using System.Collections.Generic;
using System;

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

        public bool  IsFuelEngine(CustomerCard i_Customer)
        {
            return (i_Customer.Vehicle.EnergySource is FuelEnergySource);
        }

        public bool IsElectricEngine(CustomerCard i_Customer)
        {
           return (i_Customer.Vehicle.EnergySource is ElectricEnergySource);
        }

        public void RefuelVehicle(CustomerCard i_Cutomer, float i_Amount, string i_TypeStr)
        {
           
            FuelEnergySource fuelSource = i_Cutomer.Vehicle.EnergySource as FuelEnergySource;
            if (int.TryParse(i_TypeStr, out int res))
            {
                if ((int)fuelSource.FuelType == res)
                {
                    fuelSource.Load(i_Amount);
                }
                else
                {
                    throw new ArgumentException("Fuel type is not suitable");
                }
            }
            else
            {
                throw new FormatException("Invalid Value");
            }
            
        }

        public void RechargeVehicle(CustomerCard i_Cutomer, float i_Amount)
        {
            ElectricEnergySource fuelSource = i_Cutomer.Vehicle.EnergySource as ElectricEnergySource;
            fuelSource.Load(i_Amount / 60);
        }

        public void ChangeCustomerVehicleState(CustomerCard i_Cutomer, eCarState i_State = eCarState.InRepair)
        {
            i_Cutomer.CarState = i_State; ;
        }

        public void EnterVehicle(Vehicle i_Vehicle, string i_Name, string i_Phone)
        {
            CustomerCard cutomerToAdd = new CustomerCard(i_Vehicle, i_Name, i_Phone);
            string key = cutomerToAdd.Vehicle.LicesncePlate;
            m_CostumerBook.Add(key, cutomerToAdd);
        }

        public List<string> GetVehicleByStatus(eCarState i_State)
        {
            List<string> licencses = new List<string>();
            foreach (KeyValuePair<string, CustomerCard> currentCostumer in m_CostumerBook)
            {
                if(currentCostumer.Value.CarState == i_State)
                {
                    licencses.Add(currentCostumer.Key);
                }
            }
            if (licencses.Count == 0)
            {
                licencses = null;
            }
            return licencses;
        }
        
        public List<string> GetStatusOptions()
        {
            List<string> statuses = new List<string>();
            statuses.Add(eCarState.InRepair.ToString());
            statuses.Add(eCarState.Repaired.ToString());
            statuses.Add(eCarState.Paid.ToString());
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
