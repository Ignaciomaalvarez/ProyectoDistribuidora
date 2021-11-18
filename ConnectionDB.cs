using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion
{


    public class ConnectionDB
    {
        public SqlConnection Connection
            {
            get;set;
            }

        public ConnectionDB()
        {


            string connection = ConfigurationManager.ConnectionStrings["Gestion.Properties.Settings.Gestion_distConnectionString"].ConnectionString;


            Connection = new SqlConnection(connection);

            

        }

        
    }
}