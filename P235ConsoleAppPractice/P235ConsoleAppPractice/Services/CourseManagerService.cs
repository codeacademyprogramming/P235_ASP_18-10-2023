using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using P235ConsoleAppPractice.Interfaces;
using P235ConsoleAppPractice.Models;

namespace P235ConsoleAppPractice.Services
{
    internal class CourseManagerService : ICourseManagerService
    {
        private Student[] _students;
        public CourseManagerService()
        {
            _students = new Student[0]; 
        }
        public Student[] Students 
        {
            get 
            { 
                return _students; 
            }
        }

        public void AddStudent(Student student)
        {
            Array.Resize(ref _students, _students.Length+1);
            _students[_students.Length - 1] = student; 
        }

        public void ChangeStudentGroup(int no, string groupNo)
        {
            Student student = FindStudentByNo(no);

            if (student == null)
            {
                Console.WriteLine($"{no} - lu Telebe Tapilmadi");
            }

            student.GroupNo = groupNo;
        }

        public Student FindStudentByNo(int no)
        {
            Student result = null;

            foreach (Student student in _students)
            {
                if (student.No == no)
                {
                    result = student;
                }
            }

            return result;
        }

        public Student[] GetAllStudents()
        {
            return _students;
        }

        public double GetAvgPoint(string groupNo)
        {
            double sum = 0;
            int count = 0;

            foreach (Student student in _students)
            {
                if (student.GroupNo.ToLower() == groupNo.ToLower().Trim())
                {
                    sum += student.Point;
                    count++;
                }
            }

            double avg = sum / count;

            return avg;
        }

        public Student[] GetStudentsByDateRange(DateTime starDate, DateTime endDate)
        {
            Student[] results = { };

            foreach (Student student in _students)
            {
                if (student.StartDate >= starDate && student.StartDate <= endDate)
                {
                    Array.Resize(ref results, results.Length + 1);
                    results[results.Length - 1] = student;
                }
            }

            return results;
        }

        public Student[] GetStudentsByGroupNo(string groupNo)
        {
            Student[] results = { };

            foreach (Student student in _students)
            {
                if (student.GroupNo.ToLower() == groupNo.Trim().ToLower())
                {
                    Array.Resize(ref results, results.Length + 1);
                    results[results.Length - 1] = student;
                }
            }

            return results;
        }

        public void RemoveStudent(int no)
        {
            int index = -1;

            for (int i = 0; i < _students.Length; i++)
            {
                if (_students[i].No == no)
                {
                    _students[i] = null;
                    index = i; 
                    break;
                }
            }

            if (index > -1)
            {
                Student student = _students[_students.Length - 1];
                _students[index] = student;

                Array.Resize(ref _students, _students.Length - 1);
            }

        }

        public Student[] Search(string search)
        {
            Student[] students = { };

            foreach (Student student in _students)
            {
                if (student.FullName.ToLower().Contains(search.Trim().ToLower()) || student.GroupNo.ToLower().Contains(search.Trim().ToLower()))
                {
                    Array.Resize(ref students, students.Length + 1);
                    students[students.Length - 1] = student;
                }
            }

            return students;
        }
    }
}
