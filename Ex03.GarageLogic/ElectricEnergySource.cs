using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Bson;

namespace Ex03.GarageLogic
{
    internal class ElectricEnergySource : EnergySource
    {
        internal override void RegisterClass()
        {
            base.RegisterClass();
            if (!BsonClassMap.IsClassMapRegistered(typeof(ElectricEnergySource)))
            {
                BsonClassMap.RegisterClassMap<ElectricEnergySource>();
            }
        }
    }
}
