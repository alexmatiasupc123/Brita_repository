
/***********************************************************************
Autor  :	Luis Chavarria Bendezu								
JScript:	Libreria de JScripts 
************************************************************************/

function filterInput(filterType, evt, allowDecimal, allowCustom){
    var keyCode, Char, inputField, filter = '';
    var alpha = 'abcdefghijklmnñopqrstuvwxyzABCDEFGHIJKLMNÑOPQRSTUVWXYZ';
    var num   = '0123456789';
    if(window.event){
        keyCode = window.event.keyCode;
        evt = window.event;
    }else if (evt)keyCode = evt.which;
    else return true;
    if(filterType == 0) filter = alpha;
    else if(filterType == 1) filter = num;
    else if(filterType == 2) filter = alpha + num;
    if(allowCustom)filter += allowCustom;
    if(filter == '')return true;
    inputField = evt.srcElement ? evt.srcElement : evt.target || evt.currentTarget;
    if ((keyCode == null) || (keyCode == 0) || (keyCode == 8) || (keyCode == 9) || (keyCode == 13) || (keyCode == 27) || (keyCode == 32)) return true;
    Char = String.fromCharCode(keyCode);
    if((filter.indexOf(Char) > -1)) return true;
    else if(filterType == 1 && allowDecimal && (Char == '.') && inputField.value.indexOf('.') == -1)return true;
    else return false;
}


function getObject(obj) {
  var theObj;
  if(document.all) {
    if(typeof obj=="string") {
      return document.all(obj);
    } else {
      return obj.style;
    }
  }
  if(document.getElementById) {
    if(typeof obj=="string") {
      return document.getElementById(obj);
    } else {
      return obj.style;
    }
  }
  return null;
}

function toCount(entrance,exit,text,characters) {
  var entranceObj=getObject(entrance);
  var exitObj=getObject(exit);
  var length=characters - entranceObj.value.length;
  if(length <= 0) {
    length=0;
    text='<span class="disable"> '+text+' </span>';
    entranceObj.value=entranceObj.value.substr(0,characters);
  }
  exitObj.innerHTML = text.replace("{CHAR}",length);
}

function Count(text, max) {
    var maxlength = new Number(max);
    if (text.value.length > maxlength) {
        text.value = text.value.substring(0, maxlength);
    }
}

/* validar correo*/
function doCheckEmail(email) 
{
	str = email.value;
	var at="@"
	var dot="."
	var lat=str.indexOf(at)
	var lstr=str.length
	var ldot=str.indexOf(dot)

	if (str=='') {return true};

	if (str.indexOf(at)==-1){
		alert("  Email inválido...");
		email.focus();
		return false;
	}

	if (str.indexOf(at)==-1 || str.indexOf(at)==0 || str.indexOf(at)==lstr){
		alert(" Email inválido...");
		email.focus();
		return false;
	}

	if (str.indexOf(dot)==-1 || str.indexOf(dot)==0 || str.indexOf(dot)==lstr){
		alert(" Email inválido...");
		email.focus();
		return false;
	}

	if (str.indexOf(at,(lat+1))!=-1){
		alert(" Email inválido...");
		email.focus();
		return false;
	}

	if (str.substring(lat-1,lat)==dot || str.substring(lat+1,lat+2)==dot){
		alert(" Email inválido...");
		email.focus();
		return false;
	}

	if (str.indexOf(dot,(lat+2))==-1){
		alert(" Email inválido...");
		email.focus();
		return false;
	}

	if (str.indexOf(" ")!=-1){
		alert(" Email inválido...");
		email.focus();
		return false;
	}

	//email.value = email.value.toUpperCase();
	return true;			
}



