using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Web2_Ver2
{
    public class ThongKeCode
    {
        public static int DonXuat()
        {
            int SLDX = 0;
            DBConnection conn = new DBConnection();
            conn.GetConnection();
            String sql = "SELECT trangthai FROM tbl_ThongKe";
            SqlCommand cmd = new SqlCommand(sql, conn.GetConnection());
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                String trangthai = dr["trangthai"].ToString();
                if(trangthai == "Xuất Hàng")
                {
                    SLDX++;
                }
            }
            conn.CloseConnection();
            return SLDX;
        }

        public static int DonNhap()
        {
            int SLDN = 0;
            DBConnection conn = new DBConnection();
            conn.GetConnection();
            String sql = "SELECT trangthai FROM tbl_ThongKe";
            SqlCommand cmd = new SqlCommand(sql, conn.GetConnection());
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                String trangthai = dr["trangthai"].ToString();
                if (trangthai == "Nhập Hàng")
                {
                    SLDN++;
                }
            }
            conn.CloseConnection();
            return SLDN;
        }
    }
}