namespace Ex03.WindowsFormUI
{
    partial class FormCutomerCard
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
            this.labelOwnerName = new System.Windows.Forms.Label();
            this.textBoxOwnerName = new System.Windows.Forms.TextBox();
            this.labelOwnerPhone = new System.Windows.Forms.Label();
            this.textBoxOwnerPhone = new System.Windows.Forms.TextBox();
            this.buttonCreateCustomerCard = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelOwnerName
            // 
            this.labelOwnerName.AutoSize = true;
            this.labelOwnerName.Location = new System.Drawing.Point(12, 251);
            this.labelOwnerName.Name = "labelOwnerName";
            this.labelOwnerName.Size = new System.Drawing.Size(77, 13);
            this.labelOwnerName.TabIndex = 12;
            this.labelOwnerName.Text = "Owner\'s name:";
            // 
            // textBoxOwnerName
            // 
            this.textBoxOwnerName.Location = new System.Drawing.Point(95, 248);
            this.textBoxOwnerName.Name = "textBoxOwnerName";
            this.textBoxOwnerName.Size = new System.Drawing.Size(129, 20);
            this.textBoxOwnerName.TabIndex = 13;
            // 
            // labelOwnerPhone
            // 
            this.labelOwnerPhone.AutoSize = true;
            this.labelOwnerPhone.Location = new System.Drawing.Point(12, 280);
            this.labelOwnerPhone.Name = "labelOwnerPhone";
            this.labelOwnerPhone.Size = new System.Drawing.Size(81, 13);
            this.labelOwnerPhone.TabIndex = 14;
            this.labelOwnerPhone.Text = "Owner\'s phone:";
            // 
            // textBoxOwnerPhone
            // 
            this.textBoxOwnerPhone.Location = new System.Drawing.Point(95, 274);
            this.textBoxOwnerPhone.Name = "textBoxOwnerPhone";
            this.textBoxOwnerPhone.Size = new System.Drawing.Size(129, 20);
            this.textBoxOwnerPhone.TabIndex = 15;
            // 
            // buttonCreateCustomerCard
            // 
            this.buttonCreateCustomerCard.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonCreateCustomerCard.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCreateCustomerCard.Location = new System.Drawing.Point(68, 318);
            this.buttonCreateCustomerCard.Name = "buttonCreateCustomerCard";
            this.buttonCreateCustomerCard.Size = new System.Drawing.Size(126, 49);
            this.buttonCreateCustomerCard.TabIndex = 16;
            this.buttonCreateCustomerCard.Text = "Create customer card";
            this.buttonCreateCustomerCard.UseVisualStyleBackColor = false;
            // 
            // FormCutomerCard
            // 
            this.AcceptButton = this.buttonCreateCustomerCard;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 396);
            this.Controls.Add(this.buttonCreateCustomerCard);
            this.Controls.Add(this.textBoxOwnerPhone);
            this.Controls.Add(this.labelOwnerPhone);
            this.Controls.Add(this.textBoxOwnerName);
            this.Controls.Add(this.labelOwnerName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FormCutomerCard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fuel Car";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelOwnerName;
        private System.Windows.Forms.TextBox textBoxOwnerName;
        private System.Windows.Forms.Label labelOwnerPhone;
        private System.Windows.Forms.TextBox textBoxOwnerPhone;
        private System.Windows.Forms.Button buttonCreateCustomerCard;
    }
}