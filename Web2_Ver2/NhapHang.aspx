<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="NhapHang.aspx.cs" Inherits="Web2_Ver2.NhapHang" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .gvData {
            text-align: center;
        }

        .textbox {
            width: 100px;
        }

        .pagesize {
            color: white;
            font-size: 15px;
            text-align: left;
            background-color: green;
        }

        .auto-style9 {
            width: 100%;
            height: 139px;
        }

        .auto-style10 {
            width: 638px;
        }
    </style>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/sweetalert/2.1.2/sweetalert.min.js"></script>
    <form id="form1" runat="server">
        <div style="height: 140px; width: 100%">

            <table class="auto-style9">
                <tr>
                    <td>Mã Đơn Hàng:</td>
                    <td>Tên Nhân Viên:</td>
                    <td>Nhà Cung Cấp</td>
                    <td>Loại Sản Phẩm:</td>
                    <td>Số Lượng:</td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtMaDon" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:DropDownList ID="ListDanhSachTenNhanVien" runat="server" Width="157px" DataSourceID="DataNV" DataTextField="tennhanvien" DataValueField="tennhanvien">
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="DataNV" runat="server" ConnectionString="<%$ ConnectionStrings:StrConn %>" SelectCommand="SELECT [tennhanvien] FROM [tbl_Accounts]"></asp:SqlDataSource>
                    </td>
                    <td>
                        <asp:DropDownList ID="ListDanhSachNhaCungCap" runat="server" Width="157px" DataSourceID="DataNCC" DataTextField="tennhacungcap" DataValueField="tennhacungcap">
                            <asp:ListItem>---Chọn---</asp:ListItem>
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="DataNCC" runat="server" ConnectionString="<%$ ConnectionStrings:StrConn %>" SelectCommand="SELECT [tennhacungcap] FROM [tbl_NCC]"></asp:SqlDataSource>
                    </td>
                    <td>
                        <asp:DropDownList ID="ListDanhSachLoaiSP" runat="server" Width="157px" DataSourceID="DataSP" DataTextField="tensanpham" DataValueField="tensanpham">
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="DataSP" runat="server" ConnectionString="<%$ ConnectionStrings:StrConn %>" SelectCommand="SELECT [tensanpham] FROM [tbl_Products]"></asp:SqlDataSource>
                    </td>
                    <td>
                        <asp:TextBox ID="txtSoLuong" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td colspan="2">
                        <asp:Button ID="btnADD" runat="server" Text="Nhập Hàng" OnClick="btnADD_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <input runat="server" id="txtSreach" class="auto-style10" type="text" placeholder="Nhập Tên Khách Hàng" /></td>
                    <td>
                        <asp:Button ID="btnTimKiem" runat="server" Text="Tìm Kiếm" OnClick="btnTimKiem_Click1" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnXuatFileExcel" runat="server" Text="Xuất File Excel" OnClick="btnXuatFileExcel_Click" />
                    </td>
                    <td>
                        <asp:Button ID="btnXuatFilePdf" runat="server" Text="Xuất File PDF" OnClick="btnXuatFilePdf_Click" />
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>

        </div>

        <asp:GridView ID="gvData" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None"
            Height="360px" Width="100%" CssClass="gvData" AllowPaging="True" PageSize="8" OnPageIndexChanging="gvData_PageIndexChanging" DataKeyNames="madonhang">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:TemplateField HeaderText="Mã Đơn Hàng">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("madonhang") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Tên Nhân Viên">
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("tennhanvien") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Nhà Cung Cấp">
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Eval("tennhacungcap") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Loại Sản Phẩm">
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server" Text='<%# Eval("loaisanpham") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Số Lượng">
                    <ItemTemplate>
                        <asp:Label ID="Label9" runat="server" Text='<%# Eval("soluongsanpham") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Ngày Cập Nhật">
                    <ItemTemplate>
                        <asp:Label ID="Label8" runat="server" Text='<%# Eval("ngaycapnhat") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EditRowStyle BackColor="#7C6F57" />
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <PagerStyle CssClass="pagesize" />
            <RowStyle BackColor="#E3EAEB" />
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F8FAFA" />
            <SortedAscendingHeaderStyle BackColor="#246B61" />
            <SortedDescendingCellStyle BackColor="#D4DFE1" />
            <SortedDescendingHeaderStyle BackColor="#15524A" />
        </asp:GridView>
    </form>
</asp:Content>
