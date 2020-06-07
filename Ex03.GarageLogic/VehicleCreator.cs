using System.Collections.Generic;
using System;

namespace Ex03.GarageLogic
{
    public static class VehicleCreator
    {
        public static  Vehicle Create(string i_LicencePlate, string i_VehicleType)
        {
            Vehicle vehicleToCreate = null;
            if (int.TryParse(i_VehicleType, out int vehicleNum))
            {
                if (vehicleNum >= (int)eType.ElectricCar && vehicleNum
                    <= (int)eType.Trunk)
                {
                    Enum.TryParse<eType>(vehicleNum.ToString()
                        , out eType vehicleType);
                    switch (vehicleType)
                    {
                        case eType.ElectricCar:
                            vehicleToCreate = new Car(i_LicencePlate, eEnergyType.Electric);
                            break;
                        case eType.FuelCar:
                            vehicleToCreate = new Car(i_LicencePlate, eEnergyType.Fuel);
                            break;
                        case eType.ElectricMotorCycle:
                            vehicleToCreate = new MotorCycle(i_LicencePlate, eEnergyType.Electric);
                            break;
                        case eType.FuelMotorCycle:
                            vehicleToCreate = new MotorCycle(i_LicencePlate, eEnergyType.Fuel);
                            break;
                        case eType.Trunk:
                            vehicleToCreate = new Trunk(i_LicencePlate);
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    throw new ValueOutOfRangeException(i_VehicleType, (int)eType.ElectricCar,
                        (int)eType.Trunk);
                }
            }
            else
            {
                throw new NullReferenceException("Car type not supported");
            }
            return vehicleToCreate;
        }
        public static List<string> GetInfo()
        {
            List<string> vehicleTypes = new List<string>();
            vehicleTypes.Add("1 Electric Car");
            vehicleTypes.Add("2 Fuel Car");
            vehicleTypes.Add("3 Electric MotorCycle");
            vehicleTypes.Add("4 Fuel MotorCycle");
            vehicleTypes.Add("5 Trunk");
            return vehicleTypes;
        }
    }

    public enum eType
    {
        ElectricCar = 1,
        FuelCar,
        ElectricMotorCycle,
        FuelMotorCycle,
        Trunk
    }
}
