namespace Ex03.WindowsFormUI
{
    partial class FormExistCustomer
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
            this.labelLicenseNumber = new System.Windows.Forms.Label();
            this.labelExistCustomer = new System.Windows.Forms.Label();
            this.textBoxLicenseNumber = new System.Windows.Forms.TextBox();
            this.buttonFindCustomer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelLicenseNumber
            // 
            this.labelLicenseNumber.AutoSize = true;
            this.labelLicenseNumber.Location = new System.Drawing.Point(12, 81);
            this.labelLicenseNumber.Name = "labelLicenseNumber";
            this.labelLicenseNumber.Size = new System.Drawing.Size(85, 13);
            this.labelLicenseNumber.TabIndex = 0;
            this.labelLicenseNumber.Text = "License number:";
            // 
            // labelExistCustomer
            // 
            this.labelExistCustomer.AutoSize = true;
            this.labelExistCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelExistCustomer.Location = new System.Drawing.Point(68, 36);
            this.labelExistCustomer.Name = "labelExistCustomer";
            this.labelExistCustomer.Size = new System.Drawing.Size(221, 16);
            this.labelExistCustomer.TabIndex = 1;
            this.labelExistCustomer.Text = "Enter exist customer license number";
            // 
            // textBoxLicenseNumber
            // 
            this.textBoxLicenseNumber.Location = new System.Drawing.Point(103, 78);
            this.textBoxLicenseNumber.Name = "textBoxLicenseNumber";
            this.textBoxLicenseNumber.Size = new System.Drawing.Size(164, 20);
            this.textBoxLicenseNumber.TabIndex = 0;
            // 
            // buttonFindCustomer
            // 
            this.buttonFindCustomer.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.buttonFindCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonFindCustomer.Location = new System.Drawing.Point(144, 113);
            this.buttonFindCustomer.Name = "buttonFindCustomer";
            this.buttonFindCustomer.Size = new System.Drawing.Size(80, 32);
            this.buttonFindCustomer.TabIndex = 1;
            this.buttonFindCustomer.Text = "Enter";
            this.buttonFindCustomer.UseVisualStyleBackColor = false;
            // 
            // FormExistCustomer
            // 
            this.AcceptButton = this.buttonFindCustomer;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 166);
            this.Controls.Add(this.buttonFindCustomer);
            this.Controls.Add(this.textBoxLicenseNumber);
            this.Controls.Add(this.labelExistCustomer);
            this.Controls.Add(this.labelLicenseNumber);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FormExistCustomer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Find customer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelLicenseNumber;
        private System.Windows.Forms.Label labelExistCustomer;
        private System.Windows.Forms.TextBox textBoxLicenseNumber;
        private System.Windows.Forms.Button buttonFindCustomer;
    }
}