using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentGradesManager
{
    public class StudentGradesManager
    {

        private ArrayList<double> _grades;

        public StudentGradesManager()
        {
            _grades = new ArrayList<double>();
        }

        public void AddGrade(double grade)
        {

            if(grade < 0 || grade > 20) { Console.Write("Wrong Input The Grade Should be Betwwen 0 and 20"); return; }

            _grades.Add(grade);
        }

        public void InsertGradeAt(int index ,double grade)
        {

            if (grade < 0 || grade > 20) { Console.Write("Wrong Input The Grade Should be Betwwen 0 and 20"); return; }

            _grades.InsertAt(index,grade);
        }

        public void DeleteGradeAt(int Index)
        {

            if(_grades.Size == 0) { Console.WriteLine("There no grade to remove "); return; }

            _grades.DeleteAt(Index);

        }

        public void ShowGrades()
        {

            if (_grades.Size == 0) { Console.WriteLine("There are no grades to show"); return; }

            _grades.Display();

        }

        public void UpdateGradeAT(int index , double grade)
        {
            if (grade < 0 || grade > 20) { Console.Write("Wrong Input The Grade Should be Betwwen 0 and 20"); return; }

            if (_grades.Size == 0) { Console.WriteLine("There no grade to update "); return; }

            _grades.UpdateAt(index,grade);

        }

        public double GetAverage()
        {

            if( _grades.Size == 0) return 0;

            double sum = 0;

            for (int i = 0; i < _grades.Size; i++)
            {

                sum += _grades.GetAt(i);

            }

            return sum / _grades.Size;
        }

        public double GetMaxGrade()
        {

            if (_grades.Size == 0) return 0;

            double max = _grades.GetAt(0);

            for (int i = 0; i < _grades.Size; i++)
            {
                
                if(_grades.GetAt(i) > max )

                      max = _grades.GetAt(i);

            }

            return max;

        }

        public double GetMinGrade()
        {

            if (_grades.Size == 0) return 0;

            double min = _grades.GetAt(0);

            for (int i = 0; i < _grades.Size; i++)
            {

                if (_grades.GetAt(i) < min)

                    min = _grades.GetAt(i);

            }

            return min;

        }

        public bool ContainsGrade(double grade)
        {
            if (grade < 0 || grade > 20) { Console.Write("Wrong Input The Grade Should be Betwwen 0 and 20"); return false; }


            return _grades.Contains(grade);

        }

    }
}
