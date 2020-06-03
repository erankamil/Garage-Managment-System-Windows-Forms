using System;

namespace Ex03.GarageLogic
{
    public class EnergySource
    {
        private float m_CurrentScale;
        private float m_MaxScale;
        private eEnergyType m_Type;

        //public EnergySource(float i_CurrentScale, float i_MaxScale)
        //{
        //    m_CurrentScale = i_CurrentScale;
        //    m_MaxScale = i_MaxScale;
        //}

        //public EnergySource(EnergySource i_EnergySource)
        //{
        //    m_CurrentScale = i_EnergySource.m_CurrentScale;
        //    m_MaxScale = i_EnergySource.m_MaxScale;
        //}

        public bool Load(float i_Amount)
        {

            bool isValid = true;
            if (m_CurrentScale + i_Amount < m_MaxScale)
            {
                m_CurrentScale += i_Amount;
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


        public float CurrScale
        {
            get
            {
                return m_CurrentScale;
            }
            set
            {
                m_CurrentScale = value;
            }
        }

        public float MaxScale
        {
            get
            {
                return m_MaxScale;
            }
            set
            {
                m_MaxScale = value;
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
