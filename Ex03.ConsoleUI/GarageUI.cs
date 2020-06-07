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
            bool end = false;
            while ( !end )
            { 
                printMenu();
                string selection = Console.ReadLine();
                switch (selection)
                {
                    case "1":
                        case1();
                        break;
                    case "2":
                        PrintLicensesByState();
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
                    default:
                        break;
                }
                System.Threading.Thread.Sleep(2000);
            }

        }

        private void case6()
        {
            if (findCustomer(out GarageLogic.CustomerCard exsitCustomer
                  , out string licenseNumber) == true)
            {
                if (m_GarageManager.IsElectricEngine(exsitCustomer) == true)
                {
                    bool isValid = false;
                    while (!isValid)
                    {
                        float amount = getEnergyAmount();
                        try
                        {
                            m_GarageManager.RechargeVehicle(exsitCustomer, amount);
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
        }

        private void case5()
        {
            if (findCustomer(out GarageLogic.CustomerCard exsitCustomer
               , out string licenseNumber) == true)
            {
                if (m_GarageManager.IsFuelEngine(exsitCustomer) == true)
                {
                    getRefuelData(exsitCustomer);
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
                try
                {
                    m_GarageManager.RefuelVehicle(i_ExsitCustomer, amount, typeStr);
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
            }
            Console.WriteLine("Vehicle has successfully refuled!");
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
                List<string> fuelTypes = GarageLogic.FuelEnergySource.GetFuelTypes();

                for (int i = 0; i < fuelTypes.Count; i++)
                {
                    Console.WriteLine("{0}) {1}", (i + 1).ToString(), fuelTypes[i]);
                }
                typeStr = Console.ReadLine();
            }
            while (!(isValid = (checkValidValue(typeStr) && GarageLogic.FuelEnergySource.IsFuelType(typeStr))));
            return typeStr;
        }

        private void case4()
        {
            if (findCustomer(out GarageLogic.CustomerCard exsitCustomer
                 , out string licenseNumber) == true)
            {
                m_GarageManager.BlowVehicleWheels(exsitCustomer);
                Console.WriteLine("Wheels air blowing succeed");
            }
            else
            {
                Console.WriteLine("Customer does not exist in the garage");
            }
        }

        private void case3()
        {
            if (findCustomer(out GarageLogic.CustomerCard exsitCustomer
                , out string licenseNumber) == true)
            {
                string statusStr;
                bool isValid = false;
                while (!isValid)
                {
                    Ex02.ConsoleUtils.Screen.Clear();
                    statusStr = statusesMessages();
                    if (int.TryParse(statusStr, out int res))
                    {
                        switch (int.Parse(statusStr))
                        {
                            case (int)GarageLogic.eCarState.InRepair:
                                changeCustomerVehicleState(exsitCustomer, GarageLogic.eCarState.InRepair);
                                isValid = true;
                                break;
                            case (int)GarageLogic.eCarState.Repaired:
                                changeCustomerVehicleState(exsitCustomer, GarageLogic.eCarState.Repaired);
                                isValid = true;
                                break;
                            case (int)GarageLogic.eCarState.Paid:
                                changeCustomerVehicleState(exsitCustomer, GarageLogic.eCarState.Paid);
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
                Console.WriteLine("Customer does not exist in the garage");
            }
        }

        private void case1()
        {
            
            if (findCustomer(out GarageLogic.CustomerCard exsitCustomer
                , out string licenseNumber) == true)
            {
                changeCustomerVehicleState(exsitCustomer, GarageLogic.eCarState.InRepair);
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
        public void PrintLicensesByState()
        {
            string statusStr;
            bool isValid = false;
            while (!isValid)
            {
                Ex02.ConsoleUtils.Screen.Clear();
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
                foreach(string currLicesnse in licenses)
                {
                    Console.WriteLine(currLicesnse);
                }
            }
            else
            {
                Console.WriteLine("There is no vehicles in the garage with state:{0}",
                   i_State.ToString());
            }
            Ex02.ConsoleUtils.Screen.Clear();
        }

        private void changeCustomerVehicleState(GarageLogic.CustomerCard i_Customer, 
            GarageLogic.eCarState i_State)
        {
            m_GarageManager.ChangeCustomerVehicleState(i_Customer, i_State);
            Console.WriteLine("{0}'s Vehicle changed its status to: {1} ", i_Customer.Name, i_Customer.CarState);
        }

        private void newCustomerActions(string i_LicenceStr)
        {
            string customerName, customerPhone;
            GarageLogic.Vehicle vehicleToAdd = prepareCar(i_LicenceStr);
            List<string> vehicleInfo = vehicleToAdd.GetInfo();
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
            if (string.IsNullOrEmpty(i_LicenceStr) || string.IsNullOrWhiteSpace(i_LicenceStr))
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
            Ex02.ConsoleUtils.Screen.Clear();
            Console.WriteLine(@"Welcome to the garage!
Please choose the service you want:
1) Add a new car to the garage
2) See the vehicles in the garage
3) Change vehicle status
4) Wheels air blowing
5) Put fuel
6) Charge vehicle");
        }
    }
}
