using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    class ElectricMotorcycle : ElectricVehicle
    {
        private eLicenseType m_LicenseType;
        private int m_EngineVolumeInCC;
        private const int k_NumberOfWheels = 2;
        private const float k_MaxAirPressure = 31f;
        private const float k_MaxAcumulatorTime = 2.6f;

        public ElectricMotorcycle(string i_ModelName, string i_LicensePlateNumber, string i_WheelManufactureName,
            float i_CurrentAirPressure, float i_CurrentAccumulatorTime, eLicenseType i_LicenseType, string i_OwnerName, string i_OwnerPhone)
            : base(i_ModelName, i_LicensePlateNumber, k_NumberOfWheels, i_WheelManufactureName, i_CurrentAirPressure, i_MaxAirPressure,
                  k_MaxAcumulatorTime, i_CurrentAccumulatorTime, i_OwnerName, i_OwnerPhone)
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

        public int EngineVolumeInCC
        {
            get
            {
                return m_EngineVolumeInCC;
            }
        }

        public override string ToString()
        {
            string msg = base.ToString();
            msg += string.Format("License type: {0}{1}", m_LicenseType, Environment.NewLine);
            msg += string.Format("Engine volume in CC: {0}{1}", m_EngineVolumeInCC, Environment.NewLine);
            return msg;
        }

    }
}
