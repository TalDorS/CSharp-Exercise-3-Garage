using Ex03.GarageLogic;
using Ex03.GarageLogic.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.ConsoleUI
{
    public class UserInterface
    {
        //create a garage
        private Garage m_Garage = new Garage();
        private const int k_MinMenuOption = 1;
        private const int k_MaxMenuOption = 7;
        private const int k_MaxAmoutOfDoors = 5;
        private const int k_MinAmoutOfDoors = 2;
        private const int k_GetAllVehicles = -1;
        private const int k_MinInputValue = 1;
        private const int k_NumOfFuelOptions = 4;
        private const int k_NumOfVehicleTypes = 4;
        private const int k_LowercaseThreshold = 'a';

        private eUserAction displayMenuAndGetUserInput()
        {
            string menuToPrint = string.Format(
                @"The possible choices are:
1) Insert a vehicle
2) Display a list of all licenses numbers currently avaliable in the garage
3) Change the vehicle's state in garage
4) Inflate tyres to the maximum 
5) Fuel vehicle (for fuel based vehicles)
6) Charge vehicle (for electric vehicles)
7) Display vehicle info

Please choose an option: ({0} to {1})", k_MinMenuOption, k_MaxMenuOption);
            int userChoice = getAndValidateIntInRange(k_MinMenuOption, k_MaxMenuOption, menuToPrint);

            Console.Clear();

            return (eUserAction)userChoice;
        }
        private int getAndValidateIntInRange(int i_MinValue, int i_MaxValue, string i_MessageForUser)
        {
            Console.WriteLine(i_MessageForUser);

            return getAndValidateIntInRange(i_MinValue, i_MaxValue);
        }
        private int getAndValidateIntInRange(int i_MinValue, int i_MaxValue)
        {
            int inputNumber = -1;
            bool isValidInputNumber = false;

            while (!isValidInputNumber)
            {
                string inputString = getNonEmptyUserInput();
                bool isInputANumber = int.TryParse(inputString, out inputNumber);

                if (isInputANumber)
                {
                    bool isNumberInRange = (inputNumber >= i_MinValue) && (inputNumber <= i_MaxValue);

                    isValidInputNumber = isNumberInRange;
                }

                if (!isValidInputNumber)
                {
                    Console.Write(Environment.NewLine);
                    Console.WriteLine(@"Invalid input,
Please enter a number from {0} to {1}", i_MinValue, i_MaxValue);
                }
            }

            return inputNumber;
        }
        private float getAndValidateFloatInRange(float i_MinNumber, float i_MaxNumber, string i_Message)
        {
            float inputNumber = -1;
            bool isValidInputNumber = false;
            bool isANumber;

            Console.WriteLine(i_Message);

            while (!isValidInputNumber)
            {
                string inputString = getNonEmptyUserInput();
                isANumber = float.TryParse(inputString, out inputNumber);

                if (isANumber)
                {
                    bool isNumberInRange = inputNumber >= i_MinNumber && inputNumber <= i_MaxNumber;
                    isValidInputNumber = isNumberInRange;
                }

                if (!isValidInputNumber)
                {
                    Console.WriteLine(string.Format(@"Invalid input
Please enter a number from {0} to {1}: ", i_MinNumber, i_MaxNumber));
                }
            }

            return inputNumber;
        }
        private string getNonEmptyUserInput(string i_MessageForUser)
        {
            Console.WriteLine(i_MessageForUser);

            return getNonEmptyUserInput();
        }
        private string getNonEmptyUserInput()
        {
            string userInput = Console.ReadLine();

            while (userInput == string.Empty)
            {
                Console.Write(Environment.NewLine);
                Console.WriteLine(@"Invalid input, Input can't be empty, 
Please insert a new input");
                userInput = Console.ReadLine();
            }

            return userInput;
        }
        private string addSpacesBetweenStrings(string i_StringToSpace)
        {
            string spacedString = i_StringToSpace[0].ToString();

            for (int i = 1; i < i_StringToSpace.Length; i++)
            {
                if (i_StringToSpace[i] >= k_LowercaseThreshold)
                {
                    spacedString += string.Format("{0}", i_StringToSpace[i]);
                }
                else
                {
                    spacedString += string.Format(" {0}", i_StringToSpace[i]);
                }
            }

            return spacedString;
        }
        private string getOnlyDigitsString(string i_Message)
        {
            Console.WriteLine(i_Message);

            return getOnlyDigitsString();
        }
        private string getOnlyDigitsString()
        {
            string userInput = getNonEmptyUserInput();

            while (!isOnlyDigitInString(userInput))
            {
                Console.WriteLine(@"Invalid input
The input should only contain digits, please try again: ");
                userInput = getNonEmptyUserInput();
            }

            return userInput;
        }
        private bool isOnlyDigitInString(string i_UserInput)
        {
            return i_UserInput.All(Char.IsDigit);
        }
        private void promptUserToPressEnterToContinue()
        {
            Console.WriteLine("Press 'Enter' to continue");
            Console.ReadLine();
            Console.Clear();
        }
        private string licenseNumberToString(List<string> io_LicenseNumbers)
        {
            StringBuilder licenseNumbersToPrint = new StringBuilder();

            licenseNumbersToPrint.AppendLine("The current license numbers in the garage are: ");
            if (io_LicenseNumbers.Count != 0)
            {
                foreach (string licenseNumber in io_LicenseNumbers)
                {
                    licenseNumbersToPrint.AppendLine(licenseNumber);
                }
            }
            else
            {
                licenseNumbersToPrint.Append("There are no license numbers to display currently.");
            }

            return licenseNumbersToPrint.ToString();
        }
        private float getValidFloatNumber()
        {
            float inputNumberFromUser;
            bool isANumberInput;

            do
            {
                string input = getNonEmptyUserInput();

                isANumberInput = float.TryParse(input, out inputNumberFromUser);
                if (!isANumberInput)
                {
                    Console.WriteLine("Invalid input, please try again: ");
                }
            }
            while (!isANumberInput);

            return inputNumberFromUser;
        } 
        private void insertVehicle()
        {
            Console.WriteLine(@"Hello
Please enter the license number of the required vehicle: ");
            string licenseNumber = getNonEmptyUserInput();
            //check if number exists then change the state and print a message 
            if (m_Garage.IsCarInGarage(licenseNumber))// should be a method here to check is license plate already in system
            {
                int changeStatus = 1;
                int cancelOption = 2;
                int inputNumber = getAndValidateIntInRange(changeStatus, cancelOption, string.Format(
@"Vehicle with license number '{0}' is now changed to state: In Repairing",licenseNumber));
                //update state of vehicle

                m_Garage.ChangeVehicleState(licenseNumber, eVehicleStatus.InRepair); 
            }
            //if number doesnt exist continue to the create vehicle
            else
            {
                Vehicle newVehicle = createNewVehicle(licenseNumber);
                CustomerInfo newCustomer = createNewCustomer();
                m_Garage.InsertCarToGarage(newVehicle, newCustomer);
            }
        }
        private Vehicle createNewVehicle(string i_LicenseNumber)
        {
            int inputTypeOfVehicleNumber;
            string modelName;
            string wheelsManufacturer;
            float wheelsCurrentAirPressure;
            float currentEnergyLeft;
            List<Wheel> wheelsList;
            Vehicle newVehicle;

            // Get vehicle
            inputTypeOfVehicleNumber = getTypeOfVehicleNumber();
            newVehicle = VehicleCreator.CreateVehicle((eVehicleType)inputTypeOfVehicleNumber);
            newVehicle.LicenseNumber = i_LicenseNumber;
            // Vehicle model
            modelName = getNonEmptyUserInput("Please enter the vehicle's model name: ");
            newVehicle.ModelName = modelName;
            // Wheels
            wheelsManufacturer = getNonEmptyUserInput("Please enter the wheels manufacturer's name: ");
            wheelsCurrentAirPressure = getAndValidateFloatInRange(0, newVehicle.MaxWheelPressure, "Please enter the current air pressure of the wheels: ");
            wheelsList = VehicleCreator.CreateWheels(newVehicle.NumOfWheels, wheelsManufacturer, wheelsCurrentAirPressure, newVehicle.MaxWheelPressure);
            newVehicle.Wheels = wheelsList;
            // Energy and fuel
            currentEnergyLeft = getAndValidateFloatInRange(0, newVehicle.Engine.MaxAmountOfEnergy, "Please enter the amount of fuel/charging hours left for the vehicle: ");
            newVehicle.Engine.CurrentEnergy = currentEnergyLeft;
            // Extra vehicle features
            updateExtraVehicleFeatures(newVehicle);

            return newVehicle;
        }
        private CustomerInfo createNewCustomer()
        {
            string clientName = getNonEmptyUserInput("Please enter your name: ");
            string clientPhoneNumber = getOnlyDigitsString("Please enter your phone number: ");
            CustomerInfo clientInfo = new CustomerInfo(clientName, clientPhoneNumber);
          
            return clientInfo;
        }
        private int getTypeOfVehicleNumber()//function to print all vehicle options and get the option from the user
        {
            StringBuilder messageToPrint = new StringBuilder();
            int currentLocation = 1;
            int maxInputValue = Enum.GetValues(typeof(eVehicleType)).Length;

            Console.WriteLine("Please choose a vehicle type: ");

            foreach (eVehicleType currentType in Enum.GetValues(typeof(eVehicleType)))
            {
                messageToPrint.Append(string.Format(
@"  {0}) {1}{2}", currentLocation, addSpacesBetweenStrings(currentType.ToString()), Environment.NewLine));
                currentLocation++;
            }

            Console.WriteLine(messageToPrint);

            return getAndValidateIntInRange(k_MinInputValue, maxInputValue);
        }
        private void updateExtraVehicleFeatures(Vehicle io_Vehicle)
        {
            eVehicleType vehicleType = io_Vehicle.VehicleType;
            bool success = false;

            while (!success)
            {
                try
                {
                    switch (vehicleType)
                    {
                        case eVehicleType.ElectricCar:
                        case eVehicleType.FuelCar:
                            getAndValidateCarInfoFromUser(io_Vehicle as Car);
                            break;

                        case eVehicleType.Truck:
                            getAndValidateTruckInfoFromUser(io_Vehicle as Truck);
                            break;

                        case eVehicleType.FuelMotorcycle:
                        case eVehicleType.ElectricMotorcycle:
                            getMotorcycleInfoFromUser(io_Vehicle as Motorcycle);
                            break;
                    }
                    success = true; 
                }
                catch (ArgumentException argumentException)
                {
                    Console.WriteLine(argumentException.Message);
                    promptUserToPressEnterToContinue();
                }
                catch (ValueOutOfRangeException valueOutOfRange)
                {
                    Console.WriteLine(valueOutOfRange.Message);
                    promptUserToPressEnterToContinue();
                }
                catch (FormatException formatException)
                {
                    Console.WriteLine(formatException.Message);
                    promptUserToPressEnterToContinue();
                }
            }

            promptUserToPressEnterToContinue();
        }

        private void getAndValidateCarInfoFromUser(Car io_Car)
        {
            io_Car.SetCarColor(getCarColorFromUser());
            io_Car.SetNumOfDoors(getAmoutOfDoorsFromUser());
        }
        private void getAndValidateTruckInfoFromUser(Truck io_Track)
        {
            io_Track.SetDangerousMaterials(getIfTruckCarryingDangerousMaterialsFromUser());
            io_Track.SetCargoCapacity(getTruckCargoCapacityFromUser());
        }
        private void getMotorcycleInfoFromUser(Motorcycle io_Motorcycle)
        {
            io_Motorcycle.SetLicenseType(getLicenseTypeFromUser());
            io_Motorcycle.SetEngineCapacity(getMotorcycleEngineCapacityFromUser());
        }
        private string getCarColorFromUser()
        {
            StringBuilder messageToPrint = new StringBuilder();
            int currentLocation = 1;
            int maxInputValue = Enum.GetValues(typeof(eCarColor)).Length;
            string inputValueFromUser;

            Console.WriteLine("Please choose a car color: ");

            foreach (eCarColor currentType in Enum.GetValues(typeof(eCarColor)))
            {
                messageToPrint.Append(string.Format(
@"  {0}) {1}{2}", currentLocation, addSpacesBetweenStrings(currentType.ToString()), Environment.NewLine));
                currentLocation++;
            }

            Console.WriteLine(messageToPrint);
            inputValueFromUser = Console.ReadLine();

            return inputValueFromUser;
        }

        private string getAmoutOfDoorsFromUser()
        {
            string inputValueFromUser;

            Console.WriteLine(@"Please enter amount of car doors desired: 
(You can choose 2, 3, 4 or 5) ");
            inputValueFromUser = Console.ReadLine();

            return inputValueFromUser;

        }

        private string getTruckCargoCapacityFromUser()
        {
            string inputValueFromUser;

            Console.WriteLine("Please enter desired cargo capacity: ");
            inputValueFromUser = Console.ReadLine(); 

            return inputValueFromUser;
        }

        private string getIfTruckCarryingDangerousMaterialsFromUser()
        {
            string inputValueFromUser;

            Console.WriteLine(@"Please choose if the truck carries dangerous materials:
Choose 1 for carrying
Choose 0 for not carrying");
            inputValueFromUser = Console.ReadLine();

            return inputValueFromUser;
        }
        private string getLicenseTypeFromUser()
        {
            StringBuilder messageToPrint = new StringBuilder();
            int currentLocation = 1;
            string inputValueFromUser;

            Console.WriteLine("Please enter a License Type: ");

            foreach (eLicenseType currentType in Enum.GetValues(typeof(eLicenseType)))
            {
                messageToPrint.Append(string.Format(
@"  {0}) {1}{2}", currentLocation, addSpacesBetweenStrings(currentType.ToString()), Environment.NewLine));
                currentLocation++;
            }

            Console.WriteLine(messageToPrint);
            inputValueFromUser = Console.ReadLine();

            return inputValueFromUser;
        }

        private string getMotorcycleEngineCapacityFromUser()
        {
            string inputValueFromUser;

            Console.WriteLine("Please enter desired motorcycle engine capacity: ");
            inputValueFromUser = Console.ReadLine();

            return inputValueFromUser;
        }

        private void currentLicenseNumbersInGarage()
        {
            int maxInputValue = 4;
            int minInputValue = 1;
            string messageToPrint =
@"How would you like to filter the results:
1) Being repaired
2) Repair is done
3) Paid
4) No filter

Please choose an option (1 to 4):";
            int filterNumber = getAndValidateIntInRange(minInputValue, maxInputValue, messageToPrint);
            List<string> licenseNumbers;

            if (filterNumber >= maxInputValue)
            {
                licenseNumbers = m_Garage.GetLicenseListByVehicleState(k_GetAllVehicles);//method tal needs to do
            }
            else
            {
                licenseNumbers = m_Garage.GetLicenseListByVehicleState(filterNumber);
            }

            string licenseNumbersAsString = licenseNumberToString(licenseNumbers);

            Console.Clear();
            Console.WriteLine(licenseNumbersAsString);
            promptUserToPressEnterToContinue();
        }

        private bool isUserWantToCancel()
        {
            bool isUserNotDone;
            int maxInputValue = 2;
            int minInputValue = 1;
            string messageToPrint =
@"Would you like to try again or go back to the main menu:
1) Try again
2) Go back";

            int userInputNumber = getAndValidateIntInRange(minInputValue, maxInputValue, messageToPrint);

            if (userInputNumber == minInputValue)
            {
                isUserNotDone = true;
            }
            else
            {
                isUserNotDone = false;
            }

            return isUserNotDone;
        }

        private string getLicenseNumberInGarage()
        {
            string licenserNumber;
            bool isUserNotDone;
            bool isLicenseNumberInGarage;

            Console.WriteLine("Please enter the vehicle's license number: ");
            licenserNumber = getNonEmptyUserInput();
            isUserNotDone = true;
            isLicenseNumberInGarage = m_Garage.IsCarInGarage(licenserNumber);
            while (isUserNotDone && (!isLicenseNumberInGarage))
            {
                Console.WriteLine("This vehicle is not in the garage currently");
                isUserNotDone = isUserWantToCancel();
                if (isUserNotDone == false)
                {
                    licenserNumber = string.Empty;
                    break;
                }

                Console.WriteLine("Try again: ");
                licenserNumber = getNonEmptyUserInput();
                isLicenseNumberInGarage = m_Garage.IsCarInGarage(licenserNumber);
            }

            return licenserNumber;
        }

        private void changeVehicleStatus()
        {
            string licenseNumber = getLicenseNumberInGarage();
            string messageToPrint =
      @"The possible new states for the vehicle:
1) The vehicle is being repaired
2) The vehicle repair is done
3) Paid

