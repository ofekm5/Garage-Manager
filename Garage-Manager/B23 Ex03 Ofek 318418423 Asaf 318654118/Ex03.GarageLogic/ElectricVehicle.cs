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

        public ElectricVehicle(string i_ModelName, string i_LicensePlateNumber, int i_NumberOfWheels) :base()
        {

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

        public void ChargeAccumulator(float i_HoursToAdd)
        {
            if(m_MaxAccululatorTime < i_HoursToAdd + m_CurrentAccululatorTime || i_HoursToAdd < m_MinEnergyVal)
            {
                throw new ValueOutOfRangeException(m_MinEnergyVal, m_MaxAccululatorTime - i_HoursToAdd);
            }
            else
            {
                m_CurrentAccululatorTime += i_HoursToAdd;
            }
        }

    }
}
