using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public enum eVehicleCondition
    {
        InMaintenance,
        Fixed,
        PayedFor
    }

    public class Customer
    {
        private string m_OwnerName;
        private eVehicleCondition m_VehicleCondition;
        private string m_OwnerPhone;

        public Customer(string i_OwnerName, string i_OwnerPhone)
        {
            m_VehicleCondition = eVehicleCondition.InMaintenance;
            m_OwnerName = i_OwnerName;
            m_OwnerPhone = i_OwnerPhone;
        }

        public string OwnerName
        {
            get
            {
                return m_OwnerName;
            }
        }

        public eVehicleCondition VehicleCondition
        {
            get
            {
                return m_VehicleCondition;
            }
            set
            {
                m_VehicleCondition = value;
            }
        }

        public string OwnerPhone
        {
            get
            {
                return m_OwnerPhone;
            }
        }
    }
}
