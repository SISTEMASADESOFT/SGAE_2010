<%@ Page Title="VehiculoWong" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VehiculoWong.aspx.cs" Inherits="SistemaInventario.Maestros.VehiculoWong" %>

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

    <script type="text/javascript" language="javascript" src="VehiculoWong.js" charset="UTF-8"></script>
    <link href="../Asset/css/redmond/jquery-ui-1.10.4.custom.css" rel="stylesheet" type="text/css" />
    <link href="../Asset/css/Redmond/jquery-ui-1.10.4.custom.min.css" rel="stylesheet"
        type="text/css" />
    <link href="../Asset/css/style.css" rel="stylesheet" type="text/css" />
     <link href="../Asset/toars/toastr.min.css" rel="stylesheet" type="text/css" />
    <script src="../Asset/toars/toastr.min.js" type="text/javascript"></script>
  
</asp:Content> 

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="titulo">
        Vehiculo Wong</div>
    <div id="divTabs" style="width: 1200px; height: 100%;">
     <ul>
            <li id="liConsulta"><a href="#tabConsulta" onclick="getContentTab();">Consulta</a></li>
        </ul>

    
  
     <div id="tabConsulta" >
      
       <div style="padding-top:5px;">
          
           <table cellpadding="0" cellspacing="0">
           <tr>
           <td style="width:500px padding-right: 10px;" valign="top">
                  <div class="ui-jqgrid-titlebar ui-widget-header ui-corner-top ui-helper-clearfix">
                   Vehiculo Marca
                  </div>

                  <table width="400px">
           <tr align="right">
               <td style="font-weight: bold">
                   <div style="text-align: center; width 400px; color: Black; font-weight: bold">
                       Cantidad de registros :
                       
                       <label id="lblNumeroConsulta">0</label> 
                   </div>
               </td>
               <td style="padding-left: 2px;">
                   <table>
                       <tr>
                       <td>    
                           &nbsp;</td>
                           
                       </tr>
                   </table>
               </td>
           </tr>
     </table>
                  <div style="margin: 10px 0 0 0">
                  <table class="GridView" cellpadding="0" cellspacing="0" style="min-width: 300px; width:420px; margin: 0 0 0 0">
                <tr>
                    <th scope="col" style="width: 16%">
                     <asp:ImageButton runat="server" ID="imgGrillaVehiculoMarca" ImageUrl="../Asset/images/add_small.png"
                                    ToolTip="AGREGAR MARCA DE VEHICULO" OnClientClick="F_Agregar_Marca();return false;" />
                    </th>
                    <th align="center" scope="col" style="width: 9%">
                        ITEM
                    </th>
                    <th align="center" scope="col" style="width: 50%">
                        DESCRIPCION
                    </th>
                    <th align="center" scope="col" style="width: 25%">
                        ESTADO
                    </th>
                   
                    <th id="EL_CHUCO_COLUMN" scope="col" style="width:1px">
                        &nbsp;
                    </th>
                </tr>
            </table>
        </div>
                  <div id="div_consulta" style=" overflow-y: scroll; max-height: 90vh; min-width: 300px; width:420px;">
                          <asp:GridView ID="grvConsulta" runat="server" AutoGenerateColumns="False"
                                        border="0" CellPadding="0" CellSpacing="1" CssClass="GridView" GridLines="None"
                                        Width="100%" ShowHeader="false">

                       <Columns>
                         <asp:TemplateField HeaderText="">
                         <HeaderTemplate>                         
                                <asp:ImageButton runat="server" ID="imgGrillaMarca" ImageUrl="../Asset/images/add_small.png"
                                    ToolTip="AGREGAR MARCA" OnClientClick="F_Agregar_Marca();return false;" />
                          
                         </HeaderTemplate>

                          <ItemTemplate>
                             <asp:ImageButton runat="server" ID="imgAnularDocumento" ImageUrl="~/Asset/images/EliminarBtn.png"
                                 ToolTip="ELIMINAR MARCA" OnClientClick="F_EliminarMarca(this); return false;" />
                           
                             <asp:ImageButton runat="server" ID="imgEditarRegistro" ImageUrl="../Asset/images/btnEdit.gif"
                             ToolTip="EDITAR MARCA" OnClientClick="F_EditarMarca(this); return false;" />
                                           
                             <asp:ImageButton runat="server" ID="imgGrillaModelo" ImageUrl="../Asset/images/ok.gif"
                              ToolTip="VER MODELO" OnClientClick="F_LlenarGridModelo(this); return false;"  />   
                                                                   
                         </ItemTemplate>
                            <FooterStyle HorizontalAlign="Center" />
                         <ItemStyle Width="16%" />
                         </asp:TemplateField>
                             <asp:BoundField DataField="Item" HeaderText="Items" HeaderStyle-CssClass="narrow-column" ItemStyle-Width="9.1%">
                             </asp:BoundField>

                             <asp:TemplateField HeaderText="Descripcion" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="50%">

                         <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            <ItemStyle HorizontalAlign="left" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblDescripcion" Text='<%# Bind("Descripcion") %>' CssClass="detallesart"></asp:Label>
                                <asp:HiddenField ID="hfCodEstado" runat="server" Value='<%# Bind("CodEstado") %>' />
                                <asp:HiddenField ID="hfCodVehiculo" runat="server" Value='<%# Bind("CodVehiculo") %>' />
                                 
                            </ItemTemplate>
                        </asp:TemplateField>

                               <asp:BoundField DataField="Estado" HeaderText="Estado" HeaderStyle-CssClass="narrow-column2" ItemStyle-Width="24.9%">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                                                     
                        </Columns>
                        <HeaderStyle CssClass="fixed-header" />
                          </asp:GridView>
                  </div>
                 </td>
          
           <td style="width:580px; padding-left: 10px;" valign="top">
                
                 <div class="ui-jqgrid-titlebar ui-widget-header ui-corner-top ui-helper-clearfix">
                                VEHICULO MODELO
                 </div>
                 <table width="400px">
                          <tr align="right">
                              <td style="font-weight: bold">
                              </td>
                              <td style="padding-left: 2px;">
                                  <table>
                                      <tr>
                                      <td style="text-align: center">    
                                  <div style="text-align: center; width 500px; color: Black; font-weight: bold">
                                      Cantidad de registros :
                                      
                                      <label id="lblNumeroConsultaModelo">0</label> 
                                  </div>
                              </td>                                          
                                      </tr>
                                  </table>
                              </td>
                            </tr>
                 </table>
                 

      <div style="margin: 10px 0 0 0">
                  <table class="GridView" cellpadding="0" cellspacing="0" style="min-width: 600px; width:750px; margin: 0 0 0 0">
                <tr>
                    <th scope="col" style="width: 7%">
                     <asp:ImageButton runat="server" ID="imgGrillaMarcaModelo" ImageUrl="../Asset/images/add_small.png"
                                    ToolTip="AGREGAR MODELO" OnClientClick="F_Agregar_Modelo();return false;" />
                                    <asp:HiddenField ID="hfCodVehiculoMarca" runat="server" ClientIDMode="Static" />
                    </th>
                    <th align="center" scope="col" style="width: 5.1%">
                        
                    </th>

                    <th align="center" scope="col" style="width: 5.2%">
                        ITEM
                    </th>                    

                    <th align="center" scope="col" style="width: 26%">
                        MARCA
                    </th>
                    <th align="center" scope="col" style="width: 42.2%">
                        DESCRIPCION
                    </th>
                    <th align="center" scope="col" style="width: 14.5%">
                        ESTADO
                    </th>
                  
                    
                    <th id="Th1" scope="col" style="width:1px">
                        &nbsp;
                    </th>
                </tr>
            </table>
        </div>

          <div id="div_consulta_modelo" style="overflow-y: scroll; max-height: 90vh; min-width: 400px; width:750px">
         <asp:GridView ID="grvConsultaModelo" runat="server" AutoGenerateColumns="False" 
                  border="0" CellPadding="0" CellSpacing="1" CssClass="GridView" GridLines="None" Width="732px" 
         OnRowDataBound="grvConsultaDetalle_RowDataBound" ShowHeader="false">
         <Columns>

                        <asp:TemplateField HeaderText="" >
                               <HeaderTemplate>
                               <asp:ImageButton runat="server" ID="imgGrillaMarcaModelo" ImageUrl="../Asset/images/add_small.png"
                                    ToolTip="AGREGAR MODELO" OnClientClick="F_Agregar_Modelo();return false;" />
                               </HeaderTemplate>
                               <ItemTemplate>
                                 <asp:ImageButton runat="server" ID="imgAnularDocumento" ImageUrl="~/Asset/images/EliminarBtn.png"
                                        ToolTip="ELIMINAR MODELO" OnClientClick="F_EliminarModelo(this); return false;" />
                                 <asp:ImageButton runat="server" ID="imgEditarRegistro" ImageUrl="../Asset/images/btnEdit.gif"
                                        ToolTip="EDITAR MODELO" OnClientClick="F_EditarModelo(this); return false;" />
                               </ItemTemplate>
                              <ItemStyle Width="7%" /> <%--AQUI ES LA COLUMNA DEL  +--%>
                            </asp:TemplateField>                            

                     <%---------------AQUI COMIENZA LA GRILLA DE PRODUCTO CON SU  FUNCION DE GRVCOSNUTADETALLE_ROWDATBOUND-------%>
                      <asp:TemplateField HeaderText="">
                     
                      <ItemTemplate>
                             <img id="imgTipoMotor" alt="" style="cursor: pointer" src="../Asset/images/plus.gif" onclick="F_Buscar_TipoMotor(this);" title="VER TIPO MOTOR" />
                               <asp:Panel ID="pnlTipoMotor" runat="server" Style="display: none">
                                  <asp:GridView ID="grvTipoMotor" runat="server" border="0" CellPadding="0"
                                      CellSpacing="1" AutoGenerateColumns="False" GridLines="None" class="GridView" Width="580px" >
                              <Columns>
                                      <asp:TemplateField HeaderText="">
                                               <HeaderTemplate>
                                            <asp:ImageButton runat="server" ID="imgGrillaMotor" ImageUrl="../Asset/images/add_small.png"
                                                                            ToolTip="AGREGAR MOTOR" 
                                                                            OnClientClick="F_Agregar_Motor();return false;" />

                                                                         </HeaderTemplate>
                                       
                                       <ItemTemplate>
                                        <asp:ImageButton runat="server" ID="imgAnularDocumento" ImageUrl="../Asset/images/EliminarBtn.png"
                                    ToolTip="ELIMNAR TIPO MOTOR" OnClientClick="F_EliminarTipoMotor(this); return false;" />
                                       
                                       <asp:ImageButton runat="server" ID="imgEditarRegistro" ImageUrl="../Asset/images/btnEdit.gif"
                                    ToolTip="EDITAR TIPO MOTOR" OnClientClick="F_EditarTipoMotor(this); return false;" />

                                      </ItemTemplate>
                                      <ItemStyle Width="9%"/>

                                       </asp:TemplateField>                                   

                                      <asp:BoundField DataField="Item" HeaderText="Item" 
                                      HeaderStyle-CssClass="narrow-column"  >
                                      <HeaderStyle HorizontalAlign="Center"  Width="6%"/>
                             </asp:BoundField>                                   
                                   
                                    
                                      <asp:TemplateField HeaderText="DESCRIPCION" HeaderStyle-HorizontalAlign="Center">
                                       <HeaderStyle HorizontalAlign="Center" Width="60%" /> 
                                        <ItemStyle HorizontalAlign="left" />
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblDescripcion" Text='<%# Bind("Descripcion") %>'></asp:Label>
                                            <asp:HiddenField ID="hfCodMotor" runat="server" Value='<%# Bind("CodMotor") %>' />                                            
                                            <asp:HiddenField ID="hfCodEstado" runat="server" Value='<%# Bind("CodEstado") %>' />                                     
                                            <asp:HiddenField ID="hfCodModelo" runat="server" Value='<%# Bind("CodModelo") %>' />                                         
                                            <asp:HiddenField ID="hfCodVehiculo" runat="server" Value='<%# Bind("CodVehiculo") %>' />  
                                         </ItemTemplate>
                                       </asp:TemplateField>
                                                                       
                                      <asp:BoundField DataField="Estado" HeaderText="Estado">
                                       <HeaderStyle HorizontalAlign="Center"  Width="13%"/>
                                       <ItemStyle HorizontalAlign="Left" />
                                   </asp:BoundField>
                             
                                 </Columns>
                                     </asp:GridView>
                                   </asp:Panel>

                            </ItemTemplate>
                                                  
                              <ItemStyle Width="5.1%" />  <%--  AQUI LA COLUMNA DEL VACIO  --%>                                                                         
                             <ItemStyle HorizontalAlign="Center" />
                          </asp:TemplateField>
                     <%--  AQUI TERMINA TODO GRILLA DE PRODUCTO --------------------%>                                                 

                         <asp:BoundField DataField="Item" HeaderText="Item" ItemStyle-Width="5.2%" />

                                

                         <asp:BoundField DataField="DescripcionMarca" HeaderText="Marca" ItemStyle-Width="26%" />                        
                            

                            <asp:TemplateField HeaderText="Descripcion" HeaderStyle-HorizontalAlign="Center">
                          
                              <ItemStyle Width="42.2%" />
                              <ItemStyle HorizontalAlign="left" />
                              <ItemTemplate>
                                  <asp:Label runat="server" ID="lblDescripcion" Text='<%# Bind("Descripcion") %>' CssClass="detallesart"></asp:Label>
                                  <asp:HiddenField ID="hfCodEstado" runat="server" Value='<%# Bind("CodEstado") %>' />
                                  <asp:HiddenField ID="hfCodVehiculo" runat="server" Value='<%# Bind("CodVehiculo") %>' />
                                  <asp:HiddenField ID="hfCodModelo" runat="server" Value='<%# Bind("CodModelo") %>' />
                              </ItemTemplate>
                          </asp:TemplateField>                         
                              
                            <asp:BoundField DataField="Estado" HeaderText="Estado">
                            <ItemStyle Width="14.5%" />
                                       <HeaderStyle HorizontalAlign="Center" />
                                       <ItemStyle HorizontalAlign="Left" />
                                   </asp:BoundField>

               </Columns>
               
       </asp:GridView>
      </div>
                 </td>
           </tr>
           </table>
       </div> 
  </div>
     </div>
    <div id="divRegEdiMarca" style="display: none;">
        <div class="ui-jqgrid ui-widget ui-widget-content ui-corner-all">
            <div class="ui-jqgrid-titlebar ui-widget-header ui-corner-top ui-helper-clearfix">
                DATOS DE LA MARCA DEL VEHICULO
            </div>
            <div class="ui-jqdialog-content">
                <table cellpadding="0" cellspacing="0" class="form-inputs" width="700">
                
                    <tr>
           
                        <td style="font-weight: bold">
                            Descripcion
                        </td>
                        <td>
                            <asp:TextBox ID="txtDescripcion" runat="server" Width="300" Font-Names="Arial"
                                ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                        </td>
                    </tr>

                     <tr>
                        <td style="font-weight: bold">
                            ESTADO
                        </td>
                        <td colspan='3'>
                            <div id="divEstadoVehiculo">
                                <asp:DropDownList ID="ddlEstadoVehiculo" runat="server" Font-Names="Arial" ForeColor="Blue"
                                    Font-Bold="True" Width="200">
                                </asp:DropDownList>
                            </div>
                        </td>
                    </tr>
                   
                </table>
            </div>
            <div class="linea-button">
                <asp:Button ID="btnGrabEdiVehiculoMarca" runat="server" Text="Grabar" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                    Font-Names="Arial" Font-Bold="True" Width="120px" />
            </div>
        </div>
    </div>

    <div id="divRegistroModelo" style="display: none;">
        <div class="ui-jqgrid ui-widget ui-widget-content ui-corner-all">
            <div class="ui-jqgrid-titlebar ui-widget-header ui-corner-top ui-helper-clearfix">
                DATOS DEL MODELO
            </div>
            <div class="ui-jqdialog-content">
                <table cellpadding="0" cellspacing="0" class="form-inputs" width="700">


                  <tr>
                                        <td style="font-weight: bold">
                                           MARCA
                                        </td>
                                        <td>
