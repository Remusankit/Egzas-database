using System.Collections.Generic;

namespace Egzas_Databasu
{
    public class Student : BaseEntity
    {
        public int Age { get; set; }
        public Department Department { get; set; }
        public List<Lecture> Lectures { get; set; }
        private Student() 
        {
            Lectures = new List<Lecture>();
        }
        public Student(string name, int age)
        {
            Name = name;
            Age = age;
            Lectures = new List<Lecture>();
        }
    }
}
