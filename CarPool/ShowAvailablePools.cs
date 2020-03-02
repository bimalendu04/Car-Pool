using System;
using System.Collections.Generic;
using System.Text;

namespace CarPool
{
    class ShowAvailablePools
    {
        public List<PoolProviderDetailsStructure> poolProviderDetailsList =  new PoolProviderDetails().getList();
        public List<UserDetailsStructure> userDetailsList =  new UserDetailsList().getUserList();
        public UserDetailsList userDetails = new UserDetailsList();
        public List<VehicleDetailsStructure> vehicleDetailsList =  new VehicleDetails().getVehicleList();
        public CarPooling.CarPoolUI carPoolUI = new CarPooling.CarPoolUI();
        public void displayAvailablePools(string source, string destination, string name, string phone, string gender)
        {
            int availablePools = 0;
            List<int> indexOfAvailabePool = new List<int>();
            for (int i = 0; i < poolProviderDetailsList.Count; i++)
            {
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
                if (CarPooling.CarPoolUI.isValidInt(out poolRequest))
                {
                    if (indexOfAvailabePool.Contains(poolRequest))
                    {
                        int userId = userDetails.setDetails(name, phone, gender);
                        poolProviderDetailsList[poolRequest].Riders.Add(userId);
                            //.riders.Add(new Riders { name = name, phone = phone, gender = gender });
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

        public void displayRiders(PoolProviderDetailsStructure poolProviderDetails)
        {
            Console.WriteLine("\n Source:{0}\n Destination:{1}\n Type of Vehicle:{2}\n Seats Available:{3}\n Name: {4}\n Phone:{5}\n Gender:{6}\n", poolProviderDetails.Source, poolProviderDetails.Destination, vehicleDetailsList.Find(x => x.Id.Equals(poolProviderDetails.Vehicle)).TypeOfVehicle == 2 ? "Two Wheeler" : "Four Wheeler", vehicleDetailsList.Find(x => x.Id.Equals(poolProviderDetails.Vehicle)).SeatsAvailable - poolProviderDetails.Riders.Count, poolProviderDetails.Name, poolProviderDetails.Phone, poolProviderDetails.Gender);
            if (poolProviderDetails.Riders.Count > 0)
            {
                Console.WriteLine("Riders:");
                foreach (int rider in poolProviderDetails.Riders)
                {
                    UserDetailsStructure user = userDetails.getUserDetails(rider);
                    Console.WriteLine(" \n\tName: {0} \n\tPhone: {1} \n\tGender: {2}", user.Name, user.Phone, user.Gender);
                }
            }
        }
    }

}
