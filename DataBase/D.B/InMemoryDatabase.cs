using DataBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
namespace DataBase.D.B
{
    public class InMemoryDatabase
    {

        private List<Student> Students { get; set; }
        private List<Subject> Subjects { get; set; }

        public InMemoryDatabase()
        {
            Students = new List<Student>
            {

                new Student() { FullName = "Teodor Madjovski", EmailAdress = "ted.madzovski@gmail.com" },
                new Student() { FullName = "Teodor Madjovski", EmailAdress = "ted.madzovski@gmail.com" },
                new Student() { FullName = "Teodor Madjovski", EmailAdress = "ted.madzovski@gmail.com" },
                new Student() { FullName = "Teodor Madjovski", EmailAdress = "ted.madzovski@gmail.com" },

            };
            Subjects = new List<Subject>
            {
                new Subject()
                {
                    Credits=7,
                    Name="History",
                    Semester=2

                },
                new Subject()
                {
                    Credits=4,
                    Name="English",
                    Semester=1
                },
                new Subject(){
                    Credits=3,
                    Name="Geopgrahy",
                    Semester=1
                },
                new Subject(){
                    Credits=3,
                    Name="Math",
                    Semester=2
                } 

            };

    }

        public Student GetStudentByFullName(string fullname)
        {
            return Students.FirstOrDefault(_student => _student.FullName.ToLower() == fullname.ToLower());
        }

        public List<Student> GetStudents()
        {
            return Students;
        }

        public List<Subject> GetAllSubjects()
        {
            return Subjects;

        }

        public void AddStudent(Student student)
        {
            Students.Add(student);
        }
    }
}


    