<div id="div_EstadoMarcaModelo">
                                <asp:DropDownList ID="ddlEstadoMarcaModelo" runat="server" Font-Names="Arial" ForeColor="Blue"
                                    Font-Bold="True" Width="412">
                                </asp:DropDownList>
                            </div>
                                       
                                        </td>
                                    </tr>


                    <tr>
           
                        <td style="font-weight: bold">
                            DESCRIPCION
                        </td>
                        <td>
                            <asp:TextBox ID="txtDescripcionModelo" runat="server" Width="410" Font-Names="Arial"
                                ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                        </td>
                    </tr>

                    <tr>
           
                        <td style="font-weight: bold">
                            ESTADO
                        </td>
                       
                       <td colspan='2'>
                            <div id="div_EstadoModelo">
                                <asp:DropDownList ID="ddlEstadoModelo" runat="server" Font-Names="Arial" ForeColor="Blue"
                                    Font-Bold="True" Width="150">
                                </asp:DropDownList>
                            </div>
                        </td>
                    </tr>

                   
                </table>
            </div>
            <div class="linea-button">
                <asp:Button ID="btnGrabarModelo" runat="server" Text="Grabar" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                    Font-Names="Arial" Font-Bold="True" Width="120px" />
            </div>
        </div>
    </div>
    
    <div id="divRegistroMotor" style="display: none;">
        <div class="ui-jqgrid ui-widget ui-widget-content ui-corner-all">
            <div class="ui-jqgrid-titlebar ui-widget-header ui-corner-top ui-helper-clearfix">
                DATOS TIPO MOTOR
            </div>
            <div class="ui-jqdialog-content">
                <table cellpadding="0" cellspacing="0" class="form-inputs" width="700">
                        <tr>
                         <td style="font-weight: bold">
                                           MARCA
                        </td>
                        <td colspan='2'>
                            <div id="div_ddlMarcaMotor">
                                <asp:DropDownList ID="ddlMarcaMotor" runat="server" Font-Names="Arial" ForeColor="Blue"
                                    Font-Bold="True" Width="270">
                                </asp:DropDownList>
                            </div>
                        </td>

                        </tr>
                        <tr>
                       <td style="font-weight: bold">
                                         MODELO
                                        </td>
      <td>
                            <div id="div_ModeloMotor">
                                <asp:DropDownList ID="ddlModeloMotor" runat="server" Font-Names="Arial" ForeColor="Blue"
                                    Font-Bold="True" Width="270">
                                </asp:DropDownList>
                            </div>
                        </td>

                
                       </tr>
                        <tr>
                       <td style="font-weight: bold">
                            Descripcion
                        </td>
                       <td>
                            <asp:TextBox ID="txtDescripcionMotor" runat="server" Width="404" Font-Names="Arial"
                                ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                        </td>
                    </tr>
                        <tr>
                 <td style="font-weight: bold ;padding-left:8px;">
                                                       Estado
                                                    </td>
                                          <td>
                             <div id="div_EstadoMotor">
                           <asp:DropDownList ID="ddlEstadoMotor" runat="server" Font-Names="Arial" ForeColor="Blue"
                               Font-Bold="True" Width="177">
                           </asp:DropDownList>
                       </div>
                        </td>
                 
                     </tr>                                
               </table>
            </div>
            <div class="linea-button">
                <asp:Button ID="btnGrabarTipoMotor" runat="server" Text="Grabar" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
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
    <input id="hfCodVehiculo" type="hidden" value="0" />
    <input id="hfCodModelo" type="hidden" value="0" />
    <input id="hfCodLinea" type="hidden" value="0" />
    <input id="hfCodMotor" type="hidden" value="0" />  

</asp:Content>

