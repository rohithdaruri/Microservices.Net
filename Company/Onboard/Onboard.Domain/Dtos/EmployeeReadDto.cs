using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onboard.Domain.Dtos
{
    public class EmployeeReadDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long ContactNumber { get; set; }
        public string TechnicalStack { get; set; }
        public bool IsActive { get; set; }
        public DateTime Joined { get; set; }
        public DateTime? Relieve { get; set; }
        public bool MappedToProject { get; set; }
    }
}
