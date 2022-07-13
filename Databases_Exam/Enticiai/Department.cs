using System.Collections.Generic;

namespace Egzas_Databasu
{
    public class Department : BaseEntity
    {
        public List<Student> Students { get; set; }
        public List<Lecture> Lectures { get; set; }
        private Department() 
        {
            Students = new List<Student>();
            Lectures = new List<Lecture>();
        }
        public Department(string name)
        {
            Name = name;
            Students = new List<Student>();
            Lectures = new List<Lecture>();
        }
    }
}
