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
    public partial class FormVehicleStates : Form
    {
        public FormVehicleStates()
        {
            InitializeComponent();
        }

        public ComboBox ComboBoxVehicleStates
        {
            get { return this.comboBoxVehicleStates; }
        }

        public Button ButtonOk
        {
            get { return this.buttonOk; }
        }

        public Label LabelVehicleState
        {
            get { return this.labelVehicleState; }
        }


        public Label LabelChooseOption
        {
            get { return this.labelChooseState; }
        }
    }
}
