using System.Collections.Generic;
using System;

namespace Ex03.GarageLogic
{
    public class FuelEnergySource : EnergySource
    {
        private eFuelType m_FuelType;

        public FuelEnergySource() : base() { }

        public float CurrentFuelAmount
        {
            get
            {
                return base.CurrAmount;
            }
        }

        public float MaxFuelAmount
        {
            get
            {
                return base.MaxAmount;
            }
        }

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

        public override void Load(float i_Amount)
        {
            base.Load(i_Amount);
        }
        public static List<string> GetFuelTypes()
        {
            List<string> fuelTypes = new List<string>();
            fuelTypes.Add(eFuelType.Octan95.ToString());
            fuelTypes.Add(eFuelType.Octan96.ToString());
            fuelTypes.Add(eFuelType.Octan98.ToString());
            fuelTypes.Add(eFuelType.Soler.ToString());
            return fuelTypes;
        }

        public static bool IsFuelType(string i_Type)
        {
            bool isExist = false;
            if(int.TryParse(i_Type,out int res))
            {
                if(res >= (int)eFuelType.Octan95 && res <= (int)eFuelType.Soler )
                {
                    isExist = true;
                }
            }
            return isExist;
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
