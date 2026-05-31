using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCourseManagementEngine
{
    internal class Student : IComparable<Student>
    {
        public int Id { get; set; }

        private string _fullName;

        public string FullName
        {
            get => _fullName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Full name cannot be empty.", nameof(value));
                }
                _fullName = value.Trim();
            }
        }

        private double _AverageGrade;

        public double AverageGrade
        {
            get => _AverageGrade;
            set
            {
                if (value < 0 || value > 20)
                {
                    throw new ArgumentException("Grade cannot be Less then Zero or Grate Then 20.", nameof(value));
                }
                _AverageGrade = value;
            }
        }


        public DateTime RegistrationDate { get; set; }

        public ISet<string> Skills { get; set; }


        public Student(int id, string fullName, double averageGrade)
        {
            Id = id;
            FullName = fullName;
            AverageGrade = averageGrade;
            RegistrationDate = DateTime.Now;
            Skills = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        }

        public int CompareTo(Student other)
        {
            if (other == null)
            {
                return 1;
            }

           
            int gradeComparison = other.AverageGrade.CompareTo(this.AverageGrade);

            if (gradeComparison != 0)
            {
                return gradeComparison;
            }

            
            return this.Id.CompareTo(other.Id);
        }

        public override string ToString()
        {
            return $"{Id} - {FullName} - Grade: {AverageGrade}";
        }
    }
}

