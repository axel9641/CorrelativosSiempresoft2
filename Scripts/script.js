/***************************PILOTO*********************************************************************/

function ValidarNumeroYMasMenos(Event, txtValor) {
    var Evento = Event || window.event
    var Caracter = Evento.charCode || Evento.keyCode;

    if (Caracter != 8 && Caracter != 9) {
        alert(Caracter);
        if (Caracter == 13)
            Evento.keyCode = 9

        if ((Caracter == 45 && txtValor.value.split("-").length >= 2)) {
            
            CancelarEvento(Evento);
            return false;
        }
        if ((Caracter == 43 && txtValor.value.split("+").length >= 2)) {
            CancelarEvento(Evento);
            return false;
        }
        if ((Caracter == 46 && txtValor.value.split(".").length >= 2)) {
            CancelarEvento(Evento);
            return false;
        }
    }
}

/***************************PILOTO*********************************************************************/


/***************************FUNCION ESCRIBIR FECHA*********************************************************************/
function ValidaFechaSimple(Event, txtValor) {

    var Evento = Event || window.event
    var Caracter = Evento.charCode || Evento.keyCode;

    if (Caracter != 8 && Caracter != 9) {
     if (Caracter == 13)
            Evento.keyCode = 9

     if (txtValor.value.length == 2 || txtValor.value.length == 5) {
            txtValor.value = txtValor.value + "/"
        }
        
            
     else {
            if (txtValor.value.length >= 10) {
                CancelarEvento(Evento);
                return false;
            }
            if ((Caracter == 47 && txtValor.value.split("/").length >= 2) || (!(Caracter > 47 && Caracter < 58) )) {
                CancelarEvento(Evento);
                return false;
            }
            if (txtValor.value.length == 9) {
                //alert("tengo10");
            }
            
        }
    }
}
/***************************FUNCION ESCRIBIR HORA*********************************************************************/

function ValidarCaracteres(textareaControl, maxlength) {

    if (textareaControl.value.length <= maxlength) {
        textareaControl.value = textareaControl.value.substring(0, maxlength);
        var n = textareaControl.value.split(":")
        
        // alert(n[0]);
        if (n[0] > 24) {
            alert("Verifique hora");
            n[0] = 23;
            textareaControl.value = "";
            for (i = 0; i < n.length; i++) 
            {
                textareaControl.value += n[i].toString();
                if (i < n.length -1)
                {
                    textareaControl.value += ":";
                }
            }
            textareaControl.focus();
        }

        if (n[1] > 60) {
            alert("Verifique minutos");
            n[1] = 59;
            textareaControl.value = "";
            for (i = 0; i < n.length; i++) {
                textareaControl.value += n[i].toString();
                if (i < n.length - 1) {
                    textareaControl.value += ":";
                }
            }
            textareaControl.focus();
        }

        if (n[2] > 60) {
            alert("Verifique segundos");
            n[2] = 59;
            textareaControl.value = "";
            for (i = 0; i < n.length; i++) {
                textareaControl.value += n[i].toString();
                if (i < n.length - 1) {
                    textareaControl.value += ":";
                }
            }
            textareaControl.focus();
        }
        if (textareaControl.value.length < maxlength && textareaControl.value.length>0) {
            textareaControl.focus();
            //alert("Debe ingresar formato de hora correctamente (Ej: 12:55:00). Debe ingresar un maximo de " + maxlength + " caracteres");
            alert("Debe ingresar formato de hora correctamente (Ej: 12:55:00).");
        }
    }
}


//    if (Obj.value.length == 2 || Obj.value.length == 5) {
//        Obj.value = Obj.value + "/"
//    }
//    if (Obj.value.length == 10) {
//        Obj.value = Obj.value + " "
//    }
//    if (Obj.value.length == 13 || Obj.value.length == 16) {
//        Obj.value = Obj.value + ":"
//    }


/*SCRIP FIN HEINRRICH*/

