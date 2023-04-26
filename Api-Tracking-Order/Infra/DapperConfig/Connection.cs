using Dapper;
using Domain.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.DapperConfig
{
    public class Connection : IConnection
    {
        private static readonly int TimeOut = 0;
        private static readonly string ConnectionString = Setting.ConnectionString;
        public async Task<bool> ExecCommand(string sqlQuery)
        {
            using var connection = new SqlConnection(ConnectionString);
            return await connection.ExecuteAsync(sqlQuery, commandTimeout: TimeOut) > 0;
        }

        public async Task<T> ExecProcedure<T>(string sqlQuery)
        {
            using var connection = new SqlConnection(ConnectionString);
            return await connection.QueryFirstOrDefaultAsync<T>(sqlQuery, commandTimeout: TimeOut);
        }

        public async Task<T> ExecSelect<T>(string sqlQuery)
        {
            using var connection = new SqlConnection(ConnectionString);
            return await connection.QueryFirstOrDefaultAsync<T>(sqlQuery);
        }

        public async Task<IEnumerable<T>> ExecSelectList<T>(string sqlQuery)
        {
            using var connection = new SqlConnection(ConnectionString);
            return await connection.QueryAsync<T>(sqlQuery, commandTimeout: TimeOut);
        }
    }
}
