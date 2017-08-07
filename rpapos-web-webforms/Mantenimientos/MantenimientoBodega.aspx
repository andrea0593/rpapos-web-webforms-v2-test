<%@ Page Title="" Language="C#" MasterPageFile="~/Core.Master" AutoEventWireup="true" CodeBehind="MantenimientoBodega.aspx.cs" Inherits="rpapos_web_webforms.Mantenimientos.MantenimientoBodega" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <script type="text/javascript">

        function ShowCreateModal() {
            $('#createModal').modal();
            $('#FormBody_textboxDescripcion').val('');
            $('#FormBody_textboxSimbolo').val('');
            $('#FormBody_defaultTextbox').val('create');
        }

        function ShowUpdateModal(model) {
            $('#updateModal').modal();
            $('#FormBody_textboxActualizarDescripcion').val(descripcion);
            $('#FormBody_textboxActualizarId').val(id);
            $('#FormBody_textboxActualizarSimbolo').val(simbolo);
            $('#FormBody_defaultTextbox').val('update');
        }

        function ShowDeleteModal(model) {
            $('#deleteModal').modal();
            $('#descripcionUnidadEliminar').html(`${descripcion}(${simbolo})`);
            $('#FormBody_textboxEliminarId').val(id);
            $('#FormBody_defaultTextbox').val('delete');
        }

        function dismiss(modal) {
            $(`#${modal}`).modal('hide');
            $('#FormBody_defaultTextbox').val('');
            }

            $(document).ready(function () {
                $('#gridBodega').DataTable({
                    dom: 'Bfrtip',
                    buttons: [
                        'copy', 'csv', 'excel', 'pdf', 'print'
                    ]

                });
            });
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="FormNav" runat="server">
    <div class="col-lg-10">
        <h2>Bodega</h2>
        <ol class="breadcrumb">
            <li>
                <a href="index.html">Home</a>
            </li>
            <li>
                <a>Inventario</a>
            </li>
            <li class="active">
                <strong>Bodega</strong>
            </li>
        </ol>
    </div>
    <div class="col-lg-2">
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="FormBody" runat="server">
     <form runat="server">
        <asp:Button ID="defaultButton" runat="server" CssClass="btn btn-primary hidden"
            Text="Guardar" />
        <asp:TextBox ID="defaultTextbox" runat="server" CssClass="hidden"></asp:TextBox>
        <div class="row">
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                <div class="ibox float-e-margins">
                    <div class="ibox-title">
                        <h5>Bodegas</h5>
                        <div class="pull-right">
                            <a id="showModal" class="btn btn-primary" onclick="ShowCreateModal(); return false;">Crear Bodega</a>
                        </div>
                        <div class="clearfix"></div>
                    </div>
                    <div class="ibox-content">
                        <table id="gridBodega" class="table table-hover">
                            <thead>
                                <tr>
                                    <th>Nombre</th>
                                    <th>Tipo Bodega</th>
                                    <th>Trasegar</th>
                                    <th>Localización</th>
                                    <th>Orden</th>
                                    <th>Producción</th>
                                    <th>Opción de Compra</th>
                                    <th>Entidad</th>
                                    <th>Código</th>
                                    <th>ERP Sync</th>
                                    <th>Descuento Máximo (%)</th>
                                    <th>Dispositivo IO Grupo</th>
                                </tr>
                            </thead>
                            <tbody>
                                <% foreach (var item in data)
                                    {
                                %>
                                <tr>
                                    <td>
                                        <%=item.Nombre %>
                                    </td>
                                    <td>
                                        <%=item.TipoBodegaDescripcion %>
                                    </td>
                                    <td>
                                        <%=item.Trasegar %>
                                    </td>
                                    <td>
                                        <%=item.LocalizacionDescripcion %>
                                    </td>
                                    <td>
                                        <%=item.Orden %>
                                    </td>
                                    <td>
                                        <%=item.Produccion %>
                                    </td>
                                    <td>
                                        <%=item.OpcionCompra %>
                                    </td>
                                    <td>
                                        <%=item.Entidad %>
                                    </td>
                                    <td>
                                        <%=item.Codigo %>
                                    </td>
                                    <td>
                                        <%=item.ERPSync %>
                                    </td>
                                    <td>
                                        <%=item.DescuentoPorcentajeMaximo %>
                                    </td>
                                    <td>
                                        <%=item.DispositivoIOGrupo %>
                                    </td>
                                    <td>
                                        <a onclick="ShowUpdateModal(<%=item %>)" class="btn btn-warning btn-xs">Editar</a>
                                        <a onclick="ShowDeleteModal(<%=item %>);" class="btn btn-xs btn-danger">Eliminar</a>
                                    </td>
                                </tr>
                                <%  } %>
                            </tbody>
                        </table>

                    </div>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
