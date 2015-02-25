
Partial Class cuwVentanaConfirmacion
    Inherits System.Web.UI.UserControl
    Public Event EjecutarOperacion()
    Public WriteOnly Property Titulo() As String
        Set(ByVal value As String)
            spTitulo.InnerHtml = value
        End Set
    End Property
    'Public WriteOnly Property Icono() As String
    '    Set(ByVal value As String)
    '        imgIcono.Src = value
    '    End Set
    'End Property
    Public WriteOnly Property Mensaje() As String
        Set(ByVal value As String)
            pMsje.InnerHtml = value
        End Set
    End Property
    Public WriteOnly Property Ocultar() As Boolean
        Set(ByVal value As Boolean)
            If value Then
                pnlConfirmar.Style.Add("display", "none")
            Else
                pnlConfirmar.Style.Add("display", "")
            End If
        End Set
    End Property

    Protected Sub btnAceptar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        RaiseEvent EjecutarOperacion()
    End Sub
    Public Sub OcultarModal()
        mpeConfirmar.Hide()
    End Sub
    Public Sub Confirmar()
        mpeConfirmar.Show()       
        ' ScriptManager.RegisterClientScriptBlock(Me.Page, Me.Page.GetType(), "ICONO", "ctl00_cphMaster_cuEliminar_imgIcono.src='imagenes/msjeinfo.png';", True)
    End Sub
End Class
