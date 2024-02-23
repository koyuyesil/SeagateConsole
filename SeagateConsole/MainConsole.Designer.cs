namespace SeagateConsole
{
    partial class MainConsole
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
            components = new System.ComponentModel.Container();
            gbxFormatOptions = new GroupBox();
            EnableSeaCOSXFSpaceFormat = new CheckBox();
            EnableZoneReformatSkipping = new CheckBox();
            EnableEventBasedFormatLogging = new CheckBox();
            DisableUserPartitionCertify = new CheckBox();
            DisableUserPartitionFormat = new CheckBox();
            CorruptUserPartitionPrimaryDefects = new CheckBox();
            lblFormatOptions = new Label();
            cmbPartition = new ComboBox();
            tbxCommandString = new TextBox();
            cmbValidKey = new ComboBox();
            gbxDefectListOptions = new GroupBox();
            lblDefectListOptions = new Label();
            ActiveErrorLog = new CheckBox();
            PrimaryDefectLists = new CheckBox();
            GrownDefectLists = new CheckBox();
            btnGenerateCommand = new Button();
            trackBarMaxWrRetryCnt = new TrackBar();
            trackBarMaxRdRetryCnt = new TrackBar();
            trackBarMaxECCTLevel = new TrackBar();
            trackBarMaxCertifyTrkRewrites = new TrackBar();
            lblMaxWrRetryCnt = new Label();
            lblMaxRdRetryCnt = new Label();
            lblMaxEccTLevel = new Label();
            lblMaxCertifyTrkRewrites = new Label();
            toolTip1 = new ToolTip(components);
            cmbDataPattern = new ComboBox();
            lblCmdStringStatus = new Label();
            richTextBox1 = new RichTextBox();
            btnConnect = new Button();
            btnSwitchLevelT = new Button();
            btnSendCommand = new Button();
            gbxFormatOptions.SuspendLayout();
            gbxDefectListOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBarMaxWrRetryCnt).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBarMaxRdRetryCnt).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBarMaxECCTLevel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBarMaxCertifyTrkRewrites).BeginInit();
            SuspendLayout();
            // 
            // gbxFormatOptions
            // 
            gbxFormatOptions.Controls.Add(EnableSeaCOSXFSpaceFormat);
            gbxFormatOptions.Controls.Add(EnableZoneReformatSkipping);
            gbxFormatOptions.Controls.Add(EnableEventBasedFormatLogging);
            gbxFormatOptions.Controls.Add(DisableUserPartitionCertify);
            gbxFormatOptions.Controls.Add(DisableUserPartitionFormat);
            gbxFormatOptions.Controls.Add(CorruptUserPartitionPrimaryDefects);
            gbxFormatOptions.Controls.Add(lblFormatOptions);
            gbxFormatOptions.Location = new Point(12, 99);
            gbxFormatOptions.Name = "gbxFormatOptions";
            gbxFormatOptions.Size = new Size(271, 188);
            gbxFormatOptions.TabIndex = 2;
            gbxFormatOptions.TabStop = false;
            gbxFormatOptions.Text = "Format Options";
            // 
            // EnableSeaCOSXFSpaceFormat
            // 
            EnableSeaCOSXFSpaceFormat.AutoSize = true;
            EnableSeaCOSXFSpaceFormat.Location = new Point(9, 147);
            EnableSeaCOSXFSpaceFormat.Name = "EnableSeaCOSXFSpaceFormat";
            EnableSeaCOSXFSpaceFormat.Size = new Size(184, 19);
            EnableSeaCOSXFSpaceFormat.TabIndex = 6;
            EnableSeaCOSXFSpaceFormat.Text = "EnableSeaCOSXFSpaceFormat";
            EnableSeaCOSXFSpaceFormat.UseVisualStyleBackColor = true;
            // 
            // EnableZoneReformatSkipping
            // 
            EnableZoneReformatSkipping.AutoSize = true;
            EnableZoneReformatSkipping.Location = new Point(9, 122);
            EnableZoneReformatSkipping.Name = "EnableZoneReformatSkipping";
            EnableZoneReformatSkipping.Size = new Size(183, 19);
            EnableZoneReformatSkipping.TabIndex = 4;
            EnableZoneReformatSkipping.Text = "EnableZoneReformatSkipping";
            EnableZoneReformatSkipping.UseVisualStyleBackColor = true;
            // 
            // EnableEventBasedFormatLogging
            // 
            EnableEventBasedFormatLogging.AutoSize = true;
            EnableEventBasedFormatLogging.Location = new Point(9, 97);
            EnableEventBasedFormatLogging.Name = "EnableEventBasedFormatLogging";
            EnableEventBasedFormatLogging.Size = new Size(203, 19);
            EnableEventBasedFormatLogging.TabIndex = 3;
            EnableEventBasedFormatLogging.Text = "EnableEventBasedFormatLogging";
            EnableEventBasedFormatLogging.UseVisualStyleBackColor = true;
            // 
            // DisableUserPartitionCertify
            // 
            DisableUserPartitionCertify.AutoSize = true;
            DisableUserPartitionCertify.Location = new Point(9, 72);
            DisableUserPartitionCertify.Name = "DisableUserPartitionCertify";
            DisableUserPartitionCertify.Size = new Size(167, 19);
            DisableUserPartitionCertify.TabIndex = 2;
            DisableUserPartitionCertify.Text = "DisableUserPartitionCertify";
            DisableUserPartitionCertify.UseVisualStyleBackColor = true;
            // 
            // DisableUserPartitionFormat
            // 
            DisableUserPartitionFormat.AutoSize = true;
            DisableUserPartitionFormat.Location = new Point(9, 47);
            DisableUserPartitionFormat.Name = "DisableUserPartitionFormat";
            DisableUserPartitionFormat.Size = new Size(170, 19);
            DisableUserPartitionFormat.TabIndex = 1;
            DisableUserPartitionFormat.Text = "DisableUserPartitionFormat";
            DisableUserPartitionFormat.UseVisualStyleBackColor = true;
            // 
            // CorruptUserPartitionPrimaryDefects
            // 
            CorruptUserPartitionPrimaryDefects.AutoSize = true;
            CorruptUserPartitionPrimaryDefects.Location = new Point(9, 22);
            CorruptUserPartitionPrimaryDefects.Name = "CorruptUserPartitionPrimaryDefects";
            CorruptUserPartitionPrimaryDefects.Size = new Size(215, 19);
            CorruptUserPartitionPrimaryDefects.TabIndex = 0;
            CorruptUserPartitionPrimaryDefects.Text = "CorruptUserPartitionPrimaryDefects";
            CorruptUserPartitionPrimaryDefects.UseVisualStyleBackColor = true;
            // 
            // lblFormatOptions
            // 
            lblFormatOptions.AutoSize = true;
            lblFormatOptions.Dock = DockStyle.Bottom;
            lblFormatOptions.Location = new Point(3, 170);
            lblFormatOptions.Name = "lblFormatOptions";
            lblFormatOptions.Size = new Size(100, 15);
            lblFormatOptions.TabIndex = 2;
            lblFormatOptions.Text = "lblFormatOptions";
            // 
            // cmbPartition
            // 
            cmbPartition.FormattingEnabled = true;
            cmbPartition.Location = new Point(12, 12);
            cmbPartition.Name = "cmbPartition";
            cmbPartition.Size = new Size(271, 23);
            cmbPartition.TabIndex = 0;
            // 
            // tbxCommandString
            // 
            tbxCommandString.Location = new Point(289, 12);
            tbxCommandString.Name = "tbxCommandString";
            tbxCommandString.Size = new Size(292, 23);
            tbxCommandString.TabIndex = 8;
            tbxCommandString.TextChanged += tbxCommandString_TextChanged;
            // 
            // cmbValidKey
            // 
            cmbValidKey.FormattingEnabled = true;
            cmbValidKey.Location = new Point(12, 41);
            cmbValidKey.Name = "cmbValidKey";
            cmbValidKey.Size = new Size(271, 23);
            cmbValidKey.TabIndex = 1;
            // 
            // gbxDefectListOptions
            // 
            gbxDefectListOptions.Controls.Add(lblDefectListOptions);
            gbxDefectListOptions.Controls.Add(ActiveErrorLog);
            gbxDefectListOptions.Controls.Add(PrimaryDefectLists);
            gbxDefectListOptions.Controls.Add(GrownDefectLists);
            gbxDefectListOptions.Location = new Point(15, 307);
            gbxDefectListOptions.Name = "gbxDefectListOptions";
            gbxDefectListOptions.Size = new Size(268, 115);
            gbxDefectListOptions.TabIndex = 3;
            gbxDefectListOptions.TabStop = false;
            gbxDefectListOptions.Text = "Defect List Options";
            // 
            // lblDefectListOptions
            // 
            lblDefectListOptions.AutoSize = true;
            lblDefectListOptions.Dock = DockStyle.Bottom;
            lblDefectListOptions.Location = new Point(3, 97);
            lblDefectListOptions.Name = "lblDefectListOptions";
            lblDefectListOptions.Size = new Size(114, 15);
            lblDefectListOptions.TabIndex = 4;
            lblDefectListOptions.Text = "lblDefectListOptions";
            // 
            // ActiveErrorLog
            // 
            ActiveErrorLog.AutoSize = true;
            ActiveErrorLog.Location = new Point(6, 72);
            ActiveErrorLog.Name = "ActiveErrorLog";
            ActiveErrorLog.Size = new Size(104, 19);
            ActiveErrorLog.TabIndex = 2;
            ActiveErrorLog.Text = "ActiveErrorLog";
            ActiveErrorLog.UseVisualStyleBackColor = true;
            // 
            // PrimaryDefectLists
            // 
            PrimaryDefectLists.AutoSize = true;
            PrimaryDefectLists.Location = new Point(6, 47);
            PrimaryDefectLists.Name = "PrimaryDefectLists";
            PrimaryDefectLists.Size = new Size(124, 19);
            PrimaryDefectLists.TabIndex = 1;
            PrimaryDefectLists.Text = "PrimaryDefectLists";
            PrimaryDefectLists.UseVisualStyleBackColor = true;
            // 
            // GrownDefectLists
            // 
            GrownDefectLists.AutoSize = true;
            GrownDefectLists.Location = new Point(6, 22);
            GrownDefectLists.Name = "GrownDefectLists";
            GrownDefectLists.Size = new Size(118, 19);
            GrownDefectLists.TabIndex = 0;
            GrownDefectLists.Text = "GrownDefectLists";
            GrownDefectLists.UseVisualStyleBackColor = true;
            // 
            // btnGenerateCommand
            // 
            btnGenerateCommand.Location = new Point(587, 39);
            btnGenerateCommand.Name = "btnGenerateCommand";
            btnGenerateCommand.Size = new Size(75, 23);
            btnGenerateCommand.TabIndex = 9;
            btnGenerateCommand.Text = "Generate Command";
            btnGenerateCommand.UseVisualStyleBackColor = true;
            btnGenerateCommand.Click += GenerateCommand_Click;
            // 
            // trackBarMaxWrRetryCnt
            // 
            trackBarMaxWrRetryCnt.Location = new Point(333, 85);
            trackBarMaxWrRetryCnt.Name = "trackBarMaxWrRetryCnt";
            trackBarMaxWrRetryCnt.Size = new Size(104, 45);
            trackBarMaxWrRetryCnt.TabIndex = 4;
            // 
            // trackBarMaxRdRetryCnt
            // 
            trackBarMaxRdRetryCnt.Location = new Point(333, 136);
            trackBarMaxRdRetryCnt.Name = "trackBarMaxRdRetryCnt";
            trackBarMaxRdRetryCnt.Size = new Size(104, 45);
            trackBarMaxRdRetryCnt.TabIndex = 5;
            // 
            // trackBarMaxECCTLevel
            // 
            trackBarMaxECCTLevel.Location = new Point(333, 187);
            trackBarMaxECCTLevel.Name = "trackBarMaxECCTLevel";
            trackBarMaxECCTLevel.Size = new Size(104, 45);
            trackBarMaxECCTLevel.TabIndex = 6;
            // 
            // trackBarMaxCertifyTrkRewrites
            // 
            trackBarMaxCertifyTrkRewrites.Location = new Point(333, 238);
            trackBarMaxCertifyTrkRewrites.Name = "trackBarMaxCertifyTrkRewrites";
            trackBarMaxCertifyTrkRewrites.Size = new Size(104, 45);
            trackBarMaxCertifyTrkRewrites.TabIndex = 7;
            // 
            // lblMaxWrRetryCnt
            // 
            lblMaxWrRetryCnt.AutoSize = true;
            lblMaxWrRetryCnt.Location = new Point(443, 85);
            lblMaxWrRetryCnt.Name = "lblMaxWrRetryCnt";
            lblMaxWrRetryCnt.Size = new Size(104, 15);
            lblMaxWrRetryCnt.TabIndex = 13;
            lblMaxWrRetryCnt.Text = "lblMaxWrRetryCnt";
            // 
            // lblMaxRdRetryCnt
            // 
            lblMaxRdRetryCnt.AutoSize = true;
            lblMaxRdRetryCnt.Location = new Point(443, 136);
            lblMaxRdRetryCnt.Name = "lblMaxRdRetryCnt";
            lblMaxRdRetryCnt.Size = new Size(103, 15);
            lblMaxRdRetryCnt.TabIndex = 14;
            lblMaxRdRetryCnt.Text = "lblMaxRdRetryCnt";
            // 
            // lblMaxEccTLevel
            // 
            lblMaxEccTLevel.AutoSize = true;
            lblMaxEccTLevel.Location = new Point(443, 187);
            lblMaxEccTLevel.Name = "lblMaxEccTLevel";
            lblMaxEccTLevel.Size = new Size(94, 15);
            lblMaxEccTLevel.TabIndex = 15;
            lblMaxEccTLevel.Text = "lblMaxEccTLevel";
            // 
            // lblMaxCertifyTrkRewrites
            // 
            lblMaxCertifyTrkRewrites.AutoSize = true;
            lblMaxCertifyTrkRewrites.Location = new Point(443, 238);
            lblMaxCertifyTrkRewrites.Name = "lblMaxCertifyTrkRewrites";
            lblMaxCertifyTrkRewrites.Size = new Size(137, 15);
            lblMaxCertifyTrkRewrites.TabIndex = 16;
            lblMaxCertifyTrkRewrites.Text = "lblMaxCertifyTrkRewrites";
            // 
            // cmbDataPattern
            // 
            cmbDataPattern.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point, 162);
            cmbDataPattern.FormattingEnabled = true;
            cmbDataPattern.Location = new Point(289, 41);
            cmbDataPattern.Name = "cmbDataPattern";
            cmbDataPattern.Size = new Size(291, 22);
            cmbDataPattern.TabIndex = 17;
            // 
            // lblCmdStringStatus
            // 
            lblCmdStringStatus.AutoSize = true;
            lblCmdStringStatus.Location = new Point(333, 272);
            lblCmdStringStatus.Name = "lblCmdStringStatus";
            lblCmdStringStatus.Size = new Size(109, 15);
            lblCmdStringStatus.TabIndex = 18;
            lblCmdStringStatus.Text = "lblCmdStringStatus";
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(289, 289);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(499, 149);
            richTextBox1.TabIndex = 19;
            richTextBox1.Text = "";
            // 
            // btnConnect
            // 
            btnConnect.Location = new Point(587, 12);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(75, 23);
            btnConnect.TabIndex = 20;
            btnConnect.Text = "Connect";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click;
            // 
            // btnSwitchLevelT
            // 
            btnSwitchLevelT.Location = new Point(668, 12);
            btnSwitchLevelT.Name = "btnSwitchLevelT";
            btnSwitchLevelT.Size = new Size(120, 23);
            btnSwitchLevelT.TabIndex = 21;
            btnSwitchLevelT.Text = "Switch Level T";
            btnSwitchLevelT.UseVisualStyleBackColor = true;
            btnSwitchLevelT.Click += btnSwitchLevelT_Click;
            // 
            // btnSendCommand
            // 
            btnSendCommand.Location = new Point(668, 39);
            btnSendCommand.Name = "btnSendCommand";
            btnSendCommand.Size = new Size(120, 23);
            btnSendCommand.TabIndex = 22;
            btnSendCommand.Text = "Send Command";
            btnSendCommand.UseVisualStyleBackColor = true;
            btnSendCommand.Click += btnSendCommand_Click;
            // 
            // MainConsole
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnSendCommand);
            Controls.Add(btnSwitchLevelT);
            Controls.Add(btnConnect);
            Controls.Add(richTextBox1);
            Controls.Add(lblCmdStringStatus);
            Controls.Add(cmbDataPattern);
            Controls.Add(lblMaxCertifyTrkRewrites);
            Controls.Add(lblMaxEccTLevel);
            Controls.Add(lblMaxRdRetryCnt);
            Controls.Add(lblMaxWrRetryCnt);
            Controls.Add(trackBarMaxCertifyTrkRewrites);
            Controls.Add(trackBarMaxECCTLevel);
            Controls.Add(trackBarMaxRdRetryCnt);
            Controls.Add(trackBarMaxWrRetryCnt);
            Controls.Add(btnGenerateCommand);
            Controls.Add(gbxDefectListOptions);
            Controls.Add(cmbValidKey);
            Controls.Add(tbxCommandString);
            Controls.Add(cmbPartition);
            Controls.Add(gbxFormatOptions);
            Name = "MainConsole";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += Form1_Load;
            LocationChanged += Form1_LocationChanged;
            gbxFormatOptions.ResumeLayout(false);
            gbxFormatOptions.PerformLayout();
            gbxDefectListOptions.ResumeLayout(false);
            gbxDefectListOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackBarMaxWrRetryCnt).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBarMaxRdRetryCnt).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBarMaxECCTLevel).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBarMaxCertifyTrkRewrites).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private GroupBox gbxFormatOptions;
        private Label lblFormatOptions;
        private ComboBox cmbPartition;
        private TextBox tbxCommandString;
        private ComboBox cmbValidKey;
        private GroupBox gbxDefectListOptions;
        private CheckBox ActiveErrorLog;
        private CheckBox PrimaryDefectLists;
        private CheckBox GrownDefectLists;
        private CheckBox EnableZoneReformatSkipping;
        private CheckBox EnableEventBasedFormatLogging;
        private CheckBox DisableUserPartitionCertify;
        private CheckBox DisableUserPartitionFormat;
        private CheckBox CorruptUserPartitionPrimaryDefects;
        private CheckBox EnableSeaCOSXFSpaceFormat;
        private Button btnGenerateCommand;
        private Label lblDefectListOptions;
        private TrackBar trackBarMaxWrRetryCnt;
        private TrackBar trackBarMaxRdRetryCnt;
        private TrackBar trackBarMaxECCTLevel;
        private TrackBar trackBarMaxCertifyTrkRewrites;
        private Label lblMaxWrRetryCnt;
        private Label lblMaxRdRetryCnt;
        private Label lblMaxEccTLevel;
        private Label lblMaxCertifyTrkRewrites;
        private ToolTip toolTip1;
        private ComboBox cmbDataPattern;
        private Label lblCmdStringStatus;
        private RichTextBox richTextBox1;
        private Button btnConnect;
        private Button btnSwitchLevelT;
        private Button btnSendCommand;
    }
}
