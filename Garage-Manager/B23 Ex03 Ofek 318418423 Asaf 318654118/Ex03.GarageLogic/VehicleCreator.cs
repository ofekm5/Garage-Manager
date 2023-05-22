using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Ex03.GarageLogic
{
    class VehicleCreator
    {
        private readonly List<string> m_VehicleTypes;

        public VehicleCreator()
        {
            m_VehicleTypes = new List<string>() { "electric car", "electric motorcycle", "petrol car", "petrol motorcycle", "truck" };
        }

        public List<string> VehicleTypes
        {
            get
            {
                return m_VehicleTypes;
            }
        }

        public List<string> GetProperitiesNeededForCreation(string i_VehicleType)
        {
            List<string> vehicleDetails = new List<string>();
            Type vehicleType;
            FieldInfo[] fields;

            switch (i_VehicleType)
            {
                case "electric car":
                    vehicleType = typeof(ElectricCar);
                    break;
                case "electric motorcycle":
                    vehicleType = typeof(ElectricMotorcycle);
                    break;
                case "petrol car":
                    vehicleType = typeof(PetrolCar);
                    break;
                case "petrol motorcycle":
                    vehicleType = typeof(PetrolMotorcycle);
                    break;
                case "truck":
                    vehicleType = typeof(Truck);
                    break;
                default:
                    throw new ArgumentException("invalid vehicle type! use lowercase letters only");
            }

            fields = vehicleType.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            foreach (FieldInfo attribute in fields)
            {
                if (attribute.Name.StartsWith("m_"))
                {
                    vehicleDetails.Add(attribute.Name);
                }
            }

            return vehicleDetails;
        }

        public Vehicle CreateVehicle(string i_VehicleType, Dictionary<string, string> i_VehicleDetails)
        {
            Vehicle newVehicle;

            switch (i_VehicleType)
            {
                case "electric car":
                    newVehicle = initElectricCar(i_VehicleDetails);
                    break;
                case "electric motorcycle":
                    newVehicle = initElectricMotorcycle(i_VehicleDetails);
                    break;
                case "petrol car":
                    newVehicle = initPetrolCar(i_VehicleDetails);
                    break;
                case "petrol motorcycle":
                    newVehicle = initPetrolMotorcycle(i_VehicleDetails);
                    break;
                case "truck":
                    newVehicle = initTruck(i_VehicleDetails);
                    break;
                default:
                    throw new ArgumentException("invalid vehicle type! use lowercase letters only");
            }

            return newVehicle;
        }


        private PetrolMotorcycle initPetrolMotorcycle(Dictionary<string, string> i_VehicleDetails)
        {
            PetrolMotorcycle petrolMotorcycle;
            eLicenseType licenseType;
            int engineVolumeInCC;
            float currentAirPressure;
            float currentLiterInTank;

            validatePetrolMotorcycleInfoFromUser(i_VehicleDetails, out licenseType, out engineVolumeInCC, out currentAirPressure, out currentLiterInTank);
            petrolMotorcycle = new PetrolMotorcycle(licenseType, engineVolumeInCC, i_VehicleDetails["m_ModelName"], i_VehicleDetails["m_LicensePlateNumber"],
                i_VehicleDetails["m_WheelManufactureName"], currentAirPressure, i_VehicleDetails["m_OwnerName"],
                i_VehicleDetails["m_OwnerPhone"], currentLiterInTank);

            return petrolMotorcycle;
        }

        private void validatePetrolMotorcycleInfoFromUser(Dictionary<string, string> i_VehicleDetails, out eLicenseType o_LicenseType, out int o_EngineVolumeInCC, out float o_CurrentAirPressure, out float o_CurrentLiterInTank)
        {
            validateMotorcycleInfoFromUser(i_VehicleDetails, out o_LicenseType);
            if (!float.TryParse(i_VehicleDetails["m_CurrentAirPressure"], out o_CurrentAirPressure))
            {
                throw new FormatException("Current Air pressure time cannot be parsed! please use a valid number");
            }

            if (!float.TryParse(i_VehicleDetails["m_CurrentLiterInTank"], out o_CurrentLiterInTank))
            {
                throw new FormatException("Current liter in tank cannot be parsed! please use a valid number");
            }

            if (!int.TryParse(i_VehicleDetails["m_EngineVolumeInCC"], out o_EngineVolumeInCC))
            {
                throw new FormatException("Current liter in tank cannot be parsed! please use a valid number");
            }
        }

        private ElectricMotorcycle initElectricMotorcycle(Dictionary<string, string>  i_VehicleDetails)
        {
            ElectricMotorcycle electricMotorcycle;
            float currentAirPressure;
            float currentAccumulatorTime;
            eLicenseType licenseType;

            validateElectricMotorcycleInfoFromUser(i_VehicleDetails, out currentAirPressure, out currentAccumulatorTime, out licenseType);
            electricMotorcycle = new ElectricMotorcycle(i_VehicleDetails["m_ModelName"], i_VehicleDetails["m_LicensePlateNumber"], i_VehicleDetails["m_WheelManufactureName"],
                currentAirPressure, currentAccumulatorTime, licenseType, i_VehicleDetails["m_OwnerName"], i_VehicleDetails["m_OwnerPhone"]);

            return electricMotorcycle;
        }

        private void validateElectricMotorcycleInfoFromUser(Dictionary<string, string> i_VehicleDetails, out float o_CurrentAirPressure, out float o_CurrentAccumulatorTime, out eLicenseType o_LicenseType)
        {
            validateMotorcycleInfoFromUser(i_VehicleDetails, out o_LicenseType);
            if (!float.TryParse(i_VehicleDetails["m_CurrentAccumulatorTime"], out o_CurrentAccumulatorTime))
            {
                throw new FormatException("Current accumulator time cannot be parsed! please use a valid number");
            }

            if (!float.TryParse(i_VehicleDetails["m_CurrentAirPressure"], out o_CurrentAirPressure))
            {
                throw new FormatException("Current Air pressure time cannot be parsed! please use a valid number");
            }
        }

        private void validateMotorcycleInfoFromUser(Dictionary<string, string>  i_VehicleDetails, out eLicenseType o_LicenseType)
        {
            switch (i_VehicleDetails["m_LicenseType"])
            {
                case "AA":
                    o_LicenseType = eLicenseType.AA;
                    break;
                case "A1":
                    o_LicenseType = eLicenseType.A1;
                    break;
                case "A2":
                    o_LicenseType = eLicenseType.A2;
                    break;
                case "B1":
                    o_LicenseType = eLicenseType.B1;
                    break;
                default:
                    throw new ArgumentException("invalid license type! choose from the following: AA, A1, A2, A3");
            }
        }

        private ElectricCar initElectricCar(Dictionary<string, string> i_VehicleDetails)
        {
            ElectricCar newElectricCar;
            eCarColor carColor;
            int totalDoors;
            float currentAirPressure;
            float currentAccumulatorTime;

            validateElectricCarInfoFromUser(i_VehicleDetails, out carColor, out totalDoors, out currentAirPressure, out currentAccumulatorTime);
            newElectricCar = new ElectricCar(i_VehicleDetails["m_ModelName"], i_VehicleDetails["m_LicensePlateNumber"], totalDoors, i_VehicleDetails["m_WheelManufactureName"], 
                currentAirPressure, currentAccumulatorTime, carColor, i_VehicleDetails["m_OwnerName"], i_VehicleDetails["m_OwnerPhone"]);

            return newElectricCar;
        }

        private void validateElectricCarInfoFromUser(Dictionary<string, string> i_VehicleDetails, out eCarColor o_CarColor,
            out int o_TotalDoors, out float o_CurrentAirPressure, out float o_CurrentAccumulatorTime)
        {
            validateCarInfoFromUser(i_VehicleDetails, out o_CarColor, out o_TotalDoors, out o_CurrentAirPressure);
            if (!float.TryParse(i_VehicleDetails["m_CurrentAccumulatorTime"], out o_CurrentAccumulatorTime))
            {
                throw new FormatException("Current accumulator time cannot be parsed! please use a valid number");
            }
        }

        private void validateCarInfoFromUser(Dictionary<string, string> i_VehicleDetails, out eCarColor o_CarColor, 
            out int o_TotalDoors, out float o_CurrentAirPressure)
        {
            switch (i_VehicleDetails["m_CarColor"])
            {
                case "white":
                    o_CarColor = eCarColor.White;
                    break;
                case "black":
                    o_CarColor = eCarColor.Black;
                    break;
                case "yellow":
                    o_CarColor = eCarColor.Yellow;
                    break;
                case "red":
                    o_CarColor = eCarColor.Red;
                    break;
                default:
                    throw new ArgumentException("invalid car color! choose from the following: white, black, yellow, red");
            }

            if (!int.TryParse(i_VehicleDetails["m_TotalDoors"], out o_TotalDoors))
            {
                throw new FormatException("total doors cannot be parsed! please use a valid number");
            }

            if (!float.TryParse(i_VehicleDetails["m_CurrentAirPressure"], out o_CurrentAirPressure))
            {
                throw new FormatException("current air pressure cannot be parsed! please use a valid number");
            }
        }

        private Truck initTruck(Dictionary<string, string> i_VehicleDetails)
        {
            Truck newTruck;
            float currentAirPressure;
            float currentLiterInTank;
            float loadCapacity;
            bool containHazardMaterials;

            validateTruckInfoFromUser(i_VehicleDetails, out containHazardMaterials, out loadCapacity, out currentAirPressure, out currentLiterInTank);
            newTruck = new Truck(containHazardMaterials, loadCapacity, i_VehicleDetails["m_ModelName"], i_VehicleDetails["m_LicensePlateNumber"],
                i_VehicleDetails["m_WheelManufactureName"], currentAirPressure, i_VehicleDetails["m_OwnerName"], i_VehicleDetails["m_OwnerPhone"], currentLiterInTank);

            return newTruck;
        }

        private void validateTruckInfoFromUser(Dictionary<string, string> i_VehicleDetails, out bool o_ContainHazardMaterials, out float o_LoadCapacity, out float o_CurrentAirPressure, out float o_CurrentLiterInTank)
        {
            if (!float.TryParse(i_VehicleDetails["m_CurrentAirPressure"], out o_CurrentAirPressure))
            {
                throw new FormatException("current air pressure cannot be parsed! please use a valid number");
            }

            if (!float.TryParse(i_VehicleDetails["m_CurrentLiterInTank"], out o_CurrentLiterInTank))
            {
                throw new FormatException("current liter in tank cannot be parsed! please use a valid number");
            }

            if (!float.TryParse(i_VehicleDetails["m_LoadCapacity"], out o_LoadCapacity))
            {
                throw new FormatException("current liter in tank cannot be parsed! please use a valid number");
            }

            if (i_VehicleDetails["m_ContainHazardMaterials"] == "true")
            {
                o_ContainHazardMaterials = true;
            }
            else if(i_VehicleDetails["m_ContainHazardMaterials"] == "false")
            {
                o_ContainHazardMaterials = false;
            }
            else
            {
                throw new FormatException("ContainHazardMaterials cannot be parsed! please enter true/false");
            }
        }

        private PetrolCar initPetrolCar(Dictionary<string, string> i_VehicleDetails)
        {
            PetrolCar newPetrolCar;
            eCarColor carColor;
            int totalDoors;
            float currentAirPressure;
            float currentLiterInTank;

            validatePetrolCarInfoFromUser(i_VehicleDetails, out carColor, out totalDoors, out currentAirPressure, out currentLiterInTank);
            newPetrolCar = new PetrolCar(carColor, totalDoors, i_VehicleDetails["m_ModelName"], i_VehicleDetails["m_LicensePlateNumber"], i_VehicleDetails["m_WheelManufactureName"],
                currentAirPressure, i_VehicleDetails["m_OwnerName"], i_VehicleDetails["m_OwnerPhone"], currentLiterInTank);

            return newPetrolCar;
        }

        private void validatePetrolCarInfoFromUser(Dictionary<string, string> i_VehicleDetails, out eCarColor o_CarColor, out int o_TotalDoors, out float o_CurrentAirPressure, out float o_CurrentLiterInTank)
        {
            validateCarInfoFromUser(i_VehicleDetails, out o_CarColor, out o_TotalDoors, out o_CurrentAirPressure);
            if (!float.TryParse(i_VehicleDetails["m_CurrentLiterInTank"], out o_CurrentLiterInTank))
            {
                throw new FormatException("current liter in tank cannot be parsed! please use a valid number");
            }
        }
    }
}