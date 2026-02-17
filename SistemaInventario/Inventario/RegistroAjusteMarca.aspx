<%@ Page Title="Ajuste" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistroAjusteMarca.aspx.cs" Inherits="SistemaInventario.Inventario.RegistroAjusteMarca" %>
   

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="../Asset/js/jquery-1.10.2.js" type="text/javascript"></script>
    <script src="../Asset/js/jquery-ui-1.10.4.custom.min.js" type="text/javascript"></script>
    <script src="../Asset/js/jquery.timers.js" type="text/javascript"></script>
    <script src="../Asset/js/jq-ui/1.10.2/development-bundle/ui/i18n/jquery.ui.datepicker-es.js" type="text/javascript"></script>       
    <script src="../Asset/js/autoNumeric-1.4.3.js" type="text/javascript"></script>
    <script src="../Asset/js/js.js" type="text/javascript"></script>
    <script src="../Scripts/utilitarios.js" type="text/javascript" language="javascript" charset="UTF-8"></script>
    <script type="text/javascript" language="javascript" src="RegistroAjusteMarca.js" charset="UTF-8"></script>  
    <link href="../Asset/css/Redmond/jquery-ui-1.10.4.custom.min.css" rel="stylesheet"  type="text/css" />      
    <link href="../Asset/css/style.css" rel="stylesheet" type="text/css" />
     <link href="../Asset/toars/toastr.min.css" rel="stylesheet" type="text/css" />
    <script src="../Asset/toars/toastr.min.js" type="text/javascript"></script>
    <link href="../Asset/css/alertify.core.css" rel="stylesheet" type="text/css" />
    <link href="../Asset/css/alertify.default.css" rel="stylesheet" type="text/css" />
    <link href="../Asset/css/sss.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<table>
