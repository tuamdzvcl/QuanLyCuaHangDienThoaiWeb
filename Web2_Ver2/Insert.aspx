<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Insert.aspx.cs" Inherits="Web2_Ver2.Insert" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Thêm Sản Phẩm </title>
    <link rel="stylesheet" href="./Assets/css/styleInsert.css">
    <link rel="shortcut icon" href="./Assets/images/vnua.png">
    <script src="https://cdnjs.cloudflare.com/ajax/libs/sweetalert/2.1.2/sweetalert.min.js"></script>
</head>
<body>
    <div class="container">
        <div class="title">Thêm Sản Phẩm</div>
        <div class="content">
            <form runat="server" id="fromInsert" method="post">
                <div class="user-details">
                    <div class="input-box">
                        <span class="details">Mã Sản Phẩm</span>
                        <input runat="server" id="txtId" type="text" placeholder="Nhập mã sản phẩm" required>
                    </div>
                    <div class="input-box">
                        <span class="details">Tên Sản Phẩm</span>
                        <input runat="server" id="txtName" type="text" placeholder="Nhập tên sản phẩm" required>
                    </div>
                    <div class="input-box">
                        <span class="details">Thương Hiệu</span>
                        <input runat="server" id="txtThuongHieu" type="text" placeholder="Nhập thương hiệu sản phẩm" required>
                    </div>
                    <div class="input-box">
                        <span class="details">Màu Sắc</span>
                        <input runat="server" id="txtMauSac" type="text" placeholder="Nhập màu sắc sản phẩm" required>
                    </div>
                    <div class="input-box">
                        <span class="details">Dung Lượng</span>
                        <input runat="server" id="txtDungLuong" type="text" placeholder="Nhập dung lượng bộ nhớ" required>
                    </div>
                    <div class="input-box">
                        <span class="details">Giá Bán</span>
                        <input runat="server" id="txtGiaBan" type="text" placeholder="Nhập giá bán sản phẩm" required>
                    </div>
                </div>
                <div style="font-size: 10px;" class="gender-details">
                    <span class="gender-title">Lưu ý: Nếu Mã Sản Phẩm Trùng. Hãy đổi Mã khác</span>
                </div>
                <div class="button">
                    <input runat="server" onserverclick="btnInsert_CLick" type="submit" value="Thêm Sản Phẩm">
                    <a href="./Home.aspx">
                        <input id="cancel" runat="server" type="button" value="Quay Lại Trang Chủ" style="width: 200px; margin-top: 15px; font-size: 12px"></a>
                </div>
            </form>
            <label runat="server" id="error123"></label>

        </div>
    </div>
</body>
</html>

