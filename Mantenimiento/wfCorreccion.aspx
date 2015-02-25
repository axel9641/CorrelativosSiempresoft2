<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfCorreccion.aspx.cs" Inherits="Mantenimiento_wfCorreccion" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="Toolkit" %>
<%@ Register src="../ControlesUsuario/cuwMsje.ascx" tagname="cuwMsje" tagprefix="ucMsje" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphMaster" Runat="Server">

<Toolkit:toolkitscriptmanager  ID="SM" runat="server" EnableScriptGlobalization="True" 
        EnableScriptLocalization="True" AsyncPostBackTimeout="360000"> 
        <Scripts>
        <asp:ScriptReference Path="~/scripts/chrome.js" />
        </Scripts>
</Toolkit:ToolkitScriptManager>
<div class="dvModuloContenido"><center>.:: CONTROL DE CORRELATIVOS DE CORRECCION ::.</center></div>
<ucMsje:cuwMsje ID="ucMsje" runat="server" />
 <asp:UpdatePanel ID="upnProceso" runat="server">
<ContentTemplate>
  <table style="width: 100%">
            <tr>
                <td align="left">
                    
                    <span class="BotonLink" id="Span7">
                    <asp:LinkButton ID="lblNuevo" runat="server" onclick="lblNuevo_Click"  style="color:White;" >
                        <span style="height:200px"><img class="imgLink"  src="../images/nueva_prop.png" alt="Pedir un nuevo Correlativo de Correccion" />Pedir un nuevo Correlativo de Correccion</span>
                    </asp:LinkButton>                    
                    </span>


                </td>
            </tr>
        </table>
  <asp:Panel ID="pnOfertas" runat="server" CssClass="pnlGrilla" 
            meta:resourcekey="pnlVistaCuentasResource1">
            <!---TITULO GRILLA-->
            <div class="dvTituloGrilla">
            <div style="float:left" >Control de Correlativos de Correccion</div> 
            <div style="float:right">
                <asp:Label ID="spRegistros" runat="server" CssClass="Paginas"></asp:Label>
                <span class="Paginas">&nbsp- Registros por página :</span>
                <asp:DropDownList ID="ddlRegistros" runat="server" AutoPostBack="True" CssClass="ddlPaginas" Width="60px" onselectedindexchanged="ddlRegistros_SelectedIndexChanged"  >
                            <asp:ListItem>50</asp:ListItem>
                            <asp:ListItem>100</asp:ListItem>
                            <asp:ListItem>250</asp:ListItem>
                            <asp:ListItem>1000</asp:ListItem>                            
                            <asp:ListItem Value="0">Todos</asp:ListItem>
                        </asp:DropDownList>
            </div>
            </div>


            <div class="dvOpcionesGrilla">
                
                <asp:GridView ID="gvCorrecciones" runat="server" AllowPaging="True" 
                    AutoGenerateColumns="False" CellPadding="4" CssClass="Grilla"                     
                    DataKeyNames="codigo,numero,asignado,fecha,descripcion,version,fechapeticion,idusuario,Nombre,mejora" 
                    ForeColor="#333333" GridLines="None" 
                   EmptyDataText="Sin Resultados..." Font-Size="11px" PageSize="50" 
                    onpageindexchanging="gvCorrecciones_PageIndexChanging" 
                    onrowcommand="gvCorrecciones_RowCommand" onrowdatabound="gvCorrecciones_RowDataBound" 
                  >
                    
                    <Columns>
                        
                         <asp:BoundField DataField="numeroHD" HeaderText="Numero">
                            <HeaderStyle CssClass="CabeceraGrilla" />
                            <ItemStyle CssClass="CeldaGrilla" />
                        </asp:BoundField>
                          <asp:BoundField DataField="idUsuario" HeaderText="idUsuario">
                            <HeaderStyle CssClass="CabeceraGrilla"  Width="100"  />
                            <ItemStyle CssClass="CeldaGrilla" />
                        </asp:BoundField>

                        <asp:BoundField DataField="nombre" HeaderText="Nombre">
                            <HeaderStyle CssClass="CabeceraGrilla"  Width="100"  />
                            <ItemStyle CssClass="CeldaGrilla" />
                        </asp:BoundField>

                        <asp:BoundField DataField="fecha" HeaderText="Fecha" DataFormatString="{0:d}">
                            <HeaderStyle CssClass="CabeceraGrilla" />
                            <ItemStyle CssClass="CeldaGrilla" />
                        </asp:BoundField>
                        
                        <asp:BoundField DataField="descripcion" HeaderText="Descripcion">
                            <HeaderStyle CssClass="CabeceraGrilla" />
                            <ItemStyle CssClass="CeldaGrilla" />
                        </asp:BoundField>
                        
                        <asp:BoundField DataField="mejora" HeaderText="Mejora">
                            <HeaderStyle CssClass="CabeceraGrilla" Width="70" />
                            <ItemStyle CssClass="CeldaGrilla" />
                        </asp:BoundField>

                          <asp:BoundField DataField="version" HeaderText="Version">
                            <HeaderStyle CssClass="CabeceraGrilla" Width="70" />
                            <ItemStyle CssClass="CeldaGrilla" />
                        </asp:BoundField>
                        
                        <asp:TemplateField HeaderText="Acción" >
                            <HeaderStyle CssClass="CabeceraGrilla" Width="150"/>
                            <ItemStyle CssClass="CeldaGrilla"  HorizontalAlign="Center"/>
                            <ItemTemplate>
                                  <asp:LinkButton ID="lbtnVer" runat="server" 
                                    CommandArgument='<%#DataBinder.Eval(Container,"RowIndex")%>' 
                                    CommandName="VER">Ver</asp:LinkButton>

                                <asp:LinkButton ID="lbtnEditar" runat="server" 
                                    CommandArgument='<%#DataBinder.Eval(Container,"RowIndex")%>' 
                                    CommandName="EDITAR">Editar</asp:LinkButton>

                               <asp:LinkButton ID="lbtnEliminar" runat="server" 
                                    CommandArgument='<%#DataBinder.Eval(Container,"RowIndex")%>' 
                                    CommandName="ELIMINAR" >Eliminar</asp:LinkButton>

                                <asp:LinkButton ID="lbtnDetalle" runat="server" 
                                    CommandArgument='<%#DataBinder.Eval(Container,"RowIndex")%>' 
                                    CommandName="DETALLE" >Detalle</asp:LinkButton>


                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                 <EmptyDataTemplate>
                     No existen registros
                 </EmptyDataTemplate>
                   <SelectedRowStyle BackColor="#AECAE8" Font-Bold="True"  />
                   <PagerStyle CssClass="PaginaGrilla" ForeColor="White" />
                   <RowStyle BackColor="#e8f1f8" CssClass="FilaGrilla" ForeColor="#333333" />
                   <AlternatingRowStyle BackColor="#FFFFFF" CssClass="FilaGrilla" ForeColor="#333333" />
                </asp:GridView>
            </div>
        </asp:Panel>



