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
    public partial class FormVehicleStates : Form
    {
        private string m_ActionToDo;
        private readonly Garage r_GarageManager;

        public CustomerCard CustomerToTreat { get; set; }

        public FormVehicleStates(string i_ActionToDo, CustomerCard i_CustomerToTreat, Garage i_GarageManager)
        {
            InitializeComponent();
            m_ActionToDo = i_ActionToDo;
            r_GarageManager = i_GarageManager;
            CustomerToTreat = i_CustomerToTreat;
            this.buttonDoAction.Text = i_ActionToDo;
            this.LabelChooseOption.Text = "Choose the state you want to change to:";
            this.buttonDoAction.Click += ButtonDoAction_Click;
            initializeVehicleStatesComboBox();
        }

        public FormVehicleStates(string i_ActionToDo, Garage i_GarageManager)
        {
            InitializeComponent();
            m_ActionToDo = i_ActionToDo;
            r_GarageManager = i_GarageManager;
            this.buttonDoAction.Click += ButtonDoAction_Click;
            initializeVehicleStatesComboBox();
        }

        private void initializeVehicleStatesComboBox()
        {
            List<string> statuses = r_GarageManager.GetStatusOptions();
            foreach (string currStatus in statuses)
            {
                if (this.buttonDoAction.Text != "Change" || currStatus != "All")
                {
                    ComboBoxVehicleStates.Items.Add(currStatus);
                }
            }
        }

        private void ButtonDoAction_Click(object sender, EventArgs e)
        {
            eVehicleState vehicleState;
            if (checkVehicleState(ComboBoxVehicleStates.Text, out vehicleState) == true)
            {
                if (m_ActionToDo == "Show")
                {
                    showVehiclesActions(vehicleState);
                }
                else
                {
                    changeStateActions(vehicleState);
                }
            }

        }

        private void changeStateActions(eVehicleState i_VehicleState)
        {
            r_GarageManager.ChangeCustomerVehicleState(CustomerToTreat, i_VehicleState);
            StringBuilder message = new StringBuilder();
            message.AppendLine($"{CustomerToTreat.Name}'s vehicle chagned state to: {CustomerToTreat.VehicleState}");
            string title = "State changed";
            MessageBox.Show(message.ToString(), title);
            this.Hide();
        }

        private void showVehiclesActions(eVehicleState i_VehicleState)
        {
            List<CustomerCard> customers = r_GarageManager.GetVehiclesByState(i_VehicleState);
            if (customers.Count > 0)
            {
                FormShowVehicles formShowVehicles = new FormShowVehicles(customers, ComboBoxVehicleStates.Text);
                formShowVehicles.ShowDialog();
            }
            else
            {
                string message = "There is no customers yet in the garage";
                string title = "Garage Notification";
                MessageBox.Show(message, title);
            }

            this.Hide();
        }

        private bool checkVehicleState(string i_VehicleState, out eVehicleState io_VehicleState)
        {
            bool isValid = true;
            io_VehicleState = eVehicleState.InRepair;

            if (String.IsNullOrEmpty(i_VehicleState) == true)
            {
                isValid = false;
                string message = "Vehicle state is empty";
                string title = "Invalid Input";
                MessageBox.Show(message, title);
            }
            else
            {
                try
                {
                    isValid = r_GarageManager.IsValidVehicleState(i_VehicleState, out io_VehicleState);
                }
                catch (GarageLogic.ValueOutOfRangeException ec)
                {
                    isValid = false;
                    string message = ec.Message;
                    string title = "Invalid Input";
                    MessageBox.Show(message, title);
                    comboBoxVehicleStates.Text = string.Empty;
                }
                catch (FormatException ec)
                {
                    isValid = false;
                    string message = ec.Message;
                    string title = "Invalid Input";
                    MessageBox.Show(message, title);
                    comboBoxVehicleStates.SelectedIndex = -1;
                }
            }

            return isValid;
        }

        public ComboBox ComboBoxVehicleStates
        {
            get { return this.comboBoxVehicleStates; }
        }

        public Label LabelVehicleState
        {
            get { return this.labelVehicleState; }
        }


        public Label LabelChooseOption
        {
            get { return this.labelChooseState; }
        }
    }
}
