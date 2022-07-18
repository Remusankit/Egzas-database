using System;

namespace Egzas_Databasu
{
    public class BusinessLogic
    {
        private readonly DbRepository _repository;
        public BusinessLogic()
        {
            _repository = new DbRepository();
        }
        public void CreateDepartment(string name)
        {
            var department = new Department(name);

            _repository.AddDepartment(department);
            _repository.SaveChanges();
        }
        public void CreateLecture(string name, int kelint)
        {
            var lecture = new Lecture(name, kelint);

            _repository.AddLecture(lecture);
            _repository.SaveChanges();
        }
        public void CreateStudent(string name, int age,string pavard,int iq)
        {
            var student = new Student(name, age, pavard,iq);

            _repository.AddStudent(student);
            _repository.SaveChanges();
        }
        public void ShowDepartments()
        {
            Console.WriteLine("Department's ID, Name:");

            foreach (var department in _repository.RetrieveDepartments())
            {
                Console.WriteLine($"{department.Id}, {department.Name}");
            }            
        }
        public void ShowDepartmentsByLecture(int lectureId)
        {
            Lecture lecture = _repository.RetrieveLectureById(lectureId);

            Console.WriteLine("Department's ID, Name:");

            foreach (var department in _repository.RetrieveDepartments())
            {
                if (department.Lectures.Contains(lecture))
                {
                    Console.WriteLine($"{department.Id}, {department.Name}");
                }                
            }
        }
        public void ShowDepartmentByStudent(int studentId)
        {
            Student student = _repository.RetrieveStudentById(studentId);

            Console.WriteLine("Department's ID, Name:");

            foreach (var department in _repository.RetrieveDepartments())
            {
                if (department.Students.Contains(student))
                {
                    Console.WriteLine($"{department.Id}, {department.Name}");
                }
            }
        }
        public void ShowLectures()
        {
            Console.WriteLine("Lecture's ID, Name:");

            foreach (var lecture in _repository.RetrieveLectures())
            {
                Console.WriteLine($"{lecture.Id}, {lecture.Name}");
            }
        }
        public void ShowLecturesByDepartment(int departmentId)
        {
            Department department = _repository.RetrieveDepartmentById(departmentId);

            Console.WriteLine("Lecture's ID, Name:");

            foreach (var lecture in _repository.RetrieveLectures())
            {
                if (lecture.Departments.Contains(department))
                {
                    Console.WriteLine($"{lecture.Id}, {lecture.Name}");
                }              
            }
        }
        public void ShowLecturesByStudent(int studentId)
        {
            Student student = _repository.RetrieveStudentById(studentId);

            Console.WriteLine("Lecture's ID, Name:");

            foreach (var lecture in _repository.RetrieveLectures())
            {
                if (lecture.Students.Contains(student))
                {
                    Console.WriteLine($"{lecture.Id}, {lecture.Name}");
                }
            }
        }
        public void ShowStudents()
        {
            Console.WriteLine("Student's ID, Name, Age:");

            foreach (var student in _repository.RetrieveStudents())
            {
                Console.WriteLine($"{student.Id}, {student.Name}, {student.Age}");
            }
        }
        public void ShowStudentsByDepartment(int departmentId)
        {
            Department department = _repository.RetrieveDepartmentById(departmentId);

            Console.WriteLine("Student's ID, Name, Age:");

            foreach (var student in _repository.RetrieveStudents())
            {
                if (student.Department == department)
                {
                    Console.WriteLine($"{student.Id}, {student.Name}, {student.Age}");
                }              
            }
        }
        public void ShowStudentsByLecture(int lectureId)
        {
            Lecture lecture = _repository.RetrieveLectureById(lectureId);

            Console.WriteLine("Student's ID, Name, Age:");

            foreach (var student in _repository.RetrieveStudents())
            {
                if (student.Lectures.Contains(lecture))
                {
                    Console.WriteLine($"{student.Id}, {student.Name}, {student.Age}");
                }
            }
        }
        public void AssignDepartmentToLecture(int departmentId, int lectureId)
        {
            Department department = _repository.RetrieveDepartmentById(departmentId);
            Lecture lecture = _repository.RetrieveLectureById(lectureId);

            lecture.Departments.Add(department);

            _repository.SaveChanges();
        }
        public void AssignDepartmentToStudent(int departmentId, int studentId)
        {
            Department department = _repository.RetrieveDepartmentById(departmentId);
            Student student = _repository.RetrieveStudentById(studentId);

            student.Department = department;

            AssignAllDepatmentLecturesToStudent(student, department);

            _repository.SaveChanges();
        }
        public void AssignStudentToLecture(int studentId, int lectureId)
        {
            Student student = _repository.RetrieveStudentById(studentId);
            Lecture lecture = _repository.RetrieveLectureById(lectureId);

            student.Lectures.Add(lecture);

            _repository.SaveChanges();
        }
        public void AssignAllDepatmentLecturesToStudent(Student student, Department department)
        {
            student.Lectures.Clear();

            foreach (var lecture in department.Lectures)
            {
                student.Lectures.Add(lecture);
            }

            _repository.SaveChanges();
        }
        public void DeleteDepartment(int departmentId)
        {
            Department department = _repository.RetrieveDepartmentById(departmentId);

            _repository.DeleteDepartment(department);

            _repository.SaveChanges();
        }
        public void DeleteLecture(int lectureId)
        {
            Lecture lecture = _repository.RetrieveLectureById(lectureId);

            _repository.DeleteLecture(lecture);

            _repository.SaveChanges();
        }
        public void DeleteStudent(int studentId)
        {
            Student student = _repository.RetrieveStudentById(studentId);

            _repository.DeleteStudent(student);

            _repository.SaveChanges();
        }
    }
}
