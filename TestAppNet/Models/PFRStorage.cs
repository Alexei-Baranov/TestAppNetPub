using System;

namespace TestAppNet.Models
{
    public class PFRStorage
    {
        public int Id { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public decimal Sum { get; set; }


        public int PersonId { get; set; }
        public Person Person { get; set; }
    }
}