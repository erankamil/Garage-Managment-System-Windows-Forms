using System.Collections.Generic;
using System;

namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        private eColor m_Color;
        private int m_NumOfDoors;
        private int m_startIndexInfo;

        public Car(string i_LicencePlate, EnergySource.eEnergyType i_Type) :
            base(i_LicencePlate, i_Type)
        {
            base.Wheels = new Wheel[(int)Vehicle.eVehicleWheels.Car];
            for (int i = 0; i < (int)Vehicle.eVehicleWheels.Car; i++)
            {
                base.Wheels[i] = new Wheel();
            }

            foreach (Wheel wheel in base.Wheels)
            {

                wheel.MaxAirPresure = 32;
            }

            switch (i_Type)
            {
                case EnergySource.eEnergyType.electric:
                    base.EnergySource.MaxScale = (float)2.1;
                    break;
                case EnergySource.eEnergyType.fuel:
                    (base.EnergySource as FuelEnergySource).FuelType = FuelEnergySource.eFuelType.Octan96;
                    base.EnergySource.MaxScale = (float)60;
                    break;
                default:
                    break;
            }
            m_startIndexInfo = base.Wheels.Length + 2;
        }

        public override List<string> GetInfo()
        {
            List<string> infoStrs = base.GetInfo();
            infoStrs.Add("Color");
            infoStrs.Add("Number Of Doors");
            return infoStrs;
        }

        public override void UpdateInfo(string i_Value, int i_Index)
        {
            if (i_Index < m_startIndexInfo) // base info
            {
                base.UpdateInfo(i_Value, i_Index);
            }
            else
            {
                if(i_Value != null)
                {
                    if (i_Index == m_startIndexInfo)
                    {
                        if (Enum.TryParse<eColor>(i_Value, out eColor res))
                        {
                            m_Color = res;
                        }
                        else
                        {
                            throw new NullReferenceException("Color is not supported");
                        }
                    }
                    else
                    {
                        if (int.TryParse(i_Value, out int numOfDoors)) // need to change to enum...
                        {
                            m_NumOfDoors = numOfDoors;
                        }
                        else
                        {
                            throw new NullReferenceException("Number of door should be 2,3,4,5");
                        }
                    }
                }
                else
                {
                    throw new NullReferenceException();
                }
            }
        }

        public enum eColor
        {
            RED = 1,
            WHITE = 2,
            BLACK = 3,
            SILVER = 4
        }

    }
}
