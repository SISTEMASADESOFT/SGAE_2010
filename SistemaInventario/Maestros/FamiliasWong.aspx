<%@ Page Title="Familias" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FamiliasWong.aspx.cs" Inherits="SistemaInventario.Maestros.FamiliasWong" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="../Asset/js/jquery-1.10.2.js" type="text/javascript"></script>
    <script src="../Asset/js/jquery-ui-1.10.4.custom.js" type="text/javascript"></script>
    <script src="../Asset/js/jquery-ui-1.10.4.custom.min.js" type="text/javascript"></script>
    <script src="../Asset/js/jquery.timers.js" type="text/javascript"></script>
    <script src="../Asset/js/jq-ui/1.10.2/development-bundle/ui/i18n/jquery.ui.datepicker-es.js"  type="text/javascript"></script>
    <script src="../Asset/js/autoNumeric-1.4.3.js" type="text/javascript"></script>
    <script src="../Asset/js/js.js" type="text/javascript"></script>
    <script src="../Scripts/utilitarios.js" type="text/javascript" language="javascript"  charset="UTF-8"></script>
    <script type="text/javascript" language="javascript" src="FamiliasWong.js" charset="UTF-8"></script>
    <link href="../Asset/css/redmond/jquery-ui-1.10.4.custom.css" rel="stylesheet" type="text/css" />
    <link href="../Asset/css/Redmond/jquery-ui-1.10.4.custom.min.css" rel="stylesheet" type="text/css" />
    <link href="../Asset/css/style.css" rel="stylesheet" type="text/css" />
    <link href="../Asset/toars/toastr.min.css" rel="stylesheet" type="text/css" />
    <script src="../Asset/toars/toastr.min.js" type="text/javascript"></script>
  
