using System.Collections.Generic;
using System;
using System.Linq;

namespace Ex03.GarageLogic
{
    internal class Car : Vehicle
    {
        private eColor m_Color;
        private eNumOfDoors m_NumOfDoors;
        private const float k_ElectricMaxEnregy = 2.1f;
        private const float k_MaxWheelAirPressure = 32f;
        private const float k_FuelMaxTank = 60f;

        public Car(string i_LicencePlate, eEnergyType i_Type) :
            base(i_LicencePlate, i_Type)
        {
            base.InitializeWheels(k_MaxWheelAirPressure, eVehicleWheels.Car);

            switch (i_Type)
            {
                case eEnergyType.Electric:
                    base.EnergySource.MaxAmount = k_ElectricMaxEnregy;
                    break;
                case eEnergyType.Fuel:
                    (base.EnergySource as FuelEnergySource).FuelType = eFuelType.Octan96;
                    base.EnergySource.MaxAmount =k_FuelMaxTank;
                    break;
                default:
                    break;
            }
        }

        public override List<string> GetDetails()
        {
            List<string> detailsStrs = base.GetDetails();
            detailsStrs.Add("Color: " + m_Color.ToString());
            detailsStrs.Add("Number of doors: " + m_NumOfDoors.ToString());
            return detailsStrs;
        }

        public override List<string> GetDataNames()
        {
            List<string> infoStrs = base.GetDataNames();
            infoStrs.Add(@"Color options:
1) Red
2) White
3) Black
4) Silver");
            infoStrs.Add("Number Of Doors");
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
                        case (int)eCarInfo.color:
                            UpdateColor(i_Value);
                            break;
                        case (int)eCarInfo.numOfDoors:
                            UpdateNumOfDoors(i_Value);
                            break;
                        default:
                            break;
                    }
                }
            }
        }
        
        public void UpdateNumOfDoors(string i_NumOfDoors)
        {
            if (int.TryParse(i_NumOfDoors, out int res))
            {
                var first = Enum.GetValues(typeof(eNumOfDoors)).Cast<eNumOfDoors>().First();
                var last = Enum.GetValues(typeof(eNumOfDoors)).Cast<eNumOfDoors>().Last();

                if (res >= (int)first && res <= (int)last)
                {
                    Enum.TryParse<eNumOfDoors>(res.ToString(), out eNumOfDoors number);
                    m_NumOfDoors = number;
                }
                else
                { 
                    throw new ValueOutOfRangeException(i_NumOfDoors, (int)first, (int)last);
                }
            }
            else
            {
                throw new FormatException("Invalid Numbe of doors");
            }
        }

        public void UpdateColor(string i_Color)
        {
            if (int.TryParse(i_Color, out int res))
            {
                var first = Enum.GetValues(typeof(eColor)).Cast<eColor>().First();
                var last = Enum.GetValues(typeof(eColor)).Cast<eColor>().Last();

                if (res >= (int)first && res <= (int)last)
                {
                    Enum.TryParse<eColor>(res.ToString(), out eColor color);
                    m_Color = color;
                }
                else
                {
                    throw new ValueOutOfRangeException(i_Color, (int)first, (int)last);
                }
            }
            else
            {
                throw new FormatException("Color is not supported");
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
            color = 4,
            numOfDoors 
        }

    }

}
