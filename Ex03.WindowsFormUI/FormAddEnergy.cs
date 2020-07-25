using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ex03.WindowsFormUI
{
    public partial class FormAddEnergy : Form
    {
        public FormAddEnergy()
        {
            InitializeComponent();
        }

        public TextBox TextBoxMinutesToCharge
        {
            get { return this.textBoxMinutesToCharge; }
        }

        public Button ButtonChargeVehicle
        {
            get { return this.buttonChargeVehicle; }
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

        private void labelAddEnergy_Click(object sender, EventArgs e)
        {

        }
    }
}
