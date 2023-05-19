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

        public ElectricCar(string i_ModelName, string i_LicensePlateNumber, int i_NumberOfWheels, string i_WheelManufactureName,
            float i_CurrentAirPressure, float i_MaxAirPressure, float i_MaxAcumulatorTime, float i_CurrentAccumulatorTime, eCarColor i_CarColor, int i_TotalDoors)
            : base(i_ModelName, i_LicensePlateNumber, i_NumberOfWheels, i_WheelManufactureName, i_CurrentAirPressure, i_MaxAirPressure, i_MaxAcumulatorTime, i_CurrentAccumulatorTime)
        {
            m_Color = i_CarColor;
            m_TotalDoors = i_TotalDoors;
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

    }
}
