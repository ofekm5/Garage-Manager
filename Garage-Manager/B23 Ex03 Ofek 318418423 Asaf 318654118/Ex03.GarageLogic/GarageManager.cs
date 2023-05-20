using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class GarageManager
    {
        private Dictionary<string, Vehicle> m_AllVehicles;

        public GarageManager()
        {
            m_AllVehicles = new Dictionary<string, Vehicle>();
        }

        public void InsertVehicleToGarage(string i_LicensePlateNumber)
        {

        }

        public List<string> GetListOfLicensePlates(string i_VehicleConditionFilter)
        {

        }
        
        public void ChangeVehicleCondition(string i_LicensePlateNumber, string i_NewCondition)
        {

        }

        public void PumpWheelsToMax(string i_LicensePlateNumber)
        {

        }

        public void AddEnergy(float i_AmountToFill)
        {

        }

        public string PresentVehicleData(string i_LicensePlateNumber)
        {

        }
    }
}
