using System;

namespace LegacyUserSessionManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LegacySessionManager manager = new LegacySessionManager();

            Console.WriteLine("========== 1. Add 4 Sessions ==========\n");

            manager.AddSession("S001", "Mohamed", "Admin");
            manager.AddSession("S002", "Sara", "User");
            manager.AddSession("S003", "Ali", "Manager");
            manager.AddSession("S004", "Omar", "User");

            manager.ShowAllSessions();

            Console.WriteLine("\n========== 2. Try Duplicate SessionId ==========\n");

            manager.AddSession("S001", "Youssef", "User");

            Console.WriteLine("\n========== 3. Try Invalid Inputs ==========\n");

            manager.AddSession("", "InvalidUser", "User");
            manager.AddSession("S005", "", "User");
            manager.AddSession("S006", "Hanane", "");

            Console.WriteLine("\n========== 4. AddOrUpdate Existing Session ==========\n");

            manager.AddOrUpdateSession("S002", "SaraUpdated", "PowerUser");
            manager.ShowAllSessions();

            Console.WriteLine("\n========== 5. AddOrUpdate New Session ==========\n");

            manager.AddOrUpdateSession("S005", "Youssef", "Guest");
            manager.ShowAllSessions();

            Console.WriteLine("\n========== 6. Get Existing Session ==========\n");

            UserSession session = manager.GetSession("S002");

            if (session != null)
            {
                Console.WriteLine($"Found Session: {session.UserName} | {session.Role} | Active: {session.IsActive}");
            }

            Console.WriteLine("\n========== 7. Get Missing Session ==========\n");

            manager.GetSession("S999");

            Console.WriteLine("\n========== 8. ContainsSession Tests ==========\n");

            Console.WriteLine($"Contains S001: {manager.ContainsSession("S001")}");
            Console.WriteLine($"Contains S999: {manager.ContainsSession("S999")}");

            Console.WriteLine("\n========== 9. Update Activity For Active Session ==========\n");

            manager.UpdateActivity("S001");

            Console.WriteLine("\n========== 10. End Session ==========\n");

            manager.EndSession("S001");

            Console.WriteLine("\n========== 11. Try Ending Same Session Again ==========\n");

            manager.EndSession("S001");

            Console.WriteLine("\n========== 12. Try Updating Activity On Inactive Session ==========\n");

            manager.UpdateActivity("S001");

            Console.WriteLine("\n========== 13. Remove Existing Session ==========\n");

            manager.RemoveSession("S003");

            Console.WriteLine("\n========== 14. Try Removing Missing Session ==========\n");

            manager.RemoveSession("S999");

            Console.WriteLine("\n========== 15. Show All Sessions ==========\n");

            manager.ShowAllSessions();

            Console.WriteLine("\n========== 16. Show Active Sessions ==========\n");

            manager.ShowActiveSessions();

            Console.WriteLine("\n========== 17. Count Sessions ==========\n");

            manager.CountSessions();

            Console.WriteLine("\n========== 18. Clear All Sessions ==========\n");

            manager.ClearAllSessions();

            Console.WriteLine("\n========== 19. Show All After Clear ==========\n");

            manager.ShowAllSessions();

            Console.WriteLine("\n========== 20. Show Active After Clear ==========\n");

            manager.ShowActiveSessions();

            Console.WriteLine("\n========== 21. Count After Clear ==========\n");

            manager.CountSessions();

            Console.WriteLine("\n========== TEST FINISHED ==========");
        }
    }
}