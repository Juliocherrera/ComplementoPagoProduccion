using CPTralix.Controllers;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace CPTralix
{
    public partial class DetallesFactura : System.Web.UI.Page
    {
        public FacCpController facLabControler = new FacCpController();
        public string fDesde, fHasta, concepto, tipoCobro, tipocomprobante, lugarexpedicion, metodopago33, formadepago, usocfdi, confirmacion, paisresidencia, numtributacion
        , mailenvio, numidentificacion, claveunidad, tipofactoriva, tipofactorret, coditrans, tipofactor, tasatras, codirete, tasarete, relacion, montosoloiva, montoivarete
        , ivadeiva, ivaderet, retderet, conceptoretencion, consecutivoconcepto, claveproductoservicio, valorunitario, importe, descuento, cantidadletra, uuidrel
        , identificador, version, fechapago, monedacpag, tipodecambiocpag, monto, numerooperacion, rfcemisorcuenta, nombrebanco, numerocuentaord, rfcemisorcuentaben, numcuentaben
        , tipocadenapago, certpago, cadenadelpago, sellodelpago, identpag, identdocpago, seriecpag, foliocpag, monedacpagdoc, tipocambiocpag, metododepago, numerodeparcialidad
        , importeSaldoAnterior, importepago, importesaldoinsoluto, total, subt, ivat, rett, cond, tipoc, seriee, folioe, sfolio;

        public bool error = false;

        public string serie;

        string cpagdoc = "";

        public string escrituraFactura = "", idSucursal = "", idTipoFactura = "", jsonFactura = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            imgFDesde.Visible = false;
            imgFHasta.Visible = false;
            lblFact.Text = Request.QueryString["factura"];
            if (IsPostBack)
            {
                fDesde = txtFechaDesde.Text;
                fHasta = txtFechaHasta.Text;
                concepto = txtConcepto.Text;
                tipoCobro = txtTipoCobro.Text;
                formadepago = txtFormaPago.Text;
                txtFolio.Text = "";
            }

            try
            {
                iniciaDatos();
            }
            catch (Exception EX)
            {
                string error = EX.Message;
            }
        }

        public void iniciaDatos()
        {

            try
            { //try TLS 1.3
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)12288
                                                     | (SecurityProtocolType)3072
                                                     | (SecurityProtocolType)768
                                                     | SecurityProtocolType.Tls;
            }
            catch (NotSupportedException)
            {
                try
                { //try TLS 1.2
                    ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072
                                                         | (SecurityProtocolType)768
                                                         | SecurityProtocolType.Tls;
                }
                catch (NotSupportedException)
                {
                    try
                    { //try TLS 1.1
                        ServicePointManager.SecurityProtocol = (SecurityProtocolType)768
                                                             | SecurityProtocolType.Tls;
                    }
                    catch (NotSupportedException)
                    { //TLS 1.0
                        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
                    }
                }
            }

            DataTable td = facLabControler.detalleFacturas(lblFact.Text);

            //Obtencion de datos-------------------------------------------------------------------------------------------------------------------------

            foreach (DataRow row in td.Rows)
            {

                //01-------------------------------------------------------------------------------------------------------------------------
                if (txtFolio.Text != row["SFolio"].ToString())
                {
                    txtFechaIniOP.Text = txtFechaIniOP.Text + "\r\n" + row["IdentificadorDelDocumentoPagado"].ToString();
                    FolioUUIDTxt.Text = row["UUIDident"].ToString();
                    txtFolio.Text = row["SFolio"].ToString();
                    DateTime dt = DateTime.Parse(row["FechaHoraEmision"].ToString());
                    txtFechaFactura.Text = dt.ToString("yyyy'/'MM'/'dd HH:mm:ss");

                    sfolio = row["SFolio"].ToString();


                    seriee = row["Serie"].ToString();

                    folioe = row["Folio"].ToString();
                    subt = row["Subtotal"].ToString();
                    ivat = row["TotalImpuestosTrasladados"].ToString();
                    rett = row["TotalImpuestosRetenidos"].ToString();
                    total = row["Total"].ToString();
                    cantidadletra = row["Totalconletra"].ToString();
                    //formadepago = row["FormaDePago"].ToString();
                    cond = row["CondicionesdePago"].ToString();
                    metodopago33 = row["MetodoPago"].ToString();
                    txtMoneda.Text = row["Moneda"].ToString();
                    tipoc = row["Tipodecambio"].ToString();
                    tipocomprobante = row["TipodeComprobante"].ToString();
                    lugarexpedicion = row["LugardeExpedición"].ToString();
                    usocfdi = row["UsoCFDI"].ToString();
                    confirmacion = row["Confirmación"].ToString();

                    //02-------------------------------------------------------------------------------------------------------------------------

                    txtIdCliente.Text = row["IdReceptor"].ToString();

                    txtRFC.Text = row["RFC"].ToString();
                    txtCliente.Text = row["Nombre"].ToString();
                    txtPaís.Text = row["Pais"].ToString();
                    txtCalle.Text = row["Calle"].ToString();
                    txtNoExt.Text = row["NumeroExterior"].ToString();
                    txtNoInt.Text = row["NumeroInterior"].ToString();
                    txtColonia.Text = row["Colonia"].ToString();
                    txtLocalidad.Text = row["Localidad"].ToString();
                    txtReferencia.Text = row["Referencia"].ToString();
                    txtMunicipio.Text = row["MunicipioDelegacion"].ToString();
                    txtEstado.Text = row["Estado"].ToString();
                    txtCP.Text = row["CódigoPostal"].ToString();
                    txtFechaPago.Text = row["Fechapago"].ToString();
                    paisresidencia = row["PaísResidenciaFiscal"].ToString();
                    numtributacion = row["NúmeroDeRegistroIdTributacion"].ToString();
                    mailenvio = row["CorreoEnvio"].ToString();

                    //04-------------------------------------------------------------------------------------------------------------------------

                    consecutivoconcepto = row["ConsecutivoConcepto"].ToString();
                    claveproductoservicio = row["ClaveProductooServicio"].ToString();
                    numidentificacion = row["NumeroIdentificación"].ToString();
                    claveunidad = row["ClaveUnidad"].ToString();
                    txtUnidadMedida.Text = row["ClaveUnidad"].ToString();
                    txtIdConcepto.Text = row["ClaveProductooServicio"].ToString();
                    txtCantidad.Text = row["Cantidad"].ToString();
                    txtMetodoPago.Text = row["MedotoDePago"].ToString();

                    if (concepto == null || concepto.Equals(row["Descripcion"].ToString())) { txtConcepto.Text = row["Descripcion"].ToString(); }
                    else { txtConcepto.Text = concepto; }


                    if (formadepago == null || formadepago.Equals(row["Formadepagocpag"].ToString())) { txtFormaPago.Text = row["Formadepagocpag"].ToString(); }
                    else { txtFormaPago.Text = formadepago; }


                    valorunitario = row["ValorUnitario"].ToString();
                    importe = row["Importe"].ToString();
                    descuento = row["Descuento"].ToString();

                    //CPAG-------------------------------------------------------------------------------------------------------------------------


                    DateTime dtdtt = DateTime.Parse(row["Fechapago"].ToString());
                    fechapago = dtdtt.ToString("yyyy'-'MM'-'dd'T'HH:mm:ss");
                    //fechapago =
                    identificador = row["Identificador"].ToString();
                    version = row["version"].ToString();
                    //txtFormaPago.Text = row["Formadepagocpag"].ToString();
                    monedacpag = row["Monedacpag"].ToString();
                    tipodecambiocpag = row["TipoDeCambiocpag"].ToString();
                    monto = row["Monto"].ToString();
                    numerooperacion = row["NumeroOperacion"].ToString();
                    txtRFCbancoEmisor.Text = row["RFCEmisorCuentaBeneficiario"].ToString();
                    txtBancoEmisor.Text = row["NombreDelBanco"].ToString();
                    txtCuentaPago.Text = row["NumeroCuentaOrdenante"].ToString();
                    rfcemisorcuentaben = row["RFCEmisorCuentaBeneficario"].ToString();
                    numcuentaben = row["NumerCuentaBeneficiario"].ToString();
                    tipocadenapago = row["TipoCadenaPago"].ToString();
                    certpago = row["CertificadoPago"].ToString();
                    cadenadelpago = row["CadenaDePago"].ToString();
                    sellodelpago = row["SelloDePago"].ToString();


                    //CPAGDOC-----------------------------------------------------------------------------------------------------------------------
                    DataTable detalleIdent = facLabControler.getDatosCPAGDOC(row["IdentificadorDelPago"].ToString());
                    string uid = "";

                    //foreach (DataRow rowIdent in detalleIdent.Rows)
                    //{
                    //    if (rowIdent["MedotoDePago"].ToString() == "PPD")
                    //    {
                    //        string folio = Regex.Replace(rowIdent["Foliocpag"].ToString(), @"[A-Z]", "");

                    //        string receptor = txtIdCliente.Text.ToString().Trim();
                    //        string serieinvoice = "";
                    //        if (receptor.Equals("LIVERPOL") || receptor.Equals("ALMLIVER") || receptor.Equals("LIVERTIJ") || receptor.Equals("SFERALIV") || receptor.Equals("GLOBALIV") || receptor.Equals("SETRALIV") || receptor.Equals("FACTUMLV"))
                    //        {
                    //            serieinvoice = "TDRL";
                    //        }
                    //        else
                    //        {
                    //            serieinvoice = rowIdent["Seriecpag"].ToString();
                    //        }
                    //        if (folio.Length == 7 && folio.StartsWith("99"))
                    //        {
                    //            folio = folio.Substring(folio.Length - 6, 6);
                    //        }
                    //        else if (folio.Length == 8)
                    //        {
                    //            folio = folio.Substring(folio.Length - 7, 7);
                    //        }



                    //        DataTable datosMaster = facLabControler.getDatosMaster(folio);
                    //        if (datosMaster.Rows.Count > 0)
                    //        {

                    //            foreach (DataRow rowMaster in datosMaster.Rows)
                    //            {
                    //                string invoiceMaster = Regex.Replace(rowMaster[0].ToString(), @"[A-Z]", "");

                    //                var request = (HttpWebRequest)WebRequest.Create("https://canal1.xsa.com.mx:9050/bf2e1036-ba47-49a0-8cd9-e04b36d5afd4/cfdis?folioEspecifico=" + invoiceMaster + "&serie=" + serieinvoice);
                    //                var response = (HttpWebResponse)request.GetResponse();
                    //                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

                    //                string[] separadas = responseString.Split(',');
                    //                foreach (string dato in separadas)
                    //                {
                    //                    if (dato.Contains("uuid"))
                    //                    {
                    //                        uid = dato.Replace(dato.Substring(0, 8), "").Replace("\"", "");
                    //                    }
                    //                }

                    //            }
                    //        }
                    //        else
                    //        {
                    //            var request = (HttpWebRequest)WebRequest.Create("https://canal1.xsa.com.mx:9050/bf2e1036-ba47-49a0-8cd9-e04b36d5afd4/cfdis?folioEspecifico=" + folio + "&serie=" + serieinvoice);
                    //            var response = (HttpWebResponse)request.GetResponse();
                    //            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

                    //            string[] separadas = responseString.Split(',');
                    //            foreach (string dato in separadas)
                    //            {
                    //                if (dato.Contains("uuid"))
                    //                {
                    //                    uid = dato.Replace(dato.Substring(0, 8), "").Replace("\"", "");
                    //                }
                    //            }
                    //        }
                    //          //todo: UUID DE FACTURAS PAGADAS

                    //        //txtFechaIniOP.Text = txtFechaIniOP.Text + "\r\n" + rowIdent["IdentificadorDelDocumentoPagado"].ToString();
                    //        txtFechaIniOP.Text = txtFechaIniOP.Text + "\r\n" + uid;
                    //    }
                    //}



                    //uid = "";
                    decimal importePagos = 0;
                    int contadorPUE = 0;
                    int contadorPPD = 0;




                    foreach (DataRow rowIdent in detalleIdent.Rows)
                    {
                        string folio = Regex.Replace(rowIdent["Foliocpag"].ToString().Replace("TDR", "").Trim(), @"[A-Z]", "");

                        //txtTotal.Text = importePagos.ToString();
                        string receptor = txtIdCliente.Text.ToString().Trim();
                        string serieinvoice = "";
                        if (receptor.Equals("LIVERPOL") || receptor.Equals("LIVERDED") || receptor.Equals("ALMLIVER") || receptor.Equals("LIVERTIJ") || receptor.Equals("SFERALIV") || receptor.Equals("GLOBALIV") || receptor.Equals("SETRALIV") || receptor.Equals("FACTUMLV"))
                        {
                            serieinvoice = "TDRL";
                        }
                        else
                        {
                            serieinvoice = rowIdent["Seriecpag"].ToString();
                        }
                        folio = Regex.Replace(rowIdent["Foliocpag"].ToString().Replace("TDR", "").Trim(), @"[A-Z]", "");
                        if (folio.Length == 7 && folio.StartsWith("99"))
                        {
                            folio = folio.Substring(folio.Length - 6, 6);
                        }
                        else if (folio.Length == 8)
                        {
                            folio = folio.Substring(folio.Length - 7, 7);
                        }
                        folio = folio.Replace("-", "");
                        //validar con la serie el id de sucursal-serie

                        var MetdodoPago = "";
                        DataTable datosMaster = facLabControler.getDatosMaster(folio);
                        if (datosMaster.Rows.Count > 0)
                        {

                            foreach (DataRow rowMaster in datosMaster.Rows)
                            {
                                string invoiceMaster = Regex.Replace(rowMaster[0].ToString(), @"[A-Z]", "");
                                folio = invoiceMaster;
                                var request = (HttpWebRequest)WebRequest.Create("https://canal1.xsa.com.mx:9050/bf2e1036-ba47-49a0-8cd9-e04b36d5afd4/cfdis?folioEspecifico=" + invoiceMaster + "&serie=" + serieinvoice);
                                var response = (HttpWebResponse)request.GetResponse();
                                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                                MetdodoPago = "PPD";
                                string[] separadas = responseString.Split(',');
                                foreach (string dato in separadas)
                                {
                                    if (dato.Contains("uuid"))
                                    {
                                        uid = dato.Replace(dato.Substring(0, 8), "").Replace("\"", "").Replace(":", "");
                                    }
                                    if (serieinvoice != "TDRL")
                                    {
                                        if (dato.Contains("xmlDownload"))
                                        {

                                            string xml = dato.Replace(dato.Substring(0, 15), "").Replace("\"", "");
                                            XmlDocument xDoc = new XmlDocument();
                                            xDoc.Load("https://canal1.xsa.com.mx:9050" + xml);
                                            var xmlTexto = xDoc.InnerXml.ToString();
                                            if (xmlTexto.Contains("MetodoPago=\"PPD\""))
                                            {
                                                MetdodoPago = "PPD";
                                                contadorPPD++;
                                                //PopupMsg.Message1 = "La factura es PPD!!";
                                                //PopupMsg.ShowPopUp(0);
                                            }
                                            else if (xmlTexto.Contains("MetodoPago=\"PUE\""))
                                            {
                                                MetdodoPago = "PUE";
                                                contadorPUE++;
                                                //PopupMsg.Message1 = "La factura es PUE!!";
                                                //PopupMsg.ShowPopUp(0);
                                            }
                                        }

                                    }
                                }

                            }
                        }
                        else
                        {

                            var request = (HttpWebRequest)WebRequest.Create("https://canal1.xsa.com.mx:9050/bf2e1036-ba47-49a0-8cd9-e04b36d5afd4/cfdis?folioEspecifico=" + folio + "&serie=" + serieinvoice);
                            var response = (HttpWebResponse)request.GetResponse();
                            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                            MetdodoPago = "PPD";
                            string[] separadas = responseString.Split(',');


                            foreach (string dato in separadas)
                            {
                                if (dato.Contains("uuid"))
                                {
                                    uid = dato.Replace(dato.Substring(0, 8), "").Replace("\"", "").Replace(":", "");
                                }
                                if (serieinvoice != "TDRL")
                                {
                                    if (dato.Contains("xmlDownload"))
                                    {

                                        string xml = dato.Replace(dato.Substring(0, 15), "").Replace("\"", "");
                                        XmlDocument xDoc = new XmlDocument();
                                        xDoc.Load("https://canal1.xsa.com.mx:9050" + xml);
                                        var xmlTexto = xDoc.InnerXml.ToString();
                                        if (xmlTexto.Contains("MetodoPago=\"PPD\""))
                                        {
                                            MetdodoPago = "PPD";
                                            contadorPPD++;
                                            //PopupMsg.Message1 = "La factura es PPD!!";
                                            //PopupMsg.ShowPopUp(0);
                                        }
                                        else if (xmlTexto.Contains("MetodoPago=\"PUE\""))
                                        {
                                            MetdodoPago = "PUE";
                                            contadorPUE++;
                                            //PopupMsg.Message1 = "La factura es PUE!!";
                                            //PopupMsg.ShowPopUp(0);
                                        }
                                    }
                                }
                            }
                            if (uid == "" && serieinvoice == "TDRA")
                            {
                                request = (HttpWebRequest)WebRequest.Create("https://canal1.xsa.com.mx:9050/bf2e1036-ba47-49a0-8cd9-e04b36d5afd4/cfdis?folioEspecifico=" + folio + "&serie=" + "SAEM");
                                response = (HttpWebResponse)request.GetResponse();
                                responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

                                separadas = responseString.Split(',');


                                foreach (string dato in separadas)
                                {
                                    if (dato.Contains("uuid"))
                                    {
                                        uid = dato.Replace(dato.Substring(0, 8), "").Replace("\"", "").Replace(":", "");
                                    }
                                    if (dato.Contains("xmlDownload"))
                                    {

                                        string xml = dato.Replace(dato.Substring(0, 15), "").Replace("\"", "");
                                        XmlDocument xDoc = new XmlDocument();
                                        xDoc.Load("https://canal1.xsa.com.mx:9050" + xml);
                                        var xmlTexto = xDoc.InnerXml.ToString();
                                        if (xmlTexto.Contains("MetodoPago=\"PPD\""))
                                        {
                                            MetdodoPago = "PPD";
                                            contadorPPD++;
                                            //PopupMsg.Message1 = "La factura es PPD!!";
                                            //PopupMsg.ShowPopUp(0);
                                        }
                                        else if (xmlTexto.Contains("MetodoPago=\"PUE\""))
                                        {
                                            MetdodoPago = "PUE";
                                            contadorPUE++;
                                            //PopupMsg.Message1 = "La factura es PUE!!";
                                            //PopupMsg.ShowPopUp(0);
                                        }

                                    }
                                }
                            }

                        }

                        if (MetdodoPago == "PPD")
                        {

                            identpag = rowIdent["IdentificadorDelPago"].ToString();
                            //txtFechaIniOP.Text = "\r\n" +rowIdent["IdentificadorDelDocumentoPagado"].ToString();
                            seriecpag = rowIdent["Seriecpag"].ToString();
                            foliocpag = rowIdent["Foliocpag"].ToString();
                            monedacpagdoc = rowIdent["Monedacpagdoc"].ToString();
                            tipocambiocpag = rowIdent["TipodeCambiocpagdpc"].ToString();
                            txtMetodoPago.Text = rowIdent["MedotoDePago"].ToString();
                            numerodeparcialidad = rowIdent["NumeroDeParcialidad"].ToString();
                            importeSaldoAnterior = rowIdent["ImporteSaldoAnterior"].ToString();
                            importepago = rowIdent["ImportePagado"].ToString();
                            importesaldoinsoluto = rowIdent["ImporteSaldoInsoluto"].ToString();
                            try
                            {
                                importePagos = importePagos + Convert.ToDecimal(importepago);
                                txtTotal.Text = importePagos.ToString();
                            }
                            catch (Exception ex)
                            {
                                string errors = ex.Message;
                            }

                            //txtFechaIniOP.Text = txtFechaIniOP.Text + "\r\n" + rowIdent["IdentificadorDelDocumentoPagado"].ToString();
                            txtFechaIniOP.Text = txtFechaIniOP.Text + "\r\n" + uid;
                            FolioUUIDTxt.Text = FolioUUIDTxt.Text + "\r\n" + "Serie:" + serieinvoice + " Folio:" + folio + " UUID:" + uid;



                            if (monedacpagdoc.Trim() == "USD")
                            {
                                cpagdoc = cpagdoc + ("CPAGDOC"                           //1-Tipo De Registro
                                  + "|" + identpag                                       //2-IdentificadorDelPago
                                                                                         //+ "|" + rowIdent["IdentificadorDelDocumentoPagado"].ToString()                            //3-IdentificadorDelDocumentoPagado                                              
                                  + "|" + uid                                            //3-IdentificadorDelDocumentoPagado                                              
                                  + "|" + serieinvoice                                   //4-Seriecpag
                                  + "|" + foliocpag                                      //5-Foliocpag
                                  + "|" + monedacpagdoc                                  //6-Monedacpag
                                  + "|" + ""                                             //7-TipoCambiocpagdpc
                                  + "|" + txtMetodoPago.Text                             //8-MetodoDePago
                                  + "|" + numerodeparcialidad                            //9-NumeroDeParcialidad
                                  + "|" + importepago                                    //10-ImporteSaldoAnterior
                                  + "|" + importepago                                    //11-ImportePagado                                                  
                                  + "|" + "0"                                            //12 ImporteSaldoInsoluto
                                  + "| \r\n");
                            }
                            else
                            {
                                //----------------------------------------Seccion CPAG20PAGO -------------------------------------------------------------------

                                //CPAG20PAGO (1:N)
                                //escritor.WriteLine(
                                //"CPAG20PAGO"                        //1-Tipo De Registro
                                //+ "|" + identpag                    //2-IdentificadorDelPago
                                //+ "|" + fechapago                   //3-FechaPago                                              
                                //+ "|"  + formadepagocpag            //4-Forma de pago
                                //+ "|" + moneda                      //5-Moneda
                                //+ "|"                               //6-TipoDeCambiocpag
                                //+ "|" + monto                       //7-Monto
                                //+ "|"                               //8-NumeroOperacion
                                //+ "|"                               //9-RFCEmisorCuentaOrdenante
                                //+ "|"                               //10-Nombre del Banco
                                //+ "|"                               //11-Número de Cuenta Ordenante
                                //+ "|"                               //12-RFC Emisor Cuenta Beneficiario
                                //+ "|"                               //13-Número de Cuenta Beneficiario
                                //+ "|"                               //14-Tipo Cadena Pago
                                //+ "|"                               //15-Certificado Pago
                                //+ "|"                               //16-Cadena Pago
                                //+ "|"                               //17-Sello de Pago                                                                                                 
                                //+ "|"                               //Fin Del Registro
                                //);

                                //escrituraFactura += "CPAG20PAGO"    //1-Tipo De Registro
                                //+ "|" + identpag                    //2-IdentificadorDelPago
                                //+ "|" + fechapago                   //3-FechaPago                                              
                                //+ "|"  + formadepagocpag            //4-Forma de pago
                                //+ "|" + moneda                      //5-Moneda
                                //+ "|"                               //6-TipoDeCambiocpag
                                //+ "|" + monto                       //7-Monto
                                //+ "|"                               //8-NumeroOperacion
                                //+ "|"                               //9-RFCEmisorCuentaOrdenante
                                //+ "|"                               //10-Nombre del Banco
                                //+ "|"                               //11-Número de Cuenta Ordenante
                                //+ "|"                               //12-RFC Emisor Cuenta Beneficiario
                                //+ "|"                               //13-Número de Cuenta Beneficiario
                                //+ "|"                               //14-Tipo Cadena Pago
                                //+ "|"                               //15-Certificado Pago
                                //+ "|"                               //16-Cadena Pago
                                //+ "|"                               //17-Sello de Pago                                                                                                 
                                //+ "|";                               //Fin Del Registro
                                // -------------------------- CPAG20DOC ------------------------------------------
                                //cpagdoc = cpagdoc + ("CPAG20DOC"                       //1-Tipo De Registro
                                //+ "|" + identpag                                       //2-IdentificadorDelPago
                                //+ "|" + rowIdent["IdentificadorDelDocumentoPagado"].ToString()                            //3-IdentificadorDelDocumentoPagado                                              
                                //+ "|" + uid                            //3-IdentificadorDelDocumentoPagado                                              
                                //+ "|" + serieinvoice                                      //4-Seriecpag
                                //+ "|" + foliocpag                                      //5-Foliocpag
                                //+ "|" + monedacpagdoc                                  //6-Monedacpag
                                //+ "|" + tipocambiocpag                                 //7-TipoCambiocpagdpc Equivalencia                          
                                //+ "|" + numerodeparcialidad                            //9-NumeroDeParcialidad
                                //+ "|" + importeSaldoAnterior                           //10-ImporteSaldoAnterior
                                //+ "|" + importepago                                    //11-ImportePagado                                                  
                                //+ "|" + importesaldoinsoluto                           //12 ImporteSaldoInsoluto
                                //+ "| \r\n");


                                cpagdoc = cpagdoc + ("CPAGDOC"                                              //1-Tipo De Registro
                                  + "|" + identpag                                       //2-IdentificadorDelPago
                                                                                         //+ "|" + rowIdent["IdentificadorDelDocumentoPagado"].ToString()                            //3-IdentificadorDelDocumentoPagado                                              
                                  + "|" + uid                            //3-IdentificadorDelDocumentoPagado                                              
                                  + "|" + serieinvoice                                      //4-Seriecpag
                                  + "|" + foliocpag                                      //5-Foliocpag
                                  + "|" + monedacpagdoc                                  //6-Monedacpag
                                  + "|" + tipocambiocpag                                 //7-TipoCambiocpagdpc
                                  + "|" + txtMetodoPago.Text                             //8-MetodoDePago
                                  + "|" + numerodeparcialidad                            //9-NumeroDeParcialidad
                                  + "|" + importeSaldoAnterior                           //10-ImporteSaldoAnterior
                                  + "|" + importepago                                    //11-ImportePagado                                                  
                                  + "|" + importesaldoinsoluto                           //12 ImporteSaldoInsoluto
                                  + "| \r\n");
                            }
                        }

                    }

                    if (contadorPPD == 0 && contadorPUE > 0)
                    {
                        //PopupMsg.Message1 = "La factura es PUE!! y es libre de todo PPD";
                        //PopupMsg.ShowPopUp(0);
                    }

                    //OTROS-------------------------------------------------------------------------------------------------------------------------

                    // creamos el FolioUUID
                    FolioUUIDTxt.Text = row["UUIDident"].ToString();



                    txtFechaHasta.Text = "Complemento Pago";


                    txtFechaDesde.Text = "Complemento Pago";


                    txtTipoCobro.Text = "Complemento Pago";

                }
            }
        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            try
            { //try TLS 1.3
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)12288
                                                     | (SecurityProtocolType)3072
                                                     | (SecurityProtocolType)768
                                                     | SecurityProtocolType.Tls;
            }
            catch (NotSupportedException)
            {
                try
                { //try TLS 1.2
                    ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072
                                                         | (SecurityProtocolType)768
                                                         | SecurityProtocolType.Tls;
                }
                catch (NotSupportedException)
                {
                    try
                    { //try TLS 1.1
                        ServicePointManager.SecurityProtocol = (SecurityProtocolType)768
                                                             | SecurityProtocolType.Tls;
                    }
                    catch (NotSupportedException)
                    { //TLS 1.0
                        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
                    }
                }
            }
            bool readOnly = false;
            string stilo = "editTextBox";
            string textoBoton = "Editar";
            bool visible = false;
            if (btnEdit.Text.Equals("Editar"))
            {
                readOnly = false;
                visible = true;
                stilo = "editTextBox";
                textoBoton = "Guardar";
            }
            else
            {
                string fecha1 = "", fecha2 = "";

                bool vacio = false;

                System.Globalization.DateTimeFormatInfo dateInfo = new System.Globalization.DateTimeFormatInfo();
                dateInfo.ShortDatePattern = "dd/MM/yyyy";

                if (!txtFechaDesde.Text.Equals("")) { fecha1 = txtFechaDesde.Text; imgFDesde.Visible = false; }
                else { error = true; imgFDesde.Visible = true; imgFDesde.ToolTip = "La fecha no puede estar vacía"; vacio = true; }

                if (!txtFechaHasta.Text.Equals("")) { fecha2 = txtFechaHasta.Text; imgFHasta.Visible = false; }
                else { error = true; imgFHasta.Visible = true; imgFHasta.ToolTip = "La feche no puede estar vacía"; vacio = true; }

                if (fecha1.CompareTo(fecha2) == 1 && vacio == false)
                {
                    error = true;
                    imgFDesde.Visible = true;
                    imgFDesde.ToolTip = "La Fecha inicial es mayor que la final";
                }
                if (!error)
                {
                    readOnly = true;
                    visible = false;
                    stilo = "readOnlyTextBox";
                    textoBoton = "Editar";
                }
                else
                {
                    readOnly = false;
                    visible = true;
                    stilo = "editTextBox";
                    textoBoton = "Guardar";
                }
            }
            //Se habilita el campo
            txtFechaDesde.ReadOnly = readOnly;
            txtFechaHasta.ReadOnly = readOnly;
            txtConcepto.ReadOnly = readOnly;
            txtTipoCobro.ReadOnly = readOnly;
            txtFormaPago.ReadOnly = readOnly;


            //Se elimina el estilo
            txtFechaDesde.CssClass = stilo;
            txtFechaHasta.CssClass = stilo;
            txtFechaDesde.CssClass = stilo;
            txtConcepto.CssClass = stilo;
            txtTipoCobro.CssClass = stilo;

            btnEdit.Text = textoBoton;

        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            { //try TLS 1.3
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)12288
                                                     | (SecurityProtocolType)3072
                                                     | (SecurityProtocolType)768
                                                     | SecurityProtocolType.Tls;
            }
            catch (NotSupportedException)
            {
                try
                { //try TLS 1.2
                    ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072
                                                         | (SecurityProtocolType)768
                                                         | SecurityProtocolType.Tls;
                }
                catch (NotSupportedException)
                {
                    try
                    { //try TLS 1.1
                        ServicePointManager.SecurityProtocol = (SecurityProtocolType)768
                                                             | SecurityProtocolType.Tls;
                    }
                    catch (NotSupportedException)
                    { //TLS 1.0
                        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
                    }
                }
            }
            bool campoIncorrecto = false;
            if (txtCliente.Text.Equals(""))
            {
                imgCliente.Visible = true;
                imgCliente.ToolTip = "El cliente no está capturado";
                campoIncorrecto = true;
            }

            if (txtCalle.Text.Equals(""))
            {
                imgCalle.Visible = true;
                imgCalle.ToolTip = "La calle no está capturada";
                campoIncorrecto = true;
            }

            if (txtNoExt.Equals(""))
            {
                imgNoExt.Visible = true;
                imgNoExt.ToolTip = "El No. Ext. no está capturado";
                campoIncorrecto = true;
            }

            // if (noInt.Equals (""))
            //{
            //    imgDir.Visible = true;
            //    imgDir.ToolTip = "El No. Int. no esta capturado";
            //    campoIncorrecto = true;
            //}


            if (txtColonia.Text.Equals(""))
            {
                imgColonia.Visible = true;
                imgColonia.ToolTip = "La colonia no está capturada";
                campoIncorrecto = true;
            }

            if (txtMunicipio.Text.Equals(""))
            {
                imgMunicipio.Visible = true;
                imgMunicipio.ToolTip = "El municipio no está capturado";
                campoIncorrecto = true;
            }

            if (txtEstado.Text.Equals(""))
            {
                imgEstado.Visible = true;
                imgEstado.ToolTip = "El Estado. no está capturado";
                campoIncorrecto = true;
            }

            if (txtPaís.Text.Equals(""))
            {
                imgPais.Visible = true;
                imgPais.ToolTip = "El País no está capturado";
                campoIncorrecto = true;
            }

            if (txtCP.Text.Equals(""))
            {
                imgCP.Visible = true;
                imgCP.ToolTip = "El CP. no está capturado";
                campoIncorrecto = true;
            }


            if (!campoIncorrecto)
            {
                //Se elimina el estilo
                txtFechaDesde.CssClass = "readOnlyTextBox";
                txtFechaHasta.CssClass = "readOnlyTextBox";
                txtFechaDesde.CssClass = "readOnlyTextBox";
                txtConcepto.CssClass = "readOnlyTextBox";
                txtTipoCobro.CssClass = "readOnlyTextBox";

                //generaTXT();


                //Traer variable generada por txt
                //Traer vairable idSucursal y idTipoFact
                //Traer lbltex´+.txt
                //Etiqueta archivo fuente
                //Crear el JSON
                //Insertar código petición 
                var request_ = (HttpWebRequest)WebRequest.Create("https://canal1.xsa.com.mx:9050/bf2e1036-ba47-49a0-8cd9-e04b36d5afd4/tiposCfds");
                var response_ = (HttpWebResponse)request_.GetResponse();
                var responseString_ = new StreamReader(response_.GetResponseStream()).ReadToEnd();

                string[] separadas_ = responseString_.Split('}');



                foreach (string dato in separadas_)
                {
                    if (dato.Contains("TDRC"))
                    {
                        string[] separadasSucursal_ = dato.Split(',');
                        foreach (string datoSuc in separadasSucursal_)
                        {
                            if (datoSuc.Contains("idSucursal"))
                            {
                                idSucursal = datoSuc.Replace(dato.Substring(0, 8), "").Replace("\"", "").Split(':')[1];
                            }
                            if (datoSuc.Contains("id") && !datoSuc.Contains("idSucursal"))
                            {
                                idTipoFactura = datoSuc.Replace(dato.Substring(0, 8), "").Replace("\"", "").Split(':')[1];

                            }
                        }
                    }
                }

                jsonFactura = "{\r\n\r\n  \"idTipoCfd\":" + "\"" + idTipoFactura + "\"";
                jsonFactura += ",\r\n\r\n  \"nombre\":" + "\"" + lblFact.Text + ".txt" + "\"";
                jsonFactura += ",\r\n\r\n  \"idSucursal\":" + "\"" + idSucursal + "\"";
                jsonFactura += ", \r\n\r\n  \"archivoFuente\":" + "\"" + escrituraFactura + "\"" + "\r\n\r\n}";

                string folioFactura = "", serieFactura = "", uuidFactura = "", pdf_xml_descargaFactura = "", pdf_descargaFactura = "", xlm_descargaFactura = "", cancelFactura = "", error = "";
                string salida = "";

                try
                {
                    var client = new RestClient("https://canal1.xsa.com.mx:9050/bf2e1036-ba47-49a0-8cd9-e04b36d5afd4/cfdis");
                    var request = new RestRequest(Method.PUT);

                    request.AddHeader("cache-control", "no-cache");

                    request.AddHeader("content-length", "834");
                    request.AddHeader("accept-encoding", "gzip, deflate");
                    request.AddHeader("Host", "canal1.xsa.com.mx:9050");
                    request.AddHeader("Postman-Token", "b6b7d8eb-29f2-420f-8d70-7775701ec765,a4b60b83-429b-4188-98d4-7983acc6742e");
                    request.AddHeader("Cache-Control", "no-cache");
                    request.AddHeader("Accept", "*/*");
                    request.AddHeader("User-Agent", "PostmanRuntime/7.13.0");

                    request.AddParameter("application/json", jsonFactura, ParameterType.RequestBody);
                    IRestResponse response = client.Execute(request);

                    string[] separadaFactura = response.Content.ToString().Split(',');
                    foreach (string factura in separadaFactura)
                    {
                        if (factura.Contains("errors"))
                        {
                            error += factura.Replace(factura.Substring(0, 6), "").Replace("\"", "").Split('[')[1] + "\n";
                            error = error.Replace("\\n", "").Replace("]}", "");
                            salida = "FALLA AL SUBIR";
                        }
                        else
                        {
                            if (factura.Contains("folio"))
                            {
                                folioFactura = factura.Replace(factura.Substring(0, 5), "").Replace("\"", "").Split(':')[1];
                            }

                            if (factura.Contains("serie"))
                            {
                                serieFactura = factura.Replace(factura.Substring(0, 5), "").Replace("\"", "").Split(':')[1];
                            }

                            if (factura.Contains("uuid"))
                            {
                                uuidFactura = factura.Replace(factura.Substring(0, 4), "").Replace("\"", "").Split(':')[1];
                            }

                            if (factura.Contains("pdfAndXmlDownload"))
                            {
                                pdf_xml_descargaFactura = factura.Replace(factura.Substring(0, 17), "").Replace("\"", "").Split(':')[1];
                            }

                            if (factura.Contains("pdfDownload"))
                            {
                                pdf_descargaFactura = factura.Replace(factura.Substring(0, 11), "").Replace("\"", "").Split(':')[1];
                            }

                            if (factura.Contains("xmlDownload") && !factura.Contains("pdfAndXmlDownload"))
                            {
                                xlm_descargaFactura = factura.Replace(factura.Substring(0, 11), "").Replace("\"", "").Split(':')[1];
                            }

                            if (factura.Contains("cancellCfdi"))
                            {
                                cancelFactura = factura.Replace(factura.Substring(0, 11), "").Replace("\"", "").Split(':')[1];
                            }
                        }
                    }
                }

                catch (Exception ex)
                {
                    string errors = ex.Message;
                }


                string path = System.Web.Configuration.WebConfigurationManager.AppSettings["dir"] + lblFact.Text + ".txt";

                //UploadFile file = new UploadFile();
                string ftp = System.Web.Configuration.WebConfigurationManager.AppSettings["ftp"];
                if (ftp.Equals("Si"))
                {
                    //file.prubeftp(lblFact.Text + ".txt", path, serie);
                }
                if (salida != "FALLA AL SUBIR")
                {
                    string activa = System.Web.Configuration.WebConfigurationManager.AppSettings["activa"];
                    if (activa.Equals("Si"))
                    {
                        //facLabControler.insertaFactura(txtFolio.Text, txtFechaFactura.Text);
                    }

                    //PopupMsg.Message1 = "Se ha generado correctamente el CFDi, será enviado a tu correo electrónico o podrás encontrarlo en el portal de búsqueda.";
                    //PopupMsg.ShowPopUp(0);
                }
                else
                {
                    //PopupMsg.Message1 = "Error al conectar al servicio XSA";
                    //PopupMsg.ShowPopUp(0);
                }
            }
        }

    }
}