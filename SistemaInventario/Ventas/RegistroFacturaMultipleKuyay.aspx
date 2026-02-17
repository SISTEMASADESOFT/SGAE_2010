<%@ Page Title="REG. VENTA" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"  CodeBehind="RegistroFacturaMultipleKuyay.aspx.cs" Inherits="SistemaInventario.Ventas.RegistroFacturaMultipleKuyay" %>
  
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="../Asset/js/jquery-1.10.2.js" type="text/javascript"></script>
    <script src="../Asset/js/jquery-ui-1.10.4.custom.min.js" type="text/javascript"></script>
    <script src="../Asset/js/jquery.timers.js" type="text/javascript"></script>
    <script src="../Asset/js/jq-ui/1.10.2/development-bundle/ui/i18n/jquery.ui.datepicker-es.js" type="text/javascript"></script>       
    <script src="../Asset/js/autoNumeric-1.4.3.js" type="text/javascript"></script>
    <script src="../Asset/js/js.js" type="text/javascript"></script>
    <script src="../Scripts/alertify.min.js" type="text/javascript"></script>
    <script src="../Scripts/utilitarios.js" type="text/javascript" language="javascript" charset="UTF-8"></script>       
    <script src="../Scripts/inputatajos/kibo.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript" src="RegistroFacturaMultipleKuyay.js" charset="UTF-8"></script>       
    <link href="../Asset/css/Redmond/jquery-ui-1.10.4.custom.min.css" rel="stylesheet"  type="text/css" />      
    <link href="../Asset/css/style.css" rel="stylesheet" type="text/css" />
    <link href="../Asset/css/alertify.core.css" rel="stylesheet" type="text/css" />
    <link href="../Asset/css/alertify.default.css" rel="stylesheet" type="text/css" />
    <link href="../Asset/css/sss.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table>
        <tr valign="top">
            <td style="width: 1100px" valign="top">
                <div class="titulo" style="width: 1045px">
                    <asp:Label ID="lbTipoDocumento" runat="server" Text="Factura" Font-Bold="False" Font-Size="Large"
                        Visible="false"></asp:Label>
                    <asp:Label ID="Label3" runat="server" Text="REGISTRO DE DOCUMENTO DE VENTA" Font-Bold="False"
                        Font-Size="Large"></asp:Label>
                </div>
                <div id="divTabs" style="width: 1045px">
                    <ul>
                        <li id="liRegistro"><a href="#tabRegistro">Registro</a></li>
                        <li id="liConsulta"><a href="#tabConsulta" onclick="getContentTab();">Consulta</a></li>
                    </ul>
                    <div id="tabRegistro">
                        <div class="ui-jqgrid ui-widget ui-widget-content ui-corner-all">
                            <div class="ui-jqgrid-titlebar ui-widget-header ui-corner-top ui-helper-clearfix">
                                Datos de Factura
                            </div>
                            <div>
                                <table cellpadding="0" cellspacing="0" class="form-inputs" width="750">
                                    <tr>
                                        <td style="font-weight: bold">
                                            Tipo
                                        </td>
                                        <td>
                                            <table cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td>
                                                        <div id="div_TipoDoc">
                                                            <asp:DropDownList ID="ddlTipoDoc" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                                Font-Bold="True" Width="85px">
                                                                <asp:ListItem Value="1">FACTURA</asp:ListItem>
                                                                <asp:ListItem Value="2">BOLETA</asp:ListItem>
                                                                <asp:ListItem Value="15">COTIZACION</asp:ListItem>
                                                                <asp:ListItem Value="16">NOTA DE PEDIDO</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                    </td>
                                                    <td style="font-weight: bold">
                                                        Cliente
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtNroRuc" runat="server" Width="70px" Font-Names="Arial" ForeColor="Blue"
                                                            Font-Bold="True" MaxLength="11"  onblur="F_BUSCARDNIONBLURENTER(MainContent_txtNroRuc); return false;"></asp:TextBox>
                                                    </td>
                                                    <td id="td_loading" style="font-weight: bold; padding-left: 5px; display: none">
                                                        <img src="../Asset/images/loading.gif" />
                                                    </td>
                                                    <td id="div_Cliente">
                                                        <asp:TextBox ID="txtCliente" runat="server" Width="310px" Font-Names="Arial" ForeColor="Blue"
                                                            Font-Bold="True"></asp:TextBox>
                                                    </td>
                                                     <td style="font-weight: bold">
                                                        Moneda
                                                    </td>
                                                    <td style="padding-left: 4px">
                                                        <div id="div_moneda">
                                                            <asp:DropDownList ID="ddlMoneda" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                                Font-Bold="True" Width="85" BackColor="#FFFF99">
                                                            </asp:DropDownList>
                                                        </div>
                                                    </td>
                                                    <td id="tdftNormal">
                                                        <table>
                                                            <tr>
                                                                <td style="font-weight: bold">
                                                                    Serie
                                                                </td>
                                                                <td id="tdddlSerie">
                                                                    <div id="div_serie">
                                                                        <asp:DropDownList ID="ddlSerie" Width="55" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                                            Font-Bold="True">
                                                                        </asp:DropDownList>
                                                                    </div>
                                                                </td>
                                                                <td id="tdtxtNumero">
                                                                    <asp:TextBox ID="txtNumero" runat="server" Width="48" Font-Names="Arial" ForeColor="Blue"
                                                                        Font-Bold="True"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td style="font-weight: bold;">
                                                        Igv (%)
                                                    </td>
                                                    <td>
                                                        <div id="div_igv">
                                                            <asp:DropDownList ID="ddlIgv" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                                Font-Bold="True" Width="53">
                                                            </asp:DropDownList>
                                                        </div>
                                                    </td>   
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="font-weight: bold">
                                            Direccion
                                        </td>
                                        <td>
                                            <table cellpadding="0" cellspacing="0">
                                                <tr>
                                                     <td>                                  
                                                         <div id="Div_direccion">
                                                            <asp:DropDownList ID="ddldireccionNueva" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                                Font-Bold="True" Width="495" Font-Size="Small">
                                                            </asp:DropDownList>
                                                        </div>
                                                      </td>
                                                         <td>
                                <asp:ImageButton runat="server" ID="imgDireccion" ImageUrl="../Asset/images/add_small.png"
                                    ToolTip="DIRECCION" OnClientClick="F_DireccionesTemporal(hfCodigoTemporal,hfCodProvincia,hfCodDistrito,hfCodDepartamento,MainContent_txtDireccionMultiple,MainContent_txtDistritoMultiple,1,0); return false;" />
                                                         </td>      
                                                           <td style="font-weight: bold; padding-left: 8PX;">
                                                        SubTotal
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtSubTotal" runat="server" Width="80px" Font-Names="Arial" ForeColor="Blue"
                                                            CssClass="Derecha" Font-Bold="True" ReadOnly="True" Text="0.00"></asp:TextBox>
                                                    </td>
                                                    <td style="font-weight: bold; padding-left: 1px">
                                                        Igv
                                                    </td>
                                                    <td style="padding-left: 23PX;">
                                                        <asp:TextBox ID="txtIgv" runat="server" Width="80px" Font-Names="Arial" ForeColor="Blue"
                                                            CssClass="Derecha" Font-Bold="True" ReadOnly="True" Text="0.00"></asp:TextBox>
                                                    </td>
                                                    <td style="font-weight: bold">
                                                        total
                                                    </td>
                                                    <td style="padding-left: 7PX;">
                                                        <asp:TextBox ID="txtTotal" runat="server" Width="80px" Font-Names="Arial" ForeColor="Blue"
                                                            CssClass="Derecha" Font-Bold="True" ReadOnly="True" Text="0.00"></asp:TextBox>
                                                    </td>  
                                                  
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="font-weight: bold">
                                            Emision
                                        </td>
                                        <td>
                                            <table cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td>
                                                        <asp:TextBox ID="txtEmision" runat="server" Width="51px" CssClass="Jq-ui-dtp" Font-Names="Arial"
                                                            ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                                    </td>
                                                    <td style="font-weight: bold;">
                                                        cond PAGO
                                                    </td>
                                                    <td>
                                                        <div id="div_formapago">
                                                            <asp:DropDownList ID="ddlFormaPago" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                                Font-Bold="True" Width="85">
                                                            </asp:DropDownList>
                                                        </div>
                                                    </td>
                                                    <td style="font-weight: bold;">
                                                        Vencimiento
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtVencimiento" runat="server" Width="51px" Font-Names="Arial" ForeColor="Blue"
                                                            Font-Bold="True" ReadOnly="True"></asp:TextBox>
                                                    </td>
                                                       <td style="font-weight: bold;">
                                                        OP
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtNroOperacion" runat="server" Width="61px" Font-Names="Arial"
                                                            ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                                    </td>
                                                    <td style="font-weight: bold;">
                                                        T.C.
                                                    </td>
                                                    <td style="font-weight: bold;">
                                                        <asp:Label ID="lblTC" runat="server" Text="Label" Font-Bold="True"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:CheckBox runat="server" ID="chkConIgvMaestro" Text="C/Igv" onclick="F_ValidarCheckConIgvMaestro(this.id);"
                                                            Checked="True" Font-Bold="True" />
                                                    </td>
                                                    <td>
                                                        <asp:CheckBox runat="server" ID="chkSinIgvMaestro" Text="S/Igv" onclick="F_ValidarCheckSinIgvMaestro(this.id);"
                                                            Font-Bold="True" />
                                                    </td>
                                              
                                                      <td style="font-weight: bold; display:none">
                                                        Placa
                                                    </td>
                                                    <td id="div_Placa1" style="font-weight: bold; display:none">
                                                        <asp:TextBox ID="txtPlaca1" runat="server" Width="80px" Font-Names="Arial" ForeColor="Blue"
                                                            Font-Bold="True"></asp:TextBox>
                                                    </td>
                                                    <td style="font-weight: bold;display:none">
                                                        KM
                                                    </td>
                                                    <td id="Td1" style="padding-left: 24px; display:none">
                                                        <asp:TextBox ID="txtKM" runat="server" Width="80px" Font-Names="Arial" ForeColor="Blue"
                                                            Font-Bold="True"></asp:TextBox>
                                                    </td>

                                                      <td style="font-weight: bold">
                                                        OC
                                                    </td>
                                                    <td style="padding-left: 24px;">
                                                        <asp:TextBox ID="txtNroOC" runat="server" Width="80px" Font-Names="Arial" ForeColor="Blue"
                                                            Font-Bold="True"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="font-weight: bold">
                                            VENDEDOR
                                        </td>
                                        <td>
                                            <table cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td>
                                                        <div id="div_Vendedor">
                                                            <asp:DropDownList ID="ddlVendedor" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                                Font-Bold="True" Width="209">
                                                            </asp:DropDownList>
                                                        </div>
                                                    </td>
                                                     <td>
                                                        <asp:CheckBox ID="chkConCodigo" runat="server" Text="CON CODIGO" Font-Bold="True" />
                                                    </td>

                                                        <td style="font-weight: bold;">
                                                        <asp:CheckBox ID="chkImpresion" runat="server" Text="Impresion" Font-Bold="True" Checked="True" />
                                                    </td>

                                                     <td style="font-weight: bold">
                                                        Cotizacion
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtCodCotizacion" CssClass="Derecha" runat="server" Width="80px"
                                                            Font-Names="Arial" ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                                    </td>

                                                       
                                             
                                                  
                                                    <td style="font-weight: bold;display:none;">
                                                        <asp:CheckBox runat="server" ID="chkComisionable" Text="Comision" Font-Bold="True" />
                                                    </td>
                                                
 
                                                    
                                                    <td style="display:none;">
                                                        <asp:TextBox ID="txtCorreo" runat="server" Width="152px" Font-Names="Arial" ForeColor="Blue"
                                                            Font-Bold="True" ReadOnly="False"></asp:TextBox>
                                                    </td>
                                                     <td style="font-weight: bold;display:none;">
                                                        GRA
                                                    </td>
                                                    <td id="Td2" style="padding-left: 11px;display:none;">
                                                        <asp:TextBox ID="txtGratuito" runat="server" Width="80px" Font-Names="Arial" ForeColor="Blue"
                                                         CssClass="Derecha"   Font-Bold="True"></asp:TextBox>
                                                    </td>
                                                    
                                                    <td style="display: none">
                                                        <asp:TextBox ID="txtAtencion" runat="server" Width="225px" Font-Names="Arial" ForeColor="Blue"
                                                            Font-Bold="True"></asp:TextBox>
                                                    </td>
                                                    <td style="font-weight: bold; display: none">
                                                        Referencia
                                                    </td>
                                                    <td style="display: none">
                                                        <asp:TextBox ID="txtReferencia" runat="server" Width="197px" Font-Names="Arial" ForeColor="Blue"
                                                            Font-Bold="True"></asp:TextBox>
                                                    </td>
                                                    <td id="div_lblPlaca1" style="font-weight: bold; display: none;">
                                                        Vehiculos
                                                    </td>
                                                    <td id="div_Placa2">
                                                        <asp:TextBox ID="txtPlaca2" runat="server" Width="50px" Font-Names="Arial" ForeColor="Blue"
                                                            Font-Bold="True"></asp:TextBox>
                                                    </td>
                                                    <td id="div_Placa3">
                                                        <asp:TextBox ID="txtPlaca3" runat="server" Width="50px" Font-Names="Arial" ForeColor="Blue"
                                                            Font-Bold="True"></asp:TextBox>
                                                    </td>
                                                    <td id="div_Placa4">
                                                        <asp:TextBox ID="txtPlaca4" runat="server" Width="50px" Font-Names="Arial" ForeColor="Blue"
                                                            Font-Bold="True"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr style = "display:none;">
                                     <td style="font-weight: bold">
                                                        Observacion
                                                    </td>

                                                       <td style="padding-left: 4PX;">
                                                        <asp:TextBox ID="txtObservacion" runat="server" Width="920px" Font-Names="Arial" ForeColor="Blue"
                                                            Font-Bold="True" ReadOnly="False"></asp:TextBox>
                                                    </td>
                                    </tr>
                                    <tr style = "display:none;">
                                         <td style="font-weight: bold">
                                            OBS
                                        </td>
                                        <td>
                                            <table cellpadding="0" cellspacing="0">
                                                <tr>
                                                 
                                                  
                                                    <td style="display: none">
                                                        <asp:TextBox ID="txtCotizacion" runat="server" Width="45" Font-Names="Arial" ForeColor="Blue"
                                                            Font-Bold="True" CssClass="Derecha"></asp:TextBox>
                                                    </td>
                                                    
                                                      <td style="font-weight: bold;display: none">
                                                      <label id="lblComisionTarjeta"></label>  
                                                    </td>
                                                    <td  style="display: none">
                                                        <asp:TextBox ID="txtComisionTarjeta" CssClass="Derecha" runat="server" Width="74px"
                                                            Font-Names="Arial" ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                                    </td>

                                                    <td>
                                                        <asp:CheckBox ID="chkNotaVentaANTIGUA" runat="server" Text="ANTIGUO SUNAT"
                                                            Font-Bold="True" style = "display:none;" />
                                                    </td>
                                                    <td>
                                                        <asp:CheckBox ID="chkFacturaAntigua" runat="server" Text="ANTIGUO NO ENVIA SUNAT"
                                                            Font-Bold="True" style="display:none;" />
                                                    </td>
                                                  
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                             <!--aca empieza acordion-->
                             <div id="accordion">
                                <h3>
                                    DATOS DE LA GUIA</h3>
                <div class="ui-jqdialog-content" id="div_CuerpoGuia" style="display: none">
                  <table cellpadding="0" cellspacing="0" class="form-inputs">
                                            <tr>
                                                <td>
                                                    <asp:CheckBox ID="chkGuia" runat="server" Text="Guia Serie" Font-Bold="True" />
                                                </td>
                                                <td>
                                                    <table cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td>
                                                                <div id="div_serieguia">
                                                                    <asp:DropDownList ID="ddlSerieGuia" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                                        Font-Bold="True">
                                                                    </asp:DropDownList>
                                                                </div>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtNumeroGuia" runat="server" Width="50" Font-Names="Arial" ForeColor="Blue"
                                                                    Font-Bold="True"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <div id="div_TipoTransportista">
                                                                    <asp:DropDownList ID="ddlTipoTransportista" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                                        Font-Bold="True" >
                                                                    </asp:DropDownList>
                                                                </div>
                                                            </td>
                                                            <td style="font-weight: bold; padding-left: 52px;">
                                                                Traslado
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtFechaTraslado" runat="server" Width="56px" CssClass="Jq-ui-dtp"
                                                                    Font-Names="Arial" ForeColor="Blue" Font-Bold="True" ReadOnly="True"></asp:TextBox>
                                                            </td>
                                                         <td style="font-weight: bold;padding-left:7px; color: #FF0000; font-size: small;">
                                                                Destino
                                                            </td>
                                                                  <td  style="padding-left:9px;">

                                                               <div id="Div_DireccionDestino">
                                                               <asp:DropDownList ID="ddldireccionNuevaDestino" runat="server" Font-Names="Arial" ForeColor="Red"
                                                                 Font-Bold="True" Width="430" Font-Size="Small">
                                                                </asp:DropDownList>
                                                                 </div>
                                                                  </td>
                                                                  <td>
                                                                  <asp:ImageButton runat="server" ID="ImageButton1" ImageUrl="../Asset/images/add_small.png"
                                                                  ToolTip="DIRECCION" OnClientClick="F_DireccionesTemporal(hfCodigoTemporal,hfCodProvincia,hfCodDistrito,hfCodDepartamento,MainContent_txtDireccionMultiple,MainContent_txtDistritoMultiple,2,0); return false;" />
                                                                   </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                           <tr>
                                                <td style="font-weight: bold">
                                                    Transportista
                                                </td>
                                                <td>
                                                    <table cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td>
                                                                <asp:TextBox ID="txtNroRucTransportista" runat="server" Width="70px" Font-Names="Arial"
                                                                    ForeColor="Blue" Font-Bold="True" MaxLength="11" onblur="F_ValidaRucTransportista(); return false;"></asp:TextBox>
                                                            </td>
                                                            <td id="td_loadingTransportista" style="font-weight: bold; padding-left: 5px; display: none">
                                                                <img src="../Asset/images/loading.gif" />
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtTransportista" runat="server" Width="271" Font-Names="Arial"
                                                                    ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                                            </td>
                                                            <td style="font-weight: bold;padding-left: 7px;">
                                                                Direccion
                                                            </td>
                                                             <td style="padding-left: 10px;">
                                  
                                         <div id="Div_DireccionTransportista">
                                                            <asp:DropDownList ID="ddldireccionNuevaTransportista" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                                Font-Bold="True" Width="430" Font-Size="Small">
                                                            </asp:DropDownList>
                                                        </div>
                                                            </td>
                                                             <td>
                                <asp:ImageButton runat="server" ID="ImageButton2" ImageUrl="../Asset/images/add_small.png"
                                    ToolTip="DIRECCION" OnClientClick="F_DireccionesTemporal(hfCodigoTemporal,hfCodProvincia,hfCodDistrito,hfCodDepartamento,MainContent_txtDireccionMultiple,MainContent_txtDistritoMultiple,3,1); return false;" />
                                                            </td>
                                                            <td style="font-weight: bold; display: none">
                                                                ACUENTA
                                                            </td>
                                                            <td style="display: none">
                                                                <asp:TextBox ID="txtAcuenta" runat="server" Width="90px" Font-Names="Arial" ForeColor="Blue"
                                                                    Font-Bold="True" CssClass="Derecha" ReadOnly="True" Text="0.00"></asp:TextBox>
                                                            </td>
                                                            <td style="font-weight: bold; display: none">
                                                                ACUENTA NV
                                                            </td>
                                                            <td style="display: none">
                                                                <asp:TextBox ID="txtAcuentaNV" runat="server" Width="90px" Font-Names="Arial" ForeColor="Blue"
                                                                    Font-Bold="True" CssClass="Derecha" ReadOnly="True" Text="0.00"></asp:TextBox>
                                                            </td>
                                                            <td style="display: none" id="td3">
                                                                <table>
                                                                    <tr>
                                                                        <td style="font-weight: bold;">
                                                                            Serie
                                                                        </td>
                                                                        <td id="td4">
                                                                            <asp:TextBox ID="TextBox1" runat="server" Width="25px" ForeColor="Blue" Font-Names="Arial"
                                                                                Font-Bold="True"></asp:TextBox>
                                                                        </td>
                                                                        <td style="font-weight: bold;">
                                                                            Num.
                                                                        </td>
                                                                        <td id="td5">
                                                                            <asp:TextBox ID="TextBox2" runat="server" Width="42px" ForeColor="Blue" Font-Names="Arial"
                                                                                Font-Bold="True"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                            <td style="font-weight: bold">
                                                        Nro Bultos
                                                    </td>
                                                    
                                                
                                                <td>
                                                    <table cellpadding="0" cellspacing="0">
                                                        <tr>
                                               
                                                            <td>
                                                                <asp:TextBox ID="txtNuBultos" runat="server" Width="40" Font-Names="Arial" ForeColor="Blue"
                                                                    Font-Bold="True" CssClass="Derecha"></asp:TextBox>
                                                            </td>
                                                            <td style="font-weight: bold;padding-left: 175px">
                                                                Peso 
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtPeso" runat="server" Width="45" Font-Names="Arial" ForeColor="Blue"
                                                                    Font-Bold="True" CssClass="Derecha"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <div id="div_codunidadpeso">
                                                                    <asp:DropDownList ID="ddlcodunidadpeso" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                                        Font-Bold="True">
                                                                    </asp:DropDownList>
                                                                </div>
                                                            </td>
                                               
                                                         <td style="font-weight: bold;padding-left: 7px">
                                                    Conductor
                                                </td>
                                                            <td style="">
                                                                <asp:TextBox ID="txtConductorDNI" runat="server" Width="80" Font-Names="Arial" ForeColor="Blue"
                                                                    Font-Bold="True" onblur="F_ValidaRucDniConductor(); return false;" ></asp:TextBox>
                                                            </td>
                                                            <td style=" ">
                                                                <asp:TextBox ID="txtConductorRazonSocial" runat="server" Width="338px" Font-Names="Arial"
                                                                    ForeColor="Blue" Font-Bold="True" placeholder="NOMBRE CONDUCTOR"></asp:TextBox>
                                                            </td>
                                                      
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                            <td style="font-weight: bold">
                                                                 observacion
                                                            </td>
                                                            
                                                <td>
                                                    <table cellpadding="0" cellspacing="0">
                                                        <tr>
                                                         <td>
                                                                <asp:TextBox ID="txtObservacionGuia" runat="server" Width="350" Font-Names="Arial" ForeColor="Blue"
                                                                    Font-Bold="True" ></asp:TextBox>
                                                            </td>
                                                             <td style="font-weight: bold;padding-left: 7px;">
                                                    Placa
                                                </td>
                                                            <td style="padding-left: 31px;">
                                                                <asp:TextBox ID="txtPlacaTraslado" runat="server" Width="65" Font-Names="Arial" ForeColor="Blue"
                                                                    Font-Bold="True"></asp:TextBox>
                                                            </td>
                                                            <td style="font-weight: bold">
                                                                Marca
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtMarcaGuia" runat="server" Width="148" Font-Names="Arial" ForeColor="Blue"
                                                                    Font-Bold="True"></asp:TextBox>
                                                            </td>
                                                              <td style="font-weight: bold">
                                                                Licencia
                                                            </td>
                                                             <td style="">
                                                                <asp:TextBox ID="txtLicenciaGuia" runat="server" Width="105" Font-Names="Arial" ForeColor="Blue"
                                                                    Font-Bold="True"></asp:TextBox>
                                                            </td>   
                                                        </tr>
                                                    </table>
                                                </td>                                               
                                            </tr>                                  
                                        </table>
                </div>
                 </div>
                            <div class="linea-button">
                              <asp:Button ID="btnTraerGuiaRemision" runat="server" Text="GuiaRemision" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                                    Font-Names="Arial" Font-Bold="True" Width="120"  />
                                <asp:Button ID="btnListarCotizaciones" runat="server" Text="Listar Cotiz." class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                                    Font-Names="Arial" Font-Bold="True" Width="120" />
                                <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                                    Font-Names="Arial" Font-Bold="True" Width="120" Style="display: none;" />
                                <asp:Button ID="btnNuevo" runat="server" Text="Limpiar (F1)" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                                    Font-Names="Arial" Font-Bold="True" Width="120" />
                                <asp:Button ID="btnAgregarProducto" runat="server" Text="Agregar (F2)" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                                    Font-Names="Arial" Font-Bold="True" Width="120" />
                                <asp:Button ID="btnNotaVenta" runat="server" Text="PROFORMA (F3)" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                                    Font-Names="Arial" Font-Bold="True" Width="120" Visible="false" />
                                <asp:Button ID="btnCotizacion"  Visible ="false" runat="server" Text="Cotizaciones (F4)" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                                    Font-Names="Arial" Font-Bold="True" Width="120" />
                                <asp:Button ID="btnEliminar" runat="server" Text="Eliminar (F5)" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                                    Font-Names="Arial" Font-Bold="True" Width="120" />
                                <asp:Button ID="btnGrabar" runat="server" Text="Grabar (F6)" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
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
                                        <label id="lblCantidadRegistro"></label>                                      
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div id="div_grvDetalleArticulo">
                            <asp:GridView ID="grvDetalleArticulo" runat="server" AutoGenerateColumns="False"
                                border="0" CellPadding="0" CellSpacing="1" CssClass="GridView" GridLines="None"
                                Width="1018px" >
                                <Columns>
                                    <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center">
                         <HeaderTemplate>
                                                                <asp:CheckBox ID="checkAll" runat="server" onclick="F_Chequear_Detalle_Todos(this);" />
                                                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox runat="server" ID="chkEliminar" CssClass="chkDelete" Text="" />
                            </ItemTemplate>
                        </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Codigo" HeaderStyle-HorizontalAlign="Center">
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:HyperLink runat="server" ID="lblCodigo" Font-Underline="true" ForeColor="Blue" 
                                                        Style="cursor: hand" Text='<%# Bind("CodigoProducto") %>' onclick="F_Gratuito(this.id); return false;">
                                                    </asp:HyperLink>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Descripcion" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:TextBox runat="server" ID="txtDescripcion" Font-Bold="true" CssClass="ccsestilo"
                                                Width="480px" Font-Names="Arial" ForeColor="Blue" Text='<%# Bind("Producto") %>'
                                                onblur="F_ActualizarDescripcion(this.id); return false;"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Cantidad" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:TextBox runat="server" ID="txtCantidad" Width="75px" Font-Bold="true" Style="text-align: center;"
                                                CssClass="ccsestilo" Font-Names="Arial" ForeColor="Blue" Text='<%# Bind("Cantidad") %>'
                                                onblur="F_ActualizarCantidad(this.id); return false;"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField> 
                                                                   
                                      <asp:TemplateField HeaderText="UM">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblUM" Text='<%# Bind("UM") %>'></asp:Label>                                         
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Precio" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:TextBox runat="server" ID="txtPrecio" Width="75px" Font-Bold="true" Style="text-align: center;"
                                                CssClass="ccsestilo" Font-Names="Arial" ForeColor="Blue" Text='<%# Bind("Precio") %>'
                                                onblur="F_ActualizarPrecio(this.id); return false;"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Importe">
                                        <ItemStyle HorizontalAlign="Right" />
                                        <ItemTemplate>
                                             <asp:HyperLink runat="server" ID="lblimporte" Font-Underline="true" ForeColor="Blue"
                                                Style="cursor: hand" Text='<%# Bind("Importe") %>' CssClass="detallesart"
                                                ToolTip="MOTOR" onclick="F_AgregarMotor(this.id); return false;">
                                            </asp:HyperLink>                                       
                                            <asp:HiddenField ID="hfcodarticulo" runat="server" Value='<%# Bind("CodArticulo") %>' />
                                            <asp:HiddenField ID="hfCodDetalleOC" runat="server" Value='<%# Bind("CodDetalleOC") %>' />
                                            <asp:HiddenField ID="hfCantidad" runat="server" Value='<%# Bind("Cantidad") %>' />
                                            <asp:HiddenField ID="hfPrecio" runat="server" Value='<%# Bind("Precio") %>' />
                                            <asp:HiddenField ID="hfDescripcion" runat="server" Value='<%# Bind("Producto") %>' />
                                            <asp:HiddenField ID="hfCodTipoDoc" runat="server" Value='<%# Bind("CodTipoDoc") %>' />
                                            <asp:HiddenField ID="hfP1" runat="server" Value='<%# Bind("P1") %>' />
                                            <asp:HiddenField ID="hfP2" runat="server" Value='<%# Bind("P2") %>' />
                                            <asp:HiddenField ID="hfP3" runat="server" Value='<%# Bind("P3") %>' />
                                            <asp:HiddenField ID="hfStock" runat="server" Value='<%# Bind("Stock") %>' />
                                            <asp:HiddenField ID="hfCodDetalle" runat="server" Value='<%# Bind("CodDetalle") %>' />
                                            <asp:HiddenField ID="hfAcuenta" runat="server" Value='<%# Bind("Acuenta") %>' />
                                            <asp:HiddenField ID="hfCodGratuito" runat="server" Value='<%# Bind("CodGratuito") %>' />
                                            <asp:HiddenField ID="hfExclusivo" runat="server" Value='<%# Bind("Exclusivo") %>' />
                                            <asp:HiddenField ID="hfCosto" runat="server" Value='<%# Bind("Costo") %>' />
                                           <asp:HiddenField ID="hfLoteDetalle" runat="server" Value='<%# Eval("Lote") %>' />
                                            <asp:HiddenField ID="hfLimiteMayorista" runat="server" Value='<%# Bind("LimiteMayorista") %>' />
                                            <asp:HiddenField ID="hfCantidadMayorista" runat="server" Value='<%# Bind("CantidadMayorista") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                       <asp:TemplateField HeaderText="VCTO" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:TextBox runat="server" ID="txtFechaVencimiento" Width="56px"   Text='<%# Bind("Vencimiento") %>' 
                                                     ForeColor="Blue" Font-Bold="True" Font-Names="Arial" CssClass="Jq-ui-dtp ccsestilo"
                                                     onchange="F_ActualizarVencimiento(this.id); return false;"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        </asp:TemplateField>

                                               
                                          <asp:TemplateField HeaderText="Lote" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:TextBox runat="server" ID="txtLote" Width="56px"   Text='<%# Bind("Lote") %>' 
                                                     ForeColor="Blue" Font-Bold="True" Font-Names="Arial" CssClass="  ccsestilo"
                                                     onchange="F_ActualizarLote(this.id); return false;"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
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
                                                Tipo
                                            </td>
                                            <td>
                                                <div id="div_TipoDoc2">
                                                    <asp:DropDownList ID="ddlTipoDoc2" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                        Font-Bold="True" Width="85px">
                                                
                                                    </asp:DropDownList>
                                                </div>
                                            </td>
                                            <td style="font-weight: bold">
                                                Serie
                                            </td>
                                            <td>
                                                <div id="div_serieconsulta">
                                                    <asp:DropDownList ID="ddlSerieConsulta" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                        Font-Bold="True">
                                                    </asp:DropDownList>
                                                </div>
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="chkNumero" runat="server" Text="Numero" Font-Bold="True" />
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtNumeroConsulta" runat="server" Width="40" Font-Names="Arial"
                                                    ForeColor="Blue" Font-Bold="True"></asp:TextBox>
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
                                            <td>
                                                <asp:CheckBox ID="chkCliente" runat="server" Text="Cliente" Font-Bold="True" />
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtClienteConsulta" runat="server" Width="190" Font-Names="Arial"
                                                    ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                            </td>
                                            <td style="font-weight: bold">
                                                VENDEDOR
                                            </td>
                                            <td>
                                                <div id="div_EmpleadoConsulta">
                                                    <asp:DropDownList ID="ddlEmpleadoConsulta" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                        Font-Bold="True" Width="115">
                                                    </asp:DropDownList>
                                                </div>
                                            </td>
                                            <td style="font-weight: bold">
                                                ESTADO
                                            </td>
                                            <td>
                                                <div id="div_Estado">
                                                    <asp:DropDownList ID="ddlEstado" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                        Font-Bold="True" Width="60">
                                                    </asp:DropDownList>
                                                </div>
                                            </td>

                                                    <td style = "display:none;">
                                                Placa
                                            </td>
                                               <td style = "display:none;">
                                                        <asp:TextBox ID="txtPlacaConsulta" runat="server" Width="80px" Font-Names="Arial" ForeColor="Blue"
                                                            Font-Bold="True"></asp:TextBox>
                                                    </td>
                                          
                                            <td style = "display:none;">
                                                <div id="div_Almacen">
                                                    <asp:DropDownList ID="ddlAlmacen" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                        Font-Bold="True" Width="60">
                                                    </asp:DropDownList>
                                                </div>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                            <div class="linea-button" style="height: 25px">
                            <asp:CheckBox ID="chkFactura" runat="server" Text="VISUALIZAR SOLO PDF Factura" Font-Bold="True"  STYLE = "display:none;"/>
                                <asp:Button ID="btnImpresionPedidos" runat="server" Text="Imprimir" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                                    Font-Names="Arial" Font-Bold="True" Width="120" Visible="false" />
                             
                                <asp:Button ID="btnDevolucion" runat="server" Text="Devolucion" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                                    Font-Names="Arial" Font-Bold="True" Width="120" STYLE="DISPLAY:none;" />

                                      <asp:Button ID="btnComision" runat="server" Text="Comision" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                                    Font-Names="Arial" Font-Bold="True" Width="120" STYLE = "display:none;" />
                        
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
                                        
                                        <td id="CeldaTotales">
                                        <table>
                                        <tr>
                                           <td style="font-weight: bold;padding-left: 50px;font-size: medium;">
                                        T. Soles:
                                    </td>
                                    <td style="font-weight: bold;">
                                        <label id="lblTotalSoles"></label>                                      
                                    </td>  
                                      <td  style="font-weight: bold;padding-left: 50px;font-size: medium;">
                                       T. Dolares:
                                    </td>
                                    <td style="font-weight: bold;">
                                        <label id="lblTotalDolares">    </label>
                                     </td> 
                                        </tr>
                                        </table>
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
                                            <asp:ImageButton runat="server" ID="imgAnularDocumento" ImageUrl="~/Asset/images/Eliminar.jpg"
                                                ToolTip="ANULAR DOCUMENTO" OnClientClick="F_AnularPopUP(this); return false;" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:ImageButton runat="server" ID="imgEditarDocumento" ImageUrl="~/Asset/images/btnEdit.gif"
                                                ToolTip="EDITAR DOCUMENTO" OnClientClick="F_EditarRegistro(this); return false;" />
                                        </ItemTemplate>
                                    </asp:TemplateField>     
                                   <%--      <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:ImageButton runat="server" ID="imgReemplazar" ImageUrl="~/Asset/images/Reemplazo.png"
                                                ToolTip="EDITAR VENTA" OnClientClick="F_ReemplazarDocumento(this); return false;" />
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
 
                                   <asp:TemplateField HeaderText="FT">
                                        <ItemTemplate>
                                            <asp:ImageButton runat="server" ID="imgPdfFactura" ImageUrl="~/Asset/images/pdf.png" ToolTip="VISTA PRELIMINAR FT PDF"
                                                OnClientClick="F_VistaPreliminar(this,203); return false;" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="GR">
                                        <ItemTemplate>
                                            <asp:ImageButton runat="server" ID="imgPdfGuia" ImageUrl="~/Asset/images/pdf.png" ToolTip="VISTA PRELIMINAR GR PDF"
                                                OnClientClick="F_VistaPreliminar(this,100); return false;" />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="FT">
                                        <ItemTemplate>
                                            <asp:ImageButton runat="server" ID="imgImprimirFactura" ImageUrl="~/Asset/images/imprimir.gif"
                                                ToolTip="IMPRIMIR FACTURA" OnClientClick="F_ImprimirFacturaGrilla(this,218); return false;" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                                         
                                    <asp:TemplateField HeaderText="GR">
                                        <ItemTemplate>
                                            <asp:ImageButton runat="server" ID="imgImprimirGuia" ImageUrl="~/Asset/images/imprimir.gif"
                                                ToolTip="IMPRIMIR GUIA" OnClientClick="F_ImprimirFacturaGrilla(this,200); return false;" />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                   

                                    <asp:TemplateField HeaderText="CE">
                                        <ItemTemplate>
                                            <asp:ImageButton runat="server" ID="imgMail" ImageUrl="~/Asset/images/Mail2.png"
                                                ToolTip="Reenvio de Correo" OnClientClick="F_ReenvioMail(this); return false;" />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                             <asp:TemplateField HeaderText="O">
                            <ItemTemplate>
                                <img id="imgMasObservacion" alt="" style="cursor: pointer" src="../Asset/images/plus.gif"
                                    onclick="imgMasObservacion_Click(this);" title="OBSERVACION" />
                                <asp:Panel ID="pnlOrdersObservacion" runat="server" Style="display: none">
                                    <asp:GridView ID="grvDetalleObservacion" runat="server" border="0" CellPadding="0"
                                        CellSpacing="1" AutoGenerateColumns="False" GridLines="None" class="GridView">
                                        <Columns>
                                            <asp:BoundField DataField="Observacion" HeaderText="Observacion">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                        </Columns>
                                    </asp:GridView>
                                </asp:Panel>
                            </ItemTemplate>

                        </asp:TemplateField>

                             <asp:TemplateField HeaderText="P">
                            <ItemTemplate>
                                <img id="imgMasPermisoObservacion" alt="" style="cursor: pointer" src="../Asset/images/plus.gif"
                                    onclick="imgMasPermisoObservacion_Click(this);" title="OBSERVACION PERMISO" />
                                <asp:Panel ID="pnlPermisoObservacion" runat="server" Style="display: none">
                                    <asp:GridView ID="grvPermisoObservacion" runat="server" border="0" CellPadding="0"
                                        CellSpacing="1" AutoGenerateColumns="False" GridLines="None" class="GridView">
                                        <Columns>
                                            <asp:BoundField DataField="Observacion" HeaderText="Observacion PERMISO">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                        </Columns>
                                    </asp:GridView>
                                </asp:Panel>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="A">
                            <ItemTemplate>
                                <img id="imgMasAuditoria" alt="" style="cursor: pointer" src="../Asset/images/plus.gif"
                                    onclick="imgMasAuditoria_Click(this);" title="Auditoria" />
                                <asp:Panel ID="pnlOrdersAuditoria" runat="server" Style="display: none">
                                    <asp:GridView ID="grvDetalleAuditoria" runat="server" border="0" CellPadding="0"
                                        CellSpacing="1" AutoGenerateColumns="False" GridLines="None" class="GridView">
                                        <Columns>
                                            <asp:BoundField DataField="Auditoria" HeaderText="Auditoria">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                        </Columns>
                                    </asp:GridView>
                                </asp:Panel>
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
                                               <%--         <asp:BoundField DataField="ID" HeaderText="ID">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Right" />
                                                        </asp:BoundField>--%>
                                                        <asp:BoundField DataField="Codigo" HeaderText="Codigo">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Left" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Descripcion" HeaderText="Descripcion">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Left" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Cantidad" HeaderText="Cantidad">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Right" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="UM" HeaderText="UM">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Left" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Precio" HeaderText="Precio">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Right" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Importe" HeaderText="Importe">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Right" />
                                                        </asp:BoundField>

                                                            <asp:BoundField DataField="Procedencia" HeaderText="Procedencia" >
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>

                                                           <asp:BoundField DataField="FechaCaducidad" HeaderText="FVC" >
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>

                                                  
                                                           <asp:BoundField DataField="Marca" HeaderText="Marca" >
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>

                                                           <asp:BoundField DataField="RegistroSanitario" HeaderText="RegistroSanitario">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>

                                                        <asp:BoundField DataField="OV" HeaderText="Anexo" Visible="false">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Anexo2" HeaderText="COMPRA 1" Visible="false">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                            <asp:BoundField DataField="Anexo3" HeaderText="COMPRA 2" Visible="false">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                             <asp:BoundField DataField="NCV" HeaderText="NCV" Visible="false">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                           <asp:BoundField DataField="NCC" HeaderText="NCC" Visible="false">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                 <%--        <asp:BoundField DataField="P1" HeaderText="P1">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Right" />
                                                        </asp:BoundField>
                                                          <asp:BoundField DataField="P2" HeaderText="P2">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Right" />
                                                        </asp:BoundField>
                                                          <asp:BoundField DataField="P3" HeaderText="P3">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Right" />
                                                        </asp:BoundField>--%>

                                                    </Columns>
                                                </asp:GridView>
                                            </asp:Panel>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                   
                                    <asp:TemplateField HeaderText="Numero" HeaderStyle-HorizontalAlign="Center">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <ItemTemplate>
                                            <asp:HyperLink runat="server" ID="lblnumero" Font-Underline="true" ForeColor="Black"
                                                Style="cursor: hand" Text='<%# Bind("Numero") %>' onclick="F_ImprimirDocumentonc(undefined,this,'lblnumero','PDF'); return false;"
                                                ToolTip="Ver NC" CssClass="detallesart" >
                                            </asp:HyperLink>
                                            <asp:HiddenField ID="lblCodigo" runat="server" Value='<%# Bind("Codigo") %>' />
                                            <asp:HiddenField ID="hfCodTipoDoc" runat="server" Value='<%# Bind("CodTipoDoc") %>' />
                                            <asp:HiddenField ID="hfCodTraslado" runat="server" Value='<%# Bind("CodGuia") %>' />
                                      <%--  <asp:HiddenField ID="hfCodDocNC" runat="server" Value='<%# Bind("CodDocNC") %>' />
                                            <asp:HiddenField ID="hfNumeroNC" runat="server" Value='<%# Bind("NumeroNC") %>' />--%>
                                            <asp:HiddenField ID="hfDetalleCargado" runat="server" Value='0' />
                                            <asp:HiddenField ID="hfDetalleCargadoObservacion" runat="server" Value='0' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Cliente" HeaderStyle-HorizontalAlign="Center">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblcliente" Text='<%# Bind("Cliente") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Emision" HeaderText="Emision" HeaderStyle-HorizontalAlign="Center">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Condicion" HeaderText="Condicion" HeaderStyle-HorizontalAlign="Center">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Moneda">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblMoneda" Text='<%# Bind("Moneda") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Total">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblTotal" Text='<%# Bind("Total") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Saldo" HeaderText="Saldo" HeaderStyle-HorizontalAlign="Center"
                                        DataFormatString="{0:N2}">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Guia" HeaderStyle-HorizontalAlign="Center">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblGuia" Text='<%# Bind("Guia") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Estado">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblEstado" Text='<%# Bind("Estado") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="FechaCancelacion" HeaderText="Cancelac" HeaderStyle-HorizontalAlign="Center">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Placa" HeaderText="Placa" HeaderStyle-HorizontalAlign="Center">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                              <%--      <asp:BoundField DataField="Comision" HeaderText="Comision" HeaderStyle-HorizontalAlign="Center">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                          <asp:BoundField DataField="Motorizado" HeaderText="Moto" HeaderStyle-HorizontalAlign="Center">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>--%>
                                    <asp:TemplateField HeaderText="Est. Sunat">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:HyperLink runat="server" ID="lblEstadoSunat" Font-Underline="true" ForeColor="Black"
                                                Style="cursor: hand" Text='<%# Bind("EstadoSunat") %>' onclick="F_VerArchivoCDR(this.id); return false;"
                                                ToolTip="Ver Archivo CDR">
                                            </asp:HyperLink>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Correo Sunat">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblCorreoSunat" Text='<%# Bind("EstadoCorreoSunat") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </td>
            <td valign="top" style="width: 120px">
                <div class="ui-jqgrid ui-widget ui-widget-content ui-corner-all" style="width: 250px;
                    height: 100%;">
                    <div class="ui-jqgrid-titlebar ui-widget-header ui-corner-top ui-helper-clearfix">
                        Deuda del Cliente
                    </div>
                    <div id="div2" class="ui-jqdialog-content">
                        <div>
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style="width: 60px; font-weight: bold; padding-left: 5px">
                                        Deuda
                                    </td>
                                    <td style="width: 190px; text-align: right; padding-right: 12px">
                                        <label id="txtSaldoCreditoFavor" style="font-weight: bold; font-size: 20px; text-align: right">
                                            S/0.00</label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div id="div_table_almacenes">
                            <div>
                                <table id="table_almacenes_deudas" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td style="font-weight: bold; padding-left: 5px">
                                            Deuda
                                        </td>
                                        <td style="padding-left: 10px; text-align: right">
                                            <label id="Label1" style="font-weight: bold; text-align: right">
                                                S/0.00</label>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div style="text-align:center; padding-top:5px" >
                                <asp:Button ID="btnVerDetalleDeuda" runat="server" Text="Ver detalle de las Deudas"
                                    class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                                    Font-Names="Arial" Font-Bold="True" Width="220" OnClientClick="F_MostrarDetalle_DeudaCliente(); return false;"/>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="ui-jqgrid ui-widget ui-widget-content ui-corner-all" style="width: 250px;
                    height: 100%;">
                    <div class="ui-jqgrid-titlebar ui-widget-header ui-corner-top ui-helper-clearfix">
                        Cotizaciones
                    </div>
                    <div id="divListaCotizaciones" class="ui-jqdialog-content">
                        <ul id="lu_Cotizaciones" class="ul-float" style="padding-left: 5px; width: 220px">
                        </ul>
                    </div>
                </div>
            </td>
        </tr>
    </table>
    <div id="divFacturacionOC" style="display: none;">
        <table cellpadding="0" cellspacing="0" width="850">
            <tr>
                <td align="right" style="padding-top: 10px;">
                    <asp:Button ID="btnDevolverItemOC" runat="server" Text="Devolver" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                        Font-Names="Arial" Width="120" />
                    <asp:Button ID="btnAgregarItemOC" runat="server" Text="Agregar" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                        Font-Names="Arial" Width="120" />
                </td>
            </tr>
            <tr>
                <td style="padding-top: 5px;">
                    <div id="div_DetalleOC">
                        <asp:GridView ID="grvDetalleOC" runat="server" AutoGenerateColumns="False" border="0"
                            CellPadding="0" CellSpacing="1" CssClass="GridView" GridLines="None" Width="860px">
                            <Columns>
                                <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:CheckBox runat="server" ID="chkEliminar" CssClass="chkDelete" Text="" onclick="F_ValidarCheck_OC(this.id);" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ID">
                                    <ItemStyle HorizontalAlign="Right" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblCodDetalle" Text='<%# Bind("CodDetalle") %>'></asp:Label>
                                        <asp:HiddenField ID="hfCodArticulo" runat="server" Value='<%# Bind("CodArticulo") %>' />
                                        <asp:HiddenField ID="hfCodUndMedida" runat="server" Value='<%# Bind("CodUndMedida") %>' />
                                        <asp:HiddenField ID="hfCodMovimiento" runat="server" Value='<%# Bind("CodMovimiento") %>' />
                                        <asp:HiddenField ID="hfSerieDoc" runat="server" Value='<%# Bind("SerieDoc") %>' />
                                        <asp:HiddenField ID="hfNumeroDoc" runat="server" Value='<%# Bind("NumeroDoc") %>' />
                                        <asp:HiddenField ID="hfCostoUnitario" runat="server" Value='<%# Bind("CostoUnitario") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Numero">
                                    <ItemStyle HorizontalAlign="Right" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblNumero" Text='<%# Bind("Numero") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Codigo">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblCodigo" Text='<%# Bind("Codigo") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Descripcion">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblProducto" Text='<%# Bind("Producto") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Compra">
                                    <ItemStyle HorizontalAlign="Right" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblCantidad" Text='<%# Bind("Cantidad") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="UM" HeaderText="UM">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Precio">
                                    <ItemStyle HorizontalAlign="Right" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblPrecio" Text='<%# Bind("Precio") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Cantidad" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:TextBox runat="server" ID="txtCantidadEntregada" Width="55px" Font-Bold="true"
                                            Style="text-align: center;" Font-Names="Arial" onblur="F_ValidarStockGrillaOC(this.id);"
                                            Enabled="False"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </td>
            </tr>
        </table>
    </div>
    <div id="div_FacturacionGuia" style="display: none;">
        <table cellpadding="0" cellspacing="0" width="850">
            <tr>
                <td align="right" style="padding-top: 10px;">
                    <asp:Button ID="btnDevolverGuia" runat="server" Text="Devolver" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                        Font-Names="Arial" ForeColor="Blue" Font-Bold="True" />
                    <asp:Button ID="btnAgregarGuia" runat="server" Text="Agregar" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                        Font-Names="Arial" ForeColor="Blue" Font-Bold="True" />
                </td>
            </tr>
            <tr>
                <td style="padding-top: 5px;">
                    <div id="div_GrillaFacturacionGuia">
                        <asp:GridView ID="grvFacturacionGuia" runat="server" AutoGenerateColumns="False"
                            border="0" CellPadding="0" CellSpacing="1" CssClass="GridView" GridLines="None"
                            Width="860px" Height="400">
                            <Columns>
                                <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:CheckBox runat="server" ID="chkEliminar" CssClass="chkDelete" Text="" onclick="F_ValidarCheck_OC(this.id);" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ID">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblCodDetalle" Text='<%# Bind("CodDetalle") %>'></asp:Label>
                                        <asp:HiddenField ID="hfCodArticulo" runat="server" Value='<%# Bind("CodArticulo") %>' />
                                        <asp:HiddenField ID="hfCodUndMedida" runat="server" Value='<%# Bind("CodUndMedida") %>' />
                                        <asp:HiddenField ID="hfCodMovimiento" runat="server" Value='<%# Bind("CodMovimiento") %>' />
                                        <asp:HiddenField ID="hfSerieDoc" runat="server" Value='<%# Bind("SerieDoc") %>' />
                                        <asp:HiddenField ID="hfNumeroDoc" runat="server" Value='<%# Bind("NumeroDoc") %>' />
                                        <asp:HiddenField ID="hfCostoUnitario" runat="server" Value='<%# Bind("CostoUnitario") %>' />
                                        <asp:HiddenField ID="hfCodDepartamento" runat="server" Value='<%# Bind("CodDepartamento") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Guia">
                                    <ItemStyle HorizontalAlign="Right" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblNumero" Text='<%# Bind("Numero") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="FechaEmision" HeaderText="Fecha">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Almacen" HeaderText="Almacen">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Codigo">
                                    <ItemStyle HorizontalAlign="Right" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblCodigo" Text='<%# Bind("Codigo") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Producto" HeaderText="Descripcion">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Compra">
                                    <ItemStyle HorizontalAlign="Right" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblCantidad" Text='<%# Bind("Cantidad") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="UM" HeaderText="UM">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Precio">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblPrecio" Text='<%# Bind("Precio") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Cantidad" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:TextBox runat="server" ID="txtCantidadEntregada" Width="55px" Font-Bold="true"
                                            Style="text-align: center;" Font-Names="Arial" onblur="F_ValidarStockGrillaOC(this.id);"
                                            Enabled="False"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </td>
            </tr>
        </table>
    </div>
    <div id="divConsultaArticulo" style="display: none;">
        <div id='divCabecera' class="ui-jqgrid ui-widget ui-widget-content ui-corner-all">
            <div class="ui-jqgrid-titlebar ui-widget-header ui-corner-top ui-helper-clearfix">
                Criterio de busqueda
            </div>
            <div class="ui-jqdialog-content">
                <table cellpadding="0" cellspacing="0" class="form-inputs">
                    <tbody>
                        <tr>
                            <td style="font-weight: bold">
                                Descripcion
                            </td>
                            <td>
                                <table cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td style="padding-left: 5px; font-weight: bold">
                                            <asp:CheckBox ID="chkDescripcion" runat="server" Text="descripcion" Font-Bold="True"
                                                Style="display: none;" />
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtArticulo" runat="server" Width="717px" Font-Names="Arial" ForeColor="Blue"
                                                Font-Bold="True"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Button ID="btnBuscarArticulo" runat="server" Text="Buscar" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                                                Font-Names="Arial" Font-Bold="True" Width="120" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
            <div class="linea-button">
            </div>
            <div>
                <table>
                    <tr>
                        <td valign="top">
                            <div style="overflow-y: scroll; height: 330px;">
                                <div id="div_grvConsultaArticulo" style="padding-top: 5px">
                                    <asp:GridView ID="grvConsultaArticulo" runat="server" AutoGenerateColumns="False"
                                        border="0" CellPadding="0" CellSpacing="1" CssClass="GridView" GridLines="None"
                                        Width="970px" OnRowDataBound="grvConsultaArticulo_RowDataBound">
                                        <Columns>


                                            <asp:TemplateField>
                                                <ItemStyle Font-Bold="true" />
                                                <ItemTemplate>
                                                    <asp:ImageButton runat="server" ID="imgAgregar" ImageUrl="~/Asset/images/ok.gif"
                                                        ToolTip="Agregar" OnClientClick="F_AgregarArticulo(this.id,1); return false;" />
                                               
                                                 <asp:ImageButton runat="server" ID="imgVisualizarRegistro" ImageUrl="../Asset/images/Viewx16.png"
                                        ToolTip="VISUALIZAR FOTOS DEL PRODUCTO" OnClientClick="F_VisualizarImagenVenta(this); return false;" />
                                                </ItemTemplate>
                                            </asp:TemplateField>  
                                            
                                                                                   
                                            <asp:TemplateField HeaderText="Código">
                                                <ItemStyle Font-Bold="true" />
                                                <ItemTemplate>
                                                    <asp:Label runat="server" ID="hlkCodNeumaticoGv" Text='<%# Bind("CodigoInterno") %>' Font-Size="Medium"></asp:Label>
                                                    <asp:HiddenField ID="lblcodproducto" runat="server" Value='<%# Bind("CodProducto") %>' />
                                                    <asp:HiddenField ID="hfcodunidadventa" runat="server" Value='<%# Bind("CodUnidadVenta") %>' />
                                                    <asp:HiddenField ID="hfcosto" runat="server" Value='<%# Bind("Costo") %>' />
                                                    <asp:HiddenField ID="lblPrecio1" runat="server" Value='<%# Bind("Precio1") %>' />
                                                    <asp:HiddenField ID="lblPrecio2" runat="server" Value='<%# Bind("Precio2") %>' />
                                                    <asp:HiddenField ID="lblPrecio3" runat="server" Value='<%# Bind("Precio3") %>' />                                                    
                                                    <asp:HiddenField ID="hfDescripcion" runat="server" Value='<%# Bind("Descripcion") %>' />                                                  
                                                    <asp:HiddenField ID="hfCodigoAlternativo" runat="server" Value='<%# Bind("Codigo2") %>' />
                                                    <asp:HiddenField ID="hfFlagProductoInicial" runat="server" Value='<%# Bind("FlagProductoInicial") %>' />
                                                    <asp:HiddenField ID="hfMoneda" runat="server" Value='<%# Bind("Moneda") %>' />
                                                    <asp:HiddenField ID="hfStock" runat="server" Value='<%# Bind("Stock") %>' />
                                                    <asp:HiddenField ID="hfCodigoInterno" runat="server" Value='<%# Bind("CodigoInterno") %>' />
                                                    <asp:HiddenField ID="hfCodProductoAzure" runat="server" Value='<%# Bind("CodProductoAzure") %>' />
                                                    <asp:HiddenField ID="hfLimiteMayorista" runat="server" Value='<%# Bind("LimiteMayorista") %>' /> 
                                                    <asp:HiddenField ID="hfCantidadMayorista" runat="server" Value='<%# Bind("CantidadMayorista") %>' /> 
                                                     <asp:HiddenField ID="hfexclusivo" runat="server" Value='<%# Bind("Exclusivo") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Descripcion" HeaderStyle-HorizontalAlign="Center">
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:HyperLink runat="server" ID="lblProducto" Font-Underline="true" ForeColor="Blue" Font-Size="Medium"
                                                        Style="cursor: hand" Text='<%# Bind("Descripcion") %>' onclick="F_AgregarArticuloFromDsc(this.id); return false;">
                                                    </asp:HyperLink>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Stock">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <asp:Label runat="server" ID="lblstock" Text='<%# Bind("Stock") %>' Font-Size="Medium"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="UM">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <asp:Label runat="server" ID="lblUM" Text='<%# Bind("UM") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="Costo" HeaderText="Costo">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Right" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="Precio">
                                                <ItemStyle HorizontalAlign="Right"/>
                                                <ItemTemplate>
                                                    <asp:Label runat="server" ID="lblPrecio" Text='<%# Bind("Precio1") %>' Font-Size="Medium"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Mon">
                                                <ItemStyle HorizontalAlign="Center"/>
                                                <ItemTemplate>
                                                    <asp:Label runat="server" ID="lblMoneda" Text='<%# Bind("Moneda") %>' Font-Size="Medium"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField> 
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                        </td>
                        <td valign="top">
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
                            <div id="div_ultimoprecio">
                                <div class="ui-jqdialog-content">
                                    <div class="ui-jqdialog-content">
                                        <%--COMBO--%>
                                        <div id="divcombo">
                                            <%--<asp:Label runat="server" ID="lblID" Text='<%# Bind("ID") %>'></asp:Label>--%>
                                            <asp:Label runat="server" ID="lbCodProducto" Text=""></asp:Label>
                                            <asp:Label runat="server" ID="lbCodNeumatico" Text=""></asp:Label>
                                            <asp:TextBox ID="txtClienteDropTop" runat="server" Width="227px" Font-Names="Arial"
                                                ForeColor="Blue" Font-Bold="True" ReadOnly="true"></asp:TextBox>
                                            <asp:DropDownList ID="ddlDropTop" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                Font-Bold="True">
                                                <asp:ListItem Text="Top 5" Value="5"></asp:ListItem>
                                                <asp:ListItem Text="Top 10" Value="10"></asp:ListItem>
                                                <asp:ListItem Text="Top 15" Value="15"></asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:Button ID="btnBuscarTop" runat="server" Text="Buscar" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                                                Font-Names="Arial" Font-Bold="True" Width="120" />
                                        </div>
                                        <%--GRID CON LOS ULTIMOS PRECIOS--%>
                                        <div id="div_grvConsultaUltimosPrecios" style="padding-top: 5px;">
                                            <asp:GridView ID="grvConsultaUltimosPrecios" runat="server" AutoGenerateColumns="False"
                                                border="0" CellPadding="0" CellSpacing="1" CssClass="GridView" GridLines="None"
                                                Width="227px">
                                                <Columns>
                                                    <asp:BoundField DataField="Fecha" HeaderText="Fecha">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle HorizontalAlign="Right" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Factura" HeaderText="FT">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Cantidad" HeaderText="Cant">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle HorizontalAlign="Right" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Precio" HeaderText="Prec">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle HorizontalAlign="Right" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Moneda" HeaderText="Mon">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </asp:BoundField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                        <%--ARCHIVO CDR--%>
                                        <div id="div_CDR" style="display: none">
                                            <div>
                                                <table cellpadding="0" cellspacing="0" class="form-inputs">
                                                    <tr>
                                                        <td style="font-weight: bold">
                                                            Factura
                                                        </td>
                                                        <td style="padding-left: 10px">
                                                            <asp:TextBox ID="txtFacturaCDR" runat="server" Width="200px" Font-Names="Arial" ForeColor="Blue"
                                                                Font-Bold="True" ReadOnly="true"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="font-weight: bold">
                                                            Archivo
                                                        </td>
                                                        <td style="padding-left: 10px">
                                                            <asp:TextBox ID="txtArchivoCDR" runat="server" Width="200px" Font-Names="Arial" ForeColor="Blue"
                                                                Font-Bold="True" ReadOnly="true"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td style="padding-left: 10px">
                                                            <div id="tr_btnDescargaCDR">
                                                                <asp:Button ID="btnDescargarCDR" runat="server" Text="Descargar XML CDR Y PDF" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                                                                    Font-Names="Arial" Font-Bold="True" Width="200" />
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="linea-button">
            </div>
            <div class="ui-jqdialog-content">
                <table cellpadding="0" cellspacing="0" class="form-inputs">
                    <tbody>
                        <tr>
                          
                            <td>
                                <table cellpadding="0" cellspacing="0">

                                         <tr>
                                        <td style="font-weight: bold">
                                            Codigo
                                        </td>

                                        <td>
                                            <asp:TextBox ID="txtCodigoProductoAgregar" runat="server" Width="340px" Font-Names="Arial"
                                                ForeColor="Blue" Font-Bold="True" ReadOnly="true" Font-Size="16"></asp:TextBox>
                                        </td>
                                        <td style="font-weight: bold">
                                            Stock
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtStockAgregar" runat="server" Width="80px" Font-Names="Arial"
                                                CssClass="Derecha" ForeColor="Blue" Font-Bold="True" ReadOnly="true" Font-Size="16"></asp:TextBox>
                                        </td>
                                        <td style="font-weight: bold">
                                            UM
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtUMAgregar" runat="server" Width="68px" Font-Names="Arial" ForeColor="Blue"
                                                Font-Bold="True" ReadOnly="true" Font-Size="16"></asp:TextBox>
                                        </td>   
                                        
                                          <td style="font-weight: bold">
                                            Vencimiento
                                        </td> 
                                        
                                         <td style="padding-left: 5px;">
                                            <asp:TextBox ID="txtFechaCaducidad" runat="server" Width="118px" Height="25" CssClass="Jq-ui-dtp"  
                                                Font-Names="Arial" ForeColor="Blue" Font-Bold="True" Font-Size="16" ></asp:TextBox>
                                        </td>   
                                        
                                           <td style="font-weight: bold">
                                            Lote
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtLote" runat="server" Width="150px" Font-Names="Arial" ForeColor="Blue"
                                                Font-Bold="True"  Font-Size="16"></asp:TextBox>
                                        </td>   
                                        
                       
                                        <td style="DISPLAY:none;" >
                                            <asp:TextBox ID="txtCantidad173" runat="server" Width="80px" Font-Names="Arial" ForeColor="Blue"
                                                Font-Bold="True" Font-Size="16" CssClass="Derecha"></asp:TextBox>
                                        </td> 
                                     
                                        <td  style="DISPLAY:none;">
                                            <asp:TextBox ID="txtCantidad250" runat="server" Width="80px" Font-Names="Arial" ForeColor="Blue"
                                                Font-Bold="True" Font-Size="16" CssClass="Derecha"></asp:TextBox>
                                        </td> 
                                      
                                        <td  style="DISPLAY:none;">
                                            <asp:TextBox ID="txtCantidadABC" runat="server" Width="80px" Font-Names="Arial" ForeColor="Blue"
                                                Font-Bold="True" Font-Size="16" CssClass="Derecha"></asp:TextBox>
                                        </td>
                                         <td style="font-weight: bold; color: Red; font-size: medium;DISPLAY:none;">
                                            EXCLUSIVO
                                        </td>
                                        <td style="DISPLAY:none;">
                                            <asp:TextBox ID="txtExclusivo" runat="server" Width="100px" Font-Names="Arial" ForeColor="Blue"
                                                Font-Bold="True" Font-Size="16" CssClass="Derecha" Enabled="False"></asp:TextBox>
                                        </td> 
                                         <td style="DISPLAY:none;font-weight: bold">
                                            Cantidad Mayo
                                        </td>
                                        <td style="DISPLAY:none;">
                                            <asp:TextBox ID="txtCantidadMayorista" runat="server" Width="68px" Font-Names="Arial" ForeColor="Blue"
                                                Font-Bold="True" ReadOnly="true" CssClass="Derecha" Font-Size="16"></asp:TextBox>
                                        </td>  
                                          <td style="DISPLAY:none;font-weight: bold;color: Green;font-size: medium;">
                                           Mayorista
                                        </td>
                                        <td style="DISPLAY:none;">
                                            <asp:TextBox ID="txtPrecioMayorista" runat="server" Width="88px" Font-Names="Arial" ForeColor="Green"
                                                Font-Bold="True" ReadOnly="true" CssClass="Derecha" Font-Size="16"></asp:TextBox>
                                        </td> 
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td style="display:none">
                                <asp:CheckBox ID="chkServicios" runat="server" Text="Servicios" Font-Bold="True" />
                            </td>
                            <td>
                                <table cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td style= "padding-left: 45px">
                                            <asp:TextBox ID="txtArticuloAgregar" runat="server" Width="700px" Font-Names="Arial"
                                                ForeColor="Blue" Font-Bold="True" Font-Size="16"></asp:TextBox>
                                        </td>
                                        <td style="font-weight: bold">
                                            Cantidad
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCantidad" runat="server" Width="40px" Font-Names="Arial" ForeColor="Blue"
                                                Font-Bold="True" CssClass="Derecha" Font-Size="16"></asp:TextBox>
                                        </td>
                                        <td style="font-weight: bold">
                                            Precio
                                        </td>
                                        <td>
                                            <asp:TextBox Style="width: 80px; position: absolute; color: blue; font-family: Arial;
                                                font-weight: bold; background: rgb(255, 255, 224);" ID="txtPrecioDisplay" runat="server"
                                                Font-Size="16"></asp:TextBox>
                                            <asp:DropDownList ID="ddlPrecio" Style="width: 100px" runat="server" Font-Size="16">
                                                <asp:ListItem Value="test1">test1</asp:ListItem>
                                                <asp:ListItem Value="test2">test2</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td style="font-weight: bold">
                                            <asp:Label ID="lblMonedaAgregar" runat="server" Text="" Font-Bold="True"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Button ID="btnAgregar" runat="server" Text="Agregar" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                                                Font-Names="Arial" Font-Bold="True" Width="120" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
    <div id="div_PrecioMinimo" style="display: none;">
        <div class="ui-jqdialog-content">
            <table cellpadding="0" cellspacing="0" class="form-inputs">
                <tr>
                    <td>
                        Precio Minimo
                    </td>
                    <td>
                        <asp:TextBox ID="txtPrecioMinimo" runat="server" Width="80px" ReadOnly="True" Font-Names="Arial"
                            Font-Bold="True" Font-Size="Small"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="txtMoneda" runat="server" Width="80px" ReadOnly="True" Font-Names="Arial"
                            Font-Bold="True" Font-Size="Small"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
    </div>    
    <div id="div_VerPrecio" style="display: none;">
        <div id="div_PrecioMoneda" style="padding-top: 5px;">
            <asp:GridView ID="grvPrecioMoneda" runat="server" AutoGenerateColumns="False" border="0"
                CellPadding="0" CellSpacing="1" CssClass="GridView" GridLines="None" Width="300px">
                <Columns>
                    <asp:BoundField DataField="CodProducto" HeaderText="ID">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Precio3" HeaderText="Precio 3">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Precio2" HeaderText="Precio 2">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Precio1" HeaderText="Precio 1">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Moneda" HeaderText="Moneda">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
    <div id="divFacturacionNV" style="display: none;">
        <table cellpadding="0" cellspacing="0" width="850">
            <tr>
                <td style="padding-top: 10px;">
                    <asp:CheckBox ID="chkDesdeNV" runat="server" Text="DESDE" Font-Bold="True" Checked="True" />
                </td>
                <td style="padding-left: 2px; padding-top: 10px;">
                    <asp:TextBox ID="txtDesdeNV" runat="server" Width="55" Font-Names="Arial" ForeColor="Blue"
                        Font-Bold="True" CssClass="Jq-ui-dtp" ReadOnly="True"></asp:TextBox>
                </td>
                <td style="padding-top: 10px; padding-left: 2px; font-weight: bold">
                    HASTA
                </td>
                <td style="padding-top: 10px; padding-left: 2px;">
                    <asp:TextBox ID="txtHastaNV" runat="server" Width="55" Font-Names="Arial" ForeColor="Blue"
                        Font-Bold="True" CssClass="Jq-ui-dtp" ReadOnly="True"></asp:TextBox>
                </td>
                <td style="font-weight: bold; padding-top: 10px;">
                    Serie
                </td>
                <td style="padding-top: 10px;">
                    <div id="div_SerieNV">
                        <asp:DropDownList ID="ddlSerieNV" runat="server" Font-Names="Arial" ForeColor="Blue"
                            Font-Bold="True">
                        </asp:DropDownList>
                    </div>
                </td>
                <td style="padding-top: 10px;">
                    <asp:CheckBox ID="chkNotaVenta" runat="server" Text="Numero" Font-Bold="True" />
                </td>
                <td style="padding-top: 10px;">
                    <asp:TextBox ID="txtNumeroNotaVenta" runat="server" Width="45" Font-Names="Arial"
                        ForeColor="Blue" Font-Bold="True" CssClass="Derecha"></asp:TextBox>
                </td>
                <td style="padding-top: 10px; padding-left: 285px;">
                    <asp:Button ID="btnBuscarNV" runat="server" Text="Buscar" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                        Font-Names="Arial" Font-Bold="True" Width="120" />
                    <asp:Button ID="btnDevolverNV" runat="server" Text="Devolver" Style="display: none;"
                        class="ui-button ui-widget ui-state-default ui-corner-all
    ui-button-text-only" Font-Names="Arial" Font-Bold="True" Width="120" />
                    <asp:Button ID="btnAgregarItemNV" runat="server" Text="Agregar" class="ui-button ui-widget ui-state-default
    ui-corner-all ui-button-text-only" Font-Names="Arial" Font-Bold="True" Width="120" />
                </td>
            </tr>
            <tr>
                <td style="padding-top: 5px;" colspan='9'>
                    <div id="div_DetalleNV">
                        <asp:GridView ID="grvDetalleNV" runat="server" AutoGenerateColumns="False" border="0"
                            CellPadding="0" CellSpacing="1" CssClass="GridView" GridLines="None" Width="960px">
                            <Columns>
                                <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center">
                                 <HeaderTemplate>
                                                                <asp:CheckBox ID="checkAll" runat="server" onclick="F_Chequear_NotaVenta_Todo(this);" />
                                                            </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox runat="server" ID="chkEliminar" CssClass="chkDelete" Text="" onclick="F_ValidarCheck_OC(this.id);" />
                                    </ItemTemplate>
                                </asp:TemplateField>                       
                                <asp:TemplateField HeaderText="Numero">
                                    <ItemStyle HorizontalAlign="Right" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblNumero" Text='<%# Bind("Numero") %>'></asp:Label>
                                        <asp:HiddenField ID="hfCodArticulo" runat="server" Value='<%# Bind("CodProducto") %>' />
                                        <asp:HiddenField ID="hfCodUndMedida" runat="server" Value='<%# Bind("CodUndMedida") %>' />
                                        <asp:HiddenField ID="hfCodMovimiento" runat="server" Value='<%# Bind("CodMovimiento") %>' />
                                        <asp:HiddenField ID="hfSerieDoc" runat="server" Value='<%# Bind("SerieDoc") %>' />
                                        <asp:HiddenField ID="hfNumeroDoc" runat="server" Value='<%# Bind("NumeroDoc") %>' />
                                        <asp:HiddenField ID="hfCostoUnitario" runat="server" Value='<%# Bind("CostoUnitario") %>' />
                                        <asp:HiddenField ID="hfFechaAnexo" runat="server" Value='<%# Bind("FechaAnexo") %>' />
                                        <asp:HiddenField ID="hfNroRuc" runat="server" Value='<%# Bind("NroRuc") %>' />
                                        <asp:HiddenField ID="hfPrecioSinIgv" runat="server" Value='<%# Bind("PrecioSinIgv") %>' />
                                        <asp:HiddenField ID="hfFlagGuia" runat="server" Value='<%# Bind("flagtraslado") %>' />
                                        <asp:HiddenField ID="hfRuctransportista" runat="server" Value='<%# Bind("NroRucTransportista") %>' />
                                        <asp:HiddenField ID="hfPlaca" runat="server" Value='<%# Bind("Placa") %>' />
                                        <asp:HiddenField ID="hfMarca" runat="server" Value='<%# Bind("Marca") %>' />
                                        <asp:HiddenField ID="hfLicencia" runat="server" Value='<%# Bind("Licencia") %>' />
                                        <asp:HiddenField ID="hfBultos" runat="server" Value='<%# Bind("Bultos") %>' />
                                        <asp:HiddenField ID="hfPeso" runat="server" Value='<%# Bind("Peso") %>' />
                                        <asp:HiddenField ID="hfRucConductor" runat="server" Value='<%# Bind("NroRucConductor") %>' />
                                        <asp:HiddenField ID="lblCodDetalle" runat="server" Value='<%# Bind("CodDetalle") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Fecha" HeaderText="Fecha">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Cliente" HeaderText="Cliente">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Codigo">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblCodigo" Text='<%# Bind("Codigo") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Descripcion">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblProducto" Text='<%# Bind("Producto") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Venta">
                                    <ItemStyle HorizontalAlign="Right" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblCantidad" Text='<%# Bind("Cantidad") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="UM" HeaderText="UM">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Precio">
                                    <ItemStyle HorizontalAlign="Right" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblPrecio" Text='<%# Bind("Precio") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="IMPORTE" HeaderText="IMPORTE">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Acuenta">
                                    <ItemStyle HorizontalAlign="Right" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblAcuenta" Text='<%# Bind("Acuenta") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Cantidad" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:TextBox runat="server" ID="txtCantidadEntregada" Width="55px" CssClass="ccsestilo"
                                            Style="text-align: center;" Font-Names="Arial" ForeColor="Blue" Font-Bold="True"
                                            onblur="F_ValidarStockGrillaOC(this.id);" Enabled="False"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </td>
            </tr>
        </table>
    </div>
    <div id="divClavePrecio" style="display: none">
        <table>
            <tr>
                <td style="font-weight: bold">
                    Usuario Auxiliar
                </td>
                <td>
                    <asp:TextBox ID="txtUsuarioPrecio" runat="server" Width="98px" Font-Names="Arial"
                        ForeColor="Blue" Font-Bold="True" ToolTip="Ingresar Usuario"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="font-weight: bold">
                    Clave
                </td>
                <td>
                    <asp:TextBox ID="txtContraseñaPrecio" runat="server" Width="98px" Font-Names="Arial"
                        ForeColor="Blue" Font-Bold="True" TextMode="Password" ToolTip="Ingresar Contraseña"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td style="font-weight: bold">
                    Observacion
                </td>
                <td>
                    <asp:TextBox ID="txtObservacionPrecio" runat="server" Width="200px" Font-Names="Arial"
                        ForeColor="Blue" Font-Bold="True" TextMode="MultiLine" Height="40"></asp:TextBox>
                </td>
            </tr>
        </table>
        <div class="linea-button" align="right">
            <table>
                <tr>
                    <td>
                        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                            Font-Names="Arial" Font-Bold="True" Width="120" />
                    </td>
                    <td>
                        <asp:Button ID="btnVerificar" runat="server" Text="Aceptar" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                            Font-Names="Arial" Font-Bold="True" Width="120" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div id="div_Anulacion" style="display: none;">
        <div class="ui-jqdialog-content">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td style="font-weight: bold">
                        ¿ PORQUE LO ESTAS ANULANDO ?
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtObservacionAnulacion" runat="server" Width="450px" Font-Names="Arial"
                            ForeColor="Blue" Font-Bold="True" TextMode="MultiLine" Height="80"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="font-weight: bold; padding-top: 5px;" align="right">
                        <asp:Button ID="btnAnular" runat="server" Text="ANULAR" class="ui-button ui-widget
    ui-state-default ui-corner-all ui-button-text-only" Font-Names="Arial" Font-Bold="True" Width="120" />
                    </td>
                </tr>
            </table>
        </div>
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
                                                <asp:TextBox ID="txtCodigoVisualizacion" runat="server" Width="100px" Font-Names="Arial"
                                                    ForeColor="Blue" Font-Bold="True" ReadOnly="true"></asp:TextBox>
                                            </td>
                                            <td style="font-weight: bold; width: 60px; text-align: right">
                                                Código 2
                                            </td>
                                            <td style="padding-left: 5px;">
                                                <asp:TextBox ID="txtCodigo2Visualizacion" runat="server" Width="100px" Font-Names="Arial"
                                                    ForeColor="Blue" Font-Bold="True" ReadOnly="true"></asp:TextBox>
                                            </td>
                                            <td style="font-weight: bold; width: 80px; text-align: right">
                                                Descripcion
                                            </td>
                                            <td style="padding-left: 5px;">
                                                <asp:TextBox ID="txtDescripcionVisualizacion" runat="server" Width="280px" Font-Names="Arial"
                                                    ForeColor="Blue" Font-Bold="True" ReadOnly="true"></asp:TextBox>
                                            </td>
                                            <td style="font-weight: bold; width: 60px; text-align: right">
                                                Medida
                                            </td>
                                            <td style="padding-left: 5px;">
                                                <asp:TextBox ID="txtMedidaVisualizacion" runat="server" Width="230px" Font-Names="Arial"
                                                    ForeColor="Blue" Font-Bold="True" ReadOnly="true"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
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
    <div id="div_Editar" style="display: none;">
        <div class="ui-jqgrid
    ui-widget ui-widget-content ui-corner-all">
            <div class="ui-jqgrid-titlebar ui-widget-header
    ui-corner-top ui-helper-clearfix">
                EDICION Datos de LA Factura
            </div>
            <table cellpadding="0" cellspacing="0">
              
                <tr>
                    <td style="font-weight: bold">
                        <asp:Label ID="lblTipoFacturaEdicion" runat="server" Text="" Font-Bold="True"></asp:Label>
                    </td>
                    <td>
                        <table>
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtNroFacturaEditar" runat="server" Width="80px" ReadOnly="True"
                                        Font-Names="Arial" ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                </td>
                                <td style="font-weight: bold">
                                    Cliente
                                </td>
                                <td>
                                    <asp:TextBox ID="txtClienteEditar" runat="server" Width="320px" Font-Names="Arial"
                                        ForeColor="Blue" Font-Bold="True" ReadOnly="True"></asp:TextBox>
                                </td>
                                <td id="div_lblPlaca1Editar" style="font-weight: bold;">
                                    Placa
                                </td>
                                <td id="div_Placa1Editar">
                                    <asp:TextBox ID="txtPlaca1Editar" runat="server" Width="70px" Font-Names="Arial"
                                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                </td>
                                <td style="font-weight: bold">
                                    KM
                                </td>
                                <td>
                                    <asp:TextBox ID="txtKMEdicion" runat="server" Width="70px" Font-Names="Arial" ForeColor="Blue"
                                        Font-Bold="True"></asp:TextBox>
                                </td>
                                <td style="font-weight: bold;">
                                    <asp:CheckBox runat="server" ID="chkComisionableEdicion" Text="Comision" Font-Bold="True" />
                                </td>
                                <td style="font-weight: bold;">
                                    <asp:CheckBox runat="server" ID="chkMotorizadoEdicion" Text="Motorizado" Font-Bold="True" />
                                </td>
                                 
                                                    
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td style="font-weight: bold">
                        Emision
                    </td>
                    <td>
                        <table>
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtEmisionEdicion" runat="server" Width="80px" Font-Names="Arial"
                                        ForeColor="Blue" Font-Bold="True" ReadOnly="true"></asp:TextBox>
                                </td>
                                <td style="font-weight: bold;">
                                    Recepcion
                                </td>
                                <td>
                                    <asp:TextBox ID="txtRecepcion" runat="server" Width="56px" CssClass="Jq-ui-dtp" Font-Names="Arial"
                                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                </td>
                                <td style="font-weight: bold">
                                    Forma Pago
                                </td>
                                <td>
                                    <div id="div_FormaPagoEdicion">
                                        <asp:DropDownList ID="ddlFormaPagoEdicion" runat="server" Font-Names="Arial" ForeColor="Blue"
                                            Font-Bold="True" Width="85">
                                        </asp:DropDownList>
                                    </div>
                                </td>
                                <td style="font-weight: bold">
                                    Vencimiento
                                </td>
                                <td>
                                    <asp:TextBox ID="txtVencimientoEdicion" runat="server" Width="80px" Font-Names="Arial"
                                        ForeColor="Blue" Font-Bold="True" CssClass="Jq-ui-dtp" Enabled="false"></asp:TextBox>
                                </td>
                                <td style="font-weight: bold">
                                    Nro Operacion
                                </td>
                                <td>
                                    <asp:TextBox ID="txtNroOperacionEdicion" runat="server" Width="80px" Font-Names="Arial"
                                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                </td>
                                <td style="font-weight: bold">
                                    OC
                                </td>
                                <td>
                                    <asp:TextBox ID="txtNroOCEdicion" runat="server" Width="124px" Font-Names="Arial"
                                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                </td>
                           
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                <td style="font-weight: bold">
                VENDEDOR
                </td>
                <td>
                <table>
                <tr>
                 <td>
                     <div id="div_VendedorEdicion">
                          <asp:DropDownList ID="ddlVendedorEdicion" runat="server" Font-Names="Arial" ForeColor="Blue"
                               Font-Bold="True" Width="212">
                                </asp:DropDownList>
                     </div>
                </td>
                 <td style="font-weight: bold;display:none;">
                                    Nombre Agencia
                                </td>
                                <td style = "display:none;">
                                    <asp:TextBox ID="txtNombreAgencia" runat="server" Width="217px" Font-Names="Arial"
                                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                </td>
                          
                                        <td>
                                                        <asp:CheckBox ID="chkConCodigoEdicion" runat="server" Text="CON CODIGO" Font-Bold="True" />
                                                    </td>
                                                         <td>
                                                        <asp:CheckBox ID="chkUnitario" runat="server" Text="UNITARIO" Font-Bold="True" />
                                                    </td>
                </tr>
                </table>
                </td>
               
              
                </tr>
            </table>
            <div  style = "padding-top:5px;">
            
            </div>
            <div  class="ui-jqgrid-titlebar ui-widget-header ui-corner-top ui-helper-clearfix" >   
                Edicion de Datos de la guia REMISION
            </div>
             <div id="div_GuiaRemision2" ="ui-jqdialog-content">                 
                   <table cellpadding="0" cellspacing="0" width="750" class="form-inputs">
                                <tr>
                                    <td>
                                        <asp:CheckBox ID="chkGuiaEdicion" runat="server" Text="Guia Serie" Font-Bold="True" />
                                    </td>
                                    <td>
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <div id="div_serieguiaEdicion">
                                                        <asp:DropDownList ID="ddlSerieGuiaEdicion" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                            Font-Bold="True">
                                                        </asp:DropDownList>
                                                    </div>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtNumeroGuiaEdicion" runat="server" Width="50" Font-Names="Arial"
                                                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                                </td>
                                                 <td>
                                                                <div id="div_TipoTransportistaEdicion">
                                                                    <asp:DropDownList ID="ddlTipoTransportistaEdicion" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                                        Font-Bold="True">
                                                                    </asp:DropDownList>
                                                                </div>
                                                            </td>
                                                <td style="font-weight: bold; padding-left: 27px;">
                                                    Traslado
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtFechaTrasladoEdicion" runat="server" Width="55px" CssClass="Jq-ui-dtp"
                                                      ReadOnly="True"  Font-Names="Arial" ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                                </td>
                                                <td style="font-weight: bold; padding-left: 5px;color: #FF0000; font-size: small;">
                                                    Destino
                                                </td>
                                                <td style="padding-left: 10px;">
                                  
                                         <div id="Div_DireccionDestinoEdicion">
                                                            <asp:DropDownList ID="ddldireccionNuevaDestinoEdicion" runat="server" Font-Names="Arial" ForeColor="Red"
                                                                Font-Bold="True" Width="430">
                                                            </asp:DropDownList>
                                                        </div>
                                                            </td>
                                                <td>
                                <asp:ImageButton runat="server" ID="ImageButton3" ImageUrl="../Asset/images/add_small.png"
                                    ToolTip="DIRECCION" OnClientClick="F_DireccionesTemporal(hfCodigoTemporalEdicion,hfCodProvincia,hfCodDistrito,hfCodDepartamento,MainContent_txtDireccionMultiple,MainContent_txtDistritoMultiple,4,0); return false;" />
                                                            </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                             
                                <tr>
                                    <td style="font-weight: bold">
                                        Transportista
                                    </td>
                                    <td>
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                             <td>
                                               <asp:TextBox ID="txtNroRucTransportistaEdicion" runat="server" Width="70px" Font-Names="Arial"
                                                 ForeColor="Blue" Font-Bold="True" MaxLength="11" onblur="F_ValidaRucTransportistaEdicion(); return false;"></asp:TextBox>
                                             </td>
                                             <td id="td_loadingTransportistaEdicion" style="font-weight: bold; padding-left: 5px; display: none">
                                                  <img src="../Asset/images/loading.gif" />
                                             </td>
                                             <td>
                                                    <asp:TextBox ID="txtTransportistaEdicion" runat="server" Width="245px" Font-Names="Arial"
                                                      ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                               </td>
                                             <td style="font-weight: bold">
                                        Direccion
                                    </td>
                                             <td style="padding-left: 15px;">
                                  
                                         <div id="Div_DireccionTransportistaEdicion">
                                                            <asp:DropDownList ID="ddldireccionNuevaTransportistaEdicion" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                                Font-Bold="True" Width="430">
                                                            </asp:DropDownList>
                                                        </div>
                                                            </td>
                                             <td>
                                                            <asp:ImageButton runat="server" ID="ImageButton4" ImageUrl="../Asset/images/add_small.png"
                                                                ToolTip="DIRECCION" OnClientClick="F_DireccionesTemporal(hfCodigoTemporalEdicion,hfCodProvincia,hfCodDistrito,hfCodDepartamento,MainContent_txtDireccionMultiple,MainContent_txtDistritoMultiple,5,1); return false;" />
                                                            </td> 
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                                <tr>
                                    <td style="font-weight: bold">
                                      N° Bultos
                                    </td>
                                    <td>
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                             <td>
                                                                <asp:TextBox ID="txtNuBultosEdicion" runat="server" Width="80" Font-Names="Arial" ForeColor="Blue"
                                                                    Font-Bold="True" CssClass="Derecha"></asp:TextBox>
                                                            </td>
                                             <td style="font-weight: bold;padding-left:75px;">
                                                                Peso
                                                            </td>
                                             <td>
                                                                <asp:TextBox ID="txtPesoEdicion" runat="server" Width="80" Font-Names="Arial" ForeColor="Blue"
                                                                    Font-Bold="True" CssClass="Derecha"></asp:TextBox>
                                                            </td>
                                             <td>
                                                                <div id="div_codunidadpesoedicion">
                                                                    <asp:DropDownList ID="ddlcodunidadpesoedicion" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                                        Font-Bold="True">
                                                                    </asp:DropDownList>
                                                                </div>
                                                            </td>
                                             <td style="font-weight: bold; padding-left: 0px;">
                                                    Conductor
                                                </td>
                                             <td style="padding-left: 9px;">
                                                                <asp:TextBox ID="txtConductorDNIEdicion" runat="server" Width="80" Font-Names="Arial" ForeColor="Blue"
                                                                    Font-Bold="True" onblur="F_ValidaRucDniConductorEdicion(); return false;"></asp:TextBox>
                                                            </td>
                                             <td>
                                                                <asp:TextBox ID="txtConductorRazonSocialEdicion" runat="server" Width="357px" Font-Names="Arial"
                                                                    ForeColor="Blue" Font-Bold="True" placeholder="NOMBRE CONDUCTOR"></asp:TextBox>
                                                            </td>
                                             <td style="font-weight: bold;padding-left: 4px;">
                                                 
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                                <tr>
                                                <td style="font-weight: bold">
                                                         G.Agencia    
                                                            </td>      
                                                <td>
                                                <table>
                                                <tr>
                                                 <td style="padding-left:0px;">
                                    <asp:TextBox ID="txtGuiaAgencia" runat="server" Width="80px" Font-Names="Arial"
                                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                </td>
                                                 <td style="font-weight: bold;padding-left:70px;">
                                 C.AGENCIA
                                </td>
                                                 <td style="font-weight: bold;padding-left:0px;">
                                    <asp:TextBox ID="txtClaveAgencia" runat="server" Width="105px" Font-Names="Arial"
                                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                </td>
                                                 <td style="font-weight: bold;">
                                   Placa
                                </td>
                                                 <td style="padding-left: 34px;">
                                                   <asp:TextBox ID="txtPlacaTrasladoEdicion" runat="server" Width="80" Font-Names="Arial" ForeColor="Blue"
                                                                    Font-Bold="True"></asp:TextBox>
                                                </td>
                                                 <td style="font-weight: bold">
                                                    Marca
                                                </td>
                                                 <td>
                                                     <asp:TextBox ID="txtMarcaGuiaEdicion" runat="server" Width="105" Font-Names="Arial" ForeColor="Blue"
                                                                    Font-Bold="True"></asp:TextBox>
                                                </td>
                                                 <td style="font-weight: bold">
                                                    Licencia
                                                </td>
                                                 <td style="font-weight: bold">
                                                                <asp:TextBox ID="txtLicenciaGuiaEdicion" runat="server" Width="143" Font-Names="Arial" ForeColor="Blue"
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
                                                <td>
                                                <table  cellpadding="0" cellspacing="0">
                                                <tr>
                                                <td>
                                                                <asp:TextBox ID="txtObservacionGuiaEdicion" runat="server" Width="745" Font-Names="Arial" ForeColor="Blue"
                                                                    Font-Bold="True" ></asp:TextBox>
                                                            </td>
                                                <td>     
                                                            <asp:CheckBox ID="chkImpresionGuiaEdicion" runat="server" Text="IMPRIMIR GUIA" Font-Bold="True" />
                                                             </td>
                                                </tr>
                                                </table>
                                                </td>
                                                </tr>

                                                      
                                             
                                             
            
 </table>
                                                                        
            </div>
            <div class="linea-button">
                <asp:Button ID="btnEditarFactura" runat="server" Text="Guardar" class="ui-button
    ui-widget ui-state-default ui-corner-all ui-button-text-only" Font-Names="Arial" Font-Bold="True"
                    Width="120" />
            </div>
             <%--EdicionComision--%>
            <div>
           
            </div>
               
        </div>

 <div id="div_grvDetalleEdicion" style="padding-top: 5px;Width: 870px;">
                                    <asp:GridView ID="grvDetalleEdicion" runat="server" AutoGenerateColumns="False"
                                        border="0" CellPadding="0" CellSpacing="1" CssClass="GridView" GridLines="None"
                                        Width="1000px" >
                                         <Columns>
                                                       
                                                        <asp:BoundField DataField="Codigo" HeaderText="Codigo">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Left" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Descripcion" HeaderText="Descripcion">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Left" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Cantidad" HeaderText="Cantidad">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Right" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="UM" HeaderText="UM">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Left" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Precio" HeaderText="Precio">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Right" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Importe" HeaderText="Importe">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Right" />
                                                        </asp:BoundField>
                                                                 <asp:TemplateField HeaderText="Comision" ItemStyle-HorizontalAlign="Center">
                                                              <ItemTemplate>
                                                                 <asp:HyperLink runat="server" ID="lblimporte" Font-Underline="true" ForeColor="Blue"
                                                Style="cursor: hand" Text='<%# Bind("Importe") %>'
                                                ToolTip="MOTOR" onclick="F_AgregarMotor_Edicion(this.id); return false;">
                                            </asp:HyperLink>
                                                              </ItemTemplate>

                                
                                                

                                                          </asp:TemplateField>
                                                        <asp:BoundField DataField="OV" HeaderText="Anexo">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Anexo2" HeaderText="Anexo 2">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                             <asp:BoundField DataField="NCV" HeaderText="NCV">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                          <asp:TemplateField HeaderText="Comision" ItemStyle-HorizontalAlign="Center">
                                                              <ItemTemplate>
                                                                  <asp:TextBox runat="server" ID="txtComisionEdicion" Width="75px" Font-Bold="true" Style="text-align: center;"
                                                                      CssClass="ccsestilo" Font-Names="Arial" ForeColor="Blue" Text='<%# Bind("Comision") %>'
                                                                      ></asp:TextBox>
                                                                      <asp:HiddenField ID="hfComision" runat="server" Value='<%# Bind("Comision")    %>' />
                                                                      <asp:HiddenField ID="hfID" runat="server" Value='<%# Bind("ID")    %>' />
                                                                      <asp:HiddenField ID="hfImporte" runat="server" Value='<%# Bind("Importe")    %>' />
                                                              </ItemTemplate>
                                                          </asp:TemplateField>






                                                         
                                                    </Columns>
                                    </asp:GridView>
                                </div>
    </div>
    <div id="div_DetalleDeudasPopUp" style="display: none">
        <div id="div_DetalleDeudas">
            <asp:GridView ID="grvDetalleDeudas" runat="server" AutoGenerateColumns="False" border="0"
                CellPadding="0" CellSpacing="1" CssClass="GridView" GridLines="None" Width="1018px">
                <Columns>
                    <asp:BoundField DataField="Almacen" HeaderText="Almacen">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="NroDocumento" HeaderText="Nro. Documento">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Ruc" HeaderText="Ruc">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="RazonSocial" HeaderText="Razon Social">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Emision" HeaderText="Emision">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Vencimiento" HeaderText="Vencimiento">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Retraso" HeaderText="Retraso">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="MontoDeudaSoles" HeaderText="Deuda Soles">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Vendedor" HeaderText="Vendedor">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                </Columns>
            </asp:GridView>
        </div>

    </div>
    <div id="div_DireccionMultiple" style="display: none;">
        <table cellpadding="0" cellspacing="0">
            <tr>
                <td style="padding-top: 10px; font-weight: bold">
                    Distrito
                </td>
                <td style="padding-top: 10px;">
                    <asp:TextBox ID="txtDistritoMultiple" runat="server" Width="500px" Font-Names="Arial"
                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="padding-top: 5px; font-weight: bold">
                    Direccion
                </td>
                <td style="padding-top: 5px;">
                    <asp:TextBox ID="txtDireccionMultiple" runat="server" Width="500px" Font-Names="Arial"
                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="padding-top: 5px; font-weight: bold">
                    Email 1
                </td>
                <td style="padding-top: 5px;">
                    <asp:TextBox ID="txtEmailMultiple1" runat="server" Width="500px" Font-Names="Arial"
                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="padding-top: 5px; font-weight: bold">
                    Email 2
                </td>
                <td style="padding-top: 5px;">
                    <asp:TextBox ID="txtEmailMultiple2" runat="server" Width="500px" Font-Names="Arial"
                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                </td>
            </tr>
            <tr  style="display:none">
                <td style="padding-top: 5px; font-weight: bold">
                    Email 3
                </td>
                <td style="padding-top: 5px;">
                    <asp:TextBox ID="txtEmailMultiple3" runat="server" Width="500px" Font-Names="Arial"
                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                </td>
            </tr>
            <tr  style="display:none">
                <td style="padding-top: 5px; font-weight: bold">
                    Email 4
                </td>
                <td style="padding-top: 5px;">
                    <asp:TextBox ID="txtEmailMultiple4" runat="server" Width="500px" Font-Names="Arial"
                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                </td>
            </tr>
            <tr  style="display:none">
                <td style="padding-top: 5px; font-weight: bold">
                    Email 5
                </td>
                <td style="padding-top: 5px;">
                    <asp:TextBox ID="txtEmailMultiple5" runat="server" Width="500px" Font-Names="Arial"
                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                </td>
            </tr>
            <tr style="display:none">
                <td style="padding-top: 5px; font-weight: bold">
                    Email 6
                </td>
                <td style="padding-top: 5px;">
                    <asp:TextBox ID="txtEmailMultiple6" runat="server" Width="500px" Font-Names="Arial"
                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" colspan="2">
                    <asp:Button ID="btnGrabarDireccion" runat="server" Text="GRABAR" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                        Font-Names="Arial" Font-Bold="True" Width="120" />
                </td>
            </tr>
            <tr>
                <td style="padding-top: 5px;" colspan="2">
                    <div id="div_DireccionTemporal">
                        <asp:GridView ID="grvDireccion" runat="server" AutoGenerateColumns="False" border="0"
                            CellPadding="0" CellSpacing="1" CssClass="GridView" GridLines="None" Width="860px"
                            OnRowDataBound="grvDetalleDireccionTemporal_RowDataBound">
                            <Columns>
                                <asp:TemplateField ItemStyle-HorizontalAlign="Center" >
                                    <ItemTemplate>
                                        <asp:ImageButton runat="server" ID="imgAnularDocumento" ImageUrl="~/Asset/images/EliminarBtn.png"
                                            ToolTip="Eliminar Direccion" OnClientClick="F_EliminarDireccion(hfCodigoTemporal,hfCodDireccionTemporal,MainContent_ddldireccionNueva,MainContent_txtDistritoMultiple); return false;" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-HorizontalAlign="Center" >
                                    <ItemTemplate>
                                        <asp:ImageButton runat="server" ID="imgEditarRegistro" ImageUrl="../Asset/images/btnEdit.gif"
                                            ToolTip="Editar Direccion" OnClientClick="F_EditarRegistroDireccion(this); return false;" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ID">
                                    <ItemStyle HorizontalAlign="Right" />
                                    <ItemTemplate>
                                        <asp:Label       ID="lblCoddirecciontemporal"   runat="server"  Text='<%# Bind("CodDocumentoVentaDireccion") %>'></asp:Label>
                                        <asp:HiddenField ID="hfTemporal"       runat="server" Value='<%# Bind("CodDocumentoVenta") %>' />
                                        <asp:HiddenField ID="hfCodDistrito"     runat="server" Value='<%# Bind("CodDistrito") %>' />
                                        <asp:HiddenField ID="hfCodProvincia" runat="server" Value='<%# Bind("CodProvincia") %>' />
                                        <asp:HiddenField ID="hfCodDepartamento"    runat="server" Value='<%# Bind("CodDepartamento") %>' />
                                        <asp:HiddenField ID="hfCorreo1"       runat="server" Value='<%# Bind("Correo1") %>' />
                                        <asp:HiddenField ID="hfCorreo2"           runat="server" Value='<%# Bind("Correo2") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                              
                                <asp:TemplateField HeaderText="Distrito" HeaderStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="left" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblDistrito" Text='<%# Bind("distrito") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Direccion" HeaderStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="left" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblDireccion" Text='<%# Bind("Direccion") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Correo" HeaderStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblCorreo1" Text='<%# Bind("Correo1") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
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
    <div id="div_GuiaConsignacion" style="display: none;">
        <div class="ui-jqdialog-content">
            <table>
                <tr>
                    <td style="font-weight: bold">
                        Numero Guia
                    </td>
                    <td style="padding-left: 5px;">
                        <asp:TextBox ID="txtGuia" runat="server" Width="100px" Font-Names="Arial" ForeColor="Blue"
                            Font-Bold="True" Font-Size="Small"></asp:TextBox>
                    </td>
                    <td style="padding-left: 10px;">
                        <asp:Button ID="btnFacturarGuia" runat="server" Text="Facturar" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                            Font-Names="Arial" Font-Bold="True" Width="120" />
                    </td>
                </tr>
            </table>
        </div>
    </div>

    <div id="div_FacturarCotizacion" style="display: none;">
        <div class="ui-jqdialog-content">
            <table>
                <tr>
                    <td>
                        Numero Cotizacion
                    </td>
                    <td style="padding-left: 5px;">
                        <%-- <asp:TextBox
    ID="txtCodCotizacion" runat="server" Width="150px" Font-Names="Arial" ForeColor="Blue"
    Font-Bold="True" Font-Size="Small"></asp:TextBox>--%>
                    </td>
                    <td style="padding-left: 5px;">
                        <asp:Button ID="btnFacturarCotizacion" runat="server" Text="Facturar" class="ui-button
    ui-widget ui-state-default ui-corner-all ui-button-text-only" Font-Names="Arial" Font-Bold="True" />
                    </td>
                </tr>
            </table>
        </div>
    </div>

    <div id="div_Devolucion" style="display: none;">
        <table cellpadding="0" cellspacing="0" width="850">
           <tr>
           <td>
           <table>
                
                
                <tr>
                <td style="padding-top: 5px;" colspan='9'>
                <div>
                <table>
                <tr>
                <td>
                <asp:Label ID="lblFacturaDevolucion" style="font-size: medium; color: #000000" runat="server" Text="" Font-Bold="True"></asp:Label>
                </td>
                <td>
                <asp:Label ID="lblClienteDevolucion" style="font-size: medium; color: #000000" runat="server" Text="" Font-Bold="True"></asp:Label>
                </td>
                <td style="font-weight: bold;padding-top:5px;"  align="right">
                     <asp:Button ID="btnAgregarDevolucion" runat="server" Text="Devolucion" class="ui-button ui-widget
                      ui-state-default ui-corner-all ui-button-text-only" Font-Names="Arial" Font-Bold="True" Width="120" />
                </td>
                </tr>
                <tr>
                
                </tr>
                <tr>
                <td></td>
                                    <td style="font-weight: bold">
                                        Cantidad de Registros:
                                    </td>
                                    <td style="font-weight: bold">
                                        <label id="lblcantidadDevolucion">
                                        </label>
                                    </td>
                                </tr>
                </table>
                </div>

                    <div id="div_DevolucionDetalle">
                        <asp:GridView ID="grvDetalleDevolcion" runat="server" AutoGenerateColumns="False" border="0"
                            CellPadding="0" CellSpacing="1" CssClass="GridView" GridLines="None" Width="960px">
                            <Columns>
                                <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:CheckBox runat="server" ID="chkEliminar" CssClass="chkDelete" Text="" onclick="F_ValidarCheck_Devolucion(this.id);" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Descripcion">
                                    <ItemStyle HorizontalAlign="left" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblNumero" Text='<%# Bind("Descripcion") %>' CssClass="ccsestilo"></asp:Label>
                                          <asp:HiddenField runat="server" ID="hfCodDetalle" Value='<%# Bind("ID") %>' />
                                        <asp:HiddenField ID="hfCodArticulo" runat="server" Value='<%# Bind("Codigo") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Marca" HeaderText="Marca">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                              
                                <asp:TemplateField HeaderText="Cantidad">
                                    <ItemStyle HorizontalAlign="Right" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblCantidad" Text='<%# Bind("Cantidad") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="UM">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblUM" Text='<%# Bind("UM") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Precio">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblPrecio" Text='<%# Bind("Precio") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Importe">
                                    <ItemStyle HorizontalAlign="Right" />
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblImporte" Text='<%# Bind("Importe") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="OV" HeaderText="OV">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                               
                                <asp:TemplateField HeaderText="Cantidad" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:TextBox runat="server" ID="txtCantidadEntregada" Width="55px" CssClass="ccsestilo"
                                            Style="text-align: center;" Font-Names="Arial" ForeColor="Blue" Font-Bold="True"
                                            onblur="F_ValidarStockGrillaDevolucion(this.id);" Enabled="False"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </td>
            </tr>
           </table>
           </td>
           </tr>                               
        </table>
    </div>

    <div id="div_EditarMotor" style="display: none;">
        <div class="ui-jqdialog-content">
            <table cellpadding="0" cellspacing="0" class="form-inputs">
                <tr>
                    <td colspan="2">
                        <asp:Button ID="btnGrabarMotor" runat="server" Text="Grabar" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                            Font-Names="Arial" Font-Bold="True" Width="120" />
                    </td>
                </tr>
                <tr>
                 <td style="font-weight: bold;">
                 MOTOR SEMI ARMADO
                 </td>
                 <td>
                  <table cellpadding="0" cellspacing="0">
                 <tr>
                  <td>
                        <asp:TextBox ID="txtMotorSA" runat="server" Width="400px" Font-Names="Arial" ForeColor="Blue"
                            Font-Bold="True"  ></asp:TextBox>
                    </td>
                 </tr>
                 </table>
                 </td>
                </tr>
                
                   <tr>
                 <td style="font-weight: bold;">
                 MARCA MOTOR
                 </td>
                 <td>
                  <table cellpadding="0" cellspacing="0">
                 <tr>
                  <td>
                        <asp:TextBox ID="txtMarcaMotor" runat="server" Width="400px" Font-Names="Arial" ForeColor="Blue"
                            Font-Bold="True"  ></asp:TextBox>
                    </td>
                   
                 </tr>
                 </table>
                 </td>
                </tr>


                 <tr>
                 <td style="font-weight: bold;">
                 SERIE MOTOR 
                 </td>
                 <td>
                  <table cellpadding="0" cellspacing="0">
                 <tr>
                  <td>
                        <asp:TextBox ID="txtSerieMotor" runat="server" Width="400px" Font-Names="Arial" ForeColor="Blue"
                            Font-Bold="True"  ></asp:TextBox>
                    </td>
                 </tr>
                 </table>
                 </td>
                </tr>

                     <tr>
                 <td style="font-weight: bold;">
                 CILINDRADA
                 </td>
                 <td>
                  <table cellpadding="0" cellspacing="0">
                 <tr>
                   <td >
                     <asp:TextBox ID="txtCilindrado" runat="server" Width="400px" Font-Names="Arial"
                         ForeColor="Blue" Font-Bold="True" ></asp:TextBox>
                    </td>
                 </tr>
                 </table>
                 </td>
                </tr>

                 <tr>
                 <td style="font-weight: bold;">
                 CILINDROS
                 </td>
                 <td>
                  <table cellpadding="0" cellspacing="0">
                 <tr>
                  <td>
                        <asp:TextBox ID="txtCilindros" runat="server" Width="400px" Font-Names="Arial" ForeColor="Blue"
                            Font-Bold="True" ></asp:TextBox>
                    </td>
                 </tr>
                 </table>
                 </td>
                </tr>


                         <tr>
                <td style="font-weight: bold;">
                 COMBUSTIBLE
                 </td>
                 <td>
                  <table cellpadding="0" cellspacing="0">
                 <tr>
                   <td >
                     <asp:TextBox ID="txtCombustible" runat="server" Width="400px" Font-Names="Arial"
                         ForeColor="Blue" Font-Bold="True" ></asp:TextBox>
                    </td>
                 </tr>
                 </table>
                 </td>
                </tr>


                 <tr>
                 <td style="font-weight: bold;">
                 POTENCIA    
                 </td>
                 <td>
                  <table cellpadding="0" cellspacing="0">
                 <tr>
                  <td>
                        <asp:TextBox ID="txtPotencia" runat="server" Width="400px" Font-Names="Arial" ForeColor="Blue"
                            Font-Bold="True"  ></asp:TextBox>
                    </td>
                    <td style="font-weight: bold;display:none">
                 Codigo
                 </td>
                    <td style="font-weight: bold;display:none">
                     <asp:TextBox ID="txtAdicional1" runat="server" Width="150px" Font-Names="Arial"
                         ForeColor="Blue" Font-Bold="True" ReadOnly="True"></asp:TextBox>
                    </td>
                 </tr>
                 </table>
                 </td>
                
                   
                </tr>

                 <tr>
                 <td style="font-weight: bold;display:none">
                 Codigo
                 </td>
                 <td>
                  <table cellpadding="0" cellspacing="0">
                 <tr>
                  <td style="font-weight: bold;display:none">
                        <asp:TextBox ID="txtAdicional2" runat="server" Width="150px" Font-Names="Arial" ForeColor="Blue"
                            Font-Bold="True" ReadOnly="True" ></asp:TextBox>
                    </td>
                    <td style="font-weight: bold;display:none">
                 Codigo
                 </td>
                    <td style="font-weight: bold;display:none">
                     <asp:TextBox ID="txtAdicional3" runat="server" Width="150px" Font-Names="Arial"
                         ForeColor="Blue" Font-Bold="True" ReadOnly="True"></asp:TextBox>
                    </td>
                 </tr>
                 </table>
                 </td>
                
                   
                </tr>

                 <tr>
                 <td style="font-weight: bold;display:none">
                 Codigo
                 </td>
                 <td>
                  <table cellpadding="0" cellspacing="0">
                 <tr>
                  <td style="font-weight: bold;display:none">
                        <asp:TextBox ID="txtAdicional4" runat="server" Width="150px" Font-Names="Arial" ForeColor="Blue"
                            Font-Bold="True" ReadOnly="True" ></asp:TextBox>
                    </td>
                    <td style="font-weight: bold;display:none">
                 Codigo
                 </td>
                    <td style="font-weight: bold;display:none">
                     <asp:TextBox ID="txtAdicional5" runat="server" Width="150px" Font-Names="Arial"
                         ForeColor="Blue" Font-Bold="True" ReadOnly="True"></asp:TextBox>
                    </td>
                 </tr>
                 </table>
                 </td>
                
                   
                </tr>
                        
            </table>
        </div>
    </div>

    <input id="hfCodCtaCte" type="hidden" value="0" />
    <input id="hfCodCtaCteEdicion" type="hidden" value="0" />
    <input id="hfCodCtaCteConsulta" type="hidden" value="0" />
    <input id="hfCodigoTemporal" type="hidden" value="0" />
    <input id="hfCodDocumentoVenta" type="hidden" value="0" />
    <input id="hfNotaPedido" type="hidden" value="0" />
    <input id="hfCodCtaCteNP" type="hidden" value="0" />
    <input id="hfCodUsuario" type="hidden" value="0" />   
    <input id="hfCodProforma" type="hidden" value="0" />
    <input id="hfCodTraslado" type="hidden" value="0" />
    <input id="hfCodSede" type="hidden" value="0" />
    <input id="hfCodTipoCliente" type="hidden" value="2" />
    <input id="hfCodDireccion" type="hidden" value="2" />
    <input id="hfCodTipoDoc2" type="hidden" value="2" />
    <input id="hfNroRuc" type="hidden" value="" />
    <input id="hfDistrito" type="hidden" value="" />
    <input id="hfDireccion" type="hidden" value="" />
    <input id="hfCliente" type="hidden" value="" />
    <input id="hfCodTransportista" type="hidden" value="0" />
    <input id="hfNumeroAnterior" type="hidden" value="0" />
    <input id="hfSaldoCreditoFavor" type="hidden" value="0" />
    <input id="hfCodFacturaEdicion" type="hidden" value="0" />
    <input id="hfCodProductoAgregar" type="hidden" value="0" />
    <input id="hfMenorPrecioAgregar" type="hidden" value="0" />
    <input id="hfCostoAgregar" type="hidden" value="0" />
    <input id="hfCodUmAgregar" type="hidden" value="0" />
    <input id="hfDireccionFacturaEditar" type="hidden" value="0" />
    <input id="hfDireccionTransportista" type="hidden" value="" />
    <input id="hfCodDireccionDefecto" type="hidden" value="0" />
    <input id="hfCodDocumentoVentaDescargaCDR" type="hidden" value="0" />
    <input id="hfCodTipoDocAnulacion" type="hidden" value="0" />
    <input id="hfCodDocumentoVentaAnulacion" type="hidden" value="0" />
    <input id="hfClienteAnulacion" type="hidden" value="0" />
    <input id="hfNumeroAnulacion" type="hidden" value="0" />
    <input id="hfCodDetalle" type="hidden" value="0" />
    <input id="hftokenapisunat" type="hidden" value="0" />
    <input id="hfurlapisunat" type="hidden" value="0" />
    <input id="hfCodTipoDoc_grilla" type="hidden" value="0" />
    <input id="hfimgID" type="hidden" value="0" />
    <input id="hfCodConductor" type="hidden" value="0" />
    <input id="hfLimiteMayorista" type="hidden" value="0"/>
    <input id="hfCantidadMayorista" type="hidden" value="0"/>
    <input id="hfPrecio1" type="hidden" value="0"/>
    <input id="hfCodCtaCteTransportistaEdicion" type="hidden" value="0" />
    <input id="hfTransportistaEdicion" type="hidden" value="" />
    <input id="hfCodDireccionTransportistaEdicion" type="hidden" value="0" />
    <input id="hfRucTransportistaEdicion" type="hidden" value="" />
    <input id="hfNroRucTransportistaEdicion" type="hidden" value="" />
    <input id="hfDireccionTransportistaEdicion" type="hidden" value="" />
    <input id="hfRazonSocialTransportistaEdicion" type="hidden" value="" />
    <input id="hfCodDepartamentoTransportistaEdicion" type="hidden" value="0" />
    <input id="hfCodProvinciaTransportistaEdicion" type="hidden" value="0" />
    <input id="hfCodDistritoTransportistaEdicion" type="hidden" value="0" />
    <input id="hfDistritoTrasladoEdicion" type="hidden" value="" />
    <input id="hfCodDireccionDefectoTransportistaEdicion" type="hidden" value="0" />
    <input id="hfCodTransportistaEdicion" type="hidden" value="0" />
    <input id="hfCodCtaCteTransportista" type="hidden" value="0" />
    <input id="hfTransportista" type="hidden" value="" />
    <input id="hfRucTransportista" type="hidden" value="" />
    <input id="hfNroRucTransportista" type="hidden" value="" />  
    <input id="hfRazonSocialTransportista" type="hidden" value="" />
    <input id="hfCodDepartamentoTransportista" type="hidden" value="0" />
    <input id="hfCodProvinciaTransportista" type="hidden" value="0" />
    <input id="hfCodDistritoTransportista" type="hidden" value="0" />
    <input id="hfDistritoTransportista" type="hidden" value="" />
    <input id="hfDistritoTraslado" type="hidden" value="" />
    <input id="hfNroRucCliente" type="hidden" value="" />
    <input id="hfCodDireccionDefectoTransportista" type="hidden" value="0" />
    <input id="hfCodigoTemporalEdicion" type="hidden" value="0" />
    <input id="hfCodCategoria" type="hidden" value="1" />
    <input id="hfnombretransportista" type="hidden" value="0" />
    <input id="hfDepartamento" type="hidden" value="0" />
    <input id="hfProvincia" type="hidden" value="0" />
    <input id="hfDniConductor" type="hidden" value="0" />
    <input id="hfCodDepartamento" type="hidden" value="0" />
    <input id="hfCodProvincia" type="hidden" value="0" />
    <input id="hfCodDistrito" type="hidden" value="0" />
    <input id="hfCodFacturaAnterior" type="hidden" value="0" />
    <input id="hfCodDetalleMotor" type="hidden" value="0" />
    <input id="DescripcionMotor" type="hidden" value="0" />
    <input id="hfMotorEdicion" type="hidden" value="0" />
</asp:Content>
