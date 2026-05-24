using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Models;

namespace BLL
{
    public class UserAccessManager
    {


        private List<User> _users;
        private Dictionary<int, User> _usersById;
        private Dictionary<string, User> _usersByEmail;
        private HashSet<string> _uniqueEmails;
        private HashSet<string> _uniqueUsernames;
        private Dictionary<string, HashSet<string>> _rolePermissions;


        public UserAccessManager()
        {
            _users = new List<User>();
            _usersById = new Dictionary<int, User>();
            _usersByEmail = new Dictionary<string, User>();
            _uniqueEmails = new HashSet<string>();
            _uniqueUsernames = new HashSet<string>();
            _rolePermissions = new Dictionary<string, HashSet<string>>(StringComparer.OrdinalIgnoreCase);
        }

        private void ClearUserCache()
        {

            _users.Clear();
            _usersById.Clear();
            _usersByEmail.Clear();
            _uniqueEmails.Clear();
            _uniqueUsernames.Clear();
           

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

        private bool IsValidPermission(string Permission)
        {
            return !string.IsNullOrWhiteSpace(Permission);
        }

        private bool IsValidPermissionSet(HashSet<string> Permissions)
        {
            return Permissions != null;
        }

        private bool IsNullOrEmptyUserList(List<User> users)
        {
            return users == null || users.Count == 0;
        }

        private bool IsUserValide(User user)
        {
            return user != null;
        }

        private bool IsValideFullName(string FullName)
        {
            return !string.IsNullOrWhiteSpace(FullName);
        }

        private bool IsValideUserName(string userName)
        {
            return !string.IsNullOrWhiteSpace(userName);
        }

        private bool IsValideEmail(string email)
        {
            return !string.IsNullOrWhiteSpace(email) &&  email.Contains("@") && email.Contains(".");
        }

        private bool IsValideRole(string Role)
        {
            return !string.IsNullOrWhiteSpace(Role);
        }

        public bool ValidateInputs(string FullName , string UserName , string Email , string Role)
        {

            return (IsValideFullName(FullName) && IsValideUserName(UserName) && IsValideEmail(Email) && IsValideRole(Role));

        }

        private string NormalizeData(string Data)
        {
            return Data.Trim();
        }


        public void LoadUsersFromDatabase()
        {

           List<User> users = UserRepository.GetAllUsers();

            ClearUserCache();

            if(IsNullOrEmptyUserList(users))
            {
                Console.WriteLine("No Users Exists in DataBase");
                return;

            }

      

            foreach(User user in users)
            {
                user.FullName = user.FullName.Trim();
                user.UserName = user.UserName.Trim().ToLower();
                user.Email = user.Email.Trim().ToLower();
                user.Role = user.Role.Trim();
              
                _users.Add(user);
                _usersById.Add(user.UserID, user);
                _usersByEmail.Add(user.Email, user);
                _uniqueEmails.Add(user.Email);
                _uniqueUsernames.Add(user.UserName);

            }


        }

        public void AddUser(User user)
        {

            if (!IsUserValide(user))
            {

                Console.WriteLine("The object of user is Empty");
                return;

            }

            if(!ValidateInputs(user.FullName , user.UserName , user.Email , user.Role))
            {

                Console.WriteLine("Incorrect Inputs Try to Enter A valide ones");
                return;

            }

            user.FullName = NormalizeData(user.FullName);
            user.UserName = NormalizeData(user.UserName).ToLower();
            user.Email = NormalizeData(user.Email).ToLower();
            user.Role = NormalizeData(user.Role);


            if (_uniqueEmails.Contains(user.Email))
            {
                Console.WriteLine($"You canoot Add this user because the email : {user.Email} its Already Exists");
                return;

            }

            if (_uniqueUsernames.Contains(user.UserName))
            {
                Console.WriteLine($"You canoot Add this user because the UserName : {user.UserName} its Already Exists");
                return;

            }

            int NewUserID = UserRepository.InsertUser(user);

            if (NewUserID != -1)
            {

                user.UserID = NewUserID;

                _users.Add(user);
                _usersById.Add(NewUserID, user);
                _usersByEmail.Add(user.Email, user);
                _uniqueEmails.Add(user.Email);
                _uniqueUsernames.Add(user.UserName);

                Console.WriteLine($"The Insertion is Successfully the NewId of user is : {NewUserID}");
            }
            else
            {
                Console.WriteLine("Insertion failed");
            }


        }

        public User GetUserByIdFromCache(int userId)
        {

            if(userId <= 0) { return null; }


            if(_usersById.TryGetValue(userId , out User user))
            {
                return user;
            }

            return null;

        }

        public User GetUserByEmailFromCache(string email)
        {

            if (!IsValideEmail(email)) { return null; }

            email = NormalizeData(email).ToLower();

            if (_usersByEmail.TryGetValue(email, out User user))
            {
                return user;
            }

            return null;

        }

        public bool IsEmailTaken(string email)
        {
            if (!IsValideEmail(email)) { return false; }

            email = NormalizeData(email).ToLower();

            return _uniqueEmails.Contains(email);


        }

        public bool IsUsernameTaken(string username)
        {

            if (!IsValideUserName(username)) { return false; }

            username = NormalizeData(username).ToLower();

            return _uniqueUsernames.Contains(username);


        }

        public void UpdateUserRole(int userId, string newRole)
        {

            User user = null;

            if(!IsValideRole(newRole))
            {
                Console.WriteLine("Enter A valide Role");
                return;
            }


            user = GetUserByIdFromCache(userId);

            if (user == null)
            {

                Console.WriteLine($"No User Found with this ID {userId}");
                return;
            }

            newRole = NormalizeData(newRole);

            bool Success = UserRepository.UpdateUserRole(userId, newRole);

            if (Success)
            {

                user.Role = newRole;
                user.LastUpdatedAt = DateTime.Now;

            }
            else
            {
                Console.WriteLine("Update Failed");

            }



        }

        public void UpdateUserEmail(int userId, string newEmail)
        {
            if(userId <= 0)
            {
                Console.WriteLine($"The user ID must be greater than Zero");
                return;
            }

            if (!IsValideEmail(newEmail))
            {
                Console.WriteLine("Enter A Valide Email");
                return;
            }

            User user = GetUserByIdFromCache(userId);

            if(user == null)
            {
                Console.WriteLine($"No User Found with this ID {userId}");
                return;
            }

            newEmail = NormalizeData(newEmail).ToLower();

            if (string.Equals(user.Email, newEmail, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("No need to update because you are already using this email");
                return;
            }

            if (IsEmailTaken(newEmail))
            {
                Console.WriteLine($"This email {newEmail} already exists");
                return;
            }

            bool Success = UserRepository.UpdateUserEmail(userId, newEmail);

            if (Success)
            {

                _uniqueEmails.Remove(user.Email);
                _usersByEmail.Remove(user.Email);
                user.Email = newEmail;
                _uniqueEmails.Add(newEmail);
                _usersByEmail.Add(newEmail, user);
                user.LastUpdatedAt = DateTime.Now;
                
            }
            else
            {
                Console.WriteLine("Update Failed");
            }


        }

        public void DeactivateUser(int userId)
        {

            if (userId <= 0)
            {
                Console.WriteLine($"The user ID must be greater than Zero");
                return;
            }

            User user = GetUserByIdFromCache(userId);

            if(user == null)
            {
                Console.WriteLine($"No User Found with this ID {userId}");
                return;
            }

            if(user.IsActive == false)
            {
                Console.WriteLine("This user is already inactive");
                return;
            }

            bool success = UserRepository.DeactivateUser(userId);

            if (success)
            {
                user.IsActive = false;
                user.LastUpdatedAt = DateTime.Now;

            }
            else
            {
                Console.WriteLine($"Deactive User by ID : {userId} is Failed");

            }
        }

        public void DeleteUser(int userId)
        {
            if (userId <= 0)
            {
                Console.WriteLine($"The user ID must be greater than Zero");
                return;
            }

            User user = GetUserByIdFromCache(userId);

            if(user == null)
            {
                Console.WriteLine($"No User Found with this ID {userId}");
                return;
            }

            bool Success = UserRepository.DeleteUser(user.UserID);

            if (Success)
            {

                _users.Remove(user);
                _usersById.Remove(userId);
                _usersByEmail.Remove(user.Email);
                _uniqueEmails.Remove(user.Email);
                _uniqueUsernames.Remove(user.UserName);
                
            }
            else
            {
                Console.WriteLine($"The user with id {userId} is failed to delete");
            }

        }

        public void InitializeDefaultRolePermissions()
        {
            _rolePermissions.Clear();

            _rolePermissions.Add("Admin", new HashSet<string>(StringComparer.OrdinalIgnoreCase)
             {
               "ViewUsers",
                "AddUser",
                 "EditUser",
                  "DeleteUser",
                "ExportUsers"
             });

            _rolePermissions.Add("Manager", new HashSet<string>(StringComparer.OrdinalIgnoreCase)
               {
                 "ViewUsers",
                 "AddUser",
                  "EditUser"
               });

            _rolePermissions.Add("User", new HashSet<string>(StringComparer.OrdinalIgnoreCase)
            {
                "ViewUsers"
             });

            _rolePermissions.Add("Guest", new HashSet<string>(StringComparer.OrdinalIgnoreCase)
              {
              "ViewUsers"
               });
        }

        public bool HasPermission(string role, string permission)
        {
            if (!IsValideRole(role))
            {
                Console.WriteLine("Enter a valid role.");
                return false;
            }

            if (!IsValidPermission(permission))
            {
                Console.WriteLine("Enter a valid permission.");
                return false;
            }

            role = role.Trim();
            permission = permission.Trim();

            if (!_rolePermissions.TryGetValue(role, out HashSet<string> permissions))
            {
                Console.WriteLine($"Role '{role}' was not found.");
                return false;
            }

            return permissions.Contains(permission);
        }

        public bool HasAllRequiredPermissions(string role, HashSet<string> requiredPermissions)
        {
            if (!IsValideRole(role))
            {
                Console.WriteLine("Enter a valid role.");
                return false;
            }

            if (!IsValidPermissionSet(requiredPermissions))
            {
                Console.WriteLine("Required permissions must not be null.");
                return false;
            }

            role = role.Trim();

            if (!_rolePermissions.TryGetValue(role, out HashSet<string> rolePermissions))
            {
                Console.WriteLine($"Role '{role}' was not found.");
                return false;
            }

            return requiredPermissions.IsSubsetOf(rolePermissions);
        }

        public HashSet<string> GetMissingPermissions(string role, HashSet<string> requiredPermissions)
        {
            if (!IsValideRole(role))
            {
                Console.WriteLine("Enter a valid role.");
                return new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            }

            if (!IsValidPermissionSet(requiredPermissions))
            {
                Console.WriteLine("Required permissions must not be null.");
                return new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            }

            role = role.Trim();

            if (!_rolePermissions.TryGetValue(role, out HashSet<string> rolePermissions))
            {
                Console.WriteLine($"Role '{role}' was not found.");
                return new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            }

            HashSet<string> missingPermissions =
                new HashSet<string>(requiredPermissions, StringComparer.OrdinalIgnoreCase);

            missingPermissions.ExceptWith(rolePermissions);

            return missingPermissions;
        }

        public void CompareRoles(string roleA, string roleB)
        {
            if (!IsValideRole(roleA) || !IsValideRole(roleB))
            {
                Console.WriteLine("Both roles must be valid.");
                return;
            }

            roleA = roleA.Trim();
            roleB = roleB.Trim();

            if (!_rolePermissions.TryGetValue(roleA, out HashSet<string> permissionsA))
            {
                Console.WriteLine($"Role '{roleA}' was not found.");
                return;
            }

            if (!_rolePermissions.TryGetValue(roleB, out HashSet<string> permissionsB))
            {
                Console.WriteLine($"Role '{roleB}' was not found.");
                return;
            }

            HashSet<string> commonPermissions =
                new HashSet<string>(permissionsA, StringComparer.OrdinalIgnoreCase);
            commonPermissions.IntersectWith(permissionsB);

            HashSet<string> onlyRoleAPermissions =
                new HashSet<string>(permissionsA, StringComparer.OrdinalIgnoreCase);
            onlyRoleAPermissions.ExceptWith(permissionsB);

            HashSet<string> onlyRoleBPermissions =
                new HashSet<string>(permissionsB, StringComparer.OrdinalIgnoreCase);
            onlyRoleBPermissions.ExceptWith(permissionsA);

            HashSet<string> allUniquePermissions =
                new HashSet<string>(permissionsA, StringComparer.OrdinalIgnoreCase);
            allUniquePermissions.UnionWith(permissionsB);

            Console.WriteLine($"\n========== Comparing {roleA} With {roleB} ==========\n");

            Console.WriteLine("Common Permissions:");
            PrintSet(commonPermissions);

            Console.WriteLine($"\nOnly {roleA} Permissions:");
            PrintSet(onlyRoleAPermissions);

            Console.WriteLine($"\nOnly {roleB} Permissions:");
            PrintSet(onlyRoleBPermissions);

            Console.WriteLine("\nAll Unique Permissions:");
            PrintSet(allUniquePermissions);

            Console.WriteLine($"\nDo they overlap? {permissionsA.Overlaps(permissionsB)}");
            Console.WriteLine($"Are they equal? {permissionsA.SetEquals(permissionsB)}");
            Console.WriteLine($"{roleA} is subset of {roleB}? {permissionsA.IsSubsetOf(permissionsB)}");
            Console.WriteLine($"{roleA} is proper subset of {roleB}? {permissionsA.IsProperSubsetOf(permissionsB)}");
            Console.WriteLine($"{roleA} is superset of {roleB}? {permissionsA.IsSupersetOf(permissionsB)}");
            Console.WriteLine($"{roleA} is proper superset of {roleB}? {permissionsA.IsProperSupersetOf(permissionsB)}");

            Console.WriteLine("\n====================================================\n");
        }

        public List<User> GetActiveUsers()
        {
            return _users
                .Where(u => u.IsActive)
                .ToList();
        }

        public List<User> GetUsersByRole(string role)
        {
            if (!IsValideRole(role))
            {
                Console.WriteLine("Enter a valid role.");
                return new List<User>();
            }

            role = role.Trim();

            return _users
                .Where(u => string.Equals(u.Role, role, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        public List<User> GetUsersSortedByName()
        {
            return _users
                .OrderBy(u => u.FullName)
                .ToList();
        }

        public void ShowUsers(List<User> users)
        {
            if (users == null || users.Count == 0)
            {
                Console.WriteLine("No users to show.");
                return;
            }

            Console.WriteLine("\n==================== USERS ====================\n");

            foreach (User user in users)
            {
                Console.WriteLine($"User ID       : {user.UserID}");
                Console.WriteLine($"Full Name     : {user.FullName}");
                Console.WriteLine($"Username      : {user.UserName}");
                Console.WriteLine($"Email         : {user.Email}");
                Console.WriteLine($"Phone Number  : {user.PhoneNumber}");
                Console.WriteLine($"Role          : {user.Role}");
                Console.WriteLine($"Is Active     : {(user.IsActive ? "Yes" : "No")}");
                Console.WriteLine($"Created At    : {user.CreatedAt}");

                if (user.LastUpdatedAt.HasValue)
                {
                    Console.WriteLine($"Last Updated  : {user.LastUpdatedAt.Value}");
                }
                else
                {
                    Console.WriteLine("Last Updated  : No update");
                }

                Console.WriteLine("\n------------------------------------------------\n");
            }

            Console.WriteLine("================================================\n");
        }

        public void ShowStatistics()
        {
            if (_users.Count == 0)
            {
                Console.WriteLine("No user statistics available.");
                return;
            }

            int totalUsers = _users.Count;
            int activeUsers = _users.Count(u => u.IsActive);
            int inactiveUsers = _users.Count(u => !u.IsActive);
            int uniqueEmailsCount = _uniqueEmails.Count;
            int uniqueUsernamesCount = _uniqueUsernames.Count;

            int distinctRolesCount = _users
                .Select(u => u.Role)
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .Count();

            var usersGroupedByRole = _users
                .GroupBy(u => u.Role, StringComparer.OrdinalIgnoreCase)
                .OrderBy(g => g.Key)
                .ToList();

            Console.WriteLine("\n=============== USER STATISTICS ===============\n");

            Console.WriteLine($"Total Users                  : {totalUsers}");
            Console.WriteLine($"Active Users                 : {activeUsers}");
            Console.WriteLine($"Inactive Users               : {inactiveUsers}");
            Console.WriteLine($"Unique Emails Count          : {uniqueEmailsCount}");
            Console.WriteLine($"Unique Usernames Count       : {uniqueUsernamesCount}");
            Console.WriteLine($"Distinct Roles Count         : {distinctRolesCount}");
            Console.WriteLine($"Configured Permission Roles  : {_rolePermissions.Count}");

            Console.WriteLine("\nUsers Grouped By Role:");
            Console.WriteLine("------------------------------------------------");

            foreach (var roleGroup in usersGroupedByRole)
            {
                Console.WriteLine($"{roleGroup.Key} : {roleGroup.Count()} user(s)");
            }

            Console.WriteLine("\nMemory Collection Counts:");
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine($"List<User> Count              : {_users.Count}");
            Console.WriteLine($"Dictionary By ID Count        : {_usersById.Count}");
            Console.WriteLine($"Dictionary By Email Count     : {_usersByEmail.Count}");
            Console.WriteLine($"HashSet Emails Count          : {_uniqueEmails.Count}");
            Console.WriteLine($"HashSet Usernames Count       : {_uniqueUsernames.Count}");

            Console.WriteLine("\n================================================\n");
        }

        public void CompareDatabaseVsMemoryCount()
        {
            int databaseUsersCount = UserRepository.GetUsersCount();

            if (databaseUsersCount == -1)
            {
                Console.WriteLine("Could not read the users count from the database.");
                return;
            }

            int usersListCount = _users.Count;
            int usersByIdCount = _usersById.Count;
            int usersByEmailCount = _usersByEmail.Count;
            int uniqueEmailsCount = _uniqueEmails.Count;
            int uniqueUsernamesCount = _uniqueUsernames.Count;

            Console.WriteLine("\n========== DATABASE VS MEMORY CHECK ==========\n");

            Console.WriteLine($"Database Users Count      : {databaseUsersCount}");
            Console.WriteLine($"List<User> Count          : {usersListCount}");
            Console.WriteLine($"Dictionary By ID Count    : {usersByIdCount}");
            Console.WriteLine($"Dictionary By Email Count : {usersByEmailCount}");
            Console.WriteLine($"HashSet Emails Count      : {uniqueEmailsCount}");
            Console.WriteLine($"HashSet Usernames Count   : {uniqueUsernamesCount}");

            bool allSynchronized =
                databaseUsersCount == usersListCount &&
                usersListCount == usersByIdCount &&
                usersByIdCount == usersByEmailCount &&
                usersByEmailCount == uniqueEmailsCount &&
                uniqueEmailsCount == uniqueUsernamesCount;

            Console.WriteLine("\n----------------------------------------------");

            if (allSynchronized)
            {
                Console.WriteLine("Database and memory collections are synchronized.");
            }
            else
            {
                Console.WriteLine("A synchronization mismatch was detected.");

                if (databaseUsersCount != usersListCount)
                {
                    Console.WriteLine($"- Database and List<User> differ by {Math.Abs(databaseUsersCount - usersListCount)} user(s).");
                }

                if (usersListCount != usersByIdCount)
                {
                    Console.WriteLine($"- List<User> and Dictionary<int, User> differ by {Math.Abs(usersListCount - usersByIdCount)} user(s).");
                }

                if (usersListCount != usersByEmailCount)
                {
                    Console.WriteLine($"- List<User> and Dictionary<string, User> differ by {Math.Abs(usersListCount - usersByEmailCount)} user(s).");
                }

                if (usersListCount != uniqueEmailsCount)
                {
                    Console.WriteLine($"- List<User> and unique email HashSet differ by {Math.Abs(usersListCount - uniqueEmailsCount)} value(s).");
                }

                if (usersListCount != uniqueUsernamesCount)
                {
                    Console.WriteLine($"- List<User> and unique username HashSet differ by {Math.Abs(usersListCount - uniqueUsernamesCount)} value(s).");
                }
            }

            Console.WriteLine("\n==============================================\n");
        }

        public void RefreshAllUsersFromDatabase()
        {
            LoadUsersFromDatabase();
            Console.WriteLine("Users memory cache was refreshed from the database.");
        }
    }
}
