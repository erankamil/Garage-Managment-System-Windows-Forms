using System.Collections.Generic;
using System;

namespace Ex03.ConsoleUI
{
    internal class GarageUI
    {
        private GarageLogic.Garage m_GarageManager;

        public void RunApp()
        {
            m_GarageManager = new GarageLogic.Garage();
            bool exit = false;
            while (!exit)
            { 
                printMenu();
                string selection = Console.ReadLine();
                switch (selection)
                {
                    case "1":
                        case1();
                        break;
                    case "2":
                        printLicensesByState();
                        break;
                    case "3":
                        case3();
                        break;
                    case "4":
                        case4();
                        break;
                    case "5":
                        case5();
                        break;
                    case "6":
                        case6();
                        break;
                    case "7":
                        case7();
                        break;
                    case "8":
                        Console.WriteLine("Good Bye!!");
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }
                System.Threading.Thread.Sleep(2000);
            }
        }

        private void case7()
        {
            if (findCustomer(out GarageLogic.CustomerCard existCustomer
             , out string licenseNumber) == true)
            {
                List<string> vehicleDetails = existCustomer.Vehicle.GetDetails();
                vehicleDetails.Insert(0, "Owner name " + existCustomer.Name);
                vehicleDetails.Insert(1, "Vehicle state " + existCustomer.CarState.ToString());
                foreach(string detail in vehicleDetails)
                {
                    Console.WriteLine(detail);
                }
                System.Threading.Thread.Sleep(5000);
            }
            else
            {
                Console.WriteLine("Customer does not exist in the garage..");
            }

        }

        private void case6()
        {
            if (findCustomer(out GarageLogic.CustomerCard existCustomer
                  , out string licenseNumber) == true)
            {
                if (m_GarageManager.IsElectricEngine(existCustomer) == true)
                {
                    bool isValid = false;
                    while (!isValid)
                    {
                        float amount = getEnergyAmount();
                        try
                        {
                            m_GarageManager.RechargeVehicle(existCustomer, amount);
                            isValid = true;
                        }
                        catch (GarageLogic.ValueOutOfRangeException ec)
                        {
                            Console.WriteLine(ec.Message);
                            isValid = false;
                        }
                    }
                    Console.WriteLine("Vehicle was charged successfully!");
                }

            }
            else
            {
                Console.WriteLine("Customer does not exist in the garage");
            }
        }

        private void case5()
        {
            if (findCustomer(out GarageLogic.CustomerCard existCustomer
               , out string licenseNumber) == true)
            {
                if (m_GarageManager.IsFuelEngine(existCustomer) == true)
                {
                    getRefuelData(existCustomer);
                }
                else
                {
                    Console.WriteLine("Vehicle engine is not fuel type");
                }
            }
            else
            {
                Console.WriteLine("Customer does not exist in the garage");
            }
        }

        private void getRefuelData(GarageLogic.CustomerCard i_ExsitCustomer)
        {
            bool isValid = false;
            while (!isValid)
            {
                string typeStr = getFuelType();
                float amount = getEnergyAmount();
                isValid = refuelVehicle(i_ExsitCustomer, typeStr, amount);

            }
            Console.WriteLine("Vehicle has successfully refuled!");
        }

        public bool refuelVehicle(GarageLogic.CustomerCard i_ExsitCustomer, string i_FuelType, 
            float i_Amount)
        {
            bool isValid = false;
            try
            {
                m_GarageManager.RefuelVehicle(i_ExsitCustomer, i_Amount, i_FuelType);
                isValid = true;
            }
            catch (GarageLogic.ValueOutOfRangeException ec)
            {
                Console.WriteLine(ec.Message);
                isValid = false;
            }
            catch (ArgumentException ec)
            {
                Console.WriteLine(ec.Message);
                isValid = false;
            }
            return isValid;
        }

        private float getEnergyAmount()
        {
            string amount;
            float floatAmount = 0;
            do
            {
                Console.WriteLine("Please enter amount to add:");
                amount = Console.ReadLine();
            } while (!isNumeric(amount, ref floatAmount));
            return floatAmount;
        }

