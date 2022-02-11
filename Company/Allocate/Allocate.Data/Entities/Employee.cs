using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Allocate.Data.Entities
{
    public class Employee
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeMail { get; set; }
        public string TechnicalStack { get; set; }
        public bool MappedToProject { get; set; }
    }
}
