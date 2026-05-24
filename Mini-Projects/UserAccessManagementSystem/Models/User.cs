using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class User
    {


        public int UserID { get; set; }

        public string FullName { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Role { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? LastUpdatedAt { get; set; }

        public User(int UserId , string FulllName , string UserName , string Email , string PhoneNumber , string Role , bool IsActive , DateTime CreatedAt , DateTime? UpdatedAt)
        {

            this.UserID = UserId;
            this.FullName = FulllName;
            this.UserName = UserName;
            this.Email = Email;
            this.PhoneNumber = PhoneNumber;
            this.Role = Role;
            this.IsActive = IsActive;
            this.CreatedAt = CreatedAt;
            this.LastUpdatedAt = UpdatedAt;
            
        }

    }
}
