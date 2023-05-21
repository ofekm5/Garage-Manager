using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    
    class PetrolCar : PetrolVehicle
    {
        private eCarColor m_Color;
        private int m_TotalDoors;
        private const int k_NumberOfWheels = 5;
        private const float k_MaxAirPressure = 33;
        private const ePetrolType k_PetrolType = ePetrolType.Octan95;
        private const float k_MaxLiterInTank = 46;

        public PetrolCar(eCarColor i_Color, int i_TotalDoors, string i_ModelName, string i_LicensePlateNumber, string i_WheelManufactureName, 
                           float i_CurrentAirPressure, string i_OwnerName, string i_OwnerPhone, float i_CurrentLiterInTank) : 
                           base(k_MaxLiterInTank, k_PetrolType, i_ModelName, i_LicensePlateNumber, k_NumberOfWheels, i_WheelManufactureName, i_CurrentAirPressure, k_MaxAirPressure, i_OwnerName, i_OwnerPhone, i_CurrentLiterInTank)
        {
            m_Color = i_Color;
            m_TotalDoors = i_TotalDoors;
        }

        public override string ToString()
        {
            string msg = base.ToString();

            msg += string.Format("Car's color: {0}{1}", m_Color, Environment.NewLine);
            msg += string.Format("Car's Total Doors: {0}{1}", m_TotalDoors, Environment.NewLine);

            return msg;
        }

        public eCarColor Color
        {
            get
            {
                return m_Color;
            }
        }

        public int TotalDoors
        {
            get
            {
                return m_TotalDoors;
            }
        }
    }
}
