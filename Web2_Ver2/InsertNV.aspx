<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InsertNV.aspx.cs" Inherits="Web2_Ver2.InsertNV" %>

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
        <div class="title">Thêm Nhân Viên</div>
        <div class="content">
            <form runat="server" id="fromInsert" method="post">
                <div class="user-details">
                    <div class="input-box">
                        <span class="details">Mã Nhân Viên</span>
                        <input runat="server" id="txtId" type="text" placeholder="Nhập mã sản phẩm" required>
                    </div>
                    <div class="input-box">
                        <span class="details">Tên Nhân Viên</span>
                        <input runat="server" id="txtName" type="text" placeholder="Nhập tên sản phẩm" required>
                    </div>
                    <div class="input-box">
                        <span class="details">Chức Vụ</span>
                        <select runat="server" id="ListChucVu">
                            <option value="">---Chọn---</option>
                            <option value="Admin">Admin</option>
                            <option value="NhanVien">Nhân Viên</option>
                        </select>
                    </div>
                    <div class="input-box">
                        <span class="details">Email</span>
                        <input runat="server" id="txtEmail" type="text" placeholder="Nhập email nhân viên" required>
                    </div>
                    <div class="input-box">
                        <span class="details">Tài Khoản</span>
                        <input runat="server" id="txtTaiKhoan" type="text" placeholder="Nhập tài khoản muốn tạo" required>
                    </div>
                    <div class="input-box">
                        <span class="details">Mật Khẩu</span>
                        <input runat="server" id="txtMatKhau" type="text" placeholder="Nhập mật khẩu cho tài khoản" required>
                    </div>
                </div>
                <div style="font-size: 10px;" class="gender-details">
                    <span class="gender-title">Lưu ý: Nếu Mã Nhân Viên Trùng. Hãy đổi Mã khác</span>
                </div>
                <div class="button">
                    <input runat="server" onserverclick="btnInsert_CLick" type="submit" value="Thêm Nhân Viên">
                    <a href="./Home.aspx">
                        <input id="cancel" runat="server" type="button" value="Quay Lại Trang Chủ" style="width: 200px; margin-top: 15px; font-size: 12px"></a>
                </div>
            </form>

        </div>
    </div>
</body>
</html>
