using System;
using System.Collections.Generic;

namespace CarPooling
{
    class CarPoolUI
    {
        public static CarPool.VehicleDetails vehicleDetails = new CarPool.VehicleDetails();
        public static CarPool.PoolProviderDetails poolProviderDetails = new CarPool.PoolProviderDetails();
        public static CarPool.ShowAvailablePools showAvailablePools = new CarPool.ShowAvailablePools();
        private enum MainMenuAction : int
        {
            offerRide = 1,
            requestRide = 2,
            showRide = 3,
            exit = 4
        }

        private enum TypeOfVehicle : int
        {
            twoWheel = 2,
            fourWheel = 4
        }

        private static readonly string menuText =
            "1. Offer a ride.\n" +
            "2. Request a ride.\n" +
            "3. Show all rides.\n" +
            "4. Exit.";

        static void Main(string[] args)
        {
            do
            {
                Console.WriteLine(menuText);
                
                int userChoice;
                if (isValidInt(out userChoice))
                {
                    if (userChoice == (int)MainMenuAction.exit)
                    {
                        break;
                    }
                    
                    handleMainMenuAction((MainMenuAction)userChoice);
                }
                else
                {
                    Console.WriteLine("Entered input is not Valid.");
                }
            } while (true);
        }

        private static void handleMainMenuAction(MainMenuAction action)
        {
            if (poolProviderDetails.getList() == null)
            {
                return;
            }

            // Ensure that the enum is defined
            if (!Enum.IsDefined(typeof(MainMenuAction), action))
            {
                Console.WriteLine("Please select a valid option.");
                return;
            }

            switch (action)
            {
                case MainMenuAction.offerRide:
                    offerRide();
                    break;

                case MainMenuAction.requestRide:
                    requestRide();
                    break;

                case MainMenuAction.showRide:
                    showRides();
                    break;

                default:
                    Console.WriteLine("Invalid input");
                    break;
            }
        }

        private static void offerRide()
        {
            int typeOfVehicle;
            int seatsAvailableCount;
            Console.WriteLine("Source");
            string source = Console.ReadLine();
            Console.WriteLine("Destination");
            string destination = Console.ReadLine();
            bool vehicleTypeCheck = true;
            bool availableSeatCheck = true;

            do
            {
                Console.WriteLine("Type of vehicle \n 2. Two Wheeler \n 4. Four Wheeler");
                if (isValidInt(out typeOfVehicle))
                {
                    if(typeOfVehicle == 2 || typeOfVehicle == 4)
                        vehicleTypeCheck = false;
                    else
                        Console.WriteLine("Please enter 2 for Two Wheeler or 4 for Four Wheeler\n");
                }
                else
                {
                    Console.WriteLine("Invalid Input\n");
                }
            } while (vehicleTypeCheck);

            do
            {
                Console.WriteLine("Number of available seats");
                if (isValidInt(out seatsAvailableCount))
                {
                    if ((seatsAvailableCount > 0) && (typeOfVehicle - seatsAvailableCount > 0))
                        availableSeatCheck = false;
                    else
                        Console.WriteLine("Please enter correct information.\n");
                }
                else
                {
                    Console.WriteLine("Invalid Input\n");
                }
            } while (availableSeatCheck);

            int vehicleId = vehicleDetails.setVehicleDetails(typeOfVehicle, seatsAvailableCount);
            Console.WriteLine("vehicleId = {0}", vehicleId);

            Console.WriteLine("Name");
            string name = Console.ReadLine();
            Console.WriteLine("Phone");
            string phone = Console.ReadLine();
            Console.WriteLine("Gender");
            string gender = Console.ReadLine();

            poolProviderDetails.setPoolDetails(name, phone, gender, source, destination, vehicleId);
            
            Console.WriteLine("\nYour request has been posted\n");
        }

        private static void requestRide()
        {
            List<CarPool.PoolProviderDetailsStructure> poolPostList = poolProviderDetails.getList();
            if (poolPostList.Count > 0)
            {
                Console.WriteLine("Source");
                string source = Console.ReadLine();
                Console.WriteLine("Destination");
                string destination = Console.ReadLine();
                Console.WriteLine("Name");
                string name = Console.ReadLine();
                Console.WriteLine("Phone");
                string phone = Console.ReadLine();
                Console.WriteLine("Gender");
                string gender = Console.ReadLine();

                showAvailablePools.displayAvailablePools(source, destination, name, phone, gender);
            }
            else
                Console.WriteLine("Sorry, no pooling is available currently.\n");
        }

        private static void showRides()
        {
            List<CarPool.PoolProviderDetailsStructure> rideList = poolProviderDetails.getList();
            if(rideList.Count > 0)
            {
                foreach (CarPool.PoolProviderDetailsStructure ride in rideList)
                {
                    showAvailablePools.displayRiders(ride);
                }
            } else
            {
                Console.WriteLine("No Rides to show");
            }
        }

        public static bool isValidInt(out int input)
        {
            return int.TryParse(Console.ReadLine(), out input);
        }
    }
}
