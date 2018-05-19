namespace WFSample
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.lblArduino = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.scrollX = new System.Windows.Forms.HScrollBar();
            this.scrollY = new System.Windows.Forms.HScrollBar();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.btnRGB = new System.Windows.Forms.RadioButton();
            this.btnGRB = new System.Windows.Forms.RadioButton();
            this.btnBRG = new System.Windows.Forms.RadioButton();
            this.btnBGR = new System.Windows.Forms.RadioButton();
            this.btnGBR = new System.Windows.Forms.RadioButton();
            this.btnRBG = new System.Windows.Forms.RadioButton();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblArduino
            // 
            this.lblArduino.AutoSize = true;
            this.lblArduino.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblArduino.Location = new System.Drawing.Point(39, 0);
            this.lblArduino.Name = "lblArduino";
            this.lblArduino.Size = new System.Drawing.Size(76, 18);
            this.lblArduino.TabIndex = 0;
            this.lblArduino.Text = "Arduino";
            this.lblArduino.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.lblArduino);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(157, 186);
            this.panel1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(51)))), ((int)(((byte)(63)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold);
            this.button1.Location = new System.Drawing.Point(3, 21);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(151, 51);
            this.button1.TabIndex = 1;
            this.button1.Text = "Open Connection";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(51)))), ((int)(((byte)(63)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold);
            this.button2.Location = new System.Drawing.Point(3, 78);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(151, 51);
            this.button2.TabIndex = 2;
            this.button2.Text = "Close Connection";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(51)))), ((int)(((byte)(63)))));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold);
            this.button3.Location = new System.Drawing.Point(3, 135);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(151, 51);
            this.button3.TabIndex = 3;
            this.button3.Text = "Configurate";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button5);
            this.panel2.Controls.Add(this.button6);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(175, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(157, 186);
            this.panel2.TabIndex = 4;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(104)))), ((int)(((byte)(65)))));
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button5.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold);
            this.button5.Location = new System.Drawing.Point(3, 78);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(151, 51);
            this.button5.TabIndex = 2;
            this.button5.Text = "Stop";
            this.button5.UseVisualStyleBackColor = false;
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(104)))), ((int)(((byte)(65)))));
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button6.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.Location = new System.Drawing.Point(3, 21);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(151, 51);
            this.button6.TabIndex = 1;
            this.button6.Text = "Start";
            this.button6.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(30, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Generator";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.scrollY);
            this.panel3.Controls.Add(this.scrollX);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Location = new System.Drawing.Point(339, 13);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(267, 185);
            this.panel3.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(92, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "Settings";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // scrollX
            // 
            this.scrollX.LargeChange = 1;
            this.scrollX.Location = new System.Drawing.Point(0, 20);
            this.scrollX.Name = "scrollX";
            this.scrollX.Size = new System.Drawing.Size(267, 31);
            this.scrollX.TabIndex = 5;
            this.scrollX.Value = 33;
            // 
            // scrollY
            // 
            this.scrollY.LargeChange = 1;
            this.scrollY.Location = new System.Drawing.Point(0, 60);
            this.scrollY.Name = "scrollY";
            this.scrollY.Size = new System.Drawing.Size(267, 31);
            this.scrollY.TabIndex = 6;
            this.scrollY.Value = 66;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnBGR);
            this.panel4.Controls.Add(this.btnGBR);
            this.panel4.Controls.Add(this.btnRBG);
            this.panel4.Controls.Add(this.btnBRG);
            this.panel4.Controls.Add(this.btnGRB);
            this.panel4.Controls.Add(this.btnRGB);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Location = new System.Drawing.Point(4, 95);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(120, 87);
            this.panel4.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 18);
            this.label3.TabIndex = 8;
            this.label3.Text = "Color Order";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnRGB
            // 
            this.btnRGB.AutoSize = true;
            this.btnRGB.Checked = true;
            this.btnRGB.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRGB.Location = new System.Drawing.Point(3, 21);
            this.btnRGB.Name = "btnRGB";
            this.btnRGB.Size = new System.Drawing.Size(51, 20);
            this.btnRGB.TabIndex = 10;
            this.btnRGB.TabStop = true;
            this.btnRGB.Text = "RGB";
            this.btnRGB.UseVisualStyleBackColor = true;
            // 
            // btnGRB
            // 
            this.btnGRB.AutoSize = true;
            this.btnGRB.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGRB.Location = new System.Drawing.Point(3, 47);
            this.btnGRB.Name = "btnGRB";
            this.btnGRB.Size = new System.Drawing.Size(51, 20);
            this.btnGRB.TabIndex = 11;
            this.btnGRB.Text = "GRB";
            this.btnGRB.UseVisualStyleBackColor = true;
            // 
            // btnBRG
            // 
            this.btnBRG.AutoSize = true;
            this.btnBRG.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBRG.Location = new System.Drawing.Point(3, 70);
            this.btnBRG.Name = "btnBRG";
            this.btnBRG.Size = new System.Drawing.Size(51, 20);
            this.btnBRG.TabIndex = 12;
            this.btnBRG.Text = "BRG";
            this.btnBRG.UseVisualStyleBackColor = true;
            // 
            // btnBGR
            // 
            this.btnBGR.AutoSize = true;
            this.btnBGR.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBGR.Location = new System.Drawing.Point(60, 70);
            this.btnBGR.Name = "btnBGR";
            this.btnBGR.Size = new System.Drawing.Size(51, 20);
            this.btnBGR.TabIndex = 15;
            this.btnBGR.Text = "BGR";
            this.btnBGR.UseVisualStyleBackColor = true;
            // 
            // btnGBR
            // 
            this.btnGBR.AutoSize = true;
            this.btnGBR.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGBR.Location = new System.Drawing.Point(60, 47);
            this.btnGBR.Name = "btnGBR";
            this.btnGBR.Size = new System.Drawing.Size(51, 20);
            this.btnGBR.TabIndex = 14;
            this.btnGBR.Text = "GBR";
            this.btnGBR.UseVisualStyleBackColor = true;
            // 
            // btnRBG
            // 
            this.btnRBG.AutoSize = true;
            this.btnRBG.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRBG.Location = new System.Drawing.Point(60, 21);
            this.btnRBG.Name = "btnRBG";
            this.btnRBG.Size = new System.Drawing.Size(51, 20);
            this.btnRBG.TabIndex = 13;
            this.btnRBG.Text = "RBG";
            this.btnRBG.UseVisualStyleBackColor = true;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(92)))), ((int)(((byte)(104)))));
            this.panel5.Location = new System.Drawing.Point(131, 95);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(136, 90);
            this.panel5.TabIndex = 8;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(62)))), ((int)(((byte)(74)))));
            this.ClientSize = new System.Drawing.Size(622, 216);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(255)))), ((int)(((byte)(205)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "MainForm";
            this.Text = "FFT to RGB";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblArduino;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.HScrollBar scrollX;
        private System.Windows.Forms.HScrollBar scrollY;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton btnBRG;
        private System.Windows.Forms.RadioButton btnGRB;
        private System.Windows.Forms.RadioButton btnRGB;
        private System.Windows.Forms.RadioButton btnBGR;
        private System.Windows.Forms.RadioButton btnGBR;
        private System.Windows.Forms.RadioButton btnRBG;
        private System.Windows.Forms.Panel panel5;
    }
}