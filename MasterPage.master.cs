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

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {

            if (!Page.IsPostBack)
            {

                CargarMenu(Menu1);
                
            }

        }
        catch (Exception ex)
        {
            
        }
        finally
        {
        }
    }
    protected void CargarMenu(Menu MenuControl)
    {
        CNUsuario ObjCN = new CNUsuario();
        DataTable temp = new DataTable();
        temp = ObjCN.ListarOpcionesDeUsuario(Convert.ToInt32( Funciones.GetCookie("CodigoUsuario")),  ConfigurationManager.ConnectionStrings["SIEMPRESOFT"].ConnectionString.ToString());
        DataView Vista = new DataView(temp);
        DataTable Menu = new DataTable();
        int NumeroMenu = 0;
        Menu = Vista.ToTable(true, "CodigoSistema", "Sistema");
        foreach (DataRow fila in Menu.Rows)
        {
            MenuControl.Items.Add(new MenuItem(fila.ItemArray[1].ToString()));
            MenuControl.Items[NumeroMenu].Selectable = false;
            CargarOpciones(MenuControl, NumeroMenu, Convert.ToInt32(fila.ItemArray[0].ToString()), temp);
            
            NumeroMenu += 1;
        }

    }
    protected void CargarOpciones(Menu MenuControl, int posicion, int codigosistema, DataTable opciones)
    {
        foreach (DataRow fila in opciones.Rows)
        {
            if (codigosistema.ToString() == fila.ItemArray[0].ToString())
            {
                MenuControl.Items[posicion].ChildItems.Add(new MenuItem(fila.ItemArray[3].ToString(), "", "", fila.ItemArray[4].ToString()));
            }
        }

    }

    protected void lstLogin_LoggingOut(object sender, LoginCancelEventArgs e)
    {

    }
    protected void lstLogin_LoggedOut(object sender, EventArgs e)
    {

    }
}
