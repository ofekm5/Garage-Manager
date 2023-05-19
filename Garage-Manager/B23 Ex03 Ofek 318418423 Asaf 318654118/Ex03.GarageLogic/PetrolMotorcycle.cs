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

        public PetrolMotorcycle(eLicenseType i_LicenseType, int i_EngineVolumeInCC, float i_MaxTankInLiter, ePetrolType i_PetrolType, string i_ModelName, string i_LicensePlateNumber, int i_NumberOfWheels, string i_WheelManufactureName,
            float i_CurrentAirPressure, float i_MaxAirPressure) : base(i_MaxTankInLiter, i_PetrolType, i_ModelName, i_LicensePlateNumber, i_NumberOfWheels,
                i_WheelManufactureName, i_CurrentAirPressure, i_MaxAirPressure)
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
    }
}