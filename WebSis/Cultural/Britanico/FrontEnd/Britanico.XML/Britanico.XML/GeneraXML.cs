using System;
using System.Collections.Generic;
using System.Text;
using Britanico.Web.BusinessEntities;
using Britanico.BusinessLogic.NoTransaccionales;
using System.Xml;
using Britanico.Utilitario.Funciones;
using System.IO;

namespace Britanico.XML
{
    public class GeneraXML
    {
        Funciones funciones = new Funciones();
        #region generaxml

        public string xmlNoticiaInfo(List<BENoticia> listaNoticias)
        {
            //definimos ruta de almacenamiento
            //creamos documento 
           
            XmlDocument noticia = new XmlDocument();
            //creamos cabecera
            XmlDeclaration dec = noticia.CreateXmlDeclaration("1.0", "UTF-8", null);
            //creamos nodo principal

            XmlNode datos = noticia.CreateElement("datos");
            noticia.AppendChild(datos);

            XmlNode noticias = noticia.CreateElement("noticias");
            datos.AppendChild(noticias);

            //creamos nodos hijos
            foreach (BENoticia iNoticia in listaNoticias)
            {
                //creamos nodo hijo variable
                String nombreNodoHijo = "P_" + iNoticia.noti_codi.ToString();
                System.Xml.XmlNode NodoHijo = noticia.CreateElement(nombreNodoHijo);
                //creamos nodos de informacion
                XmlNode noti_codi = noticia.CreateElement("noti_codi");
                noti_codi.InnerXml = "<![CDATA[" + iNoticia.noti_codi + "]]>";
                NodoHijo.AppendChild(noti_codi);

                XmlNode titulo = noticia.CreateElement("titulo");
                titulo.InnerXml = "<![CDATA[" + iNoticia.noti_titu + "]]>";
                NodoHijo.AppendChild(titulo);

                XmlNode resumen = noticia.CreateElement("resumen");
                resumen.InnerXml = "<![CDATA[" + iNoticia.noti_desc + "]]>";
                NodoHijo.AppendChild(resumen);

                XmlNode link = noticia.CreateElement("link");
                link.InnerXml = "Variable.aspx?tipoCriterio=noti&amp;id=" + iNoticia.noti_codi.ToString();
                NodoHijo.AppendChild(link);


                XmlNode mes = noticia.CreateElement("mes");
                mes.InnerXml = funciones.determinaMes(iNoticia.noti_fech);
                NodoHijo.AppendChild(mes);
                //
                //agregamos NodoHijo al nodo noticias
                noticias.AppendChild(NodoHijo);

            }
            //insertamos cabecera
            noticia.InsertBefore(dec, datos);
            StringWriter sw = new StringWriter();
            XmlTextWriter xw = new XmlTextWriter(sw);
            noticia.WriteTo(xw);
            return sw.ToString();

            //guardamos  archivo xml

         
        }

