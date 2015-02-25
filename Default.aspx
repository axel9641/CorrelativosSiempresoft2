<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Correlativos Siempresoft</title>    
    <link href="Styles/Site.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript" src="scripts/script.js"></script>          
    </head>

<body>   
    <form id="form1" runat="server">  
  <div class="page">
        <div class="header">
            <div class="title">
                <table width="100%" >
                    <tr> 
                     <td style="width:30%" align="center"  >
                         <asp:Image ID="Image1" runat="server"  Height= "80px" Width="150px" ImageUrl="~/images/logo_empresa.png" style="margin:10px;"   />
                              
                    </td>
                    <td style="width:70%">
                            <h1>CORRELATIVOS SIEMPRESOFT</h1>
                    </td>
                   
                    </tr>
                 </table>
                <div style="background:#0189d3; height:10px;" >
                </div>   
             </div>
         </div>
    <div class="main1">
       <table style ="width:100%;">
           <tr>
            
            <td align="center" valign="middle">
                <br />
                <img alt="" src="images/slider-img6.png" height="90%"  />
                <br />
            </td>
            <td>               
		   
			  <table cellspacing="3" align="center">
                  <tr>
                      <td align="left" style="color:#0189d3"> Nombre de usuario:</h6></td>
                  </tr>
                  <tr>
                      <td align="left">
                          <asp:TextBox ID="txtUsuario" runat="server" Font-Size="Small" MaxLength="30" 
                              Width="200px"></asp:TextBox>
                          <asp:RequiredFieldValidator ID="rfvUsuario" runat="server" 
                              ControlToValidate="txtUsuario" ErrorMessage="*" ValidationGroup="Login"></asp:RequiredFieldValidator>
                      </td>
                  </tr>
                  <tr>
                      <td align="left" style="color:#0189d3">
                                                                      Contraseña:</td>
                  </tr>
                  <tr>
                      <td align="left">
                          <asp:TextBox ID="txtContraseña" runat="server" Font-Size="Small" 
                              MaxLength="100" TextMode="Password" Width="200px"></asp:TextBox>
                          <asp:RequiredFieldValidator ID="rfvClave" runat="server" 
                              ControlToValidate="txtContraseña" ErrorMessage="*" ValidationGroup="Login"></asp:RequiredFieldValidator>
                      </td>
                  </tr>
                  <tr>
                      <td align="left">
                          <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
                      </td>
                  </tr>
                  <tr>
                      <td align="center" class="TextoCeldaDerecha">
                          <asp:Button ID="btnAceptar" runat="server" Font-Size="X-Small" Height="22px" 
                              style="font-weight: 700" TabIndex="4" Text="Aceptar" ValidationGroup="Login" 
                              Width="100px" onclick="btnAceptar_Click" />
                      </td>
                  </tr>
                  </table>
    		  		  
            </td>
           
        </tr>
        </table>
    </div>
        <div class="footer">
            © Todos los derechos reservados - 2013 ©</div>
    </div>  
		   
    </form>     
</body>
</html>
