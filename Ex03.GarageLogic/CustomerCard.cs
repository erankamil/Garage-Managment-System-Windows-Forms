
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
            m_CarState = eCarState.inRepair;
        }

        public Vehicle Vehicle
        {
            get
            {
                return m_Vehicle;
            }
        }
    }
    public enum eCarState
    {
        inRepair = 1,
        repaired,
        paid
    }

}
