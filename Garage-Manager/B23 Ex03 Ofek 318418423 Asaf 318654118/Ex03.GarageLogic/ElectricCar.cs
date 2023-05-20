using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public enum eCarColor
    { 
        White,
        Black,
        Yellow,
        Red
    }

    public class ElectricCar : ElectricVehicle
    {

        private eCarColor m_Color;
        private int m_TotalDoors;
        private const int numberOfWheels = 5;
        private const float maxAirPressure = 33;
        private const float maxAcumulatorTime = 5.2f;

        public ElectricCar(string i_ModelName, string i_LicensePlateNumber, int i_NumberOfWheels, string i_WheelManufactureName,
            float i_CurrentAirPressure, float i_CurrentAccumulatorTime, eCarColor i_CarColor, string i_OwnerName, string i_OwnerPhone)
            : base(i_ModelName, i_LicensePlateNumber, i_NumberOfWheels, i_WheelManufactureName, i_CurrentAirPressure, maxAirPressure, maxAcumulatorTime, i_CurrentAccumulatorTime, i_OwnerName, i_OwnerPhone)
        {
            m_Color = i_CarColor;
            m_TotalDoors = totalDoors;
        }

        public int Doors
        {
            get
            {
                return m_TotalDoors;
            }

            set
            {
                m_TotalDoors = value;
            }
        }

        public eCarColor CarColor
        {
            get
            {
                return m_Color;
            }

            set
            {
                m_Color = value;
            }
        }

        public override string ToString()
        {
            string msg = base.ToString();
            msg += string.Format("Total car doors: {0}{1}Car color: {2}{3}", m_TotalDoors, Environment.NewLine, m_Color, Environment.NewLine);
            return msg;
        }
    }
}
