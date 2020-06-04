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
                    string licenceStr, vehuicleTypeStr;
                    getCustomerData(out licenceStr, out vehuicleTypeStr);
                    if (!m_GarageManager.FindCustomer(licenceStr)) // in case false
                    {
                        string customerName, customerPhone;
                        GarageLogic.Vehicle vehicleToAdd = GarageLogic.VehicleCreator.Create(licenceStr, vehuicleTypeStr);
                        List<string> vehicleInfo = vehicleToAdd.GetInfo();
                        getVehicleInfo(vehicleToAdd, vehicleInfo);
                        getCustomerCardData(out customerName, out customerPhone);
                        m_GarageManager.EnterVehicle(vehicleToAdd, customerName, customerPhone);

                    }
                    break;
                default:
                    break;


            }

        }

        private void getVehicleInfo(GarageLogic.Vehicle i_Vehicle, List<string> i_vehicleInfoStrs)
        {
            for (int i = 0; i < i_vehicleInfoStrs.Count; i++)
            {

                try
                {
                    Console.WriteLine(string.Format("Please enter {0}:", i_vehicleInfoStrs[i]));
                    string vehivcleValue = Console.ReadLine();
                    i_Vehicle.UpdateInfo(vehivcleValue, i);
                }

                catch (GarageLogic.ValueOutOfRangeException ec)
                {
                    Console.WriteLine(ec.Message);
                    i--;
                }
            }
        }

        private void getCustomerData(out string o_LicenceStr, out string o_CarTypeStr)
        {
            Console.WriteLine("Please enter license number:");
            o_LicenceStr = Console.ReadLine();
            Console.WriteLine("Please enter car type (engine type, vehical type in one word)");
            o_CarTypeStr = Console.ReadLine();
        }

        private void getCustomerCardData(out string i_Name, out string i_Phone)
        {
            Console.WriteLine("Last details before entering your car:");
            Console.Write("Your name: ");
            i_Name = Console.ReadLine();
            Console.Write("Your phone number: ");
            i_Phone = Console.ReadLine();
        }

        private void printMenu()
        {
            Console.WriteLine(@"Welcome to the garage!
Please choose the service you want:
Press 1 to add a new car to the garage");
        }



    }
}