<tr valign="top">
<td style="width: 1200px" valign="top">
    <div class="titulo" style="width: 1100px">
        Ajuste de Inventario
        </div>
              <div id="divTabs" style="width: 1145px">
                    <ul>
                        <li id="liRegistro"><a href="#tabRegistro">Registro</a></li>
                        <li id="liConsulta"><a href="#tabConsulta" onclick="getContentTab();">Consulta</a></li>
                    </ul>
    <div id="tabRegistro" style="width: 1100px">
        <div class="ui-jqgrid ui-widget ui-widget-content ui-corner-all">
            <div class="ui-jqgrid-titlebar ui-widget-header ui-corner-top ui-helper-clearfix">
                Registro de Ajuste
            </div>
            <div id="divConsultaArticulo">
                <div class="ui-jqdialog-content">
                    <table cellpadding="0" cellspacing="0" width="1100" class="form-inputs">
                        <tr>
                            <td style="font-weight: bold">
                                Descripcion
                            </td>
                            <td>
                                <asp:TextBox ID="txtArticulo" runat="server" Width="800px" Font-Names="Arial" ForeColor="Blue"
                                    Font-Bold="True"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                              <td style="font-weight: bold;">
                                                     
                                                    </td>
                                                    <td style="font-weight: bold;">
   <asp:CheckBox runat="server" ID="chkAjusteInventarioNegativoCero" Text="PASAR TODOS LOS PRODUCTOS EN NEGATIVO A CERO" onclick="F_NegativoCero(this.id);"
                                                          Font-Bold="True" Font-Size="Medium" />
                                                        <asp:CheckBox runat="server" ID="chkAjusteInventarioCero" Text="PASAR TODOS LOS PRODUCTOS A CERO" onclick="F_TodoCero(this.id);"
                                                            Font-Bold="True"  Font-Size="Medium"  />
                                                    </td>
                        </tr>
              

                              <tr>
                            <td style="font-weight: bold">
                                Observacion
                            </td>
                            <td>
                                <asp:TextBox ID="txtObservacionAjuste" runat="server" Width="800px" Font-Names="Arial" ForeColor="Blue"
                                    Font-Bold="True"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <div class="linea-button">
                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" Font-Names="Arial" Font-Bold="True"
                    class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                    Width="120" />
                <asp:Button ID="btnAgregar" runat="server" Text="Grabar" Font-Names="Arial" Font-Bold="True"
                    Width="120" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only" />
            </div>
        </div>
        <div style="padding-top: 5px;">
               <table cellpadding="0" cellspacing="0" align="center">
                                    <tr>
                                        <td style="font-weight: bold">
                                           Cantidad de Registros:
                                        </td>
                                        <td style="font-weight: bold">
                                            <label id="lblNumeroConsulta">0</label>
                                        </td>                                
                                    </tr>
                                </table>
            </div>
        <div id="div_grvConsultaArticulo" style="padding-top: 5px;">
            <asp:GridView ID="grvConsultaArticulo" runat="server" AutoGenerateColumns="False"
                border="0" CellPadding="0" CellSpacing="1" CssClass="GridView" GridLines="None"
                Width="1100px">
                <Columns>
                    <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center">
                    <HeaderTemplate>
                                                                <asp:CheckBox ID="checkAll" runat="server" onclick="checkAll(this);" />
                                                            </HeaderTemplate>
                        <ItemTemplate>
                            <asp:CheckBox runat="server" ID="chkOK" CssClass="chkSi" Text="" onclick="F_ValidarCheck(this.id);" />
                        </ItemTemplate>
                    </asp:TemplateField>                 
               
                       <asp:TemplateField HeaderText="Codigo">
                        <ItemStyle HorizontalAlign="Left" />
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblCodigo" Text='<%# Bind("CodigoProducto") %>' CssClass="detallesart"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Producto" HeaderText="Producto">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                              <asp:BoundField DataField="Marca" HeaderText="Marca">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Stock">
                        <ItemStyle HorizontalAlign="Center" />
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblstock" Text='<%# Bind("Stock") %>'></asp:Label>
                            <asp:HiddenField ID="hfCodUnidadCompra" runat="server" Value='<%# Bind("CodUnidadCompra") %>' />
                            <asp:HiddenField ID="hfCodUnidadVenta" runat="server" Value='<%# Bind("CodUnidadVenta") %>' />
                            <asp:HiddenField ID="hfFactor" runat="server" Value='<%# Bind("Factor") %>' />
                            <asp:HiddenField ID="hfCodProducto" runat="server" Value='<%# Bind("CodProducto") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="UM" HeaderText="UM">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                           <asp:TemplateField HeaderText="Nuevo Stock" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:TextBox runat="server" ID="txtCantidad" Width="55px" Style="text-align: center;"
                                CssClass="ccsestilo" Font-Names="Arial" ForeColor="Blue" Font-Bold="True" Enabled="False" Text="0"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Observacion" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:TextBox runat="server" ID="txtObservacion" Width="400px" CssClass="ccsestilo"
                                Font-Names="Arial" ForeColor="Blue" Font-Bold="True"  Text="" Enabled="False"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
         <div id="tabConsulta">
                        <div id='divConsulta' class="ui-jqgrid ui-widget ui-widget-content ui-corner-all">
                            <div class="ui-jqgrid-titlebar ui-widget-header ui-corner-top ui-helper-clearfix">
                                Criterio de busqueda
                            </div>
                            <div class="ui-jqdialog-content">
                                <table cellpadding="0" cellspacing="0" class="form-inputs">
                                    <tbody>
                                        <tr>
                                            <td style="font-weight: bold">
                                                Usuario
                                            </td>
                                            <td>
                                                <div id="div_Usuario">
                                                    <asp:DropDownList ID="ddlUsuario" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                        Font-Bold="True" Width="85px">
                                                
                                                    </asp:DropDownList>
                                                </div>
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="chkRango" runat="server" Text="Fecha" Font-Bold="True" />
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtDesde" runat="server" Width="50" Font-Names="Arial" ForeColor="Blue"
                                                    Font-Bold="True" CssClass="Jq-ui-dtp" ReadOnly="True"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtHasta" runat="server" Width="50" Font-Names="Arial" ForeColor="Blue"
                                                    Font-Bold="True" CssClass="Jq-ui-dtp" ReadOnly="True"></asp:TextBox>
                                            </td>                                         
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                            <div class="linea-button" style="height: 25px">                                            
                                <asp:Button ID="btnBuscarConsulta" runat="server" Text="Buscar" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                                    Font-Names="Arial" Font-Bold="True" Width="120" />
                            </div>
                        </div>
                       <div style="padding-top: 5px;">
               <table cellpadding="0" cellspacing="0" align="center">
                                    <tr>
                                        <td style="font-weight: bold">
                                           Cantidad de Registros:
                                        </td>
                                        <td style="font-weight: bold">
                                            <label id="lblGrillaConsulta"></label>
                                        </td>                                
                                    </tr>
                                </table>
            </div>
                        <div id="div_consulta">
                            <asp:GridView ID="grvConsulta" runat="server" AutoGenerateColumns="False" border="0"
                                CellPadding="0" CellSpacing="1" CssClass="GridView" GridLines="None" Width="1005px"
                                OnRowDataBound="grvConsulta_RowDataBound">
                                <Columns>                        
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:ImageButton runat="server" ID="imgAnularDocumento" ImageUrl="~/Asset/images/EliminarBtn.png"
                                                ToolTip="ELIMINAR AJUSTE" OnClientClick="F_EliminarRegistro(this); return false;" />
                                        </ItemTemplate>
                                    </asp:TemplateField>                  

                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <img id="imgMas" alt="" style="cursor: pointer" src="../Asset/images/plus.gif" onclick="imgMas_Click(this);"
                                                title="Ver Detalle" />
                                            <asp:Panel ID="pnlOrders" runat="server" Style="display: none">
                                                <asp:GridView ID="grvDetalle" runat="server" border="0" CellPadding="0" CellSpacing="1"
                                                    AutoGenerateColumns="False" GridLines="None" class="GridView">
                                                    <Columns>                                     
                                                        <asp:BoundField DataField="Codigo" HeaderText="Codigo">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Left" />
                                                        </asp:BoundField>
                                                           <asp:BoundField DataField="Descripcion" HeaderText="Descripcion">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Left" />
                                                        </asp:BoundField>
                                                                <asp:BoundField DataField="Marca" HeaderText="Marca">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Left" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Entrada" HeaderText="Entrada">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Right" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Salida" HeaderText="Salida">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Right" />
                                                        </asp:BoundField>                                              
                                                    </Columns>
                                                </asp:GridView>
                                            </asp:Panel>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                       <asp:TemplateField HeaderText="Fecha" HeaderStyle-HorizontalAlign="Center">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblFecha" Text='<%# Bind("Fecha") %>' CssClass="detallesart"></asp:Label>
                                            <asp:HiddenField ID="hfCodigoTransaccion" runat="server" Value='<%# Bind("CodigoTransaccion") %>' />                      
                                            <asp:HiddenField ID="hfDetalleCargado" runat="server" Value='0' />         
                                        </ItemTemplate>
                                    </asp:TemplateField>                                   
                                    <asp:BoundField DataField="Usuario" HeaderText="Usuario" HeaderStyle-HorizontalAlign="Left">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Observacion" HeaderText="Observacion" HeaderStyle-HorizontalAlign="Left">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>                                 
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                            </div>
</td>
</tr>
</table>




    <div id="dlgWait" style="background-color: #CCE6FF; text-align: center; display: none;">
        <br />
        <br />
        <center>
            <asp:Label ID="Label2" runat="server" Text="PROCESANDO..." Font-Bold="true" Font-Size="Large"
                Style="text-align: center"></asp:Label></center>
        <br />
        <center>
            <img alt="Wait..." src="../Asset/images/ajax-loader2.gif" /></center>
    </div>
    <input id="hfCodCtaCte" type="hidden" value="0" />
    <input id="hfCodCtaCteConsulta" type="hidden" value="0" />
    <input id="hfCodigoTemporal" type="hidden" value="0" />
    <input id="hfCodDocumentoVenta" type="hidden" value="0" />
</asp:Content>
