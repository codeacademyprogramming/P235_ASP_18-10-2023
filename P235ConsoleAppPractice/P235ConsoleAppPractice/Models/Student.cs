using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P235ConsoleAppPractice.Models
{
    internal class Student
    {
        private static int _no;
        public readonly int No;
        public string FullName;
        public string GroupNo;
        public double Point;
        public DateTime StartDate;

        static Student()
        {
            _no = 0;
        }

        public Student()
        {
            _no++;
            No = _no;
        }

        public override string ToString()
        {
            return $"No: {No}\nAd Soyad: {FullName}\nQrup Nomresi: {GroupNo}\nQiymeti: {Point}\nBaslama Tarixi: {StartDate.ToString("yyyy - MM - dd")}";
        }
    }
}
