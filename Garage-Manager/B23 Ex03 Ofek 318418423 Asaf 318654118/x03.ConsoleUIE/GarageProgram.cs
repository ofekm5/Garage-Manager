using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ex03.GarageLogic;

namespace x03.ConsoleUIE
{
    public enum eUserChoice
    {
        Exit,
        InsertVehicle,
        GetListOfLicensePlates,
        ChangeVehicleStatus,
        PumpWheelsToMax,
        FuelPetrolVehicle,
        ChargeElectricVehicle,
        GetVehicleData,
    }

    public class GarageProgram
    {
        private GarageManager m_GarageManager;

        public void RunGarageApp()
        {
            int userChoice;
            m_GarageManager = new GarageManager();

            Console.WriteLine("Hello. Welcome to the garage app. Please choose one of the following options:");
            do
            {
                presentMenu();
                validateInput(out userChoice);
                if(userChoice == 0)
                {
                    break;
                }
                try
                {
                    makeProcessAccordingToUserChoice(userChoice);
                }
                catch (FormatException formatException)
                {
                    Console.WriteLine(formatException.Message);
                }
                catch (ArgumentException argumentException)
                {
                    Console.WriteLine(argumentException.Message);
                }
                catch (ValueOutOfRangeException valOutOfRangeException)
                {
                    Console.WriteLine(valOutOfRangeException.Message);
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
            } while (userChoice != (int)eUserChoice.Exit);
        }

        private void presentMenu()
        {
            string msg = string.Format("0. Exit. {0}1. Insert new vehicle to the garage {1}", Environment.NewLine, Environment.NewLine);

            msg += string.Format("2. Get list of license plates.{0}3. Change vehicle condition.{1}", Environment.NewLine, Environment.NewLine);
            msg += string.Format("4. Pump all vehicle wheels to max air pressure. {0}5. Fuel petrol vehicle.{1}", Environment.NewLine, Environment.NewLine);
            msg += string.Format("6. Charge electric vehicle.{0}7. Get vehicle data.", Environment.NewLine);
            Console.WriteLine(msg);
        }

        private void validateInput(out int io_UserChoice)
        {
            while (!int.TryParse(Console.ReadLine(), out io_UserChoice) || !(io_UserChoice >= (int)eUserChoice.Exit && io_UserChoice <= (int)eUserChoice.GetVehicleData))
            {
                Console.WriteLine("Invalid choice. Please chooce once again.");
            }
        }

        private void makeProcessAccordingToUserChoice(int i_UserChoice)
        {
            eUserChoice userInputInEnum = (eUserChoice)i_UserChoice;

            System.Console.Clear();
            switch (userInputInEnum)
            {
                case eUserChoice.InsertVehicle:
                    insertVehicleToGarage();
                    break;
                case eUserChoice.GetListOfLicensePlates:
                    getListOfLicensePlates();
                    break;
                case eUserChoice.ChangeVehicleStatus:
                    changeVehicleStatus();
                    break;
                case eUserChoice.PumpWheelsToMax:
                    pumpAllWheelsToMax();
                    break;
                case eUserChoice.FuelPetrolVehicle:
                    fuelPetrolVehicle();
                    break;
                case eUserChoice.ChargeElectricVehicle:
                    chargeElectricVehicle();
                    break;
                case eUserChoice.GetVehicleData:
                    getVehicleData();
                    break;
                case eUserChoice.Exit:
                    Console.WriteLine("Goodbye");
                    break;
            }
        }

        private void getLicensePlateFromUser(out string o_LicensePlate)
        {
            Console.WriteLine("Please enter the vehicle's License plate");
            do
            {
                o_LicensePlate = Console.ReadLine();
                if (!(o_LicensePlate.Length > 0 && o_LicensePlate.Length <= 8))
                {
                    Console.WriteLine("Invalid license plate! make sure its length is between 1 and 8. Try again");
                }
            }
            while (!(o_LicensePlate.Length >= 0 && o_LicensePlate.Length <= 8));
        }

        private Dictionary<string, string> setVehicleDetails(List<string> i_VehicleProperties)
        {
            Dictionary<string, string> vehicleDetails = new Dictionary<string, string>();
            string parsedProperty;

            foreach (string property in i_VehicleProperties)
            {
                parsedProperty = property.Substring(2); //removing "m_" to make it readable to user
                Console.WriteLine("Please enter " + parsedProperty);
                vehicleDetails[property] = Console.ReadLine();
            }

            return vehicleDetails;
        }

        private void insertVehicleToGarage()
        {
            string vehicleType;
            string licensePlate;
            List<string> vehicleTypes = m_GarageManager.GetVehicleTypes();
            List<string> vehicleProperties;
            Dictionary<string,string> vehicleDetails;

            getLicensePlateFromUser(out licensePlate);

            if(m_GarageManager.IsVehicleInGarage(licensePlate))
            {
                Console.WriteLine("Vehicle exists! here is its data:");
                Console.WriteLine(m_GarageManager.GetVehicleData(licensePlate));
            }
            else
            {
                Console.WriteLine("Vehicle does not exist");
                Console.WriteLine("Please enter vehicle type(lowercase only) from the following collection:");
                foreach (string type in vehicleTypes)
                {
                    Console.WriteLine(type);
                }

                vehicleType = Console.ReadLine();
                vehicleProperties = m_GarageManager.GetPropertiesOfVehicle(vehicleType);
                vehicleDetails = setVehicleDetails(vehicleProperties);
                m_GarageManager.InsertVehicleToGarage(vehicleType, licensePlate, vehicleDetails);
            }
        }

        private void getListOfLicensePlates()
        {
            int userChoice;
            List<string> allLicensePlates;
            eVehicleCondition filterBy = default;

            Console.WriteLine("Please provide a filter between the following:");
            Console.WriteLine("1. In maintenance.{0}2. Fixed.{1}3. Payed for.{2}4. All", Environment.NewLine, Environment.NewLine, Environment.NewLine, Environment.NewLine);
            while (!int.TryParse(Console.ReadLine(), out userChoice) || !(userChoice >= 1 && userChoice <= 4))
            {
                Console.WriteLine("Invalid choice. Please choose between the following above.");
            }

            switch (userChoice)
            {
                case 1:
                    filterBy = eVehicleCondition.InMaintenance;
                    break;
                case 2:
                    filterBy = eVehicleCondition.Fixed;
                    break;
                case 3:
                    filterBy = eVehicleCondition.PayedFor;
                    break;
                default:
                    break;
            }

            if (userChoice == 1 || userChoice == 2 || userChoice == 3)
            {
                allLicensePlates = m_GarageManager.GetListOfLicensePlatesWithFilter(filterBy);
            }
            else
            {
                allLicensePlates = m_GarageManager.GetListOfLicensePlatesWithoutFilter();
            }

            System.Console.Clear();
            Console.WriteLine("Requested license plates:");
            foreach (string licensePlate in allLicensePlates)
            {
                Console.WriteLine("{0}", licensePlate);
            }
        }

        private string getLicensePlateFromUserInput()
        {
            string licensePlate;

            Console.WriteLine("Please provide the vehicle's license plate");
            licensePlate = Console.ReadLine();

            return licensePlate;
        }

        private void changeVehicleStatus()
        {
            string licensePlate;
            int userChoice;
            eVehicleCondition newCondition = default;
            licensePlate = getLicensePlateFromUserInput();

            Console.WriteLine("Please choose the new vehicle status from the following" +
                "{0}1. In maintenance{1}2. Fixed{2}3. Payed for.", Environment.NewLine, Environment.NewLine, Environment.NewLine);
            while (!int.TryParse(Console.ReadLine(), out userChoice) || !(userChoice >= 1 && userChoice <= 3))
            {
                Console.WriteLine("Invalid choice. Please provide a choice between the abouve mentioned");
            }

            switch (userChoice)
            {
                case 1:
                    newCondition = eVehicleCondition.InMaintenance;
                    break;
                case 2:
                    newCondition = eVehicleCondition.Fixed;
                    break;
                case 3:
                    newCondition = eVehicleCondition.PayedFor;
                    break;
            }

            m_GarageManager.ChangeVehicleCondition(licensePlate, newCondition);
            //try
            //{
            //    m_GarageManager.ChangeVehicleCondition(licensePlate, newCondition);
            //}
            //catch (Exception exception)
            //{
            //    throw new Exception(exception.Message);
            //}
        }

        private void pumpAllWheelsToMax()
        {
            string licensePlate = getLicensePlateFromUserInput();
            m_GarageManager.PumpWheelsToMax(licensePlate);
            Console.WriteLine("All wheels of vehicle with license plate {0} pumped to max", licensePlate);
        }

        private void fuelPetrolVehicle()
        {
            string licensePlate = getLicensePlateFromUserInput();
            float amountToFill;
            int petrolTypleByUser;
            ePetrolType petrolType = default;

            Console.WriteLine("Please enter petrol type:{0}1. Soler.{1}2. Octan95.{2}3. Octan96.{3}4. Octan98", Environment.NewLine, Environment.NewLine, Environment.NewLine, Environment.NewLine);
            while (!int.TryParse(Console.ReadLine(), out petrolTypleByUser) || !(petrolTypleByUser >= 1 && petrolTypleByUser <= 4))
            {
                Console.WriteLine("Invalid petrol type choice. Please choose between the above");
            }

            switch (petrolTypleByUser)
            {
                case 1:
                    petrolType = ePetrolType.Soler;
                    break;
                case 2:
                    petrolType = ePetrolType.Octan95;
                    break;
                case 3:
                    petrolType = ePetrolType.Octan96;
                    break;
                case 4:
                    petrolType = ePetrolType.Octan98;
                    break;
            }

            Console.WriteLine("Please type amount to fill");
            while (!float.TryParse(Console.ReadLine(), out amountToFill))
            {
                Console.WriteLine("Invalid filling format. Needs to be a number. Try again.");
            }

            m_GarageManager.AddEnergy(amountToFill, licensePlate, petrolType);
        }

        private void chargeElectricVehicle()
        {
            string licensePlate = getLicensePlateFromUserInput();
            float amountToFill;
            
            Console.WriteLine("Please type amount to fill");
            while (!float.TryParse(Console.ReadLine(), out amountToFill))
            {
                Console.WriteLine("Invalid filling format. Needs to be a number. Try again.");
            }

            m_GarageManager.AddEnergy(amountToFill, licensePlate);
        }

        private void getVehicleData()
        {
            string licensePlate = getLicensePlateFromUserInput();
            string vehicleData = m_GarageManager.GetVehicleData(licensePlate);

            Console.WriteLine("Vehicle Data: {0}{1}", Environment.NewLine, vehicleData);
        }
    }
}
