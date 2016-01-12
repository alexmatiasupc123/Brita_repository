<%@ page language="C#" autoeventwireup="true" inherits="_Default, App_Web_zv_zl4dw" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title>:: CENTRO CULTURAL BRITANICO ::</title>
  <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
  <meta http-equiv="pragma" content="no-cache"/>
       <link href="App_themes/Britanico.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="js/swfobject.js"></script>
    
    <script type="text/javascript">

function agenda(){
     var opciones = "fullscreen=yes,toolbar=no,location=no,status=no,menubar=no,scrollbars=yes,resizable=yes,width=1024,height=768,left=0,top=0";
     var ventana = window.open("agenda.html","ROYAL",opciones);

}                    
//-->    
</script>

</head>
<body >
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
<div id="flashcontent">
		<strong>You need to upgrade your Flash Player</strong>
		This is replaced by the Flash content. 
		Place your alternate content here and users without the Flash plugin or with 
		Javascript turned off will see this. Content here allows you to leave out <code>noscript</code> 
		tags. Include a link to <a href="http://get.adobe.com/es/flashplayer/?promoid=BUIGP">bypass the detection</a> if you wish.
	</div>
	
	<script type="text/javascript">
		// <![CDATA[
		
		var so = new SWFObject("swf/index.swf", "britanico", "780", "900", "8", "#FF0000");
		so.addVariable("flashVarText", "this is passed in via FlashVars for example only");
		so.addParam("scale", "noscale");
		so.addParam("wmode","transparent");
		so.write("flashcontent");
		// ]]>
	</script>
    </form>
</body>
</html>