        public string xmlEventoPrincipalInfo(List<BEEvento> listaEvento, String rutaImag)
        {
            //definimos ruta de almacenamiento
            //creamos documento 
            XmlDocument evento = new XmlDocument();
            //creamos cabecera
            XmlDeclaration dec = evento.CreateXmlDeclaration("1.0", "UTF-8", null);
            //creamos nodo principal

            XmlNode datos = evento.CreateElement("datos");
            evento.AppendChild(datos);

            XmlNode eventos = evento.CreateElement("eventos");
            datos.AppendChild(eventos);

            //creamos nodos hijos
            foreach (BEEvento iEvento in listaEvento)
            {
                //creamos nodo hijo variable
                String nombreNodoHijo = "P_" + iEvento.even_codi.ToString();
                System.Xml.XmlNode NodoHijo = evento.CreateElement(nombreNodoHijo);
                //creamos nodos de informacion
               
                XmlNode url_foto = evento.CreateElement("url_foto");
                if (iEvento.even_imag != null)
                {
                    url_foto.InnerXml = "<![CDATA[" + rutaImag + iEvento.even_imag + "]]>";
                }
                else
                {
                    url_foto.InnerXml = "Ninguno";
                }
                NodoHijo.AppendChild(url_foto);

                XmlNode fecha = evento.CreateElement("fecha");
                if (iEvento.even_fini.Year >= DateTime.Now.Year)
                {
                    fecha.InnerXml = iEvento.even_fini.Day.ToString() + funciones.determinaMesCorto(iEvento.even_fini);
                }
                else {
                    fecha.InnerXml = "";
                }
                NodoHijo.AppendChild(fecha);

                XmlNode titulo = evento.CreateElement("titulo");
                titulo.InnerXml = "<![CDATA[" + iEvento.even_nomb + "]]>";
                NodoHijo.AppendChild(titulo);

                //
                //agregamos NodoHijo al nodo noticias
                eventos.AppendChild(NodoHijo);
            }
            //insertamos cabecera
            evento.InsertBefore(dec, datos);
            //guardamos  archivo xml
            StringWriter sw = new StringWriter();
            XmlTextWriter xw = new XmlTextWriter(sw);
            evento.WriteTo(xw);
            return sw.ToString();


        }


        public string xmlAgenda(List<BEEvento> listaEvento, String rutaImag)
        {
            BESede bSede = new BESede();
            BLSedeNTAD oSede = new BLSedeNTAD();

          
            //definimos ruta de almacenamiento
        //    String rutaAgenda = ruta + "agenda.xml";
            //creamos documento 
            XmlDocument evento = new XmlDocument();
            //creamos cabecera
            XmlDeclaration dec = evento.CreateXmlDeclaration("1.0", "UTF-8", null);
            //creamos nodo principal

            XmlNode datos = evento.CreateElement("datos");
            evento.AppendChild(datos);

            XmlNode agenda = evento.CreateElement("agenda");
            datos.AppendChild(agenda);

            //creamos nodos hijos
            foreach (BEEvento iEvento in listaEvento)
            {
                //creamos nodo hijo variable
                String nombreNodoHijo = "p_" + iEvento.even_codi.ToString();
                System.Xml.XmlNode NodoHijo = evento.CreateElement(nombreNodoHijo);
                //creamos nodos de informacion
                XmlNode boton = evento.CreateElement("boton");
                boton.InnerXml = "<![CDATA[" + iEvento.even_nomb + "]]>";
                NodoHijo.AppendChild(boton);

               
                XmlNode link = evento.CreateElement("link");
                String url = "Variable.aspx?tipoCriterio=6&tipoEvento=" + iEvento.even_tipo.ToString() + "&idEvento=" + iEvento.even_codr.ToString();
                link.InnerXml = "<![CDATA[" + url + "]]>";
                NodoHijo.AppendChild(link);

                XmlNode foto = evento.CreateElement("foto");
                if (iEvento.even_imag != null)
                {
                    foto.InnerXml = rutaImag + iEvento.even_aimg;
                }
                
                NodoHijo.AppendChild(foto);

                XmlNode titulo = evento.CreateElement("titulo");
                titulo.InnerXml = "<![CDATA[" + iEvento.even_nomb + "]]>";
                NodoHijo.AppendChild(titulo);

                XmlNode direccion = evento.CreateElement("direccion");
                bSede = oSede.ListarRegistro(iEvento.sede_codi);
                direccion.InnerXml = "<![CDATA[" + bSede.sede_dire + " - " + bSede.sede_nomb + "]]>";
                NodoHijo.AppendChild(direccion);

                XmlNode temporada = evento.CreateElement("temporada");
                temporada.InnerXml = "<![CDATA[" + iEvento.even_temp + "]]>";
                NodoHijo.AppendChild(temporada);

                //
                //agregamos NodoHijo al nodo noticias
                agenda.AppendChild(NodoHijo);
            }
            //insertamos cabecera
            evento.InsertBefore(dec, datos);

            StringWriter sw = new StringWriter();
            XmlTextWriter xw = new XmlTextWriter(sw);
            evento.WriteTo(xw);
            return sw.ToString();
            //guardamos  archivo xml

            //evento.Save(rutaAgenda);



        }