        private bool isNumeric (string i_Amount, ref float io_Amount)
        {
            bool isValid = false;
            if(checkValidValue(i_Amount))
            {
                if(float.TryParse(i_Amount, out float res))
                {
                    if(res > 0)
                    {
                        isValid = true;
                        io_Amount = res;
                    }
                }
            }
            if(isValid == false)
            {
                Console.WriteLine("Invalid input");
            }
            return isValid;
        }
        private string getFuelType()
        {
            bool isValid = true;
            string typeStr;
            do
            {
                if(isValid == false)
                {
                    Console.WriteLine("Invalid Input");
                }
                Console.WriteLine("Please enter fuel type:");
                string[] fuelTypes = m_GarageManager.GetFuelTypes();

                for (int i = 0; i < fuelTypes.Length; i++)
                {
                    Console.WriteLine("{0}) {1}", (i + 1).ToString(), fuelTypes[i]);
                }
                typeStr = Console.ReadLine();
            }
            while (!(isValid = (checkValidValue(typeStr) && m_GarageManager.IsFuelType(typeStr))));
            return typeStr;
        }

        private void case4()
        {
            if (findCustomer(out GarageLogic.CustomerCard existCustomer
                 , out string licenseNumber) == true)
            {
                m_GarageManager.BlowVehicleWheels(existCustomer);
                Console.WriteLine("Wheels air blowing succeed");
            }
            else
            {
                Console.WriteLine("Customer does not exist in the garage..");
            }
        }

