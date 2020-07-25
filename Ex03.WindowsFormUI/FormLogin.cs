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
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
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
            get { return this.buttonChangeStatus; }
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
