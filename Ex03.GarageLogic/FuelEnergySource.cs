
namespace Ex03.GarageLogic
{
    internal class FuelEnergySource : EnergySource
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

        public bool PutGas(float i_AmuntOfFuel)
        {
            return base.Load(i_AmuntOfFuel);
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
    }

    public enum eFuelType
    {
        Octan95 = 95,
        Octan96 = 96,
        Octan98 = 98,
        Soler = 100
    }
}
