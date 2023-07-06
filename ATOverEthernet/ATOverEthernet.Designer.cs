namespace ATOverEthernet
{
    partial class ATOverEthernetForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Label commandLabel;
            Label ipLabel;
            mainTableLayout = new TableLayoutPanel();
            commandBarTableLayout = new TableLayoutPanel();
            sendCommandButton = new Button();
            commandTextBox = new TextBox();
            outputTreeView = new TreeView();
            topBarTableLayout = new TableLayoutPanel();
            modemIPTextBox = new TextBox();
            label1 = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            m_rebootButton = new Button();
            m_caButton = new Button();
            m_temperatureButton = new Button();
            commandLabel = new Label();
            ipLabel = new Label();
            mainTableLayout.SuspendLayout();
            commandBarTableLayout.SuspendLayout();
            topBarTableLayout.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // commandLabel
            // 
            commandLabel.AutoSize = true;
            commandLabel.Dock = DockStyle.Fill;
            commandLabel.Location = new Point(3, 0);
            commandLabel.Name = "commandLabel";
            commandLabel.Size = new Size(67, 29);
            commandLabel.TabIndex = 3;
            commandLabel.Text = "Command:";
            commandLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // ipLabel
            // 
            ipLabel.AutoSize = true;
            ipLabel.Dock = DockStyle.Fill;
            ipLabel.Location = new Point(3, 0);
            ipLabel.Name = "ipLabel";
            ipLabel.Size = new Size(65, 29);
            ipLabel.TabIndex = 5;
            ipLabel.Text = "Modem IP:";
            ipLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // mainTableLayout
            // 
            mainTableLayout.ColumnCount = 2;
            mainTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            mainTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 400F));
            mainTableLayout.Controls.Add(commandBarTableLayout, 0, 2);
            mainTableLayout.Controls.Add(outputTreeView, 0, 1);
            mainTableLayout.Controls.Add(topBarTableLayout, 0, 0);
            mainTableLayout.Controls.Add(label1, 1, 0);
            mainTableLayout.Controls.Add(flowLayoutPanel1, 1, 1);
            mainTableLayout.Dock = DockStyle.Fill;
            mainTableLayout.Location = new Point(0, 0);
            mainTableLayout.Name = "mainTableLayout";
            mainTableLayout.RowCount = 3;
            mainTableLayout.RowStyles.Add(new RowStyle());
            mainTableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            mainTableLayout.RowStyles.Add(new RowStyle());
            mainTableLayout.Size = new Size(834, 411);
            mainTableLayout.TabIndex = 0;
            // 
            // commandBarTableLayout
            // 
            commandBarTableLayout.AutoSize = true;
            commandBarTableLayout.ColumnCount = 3;
            commandBarTableLayout.ColumnStyles.Add(new ColumnStyle());
            commandBarTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            commandBarTableLayout.ColumnStyles.Add(new ColumnStyle());
            commandBarTableLayout.Controls.Add(sendCommandButton, 2, 0);
            commandBarTableLayout.Controls.Add(commandTextBox, 1, 0);
            commandBarTableLayout.Controls.Add(commandLabel, 0, 0);
            commandBarTableLayout.Dock = DockStyle.Fill;
            commandBarTableLayout.Location = new Point(3, 379);
            commandBarTableLayout.Name = "commandBarTableLayout";
            commandBarTableLayout.RowCount = 1;
            commandBarTableLayout.RowStyles.Add(new RowStyle());
            commandBarTableLayout.Size = new Size(428, 29);
            commandBarTableLayout.TabIndex = 3;
            // 
            // sendCommandButton
            // 
            sendCommandButton.Location = new Point(350, 3);
            sendCommandButton.Name = "sendCommandButton";
            sendCommandButton.Size = new Size(75, 23);
            sendCommandButton.TabIndex = 0;
            sendCommandButton.Text = "Send Command";
            sendCommandButton.UseVisualStyleBackColor = true;
            sendCommandButton.Click += SendCommand_Click;
            // 
            // commandTextBox
            // 
            commandTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            commandTextBox.AutoCompleteCustomSource.AddRange(new string[] { "AT+QTEMP", "AT+QCAINFO", "AT+QENG=\"servingcell\"", "AT+QENG=\"neighbourcell\"", "AT+CFUN=1,1", "AT+CFUN=1", "AT+CFUN=0", "AT+QCFG=\"usbnet\",0", "AT+QCFG=\"usbnet\",2", "AT+CGSN", "AT+QNWPREFCFG=\"nr5g_disable_mode\"", "AT+CGDCONT?" });
            commandTextBox.AutoCompleteMode = AutoCompleteMode.Suggest;
            commandTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            commandTextBox.Location = new Point(76, 3);
            commandTextBox.Name = "commandTextBox";
            commandTextBox.Size = new Size(268, 23);
            commandTextBox.TabIndex = 2;
            // 
            // outputTreeView
            // 
            outputTreeView.Dock = DockStyle.Fill;
            outputTreeView.Location = new Point(3, 38);
            outputTreeView.Name = "outputTreeView";
            outputTreeView.Size = new Size(428, 335);
            outputTreeView.TabIndex = 1;
            // 
            // topBarTableLayout
            // 
            topBarTableLayout.AutoSize = true;
            topBarTableLayout.ColumnCount = 2;
            topBarTableLayout.ColumnStyles.Add(new ColumnStyle());
            topBarTableLayout.ColumnStyles.Add(new ColumnStyle());
            topBarTableLayout.Controls.Add(ipLabel, 0, 0);
            topBarTableLayout.Controls.Add(modemIPTextBox, 1, 0);
            topBarTableLayout.Dock = DockStyle.Fill;
            topBarTableLayout.Location = new Point(3, 3);
            topBarTableLayout.Name = "topBarTableLayout";
            topBarTableLayout.RowCount = 1;
            topBarTableLayout.RowStyles.Add(new RowStyle());
            topBarTableLayout.Size = new Size(428, 29);
            topBarTableLayout.TabIndex = 5;
            // 
            // modemIPTextBox
            // 
            modemIPTextBox.Dock = DockStyle.Left;
            modemIPTextBox.Location = new Point(74, 3);
            modemIPTextBox.Name = "modemIPTextBox";
            modemIPTextBox.Size = new Size(200, 23);
            modemIPTextBox.TabIndex = 4;
            modemIPTextBox.TextChanged += ModemIPTextBox_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Location = new Point(437, 0);
            label1.Name = "label1";
            label1.Size = new Size(394, 35);
            label1.TabIndex = 6;
            label1.Text = "Common Commands";
            label1.TextAlign = ContentAlignment.BottomCenter;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(m_rebootButton);
            flowLayoutPanel1.Controls.Add(m_caButton);
            flowLayoutPanel1.Controls.Add(m_temperatureButton);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(437, 38);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(394, 335);
            flowLayoutPanel1.TabIndex = 7;
            // 
            // m_rebootButton
            // 
            m_rebootButton.AutoSize = true;
            m_rebootButton.Location = new Point(3, 3);
            m_rebootButton.Name = "m_rebootButton";
            m_rebootButton.Size = new Size(75, 25);
            m_rebootButton.TabIndex = 0;
            m_rebootButton.Text = "Reboot";
            m_rebootButton.UseVisualStyleBackColor = true;
            m_rebootButton.Click += RebootButton_Click;
            // 
            // m_caButton
            // 
            m_caButton.AutoSize = true;
            m_caButton.Location = new Point(84, 3);
            m_caButton.Name = "m_caButton";
            m_caButton.Size = new Size(121, 25);
            m_caButton.TabIndex = 1;
            m_caButton.Text = "Carrier Aggregation";
            m_caButton.UseVisualStyleBackColor = true;
            m_caButton.Click += CarrierAggregationButton_Click;
            // 
            // m_temperatureButton
            // 
            m_temperatureButton.AutoSize = true;
            m_temperatureButton.Location = new Point(211, 3);
            m_temperatureButton.Name = "m_temperatureButton";
            m_temperatureButton.Size = new Size(121, 25);
            m_temperatureButton.TabIndex = 2;
            m_temperatureButton.Text = "Temperature";
            m_temperatureButton.UseVisualStyleBackColor = true;
            m_temperatureButton.Click += TemperatureButton_Click;
            // 
            // ATOverEthernetForm
            // 
            AcceptButton = sendCommandButton;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(834, 411);
            Controls.Add(mainTableLayout);
            MinimumSize = new Size(300, 300);
            Name = "ATOverEthernetForm";
            Text = "AT Over Ethernet";
            mainTableLayout.ResumeLayout(false);
            mainTableLayout.PerformLayout();
            commandBarTableLayout.ResumeLayout(false);
            commandBarTableLayout.PerformLayout();
            topBarTableLayout.ResumeLayout(false);
            topBarTableLayout.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel mainTableLayout;
        private TableLayoutPanel commandBarTableLayout;
        private TextBox commandTextBox;
        private Button sendCommandButton;
        private TreeView outputTreeView;
        private TableLayoutPanel topBarTableLayout;
        private TextBox modemIPTextBox;
        private Label label1;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button m_rebootButton;
        private Button m_caButton;
        private Button m_temperatureButton;
    }
}