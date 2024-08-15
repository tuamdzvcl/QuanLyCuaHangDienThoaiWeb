<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="SanPham.aspx.cs" Inherits="Web2_Ver2.SanPham" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .gvData {
            text-align: center;
        }
        .textbox{
            width:100px;
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
            <h3 style="font-size: 25px; color: white">Thông tin Sản Phẩm</h3>
            <center>
                <input runat="server" style="display: block; width: 80%; font-size: 16px" id="txtSreach" type="text" placeholder="Nhập tên sản phẩm" />
            </center>
            <input runat="server" onserverclick="btnSreach_Click" style="display: block; width: 10%; float: right; font-size: 17px; margin-right: 15px; margin-top: 5px" id="btnSreach" type="submit" value="Tìm Kiếm" />
            <br />
            <a href="./Insert.aspx">
                <input style="font-size: 17px; margin-left: 15px; margin-top: 17px" id="btnAdd" type="button" value="Thêm Sản Phẩm" />
            </a>
            <input runat="server" onserverclick="btnXuatFile_Click" style="font-size: 17px; margin-left: 10px" id="btnXuatFile" type="button" value="Xuất File Excel" />
            <input runat="server" onserverclick="btnXuatPdf_Click" style="font-size: 17px; margin-left: 10px" id="btnXuatPdf" type="button" value="Xuất File PDF" />
        </div>

        <asp:GridView ID="gvData" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None"
            Height="360px" Width="100%" CssClass="gvData" AllowPaging="True" PageSize="8" OnPageIndexChanging="gvData_PageIndexChanging" OnRowCancelingEdit="gvData_RowCancelingEdit" OnRowEditing="gvData_RowEditing" OnRowDeleting="gvData_RowDeleting" OnRowUpdating="gvData_RowUpdating" DataKeyNames="masanpham">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:TemplateField></asp:TemplateField>
                <asp:TemplateField HeaderText="Mã SP">
                    <EditItemTemplate>
                        <asp:Label ID="Label9" runat="server" Text='<%# Eval("masanpham") %>'></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("masanpham") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Tên SP">
                    <EditItemTemplate>
                        <asp:TextBox CssClass="textbox" ID="txtName" runat="server" Text='<%# Eval("tensanpham") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("tensanpham") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Thuong Hiệu">
                    <EditItemTemplate>
                        <asp:TextBox CssClass="textbox" ID="txtThuongHieu" runat="server" Text='<%# Eval("thuonghieu") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Eval("thuonghieu") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Màu Săc">
                    <EditItemTemplate>
                        <asp:TextBox CssClass="textbox" ID="txtMauSac" runat="server" Text='<%# Eval("mausac") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server" Text='<%# Eval("mausac") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Dung Lượng">
                    <EditItemTemplate>
                        <asp:TextBox CssClass="textbox" ID="txtDungLuong" runat="server" Text='<%# Eval("dungluong") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label5" runat="server" Text='<%# Eval("dungluong") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Số Lượng">
                    <EditItemTemplate>
                        <asp:Label ID="Label66" runat="server" Text='<%# Eval("soluong") %>'></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label6" runat="server" Text='<%# Eval("soluong") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Giá Bán">
                    <EditItemTemplate>
                        <asp:TextBox CssClass="textbox" ID="txtGiaBan" runat="server" Text='<%# Eval("giaban") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label7" runat="server" Text='<%# Eval("giaban") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Ngày Cập Nhật">
                    <EditItemTemplate>
                        <asp:Label ID="Label10" runat="server" Text='<%# Eval("ngaycapnhat") %>'></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label8" runat="server" Text='<%# Eval("ngaycapnhat") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Chức Năng">
                    <EditItemTemplate>
                        <asp:ImageButton ID="ImageButton4" runat="server" CommandName="update" Height="20px" ImageUrl="~/Assets/images/save.png" Width="20px" />
                        <asp:ImageButton ID="ImageButton3" runat="server" CommandName="cancel" Height="20px" ImageUrl="~/Assets/images/cancel.jpg" Width="20px" />
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:ImageButton ID="imgUpdate" runat="server" CommandName="edit" Height="20px" ImageUrl="~/Assets/images/update.jpg" Width="20px" />
                        <asp:ImageButton ID="ImageButton1" runat="server" CommandName="delete" Height="20px" ImageUrl="~/Assets/images/delete.png" Width="20px" />
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
