using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onboard.Data.ApiModels
{
    public record ResponseModel(bool IsSuccess, string Description, object data = null);
}
