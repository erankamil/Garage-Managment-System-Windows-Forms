
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    internal class ElectricEnergySource : EnergySource
    {
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

        public override void Load(float i_Amount)
        {
            base.Load(i_Amount);
        }

        public override void GetDetails(List<string> i_VehicleDetails)
        {
            base.GetDetails(i_VehicleDetails);
        }
    }
}
