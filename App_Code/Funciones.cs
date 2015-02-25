/*--------------------+
BITACORA DE CAMBIOS |
--------------------+----------------------------------------------------------------------------------------------------------
 CODIGO	    REQUERIMIENTO	ANALISTA 	 	        FECHA		    MOTIVO 
 #--------------------------------------------------------------------------------------------------------------------------------
 */
using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.IO;
using System.Text;
using System.Collections.Generic;
using Negocio;


public class Funciones
{
    public static string m_strImagenInfo = "~/images/msjeInfo.png";
    public static string m_strImagenError = "~/images/msjeError.png";
    public static string m_strImagenAdvertencia = "~/images/msjeAdvertencia.png";
    //------------------------------------------------------------------------------------------------------
    public static string ObtenerIp()
    {
        String ip =
        HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

        if (string.IsNullOrEmpty(ip))
        {
            ip = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
        }

        return ip;

    }
    public static void MostrarInformacionGrilla(int intNumRegistros, GridView grilla, Label Etiqueta)
    {
        int intNumRegIni = 0;
        if (grilla.Rows.Count > 0)
        {
            intNumRegIni = grilla.PageIndex * grilla.PageSize + 1;
        }
        //else
        //    intNumRegIni = 1;

        Etiqueta.Text = "Registro: " + intNumRegIni.ToString().Trim() + " a " + ((grilla.PageIndex * grilla.PageSize) + (grilla.Rows.Count)).ToString().Trim() + " de " + intNumRegistros.ToString().Trim();

    }
    public static void DDLCantidadRegistros(Int32 Cantidad, GridView grilla)
    {
        if (Cantidad != 0)
        {
            grilla.AllowPaging = true;
            grilla.PageSize = Cantidad;
        }
        else
        {
            grilla.AllowPaging = false;
            grilla.PageIndex = 0;
        }

        if (grilla.Rows.Count > 0)
        {
            grilla.SelectedIndex = -1;
        }
    }
    public static void LlenarComboUsuario(DropDownList Combo, string Conexion)
    {
        DataTable dtData;
        CNUsuario Obj = new CNUsuario();
        DataView dvData;


        dtData = Obj.ListarUsuario("",Conexion);
        dvData = dtData.DefaultView;
        Combo.DataSource = dvData.ToTable();

        Combo.DataTextField = "Nombre";
        Combo.DataValueField = "codigo";
        Combo.DataBind();
        if (Obj != null)
        {
            Obj = null;
        }

    }
    public static void OcultarColumnasGridView(GridView grid, params int[] Posiciones)
    {
        for (int i = 0; i <= grid.Rows.Count - 1; i++)
        {
            foreach (int Posicion in Posiciones)
            {
                grid.HeaderRow.Cells[Posicion].Visible = false;
                grid.Rows[i].Cells[Posicion].Visible = false;
            }
        }
    }

    public static void AparecerDesaparecerLink(LinkButton link, Boolean valor)
    {
        link.Visible = valor;
    }
    public static string SeleccionarUsuarioEnComboUsuario(string idusuario, string Conexion)
    {
        DataTable dtData;
        CNUsuario Obj = new CNUsuario();
        DataView dvData;
        dtData = Obj.ListarUsuario(idusuario, Conexion);
        dvData = dtData.DefaultView;
        string codigo = "0";
        if (dtData.Rows.Count > 0)
        {
            codigo = dtData.Rows[0].ItemArray[0].ToString();
        }
        
        if (Obj != null)
        {
            Obj = null;
        }

        return codigo;

    }
    //------------------------------------------------------------------------------------------------------
    //------------------------------------
    /*************************************FUNCIONES PARA MANEJO DE COOKIES Y REDIRECCIONAMIENTO AL INICIO DE SESION**********************************************/
    //JHV S 21/11/2013
    public static string GetCookie(string CookieName)
    {
        HttpCookie _cookie = new HttpCookie(CookieName);
        _cookie = HttpContext.Current.Request.Cookies[CookieName];
        if (_cookie != null)
        {
            return _cookie.Value;
        }
        else
        {
            return null;
        }
    }
    public static void SetCookie(string CookieName, string CookieValue)
    {
        HttpCookie _cookie = new HttpCookie(CookieName);

        // Set the cookie value.
        _cookie.Value = CookieValue;
        // Set the cookie expiration date.
        _cookie.Expires = DateTime.Now.AddDays(1);
        // Add the cookie.
        HttpContext.Current.Response.Cookies.Add(_cookie);

    }
    public static void RemoveCookie(string CookieName)
    {
        if (HttpContext.Current.Request.Cookies[CookieName] != null)
        {
            HttpCookie myCookie = new HttpCookie(CookieName);
            myCookie.Expires = DateTime.Now.AddDays(-1d);
            HttpContext.Current.Response.Cookies.Add(myCookie);

        }
    }
    public static void InicieSesion()
    {
        HttpContext.Current.Response.Redirect("~/Default.aspx");

    }
    //JHV E 21/11/2013



}

