using Egzas_Databasu.Database;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Egzas_Databasu
{
    public class DbRepository
    {
        private readonly StudentsDbContext _dbContext;
        public DbRepository()
        {
            _dbContext = new StudentsDbContext();
        }
        public void AddDepartment(Department department)
        {
            _dbContext.Departments.Add(department);
        }
        public void AddLecture(Lecture lecture)
        {
            _dbContext.Lectures.Add(lecture);
        }
        public void AddStudent(Student student)
        {
            _dbContext.Students.Add(student);
        }
        public void DeleteDepartment(Department department)
        {
            _dbContext.Departments.Remove(department);
        }
        public void DeleteLecture(Lecture lecture)
        {
            _dbContext.Lectures.Remove(lecture);
        }
        public void DeleteStudent(Student student)
        {
            _dbContext.Students.Remove(student);
        }
        public List<Department> RetrieveDepartments()
        {
            return _dbContext.Departments.Include(x => x.Lectures).Include(x => x.Students).ToList();
        }
        public Department RetrieveDepartmentById(int id)
        {
            return _dbContext.Departments.Include(x => x.Lectures).Include(x => x.Students).FirstOrDefault(x => x.Id == id);
        }
        public List<Lecture> RetrieveLectures()
        {
            return _dbContext.Lectures.Include(x => x.Departments).Include(x => x.Students).ToList();
        }
        public Lecture RetrieveLectureById(int id)
        {
            return _dbContext.Lectures.Include(x => x.Departments).Include(x => x.Students).FirstOrDefault(x => x.Id == id);
        }
        public List<Student> RetrieveStudents()
        {
            return _dbContext.Students.Include(x => x.Lectures).ToList();
        }
        public Student RetrieveStudentById(int id)
        {
            return _dbContext.Students.Include(x => x.Lectures).FirstOrDefault(x => x.Id == id);
        }
        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
