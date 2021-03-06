using System.Collections.Generic;

namespace Egzas_Databasu
{
    public class Lecture : BaseEntity
    {
        public List<Department> Departments { get; set; }
        public List<Student> Students { get; set; }
        public int Kelintas { get; set; }
        private Lecture() 
        {
            Departments = new List<Department>();
        }
        public Lecture(string name, int kelint)
        {
            Name = name;
            Departments = new List<Department>();
            Kelintas = kelint;
        }
    }
}