/*PARA IMAGENES PNG TRANSPARENTES EN IE6*/
function PNG_loader() {
   for(var i=0; i<document.images.length; i++) {
      var img = document.images[i];
      var imgName = img.src.toUpperCase();
      if (imgName.substring(imgName.length-3, imgName.length) == "PNG") {
         var imgID = (img.id) ? "id='" + img.id + "' " : "";
         var imgClass = (img.className) ? "class='" + img.className + "' " : "";
         var imgTitle = (img.title) ? "title='" + img.title + "' " : "title='" + img.alt + "' ";
         var imgStyle = "display:inline-block;" + img.style.cssText;
         if (img.align == "left") imgStyle += "float:left;";
         if (img.align == "right") imgStyle += "float:right;";
         if (img.parentElement.href) imgStyle += "cursor:hand;";
         var strNewHTML = "<span " + imgID + imgClass + imgTitle
            + " style=\"" + "width:" + img.width + "px; height:" + img.height + "px;" + imgStyle + ";"
            + "filter:progid:DXImageTransform.Microsoft.AlphaImageLoader"
            + "(src=\'" + img.src + "\', sizingMethod='scale');\"></span>";
         img.outerHTML = strNewHTML;
         i--;
      }
   }
}
function CerrarPopup(strMpeCliente)
{
   var modalPopupBehavior = $find(strMpeCliente);
     modalPopupBehavior.hide();

}
/*************SELECCIONAR CHECKS DE LA GRILLA**************/
 function SeleccionarTodos(chkTodos,strGrilla,intCalcularMonto) //COMPATIBLE PARA INTERNET EXPLORER Y MOZILLA- FIREFOX
 {
   var Tabla,Fila,chkItem,TagChecks
   //Tabla=$get("ctl00_cphMaster_" + strGrilla)   
   Tabla=$get(strGrilla)  
    
    /*if(intCalcularMonto==1)
     { IniciaSaldo();
     }
     */
   for(Fila=1;Fila<Tabla.rows.length;Fila++)
   {
     TagChecks=Tabla.rows[Fila].cells[0].getElementsByTagName("input")
    if(TagChecks.length>0)
      { 
         chkItem=$get(TagChecks[0].id)
         
         /**/
      if(intCalcularMonto==1)   
        { if(chkTodos.checked) 
            {
                 if(!chkItem.checked)
                 {
                    TotalMonto(chkItem.value);
                    //alert(chkItem.value);
                 }
             }
             else
             {             
                TotalMonto(chkItem.value * -1);                      
                //alert(chkItem.value * -1);
             }             
         }    
       /**/  
         chkItem.checked= chkTodos.checked              
         if(chkTodos.checked)
            {Tabla.rows[Fila].className="CheckFilaGrilla"
              //if(intCalcularMonto==1)
               // {TotalMonto(chkItem.value);}/**/
            }
         else   
            {
             Tabla.rows[Fila].className=""      
            }
        
      }
         
   }      
 }
function IniciaSaldo()
{
    var lblSaldo;
    lblSaldo=$get("ctl00_cphMaster_lblImporte");
    lblSaldo.innerText="0.00";
}
/*  POR USAR - REVISAR
function format(input)
{
    var num = input.innerText.replace(/\./g,'');
    if(!isNaN(num)){
    num = num.toString().split('').reverse().join('').replace(/(?=\d*\.?)(\d{3})/g,'$1.');
    num = num.split('').reverse().join('').replace(/^[\.]/,'');
    input.value = num;
    }
    

}


function formatCurrency(num) {
	num = num.toString().replace(/\$|\,/g,'');
	if(isNaN(num))
	num = "0";
	sign = (num == (num = Math.abs(num)));
	num = Math.floor(num*100+0.50000000001);
	cents = num%100;
	num = Math.floor(num/100).toString();
	if(cents<10)
	cents = "0" + cents;
	for (var i = 0; i < Math.floor((num.length-(1+i))/3); i++)
	num = num.substring(0,num.length-(4*i+3))+','+
	num.substring(num.length-(4*i+3));
	//return (((sign)?'':'-') + '$' + num + '.' + cents);
	
	return (((sign)?'':'-') + num + '.' + cents);
	
}
*/
function TotalMonto(Saldo)
{
 var lblSaldo;
 var fltSaldo;
 fltSaldo=0;
 lblSaldo=$get("ctl00_cphMaster_lblImporte");
 fltSaldo= parseFloat(lblSaldo.innerText)+ parseFloat(Saldo);
 
 lblSaldo.innerText=fltSaldo.toFixed(2);
 
 //lblSaldo.innerText=formatCurrency(fltSaldo.toFixed(2))
 //TotalMonto(this,<%#Eval("Container.DataItemIndex") %>)'
}


