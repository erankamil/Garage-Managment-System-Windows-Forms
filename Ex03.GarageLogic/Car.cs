using System.Collections.Generic;
using System;

namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        private eColor m_Color;
        private int m_NumOfDoors;

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

        }

        public override List<string> GetInfo()
        {
            List<string> infoStrs = base.GetInfo();
            infoStrs.Add("Color");
            infoStrs.Add("Number Of Doors");
            return infoStrs;
        }

        public override void UpdateInfo(List<string> i_InfoStrs)
        {
            base.UpdateInfo(i_InfoStrs);
            int index = i_InfoStrs.LastIndexOf("Color");
            if (Enum.TryParse<eColor>(i_InfoStrs[index++], out eColor res))
            {
                m_Color = res;
            }
            m_NumOfDoors = int.Parse(i_InfoStrs[index]);
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
