using System;
using System.Collections.Generic;
using System.Text;

namespace CarPool
{
    public class UserDetailsList
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }

        public static List<UserDetailsList> userList = new List<UserDetailsList>();

        public int setDetails(string name, string phone, string gender)
        {
            int id = userList.Count;
            userList.Add(new UserDetailsList { Id = id, Name = name, Phone = phone, Gender = gender });
            return id;
        }

        public List<UserDetailsList> getUserList()
        {
            return userList;
        }

        public UserDetailsList getUserDetails(int id)
        {
            return userList.Find(x => x.Id == id);
        }
        
    }
}
