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

        public bool IsVehicleInGarage(string i_LicensePlateNumber) //todo! the UI will use it before InsertVehicleToGarage() for validation
        {
            m_AllVehicles[i_LicensePlateNumber].CustomerVehicleCondition = eVehicleCondition.InMaintenance;

            return m_AllVehicles.ContainsKey(i_LicensePlateNumber); 
        }

        public void InsertVehicleToGarage(string i_LicensePlateNumber, Dictionary<string, string> VehicleDetails)
        {
            Vehicle newVehicle = new Vehicle();

            m_AllVehicles.Add(i_LicensePlateNumber, newVehicle);
        }

        public List<string> GetListOfLicensePlates(eVehicleCondition i_VehicleConditionFilter)
        {
            if(i_VehicleConditionFilter != eVehicleCondition.Fixed && i_VehicleConditionFilter != eVehicleCondition.InMaintenance
                && i_VehicleConditionFilter != eVehicleCondition.PayedFor)
            {
                throw new ArgumentException("Invalid vehicle condition");
            }
            else
            {
                var filteredDictionary = m_AllVehicles.Where(pair => pair.Value.CustomerOfVehicle.VehicleCondition == i_VehicleConditionFilter);
                return filteredDictionary.Select(pair => pair.Key).ToList();
            }
        }
        
        public void ChangeVehicleCondition(string i_LicensePlateNumber, eVehicleCondition i_NewCondition)
        {
            if (i_NewCondition != eVehicleCondition.Fixed && i_NewCondition != eVehicleCondition.InMaintenance
                && i_NewCondition != eVehicleCondition.PayedFor)
            {
                throw new ArgumentException("Invalid vehicle condition");
            }
            else
            {
                Vehicle vehicleFound = getVehicleAccordingToLicensePlate(i_LicensePlateNumber);
                vehicleFound.CustomerOfVehicle.VehicleCondition = i_NewCondition;
            }
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

        public string GetVehicleData(string i_LicensePlateNumber)
        {
            string vehicleDetails = "";
            Vehicle vehicleFound = getVehicleAccordingToLicensePlate(i_LicensePlateNumber);

            vehicleDetails += vehicleFound.ToString();
            return vehicleDetails;
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
