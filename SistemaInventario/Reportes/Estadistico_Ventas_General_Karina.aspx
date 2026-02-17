<%@ Page Title="Ventas" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Estadistico_Ventas_General_Karina.aspx.cs" Inherits="SistemaInventario.Reportes.Estadistico_Ventas_General_Karina" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="../Asset/js/jquery-1.10.2.js" type="text/javascript"></script>
    <script src="../Asset/js/jquery-ui-1.10.4.custom.min.js" type="text/javascript"></script>
    <script src="../Asset/js/jquery.timers.js" type="text/javascript"></script>
    <script src="../Asset/js/jq-ui/1.10.2/development-bundle/ui/i18n/jquery.ui.datepicker-es.js"  type="text/javascript"></script>      
    <script src="../Asset/js/autoNumeric-1.4.3.js" type="text/javascript"></script>
    <script src="../Asset/js/js.js" type="text/javascript"></script>
    <script src="../Scripts/alertify.min.js" type="text/javascript"></script>
    <script src="../Scripts/utilitarios.js" type="text/javascript" charset="UTF-8"></script>
    <script type="text/javascript" src="Estadistico_Ventas_General_Karina.js" charset="UTF-8"></script>

    <link href="../Asset/css/Redmond/jquery-ui-1.10.4.custom.min.css" rel="stylesheet" type="text/css" />       
    <link href="../Asset/css/style.css" rel="stylesheet" type="text/css" />
    <link href="../Asset/css/alertify.core.css" rel="stylesheet" type="text/css" />
    <link href="../Asset/css/alertify.default.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="https://cdn.jsdelivr.net/npm/chart.js"></script>
    <script type="text/javascript" src="https://cdn.jsdelivr.net/npm/chartjs-plugin-datalabels@2"></script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="titulo" style="width: 600px">
        Reporte Estadistico de Ventas
    </div>

<div style="margin:8px 0; display:flex; gap:10px; flex-wrap:wrap;">
 
    <div class="filtro-general" 
              style="padding:5px; border:1px solid #aaa; border-radius:5px; width:auto; background:#fafafa;">
        <div style="font-weight:bold; color:#2c3e50; font-size:12px; ">
            Ventas Generales
        </div>
        <div style="display:flex; align-items:center; gap:6px; font-size:10px;">
        <span class="negrita">    Desde</span>


            <asp:TextBox ID="txtDesde" runat="server" Width="60" CssClass="MesAnioPicker"
                Font-Names="Arial" ForeColor="Blue" Font-Bold="True" ReadOnly="True"></asp:TextBox>
           <span class="negrita">Hasta</span>
            <asp:TextBox ID="txtHasta" runat="server" Width="60" CssClass="MesAnioPicker"
                Font-Names="Arial" ForeColor="Blue" Font-Bold="True" ReadOnly="True"></asp:TextBox>

            <asp:Button ID="btnReporte" runat="server" Text="Generar"
                CssClass="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                Width="120px" />
        </div>
    </div>

     
    <div class="filtro-vendedor"  
              style="padding:5px; border:1px solid #aaa; border-radius:5px; width:auto; background:#fafafa; display:none">
        <div style="font-weight:bold; color:#2c3e50; font-size:10px; padding:0 4px;">
            Ventas por Vendedor
        </div>
        <div style="display:flex; align-items:center; gap:6px; font-size:10px;">
            <span>Desde</span>
            <asp:TextBox ID="txtDesdeVendedor" runat="server" Width="60" CssClass="MesAnioPicker"
                Font-Names="Arial" ForeColor="Blue" Font-Bold="True" ReadOnly="True"></asp:TextBox>

            <span>Hasta</span>
            <asp:TextBox ID="txtHastaVendedor" runat="server" Width="60" CssClass="MesAnioPicker"
                Font-Names="Arial" ForeColor="Blue" Font-Bold="True" ReadOnly="True"></asp:TextBox>

            <asp:Button ID="btnBuscarVendedor" runat="server" Text="Generar"
                CssClass="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                Width="75px" />
        </div>
    </div>

      <div class="filtro-vendedor" 
              style="padding:5px; border:1px solid #aaa; border-radius:5px; width:auto; background:#fafafa; display:none">
        <div style="font-weight:bold; color:#2c3e50; font-size:10px; padding:0 4px;">
            Ventas de Productos
        </div>
        <div style="display:flex; align-items:center; gap:6px; font-size:10px;">
            <span>Desde</span>
            <asp:TextBox ID="txtDesdeProductos" runat="server" Width="60" CssClass="MesAnioPicker"
                Font-Names="Arial" ForeColor="Blue" Font-Bold="True" ReadOnly="True"></asp:TextBox>

            <span>Hasta</span>
            <asp:TextBox ID="txtHastaProductos" runat="server" Width="60" CssClass="MesAnioPicker"
                Font-Names="Arial" ForeColor="Blue" Font-Bold="True" ReadOnly="True"></asp:TextBox>

            <asp:Button ID="btnBuscarProductos" runat="server" Text="Generar"
                CssClass="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                Width="75px" />
        </div>
    </div>


       <div class="filtro-vendedor" 
              style="padding:5px; border:1px solid #aaa; border-radius:5px; width:auto; background:#fafafa; display:none">
        <div style="font-weight:bold; color:#2c3e50; font-size:10px; padding:0 4px;">
            Ventas Por Sucursal
        </div>
        <div style="display:flex; align-items:center; gap:6px; font-size:10px;">
            <span>Desde</span>
            <asp:TextBox ID="txtDesdeSucursal" runat="server" Width="60" CssClass="MesAnioPicker"
                Font-Names="Arial" ForeColor="Blue" Font-Bold="True" ReadOnly="True"></asp:TextBox>

            <span>Hasta</span>
            <asp:TextBox ID="txtHastaSucursal" runat="server" Width="60" CssClass="MesAnioPicker"
                Font-Names="Arial" ForeColor="Blue" Font-Bold="True" ReadOnly="True"></asp:TextBox>

            <asp:Button ID="btnBuscarSucursales" runat="server" Text="Generar"
                CssClass="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                Width="75px" />
        </div>
    </div>

    

