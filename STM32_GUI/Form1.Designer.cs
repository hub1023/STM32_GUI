namespace STM32_GUI
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.m1Strat = new System.Windows.Forms.Button();
            this.m1Stop = new System.Windows.Forms.Button();
            this.m1_ind = new System.Windows.Forms.TextBox();
            this.indicator = new System.Windows.Forms.GroupBox();
            this.motor1 = new System.Windows.Forms.Label();
            this.chTemp = new System.Windows.Forms.TextBox();
            this.tempLabel = new System.Windows.Forms.GroupBox();
            this.chHumidity = new System.Windows.Forms.TextBox();
            this.rhLabel = new System.Windows.Forms.GroupBox();
            this.m1Ctrl = new System.Windows.Forms.GroupBox();
            this.indicator.SuspendLayout();
            this.tempLabel.SuspendLayout();
            this.rhLabel.SuspendLayout();
            this.m1Ctrl.SuspendLayout();
            this.SuspendLayout();
            // 
            // serialPort1
            // 
            this.serialPort1.BaudRate = 115200;
            this.serialPort1.PortName = "COM9";
            // 
            // m1Strat
            // 
            this.m1Strat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.m1Strat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m1Strat.Location = new System.Drawing.Point(6, 19);
            this.m1Strat.Name = "m1Strat";
            this.m1Strat.Size = new System.Drawing.Size(71, 47);
            this.m1Strat.TabIndex = 0;
            this.m1Strat.Text = "START";
            this.m1Strat.UseVisualStyleBackColor = false;
            this.m1Strat.Click += new System.EventHandler(this.m1Strat_Click);
            // 
            // m1Stop
            // 
            this.m1Stop.BackColor = System.Drawing.Color.Red;
            this.m1Stop.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m1Stop.Location = new System.Drawing.Point(6, 72);
            this.m1Stop.Name = "m1Stop";
            this.m1Stop.Size = new System.Drawing.Size(71, 50);
            this.m1Stop.TabIndex = 1;
            this.m1Stop.Text = "STOP";
            this.m1Stop.UseVisualStyleBackColor = false;
            this.m1Stop.Click += new System.EventHandler(this.m1Stop_Click);
            // 
            // m1_ind
            // 
            this.m1_ind.Enabled = false;
            this.m1_ind.Location = new System.Drawing.Point(24, 33);
            this.m1_ind.Multiline = true;
            this.m1_ind.Name = "m1_ind";
            this.m1_ind.Size = new System.Drawing.Size(22, 20);
            this.m1_ind.TabIndex = 2;
            this.m1_ind.TextChanged += new System.EventHandler(this.m1_ind_TextChanged);
            // 
            // indicator
            // 
            this.indicator.Controls.Add(this.motor1);
            this.indicator.Controls.Add(this.m1_ind);
            this.indicator.Location = new System.Drawing.Point(128, 147);
            this.indicator.Name = "indicator";
            this.indicator.Size = new System.Drawing.Size(93, 136);
            this.indicator.TabIndex = 3;
            this.indicator.TabStop = false;
            this.indicator.Text = "INDICATORS";
            // 
            // motor1
            // 
            this.motor1.AutoSize = true;
            this.motor1.Location = new System.Drawing.Point(52, 37);
            this.motor1.Name = "motor1";
            this.motor1.Size = new System.Drawing.Size(22, 13);
            this.motor1.TabIndex = 4;
            this.motor1.Text = "M1";
            // 
            // chTemp
            // 
            this.chTemp.Font = new System.Drawing.Font("Arial Black", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chTemp.Location = new System.Drawing.Point(7, 19);
            this.chTemp.Name = "chTemp";
            this.chTemp.Size = new System.Drawing.Size(81, 34);
            this.chTemp.TabIndex = 4;
            this.chTemp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.chTemp.TextChanged += new System.EventHandler(this.chTemp_TextChanged);
            // 
            // tempLabel
            // 
            this.tempLabel.Controls.Add(this.chTemp);
            this.tempLabel.Location = new System.Drawing.Point(28, 58);
            this.tempLabel.Name = "tempLabel";
            this.tempLabel.Size = new System.Drawing.Size(94, 72);
            this.tempLabel.TabIndex = 5;
            this.tempLabel.TabStop = false;
            this.tempLabel.Text = "TEMP";
            // 
            // chHumidity
            // 
            this.chHumidity.Font = new System.Drawing.Font("Arial Black", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chHumidity.Location = new System.Drawing.Point(6, 19);
            this.chHumidity.Name = "chHumidity";
            this.chHumidity.Size = new System.Drawing.Size(81, 34);
            this.chHumidity.TabIndex = 6;
            this.chHumidity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.chHumidity.TextChanged += new System.EventHandler(this.chHumidity_TextChanged);
            // 
            // rhLabel
            // 
            this.rhLabel.Controls.Add(this.chHumidity);
            this.rhLabel.Location = new System.Drawing.Point(128, 58);
            this.rhLabel.Name = "rhLabel";
            this.rhLabel.Size = new System.Drawing.Size(93, 72);
            this.rhLabel.TabIndex = 7;
            this.rhLabel.TabStop = false;
            this.rhLabel.Text = "HUMIDITY";
            // 
            // m1Ctrl
            // 
            this.m1Ctrl.Controls.Add(this.m1Strat);
            this.m1Ctrl.Controls.Add(this.m1Stop);
            this.m1Ctrl.Location = new System.Drawing.Point(28, 147);
            this.m1Ctrl.Name = "m1Ctrl";
            this.m1Ctrl.Size = new System.Drawing.Size(85, 136);
            this.m1Ctrl.TabIndex = 8;
            this.m1Ctrl.TabStop = false;
            this.m1Ctrl.Text = "MOTOR";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(516, 514);
            this.Controls.Add(this.m1Ctrl);
            this.Controls.Add(this.rhLabel);
            this.Controls.Add(this.tempLabel);
            this.Controls.Add(this.indicator);
            this.Name = "Form1";
            this.Text = "DASBOARD";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.indicator.ResumeLayout(false);
            this.indicator.PerformLayout();
            this.tempLabel.ResumeLayout(false);
            this.tempLabel.PerformLayout();
            this.rhLabel.ResumeLayout(false);
            this.rhLabel.PerformLayout();
            this.m1Ctrl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Button m1Strat;
        private System.Windows.Forms.Button m1Stop;
        private System.Windows.Forms.TextBox m1_ind;
        private System.Windows.Forms.GroupBox indicator;
        private System.Windows.Forms.Label motor1;
        private System.Windows.Forms.TextBox chTemp;
        private System.Windows.Forms.GroupBox tempLabel;
        private System.Windows.Forms.TextBox chHumidity;
        private System.Windows.Forms.GroupBox rhLabel;
        private System.Windows.Forms.GroupBox m1Ctrl;
    }
}

