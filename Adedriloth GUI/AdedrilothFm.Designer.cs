namespace Adedriloth_GUI
{
    partial class AdedrilothFm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdedrilothFm));
            this.Outputtbx = new System.Windows.Forms.TextBox();
            this.Inputtbx = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Executebtn = new System.Windows.Forms.Button();
            this.Exitbtn = new System.Windows.Forms.Button();
            this.nameLbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Outputtbx
            // 
            this.Outputtbx.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Outputtbx.ForeColor = System.Drawing.Color.Red;
            this.Outputtbx.Location = new System.Drawing.Point(67, 363);
            this.Outputtbx.Multiline = true;
            this.Outputtbx.Name = "Outputtbx";
            this.Outputtbx.Size = new System.Drawing.Size(756, 159);
            this.Outputtbx.TabIndex = 0;
            this.Outputtbx.TextChanged += new System.EventHandler(this.Outputtbx_TextChanged);
            // 
            // Inputtbx
            // 
            this.Inputtbx.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Inputtbx.ForeColor = System.Drawing.Color.Red;
            this.Inputtbx.Location = new System.Drawing.Point(67, 541);
            this.Inputtbx.Multiline = true;
            this.Inputtbx.Name = "Inputtbx";
            this.Inputtbx.Size = new System.Drawing.Size(756, 40);
            this.Inputtbx.TabIndex = 1;
            this.Inputtbx.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Inputtbx_KeyDown);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(67, 78);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(756, 259);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // Executebtn
            // 
            this.Executebtn.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Executebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Executebtn.ForeColor = System.Drawing.Color.Red;
            this.Executebtn.Location = new System.Drawing.Point(653, 609);
            this.Executebtn.Name = "Executebtn";
            this.Executebtn.Size = new System.Drawing.Size(75, 23);
            this.Executebtn.TabIndex = 3;
            this.Executebtn.Text = "Execute";
            this.Executebtn.UseVisualStyleBackColor = false;
            this.Executebtn.Click += new System.EventHandler(this.Executebtn_Click);
            // 
            // Exitbtn
            // 
            this.Exitbtn.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Exitbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Exitbtn.ForeColor = System.Drawing.Color.Red;
            this.Exitbtn.Location = new System.Drawing.Point(748, 609);
            this.Exitbtn.Name = "Exitbtn";
            this.Exitbtn.Size = new System.Drawing.Size(75, 23);
            this.Exitbtn.TabIndex = 4;
            this.Exitbtn.Text = "Exit";
            this.Exitbtn.UseVisualStyleBackColor = false;
            this.Exitbtn.Click += new System.EventHandler(this.Exitbtn_Click);
            // 
            // nameLbl
            // 
            this.nameLbl.AutoSize = true;
            this.nameLbl.Font = new System.Drawing.Font("Kozuka Gothic Pr6N R", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameLbl.ForeColor = System.Drawing.Color.Red;
            this.nameLbl.Location = new System.Drawing.Point(255, 9);
            this.nameLbl.Name = "nameLbl";
            this.nameLbl.Size = new System.Drawing.Size(416, 51);
            this.nameLbl.TabIndex = 5;
            this.nameLbl.Text = "Adedriloth - A New Adventure";
            // 
            // AdedrilothFm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(937, 652);
            this.Controls.Add(this.nameLbl);
            this.Controls.Add(this.Exitbtn);
            this.Controls.Add(this.Executebtn);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Inputtbx);
            this.Controls.Add(this.Outputtbx);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AdedrilothFm";
            this.Text = "AdedrilothFm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Outputtbx;
        private System.Windows.Forms.TextBox Inputtbx;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button Executebtn;
        private System.Windows.Forms.Button Exitbtn;
        private System.Windows.Forms.Label nameLbl;
    }
}

