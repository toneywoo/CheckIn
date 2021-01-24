using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CheckInAPI
{
    public class MysqlHelper
    {
        //private static MySqlConnection conn;
        static public DataSet Query(string constr,string sql)
        {
            MySqlConnection conn = new MySqlConnection(constr);
            conn.Open();
            DataSet reds = new DataSet();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
            //cmd.ExecuteReader
            MySql.Data.MySqlClient.MySqlDataAdapter da = new MySql.Data.MySqlClient.MySqlDataAdapter(cmd);
            da.Fill(reds);
            return reds;

        }
        static public int Exec(string constr, string sql)
        {
            MySqlConnection conn = new MySqlConnection(constr);
            conn.Open();
            DataSet reds = new DataSet();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
            return cmd.ExecuteNonQuery();
            
        }
    }
}