function EvaluarChecks(chkSel,strGrilla,intFila,intCalcularMonto) //COMPATIBLE PARA INTERNET EXPLORER Y MOZILLA- FIREFOX
 {
   var Tabla,Fila,chkItem,TagChecks,TotalSel,chkSelTodos
   TotalSel=0;
   //Tabla=$get("ctl00_cphMaster_" + strGrilla);   
   Tabla=$get(strGrilla);   
      if(chkSel.checked)
           {          
            Tabla.rows[intFila+1].className="CheckFilaGrilla";
           }
           else
           {
             Tabla.rows[intFila+1].className="FilaGrilla";            
           }
                         
   chkSelTodos=$get(Tabla.rows[0].cells[0].getElementsByTagName("input")[0].id)
   //$get(chkSelTodos.id);
   for(Fila=1;Fila<Tabla.rows.length;Fila++)
   {
     TagChecks=Tabla.rows[Fila].cells[0].getElementsByTagName("input")
     if(TagChecks.length>0)
     {
        chkItem=$get(TagChecks[0].id);
        if(chkItem.checked)                       
            TotalSel ++;           
           
     } 
          
   }      
   //PARA SABER SI LA GRILLA ESTA PAGINADA- SI LO ESTA LA ULTIMA FILA NO TIENE CHECK
   TagChecks=Tabla.rows[Fila-1].cells[0].getElementsByTagName("input")
   if(TagChecks.length>0)/*SI LA ULTIMA FILA TIENE CHECK*/
   { 
    chkSelTodos.checked=(TotalSel==Tabla.rows.length-1);
   }
   else
    {
        chkSelTodos.checked=(TotalSel==Tabla.rows.length-2);
    }
   /**  AGREGADO**/ 
   if(intCalcularMonto==1)
    { if(chkSel.checked)
        {
          
          TotalMonto(chkSel.value); 
        }
       else
        {
          
          TotalMonto(chkSel.value * -1); 
        }
    }
  //FIN
 }
 //Permite restablecer las filas con checks, luego de un postback
 function RestablecerChecks(strGrilla) //COMPATIBLE PARA INTERNET EXPLORER Y MOZILLA- FIREFOX
 {
   var Tabla,Fila,chkItem,TagChecks,TotalSel,chkSelTodos
   TotalSel=0;
   Tabla=$get(strGrilla);   
   //Obtenemos la referencia del check seleccionar todos   
   chkSelTodos=$get(Tabla.rows[0].cells[0].getElementsByTagName("input")[0].id)
   
   for(Fila=1;Fila<Tabla.rows.length;Fila++)
   {
     TagChecks=Tabla.rows[Fila].cells[0].getElementsByTagName("input")
     if(TagChecks.length>0)
     {
        chkItem=$get(TagChecks[0].id);
        if(chkItem.checked)
         {  
            Tabla.rows[Fila].className="CheckFilaGrilla"
            TotalSel ++;
         }
         else
         {
             Tabla.rows[Fila].className=""
         }
     }      
   }
   
  
   
   TagChecks=Tabla.rows[Fila-1].cells[0].getElementsByTagName("input")
   if(TagChecks.length>0)/*SI LA ULTIMA FILA TIENE CHECK*/
   { 
    chkSelTodos.checked=(TotalSel==Tabla.rows.length-1);
   }
   else
    {     
        if(chkSelTodos !=null)
          {  
            chkSelTodos.checked=(TotalSel==Tabla.rows.length-2);
          }
            
    }          
 }
 
  function ValidaSeleccionItems(strGrilla, Evento) //COMPATIBLE PARA INTERNET EXPLORER Y MOZILLA- FIREFOX
 {
   var Tabla,Fila,TagChecks, chkItem,TotalSel
   TotalSel=0;
   Tabla=$get("ctl00_cphMaster_" + strGrilla);      
   for(Fila=1;Fila<=Tabla.rows.length;Fila++)
   {
      TagChecks=Tabla.rows[Fila-1].cells[0].getElementsByTagName("input") 
      if(TagChecks.length>0)
        {
            chkItem=$get(TagChecks[0].id);
            if(chkItem.checked)
             {             
                TotalSel ++;
             }         
        }      
    
   }
   if(TotalSel==0)
    {alert("-Debe seleccionar almenos un item de la lista...")
     CancelarEvento(Evento);
     return 0;
    }  
    return 1;
 }

 function CancelarEvento(Evento)
 {
  if(Evento.preventDefault) //SI NAVEGADOR ES MOZILLA
      Evento.preventDefault()
   else                    
      Evento.returnValue =false     
 }
