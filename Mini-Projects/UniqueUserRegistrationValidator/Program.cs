using System;
using System.Collections.Generic;

namespace UniqueUserRegistrationValidator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UserRegistrationManager manager = new UserRegistrationManager();

            Console.WriteLine("========== 1. Register 5 Valid Users ==========\n");

            manager.RegisterUser("Mohamed Kissame", "mohamed", "mohamed@gmail.com", "0600000001", "Admin");
            manager.RegisterUser("Sara Alami", "sara", "sara@gmail.com", "0600000002", "Manager");
            manager.RegisterUser("Ali Ben", "ali", "ali@gmail.com", "0600000003", "User");
            manager.RegisterUser("Youssef Amrani", "youssef", "youssef@gmail.com", "0600000004", "User");
            manager.RegisterUser("Omar Idrissi", "omar", "omar@gmail.com", "0600000005", "Guest");

            Console.WriteLine("\n========== 2. Try Duplicate Email ==========\n");
            manager.RegisterUser("Fake User", "fakeuser", "mohamed@gmail.com", "0600000010", "User");

            Console.WriteLine("\n========== 3. Try Duplicate Username ==========\n");
            manager.RegisterUser("Another User", "sara", "another@gmail.com", "0600000011", "User");

            Console.WriteLine("\n========== 4. Try Duplicate Phone ==========\n");
            manager.RegisterUser("Phone Duplicate", "phoneuser", "phoneuser@gmail.com", "0600000003", "User");

            Console.WriteLine("\n========== 5. Try Invalid FullName ==========\n");
            manager.RegisterUser("", "badname", "badname@gmail.com", "0600000012", "User");

            Console.WriteLine("\n========== 6. Try Invalid Email ==========\n");
            manager.RegisterUser("Bad Email", "bademail", "bademail", "0600000013", "User");

            Console.WriteLine("\n========== 7. Show All Users ==========\n");
            manager.ShowAllUsers();

            Console.WriteLine("\n========== 8. Show Active Users ==========\n");
            manager.ShowActiveUsers();

            Console.WriteLine("\n========== 9. Deactivate User ID 3 ==========\n");
            manager.DeactivateUser(3);

            Console.WriteLine("\n========== 10. Try Deactivating Same User Again ==========\n");
            manager.DeactivateUser(3);

            Console.WriteLine("\n========== 11. Show Active Users After Deactivation ==========\n");
            manager.ShowActiveUsers();

            Console.WriteLine("\n========== 12. Delete User ID 4 ==========\n");
            manager.DeleteUser(4);

            Console.WriteLine("\n========== 13. Try Deleting Missing User ==========\n");
            manager.DeleteUser(99);

            Console.WriteLine("\n========== 14. Register Again With Deleted User Email ==========\n");
            manager.RegisterUser("New Youssef", "newyoussef", "youssef@gmail.com", "0600000099", "User");

            Console.WriteLine("\n========== 15. Show Users By Role: User ==========\n");
            List<User> usersByRole = manager.GetUsersByRole("user");

            foreach (User user in usersByRole)
            {
                Console.WriteLine($"{user.ID} | {user.FullName} | {user.UserName} | {user.Role}");
            }

            Console.WriteLine("\n========== 16. Check IsEmailTaken ==========\n");
            Console.WriteLine($"Is mohamed@gmail.com taken? {manager.IsEmailTaken("mohamed@gmail.com")}");
            Console.WriteLine($"Is free@gmail.com taken? {manager.IsEmailTaken("free@gmail.com")}");

            Console.WriteLine("\n========== 17. Check IsUserNameTaken ==========\n");
            Console.WriteLine($"Is sara taken? {manager.IsUserNameTaken("sara")}");
            Console.WriteLine($"Is freeuser taken? {manager.IsUserNameTaken("freeuser")}");

            Console.WriteLine("\n========== 18. Check IsPhoneTaken ==========\n");
            Console.WriteLine($"Is 0600000001 taken? {manager.IsPhoneTaken("0600000001")}");
            Console.WriteLine($"Is 0600000088 taken? {manager.IsPhoneTaken("0600000088")}");

            Console.WriteLine("\n========== 19. Show Registration Stats ==========\n");
            manager.ShowRegistrationStats();

            Console.WriteLine("\n========== 20. Test Common Permissions ==========\n");

            HashSet<string> adminPermissions = new HashSet<string>
            {
                "View", "Add", "Edit", "Delete", "Export"
            };

            HashSet<string> managerPermissions = new HashSet<string>
            {
                "View", "Add", "Edit"
            };

            HashSet<string> commonPermissions = manager.GetCommonPermissions(adminPermissions, managerPermissions);

            Console.WriteLine("Common Permissions Between Admin And Manager:");
            foreach (string permission in commonPermissions)
            {
                Console.WriteLine($"- {permission}");
            }

            Console.WriteLine("\n========== 21. Test Missing Permissions ==========\n");

            HashSet<string> userPermissions = new HashSet<string>
            {
                "View", "Add"
            };

            HashSet<string> requiredPermissions = new HashSet<string>
            {
                "View", "Add", "Edit"
            };

            HashSet<string> missingPermissions = manager.GetMissingPermissions(userPermissions, requiredPermissions);

            Console.WriteLine("Missing Permissions:");
            foreach (string permission in missingPermissions)
            {
                Console.WriteLine($"- {permission}");
            }

            Console.WriteLine("\n========== 22. Test HasAllRequiredPermissions ==========\n");

            bool hasAllRequired = manager.HasAllRequiredPermissions(userPermissions, requiredPermissions);
            Console.WriteLine($"User has all required permissions? {hasAllRequired}");

            userPermissions.Add("Edit");

            bool hasAllAfterAddingEdit = manager.HasAllRequiredPermissions(userPermissions, requiredPermissions);
            Console.WriteLine($"User has all required permissions after adding Edit? {hasAllAfterAddingEdit}");

            Console.WriteLine("\n========== 23. Test User Interests Comparison ==========\n");

            HashSet<string> userAInterests = new HashSet<string>
            {
                "CSharp", "SQL", "Backend", "Databases"
            };

            HashSet<string> userBInterests = new HashSet<string>
            {
                "SQL", "Frontend", "Backend", "UIUX"
            };

            manager.CompareUserInterests(userAInterests, userBInterests);

            Console.WriteLine("\n========== 24. Show All Users Final ==========\n");
            manager.ShowAllUsers();

            Console.WriteLine("\n========== TEST FINISHED ==========");
            Console.ReadLine();
        }
    }
}