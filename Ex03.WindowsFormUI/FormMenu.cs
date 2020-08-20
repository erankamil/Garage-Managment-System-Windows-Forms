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
using MongoDB.Bson;
using MongoDB.Driver;

namespace Ex03.WindowsFormUI
{
    public partial class FormMenu : Form
    {
        private readonly Garage r_GarageManager;

        public FormMenu(IMongoCollection<BsonDocument> i_Customers, bool i_ConnectedToDB)
        {
            r_GarageManager = new Garage(i_Customers, i_ConnectedToDB);
            InitializeComponent();
            becomeListener();
            if (i_ConnectedToDB == true)
            {
                this.labelEnvironment.Text = "Logged in with MongoDB data base";
            }
            else
            {
                this.labelEnvironment.Text = "Logged in Locally";
                this.pictureBoxDB.Visible = false;
            }
        }

        private void becomeListener()
        {
            this.buttonAddNewCar.Click += ButtonAddNewCar_Click;
            this.buttonShowAllVehicles.Click += ButtonShowAllVehicles_Click;
            this.buttonChangeState.Click += ButtonChangeState_Click;
            this.buttonAirBlowing.Click += ButtonAirBlowing_Click;
            this.buttonChargeVehicle.Click += ButtonChargeVehicle_Click;
            this.buttonRefuel.Click += ButtonRefuel_Click;
            this.buttonShowCutomerCard.Click += ButtonShowCutomerCard_Click;
            this.buttonExit.Click += ButtonExit_Click;
        }

        private void ButtonRefuel_Click(object sender, EventArgs e)
        {
            FormExistCustomer formExistCustomer = new FormExistCustomer(r_GarageManager);
            formExistCustomer.ShowDialog();
            if (formExistCustomer.DialogResult == DialogResult.OK)
            {
                if (r_GarageManager.IsFuelEngine(formExistCustomer.CustomerToTreat) == true)
                {
                    FormAddEnergy formAddEnergy = new FormAddEnergy(eEnergyType.Fuel, formExistCustomer.CustomerToTreat, r_GarageManager);
                    formAddEnergy.ShowDialog();
                }
                else
                {
                    string title = "Garage notification";
                    string msg = "Vehicle engine is not support this action.";
                    MessageBox.Show(msg, title);
                }
            }
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            //string msg = "Are you sure you want to exit?";

            //MessageBoxButtons question = MessageBoxButtons.YesNo;
            //this.Hide();
            //DialogResult exithResult = MessageBox.Show(msg, "Exit", question);

            //if (exithResult == DialogResult.Yes)
            //{
            MessageBox.Show("Good Bye !! hope to see you soon");
 
        }

        private void ButtonShowCutomerCard_Click(object sender, EventArgs e)
        {
            FormExistCustomer formExistCustomer = new FormExistCustomer(r_GarageManager);
            formExistCustomer.ShowDialog();
            if (formExistCustomer.DialogResult == DialogResult.OK)
            {
                string title = "Customer details";

                CustomerCard CustomerToTreat = formExistCustomer.CustomerToTreat;
                List<string> vehicleDetails = CustomerToTreat.Vehicle.GetDetails();
                StringBuilder cusotmerDetails = new StringBuilder();
                cusotmerDetails.AppendLine($"Customer name: {CustomerToTreat.Name}\n");
                cusotmerDetails.AppendLine($"Vehicle state: {CustomerToTreat.VehicleState.ToString()}\n");
                foreach (string detail in vehicleDetails)
                {
                    cusotmerDetails.AppendLine(detail + "\n");
                }

                MessageBox.Show(cusotmerDetails.ToString(), title);
            }
        }

        private void ButtonChargeVehicle_Click(object sender, EventArgs e)
        {
            FormExistCustomer formExistCustomer = new FormExistCustomer(r_GarageManager);
            formExistCustomer.ShowDialog();
            if (formExistCustomer.DialogResult == DialogResult.OK)
            {
                if (r_GarageManager.IsElectricEngine(formExistCustomer.CustomerToTreat) == true)
                {
                    FormAddEnergy formAddEnergy = new FormAddEnergy(eEnergyType.Electric, formExistCustomer.CustomerToTreat, r_GarageManager);
                    formAddEnergy.ShowDialog();
                }
                else
                {
                    string message = "Vehicle engine is not support this action.";
                    string title = "Garage notification";
                    MessageBox.Show(message, title);
                }
            }
        }

        private void ButtonAirBlowing_Click(object sender, EventArgs e)
        {
            FormExistCustomer formExistCustomer = new FormExistCustomer(r_GarageManager);
            formExistCustomer.ShowDialog();
            if (formExistCustomer.DialogResult == DialogResult.OK)
            {
                r_GarageManager.BlowVehicleWheels(formExistCustomer.CustomerToTreat);
                StringBuilder message = new StringBuilder();
                message.AppendLine($"{formExistCustomer.CustomerToTreat.Name} Wheels blowed succesfully!");
                string title = "Blowing Wheels";
                MessageBox.Show(message.ToString(), title);
            }
        }

        private void ButtonChangeState_Click(object sender, EventArgs e)
        {
            FormExistCustomer formExistCustomer = new FormExistCustomer(r_GarageManager);
            formExistCustomer.ShowDialog();
            if (formExistCustomer.DialogResult == DialogResult.OK)
            {
                FormVehicleStates formVehicleStates = new FormVehicleStates("Change", formExistCustomer.CustomerToTreat, r_GarageManager);
                formVehicleStates.ShowDialog();
            }

        }

        private void ButtonShowAllVehicles_Click(object sender, EventArgs e)
        {
            FormVehicleStates formVehicleStates = new FormVehicleStates("Show", r_GarageManager);
            formVehicleStates.ShowDialog();
        }

        private void ButtonAddNewCar_Click(object sender, EventArgs e)
        {
            FormNewCustomer formNewCustomer = new FormNewCustomer(r_GarageManager);
            formNewCustomer.ShowDialog();
        }

        public Button buttonAddNewVehicle
        {
            get { return this.buttonAddNewCar; }
        }

        public Button buttonShowAllVehicles
        {
            get { return this.buttonShowVehicles; }
        }

        public Button buttonChangeVehicleStatus
        {
            get { return this.buttonChangeState; }
        }

        public Button buttonAirBlowing
        {
            get { return this.buttonWheelsAirBlowing; }
        }
        public Button buttonRefuelVehicle
        { 
            get { return this.buttonRefuel; }
        }

        public Button buttonVehicleCharge
        {
            get { return this.buttonChargeVehicle; }
        }

        public Button buttonShowCutomerCard
        {
            get { return this.buttonCustomerCard; }
        }

        public Button buttonExitForm
        { 
            get { return this.buttonExit; }
        }
    }
}
