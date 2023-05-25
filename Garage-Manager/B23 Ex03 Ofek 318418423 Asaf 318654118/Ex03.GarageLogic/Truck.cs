using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    class Truck : PetrolVehicle
    {
        private bool m_ContainHazardMaterials;
        private float m_LoadCapacity;
        private const int k_NumberOfWheels = 14;
        private const float k_MaxAirPressure = 26;
        private const ePetrolType k_PetrolType = ePetrolType.Soler;
        private const float k_MaxLiterInTank = 135f;

        public Truck(bool i_ContainHazardMaterials, float i_LoadCapacity, string i_ModelName, string i_LicensePlateNumber, string i_WheelManufactureName,
            float i_CurrentAirPressure, string i_OwnerName, string i_OwnerPhone, float i_CurrentLiterInTank) : base(k_MaxLiterInTank, k_PetrolType, i_ModelName, i_LicensePlateNumber, k_NumberOfWheels, i_WheelManufactureName,
            i_CurrentAirPressure, k_MaxAirPressure, i_OwnerName, i_OwnerPhone, i_CurrentLiterInTank)
        {
            this.m_ContainHazardMaterials = i_ContainHazardMaterials;
            this.m_LoadCapacity = i_LoadCapacity;
        }

        public static float GetMaxAirPressure()
        {
            return k_MaxAirPressure;
        }

        public static float GetMaxFuel()
        {
            return k_MaxLiterInTank;
        }

        public override string ToString()
        {
            string msg = base.ToString();

            msg += string.Format("Contain Hazard Materials: {0}{1}", m_ContainHazardMaterials, Environment.NewLine);
            msg += string.Format("Load Capacity: {0}{1}", m_LoadCapacity, Environment.NewLine);

            return msg;
        }
    }
}