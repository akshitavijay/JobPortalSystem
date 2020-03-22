using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortalSystem.Entities
{
    //<summary>Admin class to store all the details about admin</summary>
    class Admin
    {
        private int adminId;
        private string password;

        public int AdminId
        {
            get { return adminId; }
            set { adminId = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }
    }
}
