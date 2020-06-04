using System;

namespace Ex03.GarageLogic
{
    public class EnergySource
    {
        private float m_CurrentAmount;
        private float m_MaxAmount;
        private eEnergyType m_Type;

        //public EnergySource(float i_CurrentAmount, float i_MaxAmount)
        //{
        //    m_CurrentAmount = i_CurrentAmount;
        //    m_MaxAmount = i_MaxAmount;
        //}

        //public EnergySource(EnergySource i_EnergySource)
        //{
        //    m_CurrentAmount = i_EnergySource.m_CurrentAmount;
        //    m_MaxAmount = i_EnergySource.m_MaxAmount;
        //}

        public bool Load(float i_Amount)
        {

            bool isValid = true;
            if (m_CurrentAmount + i_Amount < m_MaxAmount)
            {
                m_CurrentAmount += i_Amount;
            }
            else
            {
                isValid = false;
            }
            return isValid;
        }


        //public EnergySource Initialize(int i_FuelType)
        //{
        //    EnergySource EnergySourceType;
        //    Type type = this.GetType();
        //    if (type.Equals(typeof(ElectricEnergySource)))
        //    {
        //        EnergySourceType = new ElectricEnergySource(this);
        //        m_EnergySourceType.Type = EnergySource.eType.electric;
        //    }
        //    else
        //    {
        //        EnergySourceType = new FuelEnergySource(this, i_FuelType);
        //        m_EnergySourceType.Type = EnergySource.eType.fuel;
        //    }
        //}


        public float CurrAmount
        {
            get
            {
                return m_CurrentAmount;
            }
            set
            {
                m_CurrentAmount = value;
            }
        }

        public float MaxAmount
        {
            get
            {
                return m_MaxAmount;
            }
            set
            {
                m_MaxAmount = value;
            }
        }

        public eEnergyType Type
        {
            get
            {
                return m_Type;
            }

            set
            {
                m_Type = value;
            }
        }

        public enum eEnergyType
        {
            electric = 1,
            fuel = 2
        }
    }
}
