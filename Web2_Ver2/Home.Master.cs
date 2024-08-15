using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web2_Ver2
{
    public partial class Home : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String chucvu = Session["chucvu"].ToString();
            String name = Session["name"].ToString();
            if(chucvu != "Admin")
            {
                divTK.Visible = false;
                QLNV.Visible = false;
                divNCC.Visible = false;
            }
            label2.InnerHtml = name;
            label4.InnerHtml = "Chức Vụ: "+ chucvu;
            label3.InnerHtml = Date.GetDateNow();
        }
    }
}