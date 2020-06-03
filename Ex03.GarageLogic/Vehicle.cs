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
            GetInfoStrs.Add("Current Energy");
            GetInfoStrs.Add("Wheels Manufacturer");
            for(int i = 0; i < m_Wheels.Length; i++)
            {
                GetInfoStrs.Add("Air preasure Wheel number " + (i+1).ToString());
            }

            return GetInfoStrs;
        }

        public virtual void UpdateInfo(List<string> i_InfoStrs)
        {
            m_Model = i_InfoStrs[0];
            m_EnergySource.CurrScale = float.Parse(i_InfoStrs[1]);
            for(int i = 0, j = 3; i < m_Wheels.Length; i++, j++)
            {
                m_Wheels[i].Manufacturer = i_InfoStrs[2];
                m_Wheels[i].CurrentAirPresure = float.Parse(i_InfoStrs[j]);
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



