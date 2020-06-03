
using System;

namespace Ex03.GarageLogic
{
    public class VehicleCreator
    {
        public static Vehicle Create(string i_LicencePlate, string i_VehicleType)
        {
            Vehicle carToCreate;
            bool res = Enum.TryParse<eVehicleType.eType>(i_VehicleType, out eVehicleType.eType vehicleType);
            switch (vehicleType)
            {
                case eVehicleType.eType.electricCar:
                    carToCreate = new Car(i_LicencePlate, EnergySource.eEnergyType.electric);
                    break;
                case eVehicleType.eType.fuelCar:
                    carToCreate = new Car(i_LicencePlate, EnergySource.eEnergyType.fuel);
                    break;
                default:
                    carToCreate = new Car(i_LicencePlate, EnergySource.eEnergyType.fuel);
                    break;
            }
            return carToCreate;
        }
    }
}
