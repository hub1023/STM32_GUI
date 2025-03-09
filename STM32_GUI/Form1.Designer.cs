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
            this.m1Strat.Location = new System.Drawing.Point(26, 42);
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
            this.m1Stop.Location = new System.Drawing.Point(123, 42);
            this.m1Stop.Name = "m1Stop";
            this.m1Stop.Size = new System.Drawing.Size(71, 50);
            this.m1Stop.TabIndex = 1;
            this.m1Stop.Text = "STOP";
            this.m1Stop.UseVisualStyleBackColor = false;
            this.m1Stop.Click += new System.EventHandler(this.m1Stop_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.m1Stop);
            this.Controls.Add(this.m1Strat);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Button m1Strat;
        private System.Windows.Forms.Button m1Stop;
    }
}

