using System.Collections.Generic;
using System;
using System.Linq;

namespace Ex03.GarageLogic
{
    internal class FuelEnergySource : EnergySource
    {
        private eFuelType m_FuelType;

        public eFuelType FuelType
        {
            get
            {
                return m_FuelType;
            }

            set
            {
                m_FuelType = value;
            }
        }

        public static string[] GetFuelTypes()
        {
            string[] fuelTypes = Enum.GetNames(typeof(eFuelType));
            return fuelTypes;
        }

        public static bool IsFuelType(string i_Type)
        {
            bool isExist = false;
            var first = Enum.GetValues(typeof(eFuelType)).Cast<eFuelType>().First();
            var last = Enum.GetValues(typeof(eFuelType)).Cast<eFuelType>().Last();

            if(int.TryParse(i_Type, out int res))
            {
                if(res >= (int)first && res <= (int)last)
                {
                    isExist = true;
                }
            }

            return isExist;
        }

        public override void GetDetails(List<string> i_VehicleDetails)
        {
            base.GetDetails(i_VehicleDetails);
            i_VehicleDetails.Add("Fuel Type: " + m_FuelType.ToString());
        }
    }

    public enum eFuelType
    {
        Octan95 = 1,
        Octan96 = 2,
        Octan98 = 3,
        Soler = 4
    }
}
