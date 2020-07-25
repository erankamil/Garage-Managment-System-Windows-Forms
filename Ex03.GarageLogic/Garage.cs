using System.Collections.Generic;
using System;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private readonly Dictionary<string, CustomerCard> m_CostumerBook;

        public Garage()
        {
            m_CostumerBook = new Dictionary<string, CustomerCard>();
        }

        public bool FindCustomer(string i_LicencsePlate, out CustomerCard res)
        {
            bool isExist = false;
            res = null;
            foreach (KeyValuePair<string, CustomerCard> currentCostumer in m_CostumerBook)
            {
                if (currentCostumer.Value.Vehicle.LicesncePlate == i_LicencsePlate)
                {
                    isExist = true;
                    res = currentCostumer.Value;
                }
            }

            return isExist;
        }

        public void BlowVehicleWheels(CustomerCard i_Customer)
        {
            i_Customer.Vehicle.BlowWheelsToMax();
        }

        public bool IsFuelEngine(CustomerCard i_Customer)
        {
            return i_Customer.Vehicle.EnergySource is FuelEnergySource;
        }

        public bool IsElectricEngine(CustomerCard i_Customer)
        {
           return i_Customer.Vehicle.EnergySource is ElectricEnergySource;
        }

        public void RefuelVehicle(CustomerCard i_Cutomer, float i_Amount, string i_TypeStr)
        {
            eFuelType eType = FromStringToVehicleFuelTypeEnum(i_TypeStr);
            FuelEnergySource fuelSource = i_Cutomer.Vehicle.EnergySource as FuelEnergySource;
            if (fuelSource.FuelType == eType)
            {
                fuelSource.Load(i_Amount);
            }
            else
            {
                throw new ArgumentException("Fuel type is not suitable to this vehicle");
            }
        }

        public void RechargeVehicle(CustomerCard i_Cutomer, float i_Amount)
        {
            i_Cutomer.Vehicle.EnergySource.Load(i_Amount / 60);
        }

        public void ChangeCustomerVehicleState(CustomerCard i_Cutomer, string i_StateToChangeTo)
        {
            eCarState state = FromStringToCarStateEnum(i_StateToChangeTo);
            i_Cutomer.CarState = state;
        }

        public void EnterVehicle(Vehicle i_Vehicle, string i_Name, string i_Phone)
        {
            CustomerCard cutomerToAdd = new CustomerCard(i_Vehicle, i_Name, i_Phone);
            string key = cutomerToAdd.Vehicle.LicesncePlate;
            m_CostumerBook.Add(key, cutomerToAdd);
        }

        private List<string> getLicences(eCarState i_State, string i_VehicleType)
        {
            List<string> licencses = new List<string>();
            foreach (KeyValuePair<string, CustomerCard> currentCostumer in m_CostumerBook)
            {
                if (i_VehicleType == "All")
                {
                    licencses.Add(currentCostumer.Key);
                }
                else
                {
                    if (currentCostumer.Value.CarState == i_State)
                    {
                        licencses.Add(currentCostumer.Key);
                    }
                }
            }

            if(licencses.Count == 0)
            {
                licencses = null;
            }

            return licencses;
        }

        public List<string> GetVehiclesByState(string i_VehicleState)
        {
            eCarState state = eCarState.InRepair;
            List<string> licensesByState = null;
            if (i_VehicleState != "All")
            {
                state = FromStringToCarStateEnum(i_VehicleState);
            }
            licensesByState = getLicences(state, i_VehicleState);
            return licensesByState;
        }

        public eCarState FromStringToCarStateEnum(string i_VehicleState)
        {
            eCarState res;
            switch (i_VehicleState)
            {
                case "InRepair":
                    res = eCarState.InRepair;
                    break;
                case "Repaired":
                    res = eCarState.Repaired;
                    break;
                case "Paid":
                    res = eCarState.Paid;
                    break;
                default:
                    int number;
                    if(int.TryParse(i_VehicleState,out number) == false)
                    {
                        throw new FormatException("invalid state");
                    }
                    else
                    {
                        throw new ValueOutOfRangeException(i_VehicleState, 1, 3);
                    }
            }
            return res;
        }

        public eFuelType FromStringToVehicleFuelTypeEnum(string i_TypeStr)
        {
            eFuelType eType;
            switch (i_TypeStr)
            {
                case "Octan95":
                    eType = eFuelType.Octan95;
                    break;
                case "Octan96":
                    eType = eFuelType.Octan96;
                    break;
                case "Octan98":
                    eType = eFuelType.Octan98;
                    break;
                case "Soler":
                    eType = eFuelType.Soler;
                    break;
                   default:
                    int type;
                    if (int.TryParse(i_TypeStr, out type) == false)
                    {
                        throw new FormatException("invalid fuel type");
                    }
                    else
                    {
                        throw new ValueOutOfRangeException(i_TypeStr, 1, 4);
                    }
            }
            return eType;
        }


        public string[] GetFuelTypes()
        {
            return FuelEnergySource.GetFuelTypes();
        }

        public bool IsFuelType(string i_Type)
        {
            return FuelEnergySource.IsFuelType(i_Type);
        }

        public List<string> GetStatusOptions()
        {
            List<string> statuses = new List<string>(4);
            foreach(string curr in Enum.GetNames(typeof(eCarState)))
            {
                statuses.Add(curr);
            }

            statuses.Add("All");
            return statuses;
        }
    }

    public enum eCarState
    {
        InRepair = 1,
        Repaired,
        Paid
    }
}
