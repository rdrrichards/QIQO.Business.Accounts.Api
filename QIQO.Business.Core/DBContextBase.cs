using QIQO.Business.Core.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace QIQO.Business.Core
{
    public class DBContextBase
    {
        protected string _conString;
        protected SqlConnection _con;
        protected SqlTransaction _trans;

        public virtual void ReleaseConnection() => _con.Close();
        public virtual void BeginTransaction() => _con.BeginTransaction();
        public virtual void CommitTransaction() => _trans.Commit();
        public virtual void Cancel()
        {
            _trans.Rollback();
            _con.Close();
        }

        public virtual void ExecuteProcedureAsReader(string procedureName, IEnumerable<SqlParameter> parameters) => throw new NotImplementedException();

        public virtual int ExecuteProcedureNonQuery(string procedureName, IEnumerable<SqlParameter> parameters)
        {
            var cmd = new SqlCommand(procedureName, _con) { CommandType = CommandType.StoredProcedure };
            int ret_val;

            foreach (var sparam in parameters)
                cmd.Parameters.Add(BuildParameter(sparam));

            try
            {
                _con.Open();
                ret_val = cmd.ExecuteNonQuery();
                _con.Close();
                return ret_val;
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                throw ex;
            }
            finally
            {
                _con.Close();
            }

        }

        public virtual int ExecuteNonQuerySQLStatement(string sqlStatement)
        {
            int ret_val = 0;
            var cmd = new SqlCommand(sqlStatement, _con) { CommandType = CommandType.StoredProcedure };

            try
            {
                _con.Open();
                ret_val = cmd.ExecuteNonQuery();
                _con.Close();
                return ret_val;
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                throw ex;
            }
            finally
            {
                _con.Close();
            }
        }

        public virtual int ExecuteNonQuerySQLStatement(string sqlStatement, IEnumerable<SqlParameter> parameters) => throw new NotImplementedException();
        public virtual DataTable ExecuteSqlStatementAsDataTable(string sqlStatement) => throw new NotImplementedException();
        public virtual DataTable ExecuteSqlStatementAsDataTable(string sqlStatement, IEnumerable<SqlParameter> parameters) => throw new NotImplementedException();
        public virtual T ExecuteSqlStatementAsScalar<T>(string sqlStatement) => throw new NotImplementedException();

        public virtual T ExecuteSqlStatementAsScalar<T>(string sqlStatement, IEnumerable<SqlParameter> parameters)
        {
            var cmd = new SqlCommand(sqlStatement, _con) { CommandType = CommandType.StoredProcedure };

            foreach (var sparam in parameters)
                cmd.Parameters.Add(BuildParameter(sparam));

            T ret_val;
            try
            {
                _con.Open();
                ret_val = (T)cmd.ExecuteScalar();
                _con.Close();
                return ret_val;
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                throw ex;
            }
            finally
            {
                _con.Close();
            }
        }

        public virtual SqlConnection GetConnection() => new SqlConnection(_conString);
        public virtual SqlTransaction GetTransaction() => _trans;
        public virtual void Dispose() => _con.Close();
        public string Database => _con.Database;
        public string Server => _con.DataSource;

        protected SqlParameter BuildParameter(SqlParameter sparam)
        {
            return new SqlParameter()
            {
                ParameterName = sparam.ParameterName,
                Value = sparam.Value,
                DbType = sparam.DbType,
                Direction = sparam.Direction,
                TypeName = sparam.TypeName
            };
        }

        public SqlDataReader ExecuteProcedureAsSqlDataReader(string procedureName, IEnumerable<SqlParameter> parameters)
        {
            var cmd = new SqlCommand(procedureName, _con) { CommandType = CommandType.StoredProcedure };

            foreach (var sparam in parameters)
                cmd.Parameters.Add(BuildParameter(sparam));

            try
            {
                _con.Open();
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                throw ex;
            }
        }

        public SqlDataReader ExecuteProcedureAsSqlDataReader(string procedureName)
        {
            var cmd = new SqlCommand(procedureName, _con) { CommandType = CommandType.StoredProcedure };

            try
            {
                _con.Open();
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                throw ex;
            }
        }

    }

}
