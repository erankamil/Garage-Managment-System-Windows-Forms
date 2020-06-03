using System;

namespace Ex03.GarageLogic
{
    public class MotorCycle : Vehicle
    {
        private eLicenseType m_LicenseType;
        private readonly int m_EngineCapacity;
        private EnergySource m_EnergySourceType;

        public MotorCycle(Vehicle i_Base, eLicenseType i_LicenseType, int i_FuelType) : base(i_Base)
        {
            m_LicenseType = i_LicenseType;
            //Type type = i_Base.EnergySource.GetType();
            //if (type.Equals(typeof(ElectricEnergySource)))
            //{
            //    m_EnergySourceType = new ElectricEnergySource(i_Base.EnergySource);
            //    m_EnergySourceType.Type = EnergySource.eType.electric;
            //}
            //else
            //{
            //    m_EnergySourceType = new FuelEnergySource(i_Base.EnergySource, i_FuelType);
            //    m_EnergySourceType.Type = EnergySource.eType.fuel;
            //}
        }

        public eLicenseType LicenseType
        {
            get
            {
                return m_LicenseType;
            }
            set
            {
                m_LicenseType = value;
            }
        }

        public int MaxCapacity
        {
            get
            {
                return m_EngineCapacity;
            }
        }


        public enum eLicenseType
        {
            A = 1,
            A1 = 2,
            AA = 3,
            B = 4
        }
    }
}