//Seleccionar fila de la grilla con check
function MouseFilaGrilla(Fila,strGrilla)
{

   if(Fila.className!="FilaSeleccionGrilla")
   {
       
        Fila.className="MouseFilaGrilla";  
       
   }    
}
//Quitar la seleccion de la grilla
function MouseOutFilaGrilla(strGrilla,intIndice)
{    
  /*
   var Tabla,Indice;    
   var  TagChecks,chkItem
   Tabla=$get(strGrilla);  
   intIndice=intIndice -1; 
 
          TagChecks=Tabla.rows[intIndice].cells[0].getElementsByTagName("input")         
            if(TagChecks.length==0)
            {
                if(Tabla.rows[intIndice].className!="FilaSeleccionGrilla"  && Tabla.rows[intIndice].className!="PaginaGrilla")
                  {
                   
                    Tabla.rows[intIndice].className="FilaGrilla";
                  }     
            }     
            else            
            {
                chkItem=$get(TagChecks[0].id)
                 if(chkItem.checked==false)
                  {
                    Tabla.rows[intIndice].className="FilaGrilla";
                  }     
            
            }    
            */
   /*
   for(Indice=1;Indice<Tabla.rows.length;Indice++)
       {
         TagChecks=Tabla.rows[Indice].cells[0].getElementsByTagName("input")         
            if(TagChecks.length==0)
            {
                if(Tabla.rows[Indice].className!="FilaSeleccionGrilla"  && Tabla.rows[Indice].className!="PaginaGrilla")
                  {
                   
                    Tabla.rows[Indice].className="FilaGrilla";
                  }     
            }     
            else            
            {
                chkItem=$get(TagChecks[0].id)
                 if(chkItem.checked==false)
                  {
                    Tabla.rows[Indice].className="FilaGrilla";
                  }     
            
            }   
       }       
 */ 
 
     
}
function AbrirVentanaPopUp(Url,Ancho,Alto) 
{
 var TopLeftX=screen.width / 2 - Ancho/2;
	var TopLeftY=screen.height / 2 - Alto/2;
//	window.open(url,name,'top='+TopLeftY+', left='+TopLeftX+', width='+width+',height='+height+',directories=no,location=no,menubar=no,scrollbars=no,status=no,toolbar=no,resizable=no');
	
 var Propiedades ="";
 Propiedades = "toolbar=no,left=" + TopLeftX + ",top=0,location=no,directories=no,status=yes,menubar=no,scrollbars=yes,resizable=yes,width=" + Ancho + "px,height=" + Alto ; 

 
  window.open (Url,"",Propiedades);
}

/* EDGAR 10/08/2010*/
function ValidaEntero(Event) {
    var Evento = Event || window.event
    var Caracter = Evento.charCode || Evento.keyCode;

    if (Caracter != 8 && Caracter != 9) {
        if (Caracter == 13)
            Evento.keyCode = 9
        else {
            if (!(Caracter > 47 && Caracter < 58)) {
                CancelarEvento(Evento);
                return false;
            }
            else {
                return true;
            }
        }
    }
}

function CancelarEvento(Evento) {
    if (Evento.preventDefault) //SI NAVEGADOR ES MOZILLA
        Evento.preventDefault()
    else
        Evento.returnValue = false
}

