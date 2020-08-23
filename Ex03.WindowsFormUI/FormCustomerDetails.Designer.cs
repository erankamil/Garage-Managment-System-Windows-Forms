namespace Ex03.WindowsFormUI
{
    partial class FormCustomerDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCustomerDetails));
            System.Windows.Forms.Label nameLabel;
            System.Windows.Forms.Label vehicleStateLabel;
            System.Windows.Forms.Label energyPercentLabel;
            System.Windows.Forms.Label licesncePlateLabel;
            System.Windows.Forms.Label modelLabel;
            System.Windows.Forms.Label numOfPropetiesLabel;
            this.customerCardBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.customerCardBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.customerCardBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.nameLabel1 = new System.Windows.Forms.Label();
            this.vehicleStateLabel1 = new System.Windows.Forms.Label();
            this.energyPercentLabel1 = new System.Windows.Forms.Label();
            this.licesncePlateLabel1 = new System.Windows.Forms.Label();
            this.modelLabel1 = new System.Windows.Forms.Label();
            this.numOfPropetiesLabel1 = new System.Windows.Forms.Label();
            nameLabel = new System.Windows.Forms.Label();
            vehicleStateLabel = new System.Windows.Forms.Label();
            energyPercentLabel = new System.Windows.Forms.Label();
            licesncePlateLabel = new System.Windows.Forms.Label();
            modelLabel = new System.Windows.Forms.Label();
            numOfPropetiesLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.customerCardBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerCardBindingNavigator)).BeginInit();
            this.customerCardBindingNavigator.SuspendLayout();
            this.SuspendLayout();
            // 
            // customerCardBindingSource
            // 
            this.customerCardBindingSource.DataSource = typeof(Ex03.GarageLogic.CustomerCard);
            // 
            // customerCardBindingNavigator
            // 
            this.customerCardBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.customerCardBindingNavigator.BindingSource = this.customerCardBindingSource;
            this.customerCardBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.customerCardBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.customerCardBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem,
            this.customerCardBindingNavigatorSaveItem});
            this.customerCardBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.customerCardBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.customerCardBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.customerCardBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.customerCardBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.customerCardBindingNavigator.Name = "customerCardBindingNavigator";
            this.customerCardBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.customerCardBindingNavigator.Size = new System.Drawing.Size(309, 25);
            this.customerCardBindingNavigator.TabIndex = 0;
            this.customerCardBindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(35, 22);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorAddNewItem.Text = "Add new";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorDeleteItem.Text = "Delete";
            // 
            // customerCardBindingNavigatorSaveItem
            // 
            this.customerCardBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.customerCardBindingNavigatorSaveItem.Enabled = false;
            this.customerCardBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("customerCardBindingNavigatorSaveItem.Image")));
            this.customerCardBindingNavigatorSaveItem.Name = "customerCardBindingNavigatorSaveItem";
            this.customerCardBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 22);
            this.customerCardBindingNavigatorSaveItem.Text = "Save Data";
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new System.Drawing.Point(12, 39);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new System.Drawing.Size(38, 13);
            nameLabel.TabIndex = 1;
            nameLabel.Text = "Name:";
            // 
            // nameLabel1
            // 
            this.nameLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.customerCardBindingSource, "Name", true));
            this.nameLabel1.Location = new System.Drawing.Point(91, 39);
            this.nameLabel1.Name = "nameLabel1";
            this.nameLabel1.Size = new System.Drawing.Size(100, 23);
            this.nameLabel1.TabIndex = 2;
            this.nameLabel1.Text = "label1";
            // 
            // vehicleStateLabel
            // 
            vehicleStateLabel.AutoSize = true;
            vehicleStateLabel.Location = new System.Drawing.Point(12, 62);
            vehicleStateLabel.Name = "vehicleStateLabel";
            vehicleStateLabel.Size = new System.Drawing.Size(73, 13);
            vehicleStateLabel.TabIndex = 3;
            vehicleStateLabel.Text = "Vehicle State:";
            // 
            // vehicleStateLabel1
            // 
            this.vehicleStateLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.customerCardBindingSource, "VehicleState", true));
            this.vehicleStateLabel1.Location = new System.Drawing.Point(91, 62);
            this.vehicleStateLabel1.Name = "vehicleStateLabel1";
            this.vehicleStateLabel1.Size = new System.Drawing.Size(100, 23);
            this.vehicleStateLabel1.TabIndex = 4;
            this.vehicleStateLabel1.Text = "label1";
            // 
            // energyPercentLabel
            // 
            energyPercentLabel.AutoSize = true;
            energyPercentLabel.Location = new System.Drawing.Point(12, 102);
            energyPercentLabel.Name = "energyPercentLabel";
            energyPercentLabel.Size = new System.Drawing.Size(83, 13);
            energyPercentLabel.TabIndex = 5;
            energyPercentLabel.Text = "Energy Percent:";
            // 
            // energyPercentLabel1
            // 
            this.energyPercentLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.customerCardBindingSource, "Vehicle.EnergyPercent", true));
            this.energyPercentLabel1.Location = new System.Drawing.Point(111, 102);
            this.energyPercentLabel1.Name = "energyPercentLabel1";
            this.energyPercentLabel1.Size = new System.Drawing.Size(100, 23);
            this.energyPercentLabel1.TabIndex = 6;
            this.energyPercentLabel1.Text = "label1";
            // 
            // licesncePlateLabel
            // 
            licesncePlateLabel.AutoSize = true;
            licesncePlateLabel.Location = new System.Drawing.Point(12, 125);
            licesncePlateLabel.Name = "licesncePlateLabel";
            licesncePlateLabel.Size = new System.Drawing.Size(80, 13);
            licesncePlateLabel.TabIndex = 7;
            licesncePlateLabel.Text = "Licesnce Plate:";
            // 
            // licesncePlateLabel1
            // 
            this.licesncePlateLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.customerCardBindingSource, "Vehicle.LicesncePlate", true));
            this.licesncePlateLabel1.Location = new System.Drawing.Point(111, 125);
            this.licesncePlateLabel1.Name = "licesncePlateLabel1";
            this.licesncePlateLabel1.Size = new System.Drawing.Size(100, 23);
            this.licesncePlateLabel1.TabIndex = 8;
            this.licesncePlateLabel1.Text = "label1";
            // 
            // modelLabel
            // 
            modelLabel.AutoSize = true;
            modelLabel.Location = new System.Drawing.Point(12, 148);
            modelLabel.Name = "modelLabel";
            modelLabel.Size = new System.Drawing.Size(39, 13);
            modelLabel.TabIndex = 9;
            modelLabel.Text = "Model:";
            // 
            // modelLabel1
            // 
            this.modelLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.customerCardBindingSource, "Vehicle.Model", true));
            this.modelLabel1.Location = new System.Drawing.Point(111, 148);
            this.modelLabel1.Name = "modelLabel1";
            this.modelLabel1.Size = new System.Drawing.Size(100, 23);
            this.modelLabel1.TabIndex = 10;
            this.modelLabel1.Text = "label1";
            // 
            // numOfPropetiesLabel
            // 
            numOfPropetiesLabel.AutoSize = true;
            numOfPropetiesLabel.Location = new System.Drawing.Point(12, 171);
            numOfPropetiesLabel.Name = "numOfPropetiesLabel";
            numOfPropetiesLabel.Size = new System.Drawing.Size(93, 13);
            numOfPropetiesLabel.TabIndex = 11;
            numOfPropetiesLabel.Text = "Num Of Propeties:";
            // 
            // numOfPropetiesLabel1
            // 
            this.numOfPropetiesLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.customerCardBindingSource, "Vehicle.NumOfPropeties", true));
            this.numOfPropetiesLabel1.Location = new System.Drawing.Point(111, 171);
            this.numOfPropetiesLabel1.Name = "numOfPropetiesLabel1";
            this.numOfPropetiesLabel1.Size = new System.Drawing.Size(100, 23);
            this.numOfPropetiesLabel1.TabIndex = 12;
            this.numOfPropetiesLabel1.Text = "label1";
            // 
            // FormCustomerDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 218);
            this.Controls.Add(energyPercentLabel);
            this.Controls.Add(this.energyPercentLabel1);
            this.Controls.Add(licesncePlateLabel);
            this.Controls.Add(this.licesncePlateLabel1);
            this.Controls.Add(modelLabel);
            this.Controls.Add(this.modelLabel1);
            this.Controls.Add(numOfPropetiesLabel);
            this.Controls.Add(this.numOfPropetiesLabel1);
            this.Controls.Add(nameLabel);
            this.Controls.Add(this.nameLabel1);
            this.Controls.Add(vehicleStateLabel);
            this.Controls.Add(this.vehicleStateLabel1);
            this.Controls.Add(this.customerCardBindingNavigator);
            this.Name = "FormCustomerDetails";
            this.Text = "FormCustomerDetails";
            ((System.ComponentModel.ISupportInitialize)(this.customerCardBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerCardBindingNavigator)).EndInit();
            this.customerCardBindingNavigator.ResumeLayout(false);
            this.customerCardBindingNavigator.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource customerCardBindingSource;
        private System.Windows.Forms.BindingNavigator customerCardBindingNavigator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton customerCardBindingNavigatorSaveItem;
        private System.Windows.Forms.Label nameLabel1;
        private System.Windows.Forms.Label vehicleStateLabel1;
        private System.Windows.Forms.Label energyPercentLabel1;
        private System.Windows.Forms.Label licesncePlateLabel1;
        private System.Windows.Forms.Label modelLabel1;
        private System.Windows.Forms.Label numOfPropetiesLabel1;
    }
}