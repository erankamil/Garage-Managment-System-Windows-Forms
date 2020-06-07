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

        public bool FindCustomer(string i_LicencsePlate, out CustomerCard res)
        {
            bool isExist = false;
            res = null;
            foreach (KeyValuePair<string, CustomerCard> currentCostumer in m_CostumerBook)
            {
                if (currentCostumer.Value.Vehicle.LicesncePlate == i_LicencsePlate)
                {
                    isExist = true;
                    res = currentCostumer.Value;
                }
            }
            return isExist;
        }

        public void ChangeCustomerVehicleState(CustomerCard i_Cutomer)
        {
            i_Cutomer.CarState = eCarState.inRepair;
        }

        public void EnterVehicle(Vehicle i_Vehicle, string i_Name, string i_Phone)
        {
            CustomerCard cutomerToAdd = new CustomerCard(i_Vehicle, i_Name, i_Phone);
            string key = cutomerToAdd.Vehicle.LicesncePlate;
            m_CostumerBook.Add(key, cutomerToAdd);
        }
    }
}
