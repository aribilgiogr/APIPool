using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.Models
{
    public record ResponseModel(string Message, bool Status = false, string StatusCode = "0")
    {
    }
}
