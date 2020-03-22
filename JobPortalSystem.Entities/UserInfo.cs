using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortalSystem.Entities
{
    [Serializable]
    //<summary>UserInfo class to store all the details about user</summary>
    public class UserInfo
    {
        private int userId, age;
        private string password, firstName, lastName, gender, address, userType;
        private double phoneNo;

        public int UserId
        {
            get { return userId; }
            set { userId = value; }
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public double PhoneNo
        {
            get { return phoneNo; }
            set { phoneNo = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public string Gender
        {
            get { return gender; }
            set { gender = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public string UserType
        {
            get { return userType; }
            set { userType = value; }
        }

    }
}
