using System;
using System.Collections.Generic;

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

        public override List<string> GetInfo()
        {
            List<string> infoStrs = base.GetInfo();
            infoStrs.Add(@"Truck has Hazardous materials:
1) Yes
2) No");
            infoStrs.Add("Cargo Volume");
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
                        case (int)eTrunkInfo.Hazardousmaterials:
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
                if (res >= (int)eHasHazardousmaterials.Yes && res <= (int)eHasHazardousmaterials.No)
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
                    throw new ValueOutOfRangeException(i_CargoVolme, (int)eHasHazardousmaterials.Yes,
                        (int)eHasHazardousmaterials.No);
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
        Hazardousmaterials = 4,
        CargoVolume
    }

    public enum eHasHazardousmaterials
    {
        Yes = 1,
        No
    }

}
