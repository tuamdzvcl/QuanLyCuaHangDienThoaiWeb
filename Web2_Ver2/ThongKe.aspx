<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="ThongKe.aspx.cs" Inherits="Web2_Ver2.ThongKe" %>

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
    </style>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/sweetalert/2.1.2/sweetalert.min.js"></script>
    <form id="form1" runat="server">
        <div style="height: 140px">
            <h3 style="font-size: 25px; color: white;display:inline-block">Thống Kê Nhập Xuất</h3>
            <h4 runat="server" id="labelNhapHang" style="font-size:20px;color:white;display:inline-block;float:right;padding-right:8px">hihi</h4>
            <h4 runat="server" id="labelXuatHang" style="font-size:20px;color:white;display:inline-block;float:right;margin-right:8px">hihi</h4>
            <center>
                <input runat="server" style="display: block; width: 80%; font-size: 16px" id="txtSreach" type="text" placeholder="Nhập tên nhân viên/tên khách hàng" />
            </center>
            <input runat="server" onserverclick="btnSreach_Click" style="display: block; width: 10%; float: right; font-size: 17px; margin-right: 15px; margin-top: 5px" id="btnSreach" type="button" value="Tìm Kiếm" />
            <br />
            <a href="./InsertNV.aspx">
                &nbsp;</a><input runat="server" onserverclick="btnXuatFile_Click" style="font-size: 17px; margin-left: 10px" id="btnXuatFile" type="button" value="Xuất File Excel" />
            <input runat="server" onserverclick="btnXuatPdf_Click" style="font-size: 17px; margin-left: 10px" id="btnXuatPdf" type="button" value="Xuất File PDF" />
        </div>

        <asp:GridView ID="gvData" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None"
            Height="360px" Width="100%" CssClass="gvData" AllowPaging="True" PageSize="8" OnPageIndexChanging="gvData_PageIndexChanging" >
            <alternatingrowstyle backcolor="White" />
            <columns>
                <asp:TemplateField HeaderText="Mã Đơn Hàng">
                    <itemtemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("madonhang") %>'></asp:Label>
                    </itemtemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Trạng Thái">
                    <itemtemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("trangthai") %>'></asp:Label>
                    </itemtemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Tên Khách Hàng">
                    <itemtemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Eval("tenkhachhang") %>'></asp:Label>
                    </itemtemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Tên Nhân Viên">
                    <itemtemplate>
                        <asp:Label ID="Label4" runat="server" Text='<%# Eval("tennhanvien") %>'></asp:Label>
                    </itemtemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Sản Phẩm">
                    <itemtemplate>
                        <asp:Label ID="Label5" runat="server" Text='<%# Eval("tensanpham") %>'></asp:Label>
                    </itemtemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Số Lượng">
                    <itemtemplate>
                        <asp:Label ID="Label6" runat="server" Text='<%# Eval("soluong") %>'></asp:Label>
                    </itemtemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Ngày Cập Nhật">
                    <itemtemplate>
                        <asp:Label ID="Label8" runat="server" Text='<%# Eval("ngaycapnhat") %>'></asp:Label>
                    </itemtemplate>
                </asp:TemplateField>
            </columns>
            <editrowstyle backcolor="#7C6F57" />
            <footerstyle backcolor="#1C5E55" font-bold="True" forecolor="White" />
            <headerstyle backcolor="#1C5E55" font-bold="True" forecolor="White" />
            <pagerstyle cssclass="pagesize" />
            <rowstyle backcolor="#E3EAEB" />
            <selectedrowstyle backcolor="#C5BBAF" font-bold="True" forecolor="#333333" />
            <sortedascendingcellstyle backcolor="#F8FAFA" />
            <sortedascendingheaderstyle backcolor="#246B61" />
            <sorteddescendingcellstyle backcolor="#D4DFE1" />
            <sorteddescendingheaderstyle backcolor="#15524A" />
        </asp:GridView>
    </form>
</asp:Content>