        public string xmlBanner(List<BEBanner> listaBanners, String rutaImag)
        {
            //definimos ruta de almacenamiento
            //creamos documento 
            XmlDocument banner = new XmlDocument();
            //creamos cabecera
            XmlDeclaration dec = banner.CreateXmlDeclaration("1.0", "UTF-8", null);
            //creamos nodo principal

            XmlNode datos = banner.CreateElement("datos");
            banner.AppendChild(datos);

            XmlNode banners = banner.CreateElement("banners");
            datos.AppendChild(banners);

            //creamos nodos hijos
            foreach (BEBanner iBanner in listaBanners)
            {
                //creamos nodo hijo variable
                String nombreNodoHijo = "P_" + iBanner.bann_codi.ToString();
                System.Xml.XmlNode NodoHijo = banner.CreateElement(nombreNodoHijo);
                //creamos nodos de informacion
                XmlNode url_archivo = banner.CreateElement("url_archivo");
                url_archivo.InnerXml = rutaImag + iBanner.bann_imag;
                NodoHijo.AppendChild(url_archivo);

                XmlNode link = banner.CreateElement("link");
                if (iBanner.bann_link == null)
                {
                    iBanner.bann_link="";
                }
                link.InnerXml = iBanner.bann_link;
                NodoHijo.AppendChild(link);

                //
                //agregamos NodoHijo al nodo banners
                banners.AppendChild(NodoHijo);

            }
            //insertamos cabecera
            banner.InsertBefore(dec, datos);
            //guardamos  archivo xml
            StringWriter sw = new StringWriter();
            XmlTextWriter xw = new XmlTextWriter(sw);
            banner.WriteTo(xw);
            return sw.ToString();

        }

        public string xmlFotoPrincipalInfo(List<BEBanner> listaBanner, String rutaImag)
        {
            //definimos ruta de almacenamiento
            //creamos documento 
            XmlDocument foto = new XmlDocument();
            //creamos cabecera
            XmlDeclaration dec = foto.CreateXmlDeclaration("1.0", "UTF-8", null);
            //creamos nodo principal

            XmlNode datos = foto.CreateElement("datos");
            foto.AppendChild(datos);

            XmlNode fotos = foto.CreateElement("fotos");
            datos.AppendChild(fotos);

            //creamos nodos hijos
            foreach (BEBanner iBanner in listaBanner)
            {
                //creamos nodo hijo variable
                String nombreNodoHijo = "P_" + iBanner.bann_codi.ToString();
                System.Xml.XmlNode NodoHijo = foto.CreateElement(nombreNodoHijo);
                //creamos nodos de informacion
                XmlNode url_foto = foto.CreateElement("url_foto");
                url_foto.InnerXml = rutaImag + iBanner.bann_imag;
                NodoHijo.AppendChild(url_foto);


                XmlNode fecha = foto.CreateElement("fecha");
                fecha.InnerXml = iBanner.bann_dfec;
                NodoHijo.AppendChild(fecha);


                XmlNode titulo = foto.CreateElement("titulo");
                titulo.InnerXml = "<![CDATA[" + iBanner.bann_titu + "]]>";
                NodoHijo.AppendChild(titulo);

                XmlNode link = foto.CreateElement("link");
                link.InnerXml = "<![CDATA[" + iBanner.bann_link + "]]>";
                NodoHijo.AppendChild(link);
          
            //
            //agregamos NodoHijo al nodo noticias
            fotos.AppendChild(NodoHijo); 
            }
            //insertamos cabecera
            foto.InsertBefore(dec, datos);
            //guardamos  archivo xml
            StringWriter sw = new StringWriter();
            XmlTextWriter xw = new XmlTextWriter(sw);
            foto.WriteTo(xw);
            return sw.ToString();

        }

