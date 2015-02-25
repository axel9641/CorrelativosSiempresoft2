using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;
using Entidades;
using System.Web.Security;
using System.Configuration;

/// <summary>
/// Descripción breve de WebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// Para permitir que se llame a este servicio Web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
// [System.Web.Script.Services.ScriptService]
public class WebService : System.Web.Services.WebService {

    public WebService () {

        //Eliminar la marca de comentario de la línea siguiente si utiliza los componentes diseñados 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld() {
        return "Hola a todos";
    }
    [WebMethod]
    public bool InsertarTantasVeces(int veces, string conexion)
    {
        CECorrelativo obj = new CECorrelativo();
        conexion = ConfigurationManager.ConnectionStrings[conexion].ConnectionString.ToString();
        obj.CodigoAsignado= 2;        
        obj.Descripcion = "Insercion Web Services ";
        obj.Version = "1";

        bool rpta = true;
        int nrocorrelativo = 0;
        try
        {
            for (int i=0; i<veces ;i++ )
            {
                using (SqlConnection sqlcon = new SqlConnection(conexion))
                {
                    using (SqlCommand cmd = new SqlCommand("pr_icorrelativo", sqlcon))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        //cmd.Parameters.Add(new SqlParameter("@numero", obj.Numero));
                        cmd.Parameters.Add(new SqlParameter("@asignado", obj.CodigoAsignado));
                        cmd.Parameters.Add(new SqlParameter("@fecha", DateTime.Now));
                        cmd.Parameters.Add(new SqlParameter("@descripcion", obj.Descripcion+"-" + (i+1)));
                        cmd.Parameters.Add(new SqlParameter("@version", obj.Version));
                        sqlcon.Open();
                        nrocorrelativo = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return rpta;
    }    

    //---
}
