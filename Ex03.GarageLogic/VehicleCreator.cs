using System.Collections.Generic;
using System;

namespace Ex03.GarageLogic
{
    public static class VehicleCreator
    {
        public static Vehicle Create(string i_LicencePlate, string i_VehicleType)
        {
            Vehicle vehicleToCreate = null;
            Enum.TryParse<eType>(i_VehicleType, out eType vehicleType);
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
            return vehicleToCreate;
        }


        public static string[] GetVehicleTypeNames()
        {
            string[] vehicleTypes = Enum.GetNames(typeof(eType));
            return vehicleTypes;
        }
        
        public static eType FromStringToVehicleTypeEnum(string i_VehicleType)
        {
            eType res;
            switch (i_VehicleType)
            {
                case "ElectricCar":
                    res = eType.ElectricCar;
                    break;
                case "FuelCar":
                    res = eType.FuelCar;
                    break;
                case "FuelMotorCycle":
                    res = eType.FuelMotorCycle;
                    break;
                case "ElectricMotorCycle":
                    res = eType.ElectricMotorCycle;
                    break;
                case "Trunk":
                    res = eType.Trunk;
                    break;
                default:
                    int number;
                    if (int.TryParse(i_VehicleType, out number) == false)
                    {
                        throw new FormatException("invalid type");
                    }
                    else
                    {
                        throw new ValueOutOfRangeException(i_VehicleType, 1, 5);
                    }
            }
            return res;
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
