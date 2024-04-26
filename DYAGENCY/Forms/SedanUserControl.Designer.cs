
namespace DYAGENCY.Forms
{
    partial class SedanUserControl
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
            this.cbPassengerCapacity = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbInteriorColor = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbSunRoof = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbPassengerCapacity
            // 
            this.cbPassengerCapacity.BackColor = System.Drawing.SystemColors.Window;
            this.cbPassengerCapacity.FormattingEnabled = true;
            this.cbPassengerCapacity.Location = new System.Drawing.Point(164, 10);
            this.cbPassengerCapacity.Name = "cbPassengerCapacity";
            this.cbPassengerCapacity.Size = new System.Drawing.Size(121, 21);
            this.cbPassengerCapacity.TabIndex = 0;
            this.cbPassengerCapacity.SelectedIndexChanged += new System.EventHandler(this.cbPassengerCapacity_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(16, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "Passenger Capacity";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // cbInteriorColor
            // 
            this.cbInteriorColor.FormattingEnabled = true;
            this.cbInteriorColor.Location = new System.Drawing.Point(164, 56);
            this.cbInteriorColor.Name = "cbInteriorColor";
            this.cbInteriorColor.Size = new System.Drawing.Size(121, 21);
            this.cbInteriorColor.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(16, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "Interior Color";
            // 
            // cbSunRoof
            // 
            this.cbSunRoof.AutoSize = true;
            this.cbSunRoof.Location = new System.Drawing.Point(164, 98);
            this.cbSunRoof.Name = "cbSunRoof";
            this.cbSunRoof.Size = new System.Drawing.Size(15, 14);
            this.cbSunRoof.TabIndex = 4;
            this.cbSunRoof.UseVisualStyleBackColor = true;
            this.cbSunRoof.CheckedChanged += new System.EventHandler(this.cbSunRoof_CheckedChanged);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label3.Location = new System.Drawing.Point(16, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 32);
            this.label3.TabIndex = 5;
            this.label3.Text = "Sun Roof";
            // 
            // SedanUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbSunRoof);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbInteriorColor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbPassengerCapacity);
            this.Name = "SedanUserControl";
            this.Size = new System.Drawing.Size(348, 181);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbInteriorColor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cbSunRoof;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbPassengerCapacity;
    }
}
