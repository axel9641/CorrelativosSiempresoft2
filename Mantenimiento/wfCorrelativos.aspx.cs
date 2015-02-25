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

public partial class Mantenimiento_wfCorrelativos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            
            if (!Page.IsPostBack)
            {
                ucMsje.MsjeVisible = false;
                buscarcorrelativos();
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
    protected void buscarcorrelativos()
    {
        try
        {

            CNCorrelativo ObjCN = new CNCorrelativo();
            DataTable temp = new DataTable();
            temp = ObjCN.ListarCorrelativos(ConfigurationManager.ConnectionStrings["SIEMPRESOFT"].ConnectionString.ToString());
            gvCorrelativos.DataSource = temp;
            gvCorrelativos.DataBind();
            Funciones.MostrarInformacionGrilla(temp.Rows.Count, gvCorrelativos, spRegistros);
            Funciones.OcultarColumnasGridView(gvCorrelativos, 1);
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
        try
        {
            Funciones.DDLCantidadRegistros(Convert.ToInt32(ddlRegistros.SelectedValue), gvCorrelativos);
            buscarcorrelativos();
        }
        catch (Exception ex)
        {
            ucMsje.RegistrarMensajeCliente("dvMsjeError", Funciones.m_strImagenError, ex.Message + "<br />" + ex.StackTrace);
        }
    }
    protected void gvCorrelativos_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView gvTemp;
        try
        {
            gvTemp = (GridView)(sender);
            gvTemp.PageIndex = e.NewPageIndex;
            buscarcorrelativos();
        }
        catch (Exception ex)
        {
            ucMsje.RegistrarMensajeCliente("dvMsjeError", Funciones.m_strImagenError, ex.Message + "<br />" + ex.StackTrace);
        }
    }
    protected void btnGuardarTabla_Click(object sender, EventArgs e)
    {

        try
        {
            int codigo;
            CNCorrelativo ObjCN = new CNCorrelativo();
            CECorrelativo ObjCE = new CECorrelativo();
            
            ObjCE.CodigoAsignado = Convert.ToInt32(ddlUsuario.SelectedValue);
            ObjCE.Fecha = Convert.ToDateTime(txtfecha.Text);
            ObjCE.Descripcion = txtDescripcion.Text;
            ObjCE.Version = txtVersion.Text;
            ObjCE.Codigo = Convert.ToInt32(lblCodigoCorrelativo.Text);
            if (lblCodigoCorrelativo.Text == "0")
            {                
                codigo = ObjCN.InsertarCorrelativo(ObjCE, ConfigurationManager.ConnectionStrings["SIEMPRESOFT"].ConnectionString.ToString());
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Msje", "alert('Se ha realizado la peticion de un nuevo correlativo satisfactoriamente. \\n\\n Numero de Correlativo asignado:" + codigo + "');", true);
            }
            else
            {
                ObjCE.Numero = Convert.ToInt32(txtNumero.Text.Trim());
                codigo = ObjCN.ActualizarCorrelativo(ObjCE, ConfigurationManager.ConnectionStrings["SIEMPRESOFT"].ConnectionString.ToString());
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Msje", "alert('Se ha realizado la actualizacion del correlativo satisfactoriamente.');", true);
            }

            buscarcorrelativos();

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
            lblTitulo.Text = "Pedir Nuevo Correlativo";
            CNCorrelativo ObjCN = new CNCorrelativo();
            //txtNumero.Text = ObjCN.ProximoCorrelativo(ConfigurationManager.ConnectionStrings["SIEMPRESOFT"].ConnectionString.ToString()).ToString();
            //ddlUsuario.SelectedValue = Funciones.SeleccionarUsuarioEnComboUsuario(User.Identity.Name.ToString(), ConfigurationManager.ConnectionStrings["SIEMPRESOFT"].ConnectionString.ToString());
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
    protected void gvCorrelativos_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            gvCorrelativos.SelectedIndex = Convert.ToInt32(e.CommandArgument);
            txtNumero.Text = Convert.ToString(gvCorrelativos.DataKeys[gvCorrelativos.SelectedIndex].Values["numero"]);
            ddlUsuario.SelectedValue = Convert.ToString(gvCorrelativos.DataKeys[gvCorrelativos.SelectedIndex].Values["asignado"]);
            txtfecha.Text = Convert.ToDateTime(gvCorrelativos.DataKeys[gvCorrelativos.SelectedIndex].Values["fecha"]).ToShortDateString().ToString();
            txtDescripcion.Text = Convert.ToString(gvCorrelativos.DataKeys[gvCorrelativos.SelectedIndex].Values["descripcion"]);
            txtVersion.Text = Convert.ToString(gvCorrelativos.DataKeys[gvCorrelativos.SelectedIndex].Values["version"]);
            lblCodigoCorrelativo.Text = Convert.ToString(gvCorrelativos.DataKeys[gvCorrelativos.SelectedIndex].Values["codigo"]);

            switch (e.CommandName)
            {

                case "VER":
                    {
                        btnGuardarTabla.Visible = false;
                        btnCancelarTabla.Visible = false;
                        lblTitulo.Text = "Ver Correlativo";
                        
                        mpeNuevo.Show();
                        break;
                    }
                case "EDITAR":
                    {
                        //txtNumero.Text = Convert.ToString(gvCorrelativos.DataKeys[gvCorrelativos.SelectedIndex].Values["numero"]);
                        //ddlUsuario.SelectedValue = Convert.ToString(gvCorrelativos.DataKeys[gvCorrelativos.SelectedIndex].Values["asignado"]);
                        //txtfecha.Text = Convert.ToDateTime(gvCorrelativos.DataKeys[gvCorrelativos.SelectedIndex].Values["fecha"]).ToShortDateString().ToString();
                        //txtDescripcion.Text = Convert.ToString(gvCorrelativos.DataKeys[gvCorrelativos.SelectedIndex].Values["descripcion"]);
                        //txtVersion.Text = Convert.ToString(gvCorrelativos.DataKeys[gvCorrelativos.SelectedIndex].Values["version"]);
                        //lblCodigoCorrelativo.Text = Convert.ToString(gvCorrelativos.DataKeys[gvCorrelativos.SelectedIndex].Values["codigo"]);

                        lblTitulo.Text = "Actualizar Correlativo";                        
                        btnGuardarTabla.Visible = true;
                        btnCancelarTabla.Visible = true;
                        mpeNuevo.Show();
                        break;
                    }
                case "ELIMINAR":
                    {
                        lblNumero.Text = Convert.ToString(gvCorrelativos.DataKeys[gvCorrelativos.SelectedIndex].Values["numero"]);
                        lblCodigoCorrelativoEliminar.Text = Convert.ToString(gvCorrelativos.DataKeys[gvCorrelativos.SelectedIndex].Values["codigo"]);
                        mpeEliminar.Show();
                        break;
                    }
                case "DETALLE":
                    {
                        lblCodigoCorrelativoDetalle.Text = Convert.ToString(gvCorrelativos.DataKeys[gvCorrelativos.SelectedIndex].Values["codigo"]);
                        lblCodigoDetalle.Text = "0";
                        lblDetalleTitulo.Text = "Detalle del Correlativo";
                        lblUsuarioDetalle.Text = Convert.ToString(gvCorrelativos.DataKeys[gvCorrelativos.SelectedIndex].Values["idusuario"]);
                        LimpiarRegistrarDetalle();
                        Detalle();
                        mpeDetalle.Show();
                        break;
                    }
               
            }
        }
        catch (Exception ex)
        {

            ucMsje.RegistrarMensajeCliente("dvMsjeError", Funciones.m_strImagenError, ex.Message);
        }

    }
    protected void gvCorrelativos_RowDataBound(object sender, GridViewRowEventArgs e)
    {
          if (e.Row.RowType == DataControlRowType.DataRow)
            {
                
                string usuario = e.Row.Cells[1].Text;
                LinkButton link, link2;
                link = (LinkButton)e.Row.Cells[0].FindControl("lbtnEditar");
                link2 = (LinkButton)e.Row.Cells[0].FindControl("lbtnEliminar");
                if (usuario == User.Identity.Name.ToString())
                { 
                    Funciones.AparecerDesaparecerLink(link,true);
                    Funciones.AparecerDesaparecerLink(link2, true);
                }
                else
                {
                    Funciones.AparecerDesaparecerLink(link, false);
                    Funciones.AparecerDesaparecerLink(link2, false);
                }
                

            }       
    }
    protected void btnAceptarEliminar_Click(object sender, EventArgs e)
    {
        try
        {
            int codigo;
            CNCorrelativo ObjCN = new CNCorrelativo();
            CECorrelativo ObjCE = new CECorrelativo();
            ObjCE.Codigo = Convert.ToInt32(lblCodigoCorrelativoEliminar.Text );
            ObjCE.Vigencia = false;
            
                codigo = ObjCN.EliminarCorrelativo(ObjCE, ConfigurationManager.ConnectionStrings["SIEMPRESOFT"].ConnectionString.ToString());
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Msje", "alert('Se ha desestimado el correlativo satisfactoriamente.');", true);
            

            buscarcorrelativos();

        }
        catch (Exception ex)
        {

            ucMsje.RegistrarMensajeCliente("dvMsjeError", Funciones.m_strImagenError, ex.Message + "<br />" + ex.StackTrace);
        }
        finally
        {
        }

    }
    protected void LimpiarRegistrarDetalle()
    {
        ddlTipoDetalle.SelectedValue = "Seleccione";
        txtMotivo.Text ="";
        txtNombreArchivo.Text ="";

    }
    protected void Detalle()
    {
        try
        {

            CNCorrelativo ObjCN = new CNCorrelativo();
            DataTable temp = new DataTable();
            CECorrelativo Obj = new CECorrelativo();
            Obj.Codigo = Convert.ToInt32(lblCodigoCorrelativoDetalle.Text);
            temp = ObjCN.ListarDetalleCorrelativo(Obj,ConfigurationManager.ConnectionStrings["SIEMPRESOFT"].ConnectionString.ToString());
            if (lblUsuarioDetalle.Text == User.Identity.Name.ToString())
            {
                pnPanelInsercionDetalle.Visible = true;
                pnListadoDetalle.Height = 400;
            }
            else
            {
                pnPanelInsercionDetalle.Visible = false;
                pnListadoDetalle.Height = 570;
            }
            gvDetalle.DataSource = temp;
            gvDetalle.DataBind();
            

        }
        catch (Exception ex)
        {
            ucMsje.RegistrarMensajeCliente("dvMsjeError", Funciones.m_strImagenError, ex.Message + "<br />" + ex.StackTrace);
        }
        finally
        {
        }
    }
    protected void btnGuardarAgregarDetalle_Click(object sender, EventArgs e)
    {
        try
        {

            CNCorrelativo ObjCN = new CNCorrelativo();
            CEDetalle Obj = new CEDetalle();
            Obj.Motivo = txtMotivo.Text;
            Obj.Archivo = txtNombreArchivo.Text;
            Obj.Tipo = ddlTipoDetalle.SelectedValue;
            Obj.CodigoCorrelativo = Convert.ToInt32(lblCodigoCorrelativoDetalle.Text);
            Obj.Codigo = Convert.ToInt32(lblCodigoDetalle.Text);

            if (lblCodigoDetalle.Text == "0")
            {
                ObjCN.InsertarDetalleCorrelativo(Obj, ConfigurationManager.ConnectionStrings["SIEMPRESOFT"].ConnectionString.ToString());
            }
            else
            {
                ObjCN.ActualizarDetalleCorrelativo(Obj, ConfigurationManager.ConnectionStrings["SIEMPRESOFT"].ConnectionString.ToString());
            }
            lblCodigoDetalle.Text = "0";
            Detalle();
            LimpiarRegistrarDetalle();
            mpeDetalle.Show();

        }
        catch (Exception ex)
        {
            ucMsje.RegistrarMensajeCliente("dvMsjeError", Funciones.m_strImagenError, ex.Message + "<br />" + ex.StackTrace);
        }
        finally
        {
        }

    }
    protected void gvDetalle_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            gvDetalle.SelectedIndex = Convert.ToInt32(e.CommandArgument);
                      
            switch (e.CommandName)
            {

                case "EDITAR":
                    {
                        //txtNumero.Text = Convert.ToString(gvCorrelativos.DataKeys[gvCorrelativos.SelectedIndex].Values["numero"]);
                        //ddlUsuario.SelectedValue = Convert.ToString(gvCorrelativos.DataKeys[gvCorrelativos.SelectedIndex].Values["asignado"]);
                        //txtfecha.Text = Convert.ToDateTime(gvCorrelativos.DataKeys[gvCorrelativos.SelectedIndex].Values["fecha"]).ToShortDateString().ToString();
                        //txtDescripcion.Text = Convert.ToString(gvCorrelativos.DataKeys[gvCorrelativos.SelectedIndex].Values["descripcion"]);
                        //txtVersion.Text = Convert.ToString(gvCorrelativos.DataKeys[gvCorrelativos.SelectedIndex].Values["version"]);
                        //lblCodigoCorrelativo.Text = Convert.ToString(gvCorrelativos.DataKeys[gvCorrelativos.SelectedIndex].Values["codigo"]);

                        txtMotivo.Text = Convert.ToString(gvDetalle.DataKeys[gvDetalle.SelectedIndex].Values["Motivo"]);
                        txtNombreArchivo.Text = Convert.ToString(gvDetalle.DataKeys[gvDetalle.SelectedIndex].Values["archivo"]);
                        ddlTipoDetalle.Text = Convert.ToString(gvDetalle.DataKeys[gvDetalle.SelectedIndex].Values["tipo"]);
                        lblCodigoDetalle.Text = Convert.ToString(gvDetalle.DataKeys[gvDetalle.SelectedIndex].Values["codigo"]);
                        mpeDetalle.Show();
                        break;
                    }
                case "ELIMINAR":
                    {
                        lblCodigoDetalleEliminar.Text = Convert.ToString(gvDetalle.DataKeys[gvDetalle.SelectedIndex].Values["codigo"]);
                        mpeDetalle.Show();
                        mpeEliminarDetalle.Show();
                        break;
                    }

                    

            }
        }
        catch (Exception ex)
        {

            ucMsje.RegistrarMensajeCliente("dvMsjeError", Funciones.m_strImagenError, ex.Message);
        }

    }
    protected void btnEliminarDetalle_Click(object sender, EventArgs e)
    {

        try
        {
            int codigo;
            CNCorrelativo ObjCN = new CNCorrelativo();
            CEDetalle ObjCE = new CEDetalle();
            ObjCE.Codigo = Convert.ToInt32(lblCodigoDetalleEliminar.Text);
            ObjCE.Vigencia = false;

            codigo = ObjCN.EliminarDetalleCorrelativo(ObjCE, ConfigurationManager.ConnectionStrings["SIEMPRESOFT"].ConnectionString.ToString());
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "Msje", "alert('Se ha desestimado el correlativo satisfactoriamente.');", true);
            Detalle();
            mpeDetalle.Show();

        }
        catch (Exception ex)
        {

            ucMsje.RegistrarMensajeCliente("dvMsjeError", Funciones.m_strImagenError, ex.Message + "<br />" + ex.StackTrace);
        }
        finally
        {
        }


    }
    protected void gvDetalle_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            string usuario = e.Row.Cells[1].Text;
            LinkButton link, link2;
            link = (LinkButton)e.Row.Cells[0].FindControl("lbtnEditar");
            link2 = (LinkButton)e.Row.Cells[0].FindControl("lbtnEliminar");
            if (lblUsuarioDetalle.Text == User.Identity.Name.ToString())
            {
                Funciones.AparecerDesaparecerLink(link, true);
                Funciones.AparecerDesaparecerLink(link2, true);
            }
            else
            {
                Funciones.AparecerDesaparecerLink(link, false);
                Funciones.AparecerDesaparecerLink(link2, false);
            }


        }       

    }
}