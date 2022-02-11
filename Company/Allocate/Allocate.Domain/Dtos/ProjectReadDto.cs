using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Allocate.Domain.Dtos
{
    public class ProjectReadDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string TechnicalStack { get; set; }
        public List<string> Employees { get; set; }
    }
}
