using System.Collections.Generic;
using System;
using System.Text;
using System.Reflection;
using MongoDB.Driver;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using System.Linq;

namespace Ex03.GarageLogic
{
    public sealed class Garage
    {
        private readonly Dictionary<string, CustomerCard> r_CostumerBook;
        private readonly IMongoCollection<BsonDocument> r_DBCollection;
        private readonly bool r_ConnectedToDB;

        public Garage(IMongoCollection<BsonDocument> i_Collection, bool i_ConnectedToDB)
        {
            r_ConnectedToDB = i_ConnectedToDB;
            if (r_ConnectedToDB == true)
            {
                r_DBCollection = i_Collection;
            }
            else
            {
                r_CostumerBook = new Dictionary<string, CustomerCard>();
            }
        }

        public bool FindCustomer(string i_LicencsePlate, out CustomerCard res)
        {
            bool isExist = false;
            res = null;
            if (r_ConnectedToDB == false)
            {
                isExist = r_CostumerBook.TryGetValue(i_LicencsePlate, out res);
            }
            else
            {
                FilterDefinition<BsonDocument> DBFilter = Builders<BsonDocument>.Filter.Eq("_id", i_LicencsePlate);
                BsonDocument vehicleBsonDocument = r_DBCollection.Find<BsonDocument>(DBFilter).FirstOrDefault();
                if (vehicleBsonDocument != null)
                {
                    res = BsonSerializer.Deserialize<CustomerCard>(vehicleBsonDocument);
                    isExist = true;
                }
                else
                {
                    isExist = false;
                }
            }

            return isExist;
        }

        public void BlowVehicleWheels(CustomerCard i_Customer)
        {
            i_Customer.Vehicle.BlowWheelsToMax();
            if(r_ConnectedToDB == true)
            {
                UpdateDefinition<BsonDocument> updateToDo = Builders<BsonDocument>.Update.Set("Vehicle.Wheels", i_Customer.Vehicle.Wheels);
                UpdateCustomerInDB(i_Customer.Vehicle.LicesncePlate, updateToDo);
            }
        }

        public bool IsFuelEngine(CustomerCard i_Customer)
        {
            return i_Customer.Vehicle.EnergySource is FuelEnergySource;
        }

        public bool IsElectricEngine(CustomerCard i_Customer)
        {
            return i_Customer.Vehicle.EnergySource is ElectricEnergySource;
        }

        public void RefuelVehicle(CustomerCard i_Customer, float i_Amount, string i_TypeStr)
        {
            eFuelType fuelType;
            if (IsFuelType(i_TypeStr, out fuelType) == true)
            {
                FuelEnergySource fuelSource = i_Customer.Vehicle.EnergySource as FuelEnergySource;
                if (fuelSource.FuelType == fuelType)
                {
                    fuelSource.Load(i_Amount);
                    i_Customer.Vehicle.UpdateEnergyPercentageLeft();
                    if (r_ConnectedToDB == true)
                    {
                        addEnergyDBactions(i_Customer);
                    }
                }
                else
                {
                    throw new ArgumentException("Fuel type is not suitable to this vehicle");
                }
            }
        }

        private void addEnergyDBactions(CustomerCard i_Customer)
        {
            UpdateDefinition<BsonDocument> updateToDo = Builders<BsonDocument>.Update.Set("Vehicle.EnergySource.AmountOfEnergyLeft",i_Customer.Vehicle.EnergySource.CurrAmount).Set("Vehicle.PercentageOfEnergy", i_Customer.Vehicle.EnergyPercent);
            UpdateCustomerInDB(i_Customer.Vehicle.LicesncePlate, updateToDo);
        }

        public void RechargeVehicle(CustomerCard i_Cutomer, float i_Amount)
        {
            i_Cutomer.Vehicle.EnergySource.Load(i_Amount / 60);
            i_Cutomer.Vehicle.UpdateEnergyPercentageLeft();
            if (r_ConnectedToDB == true)
            {
                addEnergyDBactions(i_Cutomer);
            }
        }

        public void ChangeCustomerVehicleState(CustomerCard i_Customer, eVehicleState i_VehicleState)
        { 
            i_Customer.VehicleState = i_VehicleState;
            if(r_ConnectedToDB == true)
            {
                UpdateDefinition<BsonDocument> updateToDo = Builders<BsonDocument>.Update.Set("VehicleState", i_VehicleState.ToString());
                UpdateCustomerInDB(i_Customer.Vehicle.LicesncePlate, updateToDo);
            }
        }

        public void EnterVehicle(Vehicle i_Vehicle, string i_Name, string i_Phone)
        {  
            CustomerCard cutomerToAdd = new CustomerCard(i_Vehicle, i_Name, i_Phone);
            string key = cutomerToAdd.Vehicle.LicesncePlate;
            if (r_ConnectedToDB == true)
            {
                r_DBCollection.InsertOne(cutomerToAdd.ToBsonDocument());
            }
            else
            {
                r_CostumerBook.Add(key, cutomerToAdd);
            }
        }

