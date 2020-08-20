using System.Collections.Generic;
using System;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Bson;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private const int k_NumOfProperties = 4;
        private  string m_LicesncePlate;
        private string m_Model;
        private float m_EnergyPercent;
        private Wheel[] m_Wheels;
        private EnergySource m_EnergySource;
        private string m_WheelsManufacturer;
 
        internal class Wheel
        {
            private float m_CurrentAirPressure;
            private float m_MaxAirPressure;

            public Wheel(float i_MaximumAirPressure)
            {
                m_MaxAirPressure = i_MaximumAirPressure;
            }

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
            
            public void AirBlowing()
            {
                m_CurrentAirPressure = this.MaxAirPressure;
            }

            internal void RegisterClass()
            {
                if (!BsonClassMap.IsClassMapRegistered(typeof(Wheel)))
                {
                    BsonClassMap.RegisterClassMap<Vehicle.Wheel>(cm =>
                    {
                        cm.MapField(c => c.m_CurrentAirPressure).SetElementName("CurrentAirPressure");
                        cm.MapField(c => c.m_MaxAirPressure).SetElementName("MaximumAirPressure");
                    });
                }
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
                case eEnergyType.Fuel:
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

        public virtual List<string> GetDataNames()
        {
            List<string> infoStrs = new List<string>();
            infoStrs.Add("Model name:");
            infoStrs.Add("Current energy amount:");
            infoStrs.Add("Wheels manufacturer:");
            infoStrs.Add("Wheels air preasure:");
            return infoStrs;
        }

        public virtual List<string> GetDetails()
        {
            List<string> detailsStrs = new List<string>();
            detailsStrs.Add($"License number: {m_LicesncePlate}");
            detailsStrs.Add($"Model: {m_Model}");
            detailsStrs.Add($"Wheels manufacturer: {m_WheelsManufacturer}");
            detailsStrs.Add($"Wneels air pressure:  {m_Wheels[0].CurrentAirPressure.ToString()}");
            detailsStrs.Add($"Energy precentage left: {m_EnergyPercent}%");
            m_EnergySource.GetDetails(detailsStrs);
            return detailsStrs;
        }

        public virtual void UpdateInfo(string i_VehicleInfoStr, int i_Index)
        {
            if(string.IsNullOrEmpty(i_VehicleInfoStr) || string.IsNullOrWhiteSpace(i_VehicleInfoStr))
            {
               string msg =string.Format("field {0} is empty.",i_Index+1);
               ArgumentException ex = new ArgumentException(msg);
               throw ex;
            }
            else
            {
                switch (i_Index)
                {
                    case (int)eVehicleInfo.ModelType:
                        m_Model = i_VehicleInfoStr;
                        break;
                    case (int)eVehicleInfo.CurrentPersent:
                        SetEnergyPersent(i_VehicleInfoStr);
                        break;
                    case (int)eVehicleInfo.WheelsManufacturer:
                        m_WheelsManufacturer = i_VehicleInfoStr;
                        break;
                    default:
                        SetWheelAirPressure(i_VehicleInfoStr, i_Index);
                        break;
                }
            }
        }

        public void UpdateEnergyPercentageLeft()
        {
            EnergyPercent = (EnergySource.CurrAmount / EnergySource.MaxAmount) * 100;
        }

        public void InitializeWheels(float i_MaxAirPressure, eVehicleWheels i_NumOfWheels)
        {
            m_Wheels = new Wheel[(int)i_NumOfWheels];
            for (int i = 0; i < (int)i_NumOfWheels; i++)
            {
               m_Wheels[i] = new Wheel(i_MaxAirPressure);
            }
        }

        private void SetWheelAirPressure(string i_VehicleInfoStr, int i_Index)
        {
            float res;
            if (float.TryParse(i_VehicleInfoStr, out res))
            {
                if (res >= 0 && res <= m_Wheels[i_Index - 2].MaxAirPressure)
                {
                    foreach(Wheel wheel in m_Wheels)
                    {
                        wheel.CurrentAirPressure = res;
                    }
                }
                else
                {
                    throw new ValueOutOfRangeException(i_VehicleInfoStr, 0, m_Wheels[i_Index - 2].MaxAirPressure);
                }
            }
            else
            {
                throw new FormatException("Wheel air preasure must be non negative number");
            }
        }

        private void SetEnergyPersent(string i_VehicleInfoStr)
        {
            float res;
            if (float.TryParse(i_VehicleInfoStr, out res))
            {
                if (res >= 0 && res <= m_EnergySource.MaxAmount)
                {
                    m_EnergySource.CurrAmount = res;
                    m_EnergyPercent = (m_EnergySource.CurrAmount / m_EnergySource.MaxAmount) * 100;
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

        public void BlowWheelsToMax()
        {
            foreach(Wheel current in m_Wheels)
            {
                current.AirBlowing();
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

        public int NumOfPropeties
        {
            get
            {
                return k_NumOfProperties;
            }
        }

        internal EnergySource EnergySource
        {
            get
            {
                return m_EnergySource;
            }
        }

        internal Wheel[] Wheels
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
        public virtual void RegisterClass()
        {
            m_Wheels = new Wheel[1];
            m_Wheels[0] = new Wheel(0);
            m_Wheels[0].RegisterClass();
            m_EnergySource.RegisterClass();
            if (!BsonClassMap.IsClassMapRegistered(typeof(Vehicle)))
            {
                BsonClassMap.RegisterClassMap<Vehicle>(cm =>
                {
                    cm.MapField(c => c.m_LicesncePlate).SetElementName("LicensePlateNumber");
                    cm.MapField(c => c.m_Model).SetElementName("ModelName");
                    cm.MapField(c => c.m_EnergyPercent).SetElementName("PercentageOfEnergy");
                    cm.MapField(c => c.m_EnergySource).SetElementName("EnergySource");
                    cm.MapField(c => c.m_WheelsManufacturer).SetElementName("WheelsManufacturer");
                    cm.MapField(c => c.m_Wheels).SetElementName("Wheels");
                });
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
        WheelsManufacturer,
        WheelsAirPressure
    }
}