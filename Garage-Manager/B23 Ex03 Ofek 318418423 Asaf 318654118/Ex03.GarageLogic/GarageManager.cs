using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class GarageManager
    {
        private Dictionary<string, Vehicle> m_AllVehicles;
        private VehicleCreator m_VehicleCreator;

        public GarageManager()
        {
            m_AllVehicles = new Dictionary<string, Vehicle>();
        }

        public bool IsVehicleInGarage(string i_LicensePlateNumber) //todo! the UI will use it before InsertVehicleToGarage() for validation
        {
            bool isVehicleExists = m_AllVehicles.ContainsKey(i_LicensePlateNumber);

            if(isVehicleExists)
            {
                m_AllVehicles[i_LicensePlateNumber].CustomerVehicleCondition = eVehicleCondition.InMaintenance;
            }

            return isVehicleExists; 
        }

        public void InsertVehicleToGarage(string i_LicensePlateNumber, Dictionary<string, string> VehicleDetails)
        {
            Vehicle newVehicle = m_VehicleCreator.CreateVehicle(VehicleDetails);

            m_AllVehicles.Add(i_LicensePlateNumber, newVehicle);
        }

        public List<string> GetListOfLicensePlates(eVehicleCondition i_VehicleConditionFilter)
        {           
                var filteredDictionary = m_AllVehicles.Where(pair => pair.Value.CustomerOfVehicle.VehicleCondition == i_VehicleConditionFilter);
                return filteredDictionary.Select(pair => pair.Key).ToList();
        }
        
        public void ChangeVehicleCondition(string i_LicensePlateNumber, eVehicleCondition i_NewCondition)
        {    
                Vehicle vehicleFound = getVehicleAccordingToLicensePlate(i_LicensePlateNumber);

                vehicleFound.CustomerOfVehicle.VehicleCondition = i_NewCondition;           
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
