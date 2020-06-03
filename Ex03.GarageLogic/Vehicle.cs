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

            //public Wheel(string i_Manufacturer, float i_AirPresure)
            //{
            //    m_Manufacturer = i_Manufacturer;
            //    m_CurrentAirPresure = i_AirPresure;
            //}

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

        //public Vehicle(string i_Model, string i_LicensePlate, float i_Energy,
        //    eVehicleWheels i_NumOfWheels, float i_CurrScale, float i_MaxScale)
        //{
        //    m_Model = i_Model;
        //    m_LicesncePlate = i_LicensePlate;
        //    m_EnergyPercent = i_Energy;
        //    m_Wheels = new Wheel[(int)i_NumOfWheels];
        //    m_EnergySource = new EnergySource(i_CurrScale, i_MaxScale);
        //}

        public Vehicle(Vehicle i_Vehicle)
        {
            m_Model = i_Vehicle.Model;
            m_LicesncePlate = i_Vehicle.LicesncePlate;
            m_EnergyPercent = i_Vehicle.EnergyPercent;
            m_Wheels = i_Vehicle.m_Wheels;
            m_EnergySource = i_Vehicle.m_EnergySource;
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



