using System;
using System.Collections.Generic;
using BLL;
using Models;

namespace UserAccessManagementConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UserAccessManager manager = new UserAccessManager();

            // Unique data so the test can run again without duplicate conflicts.
            string testSuffix = DateTime.Now.ToString("yyyyMMddHHmmss");

            string mohamedEmail = $"mohamed.test.{testSuffix}@gmail.com";
            string saraEmail = $"sara.test.{testSuffix}@gmail.com";

            string mohamedUsername = $"mohamed_{testSuffix}";
            string saraUsername = $"sara_{testSuffix}";

            Console.WriteLine("========== 1. Initialize Role Permissions ==========\n");
            manager.InitializeDefaultRolePermissions();

            Console.WriteLine("\n========== 2. Load Existing Users From Database ==========\n");
            manager.LoadUsersFromDatabase();

            Console.WriteLine("\n========== 3. Initial Statistics ==========\n");
            manager.ShowStatistics();

            Console.WriteLine("\n========== 4. Initial Database Vs Memory Check ==========\n");
            manager.CompareDatabaseVsMemoryCount();

            Console.WriteLine("\n========== 5. Create Test Users ==========\n");

            User mohamed = new User(
                -1,
                "Mohamed Test User",
                mohamedUsername,
                mohamedEmail,
                "0600000101",
                "User",
                true,
                DateTime.Now,
                null
            );

            User sara = new User(
                -1,
                "Sara Test Manager",
                saraUsername,
                saraEmail,
                "0600000102",
                "Manager",
                true,
                DateTime.Now,
                null
            );

            manager.AddUser(mohamed);
            manager.AddUser(sara);

            Console.WriteLine("\n========== 6. Try Duplicate Email ==========\n");

            User duplicateEmailUser = new User(
                -1,
                "Duplicate Email User",
                $"other_{testSuffix}",
                mohamedEmail,
                "0600000103",
                "User",
                true,
                DateTime.Now,
                null
            );

            manager.AddUser(duplicateEmailUser);

            Console.WriteLine("\n========== 7. Try Duplicate Username ==========\n");

            User duplicateUsernameUser = new User(
                -1,
                "Duplicate Username User",
                saraUsername,
                $"different.{testSuffix}@gmail.com",
                "0600000104",
                "User",
                true,
                DateTime.Now,
                null
            );

            manager.AddUser(duplicateUsernameUser);

            Console.WriteLine("\n========== 8. Get User By ID From Cache ==========\n");

            User foundById = manager.GetUserByIdFromCache(mohamed.UserID);

            if (foundById != null)
            {
                Console.WriteLine(
                    $"Found by ID: {foundById.UserID} | {foundById.FullName} | {foundById.Email}"
                );
            }

            Console.WriteLine("\n========== 9. Get User By Email From Cache ==========\n");

            User foundByEmail = manager.GetUserByEmailFromCache(saraEmail);

            if (foundByEmail != null)
            {
                Console.WriteLine(
                    $"Found by Email: {foundByEmail.UserID} | {foundByEmail.FullName} | {foundByEmail.Role}"
                );
            }

            Console.WriteLine("\n========== 10. Search Missing Users From Cache ==========\n");

            User missingById = manager.GetUserByIdFromCache(999999);

            Console.WriteLine(
                missingById == null
                    ? "No user found with missing ID."
                    : "Unexpected user found."
            );

            User missingByEmail = manager.GetUserByEmailFromCache("missing.user@gmail.com");

            Console.WriteLine(
                missingByEmail == null
                    ? "No user found with missing email."
                    : "Unexpected user found."
            );

            Console.WriteLine("\n========== 11. HashSet Uniqueness Checks ==========\n");

            Console.WriteLine($"Is Mohamed email taken? {manager.IsEmailTaken(mohamedEmail)}");
            Console.WriteLine($"Is free email taken? {manager.IsEmailTaken($"free.{testSuffix}@gmail.com")}");
            Console.WriteLine($"Is Sara username taken? {manager.IsUsernameTaken(saraUsername)}");
            Console.WriteLine($"Is free username taken? {manager.IsUsernameTaken($"free_{testSuffix}")}");

            Console.WriteLine("\n========== 12. Update User Role ==========\n");

            manager.UpdateUserRole(mohamed.UserID, "Manager");

            User afterRoleUpdate = manager.GetUserByIdFromCache(mohamed.UserID);

            if (afterRoleUpdate != null)
            {
                Console.WriteLine(
                    $"Role after update: {afterRoleUpdate.FullName} → {afterRoleUpdate.Role}"
                );
            }

            Console.WriteLine("\n========== 13. Update User Email ==========\n");

            string updatedMohamedEmail = $"mohamed.updated.{testSuffix}@gmail.com";

            manager.UpdateUserEmail(mohamed.UserID, updatedMohamedEmail);

            Console.WriteLine($"Old email still taken? {manager.IsEmailTaken(mohamedEmail)}");
            Console.WriteLine($"New email taken? {manager.IsEmailTaken(updatedMohamedEmail)}");

            User afterEmailUpdate = manager.GetUserByEmailFromCache(updatedMohamedEmail);

            if (afterEmailUpdate != null)
            {
                Console.WriteLine(
                    $"User found using updated email: {afterEmailUpdate.FullName}"
                );
            }

            Console.WriteLine("\n========== 14. Try Updating To Same Current Email ==========\n");

            manager.UpdateUserEmail(mohamed.UserID, updatedMohamedEmail);

            Console.WriteLine("\n========== 15. Try Updating To Another User Email ==========\n");

            manager.UpdateUserEmail(mohamed.UserID, saraEmail);

            Console.WriteLine("\n========== 16. Deactivate User ==========\n");

            manager.DeactivateUser(sara.UserID);

            Console.WriteLine("\n========== 17. Try Deactivating Same User Again ==========\n");

            manager.DeactivateUser(sara.UserID);

            Console.WriteLine("\n========== 18. Show Active Users ==========\n");

            List<User> activeUsers = manager.GetActiveUsers();
            manager.ShowUsers(activeUsers);

            Console.WriteLine("\n========== 19. Get Users By Role: Manager ==========\n");

            List<User> managerUsers = manager.GetUsersByRole("manager");
            manager.ShowUsers(managerUsers);

            Console.WriteLine("\n========== 20. Get Users Sorted By Name ==========\n");

            List<User> usersSortedByName = manager.GetUsersSortedByName();
            manager.ShowUsers(usersSortedByName);

            Console.WriteLine("\n========== 21. Test Single Permission Checks ==========\n");

            Console.WriteLine($"Admin can DeleteUser: {manager.HasPermission("Admin", "DeleteUser")}");
            Console.WriteLine($"Manager can DeleteUser: {manager.HasPermission("Manager", "DeleteUser")}");
            Console.WriteLine($"Guest can ViewUsers: {manager.HasPermission("Guest", "ViewUsers")}");
            Console.WriteLine($"Case-insensitive admin export check: {manager.HasPermission("admin", "exportusers")}");

            Console.WriteLine("\n========== 22. Test Required Permissions ==========\n");

            HashSet<string> exportRequiredPermissions =
                new HashSet<string>(StringComparer.OrdinalIgnoreCase)
                {
                    "ViewUsers",
                    "ExportUsers"
                };

            Console.WriteLine(
                $"Admin has all export permissions: " +
                $"{manager.HasAllRequiredPermissions("Admin", exportRequiredPermissions)}"
            );

            Console.WriteLine(
                $"Manager has all export permissions: " +
                $"{manager.HasAllRequiredPermissions("Manager", exportRequiredPermissions)}"
            );

            Console.WriteLine("\n========== 23. Get Missing Manager Permissions ==========\n");

            HashSet<string> managerMissingPermissions =
                manager.GetMissingPermissions("Manager", exportRequiredPermissions);

            Console.WriteLine("Manager is missing:");

            if (managerMissingPermissions.Count == 0)
            {
                Console.WriteLine("- No missing permissions");
            }
            else
            {
                foreach (string permission in managerMissingPermissions)
                {
                    Console.WriteLine($"- {permission}");
                }
            }

            Console.WriteLine("\n========== 24. Compare Roles: Manager Vs Admin ==========\n");

            manager.CompareRoles("Manager", "Admin");

            Console.WriteLine("\n========== 25. Statistics After Changes ==========\n");

            manager.ShowStatistics();

            Console.WriteLine("\n========== 26. Database Vs Memory Check After Changes ==========\n");

            manager.CompareDatabaseVsMemoryCount();

            Console.WriteLine("\n========== 27. Delete Temporary Test Users ==========\n");

            manager.DeleteUser(mohamed.UserID);
            manager.DeleteUser(sara.UserID);

            Console.WriteLine("\n========== 28. Verify Deleted Emails Are Free In Memory ==========\n");

            Console.WriteLine(
                $"Updated Mohamed email still taken? {manager.IsEmailTaken(updatedMohamedEmail)}"
            );

            Console.WriteLine(
                $"Sara email still taken? {manager.IsEmailTaken(saraEmail)}"
            );

            Console.WriteLine("\n========== 29. Database Vs Memory Check After Delete ==========\n");

            manager.CompareDatabaseVsMemoryCount();

            Console.WriteLine("\n========== 30. Refresh All Users From Database ==========\n");

            manager.RefreshAllUsersFromDatabase();

            Console.WriteLine("\n========== 31. Final Statistics ==========\n");

            manager.ShowStatistics();

            Console.WriteLine("\n========== 32. Final Database Vs Memory Check ==========\n");

            manager.CompareDatabaseVsMemoryCount();

            Console.WriteLine("\n========== TEST FINISHED ==========");
            Console.ReadLine();
        }
    }
}