using System;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Ex03.GarageLogic
{
    public class CustomerCard
    {
        private string m_Name;
        private string m_Phone;
        private eVehicleState m_VehicleState;
        private Vehicle m_Vehicle;
        private string r_Id;


        public CustomerCard(Vehicle i_Vehicle, string i_Name, string i_Phone)
        {
            m_Vehicle = i_Vehicle;
            m_Name = i_Name;
            m_Phone = i_Phone;
            r_Id = i_Vehicle.LicesncePlate;
            m_VehicleState = eVehicleState.InRepair;
        }
        public CustomerCard()
        {
        }

        public CustomerCard(Vehicle i_Vehicle)
        {
            m_Vehicle = i_Vehicle;
            m_VehicleState = eVehicleState.InRepair;
        }

        public Vehicle Vehicle
        {
            get
            {
                return m_Vehicle;
            }
            set
            {
                m_Vehicle = value;
            }
        }

        public string Name
        {
            get
            {
                return m_Name;
            }

            set
            {
                m_Name = value;
            }
        }


        public eVehicleState VehicleState
        {
            get
            {
                return m_VehicleState;
            }

            set
            {
                m_VehicleState = value;
            }
        }
        public void RegisterClass()
        {
            VehicleCreator.RegisterVehicles();

            if (!BsonClassMap.IsClassMapRegistered(typeof(CustomerCard)))
            {
                BsonClassMap.RegisterClassMap<CustomerCard>(cm =>
                {
                    cm.SetIdMember(cm.MapField(c => c.r_Id).SetElementName("CustomerID"));
                    cm.MapField(c => c.m_Name).SetElementName("CustomerName");
                    cm.MapField(c => c.m_Phone).SetElementName("CustomerPhone");
                    cm.MapField(c => c.m_Vehicle).SetElementName("Vehicle");
                    cm.MapField(c => c.m_VehicleState).SetElementName("VehicleState").SetSerializer(new EnumSerializer<eVehicleState>(BsonType.String));
                });
            }
        }
    }
}
