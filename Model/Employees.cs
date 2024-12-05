﻿using System.ComponentModel.DataAnnotations;

namespace InyeccionDependencias.Model
{
    public class Employees
    {

        [Key]
        public int EmployeeID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Title { get; set; }
        public string Country { get; set; }

        public string City { get; set; }
        public DateTime BirthDate { get; set; }
       

    }
}
