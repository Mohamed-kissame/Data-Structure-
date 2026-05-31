using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace StudentCourseManagementEngine
{
    internal class StudentGroup
    {


        private List<Student> _students;
        private Dictionary<int, Student> _studentsById;
        private HashSet<string> _allUniqueSkills;

        public StudentGroup()
        {

            _students = new List<Student>();
            _studentsById = new Dictionary<int, Student>();
            _allUniqueSkills = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            
        }

        private void RebuildAllUniqueSkills()
        {
            _allUniqueSkills.Clear();

            foreach (Student student in _students)
            {
                foreach (string skill in student.Skills)
                {
                    _allUniqueSkills.Add(skill);
                }
            }
        }

        public void AddStudent(Student student)
        {

            if (student == null) { throw new ArgumentNullException(nameof(student), "The object must not be null."); }

            if(_studentsById.ContainsKey(student.Id)) { throw new ArgumentException("This student Is Already Exists"); }

            _students.Add(student);

            _studentsById.Add(student.Id, student);

            foreach (var item in student.Skills)
            {

                    _allUniqueSkills.Add(item);
                
            }

        }

       public Student GetStudentById(int id)
        {

            if(id <= 0)
            {
                throw new ArgumentOutOfRangeException("The Id Must be Grate then Zero.");
            }

            if(_studentsById.TryGetValue(id, out var student))
            {

                return student;

            }

            return null;

        }



        public void PrintStudents(IEnumerable<Student> students)
        {
            if (students == null)
            {
                throw new ArgumentNullException(nameof(students), "The students source must not be null.");
            }

            List<Student> studentList = students.ToList();

            if (studentList.Count == 0)
            {
                Console.WriteLine("No students to show.");
                return;
            }

            foreach (Student student in studentList)
            {
                string skillsText = student.Skills.Count == 0
                    ? "No skills"
                    : string.Join(", ", student.Skills);

                Console.WriteLine($"ID                :  {student.Id}");
                Console.WriteLine($"FullName          :  {student.FullName}");
                Console.WriteLine($"AverageGrade      :  {student.AverageGrade}");
                Console.WriteLine($"RegistrationDate  :  {student.RegistrationDate}");
                Console.WriteLine($"Skills            :  {skillsText}");
                Console.WriteLine("--------------------------------------");
            }
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return _students;
        }

        public IList<Student> GetStudentsList()
        {
            return _students;
        }

        public ISet<string> GetAllSkills()
        {
            return new HashSet<string>(_allUniqueSkills, StringComparer.OrdinalIgnoreCase);
        }

        public void AddSkillToStudent(int studentId, string skill)
        {

            if(studentId <= 0)
            {
                throw new ArgumentOutOfRangeException("The Id Must be Grate then Zero.");
            }

            if (string.IsNullOrWhiteSpace(skill))
            {
                throw new ArgumentException("The skill must not be empty.", nameof(skill));
            }

            skill = skill.Trim();

            if (_studentsById.TryGetValue(studentId, out var student))
            {
                student.Skills.Add(skill);
                _allUniqueSkills.Add(skill);
            }
            else
            {
                Console.WriteLine($"No student Found with this id {studentId}");
            }
        }

        public bool StudentHasAllRequiredSkills(int studentId, ISet<string> requiredSkills)
        {
            if (studentId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(studentId), "The ID must be greater than zero.");
            }

            if (requiredSkills == null)
            {
                throw new ArgumentNullException(nameof(requiredSkills), "Required skills must not be null.");
            }

            if (!_studentsById.TryGetValue(studentId, out Student student))
            {
                Console.WriteLine($"No student found with this ID {studentId}.");
                return false;
            }

            return requiredSkills.IsSubsetOf(student.Skills);
        }

        public ISet<string> GetMissingSkills(int studentId, ISet<string> requiredSkills)
        {
            if (studentId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(studentId), "The ID must be greater than zero.");
            }

            if (requiredSkills == null)
            {
                throw new ArgumentNullException(nameof(requiredSkills), "Required skills must not be null.");
            }

            if (!_studentsById.TryGetValue(studentId, out Student student))
            {
                Console.WriteLine($"No student found with this ID {studentId}.");
                return new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            }

            HashSet<string> missing = new HashSet<string>(
                requiredSkills,
                StringComparer.OrdinalIgnoreCase
            );

            missing.ExceptWith(student.Skills);

            return missing;
        }

        public List<Student> SortByNaturalOrder()
        {

            List<Student> students = new List<Student>(_students);

            students.Sort();

            return students;
        }

        public List<Student> SortByName()
        {
            List<Student> students = new List<Student>(_students);
            students.Sort(new StudentNameComparer());
            return students;
        }

        public List<Student> SortByRegistrationDate()
        {
            List<Student> students = new List<Student>(_students);
            students.Sort(new StudentRegistrationDateComparer());
            return students;
        }

        public bool RemoveStudentById(int id)
        {

            if(id <= 0)
            {

                throw new ArgumentOutOfRangeException("The Id Must be Grate then Zero.");

            }

            if(_studentsById.TryGetValue(id, out Student student))
            {
                _students.Remove(student);
                _studentsById.Remove(id);
                RebuildAllUniqueSkills();
                return true;
            }

            return false;
        }
    }
    
}
