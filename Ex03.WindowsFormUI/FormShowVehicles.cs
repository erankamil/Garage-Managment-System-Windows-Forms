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
            addVehiclesByState(i_CustomersToShow, i_VehicleState);
        }

        private void addVehiclesByState(List<CustomerCard> i_CustomersToShow, string i_VehicleState)
        {
            string title = i_VehicleState;
            int index = 1;
            LabelShowVehicles.Text = ($"Vheicle info by state: {i_VehicleState}");
            foreach (CustomerCard currCustomer in i_CustomersToShow)
            {
                ListBoxVehicles.Items.Add($"{index}) Name: {currCustomer.Name}, License Number: {currCustomer.Vehicle.LicesncePlate}");
                index++;
            }
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
