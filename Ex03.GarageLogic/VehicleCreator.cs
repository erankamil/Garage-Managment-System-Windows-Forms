
using System;

namespace Ex03.GarageLogic
{
    public class VehicleCreator
    {
        public static Vehicle Create(string i_LicencePlate, string i_VehicleType)
        {
            Vehicle vehicleToCreate = null;
            if (int.TryParse(i_VehicleType, out int vehicleNum))
            {
                if (vehicleNum >= (int)eVehicleType.eType.electricCar && vehicleNum
                    <= (int)eVehicleType.eType.Trunk)
                {
                    Enum.TryParse<eVehicleType.eType>(vehicleNum.ToString()
                        , out eVehicleType.eType vehicleType);
                    switch (vehicleType)
                    {
                        case eVehicleType.eType.electricCar:
                            vehicleToCreate = new Car(i_LicencePlate, EnergySource.eEnergyType.electric);
                            break;
                        case eVehicleType.eType.fuelCar:
                            vehicleToCreate = new Car(i_LicencePlate, EnergySource.eEnergyType.fuel);
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    throw new ValueOutOfRangeException(i_VehicleType, (int)eVehicleType.eType.electricCar,
                        (int)eVehicleType.eType.Trunk);
                }
            }
            else
            {
                throw new NullReferenceException("Car type not supported");
            }
            return vehicleToCreate;
        }
    }
}
