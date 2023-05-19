using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private string m_ManufactureName;
        private float m_CurrentWheelPressure;
        private float m_MaxWheelPressure;

        public Wheel(string i_ManufactureName, float i_CurrentWheelPressure, float i_MaxWheelPressure)
        {
            m_ManufactureName = i_ManufactureName;
            m_CurrentWheelPressure = i_CurrentWheelPressure;
            m_MaxWheelPressure = i_MaxWheelPressure;
        }

        public string ManufactureName
        {
            get
            {
                return m_ManufactureName;
            }
        }

        public float CurrentWheelPressure
        {
            get
            {
                return m_CurrentWheelPressure;
            }
        }

        public float MaxWheelPressure
        {
            get
            {
                return m_MaxWheelPressure;
            }
        }

        public void PumpWheel(float i_PressureToAdd)
        {

        }

        public override string ToString()
        {
            string msg = string.Format("Wheel manufacture name: {0}. {1}Wheel current air pressure: {2}. {3}Wheel max air pressure: {4}"
                , m_ManufactureName, Environment.NewLine, m_CurrentWheelPressure, m_MaxWheelPressure);
            return msg;
        }
    }
}
