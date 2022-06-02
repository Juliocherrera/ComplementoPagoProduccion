<%@ Page Language="C#" MasterPageFile="Site.master" AutoEventWireup="true" CodeBehind="DetallesFactura.aspx.cs" Inherits="CPTralix.DetallesFactura" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" runat="Server">
    <div class="container">
        <asp:UpdatePanel runat="server" ID="up">
            <ContentTemplate>   
                <asp:HyperLink ID="linkBusqueda" runat="server" NavigateUrl="http://172.16.137.33:1401/BusquedaLad.aspx"
                    Target="_blank">Busqueda</asp:HyperLink>
                <br />
                <br />
                <center>
                    <h1>
                        Complemento De Pago 
                        <asp:Label ID="lblFact" runat="server" Text="Label"></asp:Label>
                    </h1>
                </center>
                <br />
                <center>
                    &nbsp;</center>
                <center>
                    

  <table class="table table-striped">
  <tbody>
    <tr>
      <th scope="row">
          <asp:Label ID="lblFolio" runat="server" Text="Folio:"></asp:Label>
      </th>
      <th>
          <asp:TextBox ID="txtFolio" runat="server" CssClass="form-control readOnlyTextBox" ReadOnly="True"></asp:TextBox>
      </th>
      <th scope="row">
          <asp:Label ID="lblFechaFactura" runat="server" Text="Fecha Factura:"></asp:Label>
      </th>
      <th>
          <asp:TextBox ID="txtFechaFactura" runat="server" CssClass="form-control readOnlyTextBox" ReadOnly="True"></asp:TextBox>
      </th>
        
    </tr>
    <tr>
      <th scope="row">
        <asp:Label ID="lblIdCliente" runat="server" Text="Id Cliente"></asp:Label>
      </th>
      <th>
        <asp:TextBox ID="txtIdCliente"  runat="server" CssClass="form-control readOnlyTextBox" ReadOnly="True"></asp:TextBox>
      </th>
  
      <th scope="row">
        <asp:Label ID="lblCliente" runat="server" Text="Cliente"></asp:Label>

      </th>
        <th>
            <asp:TextBox ID="txtCliente" runat="server" CssClass="form-control readOnlyTextBox" ReadOnly="True" TextMode="MultiLine" Width="100%"></asp:TextBox>
        <asp:Image ID="imgCliente" runat="server" ImageUrl="~/img/alerta.png" Visible="False" ToolTip="No puede estar vacío" />
        </th>
   </tr>
      <tr>
                            <th scope="row">
                                <asp:Label ID="lblCalle" runat="server" Text="Calle"></asp:Label></th>
                            <th >
                                <asp:TextBox ID="txtCalle" runat="server" CssClass="form-control readOnlyTextBox" ReadOnly="True"
                                    ></asp:TextBox>
                                <asp:Image ID="imgCalle" runat="server" ImageUrl="~/img/alerta.png" Visible="False" /></th>
                            <th scope="row">
                                <asp:Label ID="lblColonia" runat="server" Text="Colonia"></asp:Label></th>
                            <th >
                                <asp:TextBox ID="txtColonia" runat="server" CssClass="form-control readOnlyTextBox" ReadOnly="True"
                                    ></asp:TextBox>
                                <asp:Image ID="imgColonia" runat="server" ImageUrl="~/img/alerta.png" Visible="False" ToolTip="No puede estar vacío" />

                            </th>
                        </tr>
      <tr>
                            <th scope="row">
                                <asp:Label ID="lblExt" runat="server" Text="No. Ext"></asp:Label></th>
                            <th>
                                <asp:TextBox ID="txtNoExt" runat="server" CssClass="form-control readOnlyTextBox" ReadOnly="True"></asp:TextBox>
                                <asp:Image ID="imgNoExt" runat="server" ImageUrl="~/img/alerta.png" Visible="False" /></th>
                            <th scope="row">
                                <asp:Label ID="lblNoInt" runat="server" Text="No. Int"></asp:Label></th>
                            <th >
                                <asp:TextBox ID="txtNoInt" runat="server" CssClass="form-control readOnlyTextBox" ReadOnly="True"></asp:TextBox></th>
                        </tr>
      <tr>
                            <th scope="row">
                                <asp:Label ID="Label7" runat="server" Text="País"></asp:Label></th>
                            <th >
                                <asp:TextBox ID="txtPaís" runat="server" CssClass="form-control readOnlyTextBox" ReadOnly="True"></asp:TextBox>
                                <asp:Image ID="imgPais" runat="server" ImageUrl="~/img/alerta.png" Visible="False" /></th>
                            <th scope="row">
                                <asp:Label ID="Label8" runat="server" Height="21px" Text="Municipio" Width="58px"></asp:Label></th>
                            <th>
                                <asp:TextBox ID="txtMunicipio" runat="server" CssClass="form-control readOnlyTextBox" ReadOnly="True"
                                    Width="273px"></asp:TextBox>
                                <asp:Image ID="imgMunicipio" runat="server" ImageUrl="~/img/alerta.png" Visible="False" /></th>
                        </tr>
      <tr>
                            <th scope="row">
                                <asp:Label ID="Label9" runat="server" Text="Localidad"></asp:Label></th>
                            <th>
                                <asp:TextBox ID="txtLocalidad" runat="server" CssClass="form-control readOnlyTextBox" ReadOnly="True"></asp:TextBox></th>
                            <th>
                                <asp:Label ID="Label10" runat="server" Text="Referencia"></asp:Label></th>
                            <th>
                                <asp:TextBox ID="txtReferencia" runat="server" CssClass="form-control readOnlyTextBox" ReadOnly="True"
                                    ></asp:TextBox></th>
                        </tr>
                        <tr>
                            <th scope="row">
                                <asp:Label ID="Label11" runat="server" Text="Estado"></asp:Label></th>
                            <th >
                                <asp:TextBox ID="txtEstado" runat="server" CssClass="form-control readOnlyTextBox" ReadOnly="True"></asp:TextBox>
                                <asp:Image ID="imgEstado" runat="server" ImageUrl="~/img/alerta.png" Visible="False" /></th>
                            <th scope="row">
                                <asp:Label ID="Label12" runat="server" Text="C.P"></asp:Label></th>
                            <th scope="row">
                                <asp:TextBox ID="txtCP" runat="server" CssClass="form-control readOnlyTextBox" ReadOnly="True"
                                    ></asp:TextBox>
                                <asp:Image ID="imgCP" runat="server" ImageUrl="~/img/alerta.png" Visible="False" /></th>
                        </tr>
      <tr>
                            <th colspan="2" style="text-align:right" scope="row">
                                <asp:Label ID="Label13" runat="server" Text="RFC"></asp:Label></th>
                            <th colspan="2">
                                <asp:TextBox ID="txtRFC" runat="server" CssClass="form-control readOnlyTextBox" ReadOnly="True"></asp:TextBox></th>
                            
                        </tr>
      <tr>
                            <th align="right">
                                </th>
                            <th align="left">
                                <asp:TextBox ID="txtFechaDesde" runat="server" CssClass="readOnlyTextBox" ReadOnly="True" Visible="False"></asp:TextBox>&nbsp;
                                <asp:Image ID="imgFDesde" runat="server" ImageUrl="~/img/alerta.png" Visible="False" /></th>
                            <th align="right">
                                </th>
                            <th align="left">
                                <asp:TextBox ID="txtFechaHasta" runat="server" CssClass="readOnlyTextBox" ReadOnly="True" Visible="False"></asp:TextBox>&nbsp;
                                <asp:Image ID="imgFHasta" runat="server" ImageUrl="~/img/alerta.png" Visible="False" /></th>
                        </tr>

           
    
  </tbody>
