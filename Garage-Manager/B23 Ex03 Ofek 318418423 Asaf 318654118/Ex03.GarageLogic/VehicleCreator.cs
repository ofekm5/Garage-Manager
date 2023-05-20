using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    class VehicleCreator
    {
        public Vehicle CreateVehicle(Dictionary<string, string> i_VehicleDetails)
        {
            Vehicle newVehicle;

            switch (i_VehicleDetails["VehicleType"])
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
                case "truck": //"truck"
                    newVehicle = initTruck(i_VehicleDetails);
                    break;
                default:
                    throw new ArgumentException("invalid vehicle type! use lowercase letters only");
            }

            return newVehicle;
        }

        private ElectricCar initElectricCar(Dictionary<string, string> i_VehicleDetails)
        {
            ElectricCar newElectricCar;
            eCarColor carColor;
            int totalDoors;
            float currentAirPressure;
            float currentAccumulatorTime;

            validateElectricCarInfoFromUser(i_VehicleDetails, out carColor, out totalDoors, out currentAirPressure, out currentAccumulatorTime);

            newElectricCar = new ElectricCar(i_VehicleDetails["ModelName"], i_VehicleDetails["LicensePlateNumber"], totalDoors, i_VehicleDetails["WheelManufactureName"], 
                currentAirPressure, currentAccumulatorTime, carColor, i_VehicleDetails["OwnerName"], i_VehicleDetails["OwnerPhone"]);

            return newElectricCar;
        }

        private void validateElectricCarInfoFromUser(Dictionary<string, string> i_VehicleDetails, out eCarColor o_CarColor,
            out int o_TotalDoors, out float o_CurrentAirPressure, out float o_CurrentAccumulatorTime)
        {
            validateCarInfoFromUser(i_VehicleDetails, out o_CarColor, out o_TotalDoors, out o_CurrentAirPressure);
            if (!float.TryParse(i_VehicleDetails["CurrentAccumulatorTime"], out o_CurrentAccumulatorTime))
            {
                throw new FormatException("total doors cannot be parsed! please use a valid number");
            }
        }

        private void validateCarInfoFromUser(Dictionary<string, string> i_VehicleDetails, out eCarColor o_CarColor, 
            out int o_TotalDoors, out float o_CurrentAirPressure)
        {
            switch (i_VehicleDetails["CarColor"])
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

            if (!int.TryParse(i_VehicleDetails["TotalDoors"], out o_TotalDoors))
            {
                throw new FormatException("total doors cannot be parsed! please use a valid number");
            }

            if (!float.TryParse(i_VehicleDetails["CurrentAirPressure"], out o_CurrentAirPressure))
            {
                throw new FormatException("total doors cannot be parsed! please use a valid number");
            }
        }
        private Truck initTruck(Dictionary<string, string> i_VehicleDetails)
        {
            Truck newTruck;
            eCarColor carColor;
            int totalDoors;
            float currentAirPressure;
            float currentLiterInTank;

            validateTruckInfoFromUser(i_VehicleDetails, out carColor, out totalDoors, out currentAirPressure, out currentLiterInTank);

            newTruck = new Truck(carColor, totalDoors, i_VehicleDetails["ModelName"], i_VehicleDetails["LicensePlateNumber"], i_VehicleDetails["WheelManufactureName"],
                currentAirPressure, i_VehicleDetails["OwnerName"], i_VehicleDetails["OwnerPhone"], currentLiterInTank);

            return newTruck;
        }

        private PetrolCar initPetrolCar(Dictionary<string, string> i_VehicleDetails)
        {
            PetrolCar newPetrolCar;
            eCarColor carColor;
            int totalDoors;
            float currentAirPressure;
            float currentLiterInTank;

            validatePetrolCarInfoFromUser(i_VehicleDetails, out carColor, out totalDoors, out currentAirPressure, out currentLiterInTank);

            newPetrolCar = new PetrolCar(carColor, totalDoors, i_VehicleDetails["ModelName"], i_VehicleDetails["LicensePlateNumber"], i_VehicleDetails["WheelManufactureName"],
                currentAirPressure, i_VehicleDetails["OwnerName"], i_VehicleDetails["OwnerPhone"], currentLiterInTank);

            return newPetrolCar;
        }

        private void validatePetrolCarInfoFromUser(Dictionary<string, string> i_VehicleDetails, out eCarColor o_CarColor, out int o_TotalDoors, out float o_CurrentAirPressure, out float o_CurrentLiterInTank)
        {
            validateCarInfoFromUser(i_VehicleDetails, out o_CarColor, out o_TotalDoors, out o_CurrentAirPressure);
            if (!float.TryParse(i_VehicleDetails["CurrentLiterInTank"], out o_CurrentLiterInTank))
            {
                throw new FormatException("current liter in tank cannot be parsed! please use a valid number");
            }
        }
    }
}
