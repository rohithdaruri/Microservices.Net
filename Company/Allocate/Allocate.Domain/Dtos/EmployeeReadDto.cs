using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Allocate.Domain.Dtos
{
    public class EmployeeReadDto
    {
        public string Id { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeMail { get; set; }
        public string TechnicalStack { get; set; }
        public bool MappedToProject { get; set; }
    }
}
