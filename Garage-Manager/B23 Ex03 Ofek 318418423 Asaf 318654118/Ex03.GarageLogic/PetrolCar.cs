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

        public PetrolCar(eCarColor i_Color, int i_TotalDoors, float i_MaxTankInLiter, ePetrolType i_PetrolType, string i_ModelName, string i_LicensePlateNumber, int i_NumberOfWheels, string i_WheelManufactureName,
    float i_CurrentAirPressure, float i_MaxAirPressure, string i_OwnerName, string i_OwnerPhone) : base(i_MaxTankInLiter, i_PetrolType, i_ModelName, i_LicensePlateNumber, i_NumberOfWheels, i_WheelManufactureName,
    i_CurrentAirPressure, i_MaxAirPressure, i_OwnerName, i_OwnerPhone)
        {
            m_Color = i_Color;
            m_TotalDoors = i_TotalDoors;
        }

        public override string ToString()
        {
            string msg = base.ToString();

            msg += string.Format("Car's color is {0}{1}", m_Color, Environment.NewLine);
            msg += string.Format("Car's Total Doors is {0}{1}", m_TotalDoors, Environment.NewLine);

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
