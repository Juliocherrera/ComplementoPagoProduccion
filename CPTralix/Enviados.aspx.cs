using CPTralix.Controllers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CPTralix
{
    public partial class Enviados : System.Web.UI.Page
    {
        public FacCpController facLabControler = new FacCpController();
        //public GridViewControl gridControl = new GridViewControl();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargaFacturas();
            }

            if (hdFiltrar.Value == "entra")
            {
                cargaFacturasFiltradas();
                hdFiltrar.Value = "";
            }
        }
        private void cargaFacturas()
        {
            DataTable cargaStops = facLabControler.facturasEnviadas();
            //cargaStops.AsDataView().RowFilter("");
            int numCells = 3;
            int rownum = 0;
            //cargaStops = cargaStops.Orde
            foreach (DataRow row in cargaStops.Rows)
            {
                TableRow r = new TableRow();
                for (int i = 0; i < numCells; i++)
                {
                    if (i == 0)
                    {
                        HyperLink hp1 = new HyperLink();
                        hp1.ID = "hpIndex" + rownum.ToString();
                        hp1.Text = row[i].ToString();
                        hp1.NavigateUrl = "DetallesFactura.aspx?factura=" + row[i].ToString();
                        TableCell c = new TableCell();
                        c.Controls.Add(hp1);
                        r.Cells.Add(c);
                    }
                    else
                    {
                        TableCell c = new TableCell();
                        c.Controls.Add(new LiteralControl("row "
                            + rownum.ToString() + ", cell " + i.ToString()));
                        c.Text = row[i].ToString();
                        r.Cells.Add(c);
                    }
                }


                tablaStops.Rows.Add(r);
                rownum++;
            }
        }
        private void cargaFacturasFiltradas()
        {
            tablaStops.Rows.Clear();
            DataTable cargaStops = facLabControler.facturasEnviadas();
            DataView dv = new DataView(cargaStops);
            dv.RowFilter = "Convert([Folio], System.String) like '%" + txtFiltro.Text + "%' or Cliente like '%" + txtFiltro.Text + "%' or Convert([Fecha], System.String) like '%" + txtFiltro.Text + "%'"; // query example = "id = 10"

            //encabezado


            int numCells = 3;
            int rownum = 0;
            //cargaStops = cargaStops.Orde
            foreach (DataRow row in dv.ToTable().Rows)
            {
                TableRow r = new TableRow();
                for (int i = 0; i < numCells; i++)
                {
                    if (i == 0)
                    {
                        HyperLink hp1 = new HyperLink();
                        hp1.ID = "hpIndex" + rownum.ToString();
                        hp1.Text = row[i].ToString();
                        hp1.NavigateUrl = "DetallesFactura.aspx?factura=" + row[i].ToString();
                        TableCell c = new TableCell();
                        c.Controls.Add(hp1);
                        r.Cells.Add(c);
                    }
                    else
                    {
                        TableCell c = new TableCell();
                        c.Controls.Add(new LiteralControl("row "
                            + rownum.ToString() + ", cell " + i.ToString()));
                        c.Text = row[i].ToString();
                        r.Cells.Add(c);
                    }
                }


                tablaStops.Rows.Add(r);
                rownum++;
            }
        }




    }
}