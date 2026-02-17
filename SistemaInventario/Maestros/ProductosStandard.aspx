<%@ Page Title="Productos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"   CodeBehind="ProductosStandard.aspx.cs" Inherits="SistemaInventario.Maestros.ProductosStandard" %>
 
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="../Asset/js/jquery-1.10.2.js" type="text/javascript"></script>
    <script src="../Asset/js/jquery-ui-1.10.4.custom.min.js" type="text/javascript"></script>
    <script src="../Asset/js/jquery.timers.js" type="text/javascript"></script>
    <script src="../Asset/js/jq-ui/1.10.2/development-bundle/ui/i18n/jquery.ui.datepicker-es.js"  type="text/javascript"></script>      
    <script src="../Asset/js/autoNumeric-1.4.3.js" type="text/javascript"></script>
    <script src="../Asset/js/dropzone.min.js" type="text/javascript"></script>
    <script type="text/javascript">        Dropzone.autoDiscover = false;</script>
    <script src="../Asset/js/sss.js" type="text/javascript"></script>
    <link rel="stylesheet" href="../Asset/css/checkbox.css" />
    <link rel="stylesheet" href="../Asset/css/imagescss.css" />
    <link href="../Asset/css/sss.css" rel="stylesheet" type="text/css" />
    <script src="../Asset/js/js.js" type="text/javascript">  </script>
    <script src="../Scripts/utilitarios.js" type="text/javascript" language="javascript"  charset="UTF-8"></script>      
    <script src="../Scripts/inputatajos/kibo.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript" src="ProductosStandard.js" charset="UTF-8"></script>
    <link href="../Asset/css/Redmond/jquery-ui-1.10.4.custom.min.css" rel="stylesheet"    type="text/css" />    
    <link rel="stylesheet" href="../Asset/css/dropzone.css" />
    <link href="../Asset/css/style.css" rel="stylesheet" type="text/css" />
    <link href="../Asset/toars/toastr.min.css" rel="stylesheet" type="text/css" />
    <script src="../Asset/toars/toastr.min.js" type="text/javascript"></script>
    <link href="../Asset/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="titulo" style="width: 1230px;">
        Productos</div>
    <div id="divTabs" style="width: 1230px;">
        <ul>
            <li id="liRegistro"><a href="#tabRegistro">Registro</a></li>
            <li id="liConsulta"><a href="#tabConsulta">Consulta</a></li>
             <li id="liImagen" ><a href="#tabImagen">Imagen</a></li>
        </ul>

        <div id="tabRegistro">
            <table cellpadding="0" cellspacing="0" class="form-inputs">
                <tr>
                    <td valign="top">
                        <%--DATOS DEL PRODUCTO--%>
                        <div class="ui-jqgrid ui-widget ui-widget-content ui-corner-all" style="width: 750px;">
                            <div class="ui-jqgrid-titlebar ui-widget-header ui-corner-top ui-helper-clearfix">
                                REGISTRO DE PRODUCTOS
                            </div>
                            <div>
                                <table cellpadding="0" cellspacing="0" class="form-inputs">
                                    <tr>
                                        <td style="font-weight: bold; width: 120">
                                            Codigo
                                        </td>
                                        <td>
                                            <table cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td>
                                                        <asp:TextBox ID="txtCodigoInterno" runat="server" Width="244px" Font-Names="Arial"
                                                            ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                                    </td>
                                                    <td style="font-weight: bold">
                                                        Familia
                                                    </td>
                                                    <td style="padding-left: 11px;">
                                                        <div id="div_Familia">
                                                            <asp:DropDownList ID="ddlFamilia" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                                Font-Bold="True" Width="225">
                                                            </asp:DropDownList>
                                                        </div>
                                                    </td>
                                                    <td style="padding-left: 1px; font-weight: bold">
                                                        t.c.
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtTC" runat="server" Width="31px" Font-Names="Arial" ForeColor="Blue"
                                                            Font-Bold="True" ReadOnly="True" Text="3.097"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                  
                                    <tr>
                                        <td style="font-weight: bold">
                                            Descripcion
                                        </td>

                                             <td colspan='5'>
                                            <table cellpadding="0" cellspacing="0">
                                                <tr>
                                        <td>
                                            <asp:TextBox ID="txtDescripcion" runat="server" Width="416px" Font-Names="Arial"
                                                ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                        </td>
                                         <td style="font-weight: bold;">
                                                        MARCA
                                                    </td>
                                                  
                                                       <td>
                                                        <asp:TextBox ID="txtMarca" runat="server" Width="120px" Font-Names="Arial" ForeColor="Blue"
                                                            Font-Bold="True"></asp:TextBox>
                                                    </td>

                               

                                                    </tr>
                                                    </table>
                                                    </td>
                                    </tr>

                                     <tr>
                                        <td style="font-weight: bold">
                                            Observacion
                                        </td>
                                        <td colspan='5'>
                                            <table cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td>
                                                      <asp:TextBox ID="txtObservacion" runat="server" Width="585px" Font-Names="Arial" ForeColor="Blue"
                                                            Font-Bold="True" TextMode="MultiLine" Height="40"></asp:TextBox>
                                                     
                                                    </td>
                                                 
                                              
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                           <td style="font-weight: bold">
                                                        UBICACION
                                                    </td>
                                        <td style="padding-left: 4px;">
                                                        <asp:TextBox ID="txtUbicacion" runat="server" Width="585px" Font-Names="Arial" ForeColor="Blue"
                                                            Font-Bold="True"></asp:TextBox>
                                                    </td>
                                    </tr>

                                
                                   
                                    <tr>
                                        <td style="font-weight: bold">
                                            Moneda PRECIO
                                        </td>
                                        <td colspan='5'>
                                            <table cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td style="padding-left: 2px;">
                                                        <div id="div_moneda">
                                                            <asp:DropDownList ID="ddlMoneda" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                                Font-Bold="True" Width="80">
                                                            </asp:DropDownList>
                                                        </div>
                                                    </td>
                                          
                                                    <td style="font-weight: bold;">
                                                        Precio 1
                                                    </td>
                                                    <td style="padding-left: 30px;">
                                                        <asp:TextBox ID="txtPrecio1" runat="server" Width="80px" Font-Names="Arial" ForeColor="Blue"
                                                            Font-Bold="True" CssClass="Derecha"></asp:TextBox>
                                                    </td>
                                                    <td style="font-weight: bold;">
                                                        precio 2
                                                    </td>
                                                    <td style="padding-left: 8px;">
                                                        <asp:TextBox ID="txtPrecio2" runat="server" Width="80px" Font-Names="Arial" ForeColor="Blue"
                                                            Font-Bold="True" CssClass="Derecha"></asp:TextBox>
                                                    </td>
                                                   
                                                     <td style="font-weight: bold;padding-left: 61px;">
                                                        precio 3
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtPrecio3" runat="server" Width="80px" Font-Names="Arial" ForeColor="Blue"
                                                            Font-Bold="True" CssClass="Derecha" Text="0"></asp:TextBox>
                                                    </td>
                                                      
                                                   
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                    <td style="font-weight: bold">
                                   MONEDA COSTO 
                                    </td>
                                                    <td colspan='5'>
                                                    <table  cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td style="padding-left: 2px;">
                                                        <div id="div_MonedaCostoInicial">
                                                            <asp:DropDownList ID="ddlMonedaCostoInicial" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                                Font-Bold="True" Width="80">
                                                            </asp:DropDownList>
                                                        </div>
                                                    </td>
                                                       <td style="font-weight: bold">
                                    COSTO INICIAL
                                    </td>
                                                    <td>
                                                      <asp:TextBox ID="txtCosto" runat="server" Width="80px" Font-Names="Arial" ForeColor="Blue"
                                                            Font-Bold="True" CssClass="Derecha"></asp:TextBox>
                                                    </td>
                                                    <td  style="font-weight: bold">
                                                    UM
                                                    </td>
                                        <td style="padding-left: 40px">
                                                        <div id="div_umcompra">
                                                            <asp:DropDownList ID="ddlUMCompra" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                                Font-Bold="True" Width="84">
                                                            </asp:DropDownList>
                                                        </div>
                                                    </td>
                                                    </tr>
                                                    </table>
                                                      
                                                    </td>
                                    </tr>
                                     <tr id="tdMayorista" style = "display:none;">
                                     <td style="font-weight: bold">
                                            Exclusivo
                                        </td>
                                        <td colspan='5'>
                                            <table cellpadding="0" cellspacing="0">
                                                <tr>
                                                 <td >
                                                        <asp:TextBox ID="txtExclusivo" runat="server" Width="76px" Font-Names="Arial" ForeColor="Blue"
                                                            Font-Bold="True" CssClass="Derecha"></asp:TextBox>
                                                    </td>
                                                    
                                                        <td>
                                <asp:CheckBox ID="chkBloqueoMayorista" runat="server" Text="Bloqueo Mayorista"
                                    Font-Bold="True" />
                            </td>

                                <td>
                                <asp:CheckBox ID="chkBloqueoExclusivo" runat="server" Text="Bloqueo Exclusivo"
                                    Font-Bold="True" />
                            </td>
                                                
                                                    <td style="padding-left: 13px;display:none;">
                                                        <asp:TextBox ID="txtCantidad" runat="server" Width="60px" Font-Names="Arial" ForeColor="Blue"
                                                            Font-Bold="True"  CssClass="Derecha" Text="0"></asp:TextBox>
                                                    </td>

                                               
                                                    <td style="padding-left: 19px;display:none;">
                                                        <asp:TextBox ID="txtLimite" runat="server" Width="60px" Font-Names="Arial" ForeColor="Blue"
                                                            Font-Bold="True"  CssClass="Derecha" Text="0"></asp:TextBox>
                                                    </td>
                                                   
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr style = "display:none;">
                                        <td style="font-weight: bold">
                                            ubicacion
                                        </td>
                                        <td colspan='5'>
                                            <table cellpadding="0" cellspacing="0">
                                                <tr>
                                                
                                                    <td style="font-weight: bold; padding-left: 5px;">
                                                        Stock Min
                                                    </td>
                                                    <td style="padding-left: 5px;">
                                                        <asp:TextBox ID="txtStockMinimo" runat="server" Width="60px" Font-Names="Arial" ForeColor="Blue"
                                                            Font-Bold="True" Text="0.00" CssClass="Derecha"></asp:TextBox>
                                                    </td>
                                                    <td style="padding-left: 5px; font-weight: bold">
                                                        Stock Max
                                                    </td>
                                                    <td style="padding-left: 5px;">
                                                        <asp:TextBox ID="txtStockMaximo" runat="server" Width="60px" Font-Names="Arial" ForeColor="Blue"
                                                            Font-Bold="True" Text="0.00" CssClass="Derecha"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                      <tr style = "display:none;">
                                        <td style="font-weight: bold">
                                            Codigo
                                        </td>
                                        <td>
                                            <table cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td>
                                                        <asp:TextBox ID="txtCodigo" runat="server" Width="244px" Font-Names="Arial" ForeColor="Blue"
                                                            Font-Bold="True"></asp:TextBox>
                                                    </td>
                                                    <td style="font-weight: bold">
                                                        Codigo 2
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtCodigo2" runat="server" Width="263px" Font-Names="Arial" ForeColor="Blue"
                                                            Font-Bold="True"></asp:TextBox>
                                                    </td>
                                                    <td style="font-weight: bold; display: none">
                                                        Partida Arancelaria
                                                    </td>
                                                    <td style="display: none">
                                                        <asp:TextBox ID="txtPartidaArancelaria" runat="server" Width="192px" Font-Names="Arial"
                                                            ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr style="display: none;">
                                        <td style="font-weight: bold">
                                            Desc. Ingles
                                        </td>
                                        <td style="padding-left: 4px;">
                                            <asp:TextBox ID="txtDescripcionIngles" runat="server" Width="568px" Font-Names="Arial"
                                                ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                        </td>
                                    </tr>
                                     <tr style="display: none">
                                        <td style="font-weight: bold">
                                            Medida
                                        </td>
                                        <td colspan='5'>
                                            <table cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td>
                                                        <asp:TextBox ID="txtMedida" runat="server" Width="211px" Font-Names="Arial" ForeColor="Blue"
                                                            Font-Bold="True"></asp:TextBox>
                                                    </td>
                                                    <td style="font-weight: bold">
                                                        Posicion
                                                    </td>
                                                    <td style="padding-left: 15px;">
                                                        <asp:TextBox ID="txtPosicion" runat="server" Width="248px" Font-Names="Arial" ForeColor="Blue"
                                                            Font-Bold="True"></asp:TextBox>
                                                    </td>
                                                    <td style="font-weight: bold">
                                                        Modelo
                                                    </td>
                                                    <td style="padding-left: 21px;">
                                                        <asp:TextBox ID="txtModelo" runat="server" Width="248px" Font-Names="Arial" ForeColor="Blue"
                                                            Font-Bold="True"></asp:TextBox>
                                                    </td>
                                                    <td style="font-weight: bold">
                                                        Año
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtAño" runat="server" Width="211px" Font-Names="Arial" ForeColor="Blue"
                                                            Font-Bold="True"></asp:TextBox>
                                                    </td>
                                                    <td style="padding-left: 25px; font-weight: bold">
                                                        Factor
                                                    </td>
                                                    <td style="padding-left: 13px;">
                                                        <asp:TextBox ID="txtFactor" runat="server" Width="74px" Font-Names="Arial" ForeColor="Blue"
                                                            Font-Bold="True" Text="0.00"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                        <tr style = "display:none;">
                                        <td style="font-weight: bold">
                                            Marca
                                        </td>
                                        <td colspan='5'>
                                            <table cellpadding="0" cellspacing="0">
                                                <tr>
                                                 
                                                    
                                                    <td style="padding-left: 5px; font-weight: bold; display: none">
                                                        UM Venta
                                                    </td>
                                                    <td style="padding-left: 22px; font-weight: bold; display: none">
                                                        <div id="div_umventa">
                                                            <asp:DropDownList ID="ddlUMVenta" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                                Font-Bold="True" Width="78">
                                                            </asp:DropDownList>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div class="linea-button">
                                <asp:Button ID="btnGrabar" runat="server" Text="Grabar" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                                    Font-Names="Arial" Font-Bold="True" Width="120px" />
                            </div>
                        </div>
                    </td>
                    <td >
                    
                       
                                    </tr>
                                </table>
                            </div>     
        <div id="tabConsulta">
             <div id='divConsulta' class="ui-jqgrid ui-widget ui-widget-content ui-corner-all">
                <div class="ui-jqgrid-titlebar ui-widget-header ui-corner-top ui-helper-clearfix">
                    Criterio de busqueda
                </div>
                <div class="ui-jqdialog-content">
                    <table cellpadding="0" cellspacing="0" class="form-inputs">
                        <tr>
                            <td style="font-weight: bold">
                                familia
                            </td>
                            <td>
                                <div id="div_familiaconsulta">
                                    <asp:DropDownList ID="ddlFamiliaConsulta" runat="server" Font-Names="Arial" ForeColor="Blue"
                                        Font-Bold="True">
                                    </asp:DropDownList>
                                </div>
                            </td>
                            <td style="font-weight: bold">
                                Codigo / Producto
                            </td>
                            <td>
                                <asp:TextBox ID="txtDescripcionConsulta" runat="server" Width="647" Font-Names="Arial"
                                    ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                            </td>
                            <td style="padding-left: 5px; font-weight: bold;">
                                Estado
                            </td>
                            <td style="padding-left: 22px; font-weight: bold;">
                                <div id="div_FiltroEstados">
                                    <asp:DropDownList ID="ddlFiltroCodEstado" runat="server" Font-Names="Arial" ForeColor="Blue"
                                        Font-Bold="True" Width="78">
                                        <asp:ListItem Value="0">Todos</asp:ListItem>
                                        <asp:ListItem Value="1" Selected>Activos</asp:ListItem>
                                        <asp:ListItem Value="2">Inactivos</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="linea-button">
                    <asp:Button ID="btnBuscarConsulta" runat="server" Text="Buscar" CssClass="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                        Font-Names="Arial" Width="120" />
                </div>
            </div>
            <div style="padding-top: 5px;">
                <table cellpadding="0" cellspacing="0" align="center">
                    <tr>
                        <td style="font-weight: bold">
                            Cantidad de Registros:
                        </td>
                        <td style="font-weight: bold">
                            <label id="lblNumeroConsulta">0
                            </label>
                        </td>
                    </tr>
                </table>
            </div>
            <div>
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td valign="top">
                            <div id="div_consulta" style="padding-top: 5px;">
                                <asp:GridView ID="grvConsulta" runat="server" AutoGenerateColumns="False" border="0"
                                    CellPadding="0" CellSpacing="1" CssClass="GridView" GridLines="None" Width="970px"
                                    OnRowDataBound="grvConsulta_RowDataBound">
                                    <Columns>
                                        <asp:TemplateField >
                                            <ItemTemplate>
                                                <center>
                                             <%--       <asp:ImageButton runat="server" ID="imgAnularDocumento" ImageUrl="~/Asset/images/EliminarBtn.png"
                                                        ToolTip="ELIMINAR PRODUCTO" OnClientClick="F_AnularRegistro(this); return false;" />
                                                    <asp:ImageButton runat="server" ID="imgActivarProducto" ImageUrl="~/Asset/images/ok.gif"
                                                        ToolTip="ACTIVAR PRODUCTO" OnClientClick="F_ActivarRegistro(this); return false;"/>  --%>                                                    
                                                    <asp:ImageButton runat="server" ID="imgEditarRegistro" ImageUrl="../Asset/images/btnEdit.gif"
                                                        ToolTip="EDITAR PRODUCTO" OnClientClick="F_EditarRegistro(this); return false;" />
                                                    <asp:ImageButton runat="server" ID="imgAgregar" ImageUrl="~/Asset/images/ok.gif"
                                                        ToolTip="STOCK ALMACENES" OnClientClick="F_AgregarArticulo(this.id,1); return false;" />
                                                    
                                                 <asp:ImageButton runat="server" ID="imgVisualizarRegistro" ImageUrl="../Asset/images/Viewx16.png"
                                        ToolTip="VISUALIZAR FOTOS DEL PRODUCTO" OnClientClick="F_VisualizarRegistro(this); return false;" />
                                                </center>
                                            </ItemTemplate>
                                        </asp:TemplateField>                                   

                                           <asp:TemplateField HeaderText="Codigo" HeaderStyle-HorizontalAlign="Center">
                                            <ItemStyle HorizontalAlign="Left" />
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblCodigoInterno" Text='<%# Bind("CodigoInterno") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Producto" HeaderStyle-HorizontalAlign="Center">
                                            <ItemStyle HorizontalAlign="Left" />
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblProducto" Text='<%# Bind("Producto") %>' CssClass="detallesart"></asp:Label>
                                                <asp:HiddenField ID="lblCodigo" runat="server" Value='<%# Bind("Codigo") %>' />                                             
                                                <asp:HiddenField ID="hfCodigoInterno" runat="server" Value='<%# Bind("CodigoInterno") %>' />                                        
                                                <asp:HiddenField ID="hfMarca" runat="server" Value='<%# Bind("Marca") %>' />                                         
                                                <asp:HiddenField ID="hfCodMoneda" runat="server" Value='<%# Bind("CodMoneda") %>' />                                               
                                                <asp:HiddenField ID="hfCodUnidadVenta" runat="server" Value='<%# Bind("CodUnidadVenta") %>' />
                                                <asp:HiddenField ID="hfIdFamilia" runat="server" Value='<%# Bind("IdFamilia") %>' />
                                                <asp:HiddenField ID="hfFactor" runat="server" Value='<%# Bind("Factor") %>' />                                                
                                                <asp:HiddenField ID="hfStockMaximo" runat="server" Value='<%# Bind("StockMaximo") %>' />
                                                <asp:HiddenField ID="hfStockMinimo" runat="server" Value='<%# Bind("StockMinimo") %>' />                                               
                                                <asp:HiddenField ID="hfCodAlterno" runat="server" Value='<%# Bind("CodAlterno") %>' /> 
                                                <asp:HiddenField ID="hfObservacion" runat="server" Value='<%# Bind("Observacion") %>' />                                                   
                                                <asp:HiddenField ID="hIdImagenProducto1" runat="server" Value='<%# Bind("IdImagenProducto1") %>' />
                                                <asp:HiddenField ID="hfFlagRelacionesVisto" runat="server" Value='' />
                                                <asp:HiddenField ID="hfDetalleCargado" runat="server" Value='' />
                                                <asp:HiddenField ID="hfPrecio1" runat="server" Value='<%# Bind("Precio1Edicion") %>' />
                                                <asp:HiddenField ID="hfPrecio2" runat="server" Value='<%# Bind("Precio2Edicion") %>' />
                                                <asp:HiddenField ID="hfPrecio3" runat="server" Value='<%# Bind("Precio3Edicion") %>' />                                       
                                                <asp:HiddenField ID="hfCodEstado" runat="server" Value='<%# Bind("CodEstado") %>' />
                                                <asp:HiddenField ID="hfUbicacion" runat="server" Value='<%# Bind("Ubicacion") %>' />                                               
                                                <asp:HiddenField ID="hfExclusivo" runat="server" Value='<%# Bind("Exclusivo") %>' />
                                                <asp:HiddenField ID="hfFlagBloqueoMayorista" runat="server" Value='<%# Bind("FlagBloqueoMayorista") %>' />
                                                <asp:HiddenField ID="hfFlagBloqueoExclusivo" runat="server" Value='<%# Bind("FlagBloqueoExclusivo") %>' />
                                                <asp:HiddenField ID="hfCostoSoles" runat="server" Value='<%# Bind("CostoSoles") %>' />
                                                <asp:HiddenField ID="hfCostoDolares" runat="server" Value='<%# Bind("CostoDolares") %>' />
                                                <asp:HiddenField ID="hfCostoInicial" runat="server" Value='<%# Bind("CostoInicial") %>' />
                                                <asp:HiddenField ID="hfCodMonedaInicial" runat="server" Value='<%# Bind("CodMonedaInicial") %>' />
                                                <asp:HiddenField ID="lblcodproducto" runat="server" Value='<%# Bind("Codigo") %>' />     
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:BoundField DataField="Observacion" HeaderText="Observacion" >
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign= "Left" />
                                        </asp:BoundField>
                                         <asp:BoundField DataField="Marca" HeaderText="Marca" >
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign= "Left" />
                                        </asp:BoundField>
                                          <asp:BoundField DataField="Ubicacion" HeaderText="Ubicacion" >
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign= "Left" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="UM" HeaderText="UM" Visible="false">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundField>

                                        <asp:BoundField DataField="Costo" HeaderText="Costo" DataFormatString="{0:N2}">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Precio1" HeaderText="P1" DataFormatString="{0:N2}">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Precio2" HeaderText="P2" DataFormatString="{0:N2}">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:BoundField>    
                                            <asp:BoundField DataField="Precio3" HeaderText="P3" DataFormatString="{0:N2}">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:BoundField>  
                                        <asp:TemplateField HeaderText="Moneda" HeaderStyle-HorizontalAlign="Center">
                                            <ItemStyle HorizontalAlign="Left" />
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblMoneda" Text='<%# Bind("Moneda") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Stock" HeaderText="Stock">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Estado" HeaderText="Estado">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundField>                                  
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </td>
                        <td valign="top" style="padding-left: 5px;">
                            <div id="divStocksEmpresas" style="width: 230px; padding-top: 5px">
                                <table>
                                    <thead>
                                        <tr>
                                            <th style="width: 190px">
                                                Almacen
                                            </th>
                                            <th style="width: 25px">
                                                Stock
                                            </th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr>
                                            <td>
                                                KARINA Principal
                                            </td>
                                            <td align="right">
                                                10
                                            </td>
                                        </tr>
                                    </tbody>
                                    <tfoot>
                                        <tr>
                                            <td>
                                                TOTAL
                                            </td>
                                            <td align="right">
                                                10
                                            </td>
                                        </tr>
                                    </tfoot>
                                </table>
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <div id="tabImagen" >
            <table>
                <tr>
                    <td valign="top">
                        <div style="width: 700px">
                            <div class="ui-jqgrid-titlebar ui-widget-header ui-corner-top ui-helper-clearfix">
                                REGISTRO DE IMAGENES
                            </div>
                            <div class="ui-jqgrid ui-widget ui-widget-content ui-corner-all" style="display:none">
                                <table>
                                    <tr>
                                        <td style="font-weight: bold">
                                            Carpeta
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtTitulo" runat="server" Width="586px" Font-Names="Arial" ForeColor="Blue"
                                                Font-Bold="True"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="font-weight: bold">
                                            Descripcion
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TextBox1" runat="server" Width="586px" Font-Names="Arial"
                                                ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div class="ui-jqgrid ui-widget ui-widget-content ui-corner-all" style="width: 698px;
                                height: 407px; padding: 0px; overflow-y: scroll;">
                                <table cellpadding="0" cellspacing="0" class="form-inputs" style="margin: 0px">
                                    <tr>
                                        <td style="height: 290px">
                                            <span>
                                                <input id="Hidden1" type="hidden" />
                                                <input id="Hidden2" type="hidden" />
                                                <input id="Hidden3" type="hidden" />
                                            </span>
                                            <div id="drop" style="padding-top: 1px;">
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </td>
                    <td valign="top">
                        <div class="ui-jqgrid-titlebar ui-widget-header ui-corner-top ui-helper-clearfix"
                            style="width: 460px">
                            PRODUCTOS RELACIONADOS
                        </div>
                        <div class="ui-jqgrid ui-widget ui-widget-content ui-corner-all" style="height: 50px;">
                            <table>
                                <tr>
                                    <td>
                                        Descripcion
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtDescripcionAgregar" runat="server" Width="325px" Font-Names="Arial"
                                            ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:ImageButton ID="btnAgregarProducto" runat="server" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                                            Font-Names="Arial" Font-Bold="True" Width="20px" Height="20px" ImageUrl="../Asset/images/ok.gif" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="ui-jqgrid ui-widget ui-widget-content ui-corner-all" style="width: 460px;
                            height: 350px; margin-top: 5px">
                            <div id="div_ProductosRelacionadosAgregar"  style="width: 455px; height: 310px; margin-top: 5px">
                                <asp:GridView ID="grvProductosAgregar" runat="server" AutoGenerateColumns="False"
                                    border="0" CellPadding="0" CellSpacing="1" CssClass="GridView" GridLines="None"
                                    DataKeyNames="ID" Width="460px" MaxHeight="310px" ShowHeader="True">
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:ImageButton runat="server" ID="imgEliminarRegistro" ImageUrl="../Asset/images/EliminarBtn.png"
                                                    ToolTip="Eliminar Producto" OnClientClick="F_EliminarRegistro(this); return false;" />
                                                <asp:HiddenField ID="hfID" runat="server" Value='<%# Bind("ID") %>' />
                                                <asp:HiddenField ID="hfCodProducto" runat="server" Value='<%# Bind("CodProducto") %>' />
                                            </ItemTemplate>
                                            <ItemStyle Width="18" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="CODIGO" HeaderText="CODIGO">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Left" Width="70px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="DESCRIPCION" HeaderText="DESCRIPCION">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                            <div class="linea-button">
                                <asp:Button ID="btnNuevoImagen" runat="server" Text="Nuevo" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                                    Font-Names="Arial" Font-Bold="True" Width="120px" />
                                <asp:Button ID="btnGrabarImagen" runat="server" Text="Grabar" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                                    Font-Names="Arial" Font-Bold="True" Width="120px" />
                            </div>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div id="div_ultimoprecio" style="display: none;">
        <div class="ui-jqdialog-content">
            <table cellpadding="0" cellspacing="0" class="form-inputs">
                <tr>
                    <td style="font-weight: bold">
                        Precio Minimo
                    </td>
                    <td>
                        <asp:TextBox ID="txtPrecioMinimo" runat="server" Width="80px" ReadOnly="True" Font-Names="Arial"
                            CssClass="Derecha" ForeColor="Blue" Font-Bold="True" Font-Size="Small"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="txtMoneda" runat="server" Width="80px" ReadOnly="True" Font-Names="Arial"
                            ForeColor="Blue" Font-Bold="True" Font-Size="Small"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
    </div>

    <div id="divEdicionRegistro" style="display: none;">
        <table cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    <div class="ui-jqgrid ui-widget ui-widget-content ui-corner-all" style="width: 700px;">
                        
                        <div class="ui-jqgrid-titlebar ui-widget-header ui-corner-top ui-helper-clearfix"
                            style="width: 700px">
                            DATOS PRODUCTO
                        </div>
                        <div class="ui-jqdialog-content" style="width: 700px">
                            <table cellpadding="0" cellspacing="0" class="form-inputs">
                                <tr>
                                    <td style="font-weight: bold; width: 120">
                                        Codigo
                                    </td>
                                    <td>
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <asp:TextBox ID="txtCodigoInternoEdicion" runat="server" Width="244px" Font-Names="Arial"
                                                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                                </td>
                                                <td style="font-weight: bold">
                                                    Familia
                                                </td>
                                                <td style="padding-left: 11px;">
                                                    <div id="div_FamiliaEdicion">
                                                        <asp:DropDownList ID="ddlFamiliaEdicion" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                            Font-Bold="True" Width="207">
                                                        </asp:DropDownList>
                                                    </div>
                                                </td>
                                                <td style="padding-left: 1px; font-weight: bold">
                                                    t.c.
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtTCEdicion" runat="server" Width="45px" Font-Names="Arial" ForeColor="Blue"
                                                        Font-Bold="True" ReadOnly="True" Text="3.097"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr style = "display:none;">
                                    <td style="font-weight: bold">
                                        Codigo
                                    </td>
                                    <td>
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <asp:TextBox ID="txtCodigoEdicion" runat="server" Width="258px" Font-Names="Arial"
                                                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                                </td>
                                                <td style="font-weight: bold">
                                                    Codigo 2
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtCodigo2Edicion" runat="server" Width="263px" Font-Names="Arial"
                                                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                                </td>
                                                <td style="font-weight: bold; display: none">
                                                    Partida Arancelaria
                                                </td>
                                                <td style="display: none">
                                                    <asp:TextBox ID="txtPartidaArancelariaEdicion" runat="server" Width="192px" Font-Names="Arial"
                                                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="font-weight: bold">
                                        Descripcion
                                    </td>
                                    <td>
                                    <table  cellpadding="0" cellspacing="0">
                                    <tr>
                                     <td>
                                        <asp:TextBox ID="txtDescripcionEdicion" runat="server" Width="415px" Font-Names="Arial"
                                            ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                    </td>
                                      <td style="font-weight: bold;">
                                                    marca
                                                </td>

                                                    <td  style="padding-left: 5px">
                                                    <asp:TextBox ID="txtMarcaEdicion" runat="server" Width="115px" Font-Names="Arial"
                                                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                                </td>
                               
                                    </tr>
                                    </table>
                                    </td>

                                   
                                </tr>

                                   <tr>
                                    <td style="font-weight: bold">
                                        OBSERVACION
                                    </td>
                                    <td colspan='5'>
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <asp:TextBox ID="txtObservacionEdicion" runat="server" Width="582px" Font-Names="Arial"
                                                        ForeColor="Blue" Font-Bold="True" TextMode="MultiLine" Height="40"></asp:TextBox>
                                                </td>
                                           
                                            </tr>
                                        </table>
                                    </td>
                                </tr>

                                <tr>
                                   <td style="font-weight: bold">
                                        ubicacion
                                    </td>
                                <td style="padding-left: 4px;">
                                                    <asp:TextBox ID="txtUbicacionEdicion" runat="server" Width="582px" Font-Names="Arial"
                                                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                                </td>
                                </tr>
                              
                                <tr>
                                    <td style="font-weight: bold">
                                        Moneda precio
                                    </td>
                                    <td colspan='5'>
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <div id="div_MonedaEdicion">
                                                        <asp:DropDownList ID="ddlMonedaEdicion" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                           Font-Bold="True" Width="80">
                                                        </asp:DropDownList>
                                                    </div>
                                                </td>
                                              
                                          
                                                <td style="font-weight: bold;">
                                                    precio 1
                                                </td>
                                                <td style="padding-left: 29px">
                                                    <asp:TextBox ID="txtPrecio1Edicion" runat="server" Width="80px" Font-Names="Arial"
                                                        ForeColor="Blue" Font-Bold="True" CssClass="Derecha"></asp:TextBox>
                                                </td>
                                                <td style="font-weight: bold">
                                                    precio 2
                                                </td>
                                                 
                                                <td style="padding-left: 12px">
                                                    <asp:TextBox ID="txtPrecio2Edicion" runat="server" Width="80px" Font-Names="Arial"
                                                        ForeColor="Blue" Font-Bold="True" CssClass="Derecha"></asp:TextBox>
                                                </td>
                                                              <td style="font-weight: bold;padding-left: 46px">
                                        precio 3
                                    </td>
                                                <td style="padding-left: 11px">
                                                    <asp:TextBox ID="txtPrecio3Edicion" runat="server" Width="80px" Font-Names="Arial"
                                                        ForeColor="Blue" Font-Bold="True" CssClass="Derecha"></asp:TextBox>
                                                </td>
                                              
                                                 
                                            </tr>
                                        </table>
                                    </td>
                                </tr>

                                <tr>
                                <td  style="font-weight: bold;">
                                MONEDA COSTO
                                </td>
                                <td  colspan='5'>
                                <table  cellpadding="0" cellspacing="0">
                                <tr>
                                   <td>
                                                    <div id="div_MonedaCostoInicialEdicion">
                                                        <asp:DropDownList ID="ddlMonedaCostoInicialEdicion" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                            Font-Bold="True" Width="80">
                                                        </asp:DropDownList>
                                                    </div>
                                                </td>
                                   <td  style="font-weight: bold;">
                                costo INICIAL
                                </td>

                                  <td>
                                                    <asp:TextBox ID="txtCostoEdicion" runat="server" Width="80px" Font-Names="Arial"
                                                        ForeColor="Blue" Font-Bold="True" CssClass="Derecha"></asp:TextBox>
                                                </td>
                                              
                                                   <td style="font-weight: bold;">
                                Estado
                            </td>
                            <td style="padding-left: 18px">
                                <div id="div_EstadoEdicion">
                                    <asp:DropDownList ID="ddlEstadoEdicion" runat="server" Font-Names="Arial" ForeColor="Blue"
                                        Font-Bold="True" Width="84">                                        
                                        <asp:ListItem Value="1">Activo</asp:ListItem>
                                        <asp:ListItem Value="2">Inactivo</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </td>
                              <td style="padding-left: 42px; font-weight: bold">
                                                    UM 
                                                </td>
                                                <td style="padding-left: 46px;">
                                                    <div id="div_CompraEdicion">
                                                        <asp:DropDownList ID="ddlCompraEdicion" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                            Font-Bold="True" Width="84">
                                                        </asp:DropDownList>
                                                    </div>
                                                </td>
                                </tr>
                                </table>
                                </td>
                               
                                </tr>
                                <tr id="tdMayoristaEdicion" style = "display:none;" >
                                    <td style="font-weight: bold">
                                        Exclusivo
                                    </td>
                                         <td style="display: none">
                                                    <asp:TextBox ID="TextBox2" runat="server" Width="415px" Font-Names="Arial"
                                                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                                </td>
                                    <td colspan='5'>
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                               <td >
                                                        <asp:TextBox ID="txtExclusivoEdicion" runat="server" Width="76px" Font-Names="Arial" ForeColor="Blue"
                                                            Font-Bold="True" CssClass="Derecha"></asp:TextBox>
                                                    </td>
                                             
                                                                   <td>
                                <asp:CheckBox ID="chkBloqueoMayoristaEdicion" runat="server" Text="Bloqueo Mayorista"
                                    Font-Bold="True" />
                            </td>

                                <td>
                                <asp:CheckBox ID="chkBloqueoExclusivoEdicion" runat="server" Text="Bloqueo Exclusivo"
                                    Font-Bold="True" />
                            </td>
                                           
                                                <td style="padding-left: 11px;display:none;">
                                                    <asp:TextBox ID="txtCantidadEdicion" runat="server" Width="60px" Font-Names="Arial"
                                                        ForeColor="Blue" Font-Bold="True" CssClass="Derecha"></asp:TextBox>
                                                </td>
                                              
                                                    <td style="padding-left: 19px;display:none;">
                                                        <asp:TextBox ID="txtLimiteEdicion" runat="server" Width="60px" Font-Names="Arial" ForeColor="Blue"
                                                            Font-Bold="True"  CssClass="Derecha" Text="0"></asp:TextBox>
                                                    </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr style = "display:none;">
                                    <td style="font-weight: bold">
                                        ubicacion
                                    </td>
                                    <td colspan='5'>
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                
                                                <td style="font-weight: bold; padding-left: 5px;">
                                                    Stock Min
                                                </td>
                                                <td style="padding-left: 5px;">
                                                    <asp:TextBox ID="txtStockMinimoEdicion" runat="server" Width="60px" Font-Names="Arial"
                                                        ForeColor="Blue" Font-Bold="True" Text="0.00" CssClass="Derecha"></asp:TextBox>
                                                </td>
                                                <td style="padding-left: 5px; font-weight: bold">
                                                    Stock Max
                                                </td>
                                                <td style="padding-left: 5px;">
                                                    <asp:TextBox ID="txtStockMaximoEdicion" runat="server" Width="60px" Font-Names="Arial"
                                                        ForeColor="Blue" Font-Bold="True" Text="0.00" CssClass="Derecha"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                  <tr style="display:none;">
                                    <td style="font-weight: bold">
                                        Desc. Ingles
                                    </td>
                                    <td style="padding-left: 4px;">
                                        <asp:TextBox ID="txtDescripcionInglesEdicion" runat="server" Width="568px" Font-Names="Arial"
                                            ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr style="display:none;">
                                    <td style="font-weight: bold">
                                        Marca
                                    </td>
                                    <td colspan='5'>
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                            
                                              
                                                <td style="padding-left: 5px; font-weight: bold; display: none">
                                                    UM Venta
                                                </td>
                                                <td style="padding-left: 22px; font-weight: bold; display: none">
                                                    <div id="div_VentaEdicion">
                                                        <asp:DropDownList ID="ddlVentaEdicion" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                            Font-Bold="True" Width="78">
                                                        </asp:DropDownList>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr style="display: none;">
                                    <td style="font-weight: bold">
                                        Medida
                                    </td>
                                    <td colspan='5'>
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <asp:TextBox ID="txtMedidaEdicion" runat="server" Width="211px" Font-Names="Arial"
                                                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                                </td>
                                                <td style="font-weight: bold">
                                                    Posicion
                                                </td>
                                                <td style="padding-left: 15px;">
                                                    <asp:TextBox ID="txtPosicionEdicion" runat="server" Width="248px" Font-Names="Arial"
                                                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                                </td>
                                                <td style="font-weight: bold">
                                                    Modelo
                                                </td>
                                                <td style="padding-left: 21px;">
                                                    <asp:TextBox ID="txtModeloEdicion" runat="server" Width="248px" Font-Names="Arial"
                                                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                                </td>
                                                <td style="font-weight: bold">
                                                    Año
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtAñoEdicion" runat="server" Width="211px" Font-Names="Arial" ForeColor="Blue"
                                                        Font-Bold="True"></asp:TextBox>
                                                </td>
                                                <td style="padding-left: 25px; font-weight: bold">
                                                    Factor
                                                </td>
                                                <td style="padding-left: 13px;">
                                                    <asp:TextBox ID="txtFactorEdicion" runat="server" Width="74px" Font-Names="Arial"
                                                        ForeColor="Blue" Font-Bold="True" Text="0.00"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="linea-button">
                            <asp:Button ID="btnEdicion" runat="server" Text="Grabar" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                                Font-Names="Arial" Font-Bold="True" Width="120px" />
                        </div>
                    </div>
                </td>
                <td style="padding-left: 5px;display:none;">
                    <%--IMAGEN--%>
                    <div class="ui-jqgrid ui-widget ui-widget-content ui-corner-all" style="width: 550px">
                        <div class="ui-jqgrid-titlebar ui-widget-header ui-corner-top ui-helper-clearfix"
                            style="width: 550px">
                            IMAGEN DEL PRODUCTO</div>
                        <div>
                            <table cellpadding="0" cellspacing="0" class="form-inputs">
                                <tr>
                                    <td style="height: 290px" align="center">
                                        <%--<span style="padding-left:140px; padding-top:145px">Imagen del Artículo</span>--%>
                                        <span>
                                            <input id="hid_id_nombre_edit" type="hidden" />
                                            <input id="hid_id_logo_Edit" type="hidden" />
                                            <input id="hid_id_logo_Edit2" type="hidden" />
                                        </span>
                                        <div id="div_drop_Edit" style="padding-top: 5px;">
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </td>
            </tr>
        </table>
    </div>

    <%--VISUALIZACION DE IMAGENES--%>
      <div id="divVisualizarImagen" class="wrapper" style="display: none;">
        <table>
            <tr style="max-height: 100px;">
                <td>
                    <%--CAMPOS --%>
                    <div>
                        <table>
                            <tr>
                                <td style="font-weight: bold; width: 50px; text-align: right">
                                    Código
                                </td>
                                <td colspan='5'>
                                    <table cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="txtCodigoVisualizacion" runat="server" Width="150px" Font-Names="Arial"
                                                    ForeColor="Blue" Font-Bold="True" ReadOnly="true"></asp:TextBox>
                                            </td>
                                        
                                            <td style="font-weight: bold; width: 80px; text-align: right">
                                                Descripcion
                                            </td>
                                            <td style="padding-left: 5px;">
                                                <asp:TextBox ID="txtDescripcionVisualizacion" runat="server" Width="550px" Font-Names="Arial"
                                                    ForeColor="Blue" Font-Bold="True" ReadOnly="true"></asp:TextBox>
                                            </td>
                                          
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr style="display:none;">
                                <td style="font-weight: bold; width: 50px; text-align: right">
                                    Precio1
                                </td>
                                <td colspan='5'>
                                    <table cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td style="padding-left: 0px;">
                                                <asp:TextBox ID="txtPaisVisualizacion" runat="server" Width="100px" Font-Names="Arial"
                                                    ForeColor="Blue" Font-Bold="True" ReadOnly="true"></asp:TextBox>
                                            </td>
                                            <td style="font-weight: bold; width: 60px; text-align: right">
                                                Marca
                                            </td>
                                            <td style="padding-left: 5px;">
                                                <asp:TextBox ID="txtMarcaVisualizacion" runat="server" Width="100px" Font-Names="Arial"
                                                    ForeColor="Blue" Font-Bold="True" ReadOnly="true"></asp:TextBox>
                                            </td>
                                            <td style="font-weight: bold; width: 80px; text-align: right">
                                                Modelo
                                            </td>
                                            <td style="padding-left: 5px;">
                                                <asp:TextBox ID="txtModeloVisualizacion" runat="server" Width="280px" Font-Names="Arial"
                                                    ForeColor="Blue" Font-Bold="True" ReadOnly="true"></asp:TextBox>
                                            </td>
                                            <td style="font-weight: bold; width: 60px; text-align: right">
                                                Posicion
                                            </td>
                                            <td style="padding-left: 5px;">
                                                <asp:TextBox ID="txtPosicionVisualizacion" runat="server" Width="121px" Font-Names="Arial"
                                                    ForeColor="Blue" Font-Bold="True" ReadOnly="true"></asp:TextBox>
                                            </td>
                                            <td style="font-weight: bold; width: 50px; text-align: right">
                                                Año
                                            </td>
                                            <td style="padding-left: 5px;">
                                                <asp:TextBox ID="txtAnovisualizacion" runat="server" Width="50px" Font-Names="Arial"
                                                    ForeColor="Blue" Font-Bold="True" ReadOnly="true"></asp:TextBox>
                                            </td>
                                              <td style="font-weight: bold; width: 60px; text-align: right">
                                                Medida
                                            </td>
                                            <td style="padding-left: 5px;">
                                                <asp:TextBox ID="txtMedidaVisualizacion" runat="server" Width="230px" Font-Names="Arial"
                                                    ForeColor="Blue" Font-Bold="True" ReadOnly="true"></asp:TextBox>
                                            </td>
                                                <td style="font-weight: bold; width: 60px; text-align: right">
                                                Código 2
                                            </td>
                                            <td style="padding-left: 5px;">
                                                <asp:TextBox ID="txtCodigo2Visualizacion" runat="server" Width="100px" Font-Names="Arial"
                                                    ForeColor="Blue" Font-Bold="True" ReadOnly="true"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <ul id="luImagenes" class="ul-float">
                    </ul>
                </td>
            </tr>
        </table>
    </div>

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

    <%--PRODUCTOS RELACIONADOS--%>
    <div id="divProductosRelacionados" class="wrapper" style="display: none;">
        <div class="ui-jqgrid ui-widget ui-widget-content ui-corner-all" style="width: 876px;">
            <div class="ui-jqgrid-titlebar ui-widget-header ui-corner-top ui-helper-clearfix">
                DATOS PRODUCTOS
            </div>
            <div>
                <table cellpadding="0" cellspacing="0" class="form-inputs">
                    <tr>
                        <td style="font-weight: bold">
                            Codigo Principal
                        </td>
                        <td>
                            <asp:TextBox ID="txtCodigoArticuloPrincipal" runat="server" Width="150px" Font-Names="Arial"
                                ForeColor="Blue" Font-Bold="True" ReadOnly="true"></asp:TextBox>
                        </td>
                        <td style="font-weight: bold">
                            Producto Principal
                        </td>
                        <td>
                            <asp:TextBox ID="txtArticuloPrincipal" runat="server" Width="422px" Font-Names="Arial"
                                ForeColor="Blue" Font-Bold="True" ReadOnly="true"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="font-weight: bold;">
                            PRODUCTO RELACIONADO
                        </td>
                        <td colspan='3'>
                            <asp:TextBox ID="txtArticuloRelacionado" runat="server" Width="700px" Font-Names="Arial"
                                ForeColor="Blue" Font-Bold="True" ReadOnly="false"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="linea-button">
                <asp:Button ID="ImageButton1" runat="server" Text="Agregar" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                    Font-Names="Arial" Font-Bold="True" Width="120px" OnClientClick="F_AgregarArticulosRelacionados(); return false;" />
                <%--
                                    <asp:ImageButton ID="ImageButton1" runat="server" Width="15px" Font-Names="Adrial" Text="Agregar" ForeColor="Blue"
                                                    Font-Bold="true" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only" ImageUrl="~/Asset/images/ok.gif"
                                                    ToolTip="Agregar" ></asp:ImageButton>--%>
            </div>
        </div>
        <table>
            <tr style="max-height: 100px;">
                <td>
                    <%--CAMPOS --%>
                    <div>
                        <table>
                        </table>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <ul id="Ul1" class="ul-float">
                    </ul>
                </td>
            </tr>
        </table>
        <div id="divProductosRelacionadosListado">
            <table>
                <tr>
                    <td>
                        Código
                    </td>
                    <td>
                        Descripción
                    </td>
                    <td>
                        UM
                    </td>
                </tr>
            </table>
        </div>
        <div id="div_DetalleProducto" style="display: none;">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td style="padding-top: 10px; font-weight: bold">
                        PRODUCTO
                    </td>
                    <td style="padding-top: 10px;">
                        <asp:TextBox ID="txtProductoDetalle" runat="server" Width="500px" Font-Names="Arial"
                            ForeColor="Blue" Font-Bold="True" ReadOnly="True"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="padding-top: 5px; font-weight: bold">
                        MODELO
                    </td>
                    <td style="padding-top: 5px;">
                        <asp:TextBox ID="txtModeloDetalle" runat="server" Width="500px" Font-Names="Arial"
                            ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="padding-top: 5px; font-weight: bold">
                        AÑO
                    </td>
                    <td style="padding-top: 5px;">
                        <asp:TextBox ID="txtAñoDetalle" runat="server" Width="500px" Font-Names="Arial" ForeColor="Blue"
                            Font-Bold="True"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="padding-top: 5px; font-weight: bold">
                        Motor
                    </td>
                    <td style="padding-top: 5px;">
                        <asp:TextBox ID="txtMotorDetalle" runat="server" Width="500px" Font-Names="Arial"
                            ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="padding-top: 5px; font-weight: bold">
                        Caja Cambio
                    </td>
                    <td style="padding-top: 5px;">
                        <asp:TextBox ID="txtCajaCambio" runat="server" Width="500px" Font-Names="Arial" ForeColor="Blue"
                            Font-Bold="True"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="padding-top: 5px; font-weight: bold">
                        Transmision
                    </td>
                    <td style="padding-top: 5px;">
                        <asp:TextBox ID="txtTransmision" runat="server" Width="500px" Font-Names="Arial"
                            ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="padding-top: 5px; font-weight: bold">
                        Filtro
                    </td>
                    <td style="padding-top: 5px;">
                        <asp:TextBox ID="txtFiltro" runat="server" Width="500px" Font-Names="Arial" ForeColor="Blue"
                            Font-Bold="True"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right" colspan="2">
                        <asp:Button ID="btnGrabarDetalle" runat="server" Text="GRABAR" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                            Font-Names="Arial" Font-Bold="True" Width="120" />
                    </td>
                </tr>
                <tr>
                    <td style="padding-top: 5px;" colspan="2">
                        <div id="div_ProductoDetalle">
                            <asp:GridView ID="grvProductoDetalle" runat="server" AutoGenerateColumns="False"
                                border="0" CellPadding="0" CellSpacing="1" CssClass="GridView" GridLines="None"
                                Width="860px">
                                <Columns>
                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:ImageButton runat="server" ID="imgAnularDocumento" ImageUrl="~/Asset/images/EliminarBtn.png"
                                                ToolTip="ELIMINAR DETALLE PRODUCTO" OnClientClick="F_EliminarDetalleProducto(this); return false;" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:ImageButton runat="server" ID="imgEditarRegistro" ImageUrl="../Asset/images/btnEdit.gif"
                                                ToolTip="EDITAR DETALLE PRODUCTO" OnClientClick="F_EditarDetalleProducto(this); return false;" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Linea" HeaderStyle-HorizontalAlign="Center">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblLinea" Text='<%# Bind("Linea") %>'></asp:Label>
                                            <asp:HiddenField ID="hfCodProductoModelo" runat="server" Value='<%# Bind("CodProductoModelo") %>' />
                                            <asp:HiddenField ID="hfCodModelo" runat="server" Value='<%# Bind("CodModeloVehiculo") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Modelo" HeaderStyle-HorizontalAlign="Center">
                                        <ItemStyle HorizontalAlign="left" />
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblModelo" Text='<%# Bind("Modelo") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Año" HeaderStyle-HorizontalAlign="Center">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblAño" Text='<%# Bind("Año") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Motor" HeaderStyle-HorizontalAlign="Center">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblMotor" Text='<%# Bind("Motor") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Caja Cambio" HeaderStyle-HorizontalAlign="Center">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblCajaCambio" Text='<%# Bind("CajaCambio") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Transmision" HeaderStyle-HorizontalAlign="Center">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblTransmision" Text='<%# Bind("Transmision") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Filtro" HeaderStyle-HorizontalAlign="Center">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblFiltro" Text='<%# Bind("Filtro") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
        <div id="div_DetalleProductoEditar" style="display: none;">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td style="padding-top: 10px; font-weight: bold">
                        PRODUCTO
                    </td>
                    <td style="padding-top: 10px;">
                        <asp:TextBox ID="txtProductoDetalleEdicion" runat="server" Width="370px" Font-Names="Arial"
                            ForeColor="Blue" Font-Bold="True" ReadOnly="True"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="padding-top: 5px; font-weight: bold">
                        MODELO
                    </td>
                    <td style="padding-top: 5px;">
                        <asp:TextBox ID="txtModeloDetalleEdicion" runat="server" Width="370px" Font-Names="Arial"
                            ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="padding-top: 5px; font-weight: bold">
                        AÑO
                    </td>
                    <td style="padding-top: 5px;">
                        <asp:TextBox ID="txtAñoDetalleEdicion" runat="server" Width="370px" Font-Names="Arial"
                            ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="padding-top: 5px; font-weight: bold">
                        Motor
                    </td>
                    <td style="padding-top: 5px;">
                        <asp:TextBox ID="txtMotorDetalleEdicion" runat="server" Width="370px" Font-Names="Arial"
                            ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="padding-top: 5px; font-weight: bold">
                        Caja Cambio
                    </td>
                    <td style="padding-top: 5px;">
                        <asp:TextBox ID="txtCajaCambioEdicion" runat="server" Width="370px" Font-Names="Arial"
                            ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="padding-top: 5px; font-weight: bold">
                        Transmision
                    </td>
                    <td style="padding-top: 5px;">
                        <asp:TextBox ID="txtTransmisionEdicion" runat="server" Width="370px" Font-Names="Arial"
                            ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="padding-top: 5px; font-weight: bold">
                        Filtro
                    </td>
                    <td style="padding-top: 5px;">
                        <asp:TextBox ID="txtFiltroEdicion" runat="server" Width="370px" Font-Names="Arial"
                            ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="padding-top: 10px;" align="right" colspan="2">
                        <asp:Button ID="btnGrabarDetalleEdicion" runat="server" Text="GRABAR" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                            Font-Names="Arial" Font-Bold="True" Width="120" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <input id="hfCodCtaCte" type="hidden" value="0" />
    <input id="hfCodCtaCteConsulta" type="hidden" value="0" />
    <input id="hfCodigoTemporal" type="hidden" value="0" />
    <input id="hfCodProducto" type="hidden" value="0" />
    <input id="hfMoneda" type="hidden" value="0" />
    <input id="hfCodSede" type="hidden" value="0" />
    <input id="hfCodigoArticuloPrincipal" type="hidden" value="0" />
    <input id="hfCodigoArticuloRelacionado" type="hidden" value="0" />
    <input id="hfCodModeloDetalle" type="hidden" value="0" />
    <input id="hfCodModeloDetalleEdicion" type="hidden" value="0" />
    <input id="hfCodProductoModelo" type="hidden" value="0" />
    <input id="hfCodLinea" type="hidden" value="0" />
    <input id="hfCodLineaEdicion" type="hidden" value="0" />
    <input id="hfCodMarca" type="hidden" value="0" />
    <input id="hfCodMarcaEdicion" type="hidden" value="0" />
</asp:Content>
