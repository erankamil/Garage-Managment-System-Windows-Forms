using System.Collections.Generic;
using System;
using System.Linq;

namespace Ex03.GarageLogic
{
    internal class MotorCycle : Vehicle
    {
        private eLicenseType m_LicenseType;
        private int m_EngineCapacity;
        private const float k_ElectricMaxEnregy = 1.2f;
        private const float k_MaxWheelAirPressure = 30f;
        private const float k_FuelMaxTank = 7f;


        public MotorCycle(string i_LicencePlate, eEnergyType i_EnergyType) : 
            base(i_LicencePlate, i_EnergyType)
        {
            base.InitializeWheels(k_MaxWheelAirPressure, eVehicleWheels.MotorCycle);

            switch (i_EnergyType)
            {
                case eEnergyType.Electric:
                    base.EnergySource.MaxAmount = k_ElectricMaxEnregy;
                    break;
                case eEnergyType.Fuel:
                    (base.EnergySource as FuelEnergySource).FuelType = eFuelType.Octan95;
                    base.EnergySource.MaxAmount = k_FuelMaxTank;
                    break;
                default:
                    break;
            }
        }

        public eLicenseType LicenseType
        {
            get
            {
                return m_LicenseType;
            }
        }

        public int MaxCapacity
        {
            get
            {
                return m_EngineCapacity;
            }
        }

        public override List<string> GetDetails()
        {
            List<string> detailsStrs = base.GetDetails();
            detailsStrs.Add("License type " + m_LicenseType.ToString());
            detailsStrs.Add("Engine capacity " + m_EngineCapacity.ToString());
            return detailsStrs;
        }

        public override List<string> GetDataNames()
        {
            List<string> infoStrs = base.GetDataNames();
            infoStrs.Add(@"License Types
1) A
2) A2
3) AA
4) B");
            infoStrs.Add("Engine capacity");
            return infoStrs;
        }

        public override void UpdateInfo(string i_Value, int i_Index)
        {
            if (i_Index < base.NumOfPropeties)
            {
                base.UpdateInfo(i_Value, i_Index);
            }
            else
            {
                if (string.IsNullOrEmpty(i_Value) || string.IsNullOrWhiteSpace(i_Value))
                {
                    throw new ArgumentException();
                }
                else
                {
                    switch (i_Index)
                    {
                        case (int)eMotorCyceleInfo.LincenseType:
                            UpdateLicenseType(i_Value);
                            break;
                        case (int)eMotorCyceleInfo.EngineCapacity:
                            UpdateEngineCapacity(i_Value);
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        public void UpdateEngineCapacity(string i_LicenseType)
        {
            if (int.TryParse(i_LicenseType, out int res))
            {
                if(res > 0)
                {
                    m_EngineCapacity = res;
                }
                else
                {
                    throw new ArgumentException("Engine Capacity must be non negative number");
                }
            }
            else
            {
                throw new FormatException("Engine Capacity must be non negative number");
            }
        }

        public void UpdateLicenseType(string i_LicenseType)
        {
            if (int.TryParse(i_LicenseType, out int res))
            {
                var first = Enum.GetValues(typeof(eLicenseType)).Cast<eLicenseType>().First();
                var last = Enum.GetValues(typeof(eLicenseType)).Cast<eLicenseType>().Last();

                if (res >= (int)first && res <= (int)last)
                {
                    Enum.TryParse<eLicenseType>(res.ToString(), out eLicenseType color);
                    m_LicenseType = color;
                }
                else
                {
                    throw new ValueOutOfRangeException(i_LicenseType, (int)first, (int)last);
                }
            }
            else
            {
                throw new FormatException("License Type is not supported");
            }
        }

        public enum eLicenseType
        {
            A = 1,
            A1 = 2,
            AA = 3,
            B = 4
        }

        public enum eMotorCyceleInfo
        {
            LincenseType = 4,
            EngineCapacity
        }
    }
}
