<%@ Page Title="" Language="C#" MasterPageFile="~/Core.Master" AutoEventWireup="true" CodeBehind="MantenimientoBodega.aspx.cs" Inherits="rpapos_web_webforms.Mantenimientos.MantenimientoBodega" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">

        function ShowCreateModal() {
            $('#createModal').modal();
            $("#dropdownTipoBodega").prop("selectedIndex", -1);
            $("#dropdownLocalizacion").prop("selectedIndex", -1);
            $("#dropdownGrupoDispositivos").prop("selectedIndex", -1);
            $('#FormBody_textboxDescripcion').val('');
            $('#FormBody_textboxSimbolo').val('');
            $('#FormBody_defaultTextbox').val('create');
        }
       
        function ShowUpdateModal(id, nombre, tipobodega, localizacion, codigo, descuentopormaximo, dispositivoiogrupo, orden, trasegar, produccion, opcioncompra, erpsync) {
            $('#updateModal').modal();
            $('#FormBody_textboxActualizarId').val(id);
            $('#FormBody_textboxActualizarNombre').val(nombre);
            $('#FormBody_textboxActualizarTipoBodega').val(tipobodega);
            $("#dropdownActualizarTipoBodega").prop("selectedValue", tipobodega);
            $('#FormBody_textboxActualizarLocalizacion').val(localizacion);
            $("#dropdownActualizarLocalizacion").prop("selectedValue", localizacion);
            $('#FormBody_textboxActualizarCodigo').val(codigo);
            $('#FormBody_textboxActualizarDescuentoMaximo').val(descuentopormaximo);
            $('#FormBody_textboxActualizarGrupoDispositivos').val(dispositivoiogrupo);
            $("#dropdownActualizarGrupoDispositivos").prop("selectedValue", dispositivoiogrupo);
            $('#FormBody_textboxActualizarOrden').val(orden);
            $('#FormBody_checkboxActualizarTrasegar').prop('checked', trasegar == 1);
            $('#FormBody_checkboxActualizarProduccion').prop('checked', produccion == 1);
            $('#FormBody_checkboxActualizarOpcionCompra').prop('checked', opcioncompra == 1);
            $('#FormBody_checkboxActualizarErpSync').prop('checked', erpsync == 1);
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

        function setTipoBodega() {
            $('#FormBody_textboxTipoBodega').val($("#dropdownTipoBodega").val());
        }

        function setLocalizacion() {
            $('#FormBody_textboxLocalizacion').val($("#dropdownLocalizacion").val());
        }

        function setGrupoDispositivos() {
            $('#FormBody_textboxGrupoDispositivos').val($("#dropdownGrupoDispositivos").val());
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
                        <div class="table-responsive">
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
                                        <th>Código</th>
                                        <th>ERP Sync</th>
                                        <th>Descuento Máximo (%)</th>
                                        <th>Dispositivo IO Grupo</th>
                                        <th>Acciones</th>
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
                                        <td class="text-center">
                                            <%=item.Trasegar ? "Sí" : "No" %>
                                        </td>
                                        <td>
                                            <%=item.LocalizacionDescripcion %>
                                        </td>
                                        <td class="text-center">
                                            <%=item.Orden %>
                                        </td>
                                        <td class="text-center">
                                            <%=item.Produccion ? "Sí" : "No" %>
                                        </td>
                                        <td class="text-center">
                                            <%=item.OpcionCompra ? "Sí" : "No" %>
                                        </td>
                                        <td>
                                            <%=item.Codigo %>
                                        </td>
                                        <td class="text-center">
                                            <%=item.ERPSync ? "Sí" : "No" %>
                                        </td>
                                        <td class="text-center">
                                            <%= string.Format("{0:n}", item.DescuentoPorcentajeMaximo * 100.00f) %>
                                        </td>
                                        <td>
                                            <%=item.DispositivoIOGrupoNombre %>
                                        </td>
                                        <td>
                                            <a onclick="ShowUpdateModal(
                                                <%=item.Id %>,
                                                '<%=item.Nombre %>',
                                                <%=item.TipoBodega %>,
                                                <%=item.Localizacion %>,
                                                '<%=item.Codigo %>',
                                                <%=item.DescuentoPorcentajeMaximo %>,
                                                <%=item.DispositivoIOGrupo %>,
                                                <%=item.Orden %>,
                                                <%=item.Trasegar ? 1 : 0 %>,
                                                <%=item.Produccion ? 1 : 0 %>,
                                                <%=item.OpcionCompra ? 1 : 0 %>,
                                                <%=item.ERPSync ? 1 : 0 %>)" class="btn btn-warning btn-xs">Editar</a>
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
        </div>

        <!-- Create Modal -->
        <div class="modal fade" id="createModal" role="dialog" aria-labelledby="createModalLabel" aria-hidden="true" data-backdrop="static">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" onclick="dismiss('createModal')" aria-hidden="true">&times;</button>
                        <h4 class="modal-title">
                            <asp:Label ID="lblModalTitle" runat="server" Text="Crear Nueva Bodega"></asp:Label></h4>
                    </div>
                    <div class="modal-body">
                        <div class="form-group">
                            <label>Nombre:</label>
                            <asp:TextBox ID="textboxNombre" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>Tipo de Bodega:</label>
                            <asp:TextBox runat="server" CssClass="hidden" ID="textboxTipoBodega" Text=""></asp:TextBox>
                            <select id="dropdownTipoBodega" class="form-control" onchange="setTipoBodega();" title="Elija un tipo de bodega...">
                                <%
                                    foreach (var item in dataTipoBodega)
                                    {
                                %>
                                <option class="form-control" value="<%=item.Id %>"><%=item.Descripcion %></option>
                                <% }
                                %>
                            </select>
                        </div>
                        <div class="form-group">
                            <label>Localización:</label>
                            <asp:TextBox ID="textboxLocalizacion" CssClass="hidden" runat="server"></asp:TextBox>
                            <select id="dropdownLocalizacion" class="form-control" onchange="setLocalizacion();" title="Elija una localización...">
                                <%
                                    foreach (var item in dataLocalizacion)
                                    {
                                %>
                                <option class="form-control" value="<%=item.Id %>"><%=item.Descripcion %></option>
                                <% }
                                %>
                            </select>
                        </div>
                        <div class="form-group">
                            <label>Código:</label>
                            <asp:TextBox ID="textboxCodigo" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>Descuento Máximo:</label>
                            <div class="input-group">
                                <asp:TextBox ID="textboxDescuentoMaximo" TextMode="Number" CssClass="form-control" runat="server"></asp:TextBox>
                                <span class="input-group-addon" id="basic-addon2">%</span>
                            </div>
                        </div>
                        <div class="form-group">
                            <label>Grupo de Dispositivos:</label>
                            <asp:TextBox ID="textboxGrupoDispositivos" CssClass="hidden" runat="server"></asp:TextBox>
                            <select id="dropdownGrupoDispositivos" class="form-control" onchange="setGrupoDispositivos();" title="Elija un grupo de dispositivos...">
                                <%
                                    foreach (var item in dataDispositivoIOGrupo)
                                    {
                                %>
                                <option class="form-control" value="<%=item.Id %>"><%=item.Descripcion %></option>
                                <% }
                                %>
                            </select>
                        </div>
                        <div class="form-group">
                            <label>Orden:</label>
                            <asp:TextBox ID="textboxOrden" TextMode="Number" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>

                        <div class="form-check form-check-inline">
                            <asp:CheckBox runat="server" ID="checkboxTrasegar" Checked="false" CssClass="form-check-input form-control" Text="Trasegar:&nbsp;" TextAlign="Left" />
                        </div>
                        <div class="form-check form-check-inline">
                            <asp:CheckBox runat="server" ID="checkboxProduccion" Checked="false" CssClass="form-check-input form-control" Text="Producción:&nbsp;" TextAlign="Left" />
                        </div>
                        <div class="form-check form-check-inline">
                            <asp:CheckBox runat="server" ID="checkboxOpcionCompra" Checked="false" CssClass="form-check-input form-control" Text="Opción de Compra:&nbsp;" TextAlign="Left" />
                        </div>
                        <div class="form-check form-check-inline">
                            <asp:CheckBox runat="server" ID="checkboxErpSync" Checked="false" CssClass="form-check-input form-control" Text="ERP Sync:&nbsp;" TextAlign="Left" />
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
        <div class="modal fade" id="updateModal" role="dialog" aria-labelledby="updateModalLabel" aria-hidden="true" data-backdrop="static">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" onclick="dismiss('updateModal')" aria-hidden="true">&times;</button>
                        <h4 class="modal-title">
                            <asp:Label ID="lblModalTitleUpdate" runat="server" Text="Modificar Bodega"></asp:Label></h4>
                    </div>
                    <div class="modal-body">
                        <asp:TextBox runat="server" CssClass="hidden" ID="textboxActualizarId"></asp:TextBox>
                        <div class="form-group">
                            <label>Nombre:</label>
                            <asp:TextBox ID="textboxActualizarNombre" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>Tipo de Bodega:</label>
                            <asp:TextBox runat="server" CssClass="hidden" ID="textboxActualizarTipoBodega" Text=""></asp:TextBox>
                            <select id="dropdownActualizarTipoBodega" class="form-control" onchange="setTipoBodega();">
                                <%
                                    foreach (var item in dataTipoBodega)
                                    {
                                %>
                                <option class="form-control" value="<%=item.Id %>"><%=item.Descripcion %></option>
                                <% }
                                %>
                            </select>
                        </div>
                        <div class="form-group">
                            <label>Localización:</label>
                            <asp:TextBox ID="textboxActualizarLocalizacion" CssClass="hidden" runat="server"></asp:TextBox>
                            <select id="dropdownActualizarLocalizacion" class="form-control" onchange="setLocalizacion();">
                                <%
                                    foreach (var item in dataLocalizacion)
                                    {
                                %>
                                <option class="form-control" value="<%=item.Id %>"><%=item.Descripcion %></option>
                                <% }
                                %>
                            </select>
                        </div>
                        <div class="form-group">
                            <label>Código:</label>
                            <asp:TextBox ID="textboxActualizarCodigo" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>Descuento Máximo:</label>
                            <div class="input-group">
                                <asp:TextBox ID="textboxActualizarDescuentoMaximo" TextMode="Number" CssClass="form-control" runat="server"></asp:TextBox>
                                <span class="input-group-addon" id="basic-addon3">%</span>
                            </div>
                        </div>
                        <div class="form-group">
                            <label>Grupo de Dispositivos:</label>
                            <asp:TextBox ID="textboxActualizarGrupoDispositivos" CssClass="hidden" runat="server"></asp:TextBox>
                            <select id="dropdownActualizarGrupoDispositivos" class="form-control" onchange="setGrupoDispositivos();">
                                <%
                                    foreach (var item in dataDispositivoIOGrupo)
                                    {
                                %>
                                <option class="form-control" value="<%=item.Id %>"><%=item.Descripcion %></option>
                                <% }
                                %>
                            </select>
                        </div>
                        <div class="form-group">
                            <label>Orden:</label>
                            <asp:TextBox ID="textboxActualizarOrden" TextMode="Number" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>

                        <div class="form-check form-check-inline">
                            <asp:CheckBox runat="server" ID="checkboxActualizarTrasegar" CssClass="form-check-input form-control" Text="Trasegar:&nbsp;" TextAlign="Left" />
                        </div>
                        <div class="form-check form-check-inline">
                            <asp:CheckBox runat="server" ID="checkboxActualizarProduccion" CssClass="form-check-input form-control" Text="Producción:&nbsp;" TextAlign="Left" />
                        </div>
                        <div class="form-check form-check-inline">
                            <asp:CheckBox runat="server" ID="checkboxActualizarOpcionCompra" CssClass="form-check-input form-control" Text="Opción de Compra:&nbsp;" TextAlign="Left" />
                        </div>
                        <div class="form-check form-check-inline">
                            <asp:CheckBox runat="server" ID="checkboxActualizarErpSync" CssClass="form-check-input form-control" Text="ERP Sync:&nbsp;" TextAlign="Left" />
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

    </form>
</asp:Content>
