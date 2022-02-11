using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onboard.Domain.Dtos
{
    public class EmployeeUpdateDto
    {
        [Required]
        public long ContactNumber { get; set; }
    }
}
