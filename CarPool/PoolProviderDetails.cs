using System;
using System.Collections.Generic;
using System.Text;

namespace CarPool
{
    class PoolProviderDetails
    {
        public static List<PoolProviderDetailsStructure> poolPostList = new List<PoolProviderDetailsStructure>();

        public int setPoolDetails(string name, string phone, string gender, string source, string destination, int vehicle)
        {
            int id = poolPostList.Count;
            poolPostList.Add(new PoolProviderDetailsStructure { Id = id, Name = name, Phone = phone, Gender = gender, Source = source, Destination = destination, Riders = new List<int>(), Vehicle = vehicle });
            return id;
        }

        public List<PoolProviderDetailsStructure> getList()
        {
            return poolPostList;
        }
    }

    public class PoolProviderDetailsStructure
    {
        public int Id;
        public string Name;
        public string Phone;
        public string Gender;
        public string Source;
        public string Destination;
        public List<int> Riders;
        public int Vehicle;
    }
}
