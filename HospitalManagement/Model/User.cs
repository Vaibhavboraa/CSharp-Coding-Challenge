using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Model
{
    public class User
    {
        private int userId;
        private string username;
        private string password;
        private string userType;

        public int UserId
        {
            get { return userId; }
            set { userId = value; }
        }

        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public string UserType
        {
            get { return userType; }
            set { userType = value; }
        }

        public User()
        {
           
        }

        public User(int userId, string username, string password, string userType)
        {
            UserId = userId;
            Username = username;
            Password = password;
            UserType = userType;
        }

        public override string ToString()
        {
            return $"{Username} (ID: {UserId}, Type: {UserType})";
        }
    }
}
