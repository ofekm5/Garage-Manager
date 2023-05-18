using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    abstract class ElectricVehicle : Vehicle
    {
        private float m_MaxAccululatorTime;
        private float m_CurrentAccululatorTime;

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

        }

    }
}