<!-- VENTANA DE Nuevo-->
            <asp:HiddenField ID="LblNuevaTabla" runat="server" />
            <Toolkit:ModalPopupExtender ID="mpeNuevo" runat="server" PopupControlID="pnlNuevo"
                TargetControlID="LblNuevaTabla" BehaviorID="mpeNuevoCte" BackgroundCssClass="modalBackground">
            </Toolkit:ModalPopupExtender>
            <asp:Panel ID="pnlNuevo" Style="display: none;" runat="server" 
        CssClass="pnlVentana" Width="410px" Height="350px" ScrollBars="Auto" >
                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                    <tr>
                        <td>
                            <div class="dvTituloPopup">
                                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                    <tr>
                                        <td style="width: 95%;" >
                                            <asp:Label ID="lblTitulo" runat="server" Text="" style="margin-left:10px;"></asp:Label>
                                        </td>
                                        <td style="width: 5%">
                                            <span class="dvCerrar" onclick="CerrarPopup('mpeNuevoCte');">X</span>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                    </tr>
                </table>
                <table align="center" style="width: 80%">
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                            <asp:Label ID="lblCodigoCorrelativo" runat="server" Text="Label" style="display:none;"></asp:Label>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            Nro HD</td>
                        <td>
                            <asp:TextBox ID="txtNumero" runat="server" Width="80px" ReadOnly="True"></asp:TextBox>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            Usuario
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlUsuario" runat="server" Width="300px" Enabled="False">
                            </asp:DropDownList>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            Fecha</td>
                        <td>
                            <asp:TextBox ID="txtfecha" runat="server" ValidationGroup="Group1" 
                                Width="80px"></asp:TextBox>
                            <Toolkit:CalendarExtender ID="CalendarExtender1" runat="server" Animated="true" 
                                Format="dd/MM/yyyy" PopupButtonID="txtfecha" TargetControlID="txtfecha">
                            </Toolkit:CalendarExtender>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                ControlToValidate="txtfecha" Display="Dynamic" ErrorMessage="*" 
                                ForeColor="#CC3300" ValidationGroup="GUARDAR"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    
                    <tr>
                        <td valign="top">
                            Descripcion</td>
                        <td>
                            <asp:TextBox ID="txtDescripcion" runat="server" Height="100px" 
                                TextMode="MultiLine" Width="295px" style="resize: none;"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                ControlToValidate="txtDescripcion" Display="Dynamic" ErrorMessage="*" 
                                ForeColor="#CC3300" ValidationGroup="GUARDAR"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            Mejora</td>
                        <td>
                            <asp:DropDownList ID="ddlMejora" runat="server" Width="300px">
                                <asp:ListItem>Seleccione</asp:ListItem>
                                <asp:ListItem>SI</asp:ListItem>
                                <asp:ListItem>NO</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                        <asp:CompareValidator ID="CompareValidator2" runat="server" 
                                ControlToValidate="ddlMejora" ErrorMessage="*" 
                                Operator="NotEqual" ValidationGroup="GUARDAR" ValueToCompare="Seleccione"></asp:CompareValidator>

                        </td>
                    </tr>
                    <tr>
                        <td>
                            Version</td>
                        <td>
                            <asp:TextBox ID="txtVersion" runat="server" Width="150px"></asp:TextBox>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="TextoCeldaCentrado" colspan="2">
                            <asp:Button ID="btnGuardarTabla" runat="server" CssClass="button small blue" Text="Guardar"
                                OnClick="btnGuardarTabla_Click" ValidationGroup="GUARDAR" />
                            &nbsp;
                            <asp:Button ID="btnCancelarTabla" runat="server" CssClass="button small blue" Text="Cancelar" />
                        </td>
                        <td class="TextoCeldaCentrado">
                            &nbsp;</td>
                    </tr>
                </table>
            </asp:Panel>
