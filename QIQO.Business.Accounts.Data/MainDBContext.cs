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
            _conString = @"Data Source=tcp:192.168.1.65,55403;User ID=businessuser;Password=businessuser512;Database=DevII;Application Name=QIQOBusinessAccountsMicroService";
            //ConfigurationManager.ConnectionStrings["Main"].ConnectionString;
            _con = new SqlConnection(_conString);
        }

        public override int ExecuteProcedureNonQuery(string procedureName, IEnumerable<SqlParameter> parameters)
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
                _con.Close();
            }

        }
    }

}
