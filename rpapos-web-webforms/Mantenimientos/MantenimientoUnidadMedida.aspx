<%@ Page Title="" Language="C#" MasterPageFile="~/Core.Master" AutoEventWireup="true" CodeBehind="MantenimientoUnidadMedida.aspx.cs" Inherits="rpapos_web_webforms.MantenimientoUnidadMedida" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="FormNav" runat="server">

    <%--<button type="button" class="btn btn-info btn-lg" data-toggle="modal" data-target="#myModal">Open Modal</button>--%>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="FormBody" runat="server">
    <form runat="server">
        <div class="row">
            <div class="col-lg-12 col-md-8 col-sm-10 col-xs-5">
                <div class="ibox float-e-margins">
                    <div class="ibox-title">
                        <h5>Unidades de Medida</h5>
                        <div class="pull-right">
                            <asp:Button ID="TransferFileBtn" runat="server"
                                CssClass="btn btn-primary" Text="Transfer file"
                                OnClientClick="$('#myModal').modal(); return false;" />
                        </div>
                        <div class="clearfix"></div>
                    </div>
                    <div class="ibox-content">

                        <asp:GridView ID="gridViewUnidadMedida" GridLines="None" AutoGenerateColumns="true" runat="server" CssClass="table table-hover" UseAccessibleHeader="true" BorderStyle="None" BorderWidth="0">
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
        <input type="text" name="text" value="asdfasdf" id="text" />



        <!-- Modal -->
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
                        <asp:Button ID="SendToBillingBtn" runat="server" CssClass="btn btn-primary" Text="Yes" />
                        &nbsp;&nbsp;&nbsp;
                    <button class="btn btn-primary" data-dismiss="modal" aria-hidden="true">No</button>
                    </div>
                </div>
            </div>
        </div>
    </form>
</asp:Content>


