using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace WindowsFormsApplication18
{
    class BD
    {
        public MySqlConnection con = new MySqlConnection("server=localhost;port=3306;username=root;password=root;database=хворі");

        public void openCon()
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
        }

        public void closeCon()
        {
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
        }

        public MySqlConnection getCon()
        {
            return con;
        }
    }
}
