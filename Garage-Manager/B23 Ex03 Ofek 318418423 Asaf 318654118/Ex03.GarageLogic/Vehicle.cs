using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public enum eEnergyType
    {
        Petrol,
        Electric
    }
    public abstract class Vehicle
    {
        protected const float m_MinEnergyVal = 0f;
        protected string m_ModelName;
        protected string m_LicenseplateNumber;
        protected float m_EnergyLeftPercentage;
        protected int m_NumberOfWheels;
        protected Wheel[] m_Wheels;

        public Vehicle(string i_ModelName, string i_LicensePlateNumber, int i_NumberOfWheels, string i_WheelManufactureName,
            float i_CurrentAirPressure, float i_MaxAirPressure)
        {
            m_ModelName = i_ModelName;
            m_LicenseplateNumber = i_LicensePlateNumber;
            m_NumberOfWheels = i_NumberOfWheels;
            m_Wheels = new Wheel[i_NumberOfWheels];
            for (int i = 0; i < m_NumberOfWheels; i++)
            {
                m_Wheels[i] = new Wheel(i_WheelManufactureName, i_CurrentAirPressure, i_MaxAirPressure);
            }
        }

        public float EnergyLeftPercentage
        {
            get
            {
                return m_EnergyLeftPercentage;
            }
        }

        public void CalculateEnergyPercentageLeft(float i_MaxEnergy, float i_CurrentEnergyLeft)
        {
            m_EnergyLeftPercentage = (i_CurrentEnergyLeft / i_MaxEnergy) * 100f;
        }

        public abstract void AddEnergy(float i_AmountToFill, eEnergyType i_EnergyType);

        public abstract float GetMaxEnergy();

        public abstract float GetCurrentEnergyLeft();
    }
}
