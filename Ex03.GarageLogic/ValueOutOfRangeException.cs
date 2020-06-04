using System;

namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        private float m_MaxValue;
        private float m_MinValue;

        public ValueOutOfRangeException(string i_Value,float i_MinValue,float i_MaxValue) : base(string.Format(
            "The {0} is out of range! Minimum is {1} , Maximum is {2}", i_Value, i_MinValue, i_MaxValue))
        {
            m_MaxValue = i_MaxValue;
            m_MinValue = i_MinValue;
        }
    }
}
