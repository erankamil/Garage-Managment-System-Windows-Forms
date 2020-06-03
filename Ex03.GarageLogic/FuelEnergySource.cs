
namespace Ex03.GarageLogic
{
    public class FuelEnergySource : EnergySource
    {
        private eFuelType m_FuelType;

        public FuelEnergySource() : base()
        { }
        //public FuelEnergySource(float i_CurrentTankFuel, float i_MaxTankFuel,
        //    eFuelType i_FuelType) : base(i_CurrentTankFuel, i_MaxTankFuel)
        //{
        //    m_FuelType = i_FuelType;
        //}

        //public FuelEnergySource(EnergySource i_Base, int i_FuelType):base(i_Base)
        //{
        //    m_FuelType = (eFuelType)i_FuelType;
        //}

        public float CurrentFuelAmount
        {
            get
            {
                return base.CurrScale;
            }
        }

        public float MaxFuelAmount
        {
            get
            {
                return base.MaxScale;
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

        public enum eFuelType
        {
            Octan95 = 95,
            Octan96 = 96,
            Octan98 = 98,
            Soler = 100
        }

    }
}
