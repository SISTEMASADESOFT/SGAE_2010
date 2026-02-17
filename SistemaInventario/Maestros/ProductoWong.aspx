<%@ Page Title="Productos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ProductoWong.aspx.cs" Inherits="SistemaInventario.Maestros.ProductoWong" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="../Asset/js/jquery-1.10.2.js" type="text/javascript"></script>
    <script src="../Asset/js/jquery-ui-1.10.4.custom.js" type="text/javascript"></script>
    <script src="../Asset/js/jquery-ui-1.10.4.custom.min.js" type="text/javascript"></script>
    <script src="../Asset/js/jquery.timers.js" type="text/javascript"></script>
    <script src="../Asset/js/jq-ui/1.10.2/development-bundle/ui/i18n/jquery.ui.datepicker-es.js" type="text/javascript"></script>       
    <script src="../Asset/js/autoNumeric-1.4.3.js" type="text/javascript"></script>
    <script src="../Asset/js/js.js" type="text/javascript"></script>    
    <script src="../Scripts/utilitarios.js" type="text/javascript" language="javascript"   charset="UTF-8"></script>     
    <script type="text/javascript" language="javascript" src="ProductoWong.js" charset="UTF-8"></script>
    <link href="../Asset/css/redmond/jquery-ui-1.10.4.custom.css" rel="stylesheet" type="text/css" />
    <link href="../Asset/css/Redmond/jquery-ui-1.10.4.custom.min.css" rel="stylesheet"   type="text/css" />     
    <link href="../Asset/css/style.css" rel="stylesheet" type="text/css" />
     <link href="../Asset/toars/toastr.min.css" rel="stylesheet" type="text/css" />
    <script src="../Asset/toars/toastr.min.js" type="text/javascript"></script>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="titulo">
        Productos</div>
    <div id="divTabs" style="width: 1150px; height: 100%;">
        <ul>
            <li id="liRegistro"><a href="#tabRegistro">Registro</a></li>
            <li id="liConsulta"><a href="#tabConsulta" onclick="getContentTab();">Consulta</a></li>
            <li id="liImagen"><a href="#tabImagen" onclick="getContentTab();">Imagen</a></li>
        </ul>

        <div id="tabRegistro" >

            <table cellpadding="0" cellspacing="0" class="form-inputs">
                <tr >

                    <td valign="top">
                        <%--DATOS DEL PRODUCTO--%>
                        <div class="ui-jqgrid ui-widget ui-widget-content ui-corner-all" style="width: 505px;">
                            <div class="ui-jqgrid-titlebar ui-widget-header ui-corner-top ui-helper-clearfix">
                                REGISTRO DE PRODUCTOS
                            </div>
                            <div>
                                <table cellpadding="0" cellspacing="0" class="form-inputs" >
                                    <tr>
                                        <td style="font-weight: bold; width: 120">
                                            Codigo Interno
                                        </td>
                                        <td>
                                            <table cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td>
                                                        <asp:TextBox ID="txtCodigoInterno" runat="server" Width="145px" Font-Names="Arial"
                                                            ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                                    </td>
                                                
                                                </tr>
                                            </table>
                                        </td>
                                  </tr>
                                    <tr>
                                        <td style="font-weight: bold">
                                            Ref OEM
                                        </td>
                                        <td>
                                            <table cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td>
                                                        <asp:TextBox ID="txtRefOEM" runat="server" Width="145px" Font-Names="Arial" ForeColor="Blue"
                                                            Font-Bold="True" ></asp:TextBox>
                                                    </td>
                                                    <td style="font-weight: bold ;padding-left:5px;">
                                                        Codigo Barra
                                                    </td>
                                                    <td style="padding-left: 9px;">
                                                        <asp:TextBox ID="txtCodigoBarra" runat="server" Width="140px" Font-Names="Arial" ForeColor="Blue"
                                                            Font-Bold="True"></asp:TextBox>
                                                    </td>
                                               
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>

                                        <td style="font-weight: bold">
                                            Codigo Prov.
                                        </td>
                                        <td>
                                            <table cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td>
                                                        <asp:TextBox ID="txtCodigoProveedor" runat="server" Width="145px" Font-Names="Arial" ForeColor="Blue"
                                                            Font-Bold="True" ></asp:TextBox>
                                                    </td>
                                                      <td style="font-weight: bold ;padding-left:6px;">
                                                      Proveedor   
                                                    </td>
                                                    <td style="padding-left: 24px;">
                                                        <asp:TextBox ID="txtProveedor" runat="server" Width="140px" Font-Names="Arial" ForeColor="Blue"
                                                            Font-Bold="True"></asp:TextBox>
                                                    </td>
                                               
                                                </tr>
                                            </table>
                                        </td>

                                    </tr>
                                    <tr>
                                     
                                        <td style="font-weight: bold">
                                         Codigo Fab
                                        </td>
                                        <td>
                                            <table cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td>
                                                        <asp:TextBox ID="txtCodigoFabricante" runat="server" Width="145px" Font-Names="Arial" ForeColor="Blue"
                                                            Font-Bold="True"></asp:TextBox>
                                                    </td>
                                                      <td style="font-weight: bold ;padding-left:6px;">
                                                      Equivalente 
                                                    </td>
                                                    <td style="padding-left: 17px;">
                                                        <asp:TextBox ID="txtEquivalente" runat="server" Width="140px" Font-Names="Arial" ForeColor="Blue"
                                                            Font-Bold="True"></asp:TextBox>
                                                    </td>
                                               
                                                </tr>
                                            </table>
                                        </td>

                                     

                                    </tr>
                                   <tr>

                                        <td style="font-weight: bold">
                                            Tipo Producto
                                        </td>
                                  
                                               <td  style="padding-left: 4px">
                                                        <asp:TextBox ID="txtTipoProducto" runat="server" Width="387px" Font-Names="Arial" ForeColor="Blue"
                                                            Font-Bold="True"></asp:TextBox>
                                                    </td>
                                 

                                    </tr>
                                       <tr>

                                        <td style="font-weight: bold">
                                            Desc Modelo
                                        </td>
                                                                                    
                                                    <td style="padding-left: 4px">
                                                        <asp:TextBox ID="txtDescripcionModelo" runat="server" Width="387px" Font-Names="Arial" ForeColor="Blue"
                                                            Font-Bold="True" CssClass="Derecha"></asp:TextBox>
                                                    </td>
                                                   
                                                

                                       </tr>
                                     <tr>
                                        <td style="font-weight: bold; width: 120">
                                            Nombre Fact
                                        </td>
                                        <td>
                                            <table cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td>
                                                        <asp:TextBox ID="txtNombreFact" runat="server" Width="385px" Font-Names="Arial"
                                                            ForeColor="Blue" Font-Bold="True" ></asp:TextBox>
                                                    </td>
                                                
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>

                                      <tr>
                                        <td style="font-weight: bold; width: 120">
                                            Desc Sistema
                                        </td>
                                        <td>
                                            <table cellpadding="0" cellspacing="0">
                                                <tr>
                                                  <td>
                                                    <asp:TextBox ID="txtDescSistema" runat="server" Width="385px" Height="23px" Font-Names="Arial"
                                                        ForeColor="Blue" Font-Bold="True" TextMode="MultiLine" Rows="4"></asp:TextBox>
                                                </td>

                                                
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>

                                    <tr>

                                        <td style="font-weight: bold">
                                            Marca Fab
                                        </td>
                                        <td colspan='5'>
                                            <table cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td style="padding-left: 2px;">
                                                        <div id="div_MarcaFab">
                                                            <asp:DropDownList ID="ddlMarcaFab" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                                Font-Bold="True" Width="149">
                                                            </asp:DropDownList>
                                                        </div>
                                                    </td>
                                               <td style="font-weight: bold ;padding-left:6px;">
                                                        Pais Origen
                                                    </td>
                                                    <td style="padding-left: 20px;">
                                                        <div id="div_PaisOrigen">
                                                            <asp:DropDownList ID="ddlPaisOrigen" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                                Font-Bold="True" Width="144">
                                                            </asp:DropDownList>
                                                        </div>
                                                    </td>
                                               
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>

                                          <td style="font-weight: bold">
                                           Und Venta
                                        </td>
                                        <td colspan='5'>
                                            <table cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td style="padding-left: 2px;">
                                                        <div id="div_UndVenta">
                                                            <asp:DropDownList ID="ddlUndVenta" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                                Font-Bold="True" Width="149">
                                                            </asp:DropDownList>
                                                        </div>
                                                    </td>
                                                      <td style="font-weight: bold ;padding-left:6px;">
                                                       Peso Total
                                                    </td>
                                                      <td style="padding-left: 21px;">
                                                        <asp:TextBox ID="txtPesoTotal" runat="server" Width="140px" Font-Names="Arial"
                                                            ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                                    </td>
                                                 
                                               
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                         <tr>

                                        <td style="font-weight: bold">
                                         M1
                                        </td>
                                        <td>
                                            <table cellpadding="0" cellspacing="0">
                                                <tr>
                                                  <td>
                                                    <asp:TextBox ID="txtM1" runat="server" Width="55px" Font-Names="Arial" ForeColor="Blue"
                                                        Font-Bold="True" placeholder="0.00" style="text-align: right;"></asp:TextBox>
                                                 </td>

                                                    <td style="font-weight: bold; padding-left: 10px;">
                                                      M2 
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtM2" runat="server" Width="56px" Font-Names="Arial" ForeColor="Blue"
                                                            Font-Bold="True" placeholder="0.00" style="text-align: right;"></asp:TextBox>
                                                    </td>

                                                      <td style="padding-left: 5px;">
                                         <asp:CheckBox ID="chkControlStock" runat="server" Text="Control Stock"
                                             Font-Bold="True" />
                                     </td>
                                               
                                                </tr>
                                            </table>
                                        </td>

                                     

                                    </tr>
                                </table>
                            </div>


                           
                        </div>
                    </td>


                   <%-- ******************************COLUMNA LADO IZQUIERDO--%>
                    <td valign="top">
    <%--DATOS DEL ARTICULO--%>
    <div class="ui-jqgrid ui-widget ui-widget-content ui-corner-all" style="width: 610px;">

        <div class="ui-jqgrid-titlebar ui-widget-header ui-corner-top ui-helper-clearfix">
            PRODUCTOS OPCIONALES
        </div>
        <div>
            <table cellpadding="0" cellspacing="0" class="form-inputs">
                <tr>
                
                    <td>
                                            <table cellpadding="0" cellspacing="0">
                                                <tr>
                                                  <td>


                        <div style="text-align: center;">
                            <label style="font-weight: bold; display: block;">
                               Nombre Med
                            </label>
                            <asp:TextBox ID="txtNombreMed" runat="server" Width="190px" Font-Names="Arial" ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                        </div>

                    </td>
                                                  <td>
                        <div style="text-align: center;">
                            <label style="font-weight: bold; display: block;">
                                Medida 1
                            </label>
                            <asp:TextBox ID="txtMedida1" runat="server" Width="190px" Font-Names="Arial" ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                        </div>
                    </td>
                                                  <td>
                        <div style="text-align: center;">
                            <label style="font-weight: bold; display: block;">
                                Medida 2
                            </label>
                            <asp:TextBox ID="txtMedida2" runat="server" Width="190px" Font-Names="Arial" ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                        </div>
                    </td>
                                               
                                                </tr>
                                            </table>
                                        </td>

                </tr>

                <tr>
                <td style="text-align: center">
                    <table cellpadding="0" cellspacing="0">
                      <tr>
                          <div class="ui-jqgrid-titlebar ui-widget-header ui-corner-top ui-helper-clearfix" style="height:15px;width:590px">
                                    UBICACIONES
                            </div>
                                   
                      </tr>
                    </table>
                     </td>


               </tr>

                <tr >
                 
                    <td>
                      <table cellpadding="0" cellspacing="0">
                        <tr>
                        <td>
                        <label style="font-weight: bold; display: block; text-align: center; width: 120px;">
                            Tipo
                        </label>
                          <asp:TextBox ID="txtTipo" runat="server" Width="110px" Font-Names="Arial" ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                    </td>
                        <td >
                        <div style="text-align: center;">
                            <label style="font-weight: bold; display: block;">
                                Almacen
                            </label>
                            <asp:TextBox ID="txtAlmacen" runat="server" Width="110px" Font-Names="Arial" ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                        </div>
                    </td>
                        <td>
                        <div style="text-align: center;">
                            <label style="font-weight: bold; display: block;">
                                Rack
                            </label>
                            <asp:TextBox ID="txtRack" runat="server" Width="60px" Font-Names="Arial" ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                        </div>
                    </td>
                        <td>
                        <div style="text-align: center;">
                            <label style="font-weight: bold; display: block;">
                                Nivel
                            </label>
                            <asp:TextBox ID="txtNivel" runat="server" Width="60px" Font-Names="Arial" ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                        </div>
                    </td>
                        <td>
                        <div style="text-align: center;">
                            <label style="font-weight: bold; display: block;">
                                Zona
                            </label>
                            <asp:TextBox ID="txtZona" runat="server" Width="60px" Font-Names="Arial" ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                        </div>
                    </td>
                        <td>
                        <div style="text-align: center;">
                            <label style="font-weight: bold; display: block;">
                                Caja
                            </label>
                            <asp:TextBox ID="txtCaja" runat="server" Width="60px" Font-Names="Arial" ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                        </div>
                    </td>
                        <td>
                        <div style="text-align: center;">
                            <label style="font-weight: bold; display: block;">
                                Mostrador
                            </label>
                            <asp:TextBox ID="txtMostrador" runat="server" Width="60px" Font-Names="Arial" ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                        </div>
                    </td>
                       
                        </tr>
                    </table>
                     </td>

                </tr>

                <tr>
                <td style="text-align: center">
                    <table cellpadding="0" cellspacing="0">
                      <tr>
                          <div class="ui-jqgrid-titlebar ui-widget-header ui-corner-top ui-helper-clearfix" style="height:15px;width:590px">
                                    Informacion de Vehiculos
                            </div>
                                   
                      </tr>
                    </table>
                     </td>


               </tr>

                <tr>
                
                    <td>
                                            <table cellpadding="0" cellspacing="0">
                                                <tr>
                                                  <td>
                        <label style="font-weight: bold; display: block; text-align: center; width: 120px;">
                            Marca 1
                        </label>
                          <div id="div_Marca1">
                              <asp:DropDownList ID="ddlMarca1" runat="server" Font-Names="Arial" ForeColor="Blue"
                                  Font-Bold="True" Width="130">
                              </asp:DropDownList>
                             </div>
                    </td>
                                                  <td>
                        <div style="text-align: center;">
                            <label style="font-weight: bold; display: block;">
                             Marca 2
                            </label>
                              <div id="div_Marca2">
                              <asp:DropDownList ID="ddlMarca2" runat="server" Font-Names="Arial" ForeColor="Blue"
                                  Font-Bold="True" Width="130">
                              </asp:DropDownList>
                             </div>
                        </div>
                    </td>
                                                  <td>
                        <div style="text-align: center;">
                            <label style="font-weight: bold; display: block;">
                                Marca 3
                            </label>
                             <div id="div_Marca3">
                              <asp:DropDownList ID="ddlMarca3" runat="server" Font-Names="Arial" ForeColor="Blue"
                                  Font-Bold="True" Width="130">
                              </asp:DropDownList>
                             </div>
                        </div>
                    </td>
                                               
                                                </tr>
                                            </table>
                                        </td>

                </tr>
                <tr>
                
                    <td>
                                            <table cellpadding="0" cellspacing="0">
                                                <tr>
                                                  <td>
                        <label style="font-weight: bold; display: block; text-align: center; width: 120px;">
                            Modelo 1
                        </label>
                        <asp:TextBox ID="txtModelo1" runat="server" Width="126px" Font-Names="Arial" ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                    </td>
                                                  <td>
                        <div style="text-align: center;">
                            <label style="font-weight: bold; display: block;">
                                Modelo 2
                            </label>
                            <asp:TextBox ID="txtModelo2" runat="server" Width="126px" Font-Names="Arial" ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                        </div>
                    </td>
                                                  <td>
                        <div style="text-align: center;">
                            <label style="font-weight: bold; display: block;">
                                Modelo 3
                            </label>
                            <asp:TextBox ID="txtModelo3" runat="server" Width="126px" Font-Names="Arial" ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                        </div>
                    </td>
                                               
                                                </tr>
                                            </table>
                                        </td>

                </tr>
                <tr>
                
                    <td>
                                            <table cellpadding="0" cellspacing="0">
                                                <tr>
                                                  <td>
                        <label style="font-weight: bold; display: block; text-align: center; width: 120px;">
                            Tipo Motor 1
                        </label>
                        <asp:TextBox ID="txtTipoMotor1" runat="server" Width="126px" Font-Names="Arial" ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                    </td>
                                                  <td>
                        <div style="text-align: center;">
                            <label style="font-weight: bold; display: block;">
                                Tipo Motor 2
                            </label>
                            <asp:TextBox ID="txtTipoMotor2" runat="server" Width="126px" Font-Names="Arial" ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                        </div>
                    </td>
                                                  <td>
                        <div style="text-align: center;">
                            <label style="font-weight: bold; display: block;">
                               Tipo Motor 3
                            </label>
                            <asp:TextBox ID="txtTipoMotor3" runat="server" Width="126px" Font-Names="Arial" ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                        </div>
                    </td>
                                               
                                                </tr>
                                            </table>
                                        </td>

                </tr>
                <tr>
                
                    <td>
                                            <table cellpadding="0" cellspacing="0">
                                                <tr>
                                                  <td>
                        <label style="font-weight: bold; display: block; text-align: center; width: 120px;">
                            Año I-T 1
                        </label>
                        <asp:TextBox ID="txtAñoIT1" runat="server" Width="126px" Font-Names="Arial" ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                    </td>
                                                  <td>
                        <div style="text-align: center;">
                            <label style="font-weight: bold; display: block;">
                                Año I-T 2
                            </label>
                            <asp:TextBox ID="txtAñoIT2" runat="server" Width="126px" Font-Names="Arial" ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                        </div>
                    </td>
                                                  <td>
                        <div style="text-align: center;">
                            <label style="font-weight: bold; display: block;">
                                Año I-T 3
                            </label>
                            <asp:TextBox ID="txtAñoIT3" runat="server" Width="126px" Font-Names="Arial" ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                        </div>
                    </td>
                                               
                                                </tr>
                                            </table>
                                        </td>

                </tr>

            </table>
        </div>

               <div class="linea-button">
                    <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                                    Font-Names="Arial" Font-Bold="True" Width="120px" />
                                <asp:Button ID="btnGrabarProducto" runat="server" Text="Grabar" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                                    Font-Names="Arial" Font-Bold="True" Width="120px" />
                            </div>
    </div>