</asp:Content> 

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="titulo">
        Familias</div>
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
                   FAMILIA
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
                    <th scope="col" style="width: 2px; min-width: 62px">
                     <asp:ImageButton runat="server" ID="imgGrillaFamilia" ImageUrl="../Asset/images/add_small.png"
                                    ToolTip="AGREGAR FAMILIA" OnClientClick="F_Agregar_Familia();return false;" />
                    </th>
                    <th align="center" scope="col" style="width: 32px">
                        ITEM
                    </th>
                    <th align="center" scope="col" style="width: 290px">
                        DESCRIPCION
                    </th>
                    <th align="center" scope="col" style="width: 105px">
                        ESTADO
                    </th>
                   
                    <th id="EL_CHUCO_COLUMN" scope="col" style="width:1px">
                        &nbsp;
                    </th>
                </tr>
            </table>
        </div>
                  <div id="div_consulta" style=" overflow-y: scroll; max-height: 90vh; min-width: 300px; width:420px">
                          <asp:GridView ID="grvConsulta" runat="server" AutoGenerateColumns="False"
                                        border="0" CellPadding="0" CellSpacing="1" CssClass="GridView" GridLines="None"
                                        Width="100%" ShowHeader="false">

                       <Columns>
                         <asp:TemplateField HeaderText="">
                         <HeaderTemplate>                         
                                <asp:ImageButton runat="server" ID="imgGrillaFamilia" ImageUrl="../Asset/images/add_small.png"
                                    ToolTip="AGREGAR FAMILIA" OnClientClick="F_Agregar_Familia();return false;" />
                          
                         </HeaderTemplate>

                          <ItemTemplate>
                             <asp:ImageButton runat="server" ID="imgAnularDocumento" ImageUrl="~/Asset/images/EliminarBtn.png"
                                 ToolTip="ELIMINAR FAMILIA" OnClientClick="F_EliminarFamilia(this); return false;" />
                           
                             <asp:ImageButton runat="server" ID="imgEditarRegistro" ImageUrl="../Asset/images/btnEdit.gif"
                             ToolTip="EDITAR FAMILIA" OnClientClick="F_EditarFamilia(this); return false;" />
                                           
                             <asp:ImageButton runat="server" ID="imgGrillaCategoria" ImageUrl="../Asset/images/ok.gif"
                              ToolTip="VER CATEGORIA" OnClientClick="F_LlenarGridCategoria(this); return false;"  />   
                                                                   
                         </ItemTemplate>
                            <FooterStyle HorizontalAlign="Center" />
                         <ItemStyle Width="65px" />
                         </asp:TemplateField>

                             <asp:BoundField DataField="Item" HeaderText="Items" 
                             HeaderStyle-CssClass="narrow-column"  >
                             </asp:BoundField>

                             <asp:TemplateField HeaderText="Descripcion" HeaderStyle-HorizontalAlign="Center">

                         <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            <ItemStyle HorizontalAlign="left" />
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblDescripcion" Text='<%# Bind("Descripcion") %>' CssClass="detallesart"></asp:Label>
                                <asp:HiddenField ID="hfCodEstado" runat="server" Value='<%# Bind("CodEstado") %>' />
                                <asp:HiddenField ID="hfIDFamilia" runat="server" Value='<%# Bind("IDFamilia") %>' />
                                 <asp:HiddenField ID="hfCodFamilia" runat="server" Value='<%# Bind("CodFamilia") %>' />
                                 
                            </ItemTemplate>
                        </asp:TemplateField>

                               <asp:BoundField DataField="Estado" HeaderText="Estado" HeaderStyle-CssClass="narrow-column2" >
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
                                CATEGORIA
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
                                      
                                      <label id="lblNumeroConsultaCategoria">0</label> 
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
                    <th scope="col" style="width: 2px; min-width: 40px">
                     <asp:ImageButton runat="server" ID="ImageButton1" ImageUrl="../Asset/images/add_small.png"
                                    ToolTip="AGREGAR CATEGORIA" OnClientClick="F_Agregar_Categoria();return false;" />
                    </th>
                    <th align="center" scope="col" style="width: 48px">
                        
                    </th>

                    <th align="center" scope="col" style="width: 28px">
                        ITEM
                    </th>
                    
                    <th align="center" scope="col" style="width: 93px">
                        CODIGO
                    </th>
                    <th align="center" scope="col" style="width: 142px">
                        FAMILIA
                    </th>
                    <th align="center" scope="col" style="width: 470px">
                        DESCRIPCION
                    </th>
                    <th align="center" scope="col" style="width: 150px">
                        ESTADO
                    </th>
                  
                    
                    <th id="Th1" scope="col" style="width:1px">
                        &nbsp;
                    </th>
                </tr>
            </table>
        </div>

          <div id="div_consulta_categoria" style="overflow-y: scroll; max-height: 90vh; min-width: 400px; width:750px">
         <asp:GridView ID="grvConsultaCategoria" runat="server" AutoGenerateColumns="False" 
                  border="0" CellPadding="0" CellSpacing="1" CssClass="GridView" GridLines="None" Width="732px" 
         OnRowDataBound="grvConsultaDetalle_RowDataBound" ShowHeader="false">
         <Columns>

                        <asp:TemplateField HeaderText="" >
                               <HeaderTemplate>
                               <asp:ImageButton runat="server" ID="imgGrillaFamilia" ImageUrl="../Asset/images/add_small.png"
                                    ToolTip="AGREGAR CATEGORIA" OnClientClick="F_Agregar_Categoria();return false;" />
                               </HeaderTemplate>
                               <ItemTemplate>
                                 <asp:ImageButton runat="server" ID="imgAnularDocumento" ImageUrl="~/Asset/images/EliminarBtn.png"
                                        ToolTip="ELIMINAR CATEGORIA" OnClientClick="F_EliminarCategoria(this); return false;" />
                                 <asp:ImageButton runat="server" ID="imgEditarRegistro" ImageUrl="../Asset/images/btnEdit.gif"
                                        ToolTip="EDITAR CATEGORIA" OnClientClick="F_EditarCategoria(this); return false;" />
                               </ItemTemplate>
                              <ItemStyle Width="7%" /> <%--AQUI ES LA COLUMNA DEL  +--%>
                            </asp:TemplateField>                            

                     <%---------------AQUI COMIENZA LA GRILLA DE PRODUCTO CON SU  FUNCION DE GRVCOSNUTADETALLE_ROWDATBOUND-------%>
                      <asp:TemplateField HeaderText="">
                     
                      <ItemTemplate>
                             <img id="imgTipoProducto" alt="" style="cursor: pointer" src="../Asset/images/plus.gif" onclick="F_Buscar_TipoProducto(this);" title="VER TIPO PRODUCTO" />
                               <asp:Panel ID="pnlTipoProducto" runat="server" Style="display: none">
                                  <asp:GridView ID="grvTipoProducto" runat="server" border="0" CellPadding="0"
                                      CellSpacing="1" AutoGenerateColumns="False" GridLines="None" class="GridView" Width="580px" >
                              <Columns>
                                      <asp:TemplateField HeaderText="">
                                               <HeaderTemplate>
                                            <asp:ImageButton runat="server" ID="imgGrillaProducto" ImageUrl="../Asset/images/add_small.png"
                                                                            ToolTip="AGREGAR PRODUCTO" 
                                                                            OnClientClick="F_Agregar_Producto();return false;" />

                                                                         </HeaderTemplate>
                                       
                                       <ItemTemplate>
                                        <asp:ImageButton runat="server" ID="imgAnularDocumento" ImageUrl="../Asset/images/EliminarBtn.png"
                                    ToolTip="ELIMNAR TIPO PRODUCTO" OnClientClick="F_EliminarTipoProducto(this); return false;" />
                                       
                                       <asp:ImageButton runat="server" ID="imgEditarRegistro" ImageUrl="../Asset/images/btnEdit.gif"
                                    ToolTip="EDITAR TIPO PRODUCTO" OnClientClick="F_EditarTipoProducto(this); return false;" />

                                      </ItemTemplate>
                                      <ItemStyle Width="44px"/>

                                       </asp:TemplateField>                                   

                                      <asp:BoundField DataField="Item" HeaderText="Item" 
                                      HeaderStyle-CssClass="narrow-column"  >
                                      <HeaderStyle HorizontalAlign="Center"  Width="10px"/>
                             </asp:BoundField>
                                    
                                      <asp:TemplateField HeaderText="CODIGO" HeaderStyle-HorizontalAlign="Center">
                                        <HeaderStyle HorizontalAlign="Center" Width="50px" /> 
                                        <ItemStyle HorizontalAlign="left" />
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblCodigo" Text='<%# Bind("Codigo") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    
                                      <asp:TemplateField HeaderText="DESCRIPCION" HeaderStyle-HorizontalAlign="Center">
                                       <HeaderStyle HorizontalAlign="Center" Width="200px" /> 
                                        <ItemStyle HorizontalAlign="left" />
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblDescripcion" Text='<%# Bind("Descripcion") %>'></asp:Label>
                                            <asp:HiddenField ID="hfCodTipoProducto" runat="server" Value='<%# Bind("CodTipoProducto") %>' />                                            
                                            <asp:HiddenField ID="hfCodEstado" runat="server" Value='<%# Bind("CodEstado") %>' />
                                            <asp:HiddenField ID="hfCodAlmacen" runat="server" Value='<%# Bind("CodAlmacen") %>' />
                                            <asp:HiddenField ID="hfCodCategoria" runat="server" Value='<%# Bind("CodCategoria") %>' />                                         
                                            <asp:HiddenField ID="hfIDFamilia" runat="server" Value='<%# Bind("IDFamilia") %>' />  
                                         </ItemTemplate>
                                       </asp:TemplateField>
                                    
                                      <asp:BoundField DataField="Almacen" HeaderText="Almacen">
                                          <HeaderStyle HorizontalAlign="Center" Width="60px" /> 
                                          <ItemStyle HorizontalAlign="Left" />
                                      </asp:BoundField>                                      

                                      <asp:BoundField DataField="Estado" HeaderText="Estado">
                                       <HeaderStyle HorizontalAlign="Center"  Width="70px"/>
                                       <ItemStyle HorizontalAlign="Left" />
                                   </asp:BoundField>
                             
                                 </Columns>
                                     </asp:GridView>
                                   </asp:Panel>

                            </ItemTemplate>
                                                  
                              <ItemStyle Width="5%" />  <%--  AQUI LA COLUMNA DEL VACIO  --%>                                                                         
                             <ItemStyle HorizontalAlign="Center" />
                          </asp:TemplateField>
                     <%--  AQUI TERMINA TODO GRILLA DE PRODUCTO --------------------%>                                                 

                         <asp:BoundField DataField="Item" HeaderText="Item" ItemStyle-Width="5%" />

                                <asp:TemplateField HeaderText="Código" HeaderStyle-HorizontalAlign="Center">
                               <ItemStyle Width="11%" />
                               <ItemStyle HorizontalAlign="left" />
                               <ItemTemplate>
                                   <asp:Label runat="server" ID="lblCodigo" Text='<%# Bind("Codigo") %>'></asp:Label>
                               </ItemTemplate>
                           </asp:TemplateField>

                         <asp:BoundField DataField="DscFamilia" HeaderText="Familia" ItemStyle-Width="15%" />                        
                            

                            <asp:TemplateField HeaderText="Descripcion" HeaderStyle-HorizontalAlign="Center">
                          
                              <ItemStyle Width="42%" />
                              <ItemStyle HorizontalAlign="left" />
                              <ItemTemplate>
                                  <asp:Label runat="server" ID="lblDescripcion" Text='<%# Bind("Descripcion") %>' CssClass="detallesart"></asp:Label>
                                  <asp:HiddenField ID="hfCodEstado" runat="server" Value='<%# Bind("CodEstado") %>' />
                                  <asp:HiddenField ID="hfIDFamilia" runat="server" Value='<%# Bind("IDFamilia") %>' />
                                  <asp:HiddenField ID="hfCodCategoria" runat="server" Value='<%# Bind("CodCategoria") %>' />
                              </ItemTemplate>
                          </asp:TemplateField>                         
                              
                            <asp:BoundField DataField="Estado" HeaderText="Estado">
                            <ItemStyle Width="15%" />
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
    <div id="divRegistroFamilia" style="display: none;">
        <div class="ui-jqgrid ui-widget ui-widget-content ui-corner-all">
            <div class="ui-jqgrid-titlebar ui-widget-header ui-corner-top ui-helper-clearfix">
                DATOS FAMILIA
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
                            <div id="div_EstadoFamilia">
                                <asp:DropDownList ID="ddlEstadoFamilia" runat="server" Font-Names="Arial" ForeColor="Blue"
                                    Font-Bold="True" Width="200">
                                </asp:DropDownList>
                            </div>
                        </td>
                    </tr>
                   
                </table>
            </div>
            <div class="linea-button">
                <asp:Button ID="btnGrabarFamilia" runat="server" Text="Grabar" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                    Font-Names="Arial" Font-Bold="True" Width="120px" />
            </div>
        </div>
    </div>

    <div id="divRegistroCategoria" style="display: none;">
        <div class="ui-jqgrid ui-widget ui-widget-content ui-corner-all">
            <div class="ui-jqgrid-titlebar ui-widget-header ui-corner-top ui-helper-clearfix">
                DATOS CATEGORIA
            </div>
            <div class="ui-jqdialog-content">
                <table cellpadding="0" cellspacing="0" class="form-inputs" width="700">


                  <tr>
                                        <td style="font-weight: bold">
                                           FAMILIA
                                        </td>
                                        <td>
                                            <table cellpadding="0" cellspacing="0">
                                                <tr>
                                              <td colspan='2'>
                            <div id="div_EstadoFamiliaCategoria">
                                <asp:DropDownList ID="ddlEstadoFamiliaCategoria" runat="server" Font-Names="Arial" ForeColor="Blue"
                                    Font-Bold="True" Width="270">
                                </asp:DropDownList>
                            </div>
                        </td>
                                                    <td style="font-weight: bold ;padding-left:8px;">
                                                       CODIGO
                                                    </td>
                                         <td>
                            <asp:TextBox ID="txtCodigoCategoria" runat="server" Width="80" Font-Names="Arial"
                                ForeColor="Blue" Font-Bold="True" ></asp:TextBox>
                        </td>
                                               
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>


                    <tr>
           
                        <td style="font-weight: bold">
                            DESCRIPCION
                        </td>
                        <td>
                            <asp:TextBox ID="txtDescripcionCategoria" runat="server" Width="410" Font-Names="Arial"
                                ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                        </td>
                    </tr>

                    <tr>
           
                        <td style="font-weight: bold">
                            ESTADO
                        </td>
                       
                       <td colspan='2'>
                            <div id="div_EstadoCategoria">
                                <asp:DropDownList ID="ddlEstadoCategoria" runat="server" Font-Names="Arial" ForeColor="Blue"
                                    Font-Bold="True" Width="150">
                                </asp:DropDownList>
                            </div>
                        </td>
                    </tr>

                   
                </table>
            </div>
            <div class="linea-button">
                <asp:Button ID="btnGrabarCategoria" runat="server" Text="Grabar" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                    Font-Names="Arial" Font-Bold="True" Width="120px" />
            </div>
        </div>
    </div>
    
    <div id="divRegistroProducto" style="display: none;">
        <div class="ui-jqgrid ui-widget ui-widget-content ui-corner-all">
            <div class="ui-jqgrid-titlebar ui-widget-header ui-corner-top ui-helper-clearfix">
                DATOS TIPO PRODUCTO
            </div>
            <div class="ui-jqdialog-content">
                <table cellpadding="0" cellspacing="0" class="form-inputs" width="700">
                        <tr>
                         <td style="font-weight: bold">
                                           FAMILIA
                        </td>
                        <td colspan='2'>
                            <div id="div_ddlFamiliaProducto">
                                <asp:DropDownList ID="ddlFamiliaProducto" runat="server" Font-Names="Arial" ForeColor="Blue"
                                    Font-Bold="True" Width="407px">
                                </asp:DropDownList>
                            </div>
                        </td>

                        </tr>
                        <tr>
                       <td style="font-weight: bold">
                                         CATEGORIA
                                        </td>
                       <td style="font-weight: bold ;padding-left:0px;">
                                            <table cellpadding="0" cellspacing="0">
                                                <tr>
                                              <td colspan='2'>
                            <div id="div_CategoriaProducto">
                                <asp:DropDownList ID="ddlCategoriaProducto" runat="server" Font-Names="Arial" ForeColor="Blue"
                                    Font-Bold="True" Width="407px">
                                </asp:DropDownList>
                            </div>
                        </td>
                                                    <td style="font-weight: bold ;padding-left:8px; display:none">
                                                       Codigo
                                                    </td>
                                         <td style="display:none">
                            <asp:TextBox ID="txtCodigoProducto" runat="server" Width="80" Font-Names="Arial"
                                ForeColor="Blue" Font-Bold="True" ></asp:TextBox>
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
                            <asp:TextBox ID="txtDescripcionProducto" runat="server" Width="404" Font-Names="Arial"
                                ForeColor="Blue" Font-Bold="True"></asp:TextBox>
                        </td>
                    </tr>
                        <tr>
                       <td style="font-weight: bold">
                                           Almacen
                                        </td>
                       <td style="font-weight: bold ;padding-left:0px;">
                                            <table cellpadding="0" cellspacing="0">
                                                <tr>
                                                   <td >
                           <div id="div_Almacen">
                           <asp:DropDownList ID="ddlAlmacen" runat="server" Font-Names="Arial" ForeColor="Blue"
                               Font-Bold="True" Width="177">
                           </asp:DropDownList>
                       </div>

                        </td>
                                                    <td style="font-weight: bold ;padding-left:8px;">
                                                       Estado
                                                    </td>
                                          <td>
                             <div id="div_EstadoProducto">
                           <asp:DropDownList ID="ddlEstadoProducto" runat="server" Font-Names="Arial" ForeColor="Blue"
                               Font-Bold="True" Width="177">
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
                <asp:Button ID="btnGrabarTipoProducto" runat="server" Text="Grabar" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
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
    <input id="hfCodFamilia" type="hidden" value="0" />
    <input id="hfCodCategoria" type="hidden" value="0" />
    <input id="hfCodLinea" type="hidden" value="0" />
    <input id="hfCodTipoProducto" type="hidden" value="0" />  

</asp:Content>

