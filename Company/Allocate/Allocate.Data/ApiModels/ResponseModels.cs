using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Allocate.Data.ApiModels
{
    public record ResponseModel(bool IsSuccess, string Description, object data = null);
}
