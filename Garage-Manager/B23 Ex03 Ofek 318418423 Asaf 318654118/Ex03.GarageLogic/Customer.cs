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
        private const int k_MaxDigitsInPhoneNumber = 10;
        private const int k_MinDigitsInPhoneNumber = 0;

        public Customer(string i_OwnerName, string i_OwnerPhone)
        {
            m_VehicleCondition = eVehicleCondition.InMaintenance;
            m_OwnerName = i_OwnerName;
            m_OwnerPhone = i_OwnerPhone;

            if (m_OwnerPhone.Length <= 10)
            {
                foreach (char c in m_OwnerPhone)
                {
                    if (!char.IsDigit(c))
                    {
                        throw new FormatException("Invalid phone number! it should contain digits only");
                    }
                }
            }
            else
            {
                throw new ValueOutOfRangeException(k_MinDigitsInPhoneNumber, k_MaxDigitsInPhoneNumber);
            }
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

        public override string ToString()
        {
            string msg = string.Format("Owner name: {0}{1}Owner phone: {2}{3}Vehicle state in garage: {4}{5}", m_OwnerName,
                Environment.NewLine, m_OwnerPhone, Environment.NewLine, m_VehicleCondition, Environment.NewLine);
            return msg;
        }
    }
}