</table>


    <table class="table">
                         <tbody>
                        
                        
                        
                        
                        
                        
                        <tr>
                            <td align="right" style="width: 443px">
                                <asp:Label ID="Label17" runat="server" Text="Concepto"></asp:Label></td>
                            <td style="width: 221px">
                                <asp:TextBox ID="txtConcepto" runat="server" CssClass="readOnlyTextBox" Height="68px"
                                    ReadOnly="True" TextMode="MultiLine" Width="198px"></asp:TextBox></td>
                            <td align="right" style="width: 93px">
                                <asp:Label ID="Label18" runat="server" Text="Tipo de Cobro"></asp:Label></td>
                            <td align="left" style="width: 309px">
                                <asp:TextBox ID="txtTipoCobro" runat="server" CssClass="readOnlyTextBox"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 443px">
                                Pagado</td>
                            <td align="left" style="width: 221px">
                                <asp:TextBox ID="txtTotal" runat="server" CssClass="readOnlyTextBox" ReadOnly="True"></asp:TextBox>
                            </td>
                            <td align="right" style="width: 93px">
                                &nbsp;</td>
                            <td align="left" style="width: 309px">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 443px">
                                &nbsp;</td>
                            <td align="left" style="width: 221px">
                                &nbsp;</td>
                            <td align="right" style="width: 93px">
                                &nbsp;</td>
                            <td align="left" style="width: 309px">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 443px; height: 22px;">
                                Fecha Pago </td>
                            <td align="left" style="width: 221px; height: 22px;">
                                <asp:TextBox ID="txtFechaPago" runat="server" CssClass="readOnlyTextBox" ReadOnly="True"></asp:TextBox>
                                </td>
                            <td align="right" style="width: 93px; height: 22px;">
                                </td>
                            <td align="left" style="width: 309px; height: 22px;">
                                </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 443px">
                                <asp:Label ID="Label25" runat="server" Text="Cuenta Pago"></asp:Label></td>
                            <td align="left" style="width: 221px">
                                <asp:TextBox ID="txtCuentaPago" runat="server" CssClass="readOnlyTextBox" ReadOnly="True"></asp:TextBox></td>
                            <td align="right" style="width: 93px">
                                <asp:Label ID="Label26" runat="server" Text="Forma Pago"></asp:Label></td>
                            <td align="left" style="width: 309px">
                                <asp:TextBox ID="txtFormaPago" runat="server" CssClass="readOnlyTextBox" ReadOnly="True"
                                    Width="300px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 443px">
                                Banco Emisor</td>
                            <td align="left" style="width: 221px">
                                <asp:TextBox ID="txtBancoEmisor" runat="server" CssClass="readOnlyTextBox" ReadOnly="True"></asp:TextBox>
                            </td>
                            <td align="right" style="width: 93px">
                                <asp:Label ID="Label28" runat="server" Text="Moneda"></asp:Label></td>
                            <td align="left" style="width: 309px">
                                <asp:TextBox ID="txtMoneda" runat="server" CssClass="readOnlyTextBox" ReadOnly="True"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 443px">
                                RFC Banco Emisor</td>
                            <td align="left" style="width: 221px">
                                <asp:TextBox ID="txtRFCbancoEmisor" runat="server" CssClass="readOnlyTextBox" ReadOnly="True"></asp:TextBox>
                            </td>
                            <td align="right" style="width: 93px">
                                <asp:Label ID="Label30" runat="server" Text="Unidad de Medida"></asp:Label></td>
                            <td align="left" style="width: 309px">
                                <asp:TextBox ID="txtUnidadMedida" runat="server" CssClass="readOnlyTextBox" ReadOnly="True"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 443px; height: 40px;">
                                <asp:Label ID="Label33" runat="server" Text="Método Pago"></asp:Label>
                            </td>
                            <td align="left" style="width: 221px; height: 40px;">
                                <asp:TextBox ID="txtMetodoPago" runat="server" CssClass="readOnlyTextBox" ReadOnly="True"></asp:TextBox>
                            </td>
                            <td align="right" style="width: 93px; height: 40px;">
                                <asp:Label ID="Label32" runat="server" Text="Cantidad"></asp:Label></td>
                            <td align="left" style="width: 309px; height: 40px;">
                                <asp:TextBox ID="txtCantidad" runat="server" CssClass="readOnlyTextBox" ReadOnly="True"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 443px; height: 123px;">
                                <asp:Label ID="Label31" runat="server" Text="Id Concepto SAT"></asp:Label>
                            </td>
                            <td align="left" style="width: 221px; height: 123px;">
                                <asp:TextBox ID="txtIdConcepto" runat="server" CssClass="readOnlyTextBox" ReadOnly="True"></asp:TextBox>
                            </td>
                            <td align="right" style="width: 93px; height: 123px;">
                                UUID de facturas pagadas</td>
                            <td align="left" style="width: 309px; height: 123px;">
                                <asp:TextBox ID="txtFechaIniOP" runat="server" CssClass="readOnlyTextBox" ReadOnly="True" Width="298px" Height="68px" TextMode="MultiLine"></asp:TextBox>
                            </td>
                        </tr>
                             </tbody> 
                    </table>
                      <table style="width: 700px; height: 154px">
                        <tr>
                            <td align="left" style="width: 443px; height: 258px;" id="FolioUUID">
                                Relación folio UUID
<asp:TextBox ID="FolioUUIDTxt" runat="server" ReadOnly="True" Width="679px" Height="224px" TextMode="MultiLine"></asp:TextBox>

                            </td>
                            </tr>
                          </table>
  </div>
 
                   
                    &nbsp;&nbsp;</center>
                    
                
                <br />
                <center>
                    <asp:Button ID="btnEdit" runat="server" CausesValidation="False" OnClick="btnEdit_Click"
                        Text="Editar" UseSubmitBehavior="False" />
                    <asp:Button ID="btnGuardar" runat="server" OnClick="btnGuardar_Click" Text="Facturar CFDi" />
                </center>
                <br />
                 
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnEdit" />
                <asp:AsyncPostBackTrigger ControlID="btnGuardar" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
    </asp:Content>
