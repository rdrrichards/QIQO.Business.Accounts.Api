﻿using QIQO.Business.Core.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace QIQO.Business.Core
{
    public class DBContextBase
    {
        protected static string conString;
        protected SqlConnection con;
        protected SqlTransaction _trans;

        public virtual void ReleaseConnection()
        {
            con.Close();
        }

        public virtual void BeginTransaction()
        {
            _trans = con.BeginTransaction();
        }

        public virtual void CommitTransaction()
        {
            _trans.Commit();
        }

        public virtual void Cancel()
        {
            _trans.Rollback();
            con.Close();
        }

        public virtual void ExecuteProcedureAsReader(string procedureName, IEnumerable<SqlParameter> parameters)
        {
            throw new NotImplementedException();
        }

        public virtual int ExecuteProcedureNonQuery(string procedureName, IEnumerable<SqlParameter> parameters)
        {
            SqlCommand cmd = new SqlCommand(procedureName, con);
            cmd.CommandType = CommandType.StoredProcedure;
            int ret_val;

            foreach (SqlParameter sparam in parameters)
            {
                SqlParameter param = new SqlParameter();
                //Log.Info(sparam.ParameterName);
                param.ParameterName = sparam.ParameterName;
                param.Value = sparam.Value;
                param.DbType = sparam.DbType;
                param.Direction = sparam.Direction;
                param.TypeName = sparam.TypeName;
                cmd.Parameters.Add(param);
            }

            try
            {
                con.Open();
                ret_val = cmd.ExecuteNonQuery();
                con.Close();
                //if (cmd.Parameters["@key"] != null)
                //{
                //    int key = (int)cmd.Parameters["@key"].Value;
                //    if (key > ret_val)
                //        return key;
                //}
                return ret_val;
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                throw ex;
            }
            finally
            {
                con.Close();
            }

        }

        public virtual int ExecuteNonQuerySQLStatement(string sqlStatement)
        {
            //throw new NotImplementedException();
            int ret_val = 0;
            SqlCommand cmd = new SqlCommand(sqlStatement, con);
            cmd.CommandType = CommandType.Text;

            try
            {
                con.Open();
                ret_val = cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return ret_val;
        }

        public virtual int ExecuteNonQuerySQLStatement(string sqlStatement, IEnumerable<SqlParameter> parameters)
        {
            throw new NotImplementedException();
        }

        public virtual DataTable ExecuteSqlStatementAsDataTable(string sqlStatement)
        {
            throw new NotImplementedException();
        }

        public virtual DataTable ExecuteSqlStatementAsDataTable(string sqlStatement, IEnumerable<SqlParameter> parameters)
        {
            throw new NotImplementedException();
        }

        public virtual T ExecuteSqlStatementAsScalar<T>(string sqlStatement)
        {
            throw new NotImplementedException();
        }

        public virtual T ExecuteSqlStatementAsScalar<T>(string sqlStatement, IEnumerable<SqlParameter> parameters)
        {
            SqlCommand cmd = new SqlCommand(sqlStatement, con);
            cmd.CommandType = CommandType.StoredProcedure;

            foreach (SqlParameter sparam in parameters)
            {
                SqlParameter param = new SqlParameter();
                param.ParameterName = sparam.ParameterName;
                param.Value = sparam.Value;
                param.DbType = sparam.DbType;
                param.Direction = sparam.Direction;
                param.TypeName = sparam.TypeName;
                cmd.Parameters.Add(param);
            }

            T ret_val;
            try
            {
                con.Open();
                ret_val = (T)cmd.ExecuteScalar();
                con.Close();
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return ret_val;
        }

        public virtual SqlConnection GetConnection()
        {
            con = new SqlConnection(conString);
            return con;
        }

        public virtual SqlTransaction GetTransaction()
        {
            return _trans;
        }

        public virtual void Dispose()
        {
            con.Close();
        }

        public string Database => con.Database;
        public string Server => con.DataSource;

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
            var cmd = new SqlCommand(procedureName, con);
            cmd.CommandType = CommandType.StoredProcedure;

            foreach (var sparam in parameters)
            {
                cmd.Parameters.Add(BuildParameter(sparam));
            }
            con.Open();
            return cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }

        public SqlDataReader ExecuteProcedureAsSqlDataReader(string procedureName)
        {
            var cmd = new SqlCommand(procedureName, con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            return cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }

    }

}
