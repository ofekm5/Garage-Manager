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
        private const int k_NumberOfWheels = 5;
        private const float k_MaxAirPressure = 33;
        private const float k_MaxAccumulatorTime = 5.2f;

        public ElectricCar(string i_ModelName, string i_LicensePlateNumber, int i_TotalDoors, string i_WheelManufactureName,
            float i_CurrentAirPressure, float i_CurrentAccumulatorTime, eCarColor i_CarColor, string i_OwnerName, string i_OwnerPhone)
            : base(i_ModelName, i_LicensePlateNumber, k_NumberOfWheels, i_WheelManufactureName, i_CurrentAirPressure, k_MaxAirPressure, k_MaxAccumulatorTime, i_CurrentAccumulatorTime, i_OwnerName, i_OwnerPhone)
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

        public static bool ValidateWheelPressure(float i_CurrWheelPressure)
        {
            return k_MaxAirPressure > i_CurrWheelPressure;
        }

        public static float GetMaxWheelPressure()
        {
            return k_MaxAirPressure;
        }

        public static float GetMaxAccumulatorTime()
        {
            return k_MaxAccumulatorTime;
        }

        public override string ToString()
        {
            string msg = base.ToString();
            msg += string.Format("Total car doors: {0}{1}", m_TotalDoors, Environment.NewLine);
            msg += string.Format("Car color: {0}{1}", m_Color, Environment.NewLine);
            return msg;
        }
    }
}
