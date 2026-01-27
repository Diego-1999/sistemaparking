using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace SistemaParking.Datos
{
    public abstract class ConnectionSql
    {
        private readonly string connectionString;
        public ConnectionSql()
        {
            connectionString = "Data Source=DIEGOCHACON\\SQLDEVELOPER;Initial Catalog=db_sistemaparking;User=sa; Password=diego1999; TrustServerCertificate=true";
        }
        protected SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
