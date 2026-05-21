using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniqueUserRegistrationValidator
{
    public class UserRegistrationManager
    {


        private List<User> _users;
        private HashSet<string> _emails;
        private HashSet<string> _userName;
        private HashSet<string> _phoneNumber;
        private int _NextID;


        public UserRegistrationManager()
        {
            
            _users = new List<User>();
            _emails = new HashSet<string>();
            _userName = new HashSet<string>();
            _phoneNumber = new HashSet<string>();
            _NextID = 1;

        }

        private void PrintSet(HashSet<string> items)
        {
            if (items == null || items.Count == 0)
            {
                Console.WriteLine("No items");
                return;
            }

            foreach (string item in items)
            {
                Console.WriteLine($"- {item}");
            }
        }

        private bool IsValideFullName(string fullName)
        {
            return !string.IsNullOrWhiteSpace(fullName);
        }

        private bool IsValideUserName(string username)
        {
            return !string.IsNullOrWhiteSpace(username);
        }


        private bool IsValideEmail(string Email)
        {
            return !string.IsNullOrWhiteSpace(Email) && Email.Contains('@') && Email.Contains('.');
        }

        private bool IsValidePhoneNumber(string PhoneNumber)
        {
            return !string.IsNullOrWhiteSpace(PhoneNumber);
        }

        private bool IsValideRole(string Role)
        {
            return !string.IsNullOrWhiteSpace(Role);
        }

        private string Normalize(string Input)
        {
            return Input.Trim().ToLower();
        }


        private User FindUserByID(int ID)
        {

            for (int i = 0; i < _users.Count; i++)
            {

                if( _users[i].ID == ID)
                {
                    return _users[i];
                }

            }

            return null;

        }

        public void RegisterUser(string fullName, string username, string email, string phoneNumber, string role)
        {


            if(!IsValideFullName(fullName))
            {
                Console.WriteLine("Enter A valide FullName it should not be Empty");
                return;
            }

            if (!IsValideUserName(username))
            {
                Console.WriteLine("Enter A valide userName it should not be Empty");
                return;
            }

            if (!IsValideEmail(email))
            {
                Console.WriteLine("Enter A valide email it should not be Empty");
                return;
            }

            if (!IsValidePhoneNumber(phoneNumber))
            {
                Console.WriteLine("Enter A valide PhoneNumber it should not be Empty");
                return;
            }

            if (!IsValideRole(role))
            {
                Console.WriteLine("Enter A valide Role it should not be Empty");
                return;
            }

            fullName = fullName.Trim();
            username = username.Trim().ToLower();
            email = email.Trim().ToLower();
            phoneNumber = phoneNumber.Trim();
            role = role.Trim();

            if (!_emails.Add(email))
            {
                Console.WriteLine($"This Email {email} its alraedy exist you cannot add him again");
                return;
            }

            if(!_userName.Add(username))
            {
                Console.WriteLine($"This Username {username} its alraedy exist you cannot add him again");
                _emails.Remove(email);
                return;

            }


            if (!_phoneNumber.Add(phoneNumber))
            {
                Console.WriteLine($"This PhoneNumber {phoneNumber} its alraedy exist you cannot add him again");
                _userName.Remove(username);
                _emails.Remove(email);
                return;

            }

            User NewUser = new User(_NextID, fullName, username, email, phoneNumber, role);

            _users.Add(NewUser);

            _NextID++;

        }


        public bool IsEmailTaken(string email)
        {

            if (!IsValideEmail(email))
            {
                Console.WriteLine("Enter An Valide Email");
                return false;
            }

            email = Normalize(email);

            return _emails.Contains(email);

        }

        public bool IsUserNameTaken(string userName)
        {

            if (!IsValideUserName(userName))
            {
                Console.WriteLine("Enter An Valide userName");
                return false;
            }

            userName = Normalize(userName);

            return _userName.Contains(userName);

        }

        public bool IsPhoneTaken(string phone)
        {

            if (!IsValidePhoneNumber(phone))
            {
                Console.WriteLine("Enter An Valide Phone");
                return false;
            }

             phone =  phone.Trim();

            return _phoneNumber.Contains(phone);

        }

        public void DeactivateUser(int id)
        {

            User user = FindUserByID(id);


            if(user ==  null)
            {

                Console.WriteLine($"User With Id {id} not Found");
                return;

            }

            if(user.IsActive == false)
            {
                Console.WriteLine("The User it alraedy inactive");
                return;
            }

            user.IsActive = false;


        }

        public void DeleteUser(int id)
        {


            User user = FindUserByID(id);

            if(user != null)
            {

                _emails.Remove(user.Email);
                _userName.Remove(user.UserName);
                _phoneNumber.Remove(user.PhoneNumber);
                _users.Remove(user);

                return;
            }

            else
            {
                Console.WriteLine($"No user Found with this is id {id} to delete");

            }


        }

        public void ShowAllUsers()
        {
            if( _users.Count == 0 )
            {
                Console.WriteLine("No Users To Show");
                return;
            }

            Console.WriteLine("\t\tThe List Of users \t\t");

            Console.WriteLine("=============================================\n");

            foreach (User user in _users)
            {

                Console.WriteLine($"ID        : {user.ID}");
                Console.WriteLine($"Full Name : {user.FullName}");
                Console.WriteLine($"User Name : {user.UserName}");
                Console.WriteLine($"Email     : {user.Email}");
                Console.WriteLine($"Phone     : {user.PhoneNumber}");
                Console.WriteLine($"Role      : {user.Role}");
                Console.WriteLine($"Is Active : {(user.IsActive == true ? "Yes" : "No")}");
                Console.WriteLine($"Created At: {user.CreatedAt}");

                Console.WriteLine("------------------------------------\n");

            }


            Console.WriteLine("\n=============================================\n");

        }

        public void ShowActiveUsers()
        {

            List<User> ActiveUsers = _users.Where(u =>  u.IsActive).ToList();


            Console.WriteLine("\t\tThe List Of Active Users \t\t");

            Console.WriteLine("=============================================\n");

            foreach (User user in ActiveUsers)
            {

                Console.WriteLine($"ID        : {user.ID}");
                Console.WriteLine($"Full Name : {user.FullName}");
                Console.WriteLine($"User Name : {user.UserName}");
                Console.WriteLine($"Email     : {user.Email}");
                Console.WriteLine($"Phone     : {user.PhoneNumber}");
                Console.WriteLine($"Role      : {user.Role}");
                Console.WriteLine($"Is Active : {user.IsActive}");
                Console.WriteLine($"Created At: {user.CreatedAt}");

                Console.WriteLine("------------------------------------\n");

            }


            Console.WriteLine("\n=============================================\n");


        }

        public List<User> GetUsersByRole(string role)
        {

            if (!IsValideRole(role))
            {
                Console.WriteLine("Enter A valide Role");
                return null;
            }

            return _users.Where(u => string.Equals(u.Role, role, StringComparison.OrdinalIgnoreCase)).ToList();

        }

        public HashSet<string> GetCommonPermissions(HashSet<string> roleA, HashSet<string> roleB)
        {

            HashSet<string> common = new HashSet<string>(roleA);

             common.IntersectWith(roleB);

            return common;

        }


        public HashSet<string> GetMissingPermissions(HashSet<string> userPermissions, HashSet<string> requiredPermissions)
        {
            if (userPermissions == null || requiredPermissions == null)
            {
                Console.WriteLine("Permissions sets must not be null");
                return new HashSet<string>();
            }

            HashSet<string> missing = new HashSet<string>(requiredPermissions);

            missing.ExceptWith(userPermissions);

            return missing;
        }

        public bool HasAllRequiredPermissions(HashSet<string> userPermissions, HashSet<string> requiredPermissions)
        {
            if (userPermissions == null || requiredPermissions == null)
            {
                Console.WriteLine("Permissions sets must not be null");
                return false;
            }

            return requiredPermissions.IsSubsetOf(userPermissions);
        }

        public void CompareUserInterests(HashSet<string> userAInterests, HashSet<string> userBInterests)
        {
            if (userAInterests == null || userBInterests == null)
            {
                Console.WriteLine("Interest sets must not be null");
                return;
            }

            HashSet<string> commonInterests = new HashSet<string>(userAInterests);
            commonInterests.IntersectWith(userBInterests);

            HashSet<string> onlyUserAInterests = new HashSet<string>(userAInterests);
            onlyUserAInterests.ExceptWith(userBInterests);

            HashSet<string> onlyUserBInterests = new HashSet<string>(userBInterests);
            onlyUserBInterests.ExceptWith(userAInterests);

            HashSet<string> allUniqueInterests = new HashSet<string>(userAInterests);
            allUniqueInterests.UnionWith(userBInterests);

            Console.WriteLine("\n========== User Interests Comparison ==========\n");

            Console.WriteLine("Common Interests:");
            PrintSet(commonInterests);

            Console.WriteLine("\nOnly User A Interests:");
            PrintSet(onlyUserAInterests);

            Console.WriteLine("\nOnly User B Interests:");
            PrintSet(onlyUserBInterests);

            Console.WriteLine("\nAll Unique Interests:");
            PrintSet(allUniqueInterests);

            Console.WriteLine($"\nDo they overlap? {userAInterests.Overlaps(userBInterests)}");
            Console.WriteLine($"Are they exactly equal? {userAInterests.SetEquals(userBInterests)}");

            Console.WriteLine("\n===============================================\n");
        }


        public void ShowRegistrationStats()
        {

            Console.WriteLine("\t\tRegistration State\t\t");

            Console.WriteLine("=============================================\n");

            int TotalUsers = _users.Count;
            int ActiveUsers = _users.Count(u => u.IsActive);
            int InActiveUsers = _users.Count(u =>  !u.IsActive);
            int UNiqueEmailCount = _emails.Count;
            int UniqueUserNameCount = _userName.Count;
            int UniquePhoneCount = _phoneNumber.Count;
            int RoleCount = _users.Select(u => u.Role).Distinct().Count();


            Console.WriteLine($"Total Users            : {TotalUsers}");
            Console.WriteLine($"Total Active Users     : {ActiveUsers}");
            Console.WriteLine($"Total Inactive Users   : {InActiveUsers}");
            Console.WriteLine($"Total Unique Email     : {UNiqueEmailCount}");
            Console.WriteLine($"Total Unique UserName  : {UniqueUserNameCount}");
            Console.WriteLine($"Total Unique Phone     : {UniquePhoneCount}");
            Console.WriteLine($"Total Roles            : {RoleCount}");




        }

    }
}
