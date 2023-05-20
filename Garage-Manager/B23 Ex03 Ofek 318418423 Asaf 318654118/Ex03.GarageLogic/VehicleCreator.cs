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

            switch (i_VehicleDetails["CarColor"])
            {
                case "white":
                    carColor = eCarColor.White;
                    break;
                case "black":
                    carColor = eCarColor.Black;
                    break;
                case "yellow":
                    carColor = eCarColor.Yellow;
                    break;
                case "red":
                    carColor = eCarColor.Red;
                    break;
                default:
                    throw new ArgumentException();
            }


            newElectricCar = new ElectricCar(i_VehicleDetails["ModelName"], i_VehicleDetails["LicensePlateNumber"], i_VehicleDetails["WheelManufactureName"], i_VehicleDetails["CurrentAirPressure"], i_VehicleDetails["CurrentAccumulatorTime"],
                carColor, i_VehicleDetails["OwnerName"], i_VehicleDetails["OwnerPhone"]);


            return newElectricCar;
        }
    }
}
