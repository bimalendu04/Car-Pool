using System;
using System.Collections.Generic;
using System.Text;

namespace CarPool
{
    class VehicleDetails
    {
        public VehicleList vehicleList = new VehicleList();
        public string vehicleId;
        public int typeOfVehicle;
        public int seatAvailable;

        public void setVehicle (int typeOfVehicle, int seatAvailable)
        {
            string vehicleListCount = vehicleList.getVehicleDetails().Count.ToString();
            vehicleList.setVehicleDetails(vehicleListCount, typeOfVehicle, seatAvailable);
            Console.WriteLine("{0} count", vehicleList.getVehicleDetails().Count.ToString());
        }

    }

    class VehicleList
    {
        public static List<VehicleListStructure> vehicleList = new List<VehicleListStructure>();
        vehicleList.Add(new VehicleListStructure { vehicleId = 0, typeOfVehicle = 2, seatAvailable = 1});
        public void setVehicleDetails (string id, int typeOfVehicle, int seatAvailable)
        {
            vehicleList.Add(new VehicleListStructure { vehicleId = id, typeOfVehicle = typeOfVehicle, seatAvailable = seatAvailable });
        }

        public List<VehicleListStructure> getVehicleDetails()
        {
            return vehicleList;
        }
    }

    internal class VehicleListStructure
    {
        public string vehicleId;
        public int typeOfVehicle;
        public int seatAvailable;
    }
}