</td>

                </tr>
            </table>
           
        </div>

        <div id="tabConsulta">
            <div id='divConsulta' class="ui-jqgrid ui-widget ui-widget-content ui-corner-all">

                <div class="ui-jqgrid-titlebar ui-widget-header ui-corner-top ui-helper-clearfix">
                    Criterio de busqueda
                </div>

                <div class="ui-jqdialog-content">

                    <table cellpadding="0" cellspacing="0" class="form-inputs" width="515">
                        
                           <tr>
                        <td>
                        <table cellpadding="0" cellspacing="0">
                         <tr>
                          <td style="font-weight: bold">
                                 <asp:DropDownList ID="ddlCodigoConsulta" runat="server" Font-Names="Arial" ForeColor="Blue" Font-Bold="True" Width="150">
                                   <asp:ListItem Text="CODIGO" Value="" />
                                 </asp:DropDownList>

                         </td>

                          <td style="font-weight: bold ;padding-left:5px;" >
                                <asp:TextBox ID="txtDescripcionConsulta" runat="server" Width="500" Font-Names="Arial"
                                 ForeColor="Blue" Font-Bold="True" placeholder="Ingrese el Producto"></asp:TextBox>
                          </td>
                           <td style="font-weight: bold ;padding-left:5px;">
                                                        Codigo Barra
                                                    </td>
                           <td style="padding-left: 10px;">
                                                        <asp:TextBox ID="txtCodigoBarraConsulta" runat="server" Width="140px" Font-Names="Arial" ForeColor="Blue"
                                                            Font-Bold="True"></asp:TextBox>
                                                    </td>

                                                       <td style="font-weight: bold">
                                 <asp:DropDownList ID="ddlPRUEBA" runat="server" Font-Names="Arial" ForeColor="Blue" Font-Bold="True" Width="150">
                                   <asp:ListItem Text="PRUEBA" Value="" />
                                 </asp:DropDownList>

                         </td>
                           
                         </tr>
                         </table>
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
                    CellPadding="0" CellSpacing="1" CssClass="GridView" GridLines="None" Width="1120px">
                    <Columns>    
                       <asp:TemplateField HeaderText="">
                         <HeaderTemplate>                         
                                
                         </HeaderTemplate>

                          <ItemTemplate>
                       <asp:ImageButton runat="server" ID="imgAnularDocumento" ImageUrl="~/Asset/images/EliminarBtn.png"
                                    ToolTip="ELIMINAR PRODUCTO" OnClientClick="F_EliminarRegistro(this); return false;" />
                           
                            <asp:ImageButton runat="server" ID="imgEditarRegistro" ImageUrl="../Asset/images/btnEdit.gif"
                                     ToolTip="EDITAR PRODUCTO" OnClientClick="F_EditarRegistro(this); return false;" />
                                           
                              <asp:ImageButton runat="server" ID="imgDetalleProducto" ImageUrl="../Asset/images/texto.png"
                                     ToolTip="DETALLE PRODUCTO" OnClientClick="F_DetalleProducto(this); return false;" />
                                                                   
                         </ItemTemplate>
                            <FooterStyle HorizontalAlign="Center" />
                         <ItemStyle Width="65px" />
                         </asp:TemplateField>
                                        
                            <asp:BoundField DataField="Item" HeaderText="#" 
                             HeaderStyle-CssClass="narrow-column"  >
                             </asp:BoundField>

                            <asp:TemplateField HeaderText="Producto" HeaderStyle-HorizontalAlign="Center">
                             <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            <ItemStyle HorizontalAlign="left" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblProducto" Text='<%# Bind("Producto") %>' CssClass="detallesart"></asp:Label>
                                <asp:HiddenField ID="lblRedOEM" runat="server" Value='<%# Bind("RedOEM") %>' />
                                <asp:HiddenField ID="lblCodigoBarra" runat="server" Value='<%# Bind("CodigoBarra") %>' />
                                <asp:HiddenField ID="hfProveedor" runat="server" Value='<%# Bind("Proveedor") %>' />
                                <asp:HiddenField ID="lblCodigoFabrica" runat="server" Value='<%# Bind("CodigoFabrica") %>' />
                                <asp:HiddenField ID="lblEquivalente" runat="server" Value='<%# Bind("Equivalente") %>' />
                                <asp:HiddenField ID="hfTipoProducto" runat="server" Value='<%# Bind("TipoProducto") %>' />                              
                                <asp:HiddenField ID="lblDscProducto" runat="server" Value='<%# Bind("DscProducto") %>' />
                                <asp:HiddenField ID="lblDescripcionSistema" runat="server" Value='<%# Bind("DescripcionSistema") %>' />                         
                                <asp:HiddenField ID="hfCodPais" runat="server" Value='<%# Bind("CodPais") %>' />                                      
                                <asp:HiddenField ID="lblPesoTotal" runat="server" Value='<%# Bind("PesoTotal") %>' />
                                <asp:HiddenField ID="lblM1" runat="server" Value='<%# Bind("M1") %>' />
                                <asp:HiddenField ID="lblM2" runat="server" Value='<%# Bind("M2") %>' />
                                <asp:HiddenField ID="hfFlagControlStock" runat="server" Value='<%# Bind("FlagControlStock") %>' />          
                                <asp:HiddenField ID="hfTIpoUbicacion" runat="server" Value='<%# Bind("TIpoUbicacion") %>' />
                                <asp:HiddenField ID="lblAlmacen" runat="server" Value='<%# Bind("Almacen") %>' />
                                <asp:HiddenField ID="lblRack" runat="server" Value='<%# Bind("Rack") %>' />
                                <asp:HiddenField ID="lblNivel" runat="server" Value='<%# Bind("Nivel") %>' />
                                <asp:HiddenField ID="lblZona" runat="server" Value='<%# Bind("Zona") %>' />
                                <asp:HiddenField ID="lblCaja" runat="server" Value='<%# Bind("Caja") %>' />
                                <asp:HiddenField ID="lblMostrador" runat="server" Value='<%# Bind("Mostrador") %>' />
                                <asp:HiddenField ID="hfCodMarca1" runat="server" Value='<%# Bind("CodMarca1") %>' />
                                <asp:HiddenField ID="hfCodMarca2" runat="server" Value='<%# Bind("CodMarca2") %>' />
                                <asp:HiddenField ID="hfCodMarca3" runat="server" Value='<%# Bind("CodMarca3") %>' />                     
                                <asp:HiddenField ID="hfModelo2" runat="server" Value='<%# Bind("Modelo2") %>' />
                                <asp:HiddenField ID="hfModelo3" runat="server" Value='<%# Bind("Modelo3") %>' />
                                <asp:HiddenField ID="lblTipoMotor2" runat="server" Value='<%# Bind("TipoMotor2") %>' />
                                <asp:HiddenField ID="lblTipoMotor3" runat="server" Value='<%# Bind("TipoMotor3") %>' />
                                <asp:HiddenField ID="hfAñoIT1" runat="server" Value='<%# Bind("AñoIT1") %>' />
                                <asp:HiddenField ID="hfAñoIT2" runat="server" Value='<%# Bind("AñoIT2") %>' />
                                <asp:HiddenField ID="hfAñoIT3" runat="server" Value='<%# Bind("AñoIT3") %>' />
                                <asp:HiddenField ID="hfCodProducto" runat="server" Value='<%# Bind("CodProducto") %>' />                           
                                <asp:HiddenField ID="hfCodCtaCte" runat="server" Value='<%# Bind("CodCtaCte") %>' />     
                                <asp:HiddenField ID="hfDescripcionAutocomplete" runat="server" Value='<%# Bind("DescripcionAutocomplete") %>' />                            
                                <asp:HiddenField ID="hfDescripcionTipoProducto" runat="server" Value='<%# Bind("DescripcionTipoProducto") %>' />      
                                <asp:HiddenField ID="hfCodigoCategoria" runat="server" Value='<%# Bind("CodigoCategoria") %>' />   
                                <asp:HiddenField ID="hfCodMarcaProducto" runat="server" Value='<%# Bind("CodMarcaProducto") %>' />   
                            </ItemTemplate>
                        </asp:TemplateField>

                            <asp:TemplateField HeaderText="Marca" HeaderStyle-HorizontalAlign="Center">
                                 <HeaderStyle HorizontalAlign="Center" /> 
                                 <ItemStyle HorizontalAlign="left" />
                                 <ItemTemplate>
                                     <asp:Label runat="server" ID="lblMarcaVehiculo" Text='<%# Bind("MarcaVehiculo") %>'></asp:Label>
                                 </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Modelo" HeaderStyle-HorizontalAlign="Center">
                                 <HeaderStyle HorizontalAlign="Center" /> 
                                 <ItemStyle HorizontalAlign="left" />
                                 <ItemTemplate>
                                     <asp:Label runat="server" ID="lblModelo1" Text='<%# Bind("Modelo1") %>'></asp:Label>
                                 </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Motor" HeaderStyle-HorizontalAlign="Center">
                                 <HeaderStyle HorizontalAlign="Center" /> 
                                 <ItemStyle HorizontalAlign="left" />
                                 <ItemTemplate>
                                     <asp:Label runat="server" ID="lblTipoMotor1" Text='<%# Bind("TipoMotor1") %>'></asp:Label>
                                 </ItemTemplate>
                             </asp:TemplateField>

                             <asp:TemplateField HeaderText="Medida 1" HeaderStyle-HorizontalAlign="Center">
                                 <HeaderStyle HorizontalAlign="Center" /> 
                                 <ItemStyle HorizontalAlign="left" />
                                 <ItemTemplate>
                                     <asp:Label runat="server" ID="lblMedida1" Text='<%# Bind("Medida1") %>'></asp:Label>
                                 </ItemTemplate>
                            </asp:TemplateField>

                             <asp:TemplateField HeaderText="Medida 2" HeaderStyle-HorizontalAlign="Center">
                                 <HeaderStyle HorizontalAlign="Center" /> 
                                 <ItemStyle HorizontalAlign="left" />
                                 <ItemTemplate>
                                     <asp:Label runat="server" ID="lblMedida2" Text='<%# Bind("Medida2") %>'></asp:Label>
                                 </ItemTemplate>
                            </asp:TemplateField>

                                       <asp:TemplateField HeaderText="Descripcion" HeaderStyle-HorizontalAlign="Center">
                                        <HeaderStyle HorizontalAlign="Center" /> 
                                        <ItemStyle HorizontalAlign="left" />
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblDescripcionModelo" Text='<%# Bind("DescripcionModelo") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                                                     
                                        <asp:TemplateField HeaderText="Cod Prov" HeaderStyle-HorizontalAlign="Center">
                                        <HeaderStyle HorizontalAlign="Center" /> 
                                        <ItemStyle HorizontalAlign="left" />
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblCodigoProveedor" Text='<%# Bind("CodigoProveedor") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                         
                               <asp:TemplateField HeaderText="Marca Fab" HeaderStyle-HorizontalAlign="Center">
                                        <HeaderStyle HorizontalAlign="Center" /> 
                                        <ItemStyle HorizontalAlign="left" />
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblMarcaFab" Text='<%# Bind("DscMarca1") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                             <asp:TemplateField HeaderText="Cod Int" HeaderStyle-HorizontalAlign="Center">
                                        <HeaderStyle HorizontalAlign="Center" /> 
                                        <ItemStyle HorizontalAlign="left" />
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblCodigoInterno" Text='<%# Bind("CodigoInterno") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                     <asp:TemplateField HeaderText="Costo" HeaderStyle-HorizontalAlign="Center">
                                        <HeaderStyle HorizontalAlign="Center"  /> 
                                        <ItemStyle HorizontalAlign="Right" />
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblCosto" Text='<%# Bind("Costo") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                             <asp:TemplateField HeaderText="Precio" HeaderStyle-HorizontalAlign="Center">
                                        <HeaderStyle HorizontalAlign="Center" /> 
                                        <ItemStyle HorizontalAlign="Right" />
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblPrecio1" Text='<%# Bind("Precio1") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>                                    
                    </Columns>
                </asp:GridView>
            </div>
        </div>

        <div id="tabImagen">
            <table>
                <tr>
                    <td valign="top">
                        <div style="width: 650px">
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
    
    <div id="divEdicionRegistro" style="display: none;">       
      <div class="ui-jqdialog-content">
                <table cellpadding="0" cellspacing="0" class="form-inputs">
                    <td valign="top">
                        <%--DATOS DEL PRODUCTO--%>
                        <div class="ui-jqgrid ui-widget ui-widget-content ui-corner-all" style="width: 505px;">
                            <div class="ui-jqgrid-titlebar ui-widget-header ui-corner-top ui-helper-clearfix">
                                EDICION DE PRODUCTO
                            </div>
                            <div>
                                <table cellpadding="0" cellspacing="0" class="form-inputs" >
                                    <tr>
                                        <td style="font-weight: bold; width: 120">
                                            Codigo Interno
                                        </td>
                                        <td>
                                            <table cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td>
                                                        <asp:TextBox ID="txtCodigoInternoEdicion" runat="server" Width="145px" Font-Names="Arial"
                                                            ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                                    </td>
                                                
                                                </tr>
                                            </table>
                                        </td>
                                  </tr>
                                    <tr>
                                        <td style="font-weight: bold">
                                            Ref OEM
                                        </td>
                                        <td>
                                            <table cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td>
                                                        <asp:TextBox ID="txtRefOEMEdicion" runat="server" Width="145px" Font-Names="Arial" ForeColor="Blue"
                                                            Font-Bold="True"></asp:TextBox>
                                                    </td>
                                                    <td style="font-weight: bold ;padding-left:5px;">
                                                        Codigo Barra
                                                    </td>
                                                    <td style="padding-left: 9px;">
                                                        <asp:TextBox ID="txtCodigoBarraEdicion" runat="server" Width="140px" Font-Names="Arial" ForeColor="Blue"
                                                            Font-Bold="True"></asp:TextBox>
                                                    </td>
                                               
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>

                                        <td style="font-weight: bold">
                                            Codigo Prov.
                                        </td>
                                        <td>
                                            <table cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td>
                                                        <asp:TextBox ID="txtCodigoProveedorEdicion" runat="server" Width="145px" Font-Names="Arial" ForeColor="Blue"
                                                            Font-Bold="True"></asp:TextBox>
                                                    </td>
                                                      <td style="font-weight: bold ;padding-left:6px;">
                                                      Proveedor   
                                                    </td>
                                                    <td style="padding-left: 24px;">
                                                        <asp:TextBox ID="txtProveedorEdicion" runat="server" Width="140px" Font-Names="Arial" ForeColor="Blue"
                                                            Font-Bold="True"></asp:TextBox>
                                                    </td>
                                               
                                                </tr>
                                            </table>
                                        </td>

                                    </tr>
                                    <tr>
                                     
                                        <td style="font-weight: bold">
                                         Codigo Fab
                                        </td>
                                        <td>
                                            <table cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td>
                                                        <asp:TextBox ID="txtCodigoFabricanteEdicion" runat="server" Width="145px" Font-Names="Arial" ForeColor="Blue"
                                                            Font-Bold="True"></asp:TextBox>
                                                    </td>
                                                      <td style="font-weight: bold ;padding-left:6px;">
                                                      Equivalente 
                                                    </td>
                                                    <td style="padding-left: 17px;">
                                                        <asp:TextBox ID="txtEquivalenteEdicion" runat="server" Width="140px" Font-Names="Arial" ForeColor="Blue"
                                                            Font-Bold="True"></asp:TextBox>
                                                    </td>
                                               
                                                </tr>
                                            </table>
                                        </td>

                                     

                                    </tr>
                                   <tr>

                                        <td style="font-weight: bold">
                                            Tipo Producto
                                        </td>
       <td style="padding-left: 4px;">
                                                            <asp:TextBox ID="txtTipoProductoEdicion" runat="server" Width="387px" Font-Names="Arial" ForeColor="Blue"
                                                            Font-Bold="True"></asp:TextBox>
                                                    </td>

                                    </tr>
                                       <tr>

                                        <td style="font-weight: bold">
                                              Desc Modelo
                                        </td>
   <td style="padding-left: 4px">
                                                        <asp:TextBox ID="txtDescripcionModeloEdicion" runat="server" Width="387px" Font-Names="Arial" ForeColor="Blue"
                                                            Font-Bold="True" CssClass="Derecha"></asp:TextBox>
                                                    </td>
                                  

                                       </tr>
                                     <tr>
                                        <td style="font-weight: bold; width: 120">
                                            Nombre Fact
                                        </td>
                                        <td>
                                            <table cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td>
                                                        <asp:TextBox ID="txtNombreFactEdicion" runat="server" Width="385px" Font-Names="Arial"
                                                            ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                                    </td>
                                                
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>

                                      <tr>
                                        <td style="font-weight: bold; width: 120">
                                            Desc Sistema
                                        </td>
                                        <td>
                                            <table cellpadding="0" cellspacing="0">
                                                <tr>
                                                  <td>
                                                    <asp:TextBox ID="txtDescSistemaEdicion" runat="server" Width="385px" Height="23px" Font-Names="Arial"
                                                        ForeColor="Blue" Font-Bold="True" TextMode="MultiLine" Rows="4"></asp:TextBox>
                                                </td>

                                                
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>

                                    <tr>

                                        <td style="font-weight: bold">
                                            Marca Fab
                                        </td>
                                        <td colspan='5'>
                                            <table cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td style="padding-left: 2px;">
                                                        <div id="div_MarcaFabEdicion">
                                                            <asp:DropDownList ID="ddlMarcaFabEdicion" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                                Font-Bold="True" Width="149">
                                                            </asp:DropDownList>
                                                        </div>
                                                    </td>
                                               <td style="font-weight: bold ;padding-left:6px;">
                                                        Pais Origen
                                                    </td>
                                                    <td style="padding-left: 20px;">
                                                        <div id="div_PaisOrigenEdicion">
                                                            <asp:DropDownList ID="ddlPaisOrigenEdicion" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                                Font-Bold="True" Width="144">
                                                            </asp:DropDownList>
                                                        </div>
                                                    </td>
                                               
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>

                                          <td style="font-weight: bold">
                                           Und Venta
                                        </td>
                                        <td colspan='5'>
                                            <table cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td style="padding-left: 2px;">
                                                        <div id="div_UndVentaEdicion">
                                                            <asp:DropDownList ID="ddlUndVentaEdicion" runat="server" Font-Names="Arial" ForeColor="Blue"
                                                                Font-Bold="True" Width="149">
                                                            </asp:DropDownList>
                                                        </div>
                                                    </td>
                                                      <td style="font-weight: bold ;padding-left:6px;">
                                                       Peso Total
                                                    </td>
                                                      <td style="padding-left: 21px;">
                                                        <asp:TextBox ID="txtPesoTotalEdicion" runat="server" Width="140px" Font-Names="Arial"
                                                            ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                                                    </td>
                                                 
                                               
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                         <tr>

                                        <td style="font-weight: bold">
                                         M1
                                        </td>
                                        <td>
                                            <table cellpadding="0" cellspacing="0">
                                                <tr>
                                                  <td>
                                                    <asp:TextBox ID="txtM1Edicion" runat="server" Width="55px" Font-Names="Arial" ForeColor="Blue"
                                                        Font-Bold="True" Text="0.00" style="text-align: right;"></asp:TextBox>
                                                 </td>

                                                    <td style="font-weight: bold; padding-left: 10px;">
                                                      M2 
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtM2Edicion" runat="server" Width="56px" Font-Names="Arial" ForeColor="Blue"
                                                            Font-Bold="True" Text="0.00" style="text-align: right;"></asp:TextBox>
                                                    </td>

                                                      <td style="padding-left: 5px;">
                                         <asp:CheckBox ID="chkControlStockEdicion" runat="server" Text="Control Stock"
                                             Font-Bold="True" />
                                     </td>
                                               
                                                </tr>
                                            </table>
                                        </td>

                                     

                                    </tr>
                                </table>
                            </div>


                           
                        </div>
                    </td>
                   <%-- ******************************COLUMNA LADO IZQUIERDO--%>
                    <td valign="top">
    <%--DATOS DEL ARTICULO--%>
    <div class="ui-jqgrid ui-widget ui-widget-content ui-corner-all" style="width: 610px;">

        <div class="ui-jqgrid-titlebar ui-widget-header ui-corner-top ui-helper-clearfix">
            EDICION OPCIONALES
        </div>
        <div>
            <table cellpadding="0" cellspacing="0" class="form-inputs">
                <tr>
                
                    <td>
                                            <table cellpadding="0" cellspacing="0">
                                                <tr>
                                                  <td>


                        <div style="text-align: center;">
                            <label style="font-weight: bold; display: block;">
                               Nombre Med
                            </label>
                            <asp:TextBox ID="txtNombreMedEdcion" runat="server" Width="182px" Font-Names="Arial" ForeColor="Blue" Font-Bold="True"></asp:TextBox>

                        </div>

                    </td>
                                                  <td>
                        <div style="text-align: center;">
                            <label style="font-weight: bold; display: block;">
                                Medida 1
                            </label>
                            <asp:TextBox ID="txtMedida1Edicion" runat="server" Width="190px" Font-Names="Arial" ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                        </div>
                    </td>
                                                  <td>
                        <div style="text-align: center;">
                            <label style="font-weight: bold; display: block;">
                                Medida 2
                            </label>
                            <asp:TextBox ID="txtMedida2Edicion" runat="server" Width="190px" Font-Names="Arial" ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                        </div>
                    </td>
                                               
                                                </tr>
                                            </table>
                                        </td>

                </tr>

                <tr>
                <td style="text-align: center">
                    <table cellpadding="0" cellspacing="0">
                      <tr>
                          <div class="ui-jqgrid-titlebar ui-widget-header ui-corner-top ui-helper-clearfix" style="height:15px;width:590px">
                                    UBICACIONES
                            </div>
                                   
                      </tr>
                    </table>
                     </td>


               </tr>

                <tr >
                 
                    <td>
                      <table cellpadding="0" cellspacing="0">
                        <tr>
                        <td>
                        <label style="font-weight: bold; display: block; text-align: center; width: 120px;">
                            Tipo
                        </label>

                           <asp:TextBox ID="txtTipoEdicion" runat="server" Width="118px" Font-Names="Arial" ForeColor="Blue" Font-Bold="True"></asp:TextBox>

                    </td>
                        <td >
                        <div style="text-align: center;">
                            <label style="font-weight: bold; display: block;">
                                Almacen
                            </label>
                            <asp:TextBox ID="txtAlmacenEdicion" runat="server" Width="110px" Font-Names="Arial" ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                        </div>
                    </td>
                        <td>
                        <div style="text-align: center;">
                            <label style="font-weight: bold; display: block;">
                                Rack
                            </label>
                            <asp:TextBox ID="txtRackEdicion" runat="server" Width="60px" Font-Names="Arial" ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                        </div>
                    </td>
                        <td>
                        <div style="text-align: center;">
                            <label style="font-weight: bold; display: block;">
                                Nivel
                            </label>
                            <asp:TextBox ID="txtNivelEdicion" runat="server" Width="60px" Font-Names="Arial" ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                        </div>
                    </td>
                        <td>
                        <div style="text-align: center;">
                            <label style="font-weight: bold; display: block;">
                                Zona
                            </label>
                            <asp:TextBox ID="txtZonaEdicion" runat="server" Width="60px" Font-Names="Arial" ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                        </div>
                    </td>
                        <td>
                        <div style="text-align: center;">
                            <label style="font-weight: bold; display: block;">
                                Caja
                            </label>
                            <asp:TextBox ID="txtCajaEdicion" runat="server" Width="60px" Font-Names="Arial" ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                        </div>
                    </td>
                        <td>
                        <div style="text-align: center;">
                            <label style="font-weight: bold; display: block;">
                                Mostrador
                            </label>
                            <asp:TextBox ID="txtMostradorEdicion" runat="server" Width="60px" Font-Names="Arial" ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                        </div>
                    </td>
                       
                        </tr>
                    </table>
                     </td>

                </tr>

                <tr>
                <td style="text-align: center">
                    <table cellpadding="0" cellspacing="0">
                      <tr>
                          <div class="ui-jqgrid-titlebar ui-widget-header ui-corner-top ui-helper-clearfix" style="height:15px;width:590px">
                                    Informacion de Vehiculos
                            </div>
                                   
                      </tr>
                    </table>
                     </td>


               </tr>

                <tr>
                
                    <td>
                                            <table cellpadding="0" cellspacing="0">
                                                <tr>
                                                  <td>
                        <label style="font-weight: bold; display: block; text-align: center; width: 120px;">
                            Marca 1
                        </label>
                          <div id="div_Marca1Edicion">
                              <asp:DropDownList ID="ddlMarca1Edicion" runat="server" Font-Names="Arial" ForeColor="Blue"
                                  Font-Bold="True" Width="130">
                              </asp:DropDownList>
                             </div>
                    </td>
                                                  <td>
                        <div style="text-align: center;">
                            <label style="font-weight: bold; display: block;">
                             Marca 2
                            </label>
                              <div id="div_Marca2Edicion">
                              <asp:DropDownList ID="ddlMarca2Edicion" runat="server" Font-Names="Arial" ForeColor="Blue"
                                  Font-Bold="True" Width="130">
                              </asp:DropDownList>
                             </div>
                        </div>
                    </td>
                                                  <td>
                        <div style="text-align: center;">
                            <label style="font-weight: bold; display: block;">
                                Marca 3
                            </label>
                             <div id="div_Marca3Edicion">
                              <asp:DropDownList ID="ddlMarca3Edicion" runat="server" Font-Names="Arial" ForeColor="Blue"
                                  Font-Bold="True" Width="130">
                              </asp:DropDownList>
                             </div>
                        </div>
                    </td>
                                               
                                                </tr>
                                            </table>
                                        </td>

                </tr>
                <tr>
                
                    <td>
                                            <table cellpadding="0" cellspacing="0">
                                                <tr>
                                                  <td>
                        <label style="font-weight: bold; display: block; text-align: center; width: 120px;">
                            Modelo 1
                        </label>
                        <asp:TextBox ID="txtModelo1Edicion" runat="server" Width="126px" Font-Names="Arial" ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                    </td>
                                                  <td>
                        <div style="text-align: center;">
                            <label style="font-weight: bold; display: block;">
                                Modelo 2
                            </label>
                            <asp:TextBox ID="txtModelo2Edicion" runat="server" Width="126px" Font-Names="Arial" ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                        </div>
                    </td>
                                                  <td>
                        <div style="text-align: center;">
                            <label style="font-weight: bold; display: block;">
                                Modelo 3
                            </label>
                            <asp:TextBox ID="txtModelo3Edicion" runat="server" Width="126px" Font-Names="Arial" ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                        </div>
                    </td>
                                               
                                                </tr>
                                            </table>
                                        </td>

                </tr>
                <tr>
                
                    <td>
                                            <table cellpadding="0" cellspacing="0">
                                                <tr>
                                                  <td>
                        <label style="font-weight: bold; display: block; text-align: center; width: 120px;">
                            Tipo Motor 1
                        </label>
                        <asp:TextBox ID="txtTipoMotor1Edicion" runat="server" Width="126px" Font-Names="Arial" ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                    </td>
                                                  <td>
                        <div style="text-align: center;">
                            <label style="font-weight: bold; display: block;">
                                Tipo Motor 2
                            </label>
                            <asp:TextBox ID="txtTipoMotor2Edicion" runat="server" Width="126px" Font-Names="Arial" ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                        </div>
                    </td>
                                                  <td>
                        <div style="text-align: center;">
                            <label style="font-weight: bold; display: block;">
                               Tipo Motor 3
                            </label>
                            <asp:TextBox ID="txtTipoMotor3Edicion" runat="server" Width="126px" Font-Names="Arial" ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                        </div>
                    </td>
                                               
                                                </tr>
                                            </table>
                                        </td>

                </tr>
                <tr>
                
                    <td>
                                            <table cellpadding="0" cellspacing="0">
                                                <tr>
                                                  <td>
                        <label style="font-weight: bold; display: block; text-align: center; width: 120px;">
                            Año I-T 1
                        </label>
                        <asp:TextBox ID="txtAñoIT1Edicion" runat="server" Width="126px" Font-Names="Arial" ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                    </td>
                                                  <td>
                        <div style="text-align: center;">
                            <label style="font-weight: bold; display: block;">
                                Año I-T 2
                            </label>
                            <asp:TextBox ID="txtAñoIT2Edicion" runat="server" Width="126px" Font-Names="Arial" ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                        </div>
                    </td>
                                                  <td>
                        <div style="text-align: center;">
                            <label style="font-weight: bold; display: block;">
                                Año I-T 3
                            </label>
                            <asp:TextBox ID="txtAñoIT3Edicion" runat="server" Width="126px" Font-Names="Arial" ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                        </div>
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
                </table>
            </div>
        
    </div>

    <div id="div_DetalleProducto" style="display: none;">
            <table cellpadding="0" cellspacing="0">
              
              <tr>

             <td style="font-weight: bold">
                 MARCA
             </td>
     
             <td>
                             <div id="div_MarcaAplicaciones">
                                 <asp:DropDownList ID="ddlMarcaAplicaciones" runat="server" Font-Names="Arial" ForeColor="Blue"
                                     Font-Bold="True" Width="149">
                                 </asp:DropDownList>
                             </div>
                         </td>                                              
              
 <td style="font-weight: bold">
                 MODELO
             </td>
     <td style = "padding-left:5px;">
                             <div id="div_ModeloAplicaciones">
                                 <asp:DropDownList ID="ddlModeloAplicaciones" runat="server" Font-Names="Arial" ForeColor="Blue"
                                     Font-Bold="True" Width="149">
                                 </asp:DropDownList>
                             </div>
                         </td>  

  <td style="font-weight: bold">
                 MOTOR
             </td>

    <td>
                             <div id="div_MotorAplicaciones">
                                 <asp:DropDownList ID="ddlMotorAplicaciones" runat="server" Font-Names="Arial" ForeColor="Blue"
                                     Font-Bold="True" Width="149">
                                 </asp:DropDownList>
                             </div>
                         </td> 
 <td style="font-weight: bold">
                 AÑO
             </td>

      <td>
                        <asp:TextBox ID="txtAñoDetalle" runat="server" Width="149px" Font-Names="Arial"
                            ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                    </td>    

            </tr>                 

            </table>
                                  
            <br />
            <div  style="text-align:right ;padding-right:10px;">
              <asp:Button ID="btnGrabarDetalle" runat="server" Text="GRABAR" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                            Font-Names="Arial" Font-Bold="True" Width="150" />
            </div>
         <br />
            <div>
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

                                         <asp:TemplateField HeaderText="Item" HeaderStyle-HorizontalAlign="Center">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblItem" Text='<%# Bind("Item") %>'></asp:Label>
                                <asp:HiddenField ID="hfCodMarca" runat="server" Value='<%# Bind("CodMarca") %>' />
                                <asp:HiddenField ID="hfCodModelo" runat="server" Value='<%# Bind("CodModelo") %>' />
                                <asp:HiddenField ID="hfCodmotor" runat="server" Value='<%# Bind("Codmotor") %>' />
                                    
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Marca" HeaderStyle-HorizontalAlign="Center">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblMarca" Text='<%# Bind("Marca") %>'></asp:Label>
                                    
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Modelo" HeaderStyle-HorizontalAlign="Center">
                                        <ItemStyle HorizontalAlign="left" />
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblModelo" Text='<%# Bind("Modelo") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Motor" HeaderStyle-HorizontalAlign="Center">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblMotor" Text='<%# Bind("Motor") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="AñoIT1" HeaderStyle-HorizontalAlign="Center">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblAñoIT1" Text='<%# Bind("AñoIT1") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField> 
                                                                 
                                </Columns>
                            </asp:GridView>
                        </div>
                    </td>
                </tr>
            </div>
        </div>

    <div id="div_DetalleProductoEdicion" style="display: none;">
            <table cellpadding="0" cellspacing="0">
              
              <tr>

             <td style="font-weight: bold">
                 MARCA
             </td>
     
             <td style="display: block;padding-left: 10px;">
                             <div id="div_MarcaAplicacionesEdicion">
                                 <asp:DropDownList ID="ddlMarcaAplicacionesEdicion" runat="server" Font-Names="Arial" ForeColor="Blue"
                                     Font-Bold="True" Width="149">
                                 </asp:DropDownList>
                             </div>
                         </td>  
                  
            </tr>  
                         <tr>
                          <td style="font-weight: bold">
                 MODELO
             </td>
     <td style = "padding-left:10px;">
                             <div id="div_ModeloAplicacionesEdicion">
                                 <asp:DropDownList ID="ddlModeloAplicacionesEdicion" runat="server" Font-Names="Arial" ForeColor="Blue"
                                     Font-Bold="True" Width="149">
                                 </asp:DropDownList>
                             </div>
                         </td>  
                         </tr>
                                                                     
              <tr>
               <td style="font-weight: bold">
                 MOTOR
             </td>

    <td style="display: block;padding-left: 10px;">
                             <div id="div_MotorAplicacionesEdicion">
                                 <asp:DropDownList ID="ddlMotorAplicacionesEdicion" runat="server" Font-Names="Arial" ForeColor="Blue"
                                     Font-Bold="True" Width="149">
                                 </asp:DropDownList>
                             </div>
                         </td> 
              </tr>

              <tr>
               <td style="font-weight: bold">
                 AÑO
             </td>

      <td style="display: block;padding-left: 10px;">
                        <asp:TextBox ID="txtAñoDetalleEdicion" runat="server" Width="149px" Font-Names="Arial"
                            ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                    </td>    
              </tr>
               

            </table>
                                  
            <br />
            <div  style="text-align:right ;padding-right:10px;">
              <asp:Button ID="btnEditarDetalle" runat="server" Text="GRABAR" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                            Font-Names="Arial" Font-Bold="True" Width="150" />
            </div>
         <br />

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
    <input id="hfCodCtaCte" type="hidden" value="0" />
    <input id="hfCodCtaCteEdicion" type="hidden" value="0" />
    <input id="hfCodigoInterno" type="hidden" value="0" />
    <input id="hfCodProducto" type="hidden" value="0" />
    <input id="hfCodTipoProducto" type="hidden" value="0" />
    <input id="hfTipoProducto" type="hidden" value="" />
    <input id="hfCodProductoDetalle" type="hidden" value="0" />
    <input id="hfCodigo" type="hidden" value="0" />
    <input id="hfCodTipoProductoEdicion" type="hidden" value="0" />
    <input id="hfTipoProductoEdicion" type="hidden" value="" />
    <input id="hfCodigoEdicion" type="hidden" value="0" />
</asp:Content>






   
        
        