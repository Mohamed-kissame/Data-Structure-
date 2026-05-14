using System;
using System.Collections.Generic;

namespace SmartTaskManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SmartTaskManager manager = new SmartTaskManager();

            Console.WriteLine("========== 1. AddTask Tests ==========\n");

            manager.AddTask(
                "Study C# Collections",
                5,
                DateTime.Today.AddDays(2),
                true,
                new List<string> { "CSharp", "Study", " csharp ", "", "Collections" }
            );

            manager.AddTask(
                "Finish SQL homework",
                4,
                DateTime.Today.AddDays(-2),
                false,
                new List<string> { "SQL", "Database", "Homework" }
            );

            manager.AddTask(
                "Prepare LinkedIn post",
                3,
                DateTime.Today.AddDays(1),
                false,
                new List<string> { "Career", "LinkedIn", "Writing" }
            );

            manager.AddTask(
                "Review LINQ methods",
                5,
                DateTime.Today.AddDays(-1),
                true,
                new List<string> { "CSharp", "LINQ", "Practice" }
            );

            manager.AddTask(
                "Read documentation",
                2,
                DateTime.Today.AddDays(5),
                false,
                new List<string> { "Reading", "Docs" }
            );

            Console.WriteLine("\n========== 2. Invalid AddTask Tests ==========\n");

            manager.AddTask(
                "",
                3,
                DateTime.Today.AddDays(1),
                false,
                new List<string> { "Invalid" }
            );

            manager.AddTask(
                "Invalid priority task",
                10,
                DateTime.Today.AddDays(1),
                false,
                new List<string> { "Invalid" }
            );

            Console.WriteLine("\n========== 3. AddManyTasks Tests ==========\n");

            List<TaskItem> manyTasks = new List<TaskItem>
            {
                new TaskItem(0, "Build List mini project", 5, DateTime.Today.AddDays(3), true,
                    new List<string> { "Project", "CSharp", "List" }),

                new TaskItem(0, "Practice problem solving", 4, DateTime.Today.AddDays(-3), false,
                    new List<string> { "Practice", "Algorithms" }),

                new TaskItem(0, "Clean GitHub README", 3, DateTime.Today.AddDays(4), false,
                    new List<string> { "GitHub", "Docs" }),

                new TaskItem(0, "   ", 2, DateTime.Today.AddDays(2), false,
                    new List<string> { "InvalidTitle" }),

                new TaskItem(0, "Invalid priority from AddMany", 8, DateTime.Today.AddDays(2), false,
                    new List<string> { "InvalidPriority" }),

                null
            };

            manager.AddManyTasks(manyTasks);

            Console.WriteLine("\n========== 4. Show All Tasks After Add ==========\n");
            manager.ShowAllTasks();

            Console.WriteLine("\n========== 5. CompleteTask Tests ==========\n");

            manager.CompleteTask(1);
            manager.CompleteTask(1);     // already completed
            manager.CompleteTask(100);   // invalid ID

            Console.WriteLine("\n========== 6. Update Tests ==========\n");

            manager.UpdateTaskTitle(2, "Finish Advanced SQL homework");
            manager.UpdateTaskTitle(2, "   ");      // invalid title
            manager.UpdateTaskTitle(100, "Test");   // invalid ID

            manager.UpdatePriority(3, 5);
            manager.UpdatePriority(3, 0);           // invalid priority
            manager.UpdatePriority(100, 2);         // invalid ID

            Console.WriteLine("\n========== 7. Archive Tests ==========\n");

            manager.ArchiveTask(3);  // should fail if not completed
            manager.ArchiveTask(1);  // should archive completed task

            Console.WriteLine("\n========== 8. Delete Tests ==========\n");

            manager.DeleteTask(5);       // normal delete
            manager.DeleteTask(4);       // important task, should refuse
            manager.ForceDeleteTask(4);  // force delete important task
            manager.ForceDeleteTask(100);

            Console.WriteLine("\n========== 9. Mark Overdue Tasks ==========\n");

            manager.MarkOverdueTasks();

            Console.WriteLine("\n========== 10. Show Pending Tasks ==========\n");
            manager.ShowTasks(manager.GetPendingTasks());

            Console.WriteLine("\n========== 11. Show Completed Tasks ==========\n");
            manager.ShowTasks(manager.GetCompletedTasks());

            Console.WriteLine("\n========== 12. Show Overdue Tasks ==========\n");
            manager.ShowTasks(manager.GetOverdueTasks());

            Console.WriteLine("\n========== 13. Show Important Tasks ==========\n");
            manager.ShowTasks(manager.GetImportantTasks());

            Console.WriteLine("\n========== 14. Search By Keyword ==========\n");

            Console.WriteLine("\nSearch keyword: SQL");
            manager.ShowTasks(manager.SearchByKeyword("sql"));

            Console.WriteLine("\nSearch keyword: C#");
            manager.ShowTasks(manager.SearchByKeyword("c#"));

            Console.WriteLine("\nSearch invalid keyword:");
            manager.ShowTasks(manager.SearchByKeyword("   "));

            Console.WriteLine("\n========== 15. Search By Tag ==========\n");

            Console.WriteLine("\nTag: csharp");
            manager.ShowTasks(manager.GetTasksByTag("csharp"));

            Console.WriteLine("\nTag: docs");
            manager.ShowTasks(manager.GetTasksByTag("docs"));

            Console.WriteLine("\nInvalid tag:");
            manager.ShowTasks(manager.GetTasksByTag("   "));

            Console.WriteLine("\n========== 16. Top Urgent Tasks ==========\n");
            manager.ShowTasks(manager.GetTopUrgentTasks(3));

            Console.WriteLine("\n========== 17. Sorted Copy By Due Date ==========\n");
            List<TaskItem> sortedCopy = manager.GetSortedByDueDate();
            manager.ShowTasks(sortedCopy);

            Console.WriteLine("\n========== 18. Original List Before Sort ==========\n");
            manager.ShowAllTasks();

            Console.WriteLine("\n========== 19. Sort Original By Due Date ==========\n");
            manager.SortOriginalByDueDate();
            manager.ShowAllTasks();

            Console.WriteLine("\n========== 20. Grouped By Status ==========\n");
            manager.ShowTasksGroupedByStatus();

            Console.WriteLine("\n========== 21. Statistics ==========\n");
            manager.ShowStatistics();

            Console.WriteLine("\n========== 22. Memory Info Before RemoveArchived ==========\n");
            manager.ShowMemoryInfo();

            Console.WriteLine("\n========== 23. Remove Archived Tasks ==========\n");
            manager.RemoveArchivedTasks();
            manager.ShowAllTasks();

            Console.WriteLine("\n========== 24. Archive Completed Tasks ==========\n");
            manager.ArchiveCompletedTasks();

            Console.WriteLine("\n========== 25. Memory Info Before Trim ==========\n");
            manager.ShowMemoryInfo();

            Console.WriteLine("\n========== 26. Trim Memory ==========\n");
            manager.TrimMemory();

            Console.WriteLine("\n========== 27. Final All Tasks ==========\n");
            manager.ShowAllTasks();

            Console.WriteLine("\n========== TEST FINISHED ==========");
        }
    }
}