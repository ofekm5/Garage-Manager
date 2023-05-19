using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    class ElectricMotorcycle : ElectricVehicle
    {
        private eLicenseType m_LicenseType;
        public ElectricMotorcycle(string i_ModelName, string i_LicensePlateNumber, int i_NumberOfWheels, string i_WheelManufactureName,
            float i_CurrentAirPressure, float i_MaxAirPressure, float i_MaxAcumulatorTime, float i_CurrentAccumulatorTime, eLicenseType i_LicenseType)
            : base(i_ModelName, i_LicensePlateNumber, i_NumberOfWheels, i_WheelManufactureName, i_CurrentAirPressure, i_MaxAirPressure,
                  i_MaxAcumulatorTime, i_CurrentAccumulatorTime)
        {
            m_LicenseType = i_LicenseType;
        }

        public eLicenseType LicenseType
        {
            get
            {
                return m_LicenseType;
            }
        }

        public override string ToString()
        {
            string msg = base.ToString();
            msg += string.Format("License type: {0}{1}", m_LicenseType, Environment.NewLine);
            return msg;
        }

    }
}
