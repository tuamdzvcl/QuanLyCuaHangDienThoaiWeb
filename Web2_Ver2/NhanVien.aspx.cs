using iTextSharp.text.pdf;
using iTextSharp.text;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web2_Ver2
{
    public partial class NhanVien : System.Web.UI.Page
    {
        DBConnection Conn = new DBConnection();
        String AlertUpdate = "swal('Thay Đổi Thông Tin Thành Công');";
        String AlertCancel = "swal('Bạn Đã Hủy Bỏ Việc Thay Đổi Thông Tin');";
        String AlertDelete = "swal('Xóa Sản Phẩm Thành Công');";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDataToGridView();
            }

        }
        protected void btnSreach_Click(object sender, EventArgs e)
        {
            string sreach = txtSreach.Value;
            if (sreach.Trim() == "")
            {
                LoadDataToGridView();
            }
            else
            {
                LoadDataToGridViewSreach();
            }
        }

        protected void btnXuatFile_Click(object sender, EventArgs e)
        {
            // Tạo một DataTable và nạp dữ liệu từ cơ sở dữ liệu
            DataTable dt = new DataTable();
            Conn.GetConnection();
            String sql = "SELECT manhanvien,tennhanvien,chucvu,email,taikhoan,matkhau,ngaycapnhat FROM tbl_Accounts";
            SqlDataAdapter data = new SqlDataAdapter(sql, Conn.GetConnection());
            data.Fill(dt);

            // Tạo một tệp tin Excel tạm thời
            string tempFileName = Path.GetTempFileName();
            FileInfo newFile = new FileInfo(tempFileName);

            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

            using (ExcelPackage package = new ExcelPackage(newFile))
            {
                // Tạo một sheet trong tệp tin Excel
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Sheet1");

                // Đổ dữ liệu từ DataTable vào sheet
                worksheet.Cells["A1"].LoadFromDataTable(dt, true);

                // Lưu tệp tin Excel tạm thời
                package.Save();
            }

            // Gửi tệp tin Excel cho người dùng để tải về
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment;filename=Danh_Sach_Nhan_Vien.xlsx");
            Response.TransmitFile(tempFileName);
            Response.End();

            // Xóa tệp tin Excel tạm thời sau khi đã gửi đi
            File.Delete(tempFileName);
        }

        protected void btnXuatPdf_Click(object sender, EventArgs e)
        {
            //Tạo datatable chứa dữ liệu
            DataTable dt = new DataTable();
            Conn.GetConnection();
            String sql = "SELECT manhanvien,tennhanvien,chucvu,email,taikhoan,matkhau,ngaycapnhat FROM tbl_Accounts";
            SqlDataAdapter data = new SqlDataAdapter(sql, Conn.GetConnection());
            data.Fill(dt);

            // Tạo một Document và PdfWriter
            Document document = new Document();
            MemoryStream ms = new MemoryStream();
            PdfWriter writer = PdfWriter.GetInstance(document, ms);

            // Mở Document để bắt đầu viết PDF
            document.Open();

            // Thêm nội dung từ DataTable vào PDF
            PdfPTable pdfTable = new PdfPTable(dt.Columns.Count);
            pdfTable.WidthPercentage = 100;

            // Thêm tiêu đề cột từ DataTable
            foreach (DataColumn column in dt.Columns)
            {
                PdfPCell cell = new PdfPCell(new Phrase(column.ColumnName));
                pdfTable.AddCell(cell);
            }

            // Thêm dữ liệu từ DataTable
            foreach (DataRow row in dt.Rows)
            {
                foreach (object item in row.ItemArray)
                {
                    PdfPCell cell = new PdfPCell(new Phrase(item.ToString()));
                    pdfTable.AddCell(cell);
                }
            }
            document.Add(pdfTable);

            // Đóng Document
            document.Close();

            // Xuất PDF ra response
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=Danh_Sach_Nhan_Vien.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.OutputStream.Write(ms.GetBuffer(), 0, ms.GetBuffer().Length);
            Response.End();
        }

        private void LoadDataToGridView()
        {
            Conn.GetConnection();
            DataTable dt = new DataTable();
            String sql = "SELECT * FROM tbl_Accounts ORDER BY date DESC";
            SqlDataAdapter data = new SqlDataAdapter(sql, Conn.GetConnection());
            data.Fill(dt);
            gvData.DataSource = dt;
            gvData.DataBind();
        }

        private void LoadDataToGridViewSreach()
        {
            String sreach = txtSreach.Value;
            DataTable db = new DataTable();

            Conn.GetConnection();
            String sql = "SELECT * FROM tbl_Accounts WHERE tennhanvien LIKE N'%" + sreach + "%' ORDER BY date DESC";
            SqlDataAdapter data = new SqlDataAdapter(sql, Conn.GetConnection());
            data.Fill(db);
            gvData.DataSource = db;
            gvData.DataBind();
        }

        protected void gvData_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            String sreach = txtSreach.Value;

            if (String.Compare(sreach, "") != 0)
            {
                gvData.PageIndex = e.NewPageIndex;
                LoadDataToGridViewSreach();
            }
            else
            {
                gvData.PageIndex = e.NewPageIndex;
                LoadDataToGridView();
            }
        }

        protected void gvData_RowEditing(object sender, GridViewEditEventArgs e)
        {
            String sreach = txtSreach.Value;

            if (String.Compare(sreach, "") != 0)
            {
                gvData.EditIndex = e.NewEditIndex;
                LoadDataToGridViewSreach();
            }
            else
            {
                gvData.EditIndex = e.NewEditIndex;
                LoadDataToGridView();
            }
        }

        protected void gvData_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            String sreach = txtSreach.Value;

            if (String.Compare(sreach, "") != 0)
            {
                gvData.EditIndex = -1;
                ClientScript.RegisterStartupScript(this.GetType(), "PopupScript", AlertCancel, true);
                LoadDataToGridViewSreach();
            }
            else
            {
                gvData.EditIndex = -1;
                ClientScript.RegisterStartupScript(this.GetType(), "PopupScript", AlertCancel, true);
                LoadDataToGridView();
            }
        }

        protected void gvData_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Conn.GetConnection();
            String delete = "DELETE FROM tbl_Accounts WHERE manhanvien=@manhanvien";
            SqlCommand cmd = new SqlCommand(delete, Conn.GetConnection());
            cmd.Parameters.AddWithValue("@masanpham", gvData.DataKeys[e.RowIndex].Value.ToString());
            cmd.ExecuteNonQuery();
            Conn.CloseConnection();

            String sreach = txtSreach.Value;

            if (String.Compare(sreach, "") != 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "PopupScript", AlertDelete, true);
                LoadDataToGridViewSreach();
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "PopupScript", AlertDelete, true);
                LoadDataToGridView();
            }
        }

        protected void gvData_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Conn.GetConnection();
            string update = "UPDATE tbl_Accounts SET tennhanvien=@tennhanvien," +
                            " chucvu=@chucvu, email=@email, taikhoan=@taikhoan," +
                            "matkhau=@matkhau, ngaycapnhat=@ngaycapnhat,date=@date WHERE manhanvien=@manhanvien";

            SqlCommand cmd = new SqlCommand(update, Conn.GetConnection());
            cmd.Parameters.AddWithValue("@tennhanvien", (gvData.Rows[e.RowIndex].FindControl("txtName") as TextBox).Text.Trim());
            cmd.Parameters.AddWithValue("@chucvu", (gvData.Rows[e.RowIndex].FindControl("ListChucVu") as DropDownList).SelectedValue);
            cmd.Parameters.AddWithValue("@email", (gvData.Rows[e.RowIndex].FindControl("txtEmail") as TextBox).Text.Trim());
            cmd.Parameters.AddWithValue("@taikhoan", (gvData.Rows[e.RowIndex].FindControl("txtTaiKhoan") as TextBox).Text.Trim());
            cmd.Parameters.AddWithValue("@matkhau", (gvData.Rows[e.RowIndex].FindControl("txtMatKhau") as TextBox).Text.Trim());
            cmd.Parameters.AddWithValue("@ngaycapnhat", Date.GetCurrentDateTimeString());
            cmd.Parameters.AddWithValue("@date", Date.DateSapXep());
            cmd.Parameters.AddWithValue("@manhanvien", gvData.DataKeys[e.RowIndex].Value.ToString());

            cmd.ExecuteNonQuery();

            Conn.CloseConnection();

            String sreach = txtSreach.Value;

            if (String.Compare(sreach, "") != 0)
            {
                gvData.EditIndex = -1;
                ClientScript.RegisterStartupScript(this.GetType(), "PopupScript", AlertUpdate, true);
                LoadDataToGridViewSreach();
            }
            else
            {
                gvData.EditIndex = -1;
                ClientScript.RegisterStartupScript(this.GetType(), "PopupScript", AlertUpdate, true);
                LoadDataToGridView();
            }
        }
    }
}