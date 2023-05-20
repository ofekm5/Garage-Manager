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
