<%@ Page Title="Familias" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="FamiliasSalcedo.aspx.cs" Inherits="SistemaInventario.Maestros.FamiliasSalcedo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="../Asset/js/jquery-1.10.2.js" type="text/javascript"></script>
    <script src="../Asset/js/jquery-ui-1.10.4.custom.js" type="text/javascript"></script>
    <script src="../Asset/js/jquery-ui-1.10.4.custom.min.js" type="text/javascript"></script>
    <script src="../Asset/js/jquery.timers.js" type="text/javascript"></script>
    <script src="../Asset/js/jq-ui/1.10.2/development-bundle/ui/i18n/jquery.ui.datepicker-es.js"
        type="text/javascript"></script>
    <script src="../Asset/js/autoNumeric-1.4.3.js" type="text/javascript"></script>
    <script src="../Asset/js/js.js" type="text/javascript"></script>
    
    <script src="../Scripts/utilitarios.js" type="text/javascript" language="javascript"
        charset="UTF-8"></script>
    <script type="text/javascript" language="javascript" src="FamiliasSalcedo.js" charset="UTF-8"></script>
    <link href="../Asset/css/redmond/jquery-ui-1.10.4.custom.css" rel="stylesheet" type="text/css" />
    <link href="../Asset/css/Redmond/jquery-ui-1.10.4.custom.min.css" rel="stylesheet"
        type="text/css" />
    <link href="../Asset/css/style.css" rel="stylesheet" type="text/css" />
     <link href="../Asset/toars/toastr.min.css" rel="stylesheet" type="text/css" />
    <script src="../Asset/toars/toastr.min.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="titulo">
        Familias</div>
    <div id="divTabs">
        <ul>
            <li id="liRegistro"><a href="#tabRegistro">Registro</a></li>
            <li id="liConsulta"><a href="#tabConsulta" onclick="getContentTab();">Consulta</a></li>
        </ul>
        <div id="tabRegistro">
            <div class="ui-jqgrid ui-widget ui-widget-content ui-corner-all" style="width: 460px">
                <div class="ui-jqgrid-titlebar ui-widget-header ui-corner-top ui-helper-clearfix">
                    REGISTRO DE Familias
                </div>
                <div>
                    <table cellpadding="0" cellspacing="0" class="form-inputs">
                        <tr style="display: none">
                            <td style="font-weight: bold">
                                EMPRESA
                            </td>
                            <td>
                                <div id="div_Empresa">
                                    <asp:DropDownList ID="ddlEmpresa" runat="server" Font-Names="Arial" ForeColor="Blue"
                                        Font-Bold="True" Width="354">
                                    </asp:DropDownList>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold">
                                CODIGO
                            </td>
                            <td>
                                <asp:TextBox ID="txtCodigo" runat="server" Width="350px" Font-Names="Arial"
                                    ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold">
                                Descripcion
                            </td>
                            <td>
                                <asp:TextBox ID="txtDescripcion" runat="server" Width="350px" Font-Names="Arial"
                                    ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold">
                                Estado
                            </td>
                            <td>
                                <div id="div_Estado">
                                    <asp:DropDownList ID="ddlEstado" runat="server" Font-Names="Arial" ForeColor="Blue"
                                        Font-Bold="True" Width="354">
                                    </asp:DropDownList>
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
                <div>
                <table cellpadding="0" cellspacing="0" class="form-inputs">
                       
                        <tr>
                            <td style="font-weight: bold">
                                CODIGO PRODUCTO
                            </td>
                             <td>
                                <asp:CheckBox ID="ChkCodigoProducto" runat="server" Text=""
                                    Font-Bold="True" />
                            </td>
                              <td style="font-weight: bold">
                                MOTOR
                            </td>
                             <td>
                                <asp:CheckBox ID="ChkMotor" runat="server" Text=""
                                    Font-Bold="True" />
                            </td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold">
                                MODELO VEHICULO
                            </td>
                            <td>
                                <asp:CheckBox ID="ChkModelo" runat="server" Text=""
                                    Font-Bold="True" />
                            </td>
                              <td style="font-weight: bold">
                                AÑO
                            </td>
                             <td>
                                <asp:CheckBox ID="ChkAño" runat="server" Text=""
                                    Font-Bold="True" />
                            </td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold">
                                MARCA VEHICULO
                            </td>
                            <td>
                                <asp:CheckBox ID="ChkMarca" runat="server" Text=""
                                    Font-Bold="True" />
                            </td>
                              <td style="font-weight: bold">
                                OTROS DETALLES
                            </td>
                             <td>
                                <asp:CheckBox ID="ChkDetalles" runat="server" Text=""
                                    Font-Bold="True" />
                            </td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold">
                                PLATO
                            </td>
                             <td>
                                <asp:CheckBox ID="ChkPlato" runat="server" Text=""
                                    Font-Bold="True" />
                            </td>
                              <td style="font-weight: bold">
                                DISCO
                            </td>
                            <td>
                                <asp:CheckBox ID="ChkDisco" runat="server" Text=""
                                    Font-Bold="True" />
                            </td>
                        </tr>
                      
                      
                         <tr>
                            <td style="font-weight: bold">
                                COLLARIN
                            </td>
                            <td>
                                <asp:CheckBox ID="ChkCollarin" runat="server" Text=""
                                    Font-Bold="True" />
                            </td>
                              <td style="font-weight: bold">
                                ESPESOR
                            </td>
                            <td>
                                <asp:CheckBox ID="ChkEspesor" runat="server" Text=""
                                    Font-Bold="True" />
                            </td>
                        </tr>
                         <tr>
                            <td style="font-weight: bold">
                                MEDIDA A
                            </td>
                            <td>
                                <asp:CheckBox ID="ChkMedidaA" runat="server" Text=""
                                    Font-Bold="True" />
                            </td>
                              <td style="font-weight: bold">
                                MEDIDA B
                            </td>
                            <td>
                                <asp:CheckBox ID="ChkMedidaB" runat="server" Text=""
                                    Font-Bold="True" />
                            </td>
                        </tr>
                         <tr>
                            <td style="font-weight: bold">
                                MEDIDA C
                            </td>
                             <td>
                                <asp:CheckBox ID="ChkMedidaC" runat="server" Text=""
                                    Font-Bold="True" />
                            </td>
                              <td style="font-weight: bold">
                                MEDIDA D
                            </td>
                            <td>
                                <asp:CheckBox ID="ChkMedidaD" runat="server" Text=""
                                    Font-Bold="True" />
                            </td>
                        </tr>
                           <tr>
                            <td style="font-weight: bold">
                                POSICION
                            </td>
                             <td>
                                <asp:CheckBox ID="ChkPosicion" runat="server" Text=""
                                    Font-Bold="True" />
                            </td>
                              <td style="font-weight: bold">
                                LADO
                            </td>
                            <td>
                                <asp:CheckBox ID="ChkLado" runat="server" Text=""
                                    Font-Bold="True" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="linea-button">
                    <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                        Font-Names="Arial" Font-Bold="True" Width="120px" />
                    <asp:Button ID="btnGrabar" runat="server" Text="Grabar" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                        Font-Names="Arial" Font-Bold="True" Width="120px" />
                </div>
            </div>
        </div>
        <div id="tabConsulta">
            <div id='divConsulta' class="ui-jqgrid ui-widget ui-widget-content ui-corner-all">
                <div class="ui-jqgrid-titlebar ui-widget-header ui-corner-top ui-helper-clearfix">
                    Criterio de busqueda
                </div>
                <div class="ui-jqdialog-content">
                    <table cellpadding="0" cellspacing="0" class="form-inputs" width="700">
                        <tr>
                            <td style="display: none; font-weight: bold">
                                EMPRESA
                            </td>
                            <td>
                                <div id="div_EmpresaConsulta">
                                    <asp:DropDownList ID="ddlEmpresaConsulta" runat="server" Font-Names="Arial" ForeColor="Blue"
                                        Font-Bold="True" Width="200">
                                    </asp:DropDownList>
                                </div>
                            </td>
                            
                            <td style="font-weight: bold">
                                Descripcion
                            </td>
                            <td>
                                <asp:TextBox ID="txtDescripcionConsulta" runat="server" Width="500" Font-Names="Arial"
                                    ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="linea-button">
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
                                            <label id="lblNumeroConsulta">0</label>
                                        </td>                                
                                    </tr>
                                </table>
            </div>
            <div id="div_consulta" style="padding-top: 5px;">
                <asp:GridView ID="grvConsulta" runat="server" AutoGenerateColumns="False" border="0"
                    CellPadding="0" CellSpacing="1" CssClass="GridView" GridLines="None" Width="1017px">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton runat="server" ID="imgAnularDocumento" ImageUrl="~/Asset/images/EliminarBtn.png"
                                    ToolTip="ELIMINAR FAMILIA" OnClientClick="F_EliminarRegistro(this); return false;" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton runat="server" ID="imgEditarRegistro" ImageUrl="../Asset/images/btnEdit.gif"
                                    ToolTip="EDITAR FAMILIA" OnClientClick="F_EditarRegistro(this); return false;" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Codigo" HeaderStyle-HorizontalAlign="Center">
                            <ItemStyle HorizontalAlign="Right" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblCodFamilia" Text='<%# Bind("CodFamilia") %>' CssClass="detallesart"></asp:Label>
                                <asp:HiddenField ID="hfCodEmpresa" runat="server" Value='<%# Bind("CodEmpresa") %>' />
                                <asp:HiddenField ID="hfCodEstado" runat="server" Value='<%# Bind("CodEstado") %>' />
                                <asp:HiddenField ID="hfIDFamilia" runat="server" Value='<%# Bind("IDFamilia") %>' />
                                <asp:HiddenField ID="hfPermisoCodigoProducto" runat="server" Value='<%# Bind("PermisoCodigoProducto") %>' />
                                <asp:HiddenField ID="hfPermisoMotor" runat="server" Value='<%# Bind("PermisoMotor") %>' />
                                <asp:HiddenField ID="hfPermisoModeloVehiculo" runat="server" Value='<%# Bind("PermisoModeloVehiculo") %>' />
                                <asp:HiddenField ID="hfPermisoAño" runat="server" Value='<%# Bind("PermisoAño") %>' />
                                <asp:HiddenField ID="hfPermisoMarcaVehiculo" runat="server" Value='<%# Bind("PermisoMarcaVehiculo") %>' />
                                <asp:HiddenField ID="hfPermisoOtrosDetalles" runat="server" Value='<%# Bind("PermisoOtrosDetalles") %>' />
                                <asp:HiddenField ID="hfPermisoPlato" runat="server" Value='<%# Bind("PermisoPlato") %>' />
                                <asp:HiddenField ID="hfPermisoDisco" runat="server" Value='<%# Bind("PermisoDisco") %>' />
                                <asp:HiddenField ID="hfPermisoCollarin" runat="server" Value='<%# Bind("PermisoCollarin") %>' />
                                <asp:HiddenField ID="hfPermisoEspesor" runat="server" Value='<%# Bind("PermisoEspesor") %>' />
                                <asp:HiddenField ID="hfPermisoMedidaA" runat="server" Value='<%# Bind("PermisoMedidaA") %>' />
                                <asp:HiddenField ID="hfPermisoMedidaB" runat="server" Value='<%# Bind("PermisoMedidaB") %>' />
                                <asp:HiddenField ID="hfPermisoMedidaC" runat="server" Value='<%# Bind("PermisoMedidaC") %>' />
                                <asp:HiddenField ID="hfPermisoMedidaD" runat="server" Value='<%# Bind("PermisoMedidaD") %>' />
                                <asp:HiddenField ID="hfPermisoPosicion" runat="server" Value='<%# Bind("PermisoPosicion") %>' />
                                <asp:HiddenField ID="hfPermisoLado" runat="server" Value='<%# Bind("PermisoLado") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
