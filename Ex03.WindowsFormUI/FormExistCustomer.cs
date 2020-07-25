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
    public partial class FormExistCustomer : Form
    {
        public FormExistCustomer()
        {
            InitializeComponent();
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
