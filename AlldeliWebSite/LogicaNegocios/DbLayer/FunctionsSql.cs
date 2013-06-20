using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;

namespace Alldeli.LogicLayer.DbLayer
{
    public class FunctionsSql
    {
        private const string strcn = "cn";
        public static SqlConnection GetConnection()
        {
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings[strcn].ConnectionString);
            cn.Open();
            return cn;
        }
    }
}
