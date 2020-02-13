using System;

namespace WebApplication.Models
{
    public class Student
    {
        public Student(){} // fist without default constructor then see further errors like json parsing

        public Student(String name, String department) {
            this.Name = name;
            this.Department = department;
        }

        public string Name { get; set; } // first do not use get set and see post not work
        public string Department { get; set; } // first do not use get set and see post not work
    }
}
