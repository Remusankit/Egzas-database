using System;
using System.Drawing;
using System.Threading;
using Console = Colorful.Console;

namespace Egzas_Databasu
{
    public class UserInterface
    {
        private readonly BusinessLogic _businessLogic;
        public UserInterface()
        {
            _businessLogic = new BusinessLogic();
        }

        public void Controls()
        {
            Console.Title = "Uni Database";
            string title = @"
 /\ /\ _ __ (_)_   _____ _ __ ___(_) |_ _   _ 
/ / \ \ '_ \| \ \ / / _ \ '__/ __| | __| | | |
\ \_/ / | | | |\ V /  __/ |  \__ \ | |_| |_| |
 \___/|_| |_|_| \_/ \___|_|  |___/_|\__|\__, |
                                        |___/ 
    ___      _        _                       
   /   \__ _| |_ __ _| |__   __ _ ___  ___    
  / /\ / _` | __/ _` | '_ \ / _` / __|/ _ \   
 / /_// (_| | || (_| | |_) | (_| \__ \  __/   
/___,' \__,_|\__\__,_|_.__/ \__,_|___/\___|   ";
            Console.WriteLine(title);
            for (int i = 0; i <= 100; i++)
            {
                Console.Write($"\rProgress: {i}%   ");
                Thread.Sleep(25);
            }

            Console.Write("\rDone!          ");
            Console.ReadLine();

            bool repeat = true;
            string userInput;

            while (repeat)
            {
                Console.Clear();
                Console.Title = "Menu_1";
                string menu = @" 
  /\/\   ___ _ __  _   _ 
 /    \ / _ \ '_ \| | | |
/ /\/\ \  __/ | | | |_| |
\/    \/\___|_| |_|\__,_|
 ";
                Console.WriteLine(menu);
                Console.WriteLine("[1]-Add Department, Student or Lecture " +
                    "\n[2]-See All Departments, Students or Lectures" +
                    "\n[3]-Show By Department, Student or Lecture" +
                    "\n[4]-Assign Department, Student or Lecture" +
                    "\n[5]-Delete Department, Student or Lecture" +
                    "\n[6]-Exit");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        Console.Clear();
                        CreateEntity();
                        break;
                    case "2":
                        Console.Clear();
                        ShowAllEntities();
                        break;
                    case "3":
                        Console.Clear();
                        ShowBy();
                        break;
                    case "4":
                        Console.Clear();
                        Assign();
                        break;
                    case "5":
                        Console.Clear();
                        Delete();
                        break;
                    case "6":
                        Console.Clear();
                        repeat = false;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Wrong input", Color.Red);
                        Console.ReadLine();
                        break;
                }
            }
        }
        public void CreateEntity()
        {
            bool repeat = true;
            string userInput;

            while (repeat)
            {
                Console.Clear();
                Console.WriteLine("Select what do you want to add:\n[1]-Department \n[2]-Lecture\n[3]-Student\n[4]-Return");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("Enter department's name:");
                        string DepartmentName = Console.ReadLine();
                        _businessLogic.CreateDepartment(DepartmentName);
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine("Enter lectures's name:");
                        string lectureName = Console.ReadLine();
                        Console.WriteLine("Enter lectures's number:");
                        int kelint = Int32.Parse(Console.ReadLine());
                        _businessLogic.CreateLecture(lectureName,kelint);
                        break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine("Enter student's name:");
                        string studentName = Console.ReadLine();
                        Console.WriteLine("Enter student's age:");
                        int age = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Enter student's surename:");
                        string pavard = Console.ReadLine();
                        Console.WriteLine("Enter student's iq:");
                        int iq = Int32.Parse(Console.ReadLine());
                        _businessLogic.CreateStudent(studentName, age, pavard,iq);
                        break;
                    case "4":
                        Console.Clear();
                        Console.Clear();
                        repeat = false;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Wrong input, try again", Color.Red);
                        Console.ReadLine();
                        break;
                }
            }
        }
        public void ShowAllEntities()
        {
            bool repeat = true;
            string userInput;

            while (repeat)
            {
                Console.Clear();
                Console.WriteLine("Select what do you want to see:\n[1]-All departments\n[2]-All lectures\n[3]-All students\n[4]-Return");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        Console.Clear();
                        _businessLogic.ShowDepartments();
                        Console.ReadLine();
                        break;
                    case "2":
                        Console.Clear();
                        _businessLogic.ShowLectures();
                        Console.ReadLine();
                        break;
                    case "3":
                        Console.Clear();
                        _businessLogic.ShowStudents();
                        Console.ReadLine();
                        break;
                    case "4":
                        Console.Clear();
                        Console.Clear();
                        repeat = false;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Wrong input, try again", Color.Red);
                        Console.ReadLine();
                        break;
                }
            }
        }
        public void ShowBy()
        {
            bool repeat = true;
            string userInput;

            while (repeat)
            {
                Console.Clear();
                Console.WriteLine("Select what do you want to see:\n[1]-Departments by lecture\n[2]-Department by student\n[3]-Lectures by department\n[4]-Lectures by student\n[5]-Students by department\n[6]-Students by lecture\n[7]-Return");
                userInput = Console.ReadLine();

                int departmentId;
                int lectureId;
                int studentId;

                switch (userInput)
                {
                    case "1":
                        Console.Clear();

                        lectureId = GetLectureId();

                        Console.Clear();

                        _businessLogic.ShowDepartmentsByLecture(lectureId);

                        Console.ReadLine();
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine("Enter student's ID:");

                        _businessLogic.ShowStudents();

                        Console.WriteLine();

                        studentId = Int32.Parse(Console.ReadLine());

                        Console.Clear();

                        _businessLogic.ShowDepartmentByStudent(studentId);

                        Console.ReadLine();
                        break;
                    case "3":
                        Console.Clear();

                        departmentId = GetDepartmentId();

                        Console.Clear();

                        _businessLogic.ShowLecturesByDepartment(departmentId);

                        Console.ReadLine();
                        break;
                    case "4":
                        Console.Clear();

                        studentId = GetStudentId();

                        Console.Clear();

                        _businessLogic.ShowLecturesByStudent(studentId);

                        Console.ReadLine();
                        break;
                    case "5":
                        Console.Clear();

                        departmentId = GetDepartmentId();

                        Console.Clear();

                        _businessLogic.ShowStudentsByDepartment(departmentId);

                        Console.ReadLine();
                        break;
                    case "6":
                        Console.Clear();

                        lectureId = GetLectureId();

                        Console.Clear();

                        _businessLogic.ShowStudentsByLecture(lectureId);

                        Console.ReadLine();
                        break;
                    case "7":
                        Console.Clear();
                        repeat = false;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Wrong input, try again", Color.Red);
                        Console.ReadLine();
                        break;
                }
            }
        }
        public void Assign()
        {
            bool repeat = true;
            string userInput;

            while (repeat)
            {
                Console.Clear();
                Console.WriteLine("Select what do you want to assign:\n[1]-Department to lecture\n[2]-Department to student\n[3]-Student to lecture\n[4]-Return");
                userInput = Console.ReadLine();

                int departmentId;
                int lectureId;
                int studentId;

                switch (userInput)
                {
                    case "1":
                        Console.Clear();

                        departmentId = GetDepartmentId();

                        Console.Clear();

                        lectureId = GetLectureId();

                        _businessLogic.AssignDepartmentToLecture(departmentId, lectureId);
                        break;
                    case "2":
                        Console.Clear();

                        departmentId = GetDepartmentId();

                        Console.Clear();

                        studentId = GetStudentId();

                        _businessLogic.AssignDepartmentToStudent(departmentId, studentId);
                        break;
                    case "3":
                        Console.Clear();

                        studentId = GetStudentId();

                        Console.Clear();

                        lectureId = GetLectureId();

                        _businessLogic.AssignStudentToLecture(studentId, lectureId);
                        break;
                    case "4":
                        Console.Clear();
                        repeat = false;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Wrong input, try again", Color.Red);
                        Console.ReadLine();
                        break;
                }
            }
        }
        public void Delete()
        {
            bool repeat = true;
            string userInput;

            while (repeat)
            {
                Console.Clear();
                Console.WriteLine("Select what do you want to delete:\n[1]-Department\n[2]-Lecture\n[3]-Student\n[4]-Return");
                userInput = Console.ReadLine();

                int departmentId;
                int lectureId;
                int studentId;

                switch (userInput)
                {
                    case "1":
                        Console.Clear();

                        departmentId = GetDepartmentId();

                        _businessLogic.DeleteDepartment(departmentId);

                        break;
                    case "2":
                        Console.Clear();

                        lectureId = GetLectureId();

                        _businessLogic.DeleteLecture(lectureId);

                        break;
                    case "3":
                        Console.Clear();

                        studentId = GetStudentId();

                        _businessLogic.DeleteStudent(studentId);

                        break;
                    case "4":
                        Console.Clear();
                        repeat = false;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Wrong input, try again", Color.Red);
                        Console.ReadLine();
                        break;
                }
            }
        }
        public int GetDepartmentId()
        {
            Console.WriteLine("Enter department's ID:", Color.Blue);

            _businessLogic.ShowDepartments();

            Console.WriteLine();

            return Int32.Parse(Console.ReadLine());
        }
        public int GetLectureId()
        {
            Console.WriteLine("Enter lecture's ID:", Color.Yellow);

            _businessLogic.ShowLectures();

            Console.WriteLine();

            return Int32.Parse(Console.ReadLine());
        }
        public int GetStudentId()
        {
            Console.WriteLine("Enter student's ID:", Color.Green);

            _businessLogic.ShowStudents();
            Console.WriteLine();

            return Int32.Parse(Console.ReadLine());
        }
    }


}
