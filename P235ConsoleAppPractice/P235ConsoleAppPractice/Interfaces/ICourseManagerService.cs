using P235ConsoleAppPractice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P235ConsoleAppPractice.Interfaces
{
    internal interface ICourseManagerService
    {
        Student[] Students { get; }

        void AddStudent(Student student);

        void ChangeStudentGroup(int no, string groupNo);

        Student[] GetStudentsByGroupNo(string groupNo);

        Student[] GetAllStudents();

        Student FindStudentByNo(int no);

        Student[] Search(string search);

        Student[] GetStudentsByDateRange(DateTime starDate, DateTime endDate);

        void RemoveStudent(int no);

        double GetAvgPoint(string groupNo);
    }
}
