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
        private const int numberOfWheels = 5;
        private const float maxAirPressure = 33;
        private const ePetrolType petrolType = ePetrolType.Octan95;
        private const float maxTankInLiter = 46;

        public PetrolCar(eCarColor i_Color, int i_TotalDoors, string i_ModelName, string i_LicensePlateNumber, string i_WheelManufactureName, 
                           float i_CurrentAirPressure, string i_OwnerName, string i_OwnerPhone, float i_CurrentLiterInTank) : 
                           base(maxTankInLiter, petrolType, i_ModelName, i_LicensePlateNumber, numberOfWheels, i_WheelManufactureName, i_CurrentAirPressure, maxAirPressure, i_OwnerName, i_OwnerPhone, i_CurrentLiterInTank)
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