        public List<CustomerCard> GetVehiclesByState(eVehicleState i_State)
        {
            List<CustomerCard> vehicles = new List<CustomerCard>();
            if (r_ConnectedToDB == false)
            {
                foreach (KeyValuePair<string, CustomerCard> currentCostumer in r_CostumerBook)
                {
                    if (i_State == eVehicleState.All)
                    {
                        vehicles.Add(currentCostumer.Value);
                    }
                    else
                    {
                        if (currentCostumer.Value.VehicleState == i_State)
                        {
                            vehicles.Add(currentCostumer.Value);
                        }
                    }
                }
            }
            else
            {
                vehicles = getVehiclesByStateFromDB(i_State);
            }

            return vehicles;
        }

        private List<CustomerCard> getVehiclesByStateFromDB(eVehicleState i_State)
        {
            FilterDefinition<BsonDocument> DBFilter;
            List<CustomerCard> vehiclesByState = new List<CustomerCard>();
            if (i_State == eVehicleState.All)
            {
                 DBFilter = Builders<BsonDocument>.Filter.Empty;
            }
            else
            {
                 DBFilter = Builders<BsonDocument>.Filter.Eq("VehicleState", i_State.ToString());
            }

            List<BsonDocument> vehiclesByStateDocument = r_DBCollection.Find<BsonDocument>(DBFilter).ToList();
            foreach (BsonDocument currVehicle in vehiclesByStateDocument)
            {
                vehiclesByState.Add(BsonSerializer.Deserialize<CustomerCard>(currVehicle));
            }

            return vehiclesByState;
        }

        public bool IsValidVehicleState(string i_VehicleState, out eVehicleState o_VehicleState)
        {
            bool isValid = true;
            o_VehicleState = eVehicleState.InRepair;

            if (Enum.IsDefined(typeof(eVehicleState), i_VehicleState) == false)
            {
                int choiceNumeric;
                if(int.TryParse(i_VehicleState, out choiceNumeric) == false)
                {
                    throw new FormatException("invalid state");
                }
                else
                {
                    if (isInStateTypeRange(choiceNumeric) == false)
                    {
                        throw new ValueOutOfRangeException(i_VehicleState, 1, 4);
                    }
                }
            }
            Enum.TryParse(i_VehicleState, out o_VehicleState);

            return isValid;
        }

        public bool IsFuelType(string i_TypeStr, out eFuelType o_FuelType)
        {
            bool isValid = true;
            o_FuelType = eFuelType.Octan95;

            if (Enum.IsDefined(typeof(eFuelType), i_TypeStr) == false)
            {
                int choiceNumeric;
                if (int.TryParse(i_TypeStr, out choiceNumeric) == false)
                {
                    throw new FormatException("invalid state");
                }
                else
                {
                    if (isInFuelTypeRange(choiceNumeric) == false)
                    {
                        throw new ValueOutOfRangeException(i_TypeStr, 1, 4);
                    }
                }
            }
            else
            {
                Enum.TryParse(i_TypeStr, out o_FuelType);
            }

            return isValid;
        }

        private bool isInFuelTypeRange(int i_TypeStr)
        {
            eFuelType lastFuelType = Enum.GetValues(typeof(eFuelType)).Cast<eFuelType>().Last();
            eFuelType firstFuelType = Enum.GetValues(typeof(eFuelType)).Cast<eFuelType>().Last();
            return (i_TypeStr >= (int)firstFuelType && i_TypeStr <= (int)lastFuelType);
        }

        private bool isInStateTypeRange(int i_VehicleState)
        {
            eVehicleState lastFuelType = Enum.GetValues(typeof(eVehicleState)).Cast<eVehicleState>().Last();
            eVehicleState firstFuelType = Enum.GetValues(typeof(eVehicleState)).Cast<eVehicleState>().First();
            return (i_VehicleState >= (int)firstFuelType && i_VehicleState <= (int)lastFuelType);
        }

        public string[] GetFuelTypes()
        {
            return FuelEnergySource.GetFuelTypes();
        }

        public bool IsFuelType(string i_Type)
        {
            return FuelEnergySource.IsFuelType(i_Type);
        }

        public List<string> GetStatusOptions()
        {
            List<string> statuses = new List<string>(4);
            foreach (string curr in Enum.GetNames(typeof(eVehicleState)))
            {
                statuses.Add(curr);
            }

            return statuses;
        }

        public void UpdateCustomerInDB(string i_LicensePlate, UpdateDefinition<BsonDocument> i_Update)
        {
            FilterDefinition<BsonDocument> DBFilter = Builders<BsonDocument>.Filter.Eq("_id", i_LicensePlate);
            BsonDocument vehicleBsonDocument = r_DBCollection.Find<BsonDocument>(DBFilter).FirstOrDefault();
            if (vehicleBsonDocument == null)
            {
                throw new ArgumentException($"Can not find Licende plate:{i_LicensePlate} in DB");
            }

            r_DBCollection.UpdateOne(DBFilter, i_Update);
        }
    }

    public enum eVehicleState
    {
        InRepair = 1,
        Repaired,
        Paid,
        All
    }
}
