using iTextSharp.text;
using iTextSharp.text.pdf;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.DynamicData;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace Web2_Ver2
{
	public partial class SanPham : System.Web.UI.Page
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
                CheckSLSP();
            }
            
        }
        protected void btnSreach_Click(object sender, EventArgs e)
        {
            string sreach = txtSreach.Value;
            if (sreach.Trim() == "")
            {
                LoadDataToGridViewSreach();
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
            String sql = "SELECT masanpham,tensanpham,thuonghieu,mausac,dungluong,soluong,giaban,ngaycapnhat FROM tbl_Products";
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
            Response.AddHeader("content-disposition", "attachment;filename=Danh_Sach_San_Pham.xlsx");
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
            String sql = "SELECT masanpham,tensanpham,thuonghieu,mausac,dungluong,soluong,giaban,ngaycapnhat FROM tbl_Products";
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
            Response.AddHeader("content-disposition", "attachment;filename=Danh_Sach_San_Pham.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.OutputStream.Write(ms.GetBuffer(), 0, ms.GetBuffer().Length);
            Response.End();
        }

        private void LoadDataToGridView()
        {
            Conn.GetConnection();
            DataTable dt = new DataTable();
            String sql = "SELECT * FROM tbl_Products ORDER BY date DESC";
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
            String sql = "SELECT * FROM tbl_Products WHERE tensanpham LIKE N'%" + sreach + "%' ORDER BY date DESC";
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
            String delete = "DELETE FROM tbl_Products WHERE masanpham=@masanpham";
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
            string update = "UPDATE tbl_Products SET tensanpham=@tensanpham," +
                            " thuonghieu=@thuonghieu, mausac=@mausac, dungluong=@dungluong," +
                            "giaban=@giaban, ngaycapnhat=@ngaycapnhat, date=@date WHERE masanpham=@masanpham";

            SqlCommand cmd = new SqlCommand(update, Conn.GetConnection());
            cmd.Parameters.AddWithValue("@tensanpham", (gvData.Rows[e.RowIndex].FindControl("txtName") as TextBox).Text.Trim());
            cmd.Parameters.AddWithValue("@thuonghieu", (gvData.Rows[e.RowIndex].FindControl("txtThuongHieu") as TextBox).Text.Trim());
            cmd.Parameters.AddWithValue("@mausac", (gvData.Rows[e.RowIndex].FindControl("txtMauSac") as TextBox).Text.Trim());
            cmd.Parameters.AddWithValue("@dungluong", (gvData.Rows[e.RowIndex].FindControl("txtDungLuong") as TextBox).Text.Trim());
            cmd.Parameters.AddWithValue("@giaban", (gvData.Rows[e.RowIndex].FindControl("txtGiaBan") as TextBox).Text.Trim());
            cmd.Parameters.AddWithValue("@ngaycapnhat", Date.GetCurrentDateTimeString());
            cmd.Parameters.AddWithValue("@date",Date.DateSapXep());
            cmd.Parameters.AddWithValue("@masanpham", gvData.DataKeys[e.RowIndex].Value.ToString());

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

        private void CheckSLSP()
        {
            Conn.GetConnection();
            String sql = "SELECT tensanpham FROM tbl_Products WHERE CAST(soluong AS INT) < 5";
            SqlCommand cmd = new SqlCommand(sql,Conn.GetConnection());
            SqlDataReader reader = cmd.ExecuteReader();
            List<string> lowQuantityProducts = new List<string>();
            while (reader.Read())
            {
                String name = reader["tensanpham"].ToString();
                lowQuantityProducts.Add(name);
            }
            reader.Close();
            if (lowQuantityProducts.Count > 0)
            {
                string alertMessage = "swal('Số Lượng Sản Phẩm Còn Ít.Hãy Bổ Sung: ";
                alertMessage += string.Join(", ", lowQuantityProducts) + "');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "PopupScript", alertMessage, true);
            }
        }
    }
}