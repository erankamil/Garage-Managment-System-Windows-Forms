using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private readonly Dictionary<string, CustomerCard> m_CostumerBook;

        public Garage()
        {
            m_CostumerBook = new Dictionary<string, CustomerCard>();
        }

        public bool FindCustomer(string i_LicencsePlate)
        {
            bool isExist = false;
            foreach (KeyValuePair<string, CustomerCard> currentCostumer in m_CostumerBook)
            {
                if (currentCostumer.Value.Vehicle.LicesncePlate == i_LicencsePlate)
                {
                    isExist = true;
                }
            }
            return isExist;
        }
    }
}
