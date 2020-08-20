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
    public partial class FormCutomerCard : Form
    {
        private CustomerCard m_CustomerToTreat;
        private readonly Garage r_GarageManager;

        public FormCutomerCard(List<string> i_VehicleInfo, string i_VehicleType, CustomerCard i_CustomerToTreat, Garage i_GarageManager)
        {
            r_GarageManager = i_GarageManager;
            InitializeComponent();
            InitializeCustomerDetails(i_VehicleInfo, i_VehicleType);
            m_CustomerToTreat = i_CustomerToTreat;
            this.buttonCreateCustomerCard.Click += ButtonCreateCustomerCard_Click;
        }

        private void ButtonCreateCustomerCard_Click(object sender, EventArgs e)
        {
            string customerName, customerPhone;
            if (getVehicleInfo(out customerName, out customerPhone) == true)
            {
                r_GarageManager.EnterVehicle(m_CustomerToTreat.Vehicle, customerName, customerPhone);
                string message = customerName + "'s vehicle successfully added to the garage!";
                string title = "Garage Notification";
                MessageBox.Show(message, title);
                this.Hide();
            }
        }

        private bool getVehicleInfo(out string io_CustomerName, out string io_CustomerPhone)
        {
            io_CustomerPhone = io_CustomerName = null;
            bool isValid = true;
            int counter = 0;
            for (int i = 5; i < this.Controls.Count && isValid == true; i++)
            {
                if (Controls[i] is TextBox)
                {
                    try
                    {
                        m_CustomerToTreat.Vehicle.UpdateInfo(Controls[i].Text, counter);
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
                isValid = checkValidName(this.Controls[3].Text, ref io_CustomerName);

                if (isValid == true)
                {
                    isValid = checkValidPhone(this.Controls[1].Text, ref io_CustomerPhone);
                }
            }

            return isValid;
        }

        private void InitializeCustomerDetails(List<string> i_VehicleInfo, string i_VehicleType)
        {
            int leftLabel = 12, topLebel = 20, topTextbox = 17, space = 7;
            this.Text = i_VehicleType;

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
                    label.Top = (topLebel * (i * 2)) + space;
                    label.Left = leftLabel;
                    text.Top = (topLebel * (i * 2)) + space;
                    text.Left = label.Right;
                }
                label.TabIndex = i;
                text.TabIndex = i + 1;
                this.Controls.Add(label);
                this.Controls.Add(text);
            }

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

            if (isValid == true)
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

            if (isValid == true)
            {
                o_CustomerPhone = i_PhoneStr;
            }

            return isValid;
        }

        public Button ButtonCreateCutomerCard
        {
            get { return this.buttonCreateCustomerCard; }
        }
    }
}
