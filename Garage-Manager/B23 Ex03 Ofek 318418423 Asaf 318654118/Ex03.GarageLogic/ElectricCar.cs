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

    class ElectricCar : ElectricVehicle
    {
        private eCarColor m_Color;
        private int m_TotalDoors;
        
    }
}
