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
            float i_CurrentAirPressure, float i_MaxAirPressure, float i_MaxAccumulatorTime, float i_CurrentAccumulatorTime, string i_OwnerName, string i_OwnerPhone)
            :base(i_ModelName, i_LicensePlateNumber, i_NumberOfWheels, i_WheelManufactureName, i_CurrentAirPressure, i_MaxAirPressure, i_OwnerName, i_OwnerPhone)
        {
            m_MaxAccumulatorTime = i_MaxAccumulatorTime;
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
                m_CurrentAccumulatorTime = value;
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
            if (i_HoursToAdd < k_MinEnergyVal)
            {
                throw new ValueOutOfRangeException(k_MinEnergyVal, m_MaxAccumulatorTime - m_CurrentAccumulatorTime);
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

        public static bool ValidateMaxAccumulatorTime(float i_CurrAccumulatorTime, float i_MaxAccumulatorTime)
        {
            return i_MaxAccumulatorTime > i_CurrAccumulatorTime;
        }

        public static bool ValidateWheelPressure(float i_CurrWheelPressure, float i_MaxWheelPressure)
        {
            return i_MaxWheelPressure > i_CurrWheelPressure;
        }

        public override string ToString()
        {
            string msg = base.ToString();
            msg += string.Format("Max accumulator time: {0}{1}", m_MaxAccumulatorTime, Environment.NewLine);
            msg += string.Format("Current accumulator time: {0}{1}", m_CurrentAccumulatorTime, Environment.NewLine);
            return msg;
        }

    }
}
