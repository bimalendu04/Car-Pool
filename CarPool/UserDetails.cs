using System;
using System.Collections.Generic;
using System.Text;

namespace CarPool
{
    public class UserDetailsList
    {
        public static List<UserDetailsStructure> userList = new List<UserDetailsStructure>();

        public int setDetails(string name, string phone, string gender)
        {
            int id = userList.Count;
            userList.Add(new UserDetailsStructure { Id = id, Name = name, Phone = phone, Gender = gender });
            return id;
        }

        public List<UserDetailsStructure> getUserList()
        {
            return userList;
        }

        public UserDetailsStructure getUserDetails(int id)
        {
            Console.WriteLine("Data {0}", userList.Find(x => x.Id == id));
            return userList.Find(x => x.Id == id);
        }
        
    }

    public class UserDetailsStructure
    {
        public int Id;
        public string Name;
        public string Phone;
        public string Gender;
    }
}
