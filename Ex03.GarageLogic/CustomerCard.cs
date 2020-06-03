
namespace Ex03.GarageLogic
{
    public class CustomerCard
    {
        private string m_Name;
        private string m_Phone;
        private eCarState m_CarState;
        private Vehicle m_Vehicle;

        public enum eCarState
        {
            inRepair = 1,
            repaired,
            paid
        }

        public Vehicle Vehicle
        {
            get
            {
                return m_Vehicle;
            }
        }
    }

}