        public string xmlSucursalInfo(List<BESede> listaSede)
        {

            //creamos documento 
            XmlDocument sucursal = new XmlDocument();
            //creamos cabecera
            XmlDeclaration dec = sucursal.CreateXmlDeclaration("1.0", "UTF-8", null);
            //creamos nodo principal

            XmlNode distritos = sucursal.CreateElement("distritos");
            sucursal.AppendChild(distritos);

            //creamos nodos hijos
            foreach (BESede iSede in listaSede)
            {
                System.Xml.XmlNode distrito = sucursal.CreateElement("distrito");
                //creamos atributos del nodo
                System.Xml.XmlAttribute id = sucursal.CreateAttribute("id");
                id.InnerText = iSede.sede_codi.ToString();
                distrito.Attributes.Append(id);

                System.Xml.XmlAttribute link = sucursal.CreateAttribute("link");
                link.InnerText = "Variable.aspx?tipoCriterio=0&criterio=" + iSede.sede_codi.ToString();
                distrito.Attributes.Append(link);

                System.Xml.XmlAttribute descripcion = sucursal.CreateAttribute("descripcion");
                descripcion.InnerText = iSede.sede_nomb;
                distrito.Attributes.Append(descripcion);
                //
                //agregamos nodo hijo al  nodo padre
                distritos.AppendChild(distrito);

            }
            //insertamos cabecera
            sucursal.InsertBefore(dec, distritos);
            //guardamos  archivo xml
            StringWriter sw = new StringWriter();
            XmlTextWriter xw = new XmlTextWriter(sw);
            sucursal.WriteTo(xw);
            return sw.ToString();


        }

        public string xmlSubMenu(List<BEEvento> listaEvento, String urlIni)
        {
           
            XmlDocument subMenu = new XmlDocument();
            //creamos cabecera
            XmlDeclaration dec = subMenu.CreateXmlDeclaration("1.0", "UTF-8", null);
            //creamos nodo principal

            XmlNode datos = subMenu.CreateElement("datos");
            subMenu.AppendChild(datos);

            XmlNode boton = subMenu.CreateElement("boton");
            datos.AppendChild(boton);

            //creamos nodos hijos
            foreach (BEEvento iEvento in listaEvento)
            {
                //creamos nodo hijo variable
                String nombreNodoHijo = "p_" + iEvento.even_codi.ToString();
                System.Xml.XmlNode NodoHijo = subMenu.CreateElement(nombreNodoHijo);
                //creamos nodos de informacion
                XmlNode titulo = subMenu.CreateElement("titulo");
                titulo.InnerXml = "<![CDATA[" + iEvento.even_nomb + "]]>";
                NodoHijo.AppendChild(titulo);


                XmlNode link = subMenu.CreateElement("link");
                String url = "";
               
                if(iEvento.even_tipo==22)
                    url = "Auditorios.aspx";
                else if(iEvento.even_tipo==44)
                    url = "Cursos_Talleres.aspx";
                else
                   //url = urlIni + "&tipoEvento=" + iEvento.even_tipo.ToString() + "&idEvento=" + iEvento.even_codr.ToString();
                url = urlIni + "&tipoEvento=" + iEvento.even_tipo.ToString() + "&criterio=" + iEvento.even_codr.ToString();

                link.InnerXml = "<![CDATA[" + url + "]]>";
                NodoHijo.AppendChild(link);
              
                //
                //agregamos NodoHijo al nodo noticias
                boton.AppendChild(NodoHijo);
            }
            //insertamos cabecera
            subMenu.InsertBefore(dec, datos);

            StringWriter sw = new StringWriter();
            XmlTextWriter xw = new XmlTextWriter(sw);
            subMenu.WriteTo(xw);
            return sw.ToString();
            //guardamos  archivo xml

            //evento.Save(rutaAgenda);



        }


        #endregion generaxml

       
    }
}
