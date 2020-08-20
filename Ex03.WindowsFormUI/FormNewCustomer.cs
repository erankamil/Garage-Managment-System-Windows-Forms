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
    public partial class FormNewCustomer : Form
    {
        private CustomerCard m_CustomerToTreat;
        private readonly Garage r_GarageManager;

        public FormNewCustomer(Garage i_GarageManager)
        {
            r_GarageManager = i_GarageManager;
            InitializeComponent();
            initializeComboBoxVehiceTypes();
            buttonCreateCustomerCard.Click += ButtonCreateCustomerCard_Click;
      
        }

        private void initializeComboBoxVehiceTypes()
        {
            string[] vehicleTypeNames = Ex03.GarageLogic.VehicleCreator.GetVehicleTypeNames();
            foreach (string vehicle in vehicleTypeNames)
            {
                this.comboBoxVehicleTypes.Items.Add(vehicle);
            }
        }

        //private void ButtonAddNewVehicle_Click(object sender, EventArgs e)
        //{
        //    if (DialogResult == DialogResult.OK)
        //    {
        //        Hide();
        //        newCustomerActions();
        //    }

        //    ComboBoxVehicleType.Text = string.Empty;
        //    textBoxLicencePlate.Clear();
        //}

        private void newCustomerActions()
        {
            Vehicle vehicleToCreate = GarageLogic.VehicleCreator.Create(textBoxLicencePlate.Text, ComboBoxVehicleType.Text);
            m_CustomerToTreat = new CustomerCard(vehicleToCreate);
            List<string> vehicleInfo = m_CustomerToTreat.Vehicle.GetDataNames();
            FormCutomerCard formCutomerCard = new FormCutomerCard(vehicleInfo, ComboBoxVehicleType.Text, m_CustomerToTreat, r_GarageManager);
            formCutomerCard.ShowDialog();
        }


        private void ButtonCreateCustomerCard_Click(object sender, EventArgs e)
        {
            int number;
            if (String.IsNullOrEmpty(ComboBoxVehicleType.Text) == true)
            {
                string message = "Vehicle type is empty";
                string title = "Invalid Input";
                MessageBox.Show(message, title);
            }
            else if (isValidType() == true)
            {
                if (String.IsNullOrEmpty(textBoxLicencePlate.Text) == true)
                {
                    string message = "License number field is empty";
                    string title = "Invalid Input";
                    MessageBox.Show(message, title);
                }
                else if (int.TryParse(textBoxLicencePlate.Text, out number) == false)
                {
                    string message = @"Invalid licence number
Please enter numbers only - etc:74246425";
                    string title = "Invalid Message";
                    MessageBox.Show(message, title);
                }
                else if (r_GarageManager.FindCustomer(textBoxLicencePlate.Text, out m_CustomerToTreat) == true)
                {
                    string message = "Customer alredy exist";
                    string title = "Error";
                    MessageBox.Show(message, title);
                }
                else
                {
                    Hide();
                    newCustomerActions();
                }
            }
        }

        private bool isValidType()
        {
            bool isValid = true;
            try
            {
                VehicleCreator.FromStringToVehicleTypeEnum(ComboBoxVehicleType.Text);
            }
            catch (GarageLogic.ValueOutOfRangeException ec)
            {
                isValid = false;
                string message = ec.Message;
                string title = "Invalid Input";
                MessageBox.Show(message, title);
            }
            catch (FormatException ec)
            {
                isValid = false;
                string message = ec.Message;
                string title = "Invalid Input";
                MessageBox.Show(message, title);
            }

            if (isValid == false)
            {
               ComboBoxVehicleType.SelectedIndex = -1;
            }

            return isValid;
        }


        public Button buttonCreateCustomerCard
        {
            get { return this.buttonMakeCutomerCard; }
        }

        public TextBox textBoxLicencePlate
        {
            get { return this.textBoxLicenceNumber; }
        }

        public ComboBox ComboBoxVehicleType
        {
            get { return this.comboBoxVehicleTypes; }
        }
    }
}
