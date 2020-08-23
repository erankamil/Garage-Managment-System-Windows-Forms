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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label nameLabel;
            System.Windows.Forms.Label vehicleStateLabel;
            System.Windows.Forms.Label energyPercentLabel;
            System.Windows.Forms.Label licesncePlateLabel;
            System.Windows.Forms.Label modelLabel;
            this.listBoxShowVehicles = new System.Windows.Forms.ListBox();
            this.customerCardBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.labelShowVehicles = new System.Windows.Forms.Label();
            this.nameLabel1 = new System.Windows.Forms.Label();
            this.vehicleStateLabel1 = new System.Windows.Forms.Label();
            this.energyPercentLabel1 = new System.Windows.Forms.Label();
            this.licesncePlateLabel1 = new System.Windows.Forms.Label();
            this.modelLabel1 = new System.Windows.Forms.Label();
            this.labelChosenState = new System.Windows.Forms.Label();
            nameLabel = new System.Windows.Forms.Label();
            vehicleStateLabel = new System.Windows.Forms.Label();
            energyPercentLabel = new System.Windows.Forms.Label();
            licesncePlateLabel = new System.Windows.Forms.Label();
            modelLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.customerCardBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new System.Drawing.Point(214, 56);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new System.Drawing.Size(38, 13);
            nameLabel.TabIndex = 3;
            nameLabel.Text = "Name:";
            // 
            // vehicleStateLabel
            // 
            vehicleStateLabel.AutoSize = true;
            vehicleStateLabel.Location = new System.Drawing.Point(214, 79);
            vehicleStateLabel.Name = "vehicleStateLabel";
            vehicleStateLabel.Size = new System.Drawing.Size(73, 13);
            vehicleStateLabel.TabIndex = 5;
            vehicleStateLabel.Text = "Vehicle State:";
            // 
            // energyPercentLabel
            // 
            energyPercentLabel.AutoSize = true;
            energyPercentLabel.Location = new System.Drawing.Point(214, 102);
            energyPercentLabel.Name = "energyPercentLabel";
            energyPercentLabel.Size = new System.Drawing.Size(83, 13);
            energyPercentLabel.TabIndex = 7;
            energyPercentLabel.Text = "Energy Percent:";
            // 
            // licesncePlateLabel
            // 
            licesncePlateLabel.AutoSize = true;
            licesncePlateLabel.Location = new System.Drawing.Point(214, 125);
            licesncePlateLabel.Name = "licesncePlateLabel";
            licesncePlateLabel.Size = new System.Drawing.Size(80, 13);
            licesncePlateLabel.TabIndex = 9;
            licesncePlateLabel.Text = "Licesnce Plate:";
            // 
            // modelLabel
            // 
            modelLabel.AutoSize = true;
            modelLabel.Location = new System.Drawing.Point(216, 148);
            modelLabel.Name = "modelLabel";
            modelLabel.Size = new System.Drawing.Size(39, 13);
            modelLabel.TabIndex = 11;
            modelLabel.Text = "Model:";
            // 
            // listBoxShowVehicles
            // 
            this.listBoxShowVehicles.DataSource = this.customerCardBindingSource;
            this.listBoxShowVehicles.DisplayMember = "Name";
            this.listBoxShowVehicles.FormattingEnabled = true;
            this.listBoxShowVehicles.Location = new System.Drawing.Point(12, 53);
            this.listBoxShowVehicles.Name = "listBoxShowVehicles";
            this.listBoxShowVehicles.Size = new System.Drawing.Size(172, 238);
            this.listBoxShowVehicles.TabIndex = 0;
            // 
            // customerCardBindingSource
            // 
            this.customerCardBindingSource.DataSource = typeof(Ex03.GarageLogic.CustomerCard);
            // 
            // labelShowVehicles
            // 
            this.labelShowVehicles.AutoSize = true;
            this.labelShowVehicles.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelShowVehicles.Location = new System.Drawing.Point(91, 20);
            this.labelShowVehicles.Name = "labelShowVehicles";
            this.labelShowVehicles.Size = new System.Drawing.Size(164, 18);
            this.labelShowVehicles.TabIndex = 1;
            this.labelShowVehicles.Text = "Vehicle details by state: ";
            // 
            // nameLabel1
            // 
            this.nameLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.customerCardBindingSource, "Name", true));
            this.nameLabel1.Location = new System.Drawing.Point(293, 56);
            this.nameLabel1.Name = "nameLabel1";
            this.nameLabel1.Size = new System.Drawing.Size(100, 23);
            this.nameLabel1.TabIndex = 4;
            this.nameLabel1.Text = "label1";
            // 
            // vehicleStateLabel1
            // 
            this.vehicleStateLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.customerCardBindingSource, "VehicleState", true));
            this.vehicleStateLabel1.Location = new System.Drawing.Point(293, 79);
            this.vehicleStateLabel1.Name = "vehicleStateLabel1";
            this.vehicleStateLabel1.Size = new System.Drawing.Size(100, 23);
            this.vehicleStateLabel1.TabIndex = 6;
            this.vehicleStateLabel1.Text = "label1";
            // 
            // energyPercentLabel1
            // 
            this.energyPercentLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.customerCardBindingSource, "Vehicle.EnergyPercent", true));
            this.energyPercentLabel1.Location = new System.Drawing.Point(315, 102);
            this.energyPercentLabel1.Name = "energyPercentLabel1";
            this.energyPercentLabel1.Size = new System.Drawing.Size(100, 23);
            this.energyPercentLabel1.TabIndex = 8;
            this.energyPercentLabel1.Text = "label1";
            // 
            // licesncePlateLabel1
            // 
            this.licesncePlateLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.customerCardBindingSource, "Vehicle.LicesncePlate", true));
            this.licesncePlateLabel1.Location = new System.Drawing.Point(315, 125);
            this.licesncePlateLabel1.Name = "licesncePlateLabel1";
            this.licesncePlateLabel1.Size = new System.Drawing.Size(100, 23);
            this.licesncePlateLabel1.TabIndex = 10;
            this.licesncePlateLabel1.Text = "label1";
            // 
            // modelLabel1
            // 
            this.modelLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.customerCardBindingSource, "Vehicle.Model", true));
            this.modelLabel1.Location = new System.Drawing.Point(315, 148);
            this.modelLabel1.Name = "modelLabel1";
            this.modelLabel1.Size = new System.Drawing.Size(100, 23);
            this.modelLabel1.TabIndex = 12;
            this.modelLabel1.Text = "label1";
            // 
            // labelChosenState
            // 
            this.labelChosenState.AutoSize = true;
            this.labelChosenState.Location = new System.Drawing.Point(262, 24);
            this.labelChosenState.Name = "labelChosenState";
            this.labelChosenState.Size = new System.Drawing.Size(35, 13);
            this.labelChosenState.TabIndex = 13;
            this.labelChosenState.Text = "label1";
            // 
            // FormShowVehicles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.ClientSize = new System.Drawing.Size(406, 311);
            this.Controls.Add(this.labelChosenState);
            this.Controls.Add(energyPercentLabel);
            this.Controls.Add(this.energyPercentLabel1);
            this.Controls.Add(licesncePlateLabel);
            this.Controls.Add(this.licesncePlateLabel1);
            this.Controls.Add(modelLabel);
            this.Controls.Add(this.modelLabel1);
            this.Controls.Add(nameLabel);
            this.Controls.Add(this.nameLabel1);
            this.Controls.Add(vehicleStateLabel);
            this.Controls.Add(this.vehicleStateLabel1);
            this.Controls.Add(this.labelShowVehicles);
            this.Controls.Add(this.listBoxShowVehicles);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormShowVehicles";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Show Vehicles ";
            ((System.ComponentModel.ISupportInitialize)(this.customerCardBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxShowVehicles;
        private System.Windows.Forms.Label labelShowVehicles;
        private System.Windows.Forms.BindingSource customerCardBindingSource;
        private System.Windows.Forms.Label nameLabel1;
        private System.Windows.Forms.Label vehicleStateLabel1;
        private System.Windows.Forms.Label energyPercentLabel1;
        private System.Windows.Forms.Label licesncePlateLabel1;
        private System.Windows.Forms.Label modelLabel1;
        private System.Windows.Forms.Label labelChosenState;
    }
}