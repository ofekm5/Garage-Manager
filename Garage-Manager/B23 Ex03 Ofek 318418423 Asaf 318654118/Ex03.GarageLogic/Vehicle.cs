using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        protected const float m_MinEnergyVal = 0f;
        protected string m_ModelName;
        protected string m_LicenseplateNumber;
        protected float m_EnergyLeftPercentage;
        protected int m_NumberOfWheels;
        protected Wheel[] m_Wheels;
        protected Customer m_Customer;

        public Vehicle(string i_ModelName, string i_LicensePlateNumber, int i_NumberOfWheels, string i_WheelManufactureName,
            float i_CurrentAirPressure, float i_MaxAirPressure, string i_OwnerName, string i_OwnerPhone)
        {
            m_ModelName = i_ModelName;
            m_LicenseplateNumber = i_LicensePlateNumber;
            m_NumberOfWheels = i_NumberOfWheels;
            m_Wheels = new Wheel[i_NumberOfWheels];
            for (int i = 0; i < m_NumberOfWheels; i++)
            {
                m_Wheels[i] = new Wheel(i_WheelManufactureName, i_CurrentAirPressure, i_MaxAirPressure);
            }
            m_Customer = new Customer(i_OwnerName, i_OwnerPhone);
        }

        public float EnergyLeftPercentage
        {
            get
            {
                return m_EnergyLeftPercentage;
            }
            set
            {
                m_EnergyLeftPercentage = value;
            }
        }

        public void CalculateEnergyPercentageLeft(float i_MaxEnergy, float i_CurrentEnergyLeft)
        {
            m_EnergyLeftPercentage = (i_CurrentEnergyLeft / i_MaxEnergy) * 100f;
        }

        public Wheel[] AllWheels
        {
            get
            {
                return m_Wheels;
            }
        }

        public Customer CustomerOfVehicle
        {
            get
            {
                return m_Customer;
            }
        }

        public abstract void AddEnergy(float i_AmountToFill);

        public abstract float GetMaxEnergy();

        public abstract float GetCurrentEnergyLeft();

        public override string ToString()
        {
            int i = 0;
            string msg = string.Format("model name: {0}.{1}", m_ModelName, Environment.NewLine);

            msg += string.Format("license number: {0}{1}", m_LicenseplateNumber, Environment.NewLine);
            msg += string.Format("number of wheels: {0}{1}", m_NumberOfWheels, Environment.NewLine);
            msg += m_Customer.ToString();
            foreach (Wheel wheel in m_Wheels)
            {
                msg += string.Format("Wheel #{0}{1}", i.ToString(), Environment.NewLine);
                msg += wheel.ToString();
                i++;
            }

            msg += string.Format("{0}", Environment.NewLine);
            return msg;
        }

        public eVehicleCondition CustomerVehicleCondition
        {
            get
            {
                return m_Customer.VehicleCondition;
            }
            set
            {
                m_Customer.VehicleCondition = value;
            }
        } 
    }
}