<!-- VENTANA DE Nuevo-->

<!-- VENTANA DE CONFIRMACION DE ELIMINACION-->
    <asp:HiddenField ID="lblHideEli" runat="server" />
    <toolkit:modalpopupextender ID="mpeEliminar" runat="server" 
        PopupControlID="pnlEliminar" TargetControlID="lblHideEli"  BehaviorID="mpeEliminarCte" 
         BackgroundCssClass="modalBackground" >
    </toolkit:modalpopupextender>
    <asp:Panel ID="pnlEliminar" style="display:none"  runat="server" CssClass="pnlVentana" 
        Width="320px">                 
            <table border="0"  cellpadding="0" cellspacing="0" style=" width :100%">
             <tr>
                <td colspan="2" >
                  <div class="dvTituloPopup" >
                    <table  class="dvTituloPopup" border="0"  cellpadding="0" cellspacing="0" style=" width :100%">
                    <tr>
                    <td style=" width :95%" > Desestimar </td>
                    <td style=" width :5%"><span class="dvCerrar"  onclick="CerrarPopup('mpeEliminarCte');">X</span></td>
                    </tr>
                    </table>
                </div>
                </td>
                
            </tr>
                <tr>
                    <td colspan="2" >                
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td  class="tbcIcono">
                        <img id="imgIcono" runat="server" class="imgMsje" src="../images/msjeinfo.png" alt="Icono" />
                    </td>
                    <td  class="tbcMsjeVentanaConfirmacion">
                       
                            <p id="pMsje" runat="server"  >
                                ¿Está seguro que desea desestimar el correlativo seleccionado.?
                            </p>
                            Correlativo Numero:
                    <asp:Label ID="lblNumero" runat="server" ></asp:Label>
                            <asp:Label ID="lblCodigoCorrelativoEliminar" runat="server" style="display:none"></asp:Label>
                    </td>
                  </tr>  
                    <tr>
                        <td class="TextoCeldaCentrado" colspan="2">
                            <asp:Button id="btnAceptarEliminar" runat="server" CssClass="button small blue" 
                                Text="Eliminar" onclick="btnAceptarEliminar_Click"  
                               >
                            </asp:Button> &nbsp;<asp:Button id="btnCancelarEli" runat="server" 
                                CssClass="button small blue" Text="Cancelar"></asp:Button>
                        </td>
                    </tr>                            
                <tr>
                    <td class="TextoCeldaCentrado" colspan="2">
                        &nbsp;                    
                    </td>
                </tr>
            </table>                   
        </asp:Panel> 
<!-- VENTANA DE CONFIRMACION DE ELIMINACION-->


