
Partial Class cuwMsje
    Inherits System.Web.UI.UserControl
    Public WriteOnly Property Imagen() As String
        Set(ByVal value As String)
            imgMsje.Src = value
        End Set
    End Property
    Public WriteOnly Property Mensaje() As String
        Set(ByVal value As String)
            lblMsje.Text = value
        End Set
    End Property
    Public WriteOnly Property EstiloMsje() As String
        Set(ByVal value As String)
            dvMsje.Attributes.Add("class", value)
        End Set
    End Property
    Public WriteOnly Property MsjeVisible() As Boolean
        Set(ByVal value As Boolean)
            If value Then
                dvMsje.Style.Add("display", "")
                upnlMsje.Update()
            Else
                dvMsje.Style.Add("display", "none")
                imgMsje.Src = ""
                lblMsje.Text = ""
                upnlMsje.Update()                
            End If
        End Set
    End Property
    Public WriteOnly Property UpdatePanel() As Boolean
        Set(ByVal value As Boolean)
            upnlMsje.Visible = value
        End Set
    End Property
    Public Sub RegistrarMensajeCliente(ByVal strTipo As String, ByVal strImagen As String, ByVal strMensaje As String)
        ' Page.ClientScript.RegisterStartupScript(Page.GetType, "vv", "var x=$get('ctl00_cphMaster_cuMsje_upnlMsje'); x.style.display='';", True)
        EstiloMsje = strTipo
        Imagen = strImagen
        Mensaje = strMensaje
        dvMsje.Style.Add("display", "")        
        Me.Visible = True
        upnlMsje.Visible = True
        upnlMsje.Update()
        ' ScriptManager.RegisterClientScriptBlock(upnlMsje, upnlMsje.GetType(), "PNG", "PNG_loader();", True)
    End Sub
End Class
