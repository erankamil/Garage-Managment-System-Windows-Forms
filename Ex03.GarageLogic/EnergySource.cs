using System;

namespace Ex03.GarageLogic
{
    public abstract class EnergySource
    {
        private float m_CurrentAmount;
        private float m_MaxAmount;
        private eEnergyType m_Type;

        public virtual void Load(float i_Amount)
        {
            if (m_CurrentAmount + i_Amount <= m_MaxAmount)
            {
                m_CurrentAmount += i_Amount;
            }
            else
            {
                throw new ValueOutOfRangeException(i_Amount.ToString(), 0,
                    m_MaxAmount - m_CurrentAmount);
            }
        }

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
    }
    public enum eEnergyType
    {
        Electric = 1,
        Fuel = 2
    }
}
