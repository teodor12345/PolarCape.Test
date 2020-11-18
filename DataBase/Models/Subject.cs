using System;
using System.Collections.Generic;
using System.Text;

namespace DataBase.Models
{
   public  class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Semester { get; set; }
        public int Credits { get; set; }
    }
}
