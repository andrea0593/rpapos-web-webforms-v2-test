<%@ Page Title="" Language="C#" MasterPageFile="~/Core.Master" AutoEventWireup="true" CodeBehind="BModal.aspx.cs" Inherits="rpapos_web_webforms.BModal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">


      
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

                 

            </div> 
            <form class="m-t" role="form"   runat="server">

               
                
     <asp:Button ID="TransferFileBtn" runat="server"
            CssClass="btn btn-primary" Text="Transfer file"
            OnClientClick="$('#myModal').modal(); return false;" />


                

        <div class="modal fade" id="myModal" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                        <h4 class="modal-title">
                            <asp:Label ID="lblModalTitle" runat="server" Text="Send Confirmation"></asp:Label></h4>
                    </div>
                    <div class="modal-body">
                        <asp:Label ID="lblModalBody" runat="server" Text="Are you sure?"></asp:Label>
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="SendToBillingBtn" runat="server" CssClass="btn btn-primary"
                            Text="Yes" OnClick="ButtonLogin_Click" />
                        &nbsp;&nbsp;&nbsp;
                    <button class="btn btn-primary" data-dismiss="modal" aria-hidden="true">No</button>
                    </div>
                </div>
            </div>
        </div>


            </form>
            <p class="m-t"> <small>RPApos 2.5 &copy; <%: DateTime.Now.Year %></small> </p>
        </div>
    </div>

    <!-- Mainly scripts -->
    <script src="js/jquery-3.1.1.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script src="js/plugins/toastr/toastr.min.js"></script>

</body>

</html>


</asp:Content>
