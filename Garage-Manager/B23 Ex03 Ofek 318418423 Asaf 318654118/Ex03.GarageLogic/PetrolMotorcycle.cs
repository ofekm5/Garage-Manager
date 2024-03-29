﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public enum eLicenseType
    {
        A1, 
        A2, 
        AA, 
        B1
    }

    class PetrolMotorcycle : PetrolVehicle
    {
        private eLicenseType m_LicenseType;
        private int m_EngineVolumeInCC;
        private const int k_NumberOfWheels = 2;
        private const float k_MaxAirPressure = 31f;
        private const ePetrolType k_PetrolType = ePetrolType.Octan98;
        private const float k_MaxLiterInTank = 6.4f;

        public PetrolMotorcycle(eLicenseType i_LicenseType, int i_EngineVolumeInCC, string i_ModelName, string i_LicensePlateNumber, string i_WheelManufactureName,
            float i_CurrentAirPressure, string i_OwnerName, string i_OwnerPhone, float i_CurrentLiterInTank) : base(k_MaxLiterInTank, k_PetrolType, i_ModelName, i_LicensePlateNumber, k_NumberOfWheels,
                i_WheelManufactureName, i_CurrentAirPressure, k_MaxAirPressure, i_OwnerName, i_OwnerPhone, i_CurrentLiterInTank)
        {
            m_EngineVolumeInCC = i_EngineVolumeInCC;
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

        public static float GetMaxFuelInTank()
        {
            return k_MaxLiterInTank;
        }

        public static float GetMaxWheelPressure()
        {
            return k_MaxAirPressure;
        }

        public override string ToString()
        {
            string msg = base.ToString();

            msg += string.Format("License Type: {0}{1}", m_LicenseType, Environment.NewLine);
            msg += string.Format("Engine Volume[CC] In Tank: {0}{1}", m_EngineVolumeInCC, Environment.NewLine);

            return msg;
        }
    }
}
