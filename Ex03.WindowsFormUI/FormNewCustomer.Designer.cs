namespace Ex03.WindowsFormUI
{
    partial class FormNewCustomer
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
            this.labelVehicleType = new System.Windows.Forms.Label();
            this.comboBoxVehicleTypes = new System.Windows.Forms.ComboBox();
            this.labelLicenseNumber = new System.Windows.Forms.Label();
            this.textBoxLicenceNumber = new System.Windows.Forms.TextBox();
            this.buttonMakeCutomerCard = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelVehicleType
            // 
            this.labelVehicleType.AutoSize = true;
            this.labelVehicleType.Location = new System.Drawing.Point(12, 34);
            this.labelVehicleType.Name = "labelVehicleType";
            this.labelVehicleType.Size = new System.Drawing.Size(72, 13);
            this.labelVehicleType.TabIndex = 0;
            this.labelVehicleType.Text = "Vehicle Type:";
            // 
            // comboBoxVehicleTypes
            // 
            this.comboBoxVehicleTypes.FormattingEnabled = true;
            this.comboBoxVehicleTypes.Location = new System.Drawing.Point(112, 31);
            this.comboBoxVehicleTypes.Name = "comboBoxVehicleTypes";
            this.comboBoxVehicleTypes.Size = new System.Drawing.Size(147, 21);
            this.comboBoxVehicleTypes.TabIndex = 1;
            // 
            // labelLicenseNumber
            // 
            this.labelLicenseNumber.AutoSize = true;
            this.labelLicenseNumber.Location = new System.Drawing.Point(12, 76);
            this.labelLicenseNumber.Name = "labelLicenseNumber";
            this.labelLicenseNumber.Size = new System.Drawing.Size(85, 13);
            this.labelLicenseNumber.TabIndex = 2;
            this.labelLicenseNumber.Text = "License number:";
            // 
            // textBoxLicenceNumber
            // 
            this.textBoxLicenceNumber.Location = new System.Drawing.Point(115, 73);
            this.textBoxLicenceNumber.Name = "textBoxLicenceNumber";
            this.textBoxLicenceNumber.Size = new System.Drawing.Size(144, 20);
            this.textBoxLicenceNumber.TabIndex = 3;
            // 
            // buttonMakeCutomerCard
            // 
            this.buttonMakeCutomerCard.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.buttonMakeCutomerCard.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMakeCutomerCard.Location = new System.Drawing.Point(69, 118);
            this.buttonMakeCutomerCard.Name = "buttonMakeCutomerCard";
            this.buttonMakeCutomerCard.Size = new System.Drawing.Size(222, 41);
            this.buttonMakeCutomerCard.TabIndex = 4;
            this.buttonMakeCutomerCard.Text = "Press to make customer card";
            this.buttonMakeCutomerCard.UseVisualStyleBackColor = false;
            // 
            // FormNewCustomer
            // 
            this.AcceptButton = this.buttonMakeCutomerCard;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(349, 185);
            this.Controls.Add(this.buttonMakeCutomerCard);
            this.Controls.Add(this.textBoxLicenceNumber);
            this.Controls.Add(this.labelLicenseNumber);
            this.Controls.Add(this.comboBoxVehicleTypes);
            this.Controls.Add(this.labelVehicleType);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FormNewCustomer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "New Customer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelVehicleType;
        private System.Windows.Forms.ComboBox comboBoxVehicleTypes;
        private System.Windows.Forms.Label labelLicenseNumber;
        private System.Windows.Forms.TextBox textBoxLicenceNumber;
        private System.Windows.Forms.Button buttonMakeCutomerCard;
    }
}