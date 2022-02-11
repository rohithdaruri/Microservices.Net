using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onboard.Domain.Dtos
{
    public class EmployeeCreateDto
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public long ContactNumber { get; set; }
        [Required]
        public string TechnicalStack { get; set; }
    }
}
