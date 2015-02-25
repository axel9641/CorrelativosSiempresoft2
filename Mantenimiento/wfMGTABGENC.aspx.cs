using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using System.Data;
using System.Web.Security;
using System.Configuration;
using Entidades;

public partial class Mantenimiento_wfMGTABGENC : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {

            if (!Page.IsPostBack)
            {
                ucMsje.MsjeVisible = false;
                //buscarcorrelativos();
                Funciones.LlenarComboUsuario(ddlUsuario, ConfigurationManager.ConnectionStrings["SIEMPRESOFT"].ConnectionString.ToString());
            }

        }
        catch (Exception ex)
        {
            ucMsje.RegistrarMensajeCliente("dvMsjeError", Funciones.m_strImagenError, ex.Message + "<br />" + ex.StackTrace);
        }
        finally
        {
        }
    }
    protected void lblNuevo_Click(object sender, EventArgs e)
    {
        try
        {

            mpeNuevo.Show();
            lblTitulo.Text = "Pedir Nuevo Correlativo de MGTABGENC";
            CNCorrelativo ObjCN = new CNCorrelativo();            
            ddlUsuario.SelectedValue = Funciones.GetCookie("CodigoUsuario");
            txtfecha.Text = DateTime.Now.ToShortDateString();
            lblCodigoCorrelativo.Text = "0";
            txtDescripcion.Text = "";
            txtVersion.Text = "";

        }
        catch (Exception ex)
        {

            ucMsje.RegistrarMensajeCliente("dvMsjeError", Funciones.m_strImagenError, ex.Message + "<br />" + ex.StackTrace);
        }
        finally
        {
        }

    }
    protected void ddlRegistros_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void btnGuardarTabla_Click(object sender, EventArgs e)
    {

    }
    protected void btnAceptarEliminar_Click(object sender, EventArgs e)
    {

    }
    protected void gvCorrelativos_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
    protected void gvCorrelativos_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
    protected void gvCorrelativos_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
}