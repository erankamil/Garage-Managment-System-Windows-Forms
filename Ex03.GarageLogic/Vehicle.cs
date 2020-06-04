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

        public class Wheel
        {
            private string m_Manufacturer;
            private float m_CurrentAirPresure;
            private float m_MaxAirPresure;

            public string Manufacturer
            {
                get
                {
                    return m_Manufacturer;
                }

                set
                {
                    m_Manufacturer = value;
                }
            }

            public float CurrentAirPresure
            {
                get
                {
                    return m_CurrentAirPresure;
                }

                set
                {
                    m_CurrentAirPresure = value;
                }
            }

            public float MaxAirPresure
            {
                get
                {
                    return m_MaxAirPresure;
                }
                set
                {
                    m_MaxAirPresure = value;
                }
            }
            
            public void AirBlowing(float i_AirMount)
            {
                m_CurrentAirPresure += i_AirMount;
            }
        }

        public Vehicle(string i_LicesncePlate, EnergySource.eEnergyType i_SouceType)
        {
            m_LicesncePlate = i_LicesncePlate;
            switch (i_SouceType)
            {
                case EnergySource.eEnergyType.electric:
                    m_EnergySource = new ElectricEnergySource();
                    break;
                case EnergySource.eEnergyType.fuel:
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
            GetInfoStrs.Add("Wheels Manufacturer");
            for(int i = 0; i < m_Wheels.Length; i++)
            {
                GetInfoStrs.Add("Air preasure Wheel number " + (i+1).ToString());
            }

            return GetInfoStrs;
        }

        public virtual void UpdateInfo(string i_VehicleInfoStr, int i_Index)
        {
            if (i_VehicleInfoStr != null)
            {
                if (i_Index == 0)
                {
                     m_Model = i_VehicleInfoStr;
                }
                else if (i_Index == 1)
                {
                    float res;
                    if (float.TryParse(i_VehicleInfoStr, out res))
                    {
                        if (res >= 0 && res <= m_EnergySource.MaxAmount)
                        {
                            m_EnergySource.CurrAmount = res;
                            m_EnergyPercent = (m_EnergySource.CurrAmount / m_EnergySource.MaxAmount);
                        }
                        else
                        {
                            throw new ValueOutOfRangeException(i_VehicleInfoStr, 0, m_EnergySource.MaxAmount);
                        }
                    }
                    else
                    {
                        throw new NullReferenceException("Current scale must be a non negative number");
                    }
                }
                else // for each wheel , need to chagne manufacturer
                {
                    float res;
                    if (float.TryParse(i_VehicleInfoStr, out res))
                    {
                        if (res >= 0 && res <= m_Wheels[i_Index - 2].MaxAirPresure)
                        {
                            m_Wheels[i_Index - 2].CurrentAirPresure = res;
                        }
                        else
                        {
                            throw new ValueOutOfRangeException(i_VehicleInfoStr, 0, m_Wheels[i_Index - 2].MaxAirPresure);
                        }
                    }
                    else
                    {
                        throw new NullReferenceException("Wheel air preasure must be non negative number");
                    }
                }
            }
            else // string input is null
            {
                throw new NullReferenceException();
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

        public enum eVehicleWheels
        {
            MotorCycle = 2,
            Car = 4,
            Truck = 16
        }

    }


}



