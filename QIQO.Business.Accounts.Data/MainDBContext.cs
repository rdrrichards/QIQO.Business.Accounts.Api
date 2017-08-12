using QIQO.Business.Core;
using QIQO.Business.Core.Contracts;
using QIQO.Business.Core.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace QIQO.Business.Accounts.Data
{
    public class MainDBContext : DBContextBase, IMainDBContext
    {
        public MainDBContext()
        {
            conString = @"Data Source=RDRRL8\D1;Integrated Security=SSPI;Database=DevII;Application Name=QIQO.Business.Accounts.MicroService";
            //ConfigurationManager.ConnectionStrings["Main"].ConnectionString;
            con = new SqlConnection(conString);
        }

        public override int ExecuteProcedureNonQuery(string procedureName, IEnumerable<SqlParameter> parameters)
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
                if (cmd.Parameters["@key"] != null)
                {
                    int key = (int)cmd.Parameters["@key"].Value;
                    if (key > ret_val)
                        return key;
                }
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
    }

}
