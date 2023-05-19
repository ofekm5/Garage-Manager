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

        public Truck(bool i_ContainHazardMaterials, float i_LoadCapacity, float i_MaxTankInLiter, ePetrolType i_PetrolType, string i_ModelName, string i_LicensePlateNumber, int i_NumberOfWheels, string i_WheelManufactureName,
            float i_CurrentAirPressure, float i_MaxAirPressure) : base(i_MaxTankInLiter, i_PetrolType, i_ModelName, i_LicensePlateNumber, i_NumberOfWheels, i_WheelManufactureName,
            i_CurrentAirPressure, i_MaxAirPressure)
        {
            this.m_ContainHazardMaterials = i_ContainHazardMaterials;
            this.m_LoadCapacity = i_LoadCapacity;
        }
    }
}