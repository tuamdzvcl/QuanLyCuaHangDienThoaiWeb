using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace Web2_Ver2
{
    public partial class Insert : System.Web.UI.Page
    {
        String id, name, th, color, dl, sl, gb;
        DBConnection Conn = new DBConnection();
        String AlertInsertSuccess = "swal('Thêm Sản Phẩm Thành Công');";
        String AlertInsertError = "swal('Mã Sản Phẩm Bị Trùng');";
        string AlertComfirm = "if (confirm('Thêm Sản Phẩm thành công. Bạn có muốn tiếp tục thêm dữ liệu mới?'))" +
                        "{ window.location.href = 'Insert.aspx'; } else { window.location.href = 'Home.aspx'; }";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnInsert_CLick(object sender, EventArgs e)
        {
            id =  txtId.Value;
            name = txtName.Value;
            th = txtThuongHieu.Value;
            color = txtMauSac.Value;
            dl = txtDungLuong.Value;
            gb = txtGiaBan.Value;

            try
            {
                Conn.GetConnection();
                String insert = "INSERT INTO  tbl_Products (masanpham, tensanpham, thuonghieu," +
                                "mausac, dungluong, giaban, ngaycapnhat,date)" +
                                "VALUES (@id, @name, @th, @color, @dl, @gb, @date,@datesapxep)";

                SqlCommand cmd = new SqlCommand(insert, Conn.GetConnection());
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@th", th);
                cmd.Parameters.AddWithValue("@color", color);
                cmd.Parameters.AddWithValue("@dl", dl);
                cmd.Parameters.AddWithValue("@gb", gb);
                cmd.Parameters.AddWithValue("@date", Date.GetCurrentDateTimeString());
                cmd.Parameters.AddWithValue("@datesapxep", Date.DateSapXep());

                int check = cmd.ExecuteNonQuery();

                if (check > 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "ConfirmScript", AlertComfirm, true);
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "PopupScript", AlertInsertError, true);
                }
            }
            catch (Exception ex)
            {
                string errorMessage = "Đã xảy ra lỗi: " + ex.Message;
                error123.InnerHtml = errorMessage;
            }


        }
    }
}