using System;
using System.Collections.Generic;

namespace Task.DAL.Models
{
    public partial class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime HiringDate { get; set; }
   
    }
}
