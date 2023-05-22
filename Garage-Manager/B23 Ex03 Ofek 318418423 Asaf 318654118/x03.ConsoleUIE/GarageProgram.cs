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
        AddEnergy,
        GetVehicleData,        
    }

    public class GarageProgram
    {
        private GarageManager m_GarageManager;

        public void RunGarageApp()
        {
            int userChoice;
            m_GarageManager = new GarageManager();

            Console.WriteLine("Hello. Welcome to the garage app. Please choose one of the following options:{0}", Environment.NewLine);
            do
            {
                presentMenu();
                validateInput(out userChoice);
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
            msg += string.Format("4. Pump all vehicle wheels to max air pressure. {0}5. Add energy to vehicle(petrol/electric) {1}", Environment.NewLine, Environment.NewLine);
            msg += string.Format("6. Get vehicle data.{0}", Environment.NewLine);
        }

        private void validateInput(out int io_UserChoice)
        {
            while (!int.TryParse(Console.ReadLine(), out io_UserChoice) || !(io_UserChoice >= (int)eUserChoice.InsertVehicle && io_UserChoice <= (int)eUserChoice.Exit))
            {
                Console.WriteLine("Invalid choice. Please chooce once again.");
            }
        }

        private void makeProcessAccordingToUserChoice(int i_userChoice)
        {
            eUserChoice userInputInEnum = (eUserChoice)i_userChoice;
            switch (userInputInEnum)
            {
                case eUserChoice.InsertVehicle:
                    System.Console.Clear();
                    insertVehicleToGarage();
                    break;
                case eUserChoice.GetListOfLicensePlates:
                    System.Console.Clear();
                    getListOfLicensePlates();
                    break;
                case eUserChoice.ChangeVehicleStatus:
                    System.Console.Clear();
                    changeVehicleStatus();
                    break;
                case eUserChoice.PumpWheelsToMax:
                    System.Console.Clear();
                    pumpAllWheelsToMax();
                    break;
                case eUserChoice.AddEnergy:
                    System.Console.Clear();
                    addEnergy();
                    break;
                case eUserChoice.GetVehicleData:
                    System.Console.Clear();
                    getVehicleData();
                    break;
                case eUserChoice.Exit:
                    System.Console.Clear();
                    Console.WriteLine("Goodbye");
                    break;
            }
        }

        private void getLicensePlateFromUser(out string licensePlate)
        {
            Console.WriteLine("Please enter the vehicle's License plate");
            do
            {
                licensePlate = Console.ReadLine();
                if (!(licensePlate.Length > 0 && licensePlate.Length <= 8))
                {
                    Console.WriteLine("Invalid license plate! make sure its length is between 1 and 8. Try again");
                }
            }
            while (!(licensePlate.Length >= 0 && licensePlate.Length <= 8));
        }

        private Dictionary<string, string> setVehicleDetails(List<string> vehicleProperties)
        {
            Dictionary<string, string> vehicleDetails = new Dictionary<string, string>();
            string parsedProperty;

            foreach (string property in vehicleProperties)
            {
                parsedProperty = property.Substring(2); //removing "m_" to make it readable to user
                Console.WriteLine("Please enter " + parsedProperty);
                vehicleDetails[property] = Console.ReadLine();
            }

            Console.WriteLine("Please enter wheels' Manufacture Name");
            vehicleDetails["m_ManufactureName"] = Console.ReadLine();
            Console.WriteLine("Please enter wheels' Current Wheel Pressure");
            vehicleDetails["m_CurrentWheelPressure"] = Console.ReadLine();
            Console.WriteLine("Please enter wheels' Max Wheel Pressure");
            vehicleDetails["m_MaxWheelPressure"] = Console.ReadLine();

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
                foreach(string type in vehicleTypes)
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
            Console.WriteLine("1. In maintenance.{0}2. Fixed.{1}3. Payed for.{2}4. All");
            while(!int.TryParse(Console.ReadLine(), out userChoice) || !(userChoice >= 1 && userChoice <= 4))
            {
                Console.WriteLine("Invalid choice. Please choose between the following above.");
            }

            switch(userChoice)
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

            if(userChoice == 1 || userChoice == 2 || userChoice == 3)
            {
                allLicensePlates = m_GarageManager.GetListOfLicensePlatesWithFilter(filterBy);
            }
            else
            {
                allLicensePlates = m_GarageManager.GetListOfLicensePlatesWithoutFilter();
            }

            System.Console.Clear();
            Console.WriteLine("All license plates: {0}", Environment.NewLine);
            foreach(string licensePlate in allLicensePlates)
            {
                Console.WriteLine("{0}{1}", licensePlate, Environment.NewLine);
            }        
        }

        private void changeVehicleStatus()
        {
            string licensePlate;
            int userChoice;
            eVehicleCondition newCondition = default;

            Console.WriteLine("Please provide the vehicle's license plate");
            licensePlate = Console.ReadLine();
            Console.WriteLine("Please choose the new vehicle status from the following" +
                "{0}1. In maintenance{1}2. Fixed{2}3. Payed for.",Environment.NewLine, Environment.NewLine, Environment.NewLine);    
            while(!int.TryParse(Console.ReadLine(), out userChoice) || !(userChoice >= 1 && userChoice <=3))
            {
                Console.WriteLine("Invalid choice. Please provide a choice between the abouve mentioned {0}", Environment.NewLine);
            }

            switch(userChoice)
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

            try
            {
                m_GarageManager.ChangeVehicleCondition(licensePlate, newCondition);
            }
            catch(Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        private void pumpAllWheelsToMax()
        {

        }

        private void addEnergy()
        {

        }

        private void getVehicleData()
        {

        }
    }
}
