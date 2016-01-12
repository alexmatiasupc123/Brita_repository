class pullsucursalprog extends MovieClip
{
    var botitem, varid, xbtinf, _parent, vardireccion, item, firstChild, gotoAndStop, texto, id, direccion, link, estado_scroll;
    function pullsucursalprog()
    {
        super();
        botitem.texto.text = "Seleccionar";
        botitem.enabled = false;
        botitem._alpha = 70;
        varid = 0;
        xbtinf = 152;
        botitem.onPress = function ()
        {
           if(estado_scroll == "bajar"){
		   		_parent.mascara.gotoAndPlay("subir");
				estado_scroll = "subir";
		   }
		   else{
			    _parent.mascara.gotoAndPlay("bajar");
				estado_scroll = "bajar";
		   }
        };
    } // End of the function
    function getID()
    {
        return (varid);
    } // End of the function
    function getDireccion()
    {
        return (vardireccion);
    } // End of the function
    function getValue()
    {
        return (botitem.texto.htmlText);
    } // End of the function
    function putDataXML(fileXML, varidcine)
    {
        var movdetitem = item.detitem;
        var _loc7 = new XML();
        _loc7.ignoreWhite = true;
        _loc7.onLoad = function (success)
        {
            if (success)
            {
                movdetitem._parent._parent.botitem.enabled = true;
                movdetitem._parent._parent.botitem._alpha = 100;
                var _loc4;
                var _loc6 = firstChild;
                if (_loc6.childNodes.length <= 5)
                {
                    movdetitem._parent._parent.miscroll.enabled = false;
                    movdetitem._parent._parent.xbtinf = movdetitem._parent._parent.xbtinf - 19 * (5 - _loc6.childNodes.length);
                } // end if
                for (var _loc4 = 0; _loc4 < _loc6.childNodes.length; ++_loc4)
                {
                    var _loc3 = _loc6.childNodes[_loc4];
                    var _loc2 = movdetitem.duplicateMovieClip("mclip" + _loc4, _loc4);
                    _loc2._y = Math.round((_loc4 + 1) * 19);
                    _loc2.id = _loc3.attributes.id;
					_loc2.link = _loc3.attributes.link;
                    _loc2.texto = unescape(_loc3.attributes.descripcion);
                    _loc2.direccion = unescape(_loc3.attributes.direccion);
                    _loc2.onRollOver = function ()
                    {
                        var _loc2 = new Sound();
                        _loc2.attachSound("Over");
                        _loc2.start();
                        this.gotoAndStop(2);
                    };
                    _loc2.onRollOut = function ()
                    {
                        this.gotoAndStop(1);
                    };
                    _loc2.onPress = function ()
                    {
                        this.gotoAndStop(1);
                        movdetitem._parent._parent.mascara.gotoAndPlay(movdetitem._parent._parent.mascara._currentFrame);
                        movdetitem._parent._parent.botitem.texto.text = texto;
                        movdetitem._parent._parent.varid = id;
                        movdetitem._parent._parent.vardireccion = direccion;
                        movdetitem._parent._parent._parent.setDataCine();
						if(link!="") getURL(link);
                    };
                    if (varidcine == _loc3.attributes.id)
                    {
                        movdetitem._parent._parent.varid = varidcine;
                        movdetitem._parent._parent._parent.setDataCine();
                        movdetitem._parent._parent.botitem.texto.text = unescape(_loc3.attributes.descripcion);
                        movdetitem._parent._parent._parent.vDetCine = unescape(_loc3.attributes.direccion);
                    } // end if
                } // end of for
                movdetitem._parent._parent.miscroll.scmovie = movdetitem._parent._parent.item;
                movdetitem._parent._parent.miscroll.sclimsup = movdetitem._parent._parent.xbtinf;
                movdetitem._parent._parent.miscroll.bminit();
            }
            else
            {
                movdetitem._parent._parent.botitem.enabled = false;
                movdetitem._parent._parent.botitem._alpha = 70;
            } // end else if
        };
        _loc7.load(fileXML);
    } // End of the function
} // End of Class
