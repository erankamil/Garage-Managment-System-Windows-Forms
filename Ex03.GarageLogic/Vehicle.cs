using System.Collections.Generic;
using System;

namespace Ex03.GarageLogic
{
    public class Vehicle
    {
        private string m_Model;
        private readonly string m_LicesncePlate;
        private float m_EnergyPercent;
        private Wheel[] m_Wheels;
        private EnergySource m_EnergySource;
        private string m_WheelsManufacturer;

        public class Wheel
        {
            private float m_CurrentAirPressure;
            private float m_MaxAirPressure;


            public float CurrentAirPressure
            {
                get
                {
                    return m_CurrentAirPressure;
                }

                set
                {
                    m_CurrentAirPressure = value;
                }
            }

            public float MaxAirPressure
            {
                get
                {
                    return m_MaxAirPressure;
                }
                set
                {
                    m_MaxAirPressure = value;
                }
            }
            
            public void AirBlowing(float i_AirMount)
            {
                m_CurrentAirPressure += i_AirMount;
            }
        }

        public Vehicle(string i_LicesncePlate, eEnergyType i_SouceType)
        {
            m_LicesncePlate = i_LicesncePlate;
            switch (i_SouceType)
            {
                case eEnergyType.Electric:
                    m_EnergySource = new ElectricEnergySource();
                    break;
                case  eEnergyType.Fuel:
                    m_EnergySource = new FuelEnergySource();
                    break;
                default:
                    break;

            }
        }

        public Vehicle(Vehicle i_Vehicle)
        {
            m_Model = i_Vehicle.Model;
            m_LicesncePlate = i_Vehicle.LicesncePlate;
            m_EnergyPercent = i_Vehicle.EnergyPercent;
            m_Wheels = i_Vehicle.m_Wheels;
            m_EnergySource = i_Vehicle.m_EnergySource;
        }

        public virtual List<string> GetInfo()
        {
            List<string> GetInfoStrs = new List<string>();
            GetInfoStrs.Add("Model Name");
            GetInfoStrs.Add("Current Energy Amount");
            GetInfoStrs.Add("Wheels Manufacturer ");
            for (int i = 0; i < m_Wheels.Length; i++)
            {
              
                GetInfoStrs.Add("Air preasure Wheel number " + (i+1).ToString());
            }

            return GetInfoStrs;
        }

        public virtual void UpdateInfo(string i_VehicleInfoStr, int i_Index)
        {
            if(string.IsNullOrEmpty(i_VehicleInfoStr) || string.IsNullOrWhiteSpace(i_VehicleInfoStr))
            {
                throw new ArgumentException();
            }
            else
            {
                switch (i_Index)
                {
                    case (int)eVehicleInfo.ModelType:
                        m_Model = i_VehicleInfoStr;
                        break;
                    case (int)eVehicleInfo.CurrentPersent:
                        updateEnergyPersent(i_VehicleInfoStr);
                        break;
                    case (int)eVehicleInfo.WheelsManufacturer:
                        m_WheelsManufacturer = i_VehicleInfoStr;
                        break;
                    default:
                        updateWheelAirPressure(i_VehicleInfoStr, i_Index);
                        break;
                }
            }
        }

        public void InitializeWheels(float i_MaxAirPressure, eVehicleWheels i_NumOfWheels)
        {
            m_Wheels= new Wheel[(int)i_NumOfWheels];
            for (int i = 0; i < (int)i_NumOfWheels; i++)
            {
               m_Wheels[i] = new Wheel();
            }

            foreach (Wheel wheel in m_Wheels)
            {

                wheel.MaxAirPressure = i_MaxAirPressure;
            }
        }

        private void updateWheelAirPressure(string i_VehicleInfoStr, int i_Index)
        {
            float res;
            if (float.TryParse(i_VehicleInfoStr, out res))
            {
                if (res >= 0 && res <= m_Wheels[i_Index - 3].MaxAirPressure)
                {
                    m_Wheels[i_Index - 3].CurrentAirPressure = res;
                }
                else
                {
                    throw new ValueOutOfRangeException(i_VehicleInfoStr, 0, m_Wheels[i_Index - 3].MaxAirPressure);
                }
            }
            else
            {
                throw new FormatException("Wheel air preasure must be non negative number");
            }
        }

        private void updateEnergyPersent(string i_VehicleInfoStr)
        {
            float res;
            if (float.TryParse(i_VehicleInfoStr, out res))
            {
                if (res >= 0 && res <= m_EnergySource.MaxAmount)
                {
                    m_EnergySource.CurrAmount = res;
                    m_EnergyPercent = (m_EnergySource.CurrAmount / m_EnergySource.MaxAmount)*100;
                }
                else
                {
                    throw new ValueOutOfRangeException(i_VehicleInfoStr, 0, m_EnergySource.MaxAmount);
                }
            }
            else
            {
                throw new FormatException("Current scale must be a non negative number");
            }
        }

        public string Model
        {
            get
            {
                return m_Model;
            }

            set
            {
                m_Model = value;
            }
        }

        public string LicesncePlate
        {
            get
            {
                return m_LicesncePlate;
            }
        }

        public float EnergyPercent
        {
            get
            {
                return m_EnergyPercent;
            }

            set
            {
                m_EnergyPercent = value;
            }
        }

        public EnergySource EnergySource
        {
            get
            {
                return m_EnergySource;
            }
        }

        public Wheel[] Wheels
        {
            get
            {
                return m_Wheels;
            }
            set
            {
                m_Wheels = value;
            }
        }
    }

    public enum eVehicleWheels
    {
        MotorCycle = 2,
        Car = 4,
        Truck = 16
    }

    public enum eVehicleInfo
    {
        ModelType = 0,
        CurrentPersent,
        WheelsManufacturer
    }

}



