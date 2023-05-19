using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class ElectricVehicle : Vehicle
    {
        protected float m_MaxAccululatorTime;
        protected float m_CurrentAccululatorTime;

        public ElectricVehicle(string i_ModelName, string i_LicensePlateNumber, int i_NumberOfWheels, string i_WheelManufactureName,
            float i_CurrentAirPressure, float i_MaxAirPressure, float i_MaxAcuumulatorTime, float i_CurrentAccumulatorTime)
            :base(i_ModelName, i_LicensePlateNumber, i_NumberOfWheels, i_WheelManufactureName, i_CurrentAirPressure, i_MaxAirPressure)
        {
            m_MaxAccululatorTime = i_MaxAcuumulatorTime;
            m_CurrentAccululatorTime = i_CurrentAccumulatorTime;
        }

        public float AccumulatorTimeLeft
        {
            get
            {
                return m_CurrentAccululatorTime;
            }

            set
            {
                m_CurrentAccululatorTime = value; //TODO: do i really need this set method?
            }
        }

        public float MaxAccumulatorTime
        {
            get
            {
                return m_MaxAccululatorTime;
            }

        }

        public override void AddEnergy(float i_HoursToAdd)
        {
            //if(m_MaxAccululatorTime < i_HoursToAdd + m_CurrentAccululatorTime || i_HoursToAdd < m_MinEnergyVal)
            //{
            //    throw new ValueOutOfRangeException(m_MinEnergyVal, m_MaxAccululatorTime - i_HoursToAdd);
            //}
            //else
            //{
            //    m_CurrentAccululatorTime += i_HoursToAdd;
            //}
        }

        public override float GetCurrentEnergyLeft()
        {
            return m_CurrentAccululatorTime;
        }

        public override float GetMaxEnergy()
        {
            return m_MaxAccululatorTime;
        }

    }
}