<%--                        <asp:TemplateField HeaderText="Empresa" HeaderStyle-HorizontalAlign="Center">
                            <ItemStyle HorizontalAlign="left" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblEmpresa" Text='<%# Bind("Empresa") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                        <asp:TemplateField HeaderText="Descripcion" HeaderStyle-HorizontalAlign="Center">
                            <ItemStyle HorizontalAlign="left" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblDscFamilia" Text='<%# Bind("DscFamilia") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Estado" HeaderText="Estado">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
    <div id="divEdicionRegistro" style="display: none;">
        <div class="ui-jqgrid ui-widget ui-widget-content ui-corner-all">
            <div class="ui-jqgrid-titlebar ui-widget-header ui-corner-top ui-helper-clearfix">
                DATOS FAMILIA
            </div>
            <div class="ui-jqdialog-content">
                <table cellpadding="0" cellspacing="0" class="form-inputs" width="700">
                    <tr style="display: none">
                        <td style="font-weight: bold">
                            EMPRESA
                        </td>
                        <td colspan='3'>
                            <div id="div_EmpresaEdicion">
                                <asp:DropDownList ID="ddlEmpresaEdicion" runat="server" Font-Names="Arial" ForeColor="Blue"
                                    Font-Bold="True" Width="403" Enabled="false">
                                </asp:DropDownList>
                            </div>
                        </td>
                    </tr>
                    <tr>
                    </tr>
                    <tr>
                        <td style="font-weight: bold">
                            Codigo
                        </td>
                        <td>
                            <asp:TextBox ID="txtCodFamiliaEdicion" runat="server" Width="50" Font-Names="Arial"
                                ForeColor="Blue" Font-Bold="True" ></asp:TextBox>
                        </td>
                        <td style="font-weight: bold">
                            Descripcion
                        </td>
                        <td>
                            <asp:TextBox ID="txtDescripcionEdicion" runat="server" Width="250" Font-Names="Arial"
                                ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="font-weight: bold">
                            ESTADO
                        </td>
                        <td colspan='3'>
                            <div id="div_EstadoEdicion">
                                <asp:DropDownList ID="ddlEstadoEdicion" runat="server" Font-Names="Arial" ForeColor="Blue"
                                    Font-Bold="True" Width="403">
                                </asp:DropDownList>
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
            <div>
                <table cellpadding="0" cellspacing="0" class="form-inputs">
                       
                        <tr>
                            <td style="font-weight: bold">
                                CODIGO PRODUCTO
                            </td>
                             <td>
                                <asp:CheckBox ID="ChkCodigoProductoEdicion" runat="server" Text=""
                                    Font-Bold="True" />
                            </td>
                              <td style="font-weight: bold">
                                MOTOR
                            </td>
                             <td>
                                <asp:CheckBox ID="ChkMotorEdicion" runat="server" Text=""
                                    Font-Bold="True" />
                            </td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold">
                                MODELO VEHICULO
                            </td>
                            <td>
                                <asp:CheckBox ID="ChkModeloEdicion" runat="server" Text=""
                                    Font-Bold="True" />
                            </td>
                              <td style="font-weight: bold">
                                AÑO
                            </td>
                             <td>
                                <asp:CheckBox ID="ChkAñoEdicion" runat="server" Text=""
                                    Font-Bold="True" />
                            </td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold">
                                MARCA VEHICULO
                            </td>
                            <td>
                                <asp:CheckBox ID="ChkMarcaEdicion" runat="server" Text=""
                                    Font-Bold="True" />
                            </td>
                              <td style="font-weight: bold">
                                OTROS DETALLES
                            </td>
                             <td>
                                <asp:CheckBox ID="ChkDetallesEdicion" runat="server" Text=""
                                    Font-Bold="True" />
                            </td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold">
                                PLATO
                            </td>
                             <td>
                                <asp:CheckBox ID="ChkPlatoEdicion" runat="server" Text=""
                                    Font-Bold="True" />
                            </td>
                              <td style="font-weight: bold">
                                DISCO
                            </td>
                            <td>
                                <asp:CheckBox ID="ChkDiscoEdicion" runat="server" Text=""
                                    Font-Bold="True" />
                            </td>
                        </tr>
                      
                      
                         <tr>
                            <td style="font-weight: bold">
                                COLLARIN
                            </td>
                            <td>
                                <asp:CheckBox ID="ChkCollarinEdicion" runat="server" Text=""
                                    Font-Bold="True" />
                            </td>
                              <td style="font-weight: bold">
                                ESPESOR
                            </td>
                            <td>
                                <asp:CheckBox ID="ChkEspesorEdicion" runat="server" Text=""
                                    Font-Bold="True" />
                            </td>
                        </tr>
                         <tr>
                            <td style="font-weight: bold">
                                MEDIDA A
                            </td>
                            <td>
                                <asp:CheckBox ID="ChkMedidaAEdicion" runat="server" Text=""
                                    Font-Bold="True" />
                            </td>
                              <td style="font-weight: bold">
                                MEDIDA B
                            </td>
                            <td>
                                <asp:CheckBox ID="ChkMedidaBEdicion" runat="server" Text=""
                                    Font-Bold="True" />
                            </td>
                        </tr>
                         <tr>
                            <td style="font-weight: bold">
                                MEDIDA C
                            </td>
                             <td>
                                <asp:CheckBox ID="ChkMedidaCEdicion" runat="server" Text=""
                                    Font-Bold="True" />
                            </td>
                              <td style="font-weight: bold">
                                MEDIDA D
                            </td>
                            <td>
                                <asp:CheckBox ID="ChkMedidaDEdicion" runat="server" Text=""
                                    Font-Bold="True" />
                            </td>
                        </tr>
                           <tr>
                            <td style="font-weight: bold">
                                POSICION
                            </td>
                             <td>
                                <asp:CheckBox ID="ChkPosicionEdicion" runat="server" Text=""
                                    Font-Bold="True" />
                            </td>
                              <td style="font-weight: bold">
                                LADO
                            </td>
                            <td>
                                <asp:CheckBox ID="ChkLadoEdicion" runat="server" Text=""
                                    Font-Bold="True" />
                            </td>
                        </tr>
                    </table>
                </div>
            <div class="linea-button">
                <asp:Button ID="btnEdicion" runat="server" Text="Grabar" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                    Font-Names="Arial" Font-Bold="True" Width="120px" />
            </div>
        </div>
    </div>
    <div id="dlgWait" style="background-color: #CCE6FF; text-align: center; display: none;">
        <br />
        <br />
        <center>
            <asp:Label ID="Label2" runat="server" Text="PROCESANDO..." Font-Bold="true" Font-Size="Large"
                Style="text-align: center"></asp:Label></center>
        <br />
        <br />
        <br />
        <center>
            <img alt="Wait..." src="../Asset/images/ajax-loader2.gif" /></center>
    </div>
    <input id="hfIDFamilia" type="hidden" value="0" />
    <input id="hfCodLinea" type="hidden" value="0" />
</asp:Content>
