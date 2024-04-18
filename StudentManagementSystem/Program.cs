using System;
using System.Linq;
using System.Collections.Generic;


namespace StudentManagement
{
    class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Course { get; set; }
    }
    class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
    }
    class StudentManager
    {
        public List<Student> students = new List<Student>()
        {
            new Student() { Id = 1,Name="Vivek",Age=22,Course="BscComputerscience"},
            new Student() { Id = 2,Name="Binnu",Age=21,Course="BscComputerscience"},
            new Student() { Id = 3,Name="Sreena",Age=21,Course="BscPhysics"},
            new Student() { Id = 4,Name="Asmi",Age=21,Course="BscChemistry"},
            new Student() { Id = 5,Name="Harsha",Age=21,Course="BscChemistry"}
        };
        public void AddingStudent(Student data)
        {
            int newid = students.Count + 1;
            students.Add(new Student {Id=newid,Name=data.Name,Age=data.Age,Course=data.Course });
        }
        public void ViewStudents()
        {
            students.ForEach(student =>
            {
            Console.WriteLine($"Name : {student.Name} \t Age : {student.Age} \t Course : {student.Course}");
            });
        }
        public void Deletestudent(int id)
        {
            students.RemoveAll(student => student.Id == id);
        }
        public void UpdateStudent(Student student)
        {
            var std = students.FirstOrDefault(student => student.Id == student.Id);
            std.Name= student.Name;
            std.Age= student.Age;
            std.Course= student.Course;
        }
        public void StudentsWithCertainAge(int age)
        {
            var res = from std in students where std.Age==age select std;
            foreach (var item in res)
            {
                Console.WriteLine($"Name : {item.Name}    Age : {item.Age}   Course  :  {item.Course}");

            }
        }
        public void StudentWithSpecificCourse(string course)
        {
            var res = from crs in students where crs.Course == course select crs;
            foreach (var item in res)
            {
                Console.WriteLine($"Name:{item.Name}   Course:{item.Course}  Age:{item.Age}");
            }
        }

    }
    class CourseManager
    {
        public List<Course> courses = new List<Course>()
        {
            new Course{CourseId=1,CourseName="BscComputerscience"},
            new Course{CourseId=2,CourseName="BscPhysics"},
        };
        public void AddingCourse(Course data)
        {
            int  newid=courses.Count + 1;
            courses.Add(new Course { CourseId = newid,CourseName=data.CourseName });
        }
        public void ViewCourses()
        {
            courses.ForEach(course =>
            {
                Console.WriteLine($"{course.CourseId} . {course.CourseName}");
            });
        }
    }
    class Program
    {
        public static void Main(string[] args)
        {
            StudentManager studentManager = new StudentManager();
            CourseManager courseManager = new CourseManager();
            studentManager.AddingStudent(new Student { Name = "bibin", Age = 21, Course = "BscBotony" });
            courseManager.AddingCourse(new Course { CourseName = "BscChemistry" });
            studentManager.UpdateStudent(new Student {Id=1, Name = "Bibin", Age = 22, Course = "BscChemistry" });
            courseManager.ViewCourses();
            studentManager.StudentsWithCertainAge(22);
            studentManager.ViewStudents();
            studentManager.Deletestudent(5);
            studentManager.StudentWithSpecificCourse("BscChemistry");
            studentManager.ViewStudents();
            Console.ReadLine();
        }
    }
}