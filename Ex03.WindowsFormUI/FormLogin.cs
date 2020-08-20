using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoDB.Driver;
using Ex03.GarageLogic;


namespace Ex03.WindowsFormUI
{
    public partial class FormLogin : Form
    {
        private const string k_UserName = "erankamil";
        private const string k_Password = "pa55w.rd";
        private const string k_CollectionName = "Customers";
        private const string k_DBName = "Garage";
        private const int k_NumberOfTries = 3;
        private  int s_FaliedLogins = 0;

        public IMongoCollection<BsonDocument>  Collection { get; set; }

        public bool IsConnected { get; set; }

        public FormLogin()
        {
            InitializeComponent();
            this.buttonLocal.Click += ButtonLocal_Click;
            this.buttonToDB.Click += ButtonToDB_Click;
        }

        private void ButtonToDB_Click(object sender, EventArgs e)
        {
            this.buttonToDB.Visible = false;
            this.buttonLocal.Visible = false;
            this.labelChooseConnetion.Visible = false;
            this.pictureBoxDB.Visible = false;
            this.textBoxPassword.Visible = true;
            this.textBoxUserName.Visible = true;
            this.labelEnterDetails.Visible = true;
            this.labelUserName.Visible = true;
            this.labelPassword.Visible = true;
            this.buttonConnect.Visible = true;
            this.buttonConnect.Click += ButtonConnect_Click;
        }

        private void ButtonConnect_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(this.textBoxPassword.Text) && !string.IsNullOrEmpty(this.textBoxUserName.Text))
            {
                if(this.textBoxPassword.Text == k_Password && this.textBoxUserName.Text == k_UserName)
                {
                    connectToDB();
                }
                else
                {
                    s_FaliedLogins++;
                    if (s_FaliedLogins < 3)
                    {
                        string message = $"Login failed! you have {k_NumberOfTries - s_FaliedLogins} attemps left";
                        string title = "Login notification";
                        MessageBox.Show(message, title);
                    }
                    else
                    {
                        string message = @"Login failed! no more attemps for you.
youre going to connent locally now";
                        string title = "Login notification";
                        MessageBox.Show(message, title);
                        IsConnected = false;
                        this.Close();
                    }
                    this.textBoxUserName.Text = this.textBoxPassword.Text = string.Empty;
                }
            }
            else
            {
                string message = "Username or Password empty!";
                string title = "Invalid input";
                MessageBox.Show(message, title);
            }
        }

        private void connectToDB()
        {
            try
            {
                var client = new MongoClient("mongodb+srv://dbUser:pa55w.rd@cluster0.ufirq.mongodb.net/Garage?retryWrites=true&w=majority");
                client.ListDatabaseNames();
                var DB = client.GetDatabase(k_DBName);
                Collection = DB.GetCollection<BsonDocument>(k_CollectionName);
                CustomerCard customer = new CustomerCard();
                customer.RegisterClass();
                IsConnected = true;
            }
            catch 
            {
                IsConnected = false;
                MessageBox.Show("Cannot connet to DB for some reason..");
            }

            this.Close();
        }

        private void ButtonLocal_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