        private void case3()
        {
            if (findCustomer(out GarageLogic.CustomerCard existCustomer
                , out string licenseNumber) == true)
            {
                string statusStr;
                bool isValid = false;
                while (!isValid)
                {
                    statusStr = statusesMessages();
                    if (int.TryParse(statusStr, out int res))
                    {
                        switch (int.Parse(statusStr))
                        {
                            case (int)GarageLogic.eCarState.InRepair:
                                changeCustomerVehicleState(existCustomer, GarageLogic.eCarState.InRepair);
                                isValid = true;
                                break;
                            case (int)GarageLogic.eCarState.Repaired:
                                changeCustomerVehicleState(existCustomer, GarageLogic.eCarState.Repaired);
                                isValid = true;
                                break;
                            case (int)GarageLogic.eCarState.Paid:
                                changeCustomerVehicleState(existCustomer, GarageLogic.eCarState.Paid);
                                isValid = true;
                                break;
                            default:
                                Console.WriteLine("Invalid Input");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid Input,you must choose one of the options");
                        isValid = false;
                    }
                }
            }
            else
            {
                Console.WriteLine("Customer does not exist in the garage..");
            }
        }

        private void case1()
        {
            
            if (findCustomer(out GarageLogic.CustomerCard existCustomer
                , out string licenseNumber) == true)
            {
                changeCustomerVehicleState(existCustomer, GarageLogic.eCarState.InRepair);
            }
            else
            {
                newCustomerActions(licenseNumber);            
            }
        }

        private bool findCustomer(out GarageLogic.CustomerCard o_Customer,
            out string o_LicenseNumber)
        {
            bool isExist = false;
            o_Customer = null;
            string licenceStr;
            getCustomerLicenseNumber(out licenceStr);
            o_LicenseNumber = licenceStr;
            if (m_GarageManager.FindCustomer(licenceStr, out GarageLogic.CustomerCard res) == true)
            {
                o_Customer = res;
                isExist = true;
            }
            return isExist;
        }
        private void printLicensesByState()
        {
            string statusStr;
            bool isValid = false;
            while (!isValid)
            {
                statusStr = statusesMessages();
                if (int.TryParse(statusStr, out int res))
                {
                    switch (int.Parse(statusStr))
                    {
                        case (int)GarageLogic.eCarState.InRepair:
                            printVehiclesByStatus(GarageLogic.eCarState.InRepair);
                            isValid = true;
                            break;
                        case (int)GarageLogic.eCarState.Repaired:
                            printVehiclesByStatus(GarageLogic.eCarState.Repaired);
                            isValid = true;
                            break;
                        case (int)GarageLogic.eCarState.Paid:
                            printVehiclesByStatus(GarageLogic.eCarState.Paid);
                            isValid = true;
                            break;
                        default:
                            Console.WriteLine("Invalid Input");
                            break;

                    }
                }
                else
                {
                    Console.WriteLine("Invalid Input,you must choose one of the options");
                    isValid = false;
                }
            }

        }

       
        private String statusesMessages()
        {
            String choice;
            List<string> statuses = m_GarageManager.GetStatusOptions();
            Console.WriteLine("Press:");

            for (int i = 0; i < statuses.Count; i++)
            {
                Console.WriteLine("{0}) {1}", (i + 1).ToString(), statuses[i]);
            }
            return choice = Console.ReadLine();
        }

        private void printVehiclesByStatus(GarageLogic.eCarState i_State)
        {
            List<string> licenses = m_GarageManager.GetVehicleByStatus(i_State);
            if(licenses != null)
            {
                Console.WriteLine("Licenses number with state {0}:", i_State.ToString());
                foreach (string currLicesnse in licenses)
                {
                    Console.WriteLine(currLicesnse);
                }
            }
            else
            {
                Console.WriteLine("There is no vehicles in the garage with state {0}.",
                   i_State.ToString());
            }
        }

        private void changeCustomerVehicleState(GarageLogic.CustomerCard i_Customer, 
            GarageLogic.eCarState i_State)
        {
            m_GarageManager.ChangeCustomerVehicleState(i_Customer, i_State);
            Console.WriteLine("{0}'s Vehicle changed its status to {1} ", i_Customer.Name, i_Customer.CarState);
        }

        private void newCustomerActions(string i_LicenceStr)
        {
            string customerName, customerPhone;
            GarageLogic.Vehicle vehicleToAdd = prepareCar(i_LicenceStr);
            List<string> vehicleInfo = vehicleToAdd.GetDataNames();
            getVehicleInfo(vehicleToAdd, vehicleInfo);
            getCustomerCardData(out customerName, out customerPhone);
            m_GarageManager.EnterVehicle(vehicleToAdd, customerName, customerPhone);
            Console.WriteLine("{0}'s vehicle was added successfully to the garage!", customerName);
        }

        private GarageLogic.Vehicle prepareCar(string i_LicenseNumber)
        {
            GarageLogic.Vehicle vehicleToAdd = null;
            string vehicleType;
            bool isValid = true; ;
            do
            {
                Console.WriteLine("Please choose your vehicle type:");
               string[] vehicleTypes = GarageLogic.VehicleCreator.GetDataNames();
                int i = 1;
                foreach (string type in vehicleTypes)
                {
                    Console.WriteLine(i.ToString() + ") " + type.ToString());
                    i++;
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
                    Console.WriteLine(string.Format("Please enter {0}", i_vehicleInfoStrs[i]));
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
                catch (FormatException ec)
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
            do
            {
                Console.WriteLine("Please enter license number:");
                o_LicenceStr = Console.ReadLine();
            }
            while (!checkValidNumericStr(o_LicenceStr));
        }


        private bool checkValidNumericStr(string i_LicenceStr)
        {
            int res;
            bool isValid = true;
            if (string.IsNullOrEmpty(i_LicenceStr) || string.IsNullOrWhiteSpace(i_LicenceStr))
            {
                isValid = false;
                Console.WriteLine("Invalid Licence number");
            }
            else if(int.TryParse(i_LicenceStr, out res) == false)
            {
                isValid = false;
                Console.WriteLine("Invalid  number (use only numbers)");
            }
            return isValid;
        }

        private void getCustomerCardData(out string i_Name, out string i_Phone)
        {
            Console.WriteLine("Last details before entering the car");
            do
            {
                Console.WriteLine("Owner's name:");
                i_Name = Console.ReadLine();
            }
            while (!checkValidValue(i_Name));
            do
            {
                Console.WriteLine("Owner's phone number:");
                i_Phone = Console.ReadLine();
            }
            while (!checkValidNumericStr(i_Phone));

        }

        private void printMenu()
        {
            Ex02.ConsoleUtils.Screen.Clear();
            Console.WriteLine(@"Welcome to the garage!
Please choose the service you want:
==================================
1) Add a new car to the garage
2) See the vehicles in the garage
3) Change vehicle status
4) Wheels air blowing
5) Put fuel
6) Charge vehicle
7) Show customer card details
8) Exit
=================================");
        }
    }
}
