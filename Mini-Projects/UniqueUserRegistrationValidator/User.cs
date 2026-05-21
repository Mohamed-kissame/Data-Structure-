using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniqueUserRegistrationValidator
{
    public class User
    {

        public int ID { get; set; }

        public string FullName { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Role { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedAt { get; set; }


        public User(int Id , string FullName , string UserName , string Email , string PhoneNumber , string Role)
        {

            this.ID = Id;
            this.FullName = FullName;
            this.UserName = UserName;
            this.Email = Email;
            this.PhoneNumber = PhoneNumber;
            this.Role = Role;
            this.IsActive = true;
            this.CreatedAt = DateTime.Now;
            
        }


    }
}
