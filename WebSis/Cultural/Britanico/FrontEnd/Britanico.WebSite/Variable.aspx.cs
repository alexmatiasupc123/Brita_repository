using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using System.Xml;
using Britanico.BusinessLogic.NoTransaccionales;
using Britanico.Web.BusinessEntities;
using Britanico.Utilitario.Funciones;
using Britanico.XML;

public partial class Variable : System.Web.UI.Page
{
    Funciones funciones = new Funciones();
    GeneraXML generaXML = new GeneraXML();

    BEEvento bEvento = new BEEvento();
    BLEventoNTAD oEvento = new BLEventoNTAD();
    BLSedeNTAD oSede = new BLSedeNTAD();
    BLActividadTeatroNTAD oActividad = new BLActividadTeatroNTAD();
    BLProgramacionAuditorioNTAD oProgramacion = new BLProgramacionAuditorioNTAD();
    BLGaleriaArteNTAD oGaleria = new BLGaleriaArteNTAD();
    BLGaleriaArteDetalleNTAD oGaleriaDetalle = new BLGaleriaArteDetalleNTAD();
    BLCursoTallerNTAD oCurso = new BLCursoTallerNTAD();

    String rutaUpload = ConfigurationManager.AppSettings["upLoad"].ToString();
    Int32 tipoEvento;
    protected void Page_Load(object sender, EventArgs e)
    {
            string tipoCriterio = Request.QueryString[0].ToString();

            switch (tipoCriterio)
            {
                case "noti":
                    Session["idNoticia"] = Request.QueryString[1].ToString();
                    if (Session["idNoticia"] != null)
                    {
                        //Response.Write(Session["idNoticia"].ToString());
                        Response.Redirect("Noticia_Detalle.aspx");
                    }
                    break;

                case "100":
                    string fecha = Request.QueryString[1].ToString();
                    if (fecha != null)
                    {
                        List<BEEvento> listaEvento = oEvento.ListarTodosXstrFecha(fecha);
                        string agenda = generaXML.xmlAgenda(listaEvento, rutaUpload);
                        Response.Write(agenda);
                    }
                    break;

                case "101":
                    //tipo de evento 0 = Galeria de Artes, 1 = Auditorio,2 = Teatro, 4 = Curso taller
                    tipoEvento = Convert.ToInt32(Request.QueryString[1].ToString());
                     
                        List<BEEvento> listaEventos = new List<BEEvento>();
                        String urlIni = "Variable.aspx?tipoCriterio=7";

                        if (tipoEvento == 0)
                        {
                            List<BEGaleriaArte> listaSubMenu = oGaleria.ListarTodos();
                            if (listaSubMenu.Count > 0)
                            {
                                int a = 5;
                                if (listaSubMenu.Count < a)
                                    a = listaSubMenu.Count;
                                for (int i = 0; i < a; i++)
                                {
                                    BEEvento iEvento = new BEEvento();
                                    iEvento.even_codi = i;
                                    iEvento.even_codr = listaSubMenu[i].gale_codi;
                                    iEvento.even_tipo = 0;
                                    iEvento.even_nomb = listaSubMenu[i].gale_nomb;
                                    listaEventos.Add(iEvento);
                                }

                              
                            }

                          
                            
                        }
                        else if (tipoEvento == 2)
                        {
                            int a = 4;
                            List<BESede> listaSubMenu = oSede.ListarTodosSedesAuditorios();
                            if (listaSubMenu.Count > 0)
                            {
                               
                                if (listaSubMenu.Count < a)
                                    a = listaSubMenu.Count;
                                for (int i = 0; i < a; i++)
                                {
                                    BEEvento iEvento = new BEEvento();
                                    iEvento.even_codi = i;
                                    iEvento.even_codr = listaSubMenu[i].sede_codi;
                                    iEvento.even_tipo = 1;
                                    iEvento.even_nomb = listaSubMenu[i].sede_nomb;
                                    listaEventos.Add(iEvento);
                                }


                            }

                            if (listaSubMenu.Count > a)
                            {
                                BEEvento ioEvento = new BEEvento();
                                ioEvento.even_codi = 5;
                                ioEvento.even_codr = 0;
                                ioEvento.even_tipo = 22;
                                ioEvento.even_nomb = "Ver Mas...";
                                listaEventos.Add(ioEvento);
                            }

                    
                        }
                        else if (tipoEvento == 1)
                        {
                            List<BEActividadTeatro> listaSubMenu = oActividad.ListarTodosDestacados();
                            if (listaSubMenu.Count > 0)
                            {
                                //int a = 5;
                                //if (listaSubMenu.Count < a)
                                //    a = listaSubMenu.Count;

                                for (int i = 0; i < listaSubMenu.Count; i++)
                                {
                                    BEEvento iEvento = new BEEvento();
                                    iEvento.even_codi = i;
                                    iEvento.even_codr = listaSubMenu[i].teat_codi;
                                    iEvento.even_tipo = 2;
                                    iEvento.even_nomb = listaSubMenu[i].teat_titu;
                                    listaEventos.Add(iEvento);
                                }
                            }
                        
                        }
                        else if (tipoEvento == 4)
                        {
                             int a = 4;

                            List<BESede> listaSubMenu = oSede.ListarTodosSedesCursos();
                            if (listaSubMenu.Count > 0)
                            {
                                if (listaSubMenu.Count < a)
                                    a = listaSubMenu.Count;

                                for (int i = 0; i < a; i++)
                                {
                                    BEEvento iEvento = new BEEvento();
                                    iEvento.even_codi = i;
                                    iEvento.even_codr = listaSubMenu[i].sede_codi;
                                    iEvento.even_tipo = 4;
                                    iEvento.even_nomb = listaSubMenu[i].sede_nomb;
                                    listaEventos.Add(iEvento);
                                }
                            }

                            if (listaSubMenu.Count > a)
                            {
                                BEEvento ioEvento = new BEEvento();
                                ioEvento.even_codi = 5;
                                ioEvento.even_codr = 0;
                                ioEvento.even_tipo = 44;
                                ioEvento.even_nomb = "Ver Mas...";
                                listaEventos.Add(ioEvento);
                            }

                        }
                       

                       string submenu = generaXML.xmlSubMenu(listaEventos,urlIni);
                       Response.Write(submenu);
                    
                break;


                case "0":
                    Session["tipoCriterio"] = tipoCriterio;
                    Session["idSede"] = Request.QueryString[1].ToString();
                    Response.Redirect("Agenda_Cultural.aspx");

                    break;

                case "1":
                    Session["tipoCriterio"] = tipoCriterio;
                    Session["criterio"] = Request.QueryString[1].ToString();
                    Response.Redirect("Agenda_Cultural.aspx");
                    break;

                case "2":
                    Session["tipoCriterio"] = tipoCriterio;
                    Session["dtFecha"] = Request.QueryString[1].ToString();
                    Response.Redirect("Agenda_Fecha.aspx");
                    break;

                case "4":
                    Session["tipoCriterio"] = tipoCriterio;
                    Session["criterio"] = Request.QueryString[1].ToString();
                    //mandamos a guardar mail
                    Response.Redirect("Boletin.aspx");
                    break;
                case "5":
                    Session["tipoCriterio"] = tipoCriterio;
                    //abrir boletin
                    Response.Redirect("Boletin.aspx");
                    break;

                case "6":
                    tipoEvento = Convert.ToInt32(Request.QueryString[1].ToString());
                    if (tipoEvento == 0)
                    {
                        Session["idDetalleGaleria"] = Request.QueryString[2].ToString();
                        Response.Redirect("GaleriaArte_Detalle.aspx");
                    }
                    
                    else if (tipoEvento == 1)
                    {
                        Session["idProgramacion"] = Request.QueryString[2].ToString();
                        Response.Redirect("Auditorio_Detalle.aspx");
                    }
                    else if (tipoEvento == 2)
                    {
                        Session["idActividad"] = Request.QueryString[2].ToString();
                        Response.Redirect("Teatro_Detalle.aspx");
                    }
                    else if (tipoEvento == 3)
                    {
                        Session["idConcursoTemporada"] = Request.QueryString[2].ToString();
                        Response.Redirect("Concursos.aspx");
                    }

                    else if (tipoEvento == 4)
                    {
                        Session["idCurso"] = Request.QueryString[2].ToString();
                        Response.Redirect("CursoTaller_Detalle.aspx");
                    }
                    break;

                case "7":
                    tipoEvento = Convert.ToInt32(Request.QueryString[1].ToString());
                    if (tipoEvento == 0)
                    {
                        Session["idGaleria"] = Request.QueryString[2].ToString();
                        Response.Redirect("Galeria_Arte.aspx");

                        //Session["idDetalleGaleria"] = Request.QueryString[2].ToString();
                        //Response.Redirect("GaleriaArte_Detalle.aspx");
                    }

                    else if (tipoEvento == 1)
                    {
                        Session["idSede"] = Request.QueryString[2].ToString();
                        Response.Redirect("Auditorios.aspx");

                        //Session["idProgramacion"] = Request.QueryString[2].ToString();
                        //Response.Redirect("Auditorio_Detalle.aspx");
                    }
                    else if (tipoEvento == 2)
                    {
                        Session["idActividad"] = Request.QueryString[2].ToString();
                        Response.Redirect("Teatro_Detalle.aspx");
                    }
                    else if (tipoEvento == 3)
                    {
                        Session["idConcursoTemporada"] = Request.QueryString[2].ToString();
                        Response.Redirect("Concursos.aspx");
                    }

                    else if (tipoEvento == 4)
                    {
                        Session["idSede"] = Request.QueryString[2].ToString();
                        Response.Redirect("Cursos_Talleres.aspx");

                        //Session["idCurso"] = Request.QueryString[2].ToString();
                        //Response.Redirect("CursoTaller_Detalle.aspx");
                    }
                    break;
                   
 
                default:
                    break;

        }
    }
}
