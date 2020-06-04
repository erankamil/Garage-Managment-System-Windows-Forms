using System.Collections.Generic;
using System;

namespace Ex03.GarageLogic
{
    public class MotorCycle : Vehicle
    {
        private eLicenseType m_LicenseType;
        private int m_EngineCapacity;
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

        public override List<string> GetInfo()
        {
            List<string> infoStrs = base.GetInfo();
            infoStrs.Add("Licence Type");
            infoStrs.Add("Engine capacity");
            return infoStrs;
        }
        public override int UpdateInfo(List<string> i_InfoStrs)
        {
            int index = base.UpdateInfo(i_InfoStrs);
            if (Enum.TryParse<eLicenseType>(i_InfoStrs[index++], out eLicenseType res))
            {
                m_LicenseType = res;
            }
            m_EngineCapacity = int.Parse(i_InfoStrs[index]);
            return index;
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
