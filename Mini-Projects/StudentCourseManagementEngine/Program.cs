using System;
using System.Collections.Generic;
using System.Threading;

namespace StudentCourseManagementEngine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StudentGroup group = new StudentGroup();

            Console.WriteLine("========== 1. Create Students ==========\n");

            Student s1 = new Student(1, "Mohamed", 18.5);
            Thread.Sleep(1000);

            Student s2 = new Student(2, "Sara", 16.0);
            Thread.Sleep(1000);

            Student s3 = new Student(3, "Ali", 15.5);
            Thread.Sleep(1000);

            Student s4 = new Student(4, "Youssef", 18.5);

            s1.Skills.Add("CSharp");
            s1.Skills.Add("SQL");

            s2.Skills.Add("HTML");
            s2.Skills.Add("CSS");
            s2.Skills.Add("JavaScript");

            s3.Skills.Add("Git");
            s3.Skills.Add("SQL");

            s4.Skills.Add("CSharp");
            s4.Skills.Add("Algorithms");

            Console.WriteLine("========== 2. Add Students ==========\n");

            group.AddStudent(s1);
            group.AddStudent(s2);
            group.AddStudent(s3);
            group.AddStudent(s4);

            Console.WriteLine("========== 3. Try Duplicate Student ID ==========\n");

            try
            {
                group.AddStudent(new Student(1, "Duplicate Mohamed", 12));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("\n========== 4. Print All Students Using IEnumerable ==========\n");

            group.PrintStudents(group.GetAllStudents());

            Console.WriteLine("\n========== 5. Find Student By ID Using Dictionary ==========\n");

            Student found = group.GetStudentById(2);

            if (found != null)
            {
                Console.WriteLine($"Found student: {found.Id} - {found.FullName}");
            }

            Console.WriteLine("\n========== 6. Try Finding Missing Student ==========\n");

            Student missing = group.GetStudentById(99);

            Console.WriteLine(missing == null
                ? "Student not found."
                : "Unexpected student found.");

            Console.WriteLine("\n========== 7. Access First Student Using IList ==========\n");

            IList<Student> studentsList = group.GetStudentsList();

            if (studentsList.Count > 0)
            {
                Console.WriteLine($"First student: {studentsList[0].FullName}");
            }

            Console.WriteLine("\n========== 8. Add New Skill To Student ==========\n");

            group.AddSkillToStudent(2, "React");
            group.AddSkillToStudent(1, "Git");

            Console.WriteLine("\n========== 9. Show All Unique Skills Using ISet ==========\n");

            ISet<string> allSkills = group.GetAllSkills();

            foreach (string skill in allSkills)
            {
                Console.WriteLine($"- {skill}");
            }

            Console.WriteLine("\n========== 10. Check Required Backend Skills ==========\n");

            ISet<string> backendSkills = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
            {
                "CSharp",
                "SQL",
                "Git"
            };

            bool mohamedHasBackendSkills =
                group.StudentHasAllRequiredSkills(1, backendSkills);

            Console.WriteLine($"Mohamed has all backend skills? {mohamedHasBackendSkills}");

            Console.WriteLine("\n========== 11. Show Missing Skills ==========\n");

            ISet<string> missingSkills =
                group.GetMissingSkills(1, backendSkills);

            if (missingSkills.Count == 0)
            {
                Console.WriteLine("No missing skills.");
            }
            else
            {
                foreach (string skill in missingSkills)
                {
                    Console.WriteLine($"Missing: {skill}");
                }
            }

            Console.WriteLine("\n========== 12. Sort By Natural Order ==========");
            Console.WriteLine("Natural order = AverageGrade descending, then Id ascending.\n");

            group.PrintStudents(group.SortByNaturalOrder());

            Console.WriteLine("\n========== 13. Sort By Name ==========\n");

            group.PrintStudents(group.SortByName());

            Console.WriteLine("\n========== 14. Sort By Registration Date ==========\n");

            group.PrintStudents(group.SortByRegistrationDate());

            Console.WriteLine("\n========== 15. Remove One Student ==========\n");

            bool removed = group.RemoveStudentById(3);
            Console.WriteLine($"Removed student ID 3? {removed}");

            Console.WriteLine("\n========== 16. Print Final Students ==========\n");

            group.PrintStudents(group.GetAllStudents());

            Console.WriteLine("\n========== 17. Print Final Unique Skills ==========\n");

            foreach (string skill in group.GetAllSkills())
            {
                Console.WriteLine($"- {skill}");
            }

            Console.WriteLine("\n========== TEST FINISHED ==========");
            Console.ReadLine();
        }
    }
}