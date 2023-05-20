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
            Vehicle vehicleFound = getVehicleAccordingToLicensePlate(i_LicensePlateNumber);
            foreach(Wheel wheel in vehicleFound.AllWheels)
            {
                wheel.PumpWheelToMax();
            }
        }

        public void AddEnergy(float i_AmountToFill, string i_LicensePlateNumber)
        {
            Vehicle vehicleFound = getVehicleAccordingToLicensePlate(i_LicensePlateNumber);
            vehicleFound.AddEnergy(i_AmountToFill);           
        }

        public string PresentVehicleData(string i_LicensePlateNumber)
        {
            
        }

        private Vehicle getVehicleAccordingToLicensePlate(string i_LicensePlateNumber)
        {
            Vehicle vehicleFound = null;
            if (!m_AllVehicles.ContainsKey(i_LicensePlateNumber))
            {
                throw new ArgumentException("License plate {0} does not appear in the garage.", i_LicensePlateNumber);
            }
            else
            {
                vehicleFound = m_AllVehicles[i_LicensePlateNumber];
            }

            return vehicleFound;
        }
    }
}
