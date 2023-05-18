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
    }
}
