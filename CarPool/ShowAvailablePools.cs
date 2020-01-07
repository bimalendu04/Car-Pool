using System;
using System.Collections.Generic;
using System.Text;

namespace CarPool
{
    class ShowAvailablePools
    {
        public List<PoolProviderDetailsStructure> poolProviderDetailsList =  new PoolProviderDetails().getList();
        public List<VehicleDetailsStructure> vehicleDetailsList =  new List<VehicleDetailsStructure>();

        public void displayAvailablePools(string source, string destination, string name, string phone, string gender)
        {
            int availablePools = 0;
            List<int> indexOfAvailabePool = new List<int>();
            for (int i = 0; i < poolProviderDetailsList.Count; i++)
            {
                Console.WriteLine(vehicleDetailsList.Find(x => x.Id.Equals(poolProviderDetailsList[i].Vehicle)));
                if (poolProviderDetailsList[i].Source.ToLower() == source.ToLower() && poolProviderDetailsList[i].Destination.ToLower() == destination.ToLower() && vehicleDetailsList.Find(x => x.Id.Equals(poolProviderDetailsList[i].Vehicle)).SeatsAvailable > 0 && (vehicleDetailsList.Find(x => x.Id.Equals(poolProviderDetailsList[i].Vehicle)).SeatsAvailable - poolProviderDetailsList[i].Riders.Count > 0))
                {
                    availablePools = availablePools + 1;
                    indexOfAvailabePool.Add(i);
                    Console.WriteLine("\n{0}->", i);
                    displayRiders(poolProviderDetailsList[i]);
                }
            }

            if (availablePools > 0)
            {
                int poolRequest;
                Console.WriteLine("Enter the no. you want to ride with", availablePools);
                if (isValidInt(out poolRequest))
                {
                    if (indexOfAvailabePool.Contains(poolRequest))
                    {
                        poolProviderDetailsList[poolRequest].riders.Add(new Riders { name = name, phone = phone, gender = gender });
                        Console.WriteLine("\nYou have successfully booked a ride\n");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Input\n");
                }

            }
            else
                Console.WriteLine("Sorry {0}, no vehicle found for your route", name);
        }

        private static void displayRiders(PoolProviderDetailsStructure poolProviderDetails)
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
        }
    }

}
