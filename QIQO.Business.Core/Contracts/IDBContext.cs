using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace QIQO.Business.Core.Contracts
{
    public interface IDBContext : IDisposable
    {
        void ReleaseConnection();
        void BeginTransaction();
        void CommitTransaction();
        void Cancel();

        void ExecuteProcedureAsReader(string procedureName, IEnumerable<SqlParameter> parameters);
        int ExecuteProcedureNonQuery(string procedureName, IEnumerable<SqlParameter> parameters);

        int ExecuteNonQuerySQLStatement(string sqlStatement);
        int ExecuteNonQuerySQLStatement(string sqlStatement, IEnumerable<SqlParameter> parameters);

        DataTable ExecuteSqlStatementAsDataTable(string sqlStatement);
        DataTable ExecuteSqlStatementAsDataTable(string sqlStatement, IEnumerable<SqlParameter> parameters);

        SqlDataReader ExecuteProcedureAsSqlDataReader(string sqlStatement);
        SqlDataReader ExecuteProcedureAsSqlDataReader(string sqlStatement, IEnumerable<SqlParameter> parameters);

        T ExecuteSqlStatementAsScalar<T>(string sqlStatement);
        T ExecuteSqlStatementAsScalar<T>(string sqlStatement, IEnumerable<SqlParameter> parameters);

        SqlConnection GetConnection();
        SqlTransaction GetTransaction();

        string Database { get; }
        string Server { get; }
    }

}
