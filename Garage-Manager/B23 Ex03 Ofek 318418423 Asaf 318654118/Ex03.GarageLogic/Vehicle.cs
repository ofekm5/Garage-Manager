using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    abstract class Vehicle
    {
        private string m_ModelName;
        private string m_LicenseplateNumber;
        private float m_EnergyLeftPercentage;
        private List<Wheel> m_heels;
    }
}
