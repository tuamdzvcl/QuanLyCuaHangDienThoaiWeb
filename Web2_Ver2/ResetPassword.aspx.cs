using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web2_Ver2
{
    public partial class ResetPassword : System.Web.UI.Page
    {

        DBConnection Conn = new DBConnection();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnResetPassword_Click(object sender, EventArgs e)
        {
            String email = txtEmail.Value;

            if (email.Trim() == "")
            {
                string script = "swal('Email Không Được Để Trống');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "PopupScript", script, true);
            }
            else
            {
                Conn.GetConnection();
                String sql = "SELECT * FROM tbl_Accounts WHERE email='" + email + "'";
                SqlCommand sqlCommand = new SqlCommand(sql, Conn.GetConnection());
                using (SqlDataReader data = sqlCommand.ExecuteReader())
                {
                    if (data.Read())
                    {
                        string password = data["matkhau"].ToString();
                        string script = "if(confirm('Mật Khẩu Là: " + password + "')) { window.location.href = 'Login.aspx'; }";
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "swal", script, true);
                        data.Close();

                    }
                    else
                    {
                        data.Close();
                        string script = "swal('Email Không Tồn Tại');";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "PopupScript", script, true);

                    }
                }
            }
        }
    }
}