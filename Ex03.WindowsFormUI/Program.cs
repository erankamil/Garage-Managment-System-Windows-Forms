using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Windows.Forms;
namespace Ex03.WindowsFormUI
{
    class Program
    {
        public static void Main()
        {
            Application.EnableVisualStyles();
            FormLogin fromLogin = new FormLogin();
            fromLogin.ShowDialog();

            FormMenu menu = new FormMenu(fromLogin.Collection, fromLogin.IsConnected);
            menu.ShowDialog(); 
        }
    }
}
