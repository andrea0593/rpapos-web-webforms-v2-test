﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Core.Master" AutoEventWireup="true" CodeBehind="MantenimientoUnidadMedida.aspx.cs" Inherits="rpapos_web_webforms.Mantenimientos.MantenimientoUnidadMedida" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">

        function ShowCreateModal() {
            $('#createModal').modal();
            $('#FormBody_textboxDescripcion').val('');
            $('#FormBody_textboxSimbolo').val('');
            $('#FormBody_defaultTextbox').val('create');
        }

        function ShowUpdateModal(id, descripcion, simbolo) {
            $('#updateModal').modal();
            $('#FormBody_textboxActualizarDescripcion').val(descripcion);
            $('#FormBody_textboxActualizarId').val(id);
            $('#FormBody_textboxActualizarSimbolo').val(simbolo);
            $('#FormBody_defaultTextbox').val('update');
        }

        function ShowDeleteModal(id, descripcion, simbolo) {
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
            $('#gridUnidadMedida').DataTable({
                dom: 'Bfrtip',
                buttons: [
                    'copy', 'csv', 'excel', 'pdf', 'print'
                ]

            });
        });
    </script>
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
        <asp:Button ID="defaultButton" runat="server" CssClass="btn btn-primary hidden"
            Text="Guardar" OnClick="defaultButton_Click" />
        <asp:TextBox ID="defaultTextbox" runat="server" CssClass="hidden"></asp:TextBox>
        <div class="row">
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                <div class="ibox float-e-margins">
                    <div class="ibox-title">
                        <h5>Listado de Unidades de Medida</h5>
                        <div class="pull-right">
                            <a id="showModal" class="btn btn-primary" onclick="ShowCreateModal(); return false;">Crear Unidad de Medida</a>
                        </div>
                        <div class="clearfix"></div>
                    </div>
                    <div class="ibox-content">
                        <div class="table-responsive">
                            <table id="gridUnidadMedida" class="table table-hover">
                                <thead>
                                    <tr>
                                        <th>Descripción</th>
                                        <th>Símbolo</th>
                                        <th>Acciones</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <% foreach (var item in data)
                                        {
                                    %>
                                    <tr>
                                        <td>
                                            <%=item.Descripcion %>
                                        </td>
                                        <td>
                                            <%=item.Simbolo %>
                                        </td>
                                        <td>
                                            <a onclick="ShowUpdateModal(<%=item.Unidad_Medida %>,'<%=item.Descripcion %>','<%=item.Simbolo %>')" class="btn btn-warning btn-xs">Editar</a>
                                            <a onclick="ShowDeleteModal(<%=item.Unidad_Medida %>,'<%=item.Descripcion %>','<%=item.Simbolo %>');" class="btn btn-xs btn-danger">Eliminar</a>
                                        </td>
                                    </tr>
                                    <%  } %>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </div>


        <!-- Create Modal -->
        <div class="modal fade" id="createModal" role="dialog" aria-labelledby="createModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" onclick="dismiss('createModal')" aria-hidden="true">&times;</button>
                        <h4 class="modal-title">
                            <asp:Label ID="lblModalTitle" runat="server" Text="Crear Nueva Unidad de Medida"></asp:Label></h4>
                    </div>
                    <div class="modal-body">
                        <div class="form-group">
                            <label>Descripción:</label>
                            <asp:TextBox ID="textboxDescripcion" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>Símbolo:</label>
                            <asp:TextBox ID="textboxSimbolo" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="buttonCreate" runat="server" CssClass="btn btn-primary"
                            Text="Guardar" OnClick="buttonCreate_Click" />

                        <button class="btn btn-default" onclick="dismiss('createModal')" aria-hidden="true">Cancelar</button>
                    </div>
                </div>
            </div>
        </div>

        <!-- Update Modal -->
        <div class="modal fade" id="updateModal" role="dialog" aria-labelledby="updateModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" onclick="dismiss('updateModal')" aria-hidden="true">&times;</button>
                        <h4 class="modal-title">
                            <asp:Label ID="Label3" runat="server" Text="Modificar Unidad de Medida"></asp:Label></h4>
                    </div>
                    <div class="modal-body">
                        <asp:TextBox runat="server" CssClass="hidden" ID="textboxActualizarId"></asp:TextBox>
                        <div class="form-group">
                            <label>Descripción:</label>
                            <asp:TextBox ID="textboxActualizarDescripcion" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>Símbolo:</label>
                            <asp:TextBox ID="textboxActualizarSimbolo" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="buttonUpdate" runat="server" CssClass="btn btn-primary"
                            Text="Actualizar" OnClick="buttonUpdate_Click" />

                        <button class="btn btn-default" onclick="dismiss('updateModal')" aria-hidden="true">Cancelar</button>
                    </div>
                </div>
            </div>
        </div>


        <!-- Delete Modal -->
        <div class="modal fade" id="deleteModal" role="dialog" aria-labelledby="deleteModal" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" onclick="dismiss('deleteModal')" aria-hidden="true">&times;</button>
                        <h4 class="modal-title">
                            <asp:Label ID="Label1" runat="server" Text="Eliminar"></asp:Label></h4>
                    </div>
                    <div class="modal-body">
                        <asp:TextBox runat="server" CssClass="hidden" ID="textboxEliminarId"></asp:TextBox>
                        <label class="font-normal">¿Desea eliminar la unidad de medida: <span id="descripcionUnidadEliminar" class="font-bold"></span>?</label>
                        <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="buttonDelete" runat="server" CssClass="btn btn-danger"
                            Text="Eliminar" OnClick="buttonDelete_Click" />

                        <button class="btn btn-default" onclick="dismiss('deleteModal')" aria-hidden="true">Cancelar</button>
                    </div>
                </div>
            </div>
        </div>
    </form>

</asp:Content>


