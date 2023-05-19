using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        protected const float m_MinEnergyVal = 0.0f;
        protected string m_ModelName;
        protected string m_LicenseplateNumber;
        protected float m_EnergyLeftPercentage;
        protected List<Wheel> m_Wheels;

        public Vehicle(string i_ModelName, string i_LicensePlateNumber, int i_NumberOfWheels)
        {
            m_ModelName = i_ModelName;
            m_LicenseplateNumber = i_LicensePlateNumber;
            
        }
    }
}
