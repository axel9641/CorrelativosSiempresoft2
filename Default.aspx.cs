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

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    //-----------------------------------------------------------------------------------
    protected void btnAceptar_Click(object sender, EventArgs e)
    {
        //try
        //{
        //    CNUsuario ObjCN = new CNUsuario();
        //    DataTable temp = new DataTable();
        //    temp = ObjCN.VerificarUsuario(txtUsuario.Text.Trim(), txtContraseña.Text.Trim(), Funciones.ObtenerIp(), ConfigurationManager.ConnectionStrings["SIEMPRESOFT"].ConnectionString.ToString());

        //    if (temp.Rows[0].ItemArray[7].ToString() == "Ok")
        //    {
                FormsAuthentication.RedirectFromLoginPage("jcachay", false);
                Funciones.SetCookie("CodigoUsuario", "3");
                DeterminarRedireccion();
        //    }
        //    else
        //    {
        //        lblError.Text = temp.Rows[0].ItemArray[7].ToString();
        //    }

        //}
        //catch (Exception ex)
        //{
        //    throw ex;

        //}

    }
    protected void DeterminarRedireccion()
    {
        Response.Redirect("~/Mantenimiento/wfCorrelativos.aspx");
    }

  
    
    //-----------------------------------------------------------------------------------
}