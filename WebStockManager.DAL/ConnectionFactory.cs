using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
namespace WebStockManager.DAL
{

 internal class ConnectionFactory
    {

        public static DbConnection GetOpenConnection()
        {
            // string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString; 
            string connStr = @"server=127.0.0.1;uid=sa;pwd=321456852;database=dbstock;";
			var connection = new  System.Data.SqlClient.SqlConnection(connStr); 
            connection.Open(); 
            return connection;

        }

    }


   
}
