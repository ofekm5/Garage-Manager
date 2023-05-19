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

        public Truck(bool i_ContainHazardMaterials, float i_LoadCapacity) : base()
        {
            this.m_ContainHazardMaterials = i_ContainHazardMaterials;
            this.m_LoadCapacity = i_LoadCapacity;
        }
    }
}