using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace Web2_Ver2
{
    public class DBConnection
    {
        private SqlConnection Conn;

        public SqlConnection GetConnection()
        {
            try
            {
                if (Conn == null)
                {
                    String StrConn = WebConfigurationManager.ConnectionStrings["StrConn"].ToString();
                    Conn = new SqlConnection(StrConn);
                }

                if (Conn.State != System.Data.ConnectionState.Open)
                {
                    Conn.Open();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi mở kết nối: " + ex.Message);
            }

            return Conn;
        }

        public void CloseConnection()
        {
            try
            {
                if (Conn != null && Conn.State != System.Data.ConnectionState.Closed)
                {
                    Conn.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi đóng kết nối: " + ex.Message);
            }
        }
    }
}