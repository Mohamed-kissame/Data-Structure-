using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegacyUserSessionManager
{
    internal class UserSession
    {

        public string UserName { get; set; }

        public string Role { get; set; }

        public DateTime LoginTime { get; set; }

        public DateTime LastActivity { get; set; }

        public bool IsActive { get; set; }


        public UserSession(string username , string Role)
        {

            this.UserName = username;
            this.Role = Role;
            this.LoginTime = DateTime.Now;
            this.LastActivity = DateTime.Now;
            this.IsActive = true;
            
        }
    }
}
