using System;
using System.Collections.Generic;
using System.Text;

namespace CarPool
{
    class PoolProviderDetails
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public List<int> Riders { get; set; }
        public int Vehicle { get; set; }

        public static List<PoolProviderDetails> poolPostList = new List<PoolProviderDetails>();

        public int setPoolDetails(string name, string phone, string gender, string source, string destination, int vehicle)
        {
            int id = poolPostList.Count;
            poolPostList.Add(new PoolProviderDetails { Id = id, Name = name, Phone = phone, Gender = gender, Source = source, Destination = destination, Riders = new List<int>(), Vehicle = vehicle });
            return id;
        }

        public List<PoolProviderDetails> getList()
        {
            return poolPostList;
        }
    }
}
