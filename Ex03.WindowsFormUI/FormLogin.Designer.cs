namespace Ex03.WindowsFormUI
{
    partial class FormLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            this.pictureBoxDB = new System.Windows.Forms.PictureBox();
            this.labelEnterDetails = new System.Windows.Forms.Label();
            this.buttonLocal = new System.Windows.Forms.Button();
            this.buttonToDB = new System.Windows.Forms.Button();
            this.labelChooseConnetion = new System.Windows.Forms.Label();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.labelUserName = new System.Windows.Forms.Label();
            this.labelPassword = new System.Windows.Forms.Label();
            this.textBoxUserName = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDB)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxDB
            // 
            this.pictureBoxDB.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pictureBoxDB.BackgroundImage = global::Ex03.WindowsFormUI.Properties.Resources.servers;
            this.pictureBoxDB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxDB.Location = new System.Drawing.Point(142, 12);
            this.pictureBoxDB.Name = "pictureBoxDB";
            this.pictureBoxDB.Size = new System.Drawing.Size(67, 48);
            this.pictureBoxDB.TabIndex = 0;
            this.pictureBoxDB.TabStop = false;
            // 
            // labelEnterDetails
            // 
            this.labelEnterDetails.AutoSize = true;
            this.labelEnterDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEnterDetails.Location = new System.Drawing.Point(84, 25);
            this.labelEnterDetails.Name = "labelEnterDetails";
            this.labelEnterDetails.Size = new System.Drawing.Size(183, 16);
            this.labelEnterDetails.TabIndex = 1;
            this.labelEnterDetails.Text = "Please enter the login details:";
            this.labelEnterDetails.Visible = false;
            // 
            // buttonLocal
            // 
            this.buttonLocal.BackColor = System.Drawing.Color.Lavender;
            this.buttonLocal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLocal.Location = new System.Drawing.Point(61, 104);
            this.buttonLocal.Name = "buttonLocal";
            this.buttonLocal.Size = new System.Drawing.Size(110, 37);
            this.buttonLocal.TabIndex = 2;
            this.buttonLocal.Text = "connect locally";
            this.buttonLocal.UseVisualStyleBackColor = false;
            // 
            // buttonToDB
            // 
            this.buttonToDB.BackColor = System.Drawing.Color.Lavender;
            this.buttonToDB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonToDB.Location = new System.Drawing.Point(198, 104);
            this.buttonToDB.Name = "buttonToDB";
            this.buttonToDB.Size = new System.Drawing.Size(104, 37);
            this.buttonToDB.TabIndex = 3;
            this.buttonToDB.Text = "connect to DB";
            this.buttonToDB.UseVisualStyleBackColor = false;
            // 
            // labelChooseConnetion
            // 
            this.labelChooseConnetion.AutoSize = true;
            this.labelChooseConnetion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelChooseConnetion.Location = new System.Drawing.Point(74, 75);
            this.labelChooseConnetion.Name = "labelChooseConnetion";
            this.labelChooseConnetion.Size = new System.Drawing.Size(228, 16);
            this.labelChooseConnetion.TabIndex = 4;
            this.labelChooseConnetion.Text = "Please choose your connection type:";
            // 
            // buttonConnect
            // 
            this.buttonConnect.BackColor = System.Drawing.Color.Lavender;
            this.buttonConnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonConnect.Location = new System.Drawing.Point(142, 130);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(83, 35);
            this.buttonConnect.TabIndex = 5;
            this.buttonConnect.Text = "Connect";
            this.buttonConnect.UseVisualStyleBackColor = false;
            this.buttonConnect.Visible = false;
            // 
            // labelUserName
            // 
            this.labelUserName.AutoSize = true;
            this.labelUserName.Location = new System.Drawing.Point(36, 62);
            this.labelUserName.Name = "labelUserName";
            this.labelUserName.Size = new System.Drawing.Size(63, 13);
            this.labelUserName.TabIndex = 6;
            this.labelUserName.Text = "User Name:";
            this.labelUserName.Visible = false;
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(36, 104);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(56, 13);
            this.labelPassword.TabIndex = 7;
            this.labelPassword.Text = "Password:";
            this.labelPassword.Visible = false;
            // 
            // textBoxUserName
            // 
            this.textBoxUserName.Location = new System.Drawing.Point(118, 59);
            this.textBoxUserName.Name = "textBoxUserName";
            this.textBoxUserName.Size = new System.Drawing.Size(149, 20);
            this.textBoxUserName.TabIndex = 8;
            this.textBoxUserName.Visible = false;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(118, 101);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(149, 20);
            this.textBoxPassword.TabIndex = 9;
            this.textBoxPassword.Visible = false;
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(368, 177);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.textBoxUserName);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.labelUserName);
            this.Controls.Add(this.buttonConnect);
            this.Controls.Add(this.labelChooseConnetion);
            this.Controls.Add(this.buttonToDB);
            this.Controls.Add(this.buttonLocal);
            this.Controls.Add(this.labelEnterDetails);
            this.Controls.Add(this.pictureBoxDB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DB login";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxDB;
        private System.Windows.Forms.Label labelEnterDetails;
        private System.Windows.Forms.Button buttonLocal;
        private System.Windows.Forms.Button buttonToDB;
        private System.Windows.Forms.Label labelChooseConnetion;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.Label labelUserName;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.TextBox textBoxUserName;
        private System.Windows.Forms.TextBox textBoxPassword;
    }
}