using System.Collections.Generic;
using System;

namespace Ex03.ConsoleUI
{
    public class GarageUI
    {
        private GarageLogic.Garage m_GarageManager;

        public void RunApp()
        {
            m_GarageManager = new GarageLogic.Garage();
            printMenu();
            string selection = Console.ReadLine();
            switch (selection)
            {
                case "1":
                    string licenceStr, carTypeStr;
                    getCustomerData(out licenceStr, out carTypeStr);
                    if (!m_GarageManager.FindCustomer(licenceStr)) // in case false
                    {
                        GarageLogic.Vehicle vehicleToAdd = GarageLogic.VehicleCreator.Create(licenceStr, carTypeStr);
                        List<string> vehicleInfo = vehicleToAdd.GetInfo();
                        List<string> vehicleValues = getVehicleInfo(vehicleInfo);
                        //vehicleToAdd.UpdateInfo();
                    }
                    break;
                default:
                    break;


            }

        }

        private List<string> getVehicleInfo(List<string> i_vehicleInfoStrs)
        {
            List<string> vehicleValues = new List<string>();
            for(int i = 0; i < i_vehicleInfoStrs.Count; i++)
            { 
                Console.WriteLine(string.Format("Please enter {0}:", i_vehicleInfoStrs[i]));
                vehicleValues.Add(Console.ReadLine());
            }

            return vehicleValues;
        }

        private void getCustomerData(out string o_LicenceStr, out string o_CarTypeStr)
        {
            Console.WriteLine("Please enter license number:");
            o_LicenceStr = Console.ReadLine();
            Console.WriteLine("Please enter car type:");
            o_CarTypeStr = Console.ReadLine();
        }

        private void printMenu()
        {
            Console.WriteLine(@"Welcome to the garage!
Please choose the service you want:
Press 1 to add a new car to the garage");
        }



    }
}
