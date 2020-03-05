using System;
using System.Collections.Generic;
using System.Text;

namespace CarPool
{
    public class VehicleDetails
    {
        public int Id { get; set; }
        public int TypeOfVehicle { get; set; }
        public int SeatsAvailable { get; set; }

        public static List<VehicleDetails> vehicleList = new List<VehicleDetails>();

        public int setVehicleDetails(int typeOfVehicle, int seatsAvailable)
        {
            int id = vehicleList.Count + 1;
            vehicleList.Add(new VehicleDetails { Id = id, TypeOfVehicle = typeOfVehicle, SeatsAvailable = seatsAvailable });
            return id;
        }

        public List<VehicleDetails> getVehicleList()
        {
            return vehicleList;
        }
    }
}