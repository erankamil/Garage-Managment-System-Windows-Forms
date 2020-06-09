using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex03.GarageLogic
{
    internal class Trunk : Vehicle
    {
        private float m_CargoVolume;
        private bool m_HasHazardousmaterials;
        private const float k_MaxWheelAirPressure = 28f;
        private const float k_FuelMaxTank = 120f;

        public Trunk(string i_LicencePlate) : base(i_LicencePlate, eEnergyType.Fuel)
        {
            base.InitializeWheels(k_MaxWheelAirPressure, eVehicleWheels.Truck);
            base.EnergySource.MaxAmount = k_FuelMaxTank;
            (base.EnergySource as FuelEnergySource).FuelType = eFuelType.Soler;
        }

        public float CargoVolume
        {
            get
            {
                return m_CargoVolume;
            }
        }

        public bool HasHazardousmaterials
        {
            get
            {
                return m_HasHazardousmaterials;
            }
        }

        public override List<string> GetDetails()
        {
            List<string> detailsStrs = base.GetDetails();
            detailsStrs.Add("Cargo volume " + m_CargoVolume.ToString());
            detailsStrs.Add("Has hazardous materials " + m_HasHazardousmaterials.ToString());
            return detailsStrs;
        }

        public override List<string> GetDataNames()
        {
            List<string> infoStrs = base.GetDataNames();
            infoStrs.Add(@"Truck has Hazardous materials:
1) Yes
2) No");
            infoStrs.Add("Cargo Volume:");
            return infoStrs;
        }

        public override void UpdateInfo(string i_Value, int i_Index)
        {
            if (i_Index < base.NumOfPropeties)
            {
                base.UpdateInfo(i_Value, i_Index);
            }
            else
            {
                if (string.IsNullOrEmpty(i_Value) || string.IsNullOrWhiteSpace(i_Value))
                {
                    throw new ArgumentException();
                }
                else
                {
                    switch (i_Index)
                    {
                        case (int)eTrunkInfo.CargoVolume:
                            UpdateCargoVolume(i_Value);
                            break;
                        case (int)eTrunkInfo.HazardousMaterials:
                            UpdateHazardousmaterials(i_Value);
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        public void UpdateHazardousmaterials(string i_CargoVolme)
        {
            if (float.TryParse(i_CargoVolme, out float res))
            {
                var first = Enum.GetValues(typeof(eHasHazardousmaterials)).Cast<eHasHazardousmaterials>().First();
                var last = Enum.GetValues(typeof(eHasHazardousmaterials)).Cast<eHasHazardousmaterials>().Last();

                if (res >= (int)first && res <= (int)last)
                {
                    switch (res)
                    {
                        case (int)eHasHazardousmaterials.Yes:
                            m_HasHazardousmaterials = true;
                            break;
                        default:
                            m_HasHazardousmaterials = false;
                            break;
                    }
                }
                else
                {
                    throw new ValueOutOfRangeException(i_CargoVolme, (int)first, (int)last);
                }
            }
            else
            {
                throw new FormatException("Invalid Input");
            }

        }

        public void UpdateCargoVolume(string i_CargoVolme)
        {
            if (float.TryParse(i_CargoVolme, out float res))
            {
                if (res > 0)
                {
                    m_CargoVolume = res;
                }
                else
                {
                    throw new ArgumentException("Cargo Volume must be non negative number");
                }
            }
            else
            {
                throw new FormatException("Invalid Input, Cargo Volume must be non negative number");
            }
        }
    }

    public enum eTrunkInfo
    {
        HazardousMaterials = 4,
        CargoVolume
    }

    public enum eHasHazardousmaterials
    {
        Yes = 1,
        No
    }

}
