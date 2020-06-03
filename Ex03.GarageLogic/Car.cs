using System;

namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        private eColor m_Color;
        private readonly int m_NumOfDoors;

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

        public string[] GetInfo()
        {
            string[] GetInfoStrs = new string[6];
            string model = "Model Name";
            GetInfoStrs[0] = model;
            string currEnergy = "Current Energy";
            GetInfoStrs[1] = currEnergy;
            string wheelsManufacturer = "Wheels Manufacturer";
            GetInfoStrs[2] = wheelsManufacturer;
            string currAirPresure = "Current Wheel Air Pressure";
            GetInfoStrs[3] = currAirPresure;
            string color = "Color";
            GetInfoStrs[4] = color;
            string NumOfDoors = "Number Of Doors";
            GetInfoStrs[5] = NumOfDoors;
            return GetInfoStrs;
        }

        public void UpdateInfo(object[] i_InfoArr)
        {
            string modelName = i_InfoArr[0].ToString();
            base.Model = modelName;
            float currentEnergy = float.Parse(i_InfoArr[1].ToString());
            base.EnergySource.CurrScale = currentEnergy;
            string wheelManufacturer = i_InfoArr[2].ToString();
            base.Wheels[0].Manufacturer = base.Wheels[1].Manufacturer
                = base.Wheels[2].Manufacturer = base.Wheels[3].Manufacturer = wheelManufacturer;
            float firstWheelPreasure = float.Parse(i_InfoArr[3].ToString());
            float secondWheelPreasure = float.Parse(i_InfoArr[4].ToString());
            float thirdWheelPreasure = float.Parse(i_InfoArr[5].ToString());
            float fourthWheelPreasure = float.Parse(i_InfoArr[6].ToString());
            bool res1 = Enum.TryParse<Car.eColor>(i_InfoArr[7].ToString(), out Car.eColor color);
            m_Color = color;
            int numOfDoors = int.Parse(i_InfoArr[8].ToString());
        }


        //public Car(Vehicle i_Base, eColor i_Color, int i_NumOfDoors, 
        //    int i_FuelType, EnergySource i_Type): base(i_Base)
        //{
        //    m_Color = i_Color;
        //    m_NumOfDoors = i_NumOfDoors;
        //    Type type = i_Base.EnergySource.GetType();

        //}

        public enum eColor
        {
            RED = 1,
            WHITE = 2,
            BLACK = 3,
            SILVER = 4
        }

    }
}
