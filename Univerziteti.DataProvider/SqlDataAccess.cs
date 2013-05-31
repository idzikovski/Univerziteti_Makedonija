using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Univerziteti.DataProvider.Properties;
using System.Data;

namespace Univerziteti.DataProvider
{
    public partial class SqlDataAccess
    {
        private SqlConnection connection = null;
        private string connectionString = Settings.Default.ConnectionString;

        public SqlConnection Connection
        {
            get
            {
                try
                {
                    if (connection == null)
                    {
                        connection = new SqlConnection(connectionString);
                    }
                    if (connection.State != ConnectionState.Open)
                    {
                        connection.Open();
                    }
                    return connection;
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }
    }
}