</div>



      <div id="tabRegistro" style="width: 125%; height:100%">
        <div class="ui-jqgrid ui-widget ui-widget-content ui-corner-all">
            <div class="ui-jqgrid-titlebar ui-widget-header ui-corner-top ui-helper-clearfix">
                Dashboard
            </div>


             
            <h1 style=" width:100%;text-align:center;font-size:24px;font-weight:700;font-family:'Montserrat', Arial, sans-serif;
                 letter-spacing:1.5px;padding:14px 0;margin:5px 0 12px;color:#0b3c5d;background:#eef3f7;border-bottom:3px solid #1e88e5;">
                VENTAS DE LOS ULTIMOS 6 MESES
            </h1>


               <%--     <h1 style="width:100%;text-align:center;font-size:21px;font-weight:600;font-family:'Segoe UI', Arial, sans-serif;
                        margin:10px 0 15px;color:#2c3e50;">VENTAS DE LOS ULTIMOS 6 MESES </h1>--%>



            <div id="divConsultaArticulo" style="padding:20px; display:grid; grid-template-columns: 1fr 1fr; gap:20px;">

               
              
                <div class="card-dashboard">
                   <%-- <h3 style="font-size:13px; margin:0 0 10px;">Ventas Generales</h3>--%>
                       <h3 class="titulo-grafico">Ventas Generales</h3>
                    <canvas id="canvasVentas" style="max-height:450px;"></canvas>

                </div>

                <div class="card-dashboard">
                   
                     <h3 class="titulo-grafico">Ventas por Vendedor</h3>
                    <canvas id="canvasVentasHorizontal" style="max-height:450px;"></canvas>


                </div>


                <div style="background:#fff; border:1px solid #ddd; border-radius:6px; padding:15px; display:none">
               
                      <h3 class="titulo-grafico">Distribucion de Ventas</h3>
                    <canvas id="canvasVentasPie" style="max-height:350px;"></canvas>
                </div>

               
                 <div class="card-dashboard">
                    
                    <h3 class="titulo-grafico">Ventas Por Sucursal</h3>
                    <canvas id="canvasVentasSucursal" style="max-height:380px;"></canvas>
                </div>

                  <div class="card-dashboard">
                     <h3 class="titulo-grafico">Productos Mas Vendidos</h3>
                     <canvas id="canvasVentasProducto" style="max-height:380px;"></canvas>
                </div>


              
                <div style="grid-column:span 2;">
                    <asp:GridView ID="gvRankingVentas" runat="server" AutoGenerateColumns="true"
                        CssClass="ui-widget-content ui-corner-all" Width="100%" />
                </div>

                
        <%--        <div class="linea-button" style="grid-column:span 2; text-align:right;">
                    <asp:Button ID="btnReporteExcel" runat="server" Text="Exportar a Excel" Font-Names="Arial"
                        CssClass="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                        Width="150px" />
                </div>--%>

            </div>
        </div>
    </div>
  
</asp:Content>
