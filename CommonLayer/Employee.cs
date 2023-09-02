using System;
using System.ComponentModel.DataAnnotations;

namespace CommonLayer
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string ImageLink { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public string Department { get; set; }

        [Required]
        public long Salary { get; set; }

        [Required]
        public DateTime StartDate { get; set; }
        public string Note { get; set; }
    }
}
