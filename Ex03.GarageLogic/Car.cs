using System.Collections.Generic;
using System;

namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        private eColor m_Color;
        private eNumOfDoors m_NumOfDoors;
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

                wheel.MaxAirPressure = 32;
            }

            switch (i_Type)
            {
                case EnergySource.eEnergyType.electric:
                    base.EnergySource.MaxAmount = (float)2.1;
                    break;
                case EnergySource.eEnergyType.fuel:
                    (base.EnergySource as FuelEnergySource).FuelType = FuelEnergySource.eFuelType.Octan96;
                    base.EnergySource.MaxAmount = (float)60;
                    break;
                default:
                    break;
            }
            m_startIndexInfo = base.Wheels.Length + 2;
        }

        public override List<string> GetInfo()
        {
            List<string> infoStrs = base.GetInfo();
            infoStrs.Add(@"Color options:
for red  1
for white  2
for black  3
for silver 4");
            infoStrs.Add("Number Of Doors");
            return infoStrs;
        }

        public override void UpdateInfo(string i_Value, int i_Index)
        {
            if (i_Index <= m_startIndexInfo)
            {
                base.UpdateInfo(i_Value, i_Index);
            }
            else
            {
                if (string.IsNullOrEmpty(i_Value))
                {
                    throw new ArgumentNullException();
                }
                else
                {
                    switch (i_Index)
                    {
                        case (int)eCarInfo.color:
                            updateColor(i_Value);
                            break;
                        case (int)eCarInfo.numOfDoors:
                            updateNumOfDoors(i_Value);
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        private void updateNumOfDoors(string i_NumOfDoors)
        {
            if (int.TryParse(i_NumOfDoors, out int res))
            {
                if (res >= (int)eNumOfDoors.Two && res <= (int)eNumOfDoors.Five)
                {
                    Enum.TryParse<eNumOfDoors>(res.ToString(), out eNumOfDoors number);
                    m_NumOfDoors = number;
                }
                else
                {
                    throw new ValueOutOfRangeException(i_NumOfDoors, (int)eNumOfDoors.Two,
                        (int)eNumOfDoors.Five);
                }
            }
            else
            {
                throw new NullReferenceException("Invalid Numbe of doors");
            }
        }

        private void updateColor(string i_Color)
        {
            if (int.TryParse(i_Color, out int res))
            {
                if (res >= (int)eColor.Red && res <= (int)eColor.White)
                {
                    Enum.TryParse<eColor>(res.ToString(), out eColor color);
                    m_Color = color;
                }
                else
                {
                    throw new ValueOutOfRangeException(i_Color, (int)eColor.Red,
                        (int)eColor.White);
                }
            }
            else
            {
                throw new NullReferenceException("Color is not supported");
            }
        }

        public enum eColor
        {
            Red = 1,
            White = 2,
            Black = 3,
            Silver = 4
        }

        public enum eNumOfDoors
        {
            Two = 2,
            Three = 3,
            Four = 4,
            Five = 5 
        }

        public enum eCarInfo
        {
            color = 7,
            numOfDoors 
        }

    }

}
