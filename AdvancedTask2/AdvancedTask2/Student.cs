using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTask2
{
    public class Student
    {
        private readonly int rollNumber;
        private string name;
        private int age;
        private string grade;

        public Student(int rollnumber, string name, int age, string grade)
        {
            RollNumber = rollnumber;
            Name = name;
            Age = age;
            Grade = grade;
        }
        public int RollNumber { get; }
        public string Name { get; }
        public int Age { get;}
        public string Grade { get;}
    }
}
