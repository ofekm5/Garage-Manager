using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ex03.GarageLogic;

namespace x03.ConsoleUIE
{
    public enum eUserChoice
    {
        InsertVehicle,
        GetListOfLicensePlates,
        ChangeVehicleStatus,
        PumpWheelsToMax,
        AddEnergy,
        GetVehicleData,
        Exit
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
                catch(FormatException formatException)
                {
                    Console.WriteLine(formatException.Message); 
                }
                catch(ArgumentException argumentException)
                {
                    Console.WriteLine(argumentException.Message);
                }
                catch(ValueOutOfRangeException valOutOfRangeException)
                {
                    Console.WriteLine(valOutOfRangeException.Message);
                }
                catch(Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
            } while (userChoice != (int)eUserChoice.Exit);
        }

        private void presentMenu()
        {
            string msg = string.Format("1. Insert new vehicle to the garage. {0}2. Get list of license plates {1}", Environment.NewLine, Environment.NewLine);

            msg += string.Format("3. Change vehicle condition.{0}4. Pump all vehicle wheels to max air pressure {1}", Environment.NewLine, Environment.NewLine);
            msg += string.Format("5. Add energy to vehicle(petrol/electric). {0}6. Get vehicle data {1}", Environment.NewLine, Environment.NewLine);
            msg += string.Format("7. Exit.{0}", Environment.NewLine);
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

        private void insertVehicleToGarage()
        {

        }

        private void getListOfLicensePlates()
        {
            Console.WriteLine("Please provide a filter between the following:");
            Console.WriteLine("1. In maintenance.{0}2. Fixed.{1}3. Payed for.{2}4. All");
            List<string> licensePlates = m_GarageManager.GetListOfLicensePlates()
        }

        private void changeVehicleStatus()
        {
            string licensePlate;

            Console.WriteLine("Please provide the vehicle's license plate");
            licensePlate = Console.ReadLine();
            Console.WriteLine("Please choose the new vehicle status from the following" +
                "{0}1. In maintenance{1}2. Fixed{2}3. Payed for.",Environment.NewLine, Environment.NewLine, Environment.NewLine);

            
           
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
