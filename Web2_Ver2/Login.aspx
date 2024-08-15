<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Web2_Ver2.Login" %>

<!DOCTYPE html>

<html lang="vi">

<head>
    <title>Quản Lý Điện Thoại</title>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" type="text/css" href="./Assets/vendor/bootstrap/css/bootstrap.min.css">
    <link rel="stylesheet" type="text/css" href="./Assets/fonts/font-awesome-4.7.0/css/font-awesome.min.css">
    <link rel="stylesheet" type="text/css" href="./Assets/vendor/animate/animate.css">
    <link rel="stylesheet" type="text/css" href="./Assets/vendor/css-hamburgers/hamburgers.min.css">
    <link rel="stylesheet" type="text/css" href="./Assets/vendor/select2/select2.min.css">
    <link rel="stylesheet" type="text/css" href="./Assets/css/util.css">
    <link rel="stylesheet" type="text/css" href="./Assets/css/main.css">
    <link rel="shortcut icon" href="./Assets/images/vnua.png">
    <link href="https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css" rel="stylesheet">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-sweetalert/1.0.1/sweetalert.min.css">
    <script src="https://cdnjs.cloudflare.com/ajax/libs/sweetalert/2.1.2/sweetalert.min.js"></script>
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.8.2/css/all.css">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/jquery-confirm/3.3.2/jquery-confirm.min.css">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/boxicons@latest/css/boxicons.min.css">
    <link rel="stylesheet" href="https://unpkg.com/boxicons@latest/css/boxicons.min.css">
</head>

<body>
    <div class="limiter">
        <div class="container-login100">
            <div class="wrap-login100">
                <div class="login100-pic js-tilt">
                    <img src="./Assets/images/team.jpg" alt="IMG">
                </div>
                <!--=====TIÊU ĐỀ======-->
                <form runat="server" method="post" class="login100-form validate-form">
                    <span class="login100-form-title">
                        <b>ĐĂNG NHẬP HỆ THỐNG</b>
                    </span>
                    <!--=====FORM INPUT TÀI KHOẢN VÀ PASSWORD======-->
                    <form>
                        <div class="wrap-input100 validate-input">
                            <input runat="server" class="input100" type="text" placeholder="Tài khoản quản trị"
                                id="txtUsername">
                            <span class="focus-input100"></span>
                            <span class="symbol-input100">
                                <i class='bx bx-user'></i>
                            </span>
                        </div>
                        <div class="wrap-input100 validate-input">
                            <input runat="server" autocomplete="off" class="input100" type="password" placeholder="Mật khẩu"
                                id="txtPassword">
                            <span class="symbol-input100">
                                <i class='bx bx-key'></i>
                            </span>
                        </div>

                        <!--=====ĐĂNG NHẬP======-->
                        <div class="container-login100-form-btn">
                            <input runat="server" onserverclick="btnLogin_Click" type="submit" value="Đăng nhập" id="btnLogin" />
                        </div>
                        <!--=====LINK TÌM MẬT KHẨU======-->
                        <div class="text-right p-t-12">
                            <a class="txt2" href="./ResetPassword.aspx">Bạn quên mật khẩu?
                            </a>
                        </div>
                    </form>
                    <!--=====FOOTER======-->
                    <div class="text-center p-t-70 txt2">
                        Quản Lý Điện Thoại <i class="far fa-copyright" aria-hidden="true"></i>
                        <script type="text/javascript">document.write(new Date().getFullYear());</script>
                        <a
                            class="txt2" href="">By Vnua </a>
                    </div>
                </form>
            </div>
        </div>
    </div>
    <!--Javascript-->
    <script src="./Assets/js/main.js"></script>
    <script src="https:://unpkg.com/boxicons@latest/dist/boxicons.js"></script>
    <script src="./Assets/vendor/jquery/jquery-3.2.1.min.js"></script>
    <script src="./Assets/vendor/bootstrap/js/popper.js"></script>
    <script src="./Assets/vendor/bootstrap/js/bootstrap.min.js"></script>
    <script src="./Assets/vendor/select2/select2.min.js"></script>
    <!--<script type="text/javascript">
        //show - hide mật khẩu
        function myFunction() {
            var x = document.getElementById("txtPassword");
            if (x.type == "password") {
                x.type = "text"
            } else {
                x.type = "password";
            }
        }
        $(".click-eye").click(function () {
            $(this).toggleClass("bx-show bx-hide");
            var input = $($(this).attr("toggle"));
            if (input.attr("type") == "password") {
                input.attr("type", "text");
            } else {
                input.attr("type", "password");
            }
        });
    </script>-->
</body>

</html>
