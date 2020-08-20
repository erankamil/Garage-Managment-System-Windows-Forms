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
    public partial class FormAddEnergy : Form
    {
        private readonly Garage r_GarageManager;

        public eEnergyType EnergyType { get; set; }

        public CustomerCard CustomerToTreat { get; set; }

        public FormAddEnergy(eEnergyType i_Type, CustomerCard i_CustomerToTreat, Garage i_GarageManager)
        {
            EnergyType = i_Type;
            CustomerToTreat = i_CustomerToTreat;
            r_GarageManager = i_GarageManager;
            InitializeComponent();
            this.buttonAddEnergy.Click += ButtonAddEnergy_Click;
            switch(i_Type)
            {
                case eEnergyType.Fuel:
                    changeFormToFuelEngine();
                    break;
                case eEnergyType.Electric:
                    break;
            }
        }

        private void ButtonAddEnergy_Click(object sender, EventArgs e)
        {
            switch(EnergyType)
            {
                case eEnergyType.Fuel:
                    refuelActions();
                    break;
                case eEnergyType.Electric:
                    chargeActions();
                    break;
            }
        }

        private void chargeActions()
        {
            string amountToCharageStr = TextBoxMinutesToCharge.Text;
            float amount;
            if (String.IsNullOrEmpty(amountToCharageStr) == true)
            {
                string message = "Minutes field is empty";
                string title = "Invalid Input";
                MessageBox.Show(message, title);
            }
            else if (float.TryParse(amountToCharageStr, out amount) == false)
            {
                string message = "Minutes should be number";
                string title = "Invalid Input";
                MessageBox.Show(message, title);
            }
            else
            {
                if (chargeVehicle(amount) == true)
                {
                    vehicleChargedMsg(amount);
                    this.Hide();
                }
            }
        }

        private void vehicleChargedMsg(float i_MinutesToCharge)
        {
            StringBuilder message = new StringBuilder();
            message.AppendLine($"{CustomerToTreat.Name}'s Engine charged succesfully");
            string title = "Electric engine charge";
            MessageBox.Show(message.ToString(), title);
        }

        private bool chargeVehicle(float i_MinutesToCharge)
        {
            bool isValid = true;
            try
            {
                r_GarageManager.RechargeVehicle(CustomerToTreat, i_MinutesToCharge);
            }
            catch (GarageLogic.ValueOutOfRangeException ec)
            {
                string message = ec.Message;
                string title = "Invalid Input";
                MessageBox.Show(message, title);
                isValid = false;
            }

            return isValid;
        }

        private void refuelActions()
        {
            string litersStr = TextBoxMinutesToCharge.Text;
            float liters;
            if (String.IsNullOrEmpty(litersStr) == true)
            {
                string message = "Liters field is empty";
                string title = "Invalid Input";
                MessageBox.Show(message, title);
            }
            else if (float.TryParse(litersStr, out liters) == false)
            {
                string message = "Liters field should be number only";
                string title = "Invalid Input";
                MessageBox.Show(message, title);
            }
            else
            {
                if (String.IsNullOrEmpty(ComboBoxFuelTypes.Text) == true)
                {
                    string message = "Fuel types field is empty";
                    string title = "Invalid Input";
                    MessageBox.Show(message, title);
                }
                else
                {
                    if (refuelVehicle() == true)
                    {
                        vehicleRefueledMsg();
                        this.Hide();
                    }
                }
            }
        }

        private void vehicleRefueledMsg()
        {
            StringBuilder message = new StringBuilder();
            message.AppendLine($"{CustomerToTreat.Name}'s Vehicle refueled successfully!");
            string title = "Fuel engine refuel";
            MessageBox.Show(message.ToString(), title);

        }

        private bool refuelVehicle()
        {
            bool isValid = true;
            float liters = float.Parse(TextBoxMinutesToCharge.Text);
            string fuelType = ComboBoxFuelTypes.Text;
            try
            {
                r_GarageManager.RefuelVehicle(CustomerToTreat, liters, fuelType);
            }
            catch (GarageLogic.ValueOutOfRangeException ec)
            {
                isValid = false;
                string title = "Invalid Input";
                MessageBox.Show(ec.Message, title);
            }
            catch (FormatException ec)
            {
                isValid = false;
                string title = "Invalid Input";
                MessageBox.Show(ec.Message, title);
            }
            catch (ArgumentException ec)
            {
                isValid = false;
                string title = "Invalid Input";
                MessageBox.Show(ec.Message, title);
            }
            return isValid;
        }

        private void initiazlizeFuelTypesComboBox()
        {
            string[] fuelTypes = r_GarageManager.GetFuelTypes();
            foreach (string type in fuelTypes)
            {
               ComboBoxFuelTypes.Items.Add(type);
            }
        }

        private void changeFormToFuelEngine()
        {
            this.Text = "Refuel Vehicle";
            this.LabelAddEnergy.Text = "Put the amount of liters you want to add";
            this.LabelAmountToAdd.Text = "Liters:";
            this.LabelFuelTypes.Visible = true;
            this.LabelFuelTypes.Enabled = true;
            this.ComboBoxFuelTypes.Visible = true;
            this.ComboBoxFuelTypes.Enabled = true;
            this.ButtonChargeVehicle.Text = "Refuel";
            initiazlizeFuelTypesComboBox();
        }

        public TextBox TextBoxMinutesToCharge
        {
            get { return this.textBoxMinutesToCharge; }
        }

        public Button ButtonChargeVehicle
        {
            get { return this.buttonAddEnergy; }
        }

        public Label LabelAddEnergy
        {
            get { return this.labelAddEnergy; }

            set { this.labelAddEnergy = value; }
        }

        public Label LabelAmountToAdd
        {
            get { return this.labelAmountToAdd; }

            set { this.labelAmountToAdd = value; }
        }

        public Label LabelFuelTypes
        {
            get { return this.labelFuelTypes; }
        }

        public ComboBox ComboBoxFuelTypes
        {
            get { return this.comboBoxFuelTypes; }
        }

    }
}