<!-- VENTANA DE Detalle-->
            <asp:HiddenField ID="lblDetalle" runat="server" />
            <Toolkit:ModalPopupExtender ID="mpeDetalle" runat="server" PopupControlID="pnDetalle"
                TargetControlID="lblDetalle" BehaviorID="pnDetalleCte" BackgroundCssClass="modalBackground">
            </Toolkit:ModalPopupExtender>
            <asp:Panel ID="pnDetalle" Style="display: none;" runat="server" CssClass="pnlVentana" Width="1024px" Height="620px" ScrollBars="Auto" >
                
                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                    <tr>
                        <td>
                            <div class="dvTituloPopup">
                                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                    <tr>
                                        <td style="width: 97%;" >
                                            <asp:Label ID="lblDetalleTitulo" runat="server" Text="" style="margin-left:10px;"></asp:Label>
                                            <asp:Label ID="lblCodigoCorrelativoDetalle" runat="server" Text="Label" style="display:none"></asp:Label>
                                            <asp:Label ID="lblCodigoDetalle" runat="server" Text="Label" style="display:none"></asp:Label>
                                            <asp:Label ID="lblUsuarioDetalle" runat="server" Text="Label" style="display:none"></asp:Label>
                                        </td>
                                        <td style="width: 3%">
                                            <span class="dvCerrar" onclick="CerrarPopup('pnDetalleCte');">X</span>
                                        </td>
                                    </tr>
                                </table>                                                              
                            </div>
                          </td>  
                    </tr>
                </table>
                <center>
                <asp:Panel ID="pnPanelInsercionDetalle" runat="server">
                    <table>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                Tipo</td>
                            <td>
                                <asp:DropDownList ID="ddlTipoDetalle" runat="server" Width="300px">
                                    <asp:ListItem>Seleccione</asp:ListItem>
                                    <asp:ListItem>FORMULARIO</asp:ListItem>
                                    <asp:ListItem>LOGICA</asp:ListItem>
                                    <asp:ListItem>ACCESO A DATOS</asp:ListItem>
                                    <asp:ListItem>WEB SERVICE</asp:ListItem>
                                    <asp:ListItem>REPORTE</asp:ListItem>
                                    <asp:ListItem>SCRIPT BD</asp:ListItem>
                                    <asp:ListItem>OTROS</asp:ListItem>
                                </asp:DropDownList>

                                <asp:CompareValidator ID="CompareValidator1" runat="server" 
                                ControlToValidate="ddlTipoDetalle" ErrorMessage="*" 
                                Operator="NotEqual" ValidationGroup="AGREGAR" ValueToCompare="Seleccione" 
                                    ForeColor="Red"></asp:CompareValidator>

                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                Archivo</td>
                            <td>
                                <asp:TextBox ID="txtNombreArchivo" runat="server" Width="700px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                    ControlToValidate="txtNombreArchivo" Display="Dynamic" ErrorMessage="*" 
                                    ForeColor="#CC3300" ValidationGroup="AGREGAR"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                Motivo</td>
                            <td>
                                <asp:TextBox ID="txtMotivo" runat="server" Height="50px" Width="700px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                    ControlToValidate="txtMotivo" Display="Dynamic" ErrorMessage="*" 
                                    ForeColor="#CC3300" ValidationGroup="AGREGAR"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td colspan="2" align="center">
                                <asp:Button ID="btnGuardarAgregarDetalle" runat="server" CssClass="button small blue" 
                                    Text="Guardar" ValidationGroup="AGREGAR" 
                                    onclick="btnGuardarAgregarDetalle_Click" />
                                &nbsp;
                                <asp:Button ID="btnCancelarAgregarDetalle" runat="server" CssClass="button small blue" 
                                    Text="Cancelar" />
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                    </table>
                </asp:Panel>
                
                    <asp:Panel ID="pnListadoDetalle" runat="server" Width="100%" Height="410px" ScrollBars="Vertical" style="margin:10px 0 0 0;">
                        <asp:GridView ID="gvDetalle" runat="server" AllowPaging="True" 
                            AutoGenerateColumns="False" CellPadding="4" CssClass="Grilla" 
                            DataKeyNames="tipo,archivo,Motivo,codigo" EmptyDataText="Sin Resultados..." 
                            Font-Size="11px" ForeColor="#333333" GridLines="None" 
                            onrowcommand="gvDetalle_RowCommand" PageSize="50" Width="1000px" 
                            onrowdatabound="gvDetalle_RowDataBound">
                            <Columns>
                                <asp:BoundField DataField="tipo" HeaderText="Tipo">
                                <HeaderStyle CssClass="CabeceraGrilla" Width="100px" />
                                <ItemStyle CssClass="CeldaGrilla" />
                                </asp:BoundField>
                                <asp:BoundField DataField="archivo" HeaderText="Archivo">
                                <HeaderStyle CssClass="CabeceraGrilla" Width="100px" />
                                <ItemStyle CssClass="CeldaGrilla" />
                                </asp:BoundField>
                                <asp:BoundField DataField="motivo" HeaderText="Motivo">
                                <HeaderStyle CssClass="CabeceraGrilla" Width="700px" />
                                <ItemStyle CssClass="CeldaGrilla" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Acción">
                                    <HeaderStyle CssClass="CabeceraGrilla" Width="100" />
                                    <ItemStyle CssClass="CeldaGrilla" HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lbtnEditar" runat="server" 
                                            CommandArgument='<%#DataBinder.Eval(Container,"RowIndex")%>' 
                                            CommandName="EDITAR">Editar</asp:LinkButton>
                                        <asp:LinkButton ID="lbtnEliminar" runat="server" 
                                            CommandArgument='<%#DataBinder.Eval(Container,"RowIndex")%>' 
                                            CommandName="ELIMINAR">Eliminar</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <EmptyDataTemplate>
                                No existen registros
                            </EmptyDataTemplate>
                            <SelectedRowStyle BackColor="#AECAE8" Font-Bold="True" />
                            <PagerStyle CssClass="PaginaGrilla" ForeColor="White" />
                            <RowStyle BackColor="#e8f1f8" CssClass="FilaGrilla" ForeColor="#333333" />
                            <AlternatingRowStyle BackColor="#FFFFFF" CssClass="FilaGrilla" 
                                ForeColor="#333333" />
                        </asp:GridView>
                    </asp:Panel>
                    <br />
                    </center>
            </asp:Panel>
