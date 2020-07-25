using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ex03.GarageLogic;
using MongoDB.Driver;
using MongoDB.Bson;

namespace Ex03.WindowsFormUI
{
    class UI
    {
        private FormMenu m_FormMenu;
        private FormNewCustomer m_FormNewCustomer;
        private FormCutomerCard m_FormCutomerCard;
        private FormExistCustomer m_FormExistCustomer;
        private FormVehicleStates m_FormVehicleStates;
        private FormAddEnergy m_FormChargeVehicle;
        private Garage m_Garage;
        private CustomerCard m_CustomerToTreat;
        private IMongoCollection<BsonDocument> m_Collection;

        public UI()
        {

            //var dbClient = new MongoClient("mongodb+srv://dbUser:<pa55w.rd>@cluster0.ufirq.mongodb.net/<garageDB>?retryWrites=true&w=majority");
            //var database = dbClient.GetDatabase("sample_training");
            //m_Collection = database.GetCollection<BsonDocument>("customersCards");

            Application.EnableVisualStyles();
            m_FormMenu = new FormMenu();
            m_Garage = new Garage();
            m_FormChargeVehicle = new FormAddEnergy();
            m_FormExistCustomer = new FormExistCustomer();
            m_FormVehicleStates = new FormVehicleStates();
            m_FormNewCustomer = new FormNewCustomer();
            initializeComboBoxVehiceTypes(m_FormNewCustomer.ComboBoxVehicleType);
            initializeVehicleStatesComboBox(m_FormVehicleStates.ComboBoxVehicleStates);
            initiazlizeFuelTypesComboBox(m_FormChargeVehicle.ComboBoxFuelTypes);
            initializeComponents();
        }

        public void RunApp()
        {
            m_FormMenu.DialogResult = DialogResult.OK;
            while (m_FormMenu.DialogResult == DialogResult.OK)
            {
                m_FormMenu.ShowDialog();
            }
        }

        private void initializeComponents()
        {
            m_FormNewCustomer.buttonCreateCustomerCard.Click += ButtonMakeCustomerCard_Click;
            m_FormChargeVehicle.ButtonChargeVehicle.Click += ButtonChargeVehicle_Click;
            m_FormExistCustomer.ButtonFindCustomer.Click += ButtonFindCustomer_Click;
            m_FormMenu.CancelButton = m_FormMenu.buttonExitForm;
            m_FormMenu.buttonAddNewVehicle.Click += ButtonAddNewVehicle_Click;
            m_FormMenu.buttonShowAllVehicles.Click += ButtonShowAllVehicles_Click;
            m_FormMenu.buttonChangeVehicleStatus.Click += ButtonChangeVehicleStatus_Click;
            m_FormMenu.buttonAirBlowing.Click += ButtonAirBlowing_Click;
            m_FormMenu.buttonRefuelVehicle.Click += ButtonRefuelVehicle_Click;
            m_FormMenu.buttonVehicleCharge.Click += ButtonVehicleCharge_Click;
            m_FormMenu.buttonShowCutomerCard.Click += ButtonShowCutomerCard_Click;
            m_FormMenu.buttonExitForm.Click += ButtonExitForm_Click;
            m_FormVehicleStates.ButtonOk.Click += ButtonOk_Click; 
        }

        private void initializeComboBoxVehiceTypes(ComboBox i_ComboBoxVehicleTypes)
        {
            string[] vehicleTypeNames = Ex03.GarageLogic.VehicleCreator.GetVehicleTypeNames();
            foreach(string vehicle in vehicleTypeNames)
            {
                i_ComboBoxVehicleTypes.Items.Add(vehicle);
            }
        }

        private void ButtonExitForm_Click(object sender, EventArgs e)
        {
            string msg = "Are you sure you want to exit?";

            MessageBoxButtons question = MessageBoxButtons.YesNo;
            DialogResult exithResult = MessageBox.Show(msg, "Exit", question);

            if (exithResult == DialogResult.Yes)
            {
                MessageBox.Show("Good Bye !! hope to see you soon");
                m_FormMenu.DialogResult = DialogResult.Cancel;
            }
            else
            {
                m_FormMenu.DialogResult = DialogResult.OK;
            }
        }

