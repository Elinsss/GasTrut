using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GasTrut
{
    public class db
    {
        static string serverName = @"WIN-O0RH17IT5C5";
        static string dbName = "InventoryManagement";

        public SqlConnection con = new SqlConnection($@"Data Source={serverName}; Initial Catalog={dbName};Integrated Security = True");
    }
}
