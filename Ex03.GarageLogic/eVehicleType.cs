using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public struct eVehicleType
    {
        public enum eType
        {
            electricCar = 1,
            fuelCar,
            electricMotorCycle,
            fuelMotorCycle,
            Trunk
        }

        public static List<string> GetInfo()
        {
            List<string> vehicleTypes = new List<string>();
            vehicleTypes.Add("1 electric Car");
            vehicleTypes.Add("2 Fuel Car");
            vehicleTypes.Add("3 Electric MotorCycle");
            vehicleTypes.Add("4 Fuel MotorCycle");
            vehicleTypes.Add("5 Trunk");
            return vehicleTypes;
        }


    }
}
