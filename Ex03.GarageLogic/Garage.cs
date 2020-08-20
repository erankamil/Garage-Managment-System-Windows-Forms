using System.Collections.Generic;
using System;
using System.Text;
using System.Reflection;
using MongoDB.Driver;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;

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
            eFuelType eType = FromStringToVehicleFuelTypeEnum(i_TypeStr);
            FuelEnergySource fuelSource = i_Customer.Vehicle.EnergySource as FuelEnergySource;
            if (fuelSource.FuelType == eType)
            {
                fuelSource.Load(i_Amount);
                i_Customer.Vehicle.UpdateEnergyPercentageLeft();
                if(r_ConnectedToDB == true)
                {
                    addEnergyDBactions(i_Customer);
                }
            }
            else
            {
                throw new ArgumentException("Fuel type is not suitable to this vehicle");
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

        public bool IsValidVehicleState(string i_VehicleState, out eVehicleState io_VehicleState)
        {
            bool isValid = true;

            if (Enum.TryParse(i_VehicleState, out io_VehicleState) == false)
            {
                int choiceNumeric;
                if(int.TryParse(i_VehicleState, out choiceNumeric) == false)
                {
                    throw new FormatException("invalid state");
                }
                else
                {
                    throw new ValueOutOfRangeException(i_VehicleState, 1, 4);
                }
            }

            return isValid;
        }

        public eFuelType FromStringToVehicleFuelTypeEnum(string i_TypeStr)
        {
            eFuelType eType;
            switch (i_TypeStr)
            {
                case "Octan95":
                    eType = eFuelType.Octan95;
                    break;
                case "Octan96":
                    eType = eFuelType.Octan96;
                    break;
                case "Octan98":
                    eType = eFuelType.Octan98;
                    break;
                case "Soler":
                    eType = eFuelType.Soler;
                    break;
                default:
                    int type;
                    if (int.TryParse(i_TypeStr, out type) == false)
                    {
                        throw new FormatException("invalid fuel type");
                    }
                    else
                    {
                        throw new ValueOutOfRangeException(i_TypeStr, 1, 4);
                    }
            }
            return eType;
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


    //public static Garage Instance { get { return Singleton<Garage>.Instance; } }

    //public static class Singleton<T> where T : class
    //{
    //    private static T s_Instance;

    //    private static object s_LockObj = new object();

    //    static Singleton()
    //    {
    //    }

    //    public static T Instance
    //    {
    //        get
    //        {
    //            if (s_Instance == null)
    //            {
    //                lock (s_LockObj)
    //                {
    //                    if (s_Instance == null)
    //                    {
    //                        Type typeOfT = s_Instance.GetType();
    //                        foreach (MethodInfo method in typeOfT.GetMethods())
    //                        {
    //                            if (method.Name == typeOfT.Name && method.IsPrivate && method.GetParameters().Length == 0)
    //                            {
    //                                s_Instance = (T)method.Invoke(null, null);
    //                                break;
    //                            }
    //                        }
    //                    }
    //                }
    //            }

    //            return s_Instance;
    //        }
    //    }

    //}

    public enum eVehicleState
    {
        InRepair = 1,
        Repaired,
        Paid,
        All
    }
}
