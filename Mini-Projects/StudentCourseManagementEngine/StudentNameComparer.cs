using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCourseManagementEngine
{
    internal class StudentNameComparer : IComparer<Student>
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

            int nameComparison = string.Compare(
                x.FullName,
                y.FullName,
                StringComparison.OrdinalIgnoreCase
            );

            if (nameComparison != 0)
            {
                return nameComparison;
            }

            return x.Id.CompareTo(y.Id);
        }
    }
}
