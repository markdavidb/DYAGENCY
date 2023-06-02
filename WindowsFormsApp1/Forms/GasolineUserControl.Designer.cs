
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    partial class GasolineUserControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GasolineUserControl));
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbManufacturer = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbYear = new System.Windows.Forms.ComboBox();
            this.cbColor = new System.Windows.Forms.ComboBox();
            this.cbModel = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.fuelEfficiency = new System.Windows.Forms.Label();
            this.cbModifcations = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lblEngineCapacityTitle = new System.Windows.Forms.Label();
            this.lbEngineCapacityLive = new System.Windows.Forms.Label();
            this.lbHP = new System.Windows.Forms.Label();
            this.lbFuelType = new System.Windows.Forms.Label();
            this.lbKMperLiter = new System.Windows.Forms.Label();
            this.btSubmitOrder = new FontAwesome.Sharp.IconButton();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.lbType = new System.Windows.Forms.Label();
            this.panelType = new System.Windows.Forms.Panel();
            this.lbPrice = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.label10 = new System.Windows.Forms.Label();
            this.lbFirstName = new System.Windows.Forms.Label();
            this.lbLastName = new System.Windows.Forms.Label();
            this.lbPhoneNumber = new System.Windows.Forms.Label();
            this.tbFirstName = new System.Windows.Forms.TextBox();
            this.tbPhone = new System.Windows.Forms.TextBox();
            this.tbLastName = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(26, 360);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 23);
            this.label1.TabIndex = 57;
            this.label1.Text = "Color";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(26, 322);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 23);
            this.label3.TabIndex = 61;
            this.label3.Text = "Year";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Location = new System.Drawing.Point(26, 285);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 23);
            this.label4.TabIndex = 63;
            this.label4.Text = "Model";
            // 
            // cbManufacturer
            // 
            this.cbManufacturer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbManufacturer.FormattingEnabled = true;
            this.cbManufacturer.Location = new System.Drawing.Point(158, 202);
            this.cbManufacturer.Name = "cbManufacturer";
            this.cbManufacturer.Size = new System.Drawing.Size(121, 21);
            this.cbManufacturer.TabIndex = 56;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(26, 201);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 23);
            this.label2.TabIndex = 58;
            this.label2.Text = "Manufacturer";
            // 
            // cbYear
            // 
            this.cbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbYear.FormattingEnabled = true;
            this.cbYear.Location = new System.Drawing.Point(158, 321);
            this.cbYear.Name = "cbYear";
            this.cbYear.Size = new System.Drawing.Size(121, 21);
            this.cbYear.TabIndex = 59;
            this.cbYear.SelectedIndexChanged += new System.EventHandler(this.cbYear_SelectedIndexChanged);
            // 
            // cbColor
            // 
            this.cbColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbColor.FormattingEnabled = true;
            this.cbColor.Location = new System.Drawing.Point(158, 360);
            this.cbColor.Name = "cbColor";
            this.cbColor.Size = new System.Drawing.Size(121, 21);
            this.cbColor.TabIndex = 60;
            this.cbColor.SelectedIndexChanged += new System.EventHandler(this.cbColor_SelectedIndexChanged);
            // 
            // cbModel
            // 
            this.cbModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbModel.FormattingEnabled = true;
            this.cbModel.Location = new System.Drawing.Point(158, 283);
            this.cbModel.Name = "cbModel";
            this.cbModel.Size = new System.Drawing.Size(121, 21);
            this.cbModel.TabIndex = 62;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label5.Location = new System.Drawing.Point(644, 86);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 23);
            this.label5.TabIndex = 65;
            this.label5.Text = "HP";
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label6.Location = new System.Drawing.Point(912, 82);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 23);
            this.label6.TabIndex = 66;
            this.label6.Text = "Fuel Type";
            // 
            // fuelEfficiency
            // 
            this.fuelEfficiency.BackColor = System.Drawing.Color.Transparent;
            this.fuelEfficiency.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.fuelEfficiency.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.fuelEfficiency.Location = new System.Drawing.Point(912, 134);
            this.fuelEfficiency.Name = "fuelEfficiency";
            this.fuelEfficiency.Size = new System.Drawing.Size(72, 23);
            this.fuelEfficiency.TabIndex = 67;
            this.fuelEfficiency.Text = "KM/L";
            // 
            // cbModifcations
            // 
            this.cbModifcations.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbModifcations.FormattingEnabled = true;
            this.cbModifcations.Location = new System.Drawing.Point(158, 399);
            this.cbModifcations.Name = "cbModifcations";
            this.cbModifcations.Size = new System.Drawing.Size(121, 21);
            this.cbModifcations.TabIndex = 68;
            this.cbModifcations.SelectedIndexChanged += new System.EventHandler(this.cbModifcations_SelectedIndexChanged_1);
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label7.Location = new System.Drawing.Point(26, 400);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(139, 21);
            this.label7.TabIndex = 69;
            this.label7.Text = "Car Modifications";
            // 
            // lblEngineCapacityTitle
            // 
            this.lblEngineCapacityTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblEngineCapacityTitle.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.lblEngineCapacityTitle.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblEngineCapacityTitle.Location = new System.Drawing.Point(644, 134);
            this.lblEngineCapacityTitle.Name = "lblEngineCapacityTitle";
            this.lblEngineCapacityTitle.Size = new System.Drawing.Size(103, 23);
            this.lblEngineCapacityTitle.TabIndex = 70;
            this.lblEngineCapacityTitle.Text = "Engine CC";
            // 
            // lbEngineCapacityLive
            // 
            this.lbEngineCapacityLive.BackColor = System.Drawing.Color.Transparent;
            this.lbEngineCapacityLive.Font = new System.Drawing.Font("Tahoma", 11F);
            this.lbEngineCapacityLive.ForeColor = System.Drawing.SystemColors.Window;
            this.lbEngineCapacityLive.Location = new System.Drawing.Point(736, 130);
            this.lbEngineCapacityLive.Name = "lbEngineCapacityLive";
            this.lbEngineCapacityLive.Size = new System.Drawing.Size(121, 23);
            this.lbEngineCapacityLive.TabIndex = 71;
            this.lbEngineCapacityLive.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbHP
            // 
            this.lbHP.BackColor = System.Drawing.Color.Transparent;
            this.lbHP.Font = new System.Drawing.Font("Tahoma", 11F);
            this.lbHP.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lbHP.Location = new System.Drawing.Point(736, 82);
            this.lbHP.Name = "lbHP";
            this.lbHP.Size = new System.Drawing.Size(121, 23);
            this.lbHP.TabIndex = 72;
            this.lbHP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbFuelType
            // 
            this.lbFuelType.BackColor = System.Drawing.Color.Transparent;
            this.lbFuelType.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lbFuelType.Font = new System.Drawing.Font("Tahoma", 11F);
            this.lbFuelType.ForeColor = System.Drawing.Color.Gainsboro;
            this.lbFuelType.Location = new System.Drawing.Point(990, 82);
            this.lbFuelType.Name = "lbFuelType";
            this.lbFuelType.Size = new System.Drawing.Size(121, 23);
            this.lbFuelType.TabIndex = 73;
            this.lbFuelType.Text = "95";
            this.lbFuelType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbKMperLiter
            // 
            this.lbKMperLiter.BackColor = System.Drawing.Color.Transparent;
            this.lbKMperLiter.Font = new System.Drawing.Font("Tahoma", 11F);
            this.lbKMperLiter.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lbKMperLiter.Location = new System.Drawing.Point(990, 134);
            this.lbKMperLiter.Name = "lbKMperLiter";
            this.lbKMperLiter.Size = new System.Drawing.Size(121, 23);
            this.lbKMperLiter.TabIndex = 74;
            this.lbKMperLiter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btSubmitOrder
            // 
            this.btSubmitOrder.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSubmitOrder.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btSubmitOrder.IconColor = System.Drawing.Color.Black;
            this.btSubmitOrder.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btSubmitOrder.Location = new System.Drawing.Point(396, 20);
            this.btSubmitOrder.Margin = new System.Windows.Forms.Padding(2);
            this.btSubmitOrder.Name = "btSubmitOrder";
            this.btSubmitOrder.Size = new System.Drawing.Size(168, 61);
            this.btSubmitOrder.TabIndex = 75;
            this.btSubmitOrder.Text = "Submit Order";
            this.btSubmitOrder.UseVisualStyleBackColor = true;
            this.btSubmitOrder.Click += new System.EventHandler(this.btSubmitOrder_Click);
            // 
            // cbType
            // 
            this.cbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbType.FormattingEnabled = true;
            this.cbType.Location = new System.Drawing.Point(158, 245);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(121, 21);
            this.cbType.TabIndex = 76;
            this.cbType.SelectedIndexChanged += new System.EventHandler(this.cbType_SelectedIndexChanged);
            // 
            // lbType
            // 
            this.lbType.BackColor = System.Drawing.Color.Transparent;
            this.lbType.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.lbType.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbType.Location = new System.Drawing.Point(26, 242);
            this.lbType.Name = "lbType";
            this.lbType.Size = new System.Drawing.Size(72, 23);
            this.lbType.TabIndex = 77;
            this.lbType.Text = "Type";
            // 
            // panelType
            // 
            this.panelType.Location = new System.Drawing.Point(299, 189);
            this.panelType.Name = "panelType";
            this.panelType.Size = new System.Drawing.Size(288, 140);
            this.panelType.TabIndex = 78;
            // 
            // lbPrice
            // 
            this.lbPrice.BackColor = System.Drawing.Color.Transparent;
            this.lbPrice.Font = new System.Drawing.Font("Century Gothic", 25F, System.Drawing.FontStyle.Bold);
            this.lbPrice.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lbPrice.Location = new System.Drawing.Point(137, 26);
            this.lbPrice.Name = "lbPrice";
            this.lbPrice.Size = new System.Drawing.Size(155, 55);
            this.lbPrice.TabIndex = 79;
            this.lbPrice.Text = "500000";
            this.lbPrice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbPrice.Click += new System.EventHandler(this.lbPrice_Click);
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 25F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label8.Location = new System.Drawing.Point(39, 31);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(118, 43);
            this.label8.TabIndex = 80;
            this.label8.Text = "Price:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(36)))), ((int)(((byte)(77)))));
            this.pictureBox.Location = new System.Drawing.Point(610, 172);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(500, 300);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 82;
            this.pictureBox.TabStop = false;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label10.Location = new System.Drawing.Point(26, 54);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(139, 23);
            this.label10.TabIndex = 83;
            this.label10.Text = "Costumer Details:";
            // 
            // lbFirstName
            // 
            this.lbFirstName.BackColor = System.Drawing.Color.Transparent;
            this.lbFirstName.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.lbFirstName.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lbFirstName.Location = new System.Drawing.Point(26, 91);
            this.lbFirstName.Name = "lbFirstName";
            this.lbFirstName.Size = new System.Drawing.Size(84, 23);
            this.lbFirstName.TabIndex = 84;
            this.lbFirstName.Text = "First Name";
            // 
            // lbLastName
            // 
            this.lbLastName.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.lbLastName.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lbLastName.Location = new System.Drawing.Point(312, 91);
            this.lbLastName.Name = "lbLastName";
            this.lbLastName.Size = new System.Drawing.Size(85, 23);
            this.lbLastName.TabIndex = 85;
            this.lbLastName.Text = "Last Name";
            // 
            // lbPhoneNumber
            // 
            this.lbPhoneNumber.BackColor = System.Drawing.Color.Transparent;
            this.lbPhoneNumber.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.lbPhoneNumber.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lbPhoneNumber.Location = new System.Drawing.Point(26, 130);
            this.lbPhoneNumber.Name = "lbPhoneNumber";
            this.lbPhoneNumber.Size = new System.Drawing.Size(110, 23);
            this.lbPhoneNumber.TabIndex = 86;
            this.lbPhoneNumber.Text = "Phone Number";
            // 
            // tbFirstName
            // 
            this.tbFirstName.Location = new System.Drawing.Point(158, 90);
            this.tbFirstName.Name = "tbFirstName";
            this.tbFirstName.Size = new System.Drawing.Size(121, 20);
            this.tbFirstName.TabIndex = 87;
            this.tbFirstName.TextChanged += new System.EventHandler(this.tbFirstName_TextChanged_1);
            this.tbFirstName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbFirstName_KeyPress);
            // 
            // tbPhone
            // 
            this.tbPhone.Location = new System.Drawing.Point(158, 129);
            this.tbPhone.Name = "tbPhone";
            this.tbPhone.Size = new System.Drawing.Size(121, 20);
            this.tbPhone.TabIndex = 88;
            // 
            // tbLastName
            // 
            this.tbLastName.Location = new System.Drawing.Point(405, 89);
            this.tbLastName.Name = "tbLastName";
            this.tbLastName.Size = new System.Drawing.Size(121, 20);
            this.tbLastName.TabIndex = 89;
            this.tbLastName.TextChanged += new System.EventHandler(this.tbLastName_TextChanged);
            this.tbLastName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbLastName_KeyPress);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.btSubmitOrder);
            this.panel1.Controls.Add(this.lbPrice);
            this.panel1.Location = new System.Drawing.Point(519, 480);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(628, 100);
            this.panel1.TabIndex = 90;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Century Gothic", 30F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label9.Location = new System.Drawing.Point(269, 27);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 74);
            this.label9.TabIndex = 85;
            this.label9.Text = "₪";
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Location = new System.Drawing.Point(239, 480);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker.TabIndex = 91;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.label11.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label11.Location = new System.Drawing.Point(26, 480);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(189, 23);
            this.label11.TabIndex = 92;
            this.label11.Text = "Estimated Delivery Time";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(45)))));
            this.panel2.Location = new System.Drawing.Point(605, 167);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(510, 310);
            this.panel2.TabIndex = 93;
            // 
            // GasolineUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            this.Controls.Add(this.cbModifcations);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.tbLastName);
            this.Controls.Add(this.tbPhone);
            this.Controls.Add(this.tbFirstName);
            this.Controls.Add(this.lbPhoneNumber);
            this.Controls.Add(this.lbLastName);
            this.Controls.Add(this.lbFirstName);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.panelType);
            this.Controls.Add(this.lbType);
            this.Controls.Add(this.cbType);
            this.Controls.Add(this.lbKMperLiter);
            this.Controls.Add(this.lbFuelType);
            this.Controls.Add(this.lbHP);
            this.Controls.Add(this.lbEngineCapacityLive);
            this.Controls.Add(this.lblEngineCapacityTitle);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.fuelEfficiency);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbModel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbColor);
            this.Controls.Add(this.cbYear);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbManufacturer);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "GasolineUserControl";
            this.Size = new System.Drawing.Size(1155, 590);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbManufacturer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbYear;
        private System.Windows.Forms.ComboBox cbColor;
        private System.Windows.Forms.ComboBox cbModel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label fuelEfficiency;
        private System.Windows.Forms.ComboBox cbModifcations;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblEngineCapacityTitle;
        private System.Windows.Forms.Label lbEngineCapacityLive;
        private System.Windows.Forms.Label lbHP;
        private System.Windows.Forms.Label lbFuelType;
        private System.Windows.Forms.Label lbKMperLiter;
        private FontAwesome.Sharp.IconButton btSubmitOrder;
        private System.Windows.Forms.ComboBox cbType;
        private System.Windows.Forms.Label lbType;
        private System.Windows.Forms.Panel panelType;
        private System.Windows.Forms.Label lbPrice;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lbFirstName;
        private System.Windows.Forms.Label lbLastName;
        private System.Windows.Forms.Label lbPhoneNumber;
        private System.Windows.Forms.TextBox tbFirstName;
        private System.Windows.Forms.TextBox tbPhone;
        private System.Windows.Forms.TextBox tbLastName;
        private System.Windows.Forms.Panel panel1;
        private Label label9;
        private DateTimePicker dateTimePicker;
        private Label label11;
        private Panel panel2;
    }
}
