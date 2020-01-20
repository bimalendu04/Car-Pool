using System;
using System.Collections.Generic;
using System.Text;

namespace CarPool
{
    public class VehicleDetails
    {
        public static List<VehicleDetailsStructure> vehicleList = new List<VehicleDetailsStructure>();

        public int setVehicleDetails(int typeOfVehicle, int seatsAvailable)
        {
            int id = vehicleList.Count + 1;
            vehicleList.Add(new VehicleDetailsStructure { Id = id, TypeOfVehicle = typeOfVehicle, SeatsAvailable = seatsAvailable });
            return id;
        }

        public List<VehicleDetailsStructure> getVehicleList()
        {
            return vehicleList;
        }
    }

    public class VehicleDetailsStructure
    {
        public int Id;
        public int TypeOfVehicle;
        public int SeatsAvailable;
    }
}