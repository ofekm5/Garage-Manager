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

        public bool IsVehicleInGarage(string i_LicensePlateNumber)
        {
            bool isVehicleExists = m_AllVehicles.ContainsKey(i_LicensePlateNumber);

            if(isVehicleExists)
            {
                m_AllVehicles[i_LicensePlateNumber].CustomerVehicleCondition = eVehicleCondition.InMaintenance;
            }

            return isVehicleExists; 
        }

        public List<string> GetVehicleTypes()
        {
            return m_VehicleCreator.VehicleTypes;
        }

        public List<string> GetPropertiesOfVehicle(string i_VehicleType)
        {
            return m_VehicleCreator.GetProperitiesNeededForCreation(i_VehicleType);
        }

        public void InsertVehicleToGarage(string i_VehicleType, string i_LicensePlateNumber, Dictionary<string, string> VehicleDetails)
        {
            Vehicle newVehicle = m_VehicleCreator.CreateVehicle(i_VehicleType, VehicleDetails);

            m_AllVehicles.Add(i_LicensePlateNumber, newVehicle);
        }

        public List<string> GetListOfLicensePlatesWithFilter(eVehicleCondition i_VehicleConditionFilter)
        {           
                var filteredDictionary = m_AllVehicles.Where(pair => pair.Value.CustomerOfVehicle.VehicleCondition == i_VehicleConditionFilter);
                return filteredDictionary.Select(pair => pair.Key).ToList();
        }

        public List<string> GetListOfLicensePlatesWithoutFilter()
        {
            return m_AllVehicles.Keys.ToList();
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

        public void AddEnergy(float i_AmountToFill, string i_LicensePlateNumber, ePetrolType petrolTypeProvided = default)
        {
            Vehicle vehicleFound = getVehicleAccordingToLicensePlate(i_LicensePlateNumber);

            if(vehicleFound is PetrolVehicle)
            {
                PetrolCar petrolCar = vehicleFound as PetrolCar;
                PetrolMotorcycle petrolMotorcycle = vehicleFound as PetrolMotorcycle;
                Truck truck = vehicleFound as Truck;

                if (petrolCar != null)
                {
                    if(petrolCar.PetrolType != petrolTypeProvided)
                    {
                        throw new ArgumentException("Invalid petrol type. Please try again.");
                    }
                }
                else if(petrolMotorcycle != null)
                {
                    if(petrolMotorcycle.PetrolType != petrolTypeProvided)
                    {
                        throw new ArgumentException("Invalid petrol type. Please try again.");
                    }
                }
                else if(truck != null)
                {
                    if(truck.PetrolType != petrolTypeProvided)
                    {
                        throw new ArgumentException("Invalid petrol type. Please try again.");
                    }
                }
            }

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
