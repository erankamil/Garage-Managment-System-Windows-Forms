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
    public partial class FormShowVehicles : Form
    {
        public FormShowVehicles(List<CustomerCard> i_CustomersToShow, string i_VehicleState)
        {
            InitializeComponent();
            this.customerCardBindingSource.DataSource = i_CustomersToShow;
            this.labelChosenState.Text = i_VehicleState;
        }


        public Label LabelShowVehicles
        {
            get { return this.labelShowVehicles; }
        }

        public ListBox ListBoxVehicles
        {
            get { return this.listBoxShowVehicles; }
        }
    }
}
