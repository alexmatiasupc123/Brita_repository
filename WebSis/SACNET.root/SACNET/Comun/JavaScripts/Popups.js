 
/***********************************************************************
Autor  :	Luis Chavarria Bendezu								
JScript:	Libreria de JScripts Popups
************************************************************************/ 
function OpenPopup(url, ancho, altura)
{
    var vValorRetorno;
       vValorRetorno = window.showModalDialog(url,"#1","dialogHeight: " + altura +"px; dialogWidth: " + ancho +"px; dialogTop: 150px; dialogLeft: 250px; edge: Raised;center: Yes; help: No; resizable: 0; status: 0; location: 0;");
//    vValorRetorno = window.open(url, "#1", "dialogHeight: " + altura + "px; dialogWidth: " + ancho + "px; dialogTop: 150px; dialogLeft: 250px; edge: Raised;center: Yes; help: No; resizable: 0; status: 0; location: 0;");
    
    if (vValorRetorno != null)
    {
        ActualizarPanel(vValorRetorno);
    }
}

function CerrarOK(valorRetorno)
    {
        window.returnValue = valorRetorno;
        self.close();
    }
function CerrarCancel()
    {
        window.returnValue = null;
        self.close();
    }
    function CerrarClose() 
    {
        window.close();
    }
    function RegresarPage() 
    {
        window.history.back();
        return false;
       
    }
function Logout()
   {
        
            OpenCenterPopUp("PopupLogout.aspx", "", 600, 70);
        
    }
function OpenCenterPopUp(url, name, width, height) 
    {
        var TopLeftX = screen.width / 2 - width / 2;
        var TopLeftY = screen.height / 2 - height / 2;
        window.open(url, name, 'top=' + TopLeftY + ', left=' + TopLeftX + ', width=' + width + ',height=' + height + ',directories=no,location=no,menubar=no,scrollbars=no,status=no,toolbar=no,resizable=no');
    }
function doUnload()
     {
         if (window.event.clientX < 0 && window.event.clientY < 0) 
        {
            //            alert("Window is closing...");
             OpenCenterPopUp("Logout.aspx", "", 600, 200); 
        }
    }

//    var micierre = false;
//    function ConfirmarCierre() {
//        if (event.clientY < 0) {
//            event.returnValue = "";
//            setTimeout('micierre = false', 100);
//            micierre = true;
//        }
//    }

//    function ManejadorCierre() {
//        if (micierre == true) {
//            document.location.href = "Default.aspx";
//        }
//    }



  