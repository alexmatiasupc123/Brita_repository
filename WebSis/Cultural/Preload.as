import mx.transitions.Tween;
		
class Preload{
	private var precarga:MovieClipLoader;
	
	private var ruta:MovieClip;
	private var contenedor:MovieClip;
	private var contenedor2:MovieClip;
	
	private var posX:Number;
	private var posY:Number;
	private var porcentaje:Number;

	private var swf:String;
	private var efecto:String;
	
	private var funcion_final:Function;
	
	//constructor
	function Preload(queRuta:MovieClip, ancho:Number, alto:Number, funcion:Function){
		funcion_final = funcion;
		ruta = (queRuta == undefined) ? _root : queRuta;
		contenedor = ruta.createEmptyMovieClip("contenedor1", 1);//para la pelicula
		contenedor2 = ruta.createEmptyMovieClip("contenedor2", 2);//para el preload
		porcentaje = 0;
		swf="";
		efecto="";
		precarga = new MovieClipLoader();
		precarga.addListener(this);
		
		//posicionar animacion de precarga al centro del contenedor
		posX=Math.round(ancho/2);
		posY=Math.round(alto/2);
	}
	
	public function setPelicula(nomPelicula:String){
		this.swf = nomPelicula;
	}
	
	public function setEfecto(newEfect:String){
		this.efecto = newEfect;
	}
		
function onLoadStart(clip:MovieClip)
{
	clip._visible = false;
	clip.stop();
}
function onLoadProgress(clip:MovieClip, bytesLoaded:Number, bytesTotal:Number)
{
	contenedor2.preload._visible = true;
	porcentaje = Math.round(bytesLoaded / bytesTotal * 100);
	contenedor2.preload.animPreload.gotoAndStop(porcentaje);
	var porcentajeTxt:String = "00";
	if(porcentaje<10) porcentajeTxt = "0"+porcentaje;
	else porcentajeTxt = ""+porcentaje;
	if(this.efecto=="imagen") {contenedor2.preload.cargando.text = ""+porcentajeTxt+"";}
	else {contenedor2.preload.cargando.text = ""+porcentajeTxt+"";}
		
	//trace(porcentaje);
}
function onLoadInit(clip:MovieClip)
{	//despues de haber cargado completamente
	contenedor2.preload._visible = false;
	clip._visible = true;
	if(this.efecto=="imagen") {
		var myTween:Tween = new Tween(clip, "_alpha", mx.transitions.easing.Regular.easeOut, 0, 100, 2, true);
		EfectSatur(clip, 20, 255);
	}
	removeMovieClip(contenedor2.preload);
	contenedor.play();
	funcion_final;
}

//--------------------------
public function start()
{
	contenedor2.attachMovie("preload", "preload", contenedor2.getNextHighestDepth());
	contenedor2.preload._visible = false;
	contenedor2.preload._x=posX;//posicion de la animacion de la Precarga
	contenedor2.preload._y=posY;
	precarga.loadClip(swf,contenedor);
}

function EfectSatur(ClipPelicula:MovieClip, Velocidad:Number, MaxSaturacion:Number):Void {
	var colorSet:Color = new Color(ClipPelicula);
	ClipPelicula.onEnterFrame = function (){
		if (MaxSaturacion <= 0) {
		   delete ClipPelicula.onEnterFrame;
		   }
		else {
		   MaxSaturacion -= Velocidad;
		   }
		var colorTransform = {ra:100, rb:MaxSaturacion, ga:100, gb:MaxSaturacion, ba:100, bb:MaxSaturacion, aa:100, ab:100};
		colorSet.setTransform(colorTransform);
	};
}

}//fin class

/* la animacion de la precarga debe llamarse preload
//--------------------------
import Preload;
var objPrecarga:Preload= new Preload(contenedor,570,450);//nom contenedor, ancho, alto
objPrecarga.setPelicula("contacto.swf");
objPrecarga.setEfecto("imagen");//si lo deseas colocas esto para carga efecto para imagenes
objPrecarga.start();//iniciar precarga
//--------------------------
*/
