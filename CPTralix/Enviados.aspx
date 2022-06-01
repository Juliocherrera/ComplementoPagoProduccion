<%@ Page Language="C#" MasterPageFile="Site.master" AutoEventWireup="true" CodeBehind="Enviados.aspx.cs" Inherits="CPTralix.Enviados" %>

                <asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" runat="Server">
                    <label id="lblMensajes" />
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">

                        <ContentTemplate>
         <script type="text/javascript">
        function save() {
            var brk = document.getElementById('<%= hdFiltrar.ClientID %>')
            brk.value = "entra"
            // alert("Guardando")
            }
         </script>
        <input id="lblOculta" type="text" value="false" style="visibility: hidden" readonly="readOnly" /><input id="oculto" type="text" value="ticket" style="visibility: hidden" readonly="readOnly" /><input id="exist" type="text" value="existe" style="visibility: hidden" readonly="readOnly" /><br />
        <br />
        <br />
        <br />
        <center><h1>
           Complementos De Pago Enviados</h1></center>
        <br />  
           
               <%--  <asp:GridView ID="facturasGrid" runat="server" AllowPaging="True" CellPadding="4" AllowSorting="true" 
                     ForeColor="#333333" GridLines="None" OnPageIndexChanging="facturasGrid_PageIndexChanging"
                     PageSize="20" AutoGenerateSelectButton="True" OnSelectedIndexChanged="facturasGrid_SelectedIndexChanged"  OnSorting="agVendorCsvFile_Sorting">
                     <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                     <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                     <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                     <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                     <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                     <EditRowStyle BackColor="#999999" />
                     <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                 </asp:GridView>--%>
                 &nbsp;</center>
        <center>
              <td><asp:HiddenField ID="hdFiltrar" runat="server" /></td>

                    <asp:Table ID="TableFilter" class="table table-striped" runat="server" Font-Names="ARIAL"
                        BorderWidth="1" ForeColor="Black" GridLines="Both" BorderStyle="Solid">
                        <asp:TableRow>
                            <asp:TableCell HorizontalAlign="Center">
                                <asp:Label runat="server" ID="lblFiltar" Text="Filtro:" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center">
                                <asp:TextBox runat="server" ID="txtFiltro" Width="280" Text="" />
                            </asp:TableCell><asp:TableCell HorizontalAlign="Center">
                                <asp:Button runat="server" ID="btnFiltrar" Text ="Filtrar" OnClientClick="save();" />   



                            </asp:TableCell></asp:TableRow></asp:Table><br /><asp:Table  id="tablaStops" class="table table-striped"  runat="server" Font-Names="ARIAL">
            <asp:TableRow >
            <asp:TableCell HorizontalAlign="Center">
                Folio
            </asp:TableCell><asp:TableCell HorizontalAlign="Center">
                Fecha
            </asp:TableCell><asp:TableCell HorizontalAlign="Center">
                Cliente
            </asp:TableCell></asp:TableRow></asp:Table></center></ContentTemplate></asp:UpdatePanel></label></asp:Content>
            