        private void ButtonShowCutomerCard_Click(object sender, EventArgs e)
        {
            m_FormExistCustomer.ShowDialog();

            if (m_FormExistCustomer.DialogResult == DialogResult.OK)
            {
                {
                    string title = "Customer details";

                    List<string> vehicleDetails = m_CustomerToTreat.Vehicle.GetDetails();
                    StringBuilder cusotmerDetails = new StringBuilder();
                    cusotmerDetails.AppendLine($"Customer name: {m_CustomerToTreat.Name}\n");
                    cusotmerDetails.AppendLine($"Vehicle state: {m_CustomerToTreat.CarState.ToString()}\n");
                    foreach (string detail in vehicleDetails)
                    {
                        cusotmerDetails.AppendLine(detail + "\n");
                    }

                    MessageBox.Show(cusotmerDetails.ToString(), title);
                }
            }
            else
            {
                findCustomerActions();
            }

            m_FormExistCustomer.TextBoxLicensePlate.Clear();
        }

        private void ButtonFindCustomer_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(m_FormExistCustomer.TextBoxLicensePlate.Text) == true)
            {
                string message = "License Number field is empty";
                string title = "Invalid Input";
                MessageBox.Show(message, title);
            }
            else if (m_Garage.FindCustomer(m_FormExistCustomer.TextBoxLicensePlate.Text, out m_CustomerToTreat) == true)
            {
                m_FormExistCustomer.DialogResult = DialogResult.OK;
            }
            else
            {
                string message = "Customer doesn't exist";
                string title = "Garage notification";
                MessageBox.Show(message, title);
            }
        }

        private void ButtonVehicleCharge_Click(object sender, EventArgs e)
        {
            m_FormExistCustomer.ShowDialog();
            if (m_FormExistCustomer.DialogResult == DialogResult.OK)
            {
                if (m_Garage.IsElectricEngine(m_CustomerToTreat) == true)
                {
                    if (m_FormChargeVehicle.ButtonChargeVehicle.Text == "Refuel")
                    {
                        changeFormToElectriclEngine();
                    }
                    m_FormExistCustomer.Hide();
                    m_FormChargeVehicle.ShowDialog();
                    chargeVehicleActions();
                }
                else
                {
                    string message = "Vehicle engine is not support this action.";
                    string title = "Garage notification";
                    MessageBox.Show(message, title);
                }
            }

            m_FormExistCustomer.TextBoxLicensePlate.Clear();
        }
        
        private void changeFormToElectriclEngine()
        {
            m_FormChargeVehicle.ButtonChargeVehicle.Click += ButtonChargeVehicle_Click;
            m_FormChargeVehicle.ButtonChargeVehicle.Click -= ButtonAddFuel_Click;
            m_FormChargeVehicle.Text = "Charge vehicle";
            m_FormChargeVehicle.LabelAddEnergy.Text = "Enter minutes to charge";
            m_FormChargeVehicle.LabelAmountToAdd.Text = "Minutes:";
            m_FormChargeVehicle.ButtonChargeVehicle.Text = "Charge";
            m_FormChargeVehicle.ComboBoxFuelTypes.Visible = false;
            m_FormChargeVehicle.LabelFuelTypes.Visible = false;
        }

        private void findCustomerActions()
        {
            if (m_FormExistCustomer.DialogResult == DialogResult.Cancel)
            {
                m_FormExistCustomer.Hide();
            }
            else if (m_FormExistCustomer.DialogResult == DialogResult.Retry)
            {
                string message = "License Number field is empty";
                string title = "Invalid Input";
                MessageBox.Show(message, title);
            }
            else
            {
                string message = "Customer doesn't exist";
                string title = "Garage notification";
                MessageBox.Show(message, title);
            }
        }

        private void chargeVehicleActions()
        {

            if (m_FormChargeVehicle.DialogResult == DialogResult.Yes)
            {
                float amount = float.Parse(m_FormChargeVehicle.TextBoxMinutesToCharge.Text);
                if (chargeVehicle(amount) == true)
                {
                    vehicleChargedMsg(amount);
                    m_FormChargeVehicle.Hide();
                }
            }
            else if (m_FormChargeVehicle.DialogResult == DialogResult.No)
            {
                string message = "Minutes should be number";
                string title = "Invalid Input";
                MessageBox.Show(message, title);
            }
            else if (m_FormChargeVehicle.DialogResult == DialogResult.Cancel)
            {
                m_FormChargeVehicle.Hide();
            }
            else
            {
                string message = "Minutes field is empty";
                string title = "Invalid Input";
                MessageBox.Show(message, title);
            }
            m_FormChargeVehicle.TextBoxMinutesToCharge.Clear();
        }

        private void vehicleChargedMsg(float i_MinutesToCharge)
        {
            StringBuilder message = new StringBuilder();
            message.AppendLine($"{m_CustomerToTreat.Name}'s Engine charged succesfully");
            string title = "Electric engine charge";
            MessageBox.Show(message.ToString(), title);
        }

        private bool chargeVehicle(float i_MinutesToCharge)
        {
            bool isValid = true;
            try
            {
                m_Garage.RechargeVehicle(m_CustomerToTreat, i_MinutesToCharge);
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

        private void ButtonChargeVehicle_Click(object sender, EventArgs e)
        {
            string amountToCharageStr = m_FormChargeVehicle.TextBoxMinutesToCharge.Text;
            float amount;
            if (String.IsNullOrEmpty(amountToCharageStr) == true)
            {
                m_FormChargeVehicle.DialogResult = DialogResult.Retry;
            }
            else if (float.TryParse(amountToCharageStr, out amount) == false)
            {
                m_FormChargeVehicle.DialogResult = DialogResult.No;
            }
            else
            {
                m_FormChargeVehicle.DialogResult = DialogResult.Yes;
            }
        }

        private void ButtonRefuelVehicle_Click(object sender, EventArgs e)
        {
            m_FormExistCustomer.ShowDialog();

            if (m_FormExistCustomer.DialogResult == DialogResult.OK)
            {
                if (m_Garage.IsFuelEngine(m_CustomerToTreat) == true)
                {
                    if (m_FormChargeVehicle.ButtonChargeVehicle.Text == "Charge")
                    {
                        changeFormToFuelEngine();
                    }
                    m_FormChargeVehicle.ShowDialog();
                    if (m_FormChargeVehicle.DialogResult == DialogResult.Yes)
                    {
                        if (refuelVehicle() == true)
                        {
                            vehicleRefueledMsg();
                            m_FormChargeVehicle.Hide();
                        }
                    }
                }
                else
                {
                    string title = "Garage notification";
                    string msg = "Vehicle engine is not support this action.";
                    MessageBox.Show(msg, title);
                }
            }

            m_FormChargeVehicle.TextBoxMinutesToCharge.Clear();
            m_FormExistCustomer.TextBoxLicensePlate.Clear();
            m_FormChargeVehicle.ComboBoxFuelTypes.SelectedIndex = -1;
        }

        private void vehicleRefueledMsg()
        {
            StringBuilder message = new StringBuilder();
            message.AppendLine($"{m_CustomerToTreat.Name}'s Vehicle refueled successfully!");
            string title = "Fuel engine refuel";
            MessageBox.Show(message.ToString(), title);

        }
        private bool refuelVehicle()
        {
            bool isValid = true;
            float liters = float.Parse(m_FormChargeVehicle.TextBoxMinutesToCharge.Text);
            string fuelType = m_FormChargeVehicle.ComboBoxFuelTypes.Text;
            try
            {
                m_Garage.RefuelVehicle(m_CustomerToTreat, liters, fuelType);
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

        private void ButtonAddFuel_Click(object sender, EventArgs e)
        {
            string litersStr = m_FormChargeVehicle.TextBoxMinutesToCharge.Text;
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
                if (String.IsNullOrEmpty(m_FormChargeVehicle.ComboBoxFuelTypes.Text) == true)
                {
                    string message = "Fuel types field is empty";
                    string title = "Invalid Input";
                    MessageBox.Show(message, title);
                }
                else
                {
                    m_FormChargeVehicle.DialogResult = DialogResult.Yes;
                }
            }
        }

        private void changeFormToFuelEngine()
        {
            m_FormChargeVehicle.ButtonChargeVehicle.Click -= ButtonChargeVehicle_Click;
            m_FormChargeVehicle.ButtonChargeVehicle.Click += ButtonAddFuel_Click;
            m_FormChargeVehicle.Text = "Refuel Vehicle";
            m_FormChargeVehicle.LabelAddEnergy.Text = "Put the amount of liters you want to add";
            m_FormChargeVehicle.LabelAmountToAdd.Text = "Liters:";
            m_FormChargeVehicle.LabelFuelTypes.Visible = true;
            m_FormChargeVehicle.LabelFuelTypes.Enabled = true;
            m_FormChargeVehicle.ComboBoxFuelTypes.Visible = true;
            m_FormChargeVehicle.ComboBoxFuelTypes.Enabled = true;
            m_FormChargeVehicle.ButtonChargeVehicle.Text = "Refuel";

        }

        private void ButtonAirBlowing_Click(object sender, EventArgs e)
        {
            m_FormExistCustomer.ShowDialog();
            if (m_FormExistCustomer.DialogResult == DialogResult.OK)
            {
                m_Garage.BlowVehicleWheels(m_CustomerToTreat);
                StringBuilder message = new StringBuilder();
                message.AppendLine($"{m_CustomerToTreat.Name} Wheels blowed succesfully!");
                string title = "Blowing Wheels";
                MessageBox.Show(message.ToString(), title);
            }
            m_FormExistCustomer.TextBoxLicensePlate.Clear();
        }

        private void ButtonChangeVehicleStatus_Click(object sender, EventArgs e)
        {
            m_FormExistCustomer.ShowDialog();
            if (m_FormExistCustomer.DialogResult == DialogResult.OK)
            {
                m_FormVehicleStates.LabelChooseOption.Text = "Please choose the state you want to change to";
                m_FormVehicleStates.ShowDialog();
                m_Garage.ChangeCustomerVehicleState(m_CustomerToTreat, m_FormVehicleStates.ComboBoxVehicleStates.Text);
                StringBuilder message = new StringBuilder();
                message.AppendLine($"{m_CustomerToTreat.Name}'s vehicle chagned state to: {m_CustomerToTreat.CarState}");
                string title = "State changed";
                MessageBox.Show(message.ToString(), title);
                m_FormExistCustomer.Hide();
            }

            m_FormExistCustomer.TextBoxLicensePlate.Clear();
            m_FormVehicleStates.ComboBoxVehicleStates.SelectedIndex = -1;
        }

        private void initializeVehicleStatesComboBox(ComboBox i_ComboBox)
        {
            List<string> statuses = m_Garage.GetStatusOptions();
            foreach (string currStatus in statuses)
            {
                m_FormVehicleStates.ComboBoxVehicleStates.Items.Add(currStatus);
            }
        }

        private void initiazlizeFuelTypesComboBox(ComboBox i_ComboBox)
        {
            string[] fuelTypes = m_Garage.GetFuelTypes();
            foreach (string type in fuelTypes)
            {
                m_FormChargeVehicle.ComboBoxFuelTypes.Items.Add(type);
            }
        }

        private void ButtonShowAllVehicles_Click(object sender, EventArgs e)
        {
            if (m_FormVehicleStates == null)
            {
                m_FormVehicleStates = new FormVehicleStates();
            }

            m_FormVehicleStates.LabelChooseOption.Text = "Please choose the state you want to print";
            m_FormVehicleStates.ShowDialog();
            if (m_FormVehicleStates.DialogResult == DialogResult.Yes)
            {
                printLicensesByState(m_FormVehicleStates.ComboBoxVehicleStates.Text);
            }
        }

        private void ButtonOk_Click(object sender, EventArgs e)
        {
            if(checkVehicleState(m_FormVehicleStates.ComboBoxVehicleStates.Text) == true)
            { 
                m_FormVehicleStates.DialogResult = DialogResult.Yes;
            }
        }

        private bool checkVehicleState(string i_VehicleState)
        {
            bool isValid = true;
            if (String.IsNullOrEmpty(i_VehicleState) == true)
            {
                isValid = false;
                string message = "Vehicle state is empty";
                string title = "Invalid Input";
                MessageBox.Show(message, title);
            }
            else
            {
                if (i_VehicleState != "All")
                {
                    try
                    {
                        m_Garage.FromStringToCarStateEnum(i_VehicleState);
                    }
                    catch (GarageLogic.ValueOutOfRangeException ec)
                    {
                        isValid = false;
                        string message = ec.Message;
                        string title = "Invalid Input";
                        MessageBox.Show(message, title);
                        m_FormVehicleStates.ComboBoxVehicleStates.Text = string.Empty;
                    }
                    catch (FormatException ec)
                    {
                        isValid = false;
                        string message = ec.Message;
                        string title = "Invalid Input";
                        MessageBox.Show(message, title);
                        m_FormVehicleStates.ComboBoxVehicleStates.SelectedIndex = -1;
                    }
                }
            }

            return isValid;
        }

        private void printLicensesByState(string i_VehicleState)
        {
            try
            {
                List<string> licenses = m_Garage.GetVehiclesByState(i_VehicleState);
                if (licenses != null)
                {
                    string title = i_VehicleState;
                    StringBuilder msg = new StringBuilder();
                    int index = 1;
                    msg.AppendLine($"The licences in the garage by state:{i_VehicleState}\n ");
                    foreach (string license in licenses)
                    {
                        msg.AppendLine($"{index}) {license}");
                        index++;
                    }

                    MessageBox.Show(msg.ToString(), title);
                }
                else
                {
                    string message = "There is no vehicles in this state";
                    string title = "Garage notification";
                    MessageBox.Show(message, title);
                }
            }
            catch (GarageLogic.ValueOutOfRangeException ec)
            {
                string message = ec.Message;
                string title = "Invalid Input";
                MessageBox.Show(message, title);
            }
            catch (FormatException ec)
            {
                string message = ec.Message;
                string title = "Invalid Input";
                MessageBox.Show(message, title);
            }
        }

        private void ButtonAddNewVehicle_Click(object sender, EventArgs e)
        {
            m_FormCutomerCard = new FormCutomerCard();
            m_FormCutomerCard.ButtonCreateCutomerCard.Click += ButtonCreateCutomerCard_Click;
            m_FormNewCustomer.ShowDialog();
            if(m_FormNewCustomer.DialogResult == DialogResult.OK)
            {
                m_FormNewCustomer.Hide();
                newCustomerActions();
                m_FormCutomerCard.ShowDialog();
            }

            m_FormNewCustomer.ComboBoxVehicleType.SelectedIndex = -1;
            m_FormNewCustomer.textBoxLicencePlate.Clear();
        }

        private void ButtonMakeCustomerCard_Click(object sender, EventArgs e)
        {
            int number;
            if (String.IsNullOrEmpty(m_FormNewCustomer.ComboBoxVehicleType.Text) == true)
            {
                string message = "Vehicle type is empty";
                string title = "Invalid Input";
                MessageBox.Show(message, title);
            }
            else if (isValidType() == true)
            { 
             if (String.IsNullOrEmpty(m_FormNewCustomer.textBoxLicencePlate.Text) == true)
                {
                    string message = "License number field is empty";
                    string title = "Invalid Input";
                    MessageBox.Show(message, title);
                    m_FormNewCustomer.textBoxLicencePlate.Clear();
                }
                else if (int.TryParse(m_FormNewCustomer.textBoxLicencePlate.Text, out number) == false)
                {
                    string message = @"Invalid licence number
Please enter numbers only - etc:74246425";
                    string title = "Invalid Message";
                    MessageBox.Show(message, title);
                    m_FormNewCustomer.textBoxLicencePlate.Clear();
                }
                else if (m_Garage.FindCustomer(m_FormNewCustomer.textBoxLicencePlate.Text, out m_CustomerToTreat) == true)
                {
                    string message = "Customer alredy exist";
                    string title = "Error";
                    MessageBox.Show(message, title);
                    m_FormNewCustomer.textBoxLicencePlate.Clear();
                }
                else
                {
                    m_FormNewCustomer.DialogResult = DialogResult.OK;
                }
            }
        }

        private bool isValidType()
        {
            bool isValid = true;
            try
            {
                VehicleCreator.FromStringToVehicleTypeEnum(m_FormNewCustomer.ComboBoxVehicleType.Text);
            }
            catch (GarageLogic.ValueOutOfRangeException ec)
            {
                isValid = false;
                string message = ec.Message;
                string title = "Invalid Input";
                MessageBox.Show(message, title);
            }
            catch(FormatException ec)
            {
                isValid = false;
                string message = ec.Message;
                string title = "Invalid Input";
                MessageBox.Show(message, title);
            }

            if(isValid == false)
            {
                m_FormNewCustomer.ComboBoxVehicleType.SelectedIndex = -1;
            }

            return isValid;
        }

        private void ButtonCreateCutomerCard_Click(object sender, EventArgs e)
        {
            string customerName, customerPhone;
            if(getVehicleInfo(out customerName, out customerPhone) == true)
            {
                m_Garage.EnterVehicle(m_CustomerToTreat.Vehicle, customerName, customerPhone);
                string message = customerName + "'s vehicle successfully added to the garage!";
                string title = "Garage Notification";
                MessageBox.Show(message, title);
                m_FormCutomerCard.Hide();
                m_FormMenu.Show();
            }
        }

        private void newCustomerActions()
        {
           Vehicle vehicleToCreate = GarageLogic.VehicleCreator.Create(m_FormNewCustomer.textBoxLicencePlate.Text, m_FormNewCustomer.ComboBoxVehicleType.Text);
            m_CustomerToTreat = new CustomerCard(vehicleToCreate);
            List<string> vehicleInfo = m_CustomerToTreat.Vehicle.GetDataNames();
            createCustomerCardForm(vehicleInfo);
        }

        private void createCustomerCardForm(List<string> i_VehicleInfo)
        {
            int leftLabel = 12, topLebel = 20, topTextbox = 17, space = 7;
            m_FormCutomerCard.Text = m_FormNewCustomer.ComboBoxVehicleType.Text;

            for (int i = 0; i < i_VehicleInfo.Count; i++)
            {
                Label label = new System.Windows.Forms.Label();
                TextBox text = new System.Windows.Forms.TextBox();
                label.Text = i_VehicleInfo[i];
                label.Name = i_VehicleInfo[i];
                text.Name = i_VehicleInfo[i];
                if (i == 0)
                {
                    label.Left = leftLabel;
                    label.Top = topLebel;
                    text.Left = label.Right;
                    text.Top = topTextbox;
                }
                else
                {
                    label.Top = (topLebel * (i*2))+ space;
                    label.Left = leftLabel;
                    text.Top = (topLebel * (i*2)) + space;
                    text.Left = label.Right;
                }
                label.TabIndex = i;
                text.TabIndex = i + 1;
                m_FormCutomerCard.Controls.Add(label);
                m_FormCutomerCard.Controls.Add(text);
            }
            
        }

        private bool getVehicleInfo(out string io_CustomerName, out string io_CustomerPhone)
        {
            io_CustomerPhone = io_CustomerName = null;
            bool isValid = true;
            int counter = 0;
            for (int i = 5; i < m_FormCutomerCard.Controls.Count  && isValid == true; i++)
            {
                if (m_FormCutomerCard.Controls[i] is TextBox)
                {
                    try
                    {
                        m_CustomerToTreat.Vehicle.UpdateInfo(m_FormCutomerCard.Controls[i].Text, counter);
                        counter++;
                    }
                    catch (GarageLogic.ValueOutOfRangeException ec)
                    {
                        string message = ec.Message;
                        string title = "Invalid Input";
                        MessageBox.Show(message, title);
                        isValid = false;
                    }
                    catch (ArgumentException ec)
                    {
                        string message = ec.Message;
                        string title = "Invalid Input";
                        MessageBox.Show(message, title);
                        isValid = false;
                    }
                    catch (FormatException ec)
                    {
                        string message = ec.Message;
                        string title = "Invalid Input";
                        MessageBox.Show(message, title);
                        isValid = false;
                    }
                }
            }

            if (isValid == true)
            {
                isValid = checkValidName(m_FormCutomerCard.Controls[3].Text, ref io_CustomerName);
    
                if (isValid == true)
                {
                    isValid = checkValidPhone(m_FormCutomerCard.Controls[1].Text, ref io_CustomerPhone);
                }
            }

            return isValid;
        }

        private bool checkValidName(string i_Name, ref string o_CustomerName)
        {
            bool isValid = true;
            if (string.IsNullOrEmpty(i_Name) || string.IsNullOrWhiteSpace(i_Name))
            {
                isValid = false;
                string message = "Must enter name";
                string title = "Invalid Input";
                MessageBox.Show(message, title);
            }

            if(isValid == true)
            {
                o_CustomerName = i_Name;
            }

            return isValid;
        }

        private bool checkValidPhone(string i_PhoneStr, ref string o_CustomerPhone)
        {
            int res;
            bool isValid = true;
            if (string.IsNullOrEmpty(i_PhoneStr) || string.IsNullOrWhiteSpace(i_PhoneStr))
            {
                string message = "Must enter phone number";
                string title = "Invalid Input";
                MessageBox.Show(message, title);
                isValid = false;
            }
            else if (int.TryParse(i_PhoneStr, out res) == false)
            {
                isValid = false;
                string message = "Must enter numeric phone number";
                string title = "Invalid Input";
                MessageBox.Show(message, title);
            }
            
            if(isValid == true)
            {
                o_CustomerPhone = i_PhoneStr;
            }

            return isValid;
        }
    }
}
