using System;
using System.Collections.Generic;

namespace TestAppNet.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string SecondName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public DateTime DateOfBirt { get; set; }
        public string SNILS { get; set; }
        public List<PFRStorage> PfrStorages { get; set; }

    }
}