function CalculaChequeFin() {
    var txtChequeIni = document.getElementById("ctl00_cphMaster_txtChequeIni");
    var txtChequeCant = document.getElementById("ctl00_cphMaster_txtChequeCant");
    var txtChequeFin = document.getElementById("ctl00_cphMaster_txtChequeFin");
    if (isNaN(parseInt(txtChequeCant.value)) ) {
        txtChequeFin.value = "";
        
    }
    else {
        txtChequeFin.value = parseInt(txtChequeIni.value) + parseInt(txtChequeCant.value) - 1;        
        
    }
}
function ValidaFormulario() {
    var txtChequeIni = document.getElementById("ctl00_cphMaster_txtChequeIni");
    var txtChequeCant = document.getElementById("ctl00_cphMaster_txtChequeCant");
    var txtChequeFin = document.getElementById("ctl00_cphMaster_txtChequeFin");

    if (txtChequeIni.value.length == 0) {
        alert("Ingrese número de cheque inicial");
        txtChequeIni.focus();
        SeleccionarTextBox(txtChequeIni);        
        return false;
    }
    if (txtChequeCant.value.length == 0) {
        alert("Ingrese cantidad de cheques");
        txtChequeFin.focus();
        SeleccionarTextBox(txtChequeFin);
        return false;
    }
    return true;
}

function SeleccionarTextBox(sender) {
    if (sender != null) {
        sender.select(); 
    }
}

 function ValidaReal(Event,txtValor)
 {         
   
   var Evento=Event || window.event
   var Caracter = Evento.charCode || Evento.keyCode;
   
    if (Caracter!=8 && Caracter!=9)  
    { 
      if(Caracter==13)       
         Evento.keyCode=9
      else
        {    
            if ( (Caracter==46 && txtValor.value.split(".").length>=2) || (!(Caracter>47 && Caracter<58) &&  Caracter!=46))
            {
                   CancelarEvento(Evento);
                    return false; 
            }  
         }
       }           
 }
 
 //***********Menu HoverMenuExtender para agregar cuenta bancaria******************
 
  function ValidaNumeroCta(strIdMenu,strIdText,strIdHdf)
   {
   var txtNumeroCta,pnlCuenta,hdfTipoCta,hmeMenu;
   
   txtNumeroCta=$get(strIdText);
   hdfTipoCta=$get(strIdHdf);
   //hmeMenu=$find(strIdMenu);         
   if(hdfTipoCta.value=="0")   
     {
      alert("Selecione un tipo de cuenta bancaria.");
      //hmeMenu._onHide();      
      return 0;      
     }
     else
     {
       if(txtNumeroCta.value.length==0)   
         {
          alert("Ingrese número de cuenta bancaria");
          //txtNumeroCta.focus();
          //pnlCuenta.style.display="";  
            //hmeMenu._onHover();
          return 0;
        
         }
         else
         {
          return 1;
         }         
       }
     
   
   }
 
   function SeleccionarTipoCta(strIdSelItem,strIdTipoCta,strIdSelCta,intTipoCta)
   {    
    var lblSelItem,hdfTipoCta,lblSelCta;
    
    lblSelItem=$get(strIdSelItem);    
    hdfTipoCta=$get(strIdTipoCta);
    lblSelCta=$get(strIdSelCta);        
    hdfTipoCta.value=intTipoCta;
    lblSelCta.innerHTML=lblSelItem.innerHTML;
    
   
   }
   function LimpiarMenuCta(strIdText,strIdTipoCta,strIdSelCta,strNombCta,strTipoCta,strNumeroCta,strIdPanel,strIdTitulo)
   {    
    var hdfTipoCta,lblSelCta,txtNumeroCta,hTituloCtaBan;  
    
    txtNumeroCta=$get(strIdText);  
    hdfTipoCta=$get(strIdTipoCta);    
    lblSelCta=$get(strIdSelCta);
    hTituloCtaBan=$get(strIdTitulo);
    
    txtNumeroCta.value=strNumeroCta;
    hdfTipoCta.value=strTipoCta;
    lblSelCta.innerHTML=strNombCta;
    if(strTipoCta=="0") //Si no se ha registrado una cuenta
    {
     hTituloCtaBan.innerHTML="AGREGAR CUENTA BANCARIA";
    }
    else
    {
        hTituloCtaBan.innerHTML="EDITAR CUENTA BANCARIA";
    }
    CerrarPanel(strIdPanel,1);
    
    //txtNumeroCta.focus();    
   }
   function CerrarPanel(strIdPanel,intTipo)
   {
    var pnlMenu=$get(strIdPanel);
   
     
    if(intTipo==0)
     {
      pnlMenu.style.display="none";
     }
     else
     {
      pnlMenu.style.display="";
     } 
     
   }
 

