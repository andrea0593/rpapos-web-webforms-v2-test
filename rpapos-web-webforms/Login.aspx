<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="rpapos_web_webforms.Login" %>

<%--<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
    </form>
</body>
</html>--%>


<!DOCTYPE html>
<html>

<head>

    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">

    <title>INSPINIA | Login</title>

    <link href="css/bootstrap.min.css" rel="stylesheet">
    <link href="font-awesome/css/font-awesome.css" rel="stylesheet">

    <link href="css/animate.css" rel="stylesheet">
    <link href="css/style.css" rel="stylesheet">

</head>

<body class="gray-bg">

    <div class="middle-box text-center loginscreen animated fadeInDown">
        <div>
            <div>

                

<%--                <h1 class="logo-name">IN+</h1>--%>

            </div>
           <%-- <h3>Welcome to IN+</h3>
            <p>Perfectly designed and precisely prepared admin theme with over 50 pages with extra new web app views.
                <!--Continually expanded and constantly improved Inspinia Admin Them (IN+)-->
            </p>--%>
<%--            <p>Login in. To see it in action.</p>--%>
            <form class="m-t" role="form"   runat="server">

                <div class="form-group">
                     <%--type="email"--%>
                    <asp:TextBox ID="TextBoxUsername" runat="server" CssClass="form-control" placeholder="Username" required=""  >

                    </asp:TextBox>
<%--                    <input type="email" class="form-control" placeholder="Username" required="">--%>
                </div>
                <div class="form-group">
<%--                    <input type="password" class="form-control" placeholder="Password" required="">--%>
                         <asp:TextBox ID="TextBoxPassword" runat="server" type="password" CssClass="form-control" placeholder="Password" required=""  >

                    </asp:TextBox>

                </div>
<%--                <button type="submit" class="btn btn-primary block full-width m-b">Login</button>--%>
                <asp:Button ID="ButtonLogin" runat="server" Text="Login" CssClass="btn btn-primary block full-width m-b" OnClick="ButtonLogin_Click" />
                
                        <asp:Image ID="imgEmpresa" runat="server"  />
     <%--           <a href="#"><small>Forgot password?</small></a>
                <p class="text-muted text-center"><small>Do not have an account?</small></p>
                <a class="btn btn-sm btn-white btn-block" href="register.html">Create an account</a>--%>
            </form>
            <p class="m-t"> <small>RPApos 2.5 &copy; 2017</small> </p>
        </div>
    </div>

    <!-- Mainly scripts -->
    <script src="js/jquery-3.1.1.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script src="js/plugins/toastr/toastr.min.js"></script>

</body>

</html>

