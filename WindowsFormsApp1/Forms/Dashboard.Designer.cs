
namespace WindowsFormsApp1.Forms
{
    partial class Dashboard
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dashboard));
            this.lbDate = new System.Windows.Forms.Label();
            this.lbClock = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbDate
            // 
            this.lbDate.BackColor = System.Drawing.Color.Transparent;
            this.lbDate.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.lbDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(115)))), ((int)(((byte)(188)))));
            this.lbDate.Location = new System.Drawing.Point(456, 380);
            this.lbDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbDate.Name = "lbDate";
            this.lbDate.Size = new System.Drawing.Size(232, 19);
            this.lbDate.TabIndex = 5;
            this.lbDate.Text = "123";
            this.lbDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbClock
            // 
            this.lbClock.BackColor = System.Drawing.Color.Transparent;
            this.lbClock.Font = new System.Drawing.Font("Century Gothic", 36F);
            this.lbClock.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(219)))), ((int)(((byte)(225)))));
            this.lbClock.Location = new System.Drawing.Point(417, 295);
            this.lbClock.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbClock.Name = "lbClock";
            this.lbClock.Size = new System.Drawing.Size(311, 102);
            this.lbClock.TabIndex = 7;
            this.lbClock.Text = "123";
            this.lbClock.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(117, 83);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(764, 285);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            this.Controls.Add(this.lbDate);
            this.Controls.Add(this.lbClock);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Dashboard";
            this.Size = new System.Drawing.Size(1155, 590);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lbDate;
        private System.Windows.Forms.Label lbClock;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
