<%@ Page Title="" Language="C#" MasterPageFile="~/Core.Master" AutoEventWireup="true" CodeBehind="MantenimientoUnidadMedida.aspx.cs" Inherits="rpapos_web_webforms.MantenimientoUnidadMedida" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="NavContent" ContentPlaceHolderID="FormNav" runat="server">
    <div class="col-lg-10">
        <h2>Unidades de Medida</h2>
        <ol class="breadcrumb">
            <li>
                <a href="index.html">Home</a>
            </li>
            <li>
                <a>Inventario</a>
            </li>
            <li class="active">
                <strong>Unidades de Medida</strong>
            </li>
        </ol>
    </div>
    <div class="col-lg-2">
    </div>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="FormBody" runat="server">


    <form runat="server">
        <div class="row">
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                <div class="ibox float-e-margins">
                    <div class="ibox-title">
                        <h5>Listado de Unidades de Medida</h5>
                        <div class="pull-right">
                            <a id="showModal" class="btn btn-primary" onclick="$('#createModal').modal(); return false;">Crear Unidad de Medida</a>
                        </div>
                        <div class="clearfix"></div>
                    </div>
                    <div class="ibox-content">

                        <asp:GridView ID="gridViewUnidadMedida" ClientIDMode="Static" GridLines="None" AutoGenerateColumns="true" runat="server" CssClass="table table-hover  dataTables_filter" UseAccessibleHeader="true" BorderStyle="None" BorderWidth="0">
                            <%--<Columns>
                                <asp:BoundField DataField="Unidad_Medida" HeaderText="CACA" />
                                <asp:BoundField DataField="Descripcion" />
                                <asp:BoundField DataField="Simbolo" />
                                <asp:BoundField DataField="Fecha_Hora" />
                                <asp:BoundField DataField="UserName" />
                                <asp:BoundField DataField="M_Fecha_Hora" />
                                <asp:BoundField DataField="M_UserName" />
                                <asp:BoundField DataField="Orden" />
                                <asp:BoundField DataField="Estado" />
                            </Columns>--%>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>

        <div class="modal fade" id="createModal" role="dialog" aria-labelledby="createModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                        <h4 class="modal-title">
                            <asp:Label ID="lblModalTitle" runat="server" Text="Crear Nueva Unidad de Medida"></asp:Label></h4>
                    </div>
                    <div class="modal-body">
                        <div class="form-group">
                            <label>Descripci&oacute;n:</label>
                            <asp:TextBox ID="textboxDescripcion" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>S&iacute;mbolo:</label>
                            <asp:TextBox ID="textboxSimbolo" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="buttonCreate" runat="server" CssClass="btn btn-primary"
                            Text="Yes" OnClick="buttonCreate_Click" />
                        &nbsp;&nbsp;&nbsp;
                    <button class="btn btn-danger" data-dismiss="modal" aria-hidden="true">No</button>
                    </div>
                </div>
            </div>
        </div>


        <div class="modal fade" id="deleteModal" role="dialog" aria-labelledby="deleteModal" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                        <h4 class="modal-title">
                            <asp:Label ID="Label1" runat="server" Text="Send Confirmation"></asp:Label></h4>
                    </div>
                    <div class="modal-body">
                        <asp:Label ID="Label2" runat="server" Text="Are you sure?"></asp:Label>
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="Button2" runat="server" CssClass="btn btn-primary"
                            Text="Yes" />
                        &nbsp;&nbsp;&nbsp;
                    <button class="btn btn-primary" data-dismiss="modal" aria-hidden="true">No</button>
                    </div>
                </div>
            </div>
        </div>

    </form>

     
    <script type="text/javascript">
        $(document).ready(function () {
            $('#gridViewUnidadMedida').DataTable({
                dom: 'Bfrtip',
                buttons: [
                    'copy', 'csv', 'excel', 'pdf', 'print'
                ]

            });
        });
    </script>

</asp:Content>


