using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onboard.Data.Entities
{
    public class Employee
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public long ContactNumber { get; set; }
        [Required]
        public string TechnicalStack { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [Required]
        public DateTime Joined { get; set; }
        public DateTime? Relieve { get; set; }
        public bool MappedToProject { get; set; } // Inserted once the Mapped to Project in Allocate API
    }
}
