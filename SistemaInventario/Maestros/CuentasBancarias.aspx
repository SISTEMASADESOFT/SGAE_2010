<%@ Page Title="CuentasBancarias" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="CuentasBancarias.aspx.cs" Inherits="SistemaInventario.Maestros.CuentasBancarias" %>

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
    <script type="text/javascript" language="javascript" src="CuentasBancarias.js" charset="UTF-8"></script>
    <link href="../Asset/css/redmond/jquery-ui-1.10.4.custom.css" rel="stylesheet" type="text/css" />
    <link href="../Asset/css/Redmond/jquery-ui-1.10.4.custom.min.css" rel="stylesheet"
        type="text/css" />
    <link href="../Asset/css/style.css" rel="stylesheet" type="text/css" />
     <link href="../Asset/toars/toastr.min.css" rel="stylesheet" type="text/css" />
    <script src="../Asset/toars/toastr.min.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="titulo">
        Cuentas Bancarias</div>
    <div id="divTabs">
        <ul>
            <li id="liRegistro"><a href="#tabRegistro">Registro</a></li>
            <li id="liConsulta"><a href="#tabConsulta" onclick="getContentTab();">Consulta</a></li>
        </ul>
        <div id="tabRegistro">
            <div class="ui-jqgrid ui-widget ui-widget-content ui-corner-all" style="width: 530px">
                <div class="ui-jqgrid-titlebar ui-widget-header ui-corner-top ui-helper-clearfix">
                    REGISTRO DE Cuentas Bancarias
                </div>
                <div>
                  <table cellpadding="0" cellspacing="1" class="form-inputs">
                           <tr>
                            <td style="font-weight: bold">
                                Banco
                            </td>
                            <td>
                                <div id="div_CuentasBancarias">
                                    <asp:DropDownList ID="ddlCuentasBancarias" runat="server" Font-Names="Arial" ForeColor="Blue"
                                        Font-Bold="True" Width="344">
                                    </asp:DropDownList>
                                </div>
                            </td>

                           <td style="width: 20px" height="18px">
                                
                              <asp:ImageButton runat="server" ID="imgDireccion" ImageUrl="../Asset/images/add_small.png"
                                    ToolTip="DIRECCION" OnClientClick="F_AbrirBanco(this); return false;" />
                           </td>

                           <td style="width: 20px" height="18px">

                           
                                <asp:ImageButton runat="server" ID="imgEditarRegistro" ImageUrl="../Asset/images/btnEdit.gif"
                                    ToolTip="EDITAR" OnClientClick="F_EditarRegistro(this); return false;" />
                            

                            </td>
                        </tr>

               
                        <tr>
                            <td style="font-weight: bold">
                               Moneda
                            </td>
                            <td>
                                <div id="div_Moneda">
                                    <asp:DropDownList ID="ddlMoneda" runat="server" Font-Names="Arial" ForeColor="Blue"
                                        Font-Bold="True" Width="344">
                                    </asp:DropDownList>
                                </div>
                            </td>
                        </tr>

                        <tr>
                            <td style="font-weight: bold">
                                Num Cuenta
                            </td>
                            <td>
                                <asp:TextBox ID="txtCuenta" runat="server" Width="340px" Font-Names="Arial"
                                    ForeColor="Blue" Font-Bold="True" MaxLength="20"></asp:TextBox>
                            </td>
                      </tr>

                         <tr>
                            <td style="font-weight: bold">
                               CCI
                            </td>
                            <td>
                                <asp:TextBox ID="txtCci" runat="server" Width="340px" Font-Names="Arial"
                                    ForeColor="Blue" Font-Bold="True" MaxLength="23"></asp:TextBox>
                            </td>
                       </tr>

                       <tr>
                            <td style="font-weight:bold">
                              Observacion
                            </td>
                            <td>
                                <asp:TextBox ID="txtObservacion" runat="server" Width ="340px" Font-Names="Arial"
                                    ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                            </td>
                        </tr>

                        <tr>
                            <td style="font-weight:bold">
                            Cuenta Contable
                            </td>
                            <td >
                                <asp:TextBox ID="txtCuentaContable" runat="server" Width ="340px" Font-Names="Arial"
                                    ForeColor="Blue" Font-Bold="True"></asp:TextBox>

                            </td>
                        </tr>

                        <tr>
                            <td style="font-weight:bold">
                            TD
                            </td>
                            <td>
                                <asp:TextBox ID="txtTd" runat="server" Width ="340px" Font-Names="Arial"
                                    ForeColor="Blue" Font-Bold="True"></asp:TextBox>

                            </td>
                        </tr>

                        <tr>
                            <td style="font-weight:bold">
                            Codigo Anexo
                            </td>
                            <td>
                                <asp:TextBox ID="txtCodigoAnexo" runat="server" Width ="340px" Font-Names="Arial"
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
                                        Font-Bold="True" Width="344">
                                    </asp:DropDownList>
                                </div>
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
                                            <label id="lblNumeroConsulta"></label>
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
                                                ToolTip="ELIMINAR BANCO" OnClientClick="F_EliminarRegistro(this); return false;" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:ImageButton runat="server" ID="imgEditarRegistro" ImageUrl="../Asset/images/btnEdit.gif"
                                                ToolTip="EDITAR BANCO" OnClientClick="F_EditarRegistro2(this); return false;" />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                      

                                    <asp:TemplateField HeaderText="Banco">
                                           <HeaderStyle HorizontalAlign="Center" />
                                          <ItemStyle HorizontalAlign="Left" />
                                            <ItemTemplate>
                                     <asp:Label runat="server" ID="lblNombreBanco" Text='<%# Bind("banco") %>' CssClass="detallesart"></asp:Label>

                                      <asp:HiddenField runat="server" ID="hfCodCuenta" value='<%# Bind("CodCuenta") %>'/>
                                       <asp:HiddenField ID="lblObservacion" runat="server" Value='<%# Bind("Observacion") %>' />
                                       <asp:HiddenField ID="lblCci" runat="server" Value='<%# Bind("Cci") %>' />
                                       <asp:HiddenField ID="lblMoneda" runat="server" Value='<%# Bind("CodMoneda") %>' />
                                       <asp:HiddenField ID="lblNumeroCuenta" runat="server" Value='<%# Bind("NumeroCuenta") %>' />
                                       <asp:HiddenField ID="hfestado" runat="server" Value='<%# Bind("CodEstado") %>' />
                                       <asp:HiddenField ID="hfDetraccion" runat="server" Value='<%# Bind("Detraccion") %>' />
                                       <asp:HiddenField ID="lblTd" runat="server" Value='<%# Bind("TD") %>' />
                                       <asp:HiddenField ID="lblAnexo" runat="server" Value='<%# Bind("Anexo") %>' />
                                       <asp:HiddenField ID="lblCuentaContable" runat="server" Value='<%# Bind("CuentaContable") %>' />

                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:BoundField DataField="moneda" HeaderText="Moneda">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Cci" HeaderText="CCI">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="NumeroCuenta" HeaderText="Número de Cuenta">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="estado" HeaderText="Estado">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>

                                       <asp:BoundField DataField="Observacion" HeaderText="Observacion">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>

                                           <asp:BoundField DataField="CuentaContable" HeaderText="Cuenta Contable">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="right" />
                                    </asp:BoundField>

                                           <asp:BoundField DataField="TD" HeaderText="TD">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="right" />
                                    </asp:BoundField>

                                           <asp:BoundField DataField="Anexo" HeaderText="Codigo de Anexo">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="right" />
                                    </asp:BoundField>

                                        <asp:BoundField DataField="Detraccion" HeaderText="Detraccion">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>

                                </Columns>
                            </asp:GridView>
                        </div>

        </div>


    </div>

     
     <div id="tabGrabarBanco" style="display: none; width: 180; height:200 ">
        <table cellpadding="2" cellspacing="0" >
     
            <tr>
                <td style="padding-top: 5px; font-weight: bold">
                    Descripcion
                </td>
                <td style="padding-top: 5px;">
                    <asp:TextBox ID="txtDescripcion" runat="server" Width="350px" Font-Names="Arial"
                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="padding-top: 5px; font-weight: bold">
                    Descripcion Corta 
                </td>
                <td style="padding-top: 5px;">
                    <asp:TextBox ID="txtDescripcionCorta" runat="server" Width="350px" Font-Names="Arial"
                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td style=" font-weight: bold">
                    Numero De Orden
                </td>
                <td style="padding-top: 5px;">
                    <asp:TextBox ID="txtOrden" runat="server" Width="350px" Font-Names="Arial"
                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                </td>
            </tr>

          

                 <tr>
                     <td style="font-weight: bold; ">
                                Estado
                            </td>
                            <td style= "padding-top: 5px">
                                <div id="div_EstadoBanco">
                                    <asp:DropDownList ID="ddlEstadoBanco" runat="server" Font-Names="Arial" ForeColor="Blue"
                                        Font-Bold="True" Width="354">
                                    </asp:DropDownList>
                                </div>
                            </td>
                        </tr>

                     <tr>
                    <td style="font-weight: bold">
                                    Banco Interno:
                                </td>
                                <td style="font-weight: bold; margin-right :10px">
                                    <asp:CheckBox ID="chkBancoInterno" runat="server" Text="Banco Interno" Font-Bold="True" />
                                     
                                </td>
                       </tr>

            <tr>
                <td align="right" colspan="2">
                    <asp:Button ID="btnNuevoBanco" runat="server" Text="Nuevo" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                        Font-Names="Arial" Font-Bold="True" Width="120px" />
                    <asp:Button ID="btnGrabarBanco" runat="server" Text="GRABAR" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                        Font-Names="Arial" Font-Bold="True" Width="120" />
                </td>
            </tr>

       
        </table>
    </div>
    

   <div id="tabEdicionBanco" style="display: none; width:200" >
   
    <table cellpadding="0" cellspacing="0">

            <tr style ="padding-top: 20px">
                <td style="font-weight: bold; padding-top:20 ">
                    Banco
                </td>
                <td>
                    <div id="div_BancoEdicion">
                        <asp:DropDownList ID="ddlBancoEdicion" runat="server" Font-Names="Arial" ForeColor="Blue"
                            Font-Bold="True" Width="354" Enabled="false">
                        </asp:DropDownList>
                    </div>
                </td>
            </tr>

            <tr>
                <td style="padding-top: 5px; font-weight: bold">
                    Descripcion
                </td>
                <td style="padding-top: 5px;">
                    <asp:TextBox ID="txtDescripcionEdicion" runat="server" Width="350px" Font-Names="Arial"
                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="padding-top: 5px; font-weight: bold">
                    Descripcion Corta
                </td>
                <td style="padding-top: 5px;">
                    <asp:TextBox ID="txtDescripcionCortaEdicion" runat="server" Width="350px" Font-Names="Arial"
                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style=" font-weight: bold">
                    Numero De Orden
                </td>
                <td style="padding-top: 5px;">
                    <asp:TextBox ID="txtOrdenEdicion" runat="server" Width="350px" Font-Names="Arial"
                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="font-weight: bold; ">
                    Estado
                </td>
                <td style= "padding-top: 5px">
                    <div id="div_EstadoEdicion2">
                        <asp:DropDownList ID="ddlEstadoEdicion2" runat="server" Font-Names="Arial" ForeColor="Blue"
                            Font-Bold="True" Width="354">
                        </asp:DropDownList>
                    </div>
                </td>
            </tr>
            <tr style="display:none" >
                <td style="font-weight: bold; padding-top:5px">
                    Banco Interno
                </td>
                <td style="font-weight: bold; margin-right :10px">
                    <asp:CheckBox ID="ChkBancoInternoEdicion" runat="server" Text="Principal" Font-Bold="True" />
                </td>
            </tr>


              <tr style="padding-top:50px">
                <td align="right" colspan="2" style="padding-top:10px">
                   <asp:Button ID="btnEdicionBanco" runat="server" Text="Grabar" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
            Font-Names="Arial" Font-Bold="True" Width="120px" Height="" />
                </td>
            </tr>

        </table>
      
     </div>

       <div id="tabEdicionCuentas" style="display: none;">
        <table cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    <div class="ui-jqgrid ui-widget ui-widget-content ui-corner-all" style="width: 450px;">
                        
                        <div class="ui-jqgrid-titlebar ui-widget-header ui-corner-top ui-helper-clearfix"
                            style="width: 450px">
                            DATOS CUENTA BANCARIA
                        </div>
                        <div class="ui-jqdialog-content" style="width: 450px">
                          <table cellpadding="0" cellspacing="0" class="form-inputs">
        <tr>
                <td style=" font-weight: bold">
                    Num. Cuenta
                </td>
                <td style="padding-top: 5px;">
                    <asp:TextBox ID="txtNumeroCuenta" runat="server" Width="200px" Font-Names="Arial"
                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                </td>
            </tr>

         <tr>
                <td style="padding-top: 5px; font-weight: bold">
                    Cci
                </td>
                <td style="padding-top: 5px;">
                    <asp:TextBox ID="txtCciEdicion" runat="server" Width="200px" Font-Names="Arial"
                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td style="padding-top: 5px; font-weight: bold">
                    Observacion
                </td>
                <td style="padding-top: 5px;">
                    <asp:TextBox ID="txtObservacionEdicion" runat="server" Width="200px" Font-Names="Arial"
                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                </td>
            </tr>

        

            <tr style ="padding-top: 20px">
                <td style="font-weight: bold; padding-top:20 ">
                    Moneda
                </td>
                <td>
                    <div id="div_MonedaEdicion">
                        <asp:DropDownList ID="ddlMonedaEdicion" runat="server" Font-Names="Arial" ForeColor="Blue"
                            Font-Bold="True" Width="204" >
                        </asp:DropDownList>
                    </div>
                </td>
            </tr>

    

            <tr>
                <td style="font-weight: bold; ">
                    Estado
                </td>
                <td style= "padding-top: 5px">
                    <div id="div_EstadoEdicion">
                        <asp:DropDownList ID="ddlEstadoEdicion" runat="server" Font-Names="Arial" ForeColor="Blue"
                            Font-Bold="True" Width="204">
                        </asp:DropDownList>
                    </div>
                </td>
            </tr>

              <tr>
                <td style="padding-top: 5px; font-weight: bold">
                    Cuenta Contable
                </td>
                <td style="padding-top: 5px;">
                    <asp:TextBox ID="txtCuentaContableEdicion" runat="server" Width="200px" Font-Names="Arial"
                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                </td>
            </tr>

             <tr>
                <td style="padding-top: 5px; font-weight: bold">
                    TD
                </td>
                <td style="padding-top: 5px;">
                    <asp:TextBox ID="txtTdEdicion" runat="server" Width="200px" Font-Names="Arial"
                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                </td>
            </tr>

              <tr>
                <td style="padding-top: 5px; font-weight: bold">
                  Codigo Anexo
                </td>
                <td style="padding-top: 5px;">
                    <asp:TextBox ID="txtCodigoAnexoEdicion" runat="server" Width="200px" Font-Names="Arial"
                        ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                </td>
            </tr>

            <tr  >
                <td style="font-weight: bold; padding-top:5px">
                    
                </td>
                <td style="font-weight: bold; margin-right :10px">
                    <asp:CheckBox ID="chkDetraccion" runat="server" Text="Detraccion" Font-Bold="True" />
                </td>
            </tr>            
        </table>
                        </div>
                        <div class="linea-button">
                                <asp:Button ID="btnEdicion" runat="server" Text="Grabar" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
            Font-Names="Arial" Font-Bold="True" Width="120px" Height="" />
                        </div>
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
        <br />
        <br />
        <center>
            <img alt="Wait..." src="../Asset/images/ajax-loader2.gif" /></center>
    </div>
    
    <div id="divEdicionRegistro" style="display: none;">
        <div class="ui-jqgrid ui-widget ui-widget-content ui-corner-all">
            <div class="ui-jqgrid-titlebar ui-widget-header ui-corner-top ui-helper-clearfix">
                DATOS FAMILIA
            </div>
            <div class="ui-jqdialog-content">
                <table cellpadding="0" cellspacing="0" class="form-inputs" width="700">
                    <tr>
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
                        <td style="font-weight: bold">
                            Codigo
                        </td>
                        <td>
                            <asp:TextBox ID="txtCodFamiliaEdicion" runat="server" Width="50" Font-Names="Arial"
                                ForeColor="Blue" Font-Bold="True" ReadOnly="True"></asp:TextBox>
                        </td>
                        <td style="font-weight: bold">
                            Descripcion
                        </td>
                 
                    </tr>
                    <tr>
                        <td style="font-weight: bold">
                            ESTADO
                        </td>
                  
                    </tr>
                </table>
            </div>
            
        </div>
    </div>


    <input id="hfIDFamilia" type="hidden" value="0" />
    
    <input id="hfCodCuenta" type="hidden" value="0" />
    <input id="hfCodLinea" type="hidden" value="0" />
</asp:Content>
