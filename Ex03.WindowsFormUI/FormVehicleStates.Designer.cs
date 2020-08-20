namespace Ex03.WindowsFormUI
{
    partial class FormVehicleStates
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
            this.labelChooseState = new System.Windows.Forms.Label();
            this.labelVehicleState = new System.Windows.Forms.Label();
            this.comboBoxVehicleStates = new System.Windows.Forms.ComboBox();
            this.buttonDoAction = new System.Windows.Forms.Button();
            this.buttonShow = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelChooseState
            // 
            this.labelChooseState.AutoSize = true;
            this.labelChooseState.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelChooseState.Location = new System.Drawing.Point(41, 36);
            this.labelChooseState.Name = "labelChooseState";
            this.labelChooseState.Size = new System.Drawing.Size(228, 16);
            this.labelChooseState.TabIndex = 0;
            this.labelChooseState.Text = "Choose vehicle state you want to see";
            // 
            // labelVehicleState
            // 
            this.labelVehicleState.AutoSize = true;
            this.labelVehicleState.Location = new System.Drawing.Point(22, 86);
            this.labelVehicleState.Name = "labelVehicleState";
            this.labelVehicleState.Size = new System.Drawing.Size(71, 13);
            this.labelVehicleState.TabIndex = 1;
            this.labelVehicleState.Text = "Vehicle state:";
            // 
            // comboBoxVehicleStates
            // 
            this.comboBoxVehicleStates.FormattingEnabled = true;
            this.comboBoxVehicleStates.Location = new System.Drawing.Point(111, 83);
            this.comboBoxVehicleStates.Name = "comboBoxVehicleStates";
            this.comboBoxVehicleStates.Size = new System.Drawing.Size(121, 21);
            this.comboBoxVehicleStates.TabIndex = 2;
            // 
            // buttonDoAction
            // 
            this.buttonDoAction.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.buttonDoAction.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDoAction.Location = new System.Drawing.Point(130, 122);
            this.buttonDoAction.Name = "buttonDoAction";
            this.buttonDoAction.Size = new System.Drawing.Size(80, 32);
            this.buttonDoAction.TabIndex = 4;
            this.buttonDoAction.Text = "Show";
            this.buttonDoAction.UseVisualStyleBackColor = false;
            // 
            // buttonShow
            // 
            this.buttonShow.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.buttonShow.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonShow.Location = new System.Drawing.Point(130, 122);
            this.buttonShow.Name = "buttonShow";
            this.buttonShow.Size = new System.Drawing.Size(80, 32);
            this.buttonShow.TabIndex = 4;
            this.buttonShow.Text = "Show";
            this.buttonShow.UseVisualStyleBackColor = false;
            // 
            // FormVehicleStates
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 166);
            this.Controls.Add(this.buttonDoAction);
            this.Controls.Add(this.comboBoxVehicleStates);
            this.Controls.Add(this.labelVehicleState);
            this.Controls.Add(this.labelChooseState);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FormVehicleStates";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Vehicle States";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelChooseState;
        private System.Windows.Forms.Label labelVehicleState;
        private System.Windows.Forms.ComboBox comboBoxVehicleStates;
        private System.Windows.Forms.Button buttonDoAction;
        private System.Windows.Forms.Button buttonShow;
    }
}