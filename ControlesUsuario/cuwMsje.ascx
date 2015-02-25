﻿<%@ Control Language="VB" AutoEventWireup="false" CodeFile="cuwMsje.ascx.vb" Inherits="cuwMsje" Description="Control para mostrar mensajes de información y error al cliente" %>

 <asp:UpdatePanel ID="upnlMsje"  runat="server" ChildrenAsTriggers="False" 
    UpdateMode="Conditional">
        <ContentTemplate>            
           <div  runat="server" id="dvMsje" >
            <table  style="width:auto; height:auto">
                <tr>
                    <td>
                        <img runat="server" src="~/images/msjeError.png" id="imgMsje"   alt="Mensaje" />                   
                    </td>
                    <td>
                         <asp:Label ID="lblMsje"  style="color:Red" runat="server"></asp:Label>                             
                    </td>
                </tr>
                
            </table>                                    
        </div>
        </ContentTemplate>        
    </asp:UpdatePanel> 
    
    
           