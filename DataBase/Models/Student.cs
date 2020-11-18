using System;
using System.Collections.Generic;
using System.Text;

namespace DataBase.Models
{
    public class Student
    {
        public string FullName { get; set; }
        public string EmailAdress { get; set; }
        public string StudentNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public List<Subject> Subjects { get; set; }
    }
}
