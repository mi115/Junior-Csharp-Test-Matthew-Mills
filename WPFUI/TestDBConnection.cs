using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace WPFUI
{
    public static class TestDBConnection
    {
        public static bool IsAvailable(this MySqlConnection conn)
        {
            try
            {
                conn.Open();
                conn.Close();
            }
            catch (MySqlException)
            {
                return false;
            }
            return true;
        }
    }
}
