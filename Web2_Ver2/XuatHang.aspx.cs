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
using System.Runtime.Remoting.Messaging;
using iTextSharp.xmp;
using OfficeOpenXml.Drawing.Slicer;

namespace Web2_Ver2
{
    public partial class XuatHang : System.Web.UI.Page
    {
        DBConnection Conn = new DBConnection();
        String iD, Name, SP, SDT, DC, SLSP, Day;
        String AlertSuccces = "swal('Tạo Đơn Hàng Thành Công. Đã Cập Nhật Lại Số Lượng Sản Phẩm Trong Kho');";
        String AlertError = "swal('Lỗi! Không Tạo Được Đơn Hàng');";
        String AlertCheck = "swal('Lỗi! Không Đủ Sản Phẩm Để Xuất Hàng');";
        String AlertErrorTrungMa = "swal('Mã Đơn Hàng Bị Trùng');";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDataToGridView();
            }

        }

        private void LoadDataToGridView()
        {
            Conn.GetConnection();
            DataTable dt = new DataTable();
            String sql = "SELECT * FROM tbl_DonXuat ORDER BY date DESC";
            SqlDataAdapter data = new SqlDataAdapter(sql, Conn.GetConnection());
            data.Fill(dt);
            gvData.DataSource = dt;
            gvData.DataBind();
        }

        protected void btnXuatFileExcel_Click(object sender, EventArgs e)
        {
            // Tạo một DataTable và nạp dữ liệu từ cơ sở dữ liệu
            DataTable dt = new DataTable();
            Conn.GetConnection();
            String sql = "SELECT madonhang,tenkhachhang,sodienthoai,diachi,ngaycapnhat," +
                         "loaisanpham,soluongsanpham FROM tbl_DonXuat";
            SqlDataAdapter data = new SqlDataAdapter(sql, Conn.GetConnection());
            data.Fill(dt);

            // Tạo một tệp tin Excel tạm thời
            string tempFileName = Path.GetTempFileName();
            FileInfo newFile = new FileInfo(tempFileName);

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;



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
            Response.AddHeader("content-disposition", "attachment;filename=Danh_Sach_Don_Xuat_Hang.xlsx");
            Response.TransmitFile(tempFileName);
            Response.End();

            // Xóa tệp tin Excel tạm thời sau khi đã gửi đi
            File.Delete(tempFileName);
        }

        protected void btnTimKiem_Click1(object sender, EventArgs e)
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

        protected void btnXuatFilePdf_Click(object sender, EventArgs e)
        {
            //Tạo datatable chứa dữ liệu
            DataTable dt = new DataTable();
            Conn.GetConnection();
            String sql = "SELECT madonhang,tenkhachhang,sodienthoai,diachi,ngaycapnhat," +
                         "loaisanpham,soluongsanpham FROM tbl_DonXuat";
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
            Response.AddHeader("content-disposition", "attachment;filename=Danh_Sach_Don_Xuat_Hang.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.OutputStream.Write(ms.GetBuffer(), 0, ms.GetBuffer().Length);
            Response.End(); ;
        }

        private void LoadDataToGridViewSreach()
        {
            String sreach = txtSreach.Value;
            DataTable db = new DataTable();

            Conn.GetConnection();
            String sql = "SELECT * FROM tbl_DonXuat WHERE tenkhachhang LIKE N'%" + sreach + "%' ORDER BY date DESC";
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

        protected void btnADD_Click(object sender, EventArgs e)
        {
            CheckSLSPCoDuXuatHangHayKh();
            LoadDataToGridView();
        }

        public void insertDH()
        {
            iD = txtMaDon.Text;
            Name = txtName.Text;
            SP = ListDanhSach.SelectedValue;
            SDT = txtSoDienThoai.Text;
            DC = txtDiaChi.Text;
            Day = Date.GetCurrentDateTimeString();
            SLSP = txtSoLuong.Text;
            try
            {
                Conn.GetConnection();
                String insert = "INSERT INTO  tbl_DonXuat (madonhang, tenkhachhang, loaisanpham," +
                                "sodienthoai, diachi,soluongsanpham, ngaycapnhat,date)" +
                                "VALUES (@iD, @Name, @SP, @SDT, @DC,@SLSP, @Day,@date)";

                SqlCommand cmd = new SqlCommand(insert, Conn.GetConnection());
                cmd.Parameters.AddWithValue("@iD", iD);
                cmd.Parameters.AddWithValue("@Name", Name);
                cmd.Parameters.AddWithValue("@SP", SP);
                cmd.Parameters.AddWithValue("@SDT", SDT);
                cmd.Parameters.AddWithValue("@DC", DC);
                cmd.Parameters.AddWithValue("@SLSP", SLSP);
                cmd.Parameters.AddWithValue("@Day", Day);
                cmd.Parameters.AddWithValue("@date", Date.DateSapXep());

                int check = cmd.ExecuteNonQuery();

                if (check > 0)
                {
                    insertThongKe();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "PopupScript", AlertError, true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "PopupScript", AlertErrorTrungMa, true);
            }
        }

        public void updateSLSP()
        {
            int SLM;
            int.TryParse(txtSoLuong.Text, out SLM);
            Conn.GetConnection();
            string sql = "SELECT soluong FROM tbl_Products WHERE tensanpham = @tensanpham";
            SqlCommand cmd = new SqlCommand(sql, Conn.GetConnection());
            cmd.Parameters.AddWithValue("@tensanpham", ListDanhSach.SelectedValue);

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                // Lấy giá trị soluong từ CSDL
                string soluong = reader["soluong"].ToString();

                // Chuyển đổi sang kiểu int
                int SLC;
                if (int.TryParse(soluong, out SLC))
                {

                }
                reader.Close();
                int SLN = SLC - SLM;
                String updateSLSP = "UPDATE tbl_Products SET soluong=@SLN,ngaycapnhat=@day,date=@date WHERE tensanpham=@tensanpham";
                SqlCommand updateCmm = new SqlCommand(updateSLSP, Conn.GetConnection());
                updateCmm.Parameters.AddWithValue("@SLN", SLN.ToString());
                updateCmm.Parameters.AddWithValue("@tensanpham", ListDanhSach.SelectedValue.ToString());
                updateCmm.Parameters.AddWithValue("@day", Date.GetCurrentDateTimeString());
                updateCmm.Parameters.AddWithValue("@date", Date.DateSapXep());

                int check = updateCmm.ExecuteNonQuery();

                if (check > 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "PopupScript", AlertSuccces, true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "PopupScript", AlertError, true);
                }
            }
        }

        public void insertThongKe()
        {
            Conn.GetConnection();
            String insertThongKe = "INSERT INTO tbl_ThongKe (madonhang,trangthai,tenkhachhang,tensanpham,soluong,ngaycapnhat,date)" +
                                           "VALUES (@madonhang,@trangthai,@tenkhachhang,@tensanpham,@soluong,@Day,@date)";
            SqlCommand insertThongKeCmm = new SqlCommand(insertThongKe, Conn.GetConnection());
            insertThongKeCmm.Parameters.AddWithValue("@madonhang", iD);
            insertThongKeCmm.Parameters.AddWithValue("@trangthai", "Xuất Hàng");
            insertThongKeCmm.Parameters.AddWithValue("@tenkhachhang", Name);
            insertThongKeCmm.Parameters.AddWithValue("@tensanpham", SP);
            insertThongKeCmm.Parameters.AddWithValue("@soluong", SLSP);
            insertThongKeCmm.Parameters.AddWithValue("@Day", Day);
            insertThongKeCmm.Parameters.AddWithValue("@date", Date.DateSapXep());
            int check = insertThongKeCmm.ExecuteNonQuery();
            if (check > 0)
            {
                updateSLSP();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "PopupScript", AlertError, true);
            }
        }
        public void CheckSLSPCoDuXuatHangHayKh()
        {
            int SLM;
            int.TryParse(txtSoLuong.Text, out SLM);
            Conn.GetConnection();
            string sql = "SELECT soluong FROM tbl_Products WHERE tensanpham = @tensanpham";
            SqlCommand cmd = new SqlCommand(sql, Conn.GetConnection());
            cmd.Parameters.AddWithValue("@tensanpham", ListDanhSach.SelectedValue);

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                string soluong = reader["soluong"].ToString();
                int SLC;
                if (int.TryParse(soluong, out SLC))
                {

                }
                reader.Close();
                int SLN = SLC - SLM;
                if (SLN < 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "PopupScript", AlertCheck, true);
                }
                else
                {
                    insertDH();
                }
            }
        }
    }
}