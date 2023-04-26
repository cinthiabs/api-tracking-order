using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface IConnection
    {
       Task<IEnumerable<T>> ExecSelectList<T>(string sqlQuery);
       Task<T> ExecSelect<T>(string sqlQuery);
       Task<bool> ExecCommand(string sqlQuery);
       Task<T> ExecProcedure<T>(string sqlQuery);
    }
}
