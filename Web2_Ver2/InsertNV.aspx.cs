using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web2_Ver2
{
    public partial class InsertNV : System.Web.UI.Page
    {
        String id, name, cv, email, tk, mk, day;
        DBConnection Conn = new DBConnection();
        String AlertInsertSuccess = "swal('Thêm Sản Phẩm Thành Công');";
        String AlertInsertError = "swal('Mã Sản Phẩm Bị Trùng');";
        string AlertComfirm = "if (confirm('Thêm Sản Phẩm thành công. Bạn có muốn tiếp tục thêm dữ liệu mới?'))" +
                        "{ window.location.href = 'InsertNV.aspx'; } else { window.location.href = 'Home.aspx'; }";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnInsert_CLick(object sender, EventArgs e)
        {
            id = txtId.Value;
            name = txtName.Value;
            cv = ListChucVu.Value;
            email = txtEmail.Value;
            tk = txtTaiKhoan.Value;
            mk = txtMatKhau.Value;
            day = Date.GetCurrentDateTimeString();

            try
            {
                Conn.GetConnection();
                String insert = "INSERT INTO  tbl_Accounts (manhanvien, tennhanvien, chucvu," +
                                "email, taikhoan, matkhau, ngaycapnhat)" +
                                "VALUES (@id, @name, @cv, @email, @tk, @mk, @day)";

                SqlCommand cmd = new SqlCommand(insert, Conn.GetConnection());
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@cv", cv);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@tk", tk);
                cmd.Parameters.AddWithValue("@mk", mk);
                cmd.Parameters.AddWithValue("@day", day);

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
            }


        }
    }
}