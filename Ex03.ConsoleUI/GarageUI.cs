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
                    string licenceStr;
                    getCustomerLicenseNumber(out licenceStr);
                    if (!m_GarageManager.FindCustomer(licenceStr)) // in case false
                    {
                        newCustomerActions(licenceStr);
                    }
                    break;
                default:
                    break;
            }

        }

        private void newCustomerActions(string i_LicenceStr)
        {
            string customerName, customerPhone;
            GarageLogic.Vehicle vehicleToAdd = prepareCar(i_LicenceStr);
            List<string> vehicleInfo = vehicleToAdd.GetInfo();
            getVehicleInfo(vehicleToAdd, vehicleInfo);
            getCustomerCardData(out customerName, out customerPhone);
            m_GarageManager.EnterVehicle(vehicleToAdd, customerName, customerPhone);
        }

        private GarageLogic.Vehicle prepareCar(string i_LicenseNumber)
        {
            GarageLogic.Vehicle vehicleToAdd = null;
            string vehicleType;
            bool isValid = true; ;
            do
            {
                Console.WriteLine("Please choose you vehicle type:");
                List<string> vehicleTypes = GarageLogic.VehicleCreator.GetInfo();
                foreach (string type in vehicleTypes)
                {
                    Console.WriteLine(type.ToString());
                }
                vehicleType = Console.ReadLine();

                try
                {
                    vehicleToAdd = GarageLogic.VehicleCreator.Create(i_LicenseNumber, vehicleType);
                    isValid = true;
                }
                catch (GarageLogic.ValueOutOfRangeException ec)
                {
                    Console.WriteLine(ec.Message);
                    isValid = false;
                }
                catch (FormatException ec)
                {
                    Console.WriteLine(ec.Message);
                    isValid = false;
                }
                catch (ArgumentException ec)
                {
                    Console.WriteLine(ec.Message);
                    isValid = false;
                }
            }
            while (!isValid);
            return vehicleToAdd;
        }
        private void getVehicleInfo(GarageLogic.Vehicle i_Vehicle, List<string> i_vehicleInfoStrs)
        {
            for (int i = 0; i < i_vehicleInfoStrs.Count; i++)
            {
                string vehicleValue;
                do
                {
                    Console.WriteLine(string.Format("Please enter {0}:", i_vehicleInfoStrs[i]));
                    vehicleValue = Console.ReadLine();
                }
                while (!checkValidValue(vehicleValue));

                try
                {
                    i_Vehicle.UpdateInfo(vehicleValue, i);
                }
                catch (GarageLogic.ValueOutOfRangeException ec)
                {
                    Console.WriteLine(ec.Message);
                    i--;
                }
                catch (ArgumentException ec)
                {
                    Console.WriteLine(ec.Message);
                    i--;
                }
            }
        }

        private bool checkValidValue(string i_vehicleValue)
        {
            bool isValid = true;
            if (string.IsNullOrEmpty(i_vehicleValue) || string.IsNullOrWhiteSpace(i_vehicleValue))
            {
                isValid = false;
                Console.WriteLine("Invalid value");
            }
            return isValid;
        }

        private void getCustomerLicenseNumber(out string o_LicenceStr)
        {
            Console.WriteLine("Please enter license number:");
            do
            {
                o_LicenceStr = Console.ReadLine();
            }
            while (!checkValidLicense(o_LicenceStr));
        }


        private bool checkValidLicense(string i_LicenceStr)
        {
            int res;
            bool isValid = true;
            if (string.IsNullOrEmpty(i_LicenceStr))
            {
                isValid = false;
                Console.WriteLine("Invalid Licence number");
            }
            else if(int.TryParse(i_LicenceStr, out res) == false)
            {
                isValid = false;
                Console.WriteLine("Invalid Licence number (only numbers)");
            }
            return isValid;
        }

        private void getCustomerCardData(out string i_Name, out string i_Phone)
        {
            Console.WriteLine("Last details before entering the car:");
            Console.Write("Owner's name: ");
            i_Name = Console.ReadLine();
            Console.Write("Owner's phone number: ");
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