Please choose an option (1 to 3): ";
            int userVehicleState = getAndValidateIntInRange(k_MinInputValue, k_NumOfVehicleTypes, messageToPrint);

            m_Garage.ChangeVehicleState(licenseNumber, (eVehicleStatus)userVehicleState);
        }

        private void inflateWheelsToMax()
        {
            string licenseNumber = getLicenseNumberInGarage();
            bool userWantToQuit;

            if (licenseNumber == string.Empty)
            {
                userWantToQuit = true;
            }
            else
            {
                userWantToQuit = false;
            }

            if (!userWantToQuit)
            {
                m_Garage.InflateWheelsToMax(licenseNumber);
            }
        }

        private void fuelVehicle()
        {
            string licenseNumber = getLicenseNumberInGarage();
            bool success = false;
            string messageToPrint =
        @"Please choose fuel type:
1) Soler
2) Octan 95
3) Octan 96
4) Octan 98

Please choose an option: ";

            while (!success)
            {
                try
                {
                    float amountOfFuel;
                    int fuelType = getAndValidateIntInRange(k_MinInputValue, k_NumOfFuelOptions, messageToPrint);

                    Console.WriteLine("How many liters of fuel would you want to add?");

                    amountOfFuel = getValidFloatNumber();
                    m_Garage.FuelVehicle(licenseNumber, (eFuelType)fuelType, amountOfFuel);
                    success = true; // Set success to true to exit the loop
                }
                catch (ArgumentException argumentException)
                {
                    Console.WriteLine(argumentException.Message);
                    promptUserToPressEnterToContinue();
                }
                catch (ValueOutOfRangeException valueOutOfRange)
                {
                    Console.WriteLine(valueOutOfRange.Message);
                    promptUserToPressEnterToContinue();
                }
            }
        }

        private void chargeVehicle()
        {
            string licenseNumber = getLicenseNumberInGarage();
            bool success = false;

            while (!success)
            {
                Console.WriteLine("How many minutes would you want to add? ");
                try
                {
                    float amountOfMinutesToCharge = getValidFloatNumber();
                    m_Garage.ChargeVehicle(licenseNumber, amountOfMinutesToCharge);
                    success = true; 
                }
                catch (ArgumentException argumentException)
                {
                    Console.WriteLine(argumentException.Message);
                    promptUserToPressEnterToContinue();
                }
                catch (ValueOutOfRangeException valueOutOfRange)
                {
                    Console.WriteLine(valueOutOfRange.Message);
                    promptUserToPressEnterToContinue();
                }
            }
        }

        private void showVehicleInfo()
        {
            string licenseNumber = getLicenseNumberInGarage();

            Console.WriteLine(m_Garage.VehicleInfoToString(licenseNumber));
            promptUserToPressEnterToContinue();
        }

        public void ManageGarage()
        {
            bool isExit = false;

            Console.WriteLine("Welcome To Our Garage!");
            while (!isExit)
            {
                switch (displayMenuAndGetUserInput())
                {
                    case eUserAction.InsertVehicle:
                        {
                            Console.Clear();
                            insertVehicle();
                            break;
                        }

                    case eUserAction.DisplayAllLicenseNumbers:
                        {
                            Console.Clear();
                            currentLicenseNumbersInGarage();
                            break;
                        }

                    case eUserAction.ChangeVehicleState:
                        {
                            Console.Clear();
                            changeVehicleStatus();
                            break;
                        }

                    case eUserAction.InflateTyersToMax:
                        {
                            Console.Clear();
                            inflateWheelsToMax();
                            break;
                        }

                    case eUserAction.FuelVehicle:
                        {
                            Console.Clear();
                            fuelVehicle();
                            break;
                        }

                    case eUserAction.ChargeVehicle:
                        {
                            Console.Clear();
                            chargeVehicle();
                            break;
                        }

                    case eUserAction.DisplayVehicle:
                        {
                            Console.Clear();
                            showVehicleInfo();
                            break;
                        }
                }

                Console.Clear();
            }
        }
    }
}
