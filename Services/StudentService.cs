using DataBase.D.B;
using DataBase.Models;
using Microsoft.EntityFrameworkCore.InMemory.Storage.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services
{
   public  class StudentService
    { {
        private readonly DataBase.D.B.InMemoryDatabase _inMemoryDatabase;

        public StudentService()
        {
            _inMemoryDatabase = new DataBase.D.B.InMemoryDatabase();
        }


        public void Register()
        {

            Console.WriteLine("Please Enter  Full Name:");
            string fullName = Console.ReadLine();
            Console.WriteLine("Enter Your Email Address:");
            string email = Console.ReadLine();
            bool emailInput = ValidateEmail(email);
            if (!emailInput)
            {
                Console.WriteLine("Please enter a valid email:");


            }

            Console.WriteLine("Please enter a valid phone number:");
            string phoneNumber = Console.ReadLine();
            bool phoneNumberInput = ValidatePhoneNumber(phoneNumber);
            if (!phoneNumberInput)
            {
                Console.WriteLine("Please enter a valid number. Ex:+389-xx-xxx-xxx");
            }

            Console.WriteLine("Please select the first subject navigate from 1 to 4");
            ListAllSubjects();
            var listOfStudentSubjects = new List<Subject>();

            int firstSubjectInput = int.Parse(Console.ReadLine());
            foreach (var subject in _inMemoryDatabase.GetAllSubjects())
            {
                if (firstSubjectInput == subject.Id)
                {
                    var firstSubject = _inMemoryDatabase.GetAllSubjects().FirstOrDefault(subject => subject.Id == firstSubjectInput);
                    listOfStudentSubjects.Add(firstSubject);
                }
            }
            Console.WriteLine("Please select the second subject:");
            int secondSubjectInput = int.Parse(Console.ReadLine());
            foreach (var subject in _inMemoryDatabase.GetAllSubjects())
            {
                if (secondSubjectInput == subject.Id)
                {
                    var secondSubject = _inMemoryDatabase.GetAllSubjects().FirstOrDefault(subject => subject.Id == secondSubjectInput);
                    listOfStudentSubjects.Add(secondSubject);
                }
            }
            var student = new Student()
            {
                FullName = fullName,
                PhoneNumber = phoneNumber,
                EmailAddress = email,
                Subjects = listOfStudentSubjects
            };
            _inMemoryDatabase.AddStudent(student);
            Console.WriteLine("You were successfully registered!" + student.FullName);
        }
        private bool ValidateEmail(string email)
        {
            if (!email.Contains('@'))
            {
                return false;
            }
            string[] emailParts = email.Split('@');
            if (emailParts.Length != 2)
            {
                return false;
            }

            if (emailParts[emailParts.Length - 1].Length <= 7
                && !emailParts[emailParts.Length - 1].Contains('.'))
            {
                return false;
            }

            return true;
        }
        private bool ValidatePhoneNumber(string phoneNumber)
        {
            if (phoneNumber.Length != 12 || !phoneNumber.StartsWith("+3897"))
            {
                return false;
            }
            return true;
        }
        private void ListAllSubjects()
        {
            for (int i = 0; i < _inMemoryDatabase.GetAllSubjects().Count; i++)
            {
                Console.WriteLine($"{i + 1}.{_inMemoryDatabase.GetAllSubjects()[i].Name}");
            }
        }
    }
}