<!-- VENTANA DE Detalle-->

<!-- VENTANA DE CONFIRMACION DE ELIMINACION DETALLE-->
    <asp:HiddenField ID="lblEliminarDetalle" runat="server" />
    <toolkit:modalpopupextender ID="mpeEliminarDetalle" runat="server" 
        PopupControlID="pnEliminarDetalle" TargetControlID="lblEliminarDetalle"  BehaviorID="pnEliminarDetalleCte" 
         BackgroundCssClass="modalBackground" >
    </toolkit:modalpopupextender>
    <asp:Panel ID="pnEliminarDetalle" style="display:none"  runat="server" CssClass="pnlVentana" 
        Width="320px">                 
            <table border="0"  cellpadding="0" cellspacing="0" style=" width :100%">
             <tr>
                <td colspan="2" >
                  <div class="dvTituloPopup" >
                    <table  class="dvTituloPopup" border="0"  cellpadding="0" cellspacing="0" style=" width :100%">
                    <tr>
                    <td style=" width :95%" > Eliminar </td>
                    <td style=" width :5%"><span class="dvCerrar"  onclick="CerrarPopup('pnEliminarDetalleCte');">X</span></td>
                    </tr>
                    </table>
                </div>
                </td>
                
            </tr>
                <tr>
                    <td colspan="2" >                
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td  class="tbcIcono">
                        <img id="img1" runat="server" class="imgMsje" src="../images/msjeinfo.png" alt="Icono" />
                    </td>
                    <td  class="tbcMsjeVentanaConfirmacion">
                       
                            <p id="p1" runat="server"  >
                                ¿Está seguro que desea desestimar el correlativo seleccionado.?
                            </p>
                            Codigo Detalle:
                    <asp:Label ID="lblCodigoDetalleEliminar" runat="server" ></asp:Label>
                    </td>
                  </tr>  
                    <tr>
                        <td class="TextoCeldaCentrado" colspan="2">
                            <asp:Button id="btnEliminarDetalle" runat="server" CssClass="button small blue" 
                                Text="Eliminar" onclick="btnEliminarDetalle_Click"
                               >
                            </asp:Button> &nbsp;<asp:Button id="btnCancelarEliminarDetalle" runat="server" 
                                CssClass="button small blue" Text="Cancelar"></asp:Button>
                        </td>
                    </tr>                            
                <tr>
                    <td class="TextoCeldaCentrado" colspan="2">
                        &nbsp;                    
                    </td>
                </tr>
            </table>                   
        </asp:Panel> 
<!-- VENTANA DE CONFIRMACION DE ELIMINACION DETALLE-->





</ContentTemplate>
</asp:UpdatePanel>
  <asp:UpdateProgress ID="uproProgreso" runat="server" DynamicLayout="False" 
        DisplayAfter="1" AssociatedUpdatePanelID="upnProceso">
    <ProgressTemplate>
        <div class="PageWorkingBackground">
        </div>
        <div class="UpdateProgress">
            <asp:Image ID="Image1" runat="server" ImageUrl="~/images/progreso.gif" AlternateText="[image]" />
            Procesando Solicitud...            
        </div>
    </ProgressTemplate>
</asp:UpdateProgress>   
</asp:Content>

