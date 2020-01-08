using System;
using System.Collections;
using System.Collections.Generic;

namespace CarPooling
{
    class Program
    {
        public static List<RideList> rideList = new List<RideList>();
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
                    
                    handleMainMenuAction((MainMenuAction)userChoice, rideList);
                }
                else
                {
                    Console.WriteLine("Entered input is not Valid.");
                }
            } while (true);
        }

        private static void handleMainMenuAction(MainMenuAction action, List<RideList> rideList)
        {
            if (rideList == null)
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

            Console.WriteLine("Name");
            string name = Console.ReadLine();
            Console.WriteLine("Phone");
            string phone = Console.ReadLine();
            Console.WriteLine("Gender");
            string gender = Console.ReadLine();

            poolProviderDetails.setPoolDetails(name, phone, gender, source, destination, vehicleId);


            //RideList pet = new RideList { source = source, destination = destination, typeOfVehicle = typeOfVehicle, seatsAvailableCount = seatsAvailableCount, riders = new List<Riders>(), name = name, phone = phone, gender = gender };
            //rideList.Add(pet);
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

        /*private static void displayAvailablePools(string source, string destination, string name, string phone, string gender)
        {
            int availablePools = 0;
            List<int> indexOfAvailabePool = new List<int>();
            for (int i = 0; i < rideList.Count; i++)
            {
                if (rideList[i].source.ToLower() == source.ToLower() && rideList[i].destination.ToLower() == destination.ToLower() && rideList[i].seatsAvailableCount > 0 && (rideList[i].seatsAvailableCount - rideList[i].riders.Count > 0))
                {
                    availablePools = availablePools + 1;
                    indexOfAvailabePool.Add(i);
                    Console.WriteLine("\n{0}->", i);
                    displayRiders(rideList[i]);
                }
            }

            if (availablePools > 0)
            {
                int poolRequest;
                Console.WriteLine("Enter the no. you want to ride with", availablePools);
                if (isValidInt(out poolRequest))
                {
                    if (indexOfAvailabePool.Contains(poolRequest)) {
                        rideList[poolRequest].riders.Add(new Riders { name = name, phone = phone, gender = gender});
                        Console.WriteLine("\nYou have successfully booked a ride\n");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Input\n");
                }

            } else
                Console.WriteLine("Sorry {0}, no vehicle found for your route", name);
        }*/


        private static void showRides()
        {
            if(rideList.Count > 0)
            {
                foreach (RideList ride in rideList)
                {
                    showAvailablePools. displayRiders(ride);
                }
            } else
            {
                Console.WriteLine("No Rides to show");
            }
        }

        public bool isValidInt(out int input)
        {
            return int.TryParse(Console.ReadLine(), out input);
        }

        /*private static void displayRiders(RideList ride)
        {
            Console.WriteLine("\nSource:{0}\n Destination:{1}\n Type of Vehicle:{2}\n Seats Available:{3}\n Name: {4}\n Phone:{5}\n Gender:{6}\n", ride.source, ride.destination, ride.typeOfVehicle == 2 ? "Two Wheeler" : "Four Wheeler", ride.seatsAvailableCount - ride.riders.Count, ride.name, ride.phone, ride.gender);
            if (ride.riders.Count > 0)
            {
                Console.WriteLine("Riders:");
                foreach (Riders rider in ride.riders)
                {
                    Console.WriteLine(" \n\tName: {0} \n\tPhone: {1} \n\tGender: {2}", rider.name, rider.phone, rider.gender);
                }
            }
        }*/
    }

    internal class RideList
    {
        public string source;
        public string destination;
        public int typeOfVehicle;
        public int seatsAvailableCount;
        public List<Riders> riders;
        public string name;
        public string phone;
        public string gender;
    }

    internal class Riders
    {
        public string name;
        public string phone;
        public string gender;
    }
}
