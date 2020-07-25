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
    public partial class FormNewCustomer : Form
    {
        public FormNewCustomer()
        {
            InitializeComponent();
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
