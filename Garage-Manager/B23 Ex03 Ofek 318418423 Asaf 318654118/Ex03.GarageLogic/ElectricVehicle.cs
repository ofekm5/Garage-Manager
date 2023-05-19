using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class ElectricVehicle : Vehicle
    {
        protected float m_MaxAccumulatorTime;
        protected float m_CurrentAccumulatorTime;

        public ElectricVehicle(string i_ModelName, string i_LicensePlateNumber, int i_NumberOfWheels, string i_WheelManufactureName,
            float i_CurrentAirPressure, float i_MaxAirPressure, float i_MaxAcumulatorTime, float i_CurrentAccumulatorTime)
            :base(i_ModelName, i_LicensePlateNumber, i_NumberOfWheels, i_WheelManufactureName, i_CurrentAirPressure, i_MaxAirPressure)
        {
            m_MaxAccumulatorTime = i_MaxAcumulatorTime;
            m_CurrentAccumulatorTime = i_CurrentAccumulatorTime;
        }

        public float AccumulatorTimeLeft
        {
            get
            {
                return m_CurrentAccumulatorTime;
            }

            set
            {
                m_CurrentAccumulatorTime = value; //TODO: do i really need this set method?
            }
        }

        public float MaxAccumulatorTime
        {
            get
            {
                return m_MaxAccumulatorTime;
            }

        }

        public override void AddEnergy(float i_HoursToAdd)
        {
            if (m_MaxAccumulatorTime < i_HoursToAdd + m_CurrentAccumulatorTime || i_HoursToAdd < m_MinEnergyVal)
            {
                throw new ValueOutOfRangeException(m_MinEnergyVal, m_MaxAccumulatorTime - i_HoursToAdd);
            }
            else
            {
                m_CurrentAccumulatorTime += i_HoursToAdd;
                this.EnergyLeftPercentage = (m_CurrentAccumulatorTime / m_MaxAccumulatorTime) * 100f;
            }
        }

        public override float GetCurrentEnergyLeft()
        {
            return m_CurrentAccumulatorTime;
        }

        public override float GetMaxEnergy()
        {
            return m_MaxAccumulatorTime;
        }

    }
}
