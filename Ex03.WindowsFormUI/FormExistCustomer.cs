using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ex03.GarageLogic;

namespace Ex03.WindowsFormUI
{ 
    public partial class FormExistCustomer : Form
    {
        private CustomerCard m_CustomerToTreat;
        private readonly Garage r_GarageManager;

        public FormExistCustomer(Garage i_GarageManager)
        {
            InitializeComponent();
            this.buttonFindCustomer.Click += ButtonFindCustomer_Click;
            r_GarageManager = i_GarageManager;
        }

        public CustomerCard CustomerToTreat
        {
            get { return this.m_CustomerToTreat; }
        }

        private void ButtonFindCustomer_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(TextBoxLicensePlate.Text) == true)
            {
                string message = "License Number field is empty";
                string title = "Invalid Input";
                MessageBox.Show(message, title);
            }
            else if (r_GarageManager.FindCustomer(TextBoxLicensePlate.Text, out m_CustomerToTreat) == true)
            {
                DialogResult = DialogResult.OK;
            }
            else
            {
                string message = "Customer doesn't exist";
                string title = "Garage notification";
                MessageBox.Show(message, title);
            }
        }


        public TextBox TextBoxLicensePlate
        {
            get { return this.textBoxLicenseNumber; }
        }

        public Button ButtonFindCustomer
        {
            get { return this.buttonFindCustomer; }
        }
    }
}
