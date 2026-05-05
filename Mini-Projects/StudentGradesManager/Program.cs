using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentGradesManager
{
    internal class Program
    {
        static void Main(string[] args)
        {

            StudentGradesManager studentGradesManager = new StudentGradesManager();

            studentGradesManager.AddGrade(12);
            studentGradesManager.AddGrade(13);
            studentGradesManager.AddGrade(15);

            studentGradesManager.ShowGrades();

            Console.WriteLine($"\nThe Average of Grades its : {studentGradesManager.GetAverage()}");
            Console.WriteLine($"\nThe Max of Grades its : {studentGradesManager.GetMaxGrade()}");
            Console.WriteLine($"\nThe Min of Grades its : {studentGradesManager.GetMinGrade()}");


        }
    }
}
