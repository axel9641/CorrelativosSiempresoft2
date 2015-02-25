<%@ Control Language="VB" AutoEventWireup="false" CodeFile="cuwVentanaConfirmacion.ascx.vb" Inherits="cuwVentanaConfirmacion" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ToolKit" %>

    <asp:Panel ID="pnlConfirmar" style=""  runat="server" CssClass="pnlVentana" 
        Width="320px">      
           <div class="dvTituloVentanaConfirmacion"><span id="spTitulo" runat="server" >Confirme eliminaci&oacute;n</span> </div>     
            <table border="0"  cellpadding="0" cellspacing="0" style=" width :100%">
                <tr>
                    <td colspan="2" >                
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td  class="tbcIcono">
                        <img id="imgIcono" runat="server" class="imgMsje" src="~/imagenes/msjeinfo.png" alt="Icono" />
                         <img id="img1" runat="server" c src="~/imagenes/msjeinfo.png" alt="Icono" />
                    </td>
                    <td  class="tbcMsjeVentanaConfirmacion">
                       
                            <p id="pMsje" runat="server"  >
                                
                            </p>                           
                    </td>
                  </tr>  
                    <tr>
                        <td class="TextoCeldaCentrado" colspan="2">
                            <asp:Button id="btnAceptar" runat="server" CssClass="Boton" Text="Aceptar">
                            </asp:Button> <asp:Button id="btnCancelar" runat="server" CssClass="Boton" Text="Cancelar"></asp:Button>    
                        </td>
                    </tr>                            
                <tr>
                    <td class="TextoCeldaCentrado" colspan="2">
                        &nbsp;                    
                    </td>
                </tr>
            </table>                 
        </asp:Panel>       
<ToolKit:ModalPopupExtender ID="mpeConfirmar" runat="server"        
    PopupControlID="pnlConfirmar" 
    BackgroundCssClass="modalBackground"                 
    CancelControlID="btnCancelar"
    TargetControlID="lblHide">
</ToolKit:ModalPopupExtender>    
<asp:Label ID="lblHide" runat="server" ></asp:Label>