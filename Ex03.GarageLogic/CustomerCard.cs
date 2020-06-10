namespace Ex03.GarageLogic
{
    public class CustomerCard
    {
        private string m_Name;
        private string m_Phone;
        private eCarState m_CarState;
        private Vehicle m_Vehicle;

        public CustomerCard(Vehicle i_Vehicle, string i_Name, string i_Phone)
        {
            m_Vehicle = i_Vehicle;
            m_Name = i_Name;
            m_Phone = i_Phone;
            m_CarState = eCarState.InRepair;
        }

        public Vehicle Vehicle
        {
            get
            {
                return m_Vehicle;
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

        public eCarState CarState
        {
            get
            {
                return m_CarState;
            }

            set
            {
                m_CarState = value;
            }
        }
    }
}
