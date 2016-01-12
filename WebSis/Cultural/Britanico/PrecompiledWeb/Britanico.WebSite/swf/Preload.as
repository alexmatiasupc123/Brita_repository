class Preload
{
    var funcion_final, ruta, contenedor, contenedor2, porcentaje, swf, efecto, precarga, posX, posY;
    function Preload(queRuta, ancho, alto, funcion)
    {
        funcion_final = funcion;
        ruta = queRuta == undefined ? (_root) : (queRuta);
        contenedor = ruta.createEmptyMovieClip("contenedor1", 1);
        contenedor2 = ruta.createEmptyMovieClip("contenedor2", 2);
        porcentaje = 0;
        swf = "";
        efecto = "";
        precarga = new MovieClipLoader();
        precarga.addListener(this);
        posX = Math.round(ancho / 2);
        posY = Math.round(alto / 2);
    } // End of the function
    function setPelicula(nomPelicula)
    {
        swf = nomPelicula;
    } // End of the function
    function setEfecto(newEfect)
    {
        efecto = newEfect;
    } // End of the function
    function onLoadStart(clip)
    {
        clip._visible = false;
        clip.stop();
    } // End of the function
    function onLoadProgress(clip, bytesLoaded, bytesTotal)
    {
        contenedor2.preload._visible = true;
        porcentaje = Math.round(bytesLoaded / bytesTotal * 100);
        contenedor2.preload.animPreload.gotoAndStop(porcentaje);
        var _loc2 = "00";
        if (porcentaje < 10)
        {
            _loc2 = "0" + porcentaje;
        }
        else
        {
            _loc2 = "" + porcentaje;
        } // end else if
        if (efecto == "imagen")
        {
            contenedor2.preload.cargando.text = "" + _loc2 + "";
        }
        else
        {
            contenedor2.preload.cargando.text = "" + _loc2 + "";
        } // end else if
    } // End of the function
    function onLoadInit(clip)
    {
        contenedor2.preload._visible = false;
        clip._visible = true;
        if (efecto == "imagen")
        {
            var _loc3 = new mx.transitions.Tween(clip, "_alpha", mx.transitions.easing.Regular.easeOut, 0, 100, 2, true);
            this.EfectSatur(clip, 20, 255);
        } // end if
        removeMovieClip (contenedor2.preload);
        contenedor.play();
    } // End of the function
    function start()
    {
        contenedor2.attachMovie("preload", "preload", contenedor2.getNextHighestDepth());
        contenedor2.preload._visible = false;
        contenedor2.preload._x = posX;
        contenedor2.preload._y = posY;
        precarga.loadClip(swf, contenedor);
    } // End of the function
    function EfectSatur(ClipPelicula, Velocidad, MaxSaturacion)
    {
        var colorSet = new Color(ClipPelicula);
        ClipPelicula.onEnterFrame = function ()
        {
            if (MaxSaturacion <= 0)
            {
                delete ClipPelicula.onEnterFrame;
            }
            else
            {
                MaxSaturacion = MaxSaturacion - Velocidad;
            } // end else if
            var _loc1 = {ra: 100, rb: MaxSaturacion, ga: 100, gb: MaxSaturacion, ba: 100, bb: MaxSaturacion, aa: 100, ab: 100};
            colorSet.setTransform(_loc1);
        };
    } // End of the function
} // End of Class
