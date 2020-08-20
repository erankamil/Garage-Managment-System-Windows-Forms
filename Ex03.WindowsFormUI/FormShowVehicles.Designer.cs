namespace Ex03.WindowsFormUI
{
    partial class FormShowVehicles
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
            this.listBoxShowVehicles = new System.Windows.Forms.ListBox();
            this.labelShowVehicles = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listBoxShowVehicles
            // 
            this.listBoxShowVehicles.FormattingEnabled = true;
            this.listBoxShowVehicles.Location = new System.Drawing.Point(51, 65);
            this.listBoxShowVehicles.Name = "listBoxShowVehicles";
            this.listBoxShowVehicles.Size = new System.Drawing.Size(263, 186);
            this.listBoxShowVehicles.TabIndex = 0;
            // 
            // labelShowVehicles
            // 
            this.labelShowVehicles.AutoSize = true;
            this.labelShowVehicles.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelShowVehicles.Location = new System.Drawing.Point(98, 32);
            this.labelShowVehicles.Name = "labelShowVehicles";
            this.labelShowVehicles.Size = new System.Drawing.Size(164, 18);
            this.labelShowVehicles.TabIndex = 1;
            this.labelShowVehicles.Text = "Vehicle details by state: ";
            // 
            // FormShowVehicles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 283);
            this.Controls.Add(this.labelShowVehicles);
            this.Controls.Add(this.listBoxShowVehicles);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormShowVehicles";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Show Vehicles ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxShowVehicles;
        private System.Windows.Forms.Label labelShowVehicles;
    }
}