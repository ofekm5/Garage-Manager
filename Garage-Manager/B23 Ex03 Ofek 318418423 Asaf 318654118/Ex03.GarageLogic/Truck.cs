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
        private const int numberOfWheels = 14;
        private const float maxAirPressure = 26;
        private const ePetrolType k_PetrolType = ePetrolType.Soler;
        private const float k_MaxLiterInTank = 135f;

        public Truck(bool i_ContainHazardMaterials, float i_LoadCapacity, string i_ModelName, string i_LicensePlateNumber, string i_WheelManufactureName,
            float i_CurrentAirPressure, string i_OwnerName, string i_OwnerPhone, float i_CurrentLiterInTank) : base(k_MaxLiterInTank, k_PetrolType, i_ModelName, i_LicensePlateNumber, numberOfWheels, i_WheelManufactureName,
            i_CurrentAirPressure, maxAirPressure, i_OwnerName, i_OwnerPhone, i_CurrentLiterInTank)
        {
            this.m_ContainHazardMaterials = i_ContainHazardMaterials;
            this.m_LoadCapacity = i_LoadCapacity;
        }

        public override string ToString()
        {
            string msg = base.ToString();

            msg += string.Format("Contain Hazard Materials: {0}{1}", m_ContainHazardMaterials, Environment.NewLine);
            msg += string.Format("Load Capacity is {0}{1}", m_LoadCapacity, Environment.NewLine);

            return msg;
        }
    }
}