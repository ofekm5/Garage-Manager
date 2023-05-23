using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private string m_ManufactureName;
        private float m_CurrentAirPressure;
        private float m_MaxAirPressure;

        public Wheel(string i_ManufactureName, float i_CurrentAirPressure, float i_MaxAirPressure)
        {
            m_ManufactureName = i_ManufactureName;
            m_CurrentAirPressure = i_CurrentAirPressure;
            m_MaxAirPressure = i_MaxAirPressure;
        }

        public string ManufactureName
        {
            get
            {
                return m_ManufactureName;
            }
        }

        public float CurrentAirPressure
        {
            get
            {
                return m_CurrentAirPressure;
            }
            set
            {
                m_CurrentAirPressure = value;
            }
        }

        public float MaxAirPressure
        {
            get
            {
                return m_MaxAirPressure;
            }
        }

        public void PumpWheel(float i_PressureToAdd)
        {
            float pressureAfterFilling = this.CurrentAirPressure + i_PressureToAdd;

            if (pressureAfterFilling > this.MaxAirPressure)
            {
                throw new ValueOutOfRangeException(0, this.MaxAirPressure - this.CurrentAirPressure);
            }
            else
            {
                this.CurrentAirPressure = pressureAfterFilling;
            }
        }

        public void PumpWheelToMax()
        {
            m_CurrentAirPressure = m_MaxAirPressure;
        }

        public override string ToString()
        {
            string msg = string.Format("Wheel manufacture name: {0}{1}", m_ManufactureName, Environment.NewLine);

            msg += string.Format("Wheel current air pressure: {0}{1}", m_CurrentAirPressure, Environment.NewLine);
            msg += string.Format("Wheel max air pressure: {0}{1}", m_MaxAirPressure, Environment.NewLine);
            return msg;
        }
    }
}
