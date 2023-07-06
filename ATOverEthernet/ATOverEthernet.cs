using System;
using System.Net;
using System.Net.Sockets;
using System.Security.AccessControl;
using System.Text;

namespace ATOverEthernet
{
    public partial class ATOverEthernetForm : Form
    {
        public ATOverEthernetForm()
        {
            InitializeComponent();

            modemIPTextBox.Text = Properties.Settings.Default.modemIP;
        }

        private static bool EndsWith(List<char> list, string endsWith)
        {
            if (list == null || endsWith == null)
            {
                return false;
            }

            if (endsWith.Length == 0)
            {
                return true;
            }

            if (list.Count < endsWith.Length)
            {
                return false;
            }

            int startIndex = list.Count - endsWith.Length;
            for (int i = startIndex; i < list.Count; ++i)
            {
                if (list[i] != endsWith[i - startIndex])
                {
                    return false;
                }
            }
            return true;
        }

        private static async Task<string> TrySendingCommand(IPAddress ipAddress, int port, byte[] commandBytes)
        {
            IPEndPoint localEndPoint = new(ipAddress, port);

            byte[] trailingBytes = Encoding.ASCII.GetBytes("\r\n");

            byte[] atCommandBytes = new byte[commandBytes.Length + trailingBytes.Length];
            commandBytes.CopyTo(atCommandBytes, 0);
            trailingBytes.CopyTo(atCommandBytes, commandBytes.Length);

            using Socket socket = new(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                await socket.ConnectAsync(localEndPoint);

                int atCommandLength = atCommandBytes.Length;

                byte[] requestBytes = new byte[atCommandBytes.Length + 3];
                requestBytes[0] = 0xa4;
                requestBytes[1] = (byte)((atCommandLength & 0xff00) >> 8);
                requestBytes[2] = (byte)(atCommandLength & 0x00ff);
                atCommandBytes.CopyTo(requestBytes, 3);

                int bytesSent = 0;
                while (bytesSent < requestBytes.Length)
                {
                    bytesSent += await socket.SendAsync(requestBytes.AsMemory(bytesSent), SocketFlags.None);
                }

                byte[] responseBytes = new byte[256];
                List<char> responseBuffer = new();
                while (true)
                {
                    int bytesReceived;
                    try
                    {
                        bytesReceived = await socket.ReceiveAsync(responseBytes, SocketFlags.None).WaitAsync(TimeSpan.FromSeconds(2));
                    }
                    catch (TimeoutException)
                    {
                        responseBuffer.AddRange("\r\nERROR: Timed out\r\n");
                        break;
                    }

                    // Receiving 0 bytes means EOF has been reached
                    // This doesn't always happen
                    if (bytesReceived == 0)
                    {
                        break;
                    }

                    char[] responseChars = new char[512];
                    int charCount = Encoding.ASCII.GetChars(responseBytes, 0, bytesReceived, responseChars, 0);

                    for (int i = 0; i < charCount; i++)
                    {
                        responseBuffer.Add(responseChars[i]);
                    }

                    // Don't always get a EOF, try to guess that we're at the end of the response
                    if (EndsWith(responseBuffer, "OK\r\n") || EndsWith(responseBuffer, "ERROR\r\n"))
                    {
                        break;
                    }
                }

                if (responseBuffer.Count > 0)
                {
                    string rawResponse = new(responseBuffer.ToArray());

                    // Remove any info that the modem says prior to the response, like the RGMII interface is ready
                    int removeFromIndex = rawResponse.IndexOf("\r\n");
                    if (removeFromIndex < 0)
                    {
                        return "Incomplete or corrupted message received";
                    }

                    return rawResponse[removeFromIndex..].Trim();
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return "No response from modem, if the command issued a reboot then this is typical.";
        }

        private Task<string>? m_currentCommandTask;

        private void OnReceiveTaskComplete(string command, string response)
        {
            outputTreeView.Invoke(() =>
            {
                outputTreeView.BeginUpdate();
                int parentIndex = outputTreeView.Nodes.Add(new TreeNode(command));

                string[] lines = response.Split("\r\n", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
                foreach (string line in lines)
                {
                    outputTreeView.Nodes[parentIndex].Nodes.Add(new TreeNode(line));
                }

                outputTreeView.EndUpdate();

                outputTreeView.Nodes[parentIndex].Nodes[^1].EnsureVisible();
            });

            sendCommandButton.Invoke(() =>
            {
                sendCommandButton.Enabled = true;
                sendCommandButton.Text = "Send";
            });
        }

        readonly HashSet<Control> m_flashingControls = new();
        private async void FlashControl(Control control)
        {
            if (!m_flashingControls.Add(control))
            {
                return;
            }

            Color flashColor = Color.Red;

            float duration = 200; // milliseconds
            int steps = 20;
            float interval = duration / steps;

            Color original = control.BackColor;

            float interpolant = 0.0f;
            while (interpolant < 1.0f)
            {
                Color c = InterpolateColour(flashColor, original, interpolant);
                control.BackColor = c;
                await Task.Delay((int)interval);
                interpolant += (1.0f / steps);
            }

            control.BackColor = original;

            m_flashingControls.Remove(control);
        }

        public static Color InterpolateColour(Color c1, Color c2, float alpha)
        {
            float oneMinusAlpha = 1.0f - alpha;
            float a = oneMinusAlpha * c1.A + alpha * c2.A;
            float r = oneMinusAlpha * c1.R + alpha * c2.R;
            float g = oneMinusAlpha * c1.G + alpha * c2.G;
            float b = oneMinusAlpha * c1.B + alpha * c2.B;
            return Color.FromArgb((int)a, (int)r, (int)g, (int)b);
        }

        private void SendPendingCommand(string? overrideCommand = null)
        {
            if (m_currentCommandTask != null && !m_currentCommandTask.IsCompleted)
            {
                return;
            }

            string command = overrideCommand ?? commandTextBox.Text;
            if (command.Length == 0)
            {
                FlashControl(commandTextBox);
            }
            if (overrideCommand == null)
            {
                commandTextBox.Text = "";
            }

            if (IPAddress.TryParse(modemIPTextBox.Text, out IPAddress? ipAddress))
            {
                if (command.Length == 0)
                {
                    return;
                }
                sendCommandButton.Enabled = false;
                sendCommandButton.Text = "Waiting...";

                m_currentCommandTask = TrySendingCommand(ipAddress, 1555, Encoding.ASCII.GetBytes(command));
                m_currentCommandTask.ContinueWith(t => OnReceiveTaskComplete(command, t.Result));
            }
            else
            {
                FlashControl(modemIPTextBox);

                outputTreeView.Invoke(() =>
                {
                    outputTreeView.BeginUpdate();
                    int parentIndex = outputTreeView.Nodes.Add(new TreeNode(string.IsNullOrWhiteSpace(command) ? "<no command>" : command));
                    outputTreeView.Nodes[parentIndex].Nodes.Add(new TreeNode("Modem IP is invalid. The default is 192.168.225.1."));
                    outputTreeView.EndUpdate();

                    outputTreeView.Nodes[parentIndex].Nodes[^1].EnsureVisible();
                });
            }
        }

        private void SendCommand_Click(object sender, EventArgs e)
        {
            SendPendingCommand();
        }

        private void ModemIPTextBox_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.modemIP = modemIPTextBox.Text;
            Properties.Settings.Default.Save();
        }

        private void RebootButton_Click(object sender, EventArgs e)
        {
            SendPendingCommand("AT+CFUN=1,1");
        }

        private void CarrierAggregationButton_Click(object sender, EventArgs e)
        {
            SendPendingCommand("AT+QCAINFO");
        }

        private void TemperatureButton_Click(object sender, EventArgs e)
        {
            SendPendingCommand("AT+QTEMP");
        }
    }
}