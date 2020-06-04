
namespace Ex03.GarageLogic
{
    public class ElectricEnergySource : EnergySource
    {
        //public ElectricEnergySource(float i_BatteryVlotage,float i_MaxBatteryVoltage)
        //    :base(i_BatteryVlotage, i_MaxBatteryVoltage) { }

        //public ElectricEnergySource(EnergySource i_Base) : base(i_Base) { }

        public float CurrentBatteryVoltage
        {
            get
            {
                return base.CurrAmount;
            }
        }


    }
}
