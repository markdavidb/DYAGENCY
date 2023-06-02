
namespace WindowsFormsApp1.Forms
{
    partial class SUVUserControl
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
            this.cbPassengerCapacitySUV = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.check4x4 = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbPassengerCapacitySUV
            // 
            this.cbPassengerCapacitySUV.BackColor = System.Drawing.SystemColors.Window;
            this.cbPassengerCapacitySUV.FormattingEnabled = true;
            this.cbPassengerCapacitySUV.Location = new System.Drawing.Point(109, 10);
            this.cbPassengerCapacitySUV.Name = "cbPassengerCapacitySUV";
            this.cbPassengerCapacitySUV.Size = new System.Drawing.Size(121, 21);
            this.cbPassengerCapacitySUV.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(16, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 29);
            this.label1.TabIndex = 4;
            this.label1.Text = "Seating Capacity";
            // 
            // check4x4
            // 
            this.check4x4.AutoSize = true;
            this.check4x4.Location = new System.Drawing.Point(109, 59);
            this.check4x4.Name = "check4x4";
            this.check4x4.Size = new System.Drawing.Size(15, 14);
            this.check4x4.TabIndex = 7;
            this.check4x4.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(16, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 25);
            this.label2.TabIndex = 8;
            this.label2.Text = "4WD";
            // 
            // SUVUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.check4x4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbPassengerCapacitySUV);
            this.Name = "SUVUserControl";
            this.Size = new System.Drawing.Size(259, 138);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbPassengerCapacitySUV;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox check4x4;
        private System.Windows.Forms.Label label2;
    }
}
