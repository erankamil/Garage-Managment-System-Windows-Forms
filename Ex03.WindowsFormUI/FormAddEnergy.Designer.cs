namespace Ex03.WindowsFormUI
{
    partial class FormAddEnergy
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
            this.labelAddEnergy = new System.Windows.Forms.Label();
            this.labelAmountToAdd = new System.Windows.Forms.Label();
            this.textBoxMinutesToCharge = new System.Windows.Forms.TextBox();
            this.buttonChargeVehicle = new System.Windows.Forms.Button();
            this.labelFuelTypes = new System.Windows.Forms.Label();
            this.comboBoxFuelTypes = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // labelAddEnergy
            // 
            this.labelAddEnergy.AutoSize = true;
            this.labelAddEnergy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAddEnergy.Location = new System.Drawing.Point(83, 28);
            this.labelAddEnergy.Name = "labelAddEnergy";
            this.labelAddEnergy.Size = new System.Drawing.Size(147, 16);
            this.labelAddEnergy.TabIndex = 2;
            this.labelAddEnergy.Text = "Enter minutes to charge";
            this.labelAddEnergy.Click += new System.EventHandler(this.labelAddEnergy_Click);
            // 
            // labelAmountToAdd
            // 
            this.labelAmountToAdd.AutoSize = true;
            this.labelAmountToAdd.Location = new System.Drawing.Point(42, 66);
            this.labelAmountToAdd.Name = "labelAmountToAdd";
            this.labelAmountToAdd.Size = new System.Drawing.Size(47, 13);
            this.labelAmountToAdd.TabIndex = 3;
            this.labelAmountToAdd.Text = "Minutes:";
            // 
            // textBoxMinutesToCharge
            // 
            this.textBoxMinutesToCharge.Location = new System.Drawing.Point(110, 63);
            this.textBoxMinutesToCharge.Name = "textBoxMinutesToCharge";
            this.textBoxMinutesToCharge.Size = new System.Drawing.Size(120, 20);
            this.textBoxMinutesToCharge.TabIndex = 4;
            // 
            // buttonChargeVehicle
            // 
            this.buttonChargeVehicle.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.buttonChargeVehicle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonChargeVehicle.Location = new System.Drawing.Point(127, 122);
            this.buttonChargeVehicle.Name = "buttonChargeVehicle";
            this.buttonChargeVehicle.Size = new System.Drawing.Size(80, 32);
            this.buttonChargeVehicle.TabIndex = 5;
            this.buttonChargeVehicle.Text = "Charge";
            this.buttonChargeVehicle.UseVisualStyleBackColor = false;
            // 
            // labelFuelTypes
            // 
            this.labelFuelTypes.AutoSize = true;
            this.labelFuelTypes.Enabled = false;
            this.labelFuelTypes.Location = new System.Drawing.Point(42, 95);
            this.labelFuelTypes.Name = "labelFuelTypes";
            this.labelFuelTypes.Size = new System.Drawing.Size(53, 13);
            this.labelFuelTypes.TabIndex = 7;
            this.labelFuelTypes.Text = "Fuel type:";
            this.labelFuelTypes.Visible = false;
            // 
            // comboBoxFuelTypes
            // 
            this.comboBoxFuelTypes.Enabled = false;
            this.comboBoxFuelTypes.FormattingEnabled = true;
            this.comboBoxFuelTypes.Location = new System.Drawing.Point(110, 89);
            this.comboBoxFuelTypes.Name = "comboBoxFuelTypes";
            this.comboBoxFuelTypes.Size = new System.Drawing.Size(121, 21);
            this.comboBoxFuelTypes.TabIndex = 8;
            this.comboBoxFuelTypes.Visible = false;
            // 
            // FormAddEnergy
            // 
            this.AcceptButton = this.buttonChargeVehicle;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 166);
            this.Controls.Add(this.comboBoxFuelTypes);
            this.Controls.Add(this.labelFuelTypes);
            this.Controls.Add(this.buttonChargeVehicle);
            this.Controls.Add(this.textBoxMinutesToCharge);
            this.Controls.Add(this.labelAmountToAdd);
            this.Controls.Add(this.labelAddEnergy);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FormAddEnergy";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Charge vehicle";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelAddEnergy;
        private System.Windows.Forms.Label labelAmountToAdd;
        private System.Windows.Forms.TextBox textBoxMinutesToCharge;
        private System.Windows.Forms.Button buttonChargeVehicle;
        private System.Windows.Forms.Label labelFuelTypes;
        private System.Windows.Forms.ComboBox comboBoxFuelTypes;
    }
}