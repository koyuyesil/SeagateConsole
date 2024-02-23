namespace SeagateConsole
{
    partial class SerialTestConsole
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBoxConsole = new TextBox();
            tbxPortName = new TextBox();
            tbxBaudRate = new TextBox();
            btnConnect = new Button();
            SuspendLayout();
            // 
            // textBoxConsole
            // 
            textBoxConsole.Location = new Point(12, 46);
            textBoxConsole.Multiline = true;
            textBoxConsole.Name = "textBoxConsole";
            textBoxConsole.Size = new Size(776, 392);
            textBoxConsole.TabIndex = 0;
            textBoxConsole.Click += textBoxConsole_Click;
            textBoxConsole.KeyDown += textBoxConsole_KeyDown;
            textBoxConsole.KeyPress += textBoxConsole_KeyPress;
            // 
            // tbxPortName
            // 
            tbxPortName.Location = new Point(12, 12);
            tbxPortName.Name = "tbxPortName";
            tbxPortName.Size = new Size(200, 23);
            tbxPortName.TabIndex = 1;
            tbxPortName.Text = "COM11";
            // 
            // tbxBaudRate
            // 
            tbxBaudRate.Location = new Point(218, 12);
            tbxBaudRate.Name = "tbxBaudRate";
            tbxBaudRate.Size = new Size(200, 23);
            tbxBaudRate.TabIndex = 2;
            tbxBaudRate.Text = "115200";
            // 
            // btnConnect
            // 
            btnConnect.Location = new Point(424, 12);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(364, 23);
            btnConnect.TabIndex = 3;
            btnConnect.Text = "Connect for Debug Software or Command F3 Console";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click;
            // 
            // SerialTestConsole
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnConnect);
            Controls.Add(tbxBaudRate);
            Controls.Add(tbxPortName);
            Controls.Add(textBoxConsole);
            Name = "SerialTestConsole";
            Text = "SerialTestConsole";
            FormClosing += SerialTestConsole_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxConsole;
        private TextBox tbxPortName;
        private TextBox tbxBaudRate;
        private Button btnConnect;
    }
}