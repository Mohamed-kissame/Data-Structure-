using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCourseManagementEngine
{
    internal class StudentRegistrationDateComparer : IComparer<Student>
    {

        public int Compare(Student x, Student y)
        {
            if (ReferenceEquals(x, y))
            {
                return 0;
            }

            if (x == null)
            {
                return -1;
            }

            if (y == null)
            {
                return 1;
            }

            int nameComparison = DateTime.Compare(
                x.RegistrationDate,
                y.RegistrationDate
            );

            if (nameComparison != 0)
            {
                return nameComparison;
            }

            return x.Id.CompareTo(y.Id);
        }

    }
}
