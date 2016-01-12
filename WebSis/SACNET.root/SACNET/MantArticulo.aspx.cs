using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Britanico.SacNet.BusinessEntities;
using Britanico.SacNet.BusinessLogic;
using Oxinet.Maestros.BusinessLogic;
using Oxinet.Maestros.BusinessEntities;
using Oxinet.Maestros.Interface;
using Oxinet.Tools;
using System.Globalization;
using System.Configuration;
using System.IO;

public partial class MantArticulo : System.Web.UI.Page
{
    #region "/--- Eventos de la Página  ---/"
    /**************************************************************************/
    /**************************************************************************/
    protected void Page_Load(object sender, EventArgs e)
    {        
    this.InicializarEventos();
        
        CargarValoresHF();
        if (!Page.IsPostBack)
        {   
            imgFoto.ImageUrl = HelpConfiguration.AppSettings(HelpConfiguration.AppSett.DirImagenViewItem) + "NoDisponible.jpg";
            this.CargarPagina();
            
        }
        //this.CargarConfiguraciones();
        
    }
    protected void Page_LoadComplete(object sender, EventArgs e)
    {
        Seguridad();
        

    }
    #endregion

    #region "/--- Métodos del Programador  ---/"
    /**************************************************************************/
    /**************************************************************************/
    public string PintarEstado(bool pEstado)
    {
        string estado = string.Empty;

        if (pEstado)
            estado = "Si";
        else
            estado = "No";
        return estado;
    }

    private void CargarValoresHF()
    {
        if (Request.QueryString["pm"] != null)
        {
            string querystringDESENCRYP = HelpEncrypt.DesEncriptar(Request.QueryString.Get("pm"));
            hfParameters.Value = querystringDESENCRYP;
            //if(hfEvento.Value ==HelpEvento.Editar.ToString())
                hfCodItem.Value = HelpEncrypt.QueryString(querystringDESENCRYP, "iId");
            if (hfCodItem.Value != string.Empty)
            {
                hfCodSAC.Value = HelpEncrypt.QueryString(querystringDESENCRYP, "SAC");
            }
        }
        hfCodArguAudioVisual.Value = HelpConfiguration.AppSettings(HelpConfiguration.AppSett.CodArguTipoItemAudioVisual);
        //***ELVP: 19-09-2011********************
        hfCodArguLibroReader.Value = HelpConfiguration.AppSettings(HelpConfiguration.AppSett.CodArguTipoItemLibroReader);
        hfCodArguLibroGrammar.Value = HelpConfiguration.AppSettings(HelpConfiguration.AppSett.CodArguTipoItemLibroGrammar);
        hfCodArguLibroPaper.Value = HelpConfiguration.AppSettings(HelpConfiguration.AppSett.CodArguTipoItemLibroPaper);
        //hfCodArguLibro.Value = HelpConfiguration.AppSettings(HelpConfiguration.AppSett.CodArguTipoItemLibro);
        //***************************************
        hfCodArguRevista.Value = HelpConfiguration.AppSettings(HelpConfiguration.AppSett.CodArguTipoItemRevista);
        hfCodArguRecursoElectronico.Value = HelpConfiguration.AppSettings(HelpConfiguration.AppSett.CodArguTipoItemRecursoElectronico);
    }
    private void Seguridad()
    {
        //RolesOpciones oRolesOpciones = this.Master.HelpOpcion_Permiso("ListaArticulo.aspx");
        List<RolesOpciones> lstRolesOpciones = this.Master.HelpOpcion_Permiso_Lista("ListaArticulo.aspx");//ELVP:11-10-2011
        RolesOpciones oRolesOpciones = new RolesOpciones();

        if (lstRolesOpciones != null)  
        {
            DataTable dt = HelpConvert<RolesOpciones>.ConvertList(lstRolesOpciones);
            DataRow[] drEditar = dt.Select("Tipo=4");
            DataTable dtEditar = drEditar.Length>0? drEditar.CopyToDataTable(): new DataTable();

            DataRow[] drNuevo = dt.Select("Tipo=5");
            DataTable dtNuevo = drNuevo.Length>0? drNuevo.CopyToDataTable(): new DataTable();

            if (dtEditar.Rows.Count > 0)
            {
                lblTituloPagina.Text = dtEditar.Rows[0]["CodigoOpcionNombre"].ToString();
                BotonesEdicionMantenimiento1.BotonEditar = Convert.ToBoolean(dtEditar.Rows[0]["Flag_Editar"]);
                if (BotonesEdicionMantenimiento1.BotonNuevo || BotonesEdicionMantenimiento1.BotonEditar)
                    BotonesEdicionMantenimiento1.BotonGrabar = true;

                else
                    BotonesEdicionMantenimiento1.BotonGrabar = false;
            }
            if (dtNuevo.Rows.Count > 0)
            {
                lblTituloPagina.Text = dtNuevo.Rows[0]["CodigoOpcionNombre"].ToString();
                BotonesEdicionMantenimiento1.BotonNuevo = Convert.ToBoolean(dtNuevo.Rows[0]["Flag_Nuevo"]);
                if (BotonesEdicionMantenimiento1.BotonNuevo || BotonesEdicionMantenimiento1.BotonEditar)
                    BotonesEdicionMantenimiento1.BotonGrabar = true;

                else
                    BotonesEdicionMantenimiento1.BotonGrabar = false;
            }

            //lblTituloPagina.Text = oRolesOpciones.CodigoOpcionNombre;
            //BotonesEdicionMantenimiento1.BotonNuevo = oRolesOpciones.Flag_Nuevo;
            //BotonesEdicionMantenimiento1.BotonEditar = oRolesOpciones.Flag_Editar;
            //if (BotonesEdicionMantenimiento1.BotonNuevo || BotonesEdicionMantenimiento1.BotonEditar)
            //{
            //    BotonesEdicionMantenimiento1.BotonGrabar = true;

            //}
            //else
            //{
            //    BotonesEdicionMantenimiento1.BotonGrabar = false;

            //}

            if (Request.QueryString["pm"] != null)
            {
                string querystringDESENCRYP = HelpEncrypt.DesEncriptar(Request.QueryString.Get("pm"));
                if (HelpEncrypt.QueryString(querystringDESENCRYP, "EV") == HelpEvento.Ver.ToString())
                {
                    this.BotonesEdicionMantenimiento1.BotonCancelar = false;
                    this.BotonesEdicionMantenimiento1.BotonEditar = false;
                    this.BotonesEdicionMantenimiento1.BotonGrabar = false;
                    this.BotonesEdicionMantenimiento1.BotonNuevo = false;
                    pnRegistroItem.Enabled = false;

                }
            }            
            BotonesEdicionMantenimiento1.LoadComplete();
        }
        else
        {
            Response.Redirect("Login.aspx");
        }
    }
    private void CargarPagina()
    {
        
        this.CargarCombos();       
        this.EstadoDatosActivo(true);
        if (Request.QueryString["pm"] != null)
        {
            string querystringDESENCRYP = HelpEncrypt.DesEncriptar(Request.QueryString.Get("pm"));
            hfParameters.Value = querystringDESENCRYP;            
            //if (hfEvento.Value == HelpEvento.Editar.ToString())
                hfCodItem.Value = HelpEncrypt.QueryString(querystringDESENCRYP, "iId");
            if (hfCodItem.Value != string.Empty)
            {
                hfCodSAC.Value = HelpEncrypt.QueryString(querystringDESENCRYP, "SAC");
                PintarDatosItem(hfCodItem.Value);
                if (HelpEncrypt.QueryString(querystringDESENCRYP, "EV") == HelpEvento.Ver.ToString())
                {
                    pnRegistroItem.Enabled = false;
                    fuFotografia.Enabled = false;
                    this.BotonesEdicionMantenimiento1.BotonCancelar = false;
                    this.BotonesEdicionMantenimiento1.BotonEditar = false;
                    this.BotonesEdicionMantenimiento1.BotonGrabar = false;
                    this.BotonesEdicionMantenimiento1.BotonNuevo = false;
                    hfEvento.Value = HelpEvento.Ver.ToString();
                }
                else
                {
                    this.BotonesEdicionMantenimiento1.EstadoBoton(Controles_BotonEdicionMantenimiento.Evento.Editar);
                    hfEvento.Value = HelpEvento.Editar.ToString();
                    txtCodItem.Enabled = false;
                    ddlEstado.Enabled = false;
                }
            }
            else
            {
                this.BotonesEdicionMantenimiento1.EstadoBoton(Controles_BotonEdicionMantenimiento.Evento.Nuevo);
                hfEvento.Value = HelpEvento.Registrar.ToString();
                ddlEstado.SelectedValue = HelpConfiguration.AppSettings(HelpConfiguration.AppSett.CodArguEstadoItem_VXDF);
                ddlPrestamo.SelectedValue = HelpConfiguration.AppSettings(HelpConfiguration.AppSett.CodArguPrestamo_VXDF);
                ddlEstado.Enabled = false;
                Auditoria1.CargarSeguridadInicio();
                Session["Ejemplares"] = null;
                Session[HelpMaestros.CodigoTabla(HelpMaestros.TablasMaestras.AutoresDeItems)] = null;
                Session[HelpMaestros.CodigoTabla(HelpMaestros.TablasMaestras.ActoresDeObras)] = null;
                Session[HelpMaestros.CodigoTabla(HelpMaestros.TablasMaestras.TiposDeTemas)] = null;
                Session[HelpMaestros.CodigoTabla(HelpMaestros.TablasMaestras.AutoresDeItemsInstitucionales)] = null;
                gvEjemplares.DataSource = null;
                gvEjemplares.DataBind();

            }
        }
        else
        {
            this.BotonesEdicionMantenimiento1.EstadoBoton(Controles_BotonEdicionMantenimiento.Evento.Nuevo);
            hfEvento.Value = HelpEvento.Registrar.ToString();
            ddlEstado.SelectedValue = HelpConfiguration.AppSettings(HelpConfiguration.AppSett.CodArguEstadoItem_VXDF);
            ddlPrestamo.SelectedValue = HelpConfiguration.AppSettings(HelpConfiguration.AppSett.CodArguPrestamo_VXDF);
            ddlEstado.Enabled = false;
            Auditoria1.CargarSeguridadInicio();
            Session["Ejemplares"] = null;
            Session[HelpMaestros.CodigoTabla(HelpMaestros.TablasMaestras.AutoresDeItems)] = null;
            Session[HelpMaestros.CodigoTabla(HelpMaestros.TablasMaestras.ActoresDeObras)] = null;
            Session[HelpMaestros.CodigoTabla(HelpMaestros.TablasMaestras.TiposDeTemas)] = null;
            Session[HelpMaestros.CodigoTabla(HelpMaestros.TablasMaestras.AutoresDeItemsInstitucionales)] = null;
            gvEjemplares.DataSource = null;
            gvEjemplares.DataBind();

        }
            
        this.CargarConfiguraciones();

    }
    private void CargarCombos()
    {
        HelpMaestros.CargarListadoGenerico(ref ddlTipoItem, HelpMaestros.TablasMaestras.TiposDeItem, "", MaestroLogic.EstadoDetalle.Habilitado, HelpComboBox.Texto.Select);
        HelpMaestros.CargarListadoGenerico(ref ddlEstado, HelpMaestros.TablasMaestras.EstadosDeLosItems, "", MaestroLogic.EstadoDetalle.Habilitado, HelpComboBox.Texto.Select);
        HelpMaestros.CargarListadoGenerico(ref ddlTipoAudiencia, HelpMaestros.TablasMaestras.TiposDeAudiencia, "", MaestroLogic.EstadoDetalle.Habilitado, HelpComboBox.Texto.Select);
        HelpMaestros.CargarListadoGenerico(ref ddlProcedencia, HelpMaestros.TablasMaestras.TiposDeProcedencia, "", MaestroLogic.EstadoDetalle.Habilitado, HelpComboBox.Texto.Select);
        HelpMaestros.CargarListadoGenerico(ref ddlGenero, HelpMaestros.TablasMaestras.TiposDeGeneros, "", MaestroLogic.EstadoDetalle.Habilitado, HelpComboBox.Texto.Select);
        HelpMaestros.CargarListadoGenerico(ref ddlProveedor, HelpMaestros.TablasMaestras.TablaDeProveedores, "", MaestroLogic.EstadoDetalle.Habilitado, HelpComboBox.Texto.Select);
        HelpMaestros.CargarListadoGenerico(ref ddlPrestamo, HelpMaestros.TablasMaestras.TiposDePrestamos, "", MaestroLogic.EstadoDetalle.Habilitado, HelpComboBox.Texto.Select);
        this.CargarIdiomas();
        hfCodArguAudioVisual.Value = HelpConfiguration.AppSettings(HelpConfiguration.AppSett.CodArguTipoItemAudioVisual);
        //***ELVP:19-09-2011******************
        hfCodArguLibroReader.Value = HelpConfiguration.AppSettings(HelpConfiguration.AppSett.CodArguTipoItemLibroReader);
        hfCodArguLibroGrammar.Value = HelpConfiguration.AppSettings(HelpConfiguration.AppSett.CodArguTipoItemLibroGrammar);
        hfCodArguLibroPaper.Value = HelpConfiguration.AppSettings(HelpConfiguration.AppSett.CodArguTipoItemLibroPaper);
        //hfCodArguLibro.Value = HelpConfiguration.AppSettings(HelpConfiguration.AppSett.CodArguTipoItemLibro);
        //************************************
        hfCodArguRevista.Value = HelpConfiguration.AppSettings(HelpConfiguration.AppSett.CodArguTipoItemRevista);
        hfCodArguRecursoElectronico.Value = HelpConfiguration.AppSettings(HelpConfiguration.AppSett.CodArguTipoItemRecursoElectronico);
        
    }
    private void CargarIdiomas()
    {
        List<ListItem> ListaIdiomas = new List<ListItem>();
        foreach (CultureInfo Culturas in CultureInfo.GetCultures(CultureTypes.SpecificCultures))
        {
            ListaIdiomas.Add(new ListItem(Culturas.DisplayName, Culturas.Name));
        }
        ddlIdioma.DataSource = ListaIdiomas.OrderBy(x=>x.Text);
        ddlIdioma.DataTextField = "Text";
        ddlIdioma.DataValueField = "Value";
        ddlIdioma.DataBind();
        ddlIdioma.SelectedValue = "en-GB";
        

    }
    private string Validar()
    {
        string mensage = "";
        if (ddlTipoItem.SelectedIndex == 0) mensage = mensage + ",Ingresar el tipo del ítem";
        if (txtCodItem.Text == "") mensage = mensage + ",Ingresar el código del ítem";
        if (txtTitulo.Text == "") mensage = mensage + ", Ingresar el título del ítem";
        if (mensage.Length > 0)
            mensage = mensage.Substring(1);
        return mensage;
    }
    private void HabilitarCamposAudioVisual(bool pValor)
    {
        //Desactivar Campos Audiovisuales
        lblPieImprenta.Visible = !pValor;
        txtPieImprenta.Visible = !pValor;
        lblNPaginas.Visible = !pValor;
        txtNroPaginas.Visible = !pValor;        
        lblISSN.Visible = !pValor;        
        txtISSN.Visible = !pValor;
        lblAutores.Visible = !pValor;
        ltbAutores.Visible = !pValor;
        btnAgregarAutores.Visible = !pValor;
        lblEdicion.Visible = !pValor;
        txtEdicion.Visible = !pValor;
        pnAutoresInstitucionales.Visible = !pValor;

        //Activar Campos Audiovisuales
        lblISBN.Visible = pValor;
        txtISBN.Visible = pValor;
        lblDuracion.Visible = pValor;
        lblGenero.Visible = pValor;
        lblReqTecnico.Visible = pValor;
        lblTipoAudiencia.Visible = pValor;
        txtDuracion.Visible = pValor;
        txtReqTecnico.Visible = pValor;
        ddlGenero.Visible = pValor;
        ddlTipoAudiencia.Visible = pValor;
        pnActores.Visible = pValor;
        
    }
    private void HabilitarCamposLibros(bool pValor)
    {
        //Desactivar Campos Libros        
        lblISSN.Visible = !pValor;
        txtISSN.Visible = !pValor;
        lblDuracion.Visible = !pValor;
        lblGenero.Visible = !pValor;
        lblReqTecnico.Visible = !pValor;
        lblTipoAudiencia.Visible = !pValor;
        txtDuracion.Visible = !pValor;
        txtReqTecnico.Visible = !pValor;
        ddlGenero.Visible = !pValor;
        ddlTipoAudiencia.Visible = !pValor;
        pnActores.Visible = !pValor;

        //Activar Campos Libros
        lblAutores.Visible = pValor;
        ltbAutores.Visible = pValor;
        btnAgregarAutores.Visible = pValor;
        lblPieImprenta.Visible = pValor;
        txtPieImprenta.Visible = pValor;
        lblNPaginas.Visible = pValor;
        txtNroPaginas.Visible = pValor;
        lblEdicion.Visible = pValor;
        txtEdicion.Visible = pValor;
        lblISBN.Visible = pValor;
        txtISBN.Visible = pValor;
        pnAutoresInstitucionales.Visible = pValor;

    }
    private void HabilitarCamposRecursoElectronico(bool pValor)
    {
        //Desactivar Campos Libros        
        lblISSN.Visible = !pValor;
        txtISSN.Visible = !pValor;        
        lblGenero.Visible = !pValor;        
        lblTipoAudiencia.Visible = !pValor;
        ddlGenero.Visible = !pValor;
        ddlTipoAudiencia.Visible = !pValor;
        pnActores.Visible = !pValor;
        lblAutores.Visible = !pValor;
        ltbAutores.Visible = !pValor;
        btnAgregarAutores.Visible = !pValor;
        lblPieImprenta.Visible = !pValor;
        txtPieImprenta.Visible = !pValor;
        lblNPaginas.Visible = !pValor;
        txtNroPaginas.Visible = !pValor;
        lblEdicion.Visible = !pValor;
        txtEdicion.Visible = !pValor;
        lblISBN.Visible = !pValor;
        txtISBN.Visible = !pValor;
        pnAutoresInstitucionales.Visible = !pValor;

        //Activar Campos Libros
        lblDuracion.Visible = pValor;
        txtDuracion.Visible = pValor;
        lblReqTecnico.Visible = pValor;
        txtReqTecnico.Visible = pValor;
        
    }
    private void HabilitarCamposRevista(bool pValor)
    {
        //Desactivar Campos Libros        
        
        lblGenero.Visible = !pValor;
        lblTipoAudiencia.Visible = !pValor;
        ddlGenero.Visible = !pValor;
        ddlTipoAudiencia.Visible = !pValor;
        pnActores.Visible = !pValor;        
        lblISBN.Visible = !pValor;
        txtISBN.Visible = !pValor;
        lblDuracion.Visible = !pValor;
        txtDuracion.Visible = !pValor;
        lblReqTecnico.Visible = !pValor;
        txtReqTecnico.Visible = !pValor;

        //Activar Campos Libros
        lblAutores.Visible = pValor;
        ltbAutores.Visible = pValor;
        btnAgregarAutores.Visible = pValor;
        lblPieImprenta.Visible = pValor;
        txtPieImprenta.Visible = pValor;
        lblNPaginas.Visible = pValor;
        txtNroPaginas.Visible = pValor;
        lblEdicion.Visible = pValor;
        txtEdicion.Visible = pValor;
        lblISSN.Visible = pValor;
        txtISSN.Visible = pValor;
        pnAutoresInstitucionales.Visible = pValor;

    }
    private void EstadoDatosActivo(bool ESTADO)
    {
        fuFotografia.Enabled = ESTADO;
        pnRegistroItem.Enabled = ESTADO;        
    }
    private void LimpiarDatos()
    {
        ddlTipoItem.SelectedIndex = 0;
        ddlEstado.SelectedIndex = 0;
        ddlTipoAudiencia.SelectedIndex = 0;
        ddlProcedencia.SelectedIndex = 0;
        ddlGenero.SelectedIndex = 0;
        ddlProveedor.SelectedIndex = 0;
        ddlPrestamo.SelectedIndex = 0;
        ddlIdioma.SelectedValue = "en-GB";
        txtCodItem.Text = string.Empty;
        txtTitulo.Text = string.Empty;
        txtPieImprenta.Text = string.Empty;
        txtISBN.Text = string.Empty;
        txtISSN.Text = string.Empty;
        txtNroPaginas.Text = string.Empty;
        txtEdicion.Text = string.Empty;
        txtPrecioUnitario.Text = string.Empty;
        txtDuracion.Text = string.Empty;
        txtFormatoAdicional.Text = string.Empty;
        txtReqTecnico.Text = string.Empty;
        txtNotas.Text = string.Empty;
        txtResumen.Text = string.Empty;


    }
    private void CargarConfiguraciones()
    {
        String querystringENCRYP_ED = string.Empty;
        String querystringENCRYP_Autores = string.Empty;
        String querystringENCRYP_Actores = string.Empty;
        String querystringENCRYP_Temas = string.Empty;
        String querystringENCRYP_AutoresInstitucionales = string.Empty;
        querystringENCRYP_ED = HelpEncrypt.Encriptar("&oCodItem=" + hfCodItem.Value);
        this.ibtnAgregarEjemplar.Attributes.Add("OnClick", "OpenPopup('PopupAgregarEjemplar.aspx?pm=" + querystringENCRYP_ED + "',600,390)");

        querystringENCRYP_Autores = HelpEncrypt.Encriptar("&oCodTabla=" + HelpMaestros.CodigoTabla(HelpMaestros.TablasMaestras.AutoresDeItems) + "&oCodItem=" + hfCodItem.Value + "&oFec=" + DateTime.Today.ToLongTimeString());
        this.btnAgregarAutores.Attributes.Add("OnClick", "OpenPopup('PopupAgregarLista.aspx?pm=" + querystringENCRYP_Autores + "',600,520)");

        querystringENCRYP_Actores = HelpEncrypt.Encriptar("&oCodTabla=" + HelpMaestros.CodigoTabla(HelpMaestros.TablasMaestras.ActoresDeObras) + "&oCodItem=" + hfCodItem.Value + "&oFec=" + DateTime.Today.ToLongTimeString());
        this.btnAgregarActores.Attributes.Add("OnClick", "OpenPopup('PopupAgregarLista.aspx?pm=" + querystringENCRYP_Actores + "',600,520)");

        querystringENCRYP_Temas = HelpEncrypt.Encriptar("&oCodTabla=" + HelpMaestros.CodigoTabla(HelpMaestros.TablasMaestras.TiposDeTemas) + "&oCodItem=" + hfCodItem.Value + "&oFec=" + DateTime.Today.ToLongTimeString());
        this.btnAgregarTemas.Attributes.Add("OnClick", "OpenPopup('PopupAgregarLista.aspx?pm=" + querystringENCRYP_Temas + "',600,520)");

        querystringENCRYP_AutoresInstitucionales = HelpEncrypt.Encriptar("&oCodTabla=" + HelpMaestros.CodigoTabla(HelpMaestros.TablasMaestras.AutoresDeItemsInstitucionales) + "&oCodItem=" + hfCodItem.Value + "&oFec=" + DateTime.Today.ToLongTimeString());
        this.btnAgregarAutoresInstitucionales.Attributes.Add("OnClick", "OpenPopup('PopupAgregarLista.aspx?pm=" + querystringENCRYP_AutoresInstitucionales + "',600,520)");

        txtNroPaginas.Attributes.Add("onKeyPress", "return filterInput(1, event)");
        txtPrecioUnitario.Attributes.Add("OnKeyPress", "return filterInput(1, event, true ,' ')");
    }
    private void EliminarEjemplar(string CodItem,string CodEjemplar, string IndexGrid)
    {
        List<ItemEjemplar> ListaItemEjemplar = (List<ItemEjemplar>)Session["Ejemplares"];

        if (string.IsNullOrEmpty(CodItem) == false)
        {

            ItemEjemplarLogic oItemEjemplarLogic = new ItemEjemplarLogic();
            
            ReturnValor OReturnValor =   oItemEjemplarLogic.Eliminar(CodEjemplar);
            if (OReturnValor.Exitosa)
            {
                int posicion = ListaItemEjemplar.FindIndex(x => x.sCodEjemplar == CodEjemplar.Trim());
                ListaItemEjemplar.RemoveAt(posicion);
                MessageBox1.ShowSuccess(OReturnValor.Message);

            }
            else
            {
                MessageBox1.ShowWarning(OReturnValor.Message);
            }
        }
        else
        {
            ListaItemEjemplar.RemoveAt(Convert.ToInt32(IndexGrid));
        }

        gvEjemplares.DataSource = ListaItemEjemplar;
        gvEjemplares.DataBind();
        Session["Ejemplares"] = ListaItemEjemplar;

    }
    private bool GenerarFotografiaEnServidor(string NombreImagen)
    {
        bool pValorSucced = false;
        ReturnValor oReturn = new ReturnValor();
        NombreImagen = NombreImagen.Replace("/", "@");
        try
        {
            string DirImagenItem = HelpConfiguration.AppSettings(HelpConfiguration.AppSett.DirImagenItem);            
            if (fuFotografia.HasFile)
            {
                string FotoExtension = Path.GetExtension(fuFotografia.FileName);    
                if (FotoExtension.ToUpper() == ".jpg".ToUpper())
                {
                    int fileSize = fuFotografia.PostedFile.ContentLength;
                    int filePred = Convert.ToInt32(HelpConfiguration.AppSettings(HelpConfiguration.AppSett.TamanoMaximoImagen)) * 1024;
                    int fileConf = Convert.ToInt32(HelpConfiguration.AppSettings(HelpConfiguration.AppSett.TamanoMaximoImagen));
                    if (fileSize <= filePred)
                    {
                        fuFotografia.SaveAs(DirImagenItem + NombreImagen + FotoExtension);
                        pValorSucced = true;
                    }
                    else
                    {
                        MessageBox1.ShowWarning("¡ El tamaño de la imagen seleccionada excede al tamaño predeterminado : [" + fileConf.ToString() + " Kb]!");
                        pValorSucced = false;
                       
                    }
                }
                else
                {
                    MessageBox1.ShowWarning( "¡ El formato de la imagen es incorrecto,solo se aceptan .jpg !");
                    pValorSucced = false;
                }

            }
            else
            {
                File.Copy(DirImagenItem + "NoDisponible.jpg", DirImagenItem + NombreImagen + ".jpg", true);                
                pValorSucced = true;
            }
            
        }
        catch (Exception ex)
        {
            MessageBox1.ShowWarning( ex.Message);
        }
        return pValorSucced;

 
    }
    private void ForzarPostback()
    {
        ScriptManager.RegisterStartupScript(this,GetType(), "jsKeys", "javascript:Forzar();",true);
    }
        
    private void MostrarFotografia(string NombreFoto)
    {
        string PathImagenes = HelpConfiguration.AppSettings(HelpConfiguration.AppSett.DirImagenViewItem);// Trabajo en Desarrollo
        NombreFoto = NombreFoto.Replace("/", "@");
        imgFoto.Dispose();
        imgFoto.ImageUrl = PathImagenes + NombreFoto;
        imgFoto.DataBind();
    }
    private Item GetItem()
    {
        Item oItem = new Item();
        oItem.sCodItem = txtCodItem.Text.Trim();
        oItem.sCodArguTipoItem = ddlTipoItem.SelectedItem.Value;
        oItem.sTitulo = txtTitulo.Text;
        oItem.sCodArguEstadoItem = ddlEstado.SelectedItem.Value;
        oItem.sIdioma = ddlIdioma.SelectedItem.Value;
        oItem.sPieImprenta = txtPieImprenta.Text;
        oItem.sISBN = txtISBN.Text;
        oItem.sISSN = txtISSN.Text;
        oItem.nPaginas = txtNroPaginas.Text == "" ? 0 : Convert.ToInt32(txtNroPaginas.Text);
        oItem.sEdicion = txtEdicion.Text;
        oItem.sCodArguPrestamoEn = ddlPrestamo.SelectedItem.Value;
        oItem.sCodArguAudiencia = ddlTipoAudiencia.SelectedItem.Value;
        oItem.fPrecioUnitario = txtPrecioUnitario.Text == "" ? 0 : Convert.ToDecimal(txtPrecioUnitario.Text);
        oItem.sCodArguProcedencia = ddlProcedencia.SelectedItem.Value;
        oItem.sDuracion = txtDuracion.Text;
        oItem.sCodArguGenero = ddlGenero.SelectedItem.Value;
        oItem.sFormatoAdicional = txtFormatoAdicional.Text;
        oItem.sCodArguProveedor = ddlProveedor.SelectedItem.Value;
        oItem.sRequerimientoTecnico = txtReqTecnico.Text;
        oItem.sResumen = txtResumen.Text;
        oItem.sNotas = txtNotas.Text;
        oItem.sFotografia = txtCodItem.Text.Trim() + ".jpg";
        oItem.SSIUsuario_Creacion = Master.HelpUsuario().LoginUsuario;
        oItem.SSIUsuario_Modificacion = Master.HelpUsuario().LoginUsuario;
        oItem.SSIHost = Request.ServerVariables["HTTP_CLIENT-IP"] == null ? string.Empty : Request.ServerVariables["HTTP_CLIENT-IP"];
        if (Session["Ejemplares"] != null)
        {
            List<ItemEjemplar> oListaEjemplares = new List<ItemEjemplar>();
            oListaEjemplares = (List<ItemEjemplar>)Session["Ejemplares"];
            oItem.ListaEjemplares = oListaEjemplares;
        }
        if (Session[HelpMaestros.CodigoTabla(HelpMaestros.TablasMaestras.AutoresDeItems)] != null)
        {
            List<TDetalle> ListaDetalleAutor = new List<TDetalle>();
            List<ItemAutor> oListaItemAutor = new List<ItemAutor>();
            ListaDetalleAutor = (List<TDetalle>)Session[HelpMaestros.CodigoTabla(HelpMaestros.TablasMaestras.AutoresDeItems)];
            foreach (TDetalle item in ListaDetalleAutor)
            {
                oListaItemAutor.Add(new ItemAutor() { sCodArguAutor = item.CodArgu, bEstado = item.Activo, SSIUsuario_Creacion = Master.HelpUsuario().LoginUsuario, SSIHost = Context.Request.UserHostName });
            }
            oItem.ListaAutores = oListaItemAutor;
        }
        if (Session[HelpMaestros.CodigoTabla(HelpMaestros.TablasMaestras.ActoresDeObras)] != null)
        {
            List<TDetalle> ListaDetalleActor = new List<TDetalle>();
            List<ItemActor> oListaItemActor = new List<ItemActor>();
            ListaDetalleActor = (List<TDetalle>)Session[HelpMaestros.CodigoTabla(HelpMaestros.TablasMaestras.ActoresDeObras)];
            foreach (TDetalle item in ListaDetalleActor)
            {
                oListaItemActor.Add(new ItemActor() { sCodArguActor = item.CodArgu, bActivo = item.Activo, SSIUsuario_Creacion = Master.HelpUsuario().LoginUsuario, SSIHost = Context.Request.UserHostName });
            }
            oItem.ListaActores = oListaItemActor;

        }
        if (Session[HelpMaestros.CodigoTabla(HelpMaestros.TablasMaestras.TiposDeTemas)] != null)
        {
            List<TDetalle> ListaDetalleTema = new List<TDetalle>();
            List<ItemTema> oListaItemTema = new List<ItemTema>();
            ListaDetalleTema = (List<TDetalle>)Session[HelpMaestros.CodigoTabla(HelpMaestros.TablasMaestras.TiposDeTemas)];
            foreach (TDetalle item in ListaDetalleTema)
            {
                oListaItemTema.Add(new ItemTema() { sCodArguTema = item.CodArgu, bEstado = item.Activo, SSIUsuario_Creacion = Master.HelpUsuario().LoginUsuario, SSIHost = Context.Request.UserHostName });
            }
            oItem.ListaTemas = oListaItemTema;

        }
        if (Session[HelpMaestros.CodigoTabla(HelpMaestros.TablasMaestras.AutoresDeItemsInstitucionales)] != null)
        {
            List<TDetalle> ListaDetalleAutorInstitucional = new List<TDetalle>();
            List<ItemAutor> oListaItemAutorInstitucional = new List<ItemAutor>();
            ListaDetalleAutorInstitucional = (List<TDetalle>)Session[HelpMaestros.CodigoTabla(HelpMaestros.TablasMaestras.AutoresDeItemsInstitucionales)];
            foreach (TDetalle item in ListaDetalleAutorInstitucional)
            {
                oListaItemAutorInstitucional.Add(new ItemAutor() { sCodArguAutor = item.CodArgu, bEstado = item.Activo, SSIUsuario_Creacion = Master.HelpUsuario().LoginUsuario, SSIHost = Context.Request.UserHostName });
            }
            oItem.ListaAutoresInstitucionales = oListaItemAutorInstitucional;
        }

        return oItem;
    }
   
    private void PintarDatosItem(string pCodItem)
    {
        ItemLogic oItemLogic = new ItemLogic();
        Item oItem = new Item();
        oItem = oItemLogic.Buscar(pCodItem);
        txtCodItem.Text = oItem.sCodItem;
        ddlTipoItem.SelectedValue =oItem.sCodArguTipoItem;
        txtTitulo.Text=oItem.sTitulo;
        ddlEstado.SelectedValue = oItem.sCodArguEstadoItem;
        ddlIdioma.SelectedValue = oItem.sIdioma;
        txtPieImprenta.Text=oItem.sPieImprenta;
        txtISBN.Text=oItem.sISBN;
        txtISSN.Text=oItem.sISSN;
        txtNroPaginas.Text =oItem.nPaginas.ToString();
        txtEdicion.Text=oItem.sEdicion;
        ddlPrestamo.SelectedValue = oItem.sCodArguPrestamoEn;
        ddlTipoAudiencia.SelectedValue = oItem.sCodArguAudiencia;
        txtPrecioUnitario.Text =oItem.fPrecioUnitario.ToString();
        ddlProcedencia.SelectedValue = oItem.sCodArguProcedencia;
        txtDuracion.Text=oItem.sDuracion ;
        ddlGenero.SelectedValue = oItem.sCodArguGenero;
        txtFormatoAdicional.Text=oItem.sFormatoAdicional;
        ddlProveedor.SelectedValue = oItem.sCodArguProveedor;
        txtReqTecnico.Text=oItem.sRequerimientoTecnico;
        txtResumen.Text=oItem.sResumen;
        txtNotas.Text=oItem.sNotas;
        MostrarFotografia(oItem.sFotografia);
        if (ddlTipoItem.SelectedValue == hfCodArguAudioVisual.Value)
        {
            HabilitarCamposAudioVisual(true);
        }
        //else if (ddlTipoItem.SelectedValue == hfCodArguLibro.Value)
        else if (ddlTipoItem.SelectedValue == hfCodArguLibroReader.Value ||
            ddlTipoItem.SelectedValue == hfCodArguLibroGrammar.Value ||
            ddlTipoItem.SelectedValue == hfCodArguLibroPaper.Value)//ELVP:19-09-2011
        {
            HabilitarCamposLibros(true);
        }
        else if (ddlTipoItem.SelectedValue == hfCodArguRevista.Value)
        {
            HabilitarCamposRevista(true);
        }
        else if (ddlTipoItem.SelectedValue == hfCodArguRecursoElectronico.Value)
        {
            HabilitarCamposRecursoElectronico(true);
        }        
        if (oItem.ListaAutores != null)
        {
            List<ItemAutor> ListaAutor = new List<ItemAutor>();
            List<TDetalle> ListaDetAutor = new List<TDetalle>();
            ListaAutor = oItem.ListaAutores;
            foreach (ItemAutor itemAutor in ListaAutor)
            {
                ListaDetAutor.Add(new TDetalle() { CodArgu = itemAutor.sCodArguAutor, Nombre = itemAutor.sCodArguNombreAutor, Activo = itemAutor.bEstado });
                
            }
            ltbAutores.DataSource = ListaDetAutor;
            ltbAutores.DataTextField = "Nombre";
            ltbAutores.DataValueField = "CodArgu";
            ltbAutores.DataBind();
            Session[HelpMaestros.CodigoTabla(HelpMaestros.TablasMaestras.AutoresDeItems)] = ListaDetAutor;
            
        }
       
        
        if (oItem.ListaAutoresInstitucionales != null)
        {
            List<ItemAutor> ListaAutorInstitucionales = new List<ItemAutor>();
            List<TDetalle> ListaDetAutorInstitucionales = new List<TDetalle>();
            ListaAutorInstitucionales = oItem.ListaAutoresInstitucionales;
            foreach (ItemAutor itemAutorIn in ListaAutorInstitucionales)
            {
                ListaDetAutorInstitucionales.Add(new TDetalle() { CodArgu = itemAutorIn.sCodArguAutor, Nombre = itemAutorIn.sCodArguNombreAutor, Activo = itemAutorIn.bEstado });
            }
            ltbAutoresInstitucionales.DataSource = ListaDetAutorInstitucionales;
            ltbAutoresInstitucionales.DataTextField = "Nombre";
            ltbAutoresInstitucionales.DataValueField = "CodArgu";
            ltbAutoresInstitucionales.DataBind();
            Session[HelpMaestros.CodigoTabla(HelpMaestros.TablasMaestras.AutoresDeItemsInstitucionales)] = ListaDetAutorInstitucionales;
        }
        if (oItem.ListaTemas != null)
        {
            List<ItemTema> ListaTema = new List<ItemTema>();
            List<TDetalle> ListaDetTema = new List<TDetalle>();
            ListaTema = oItem.ListaTemas;
            foreach (ItemTema itemTema in ListaTema)
            {
                ListaDetTema.Add(new TDetalle() { CodArgu = itemTema.sCodArguTema, Nombre = itemTema.sCodArguNombreTema, Activo = itemTema.bEstado });
            }
            ltbTemas.DataSource = ListaDetTema;
            ltbTemas.DataTextField = "Nombre";
            ltbTemas.DataValueField = "CodArgu";
            ltbTemas.DataBind();
            Session[HelpMaestros.CodigoTabla(HelpMaestros.TablasMaestras.TiposDeTemas)] = ListaDetTema;
        }
        if (oItem.ListaActores != null)
        {
            List<ItemActor> ListaActor = new List<ItemActor>();
            List<TDetalle> ListaDetActor = new List<TDetalle>();
            ListaActor = oItem.ListaActores;
            foreach (ItemActor itemActor in ListaActor)
            {
                ListaDetActor.Add(new TDetalle() { CodArgu = itemActor.sCodArguActor, Nombre = itemActor.sCodArguNombreActor, Activo = itemActor.bActivo});
            }
            ltbActores.DataSource = ListaDetActor;
            ltbActores.DataTextField = "Nombre";
            ltbActores.DataValueField = "CodArgu";
            ltbActores.DataBind();
            Session[HelpMaestros.CodigoTabla(HelpMaestros.TablasMaestras.ActoresDeObras)] = ListaDetActor;
        }
        ListarEjemplares(pCodItem);
        Auditoria1.CargarSeguridad(oItem.SSIUsuario_Creacion, oItem.SSIUsuario_Modificacion, oItem.SSIFechaHora_Creacion, oItem.SSIFechaHora_Modificacion, oItem.SSIHost);
        
    }
    private void ListarEjemplares(string pCodItem)
    {
        ItemEjemplarLogic oItemEjemplarLogic = new ItemEjemplarLogic();
        List<ItemEjemplar> ListaItemEjemplar = new List<ItemEjemplar>();
        ListaItemEjemplar=oItemEjemplarLogic.Listar(pCodItem,hfCodSAC.Value.ToString(),string.Empty);
        gvEjemplares.DataSource=ListaItemEjemplar;
        gvEjemplares.DataBind();
        Session["Ejemplares"] = ListaItemEjemplar;
    }
    #endregion

    #region "/--- Eventos de los Controles  ---/"
    /**************************************************************************/
    /**************************************************************************/
    #region "/--- Eventos de los Botones de Comando  ---/"
    /**************************************************************************/
    /**************************************************************************/
    private void InicializarEventos()
    {
        this.BotonesEdicionMantenimiento1.OnBotonNuevoClick += new EventHandler(BotonEdicionMantenimiento1_OnBotonNuevoClick);
        this.BotonesEdicionMantenimiento1.OnBotonEditarClick += new EventHandler(BotonEdicionMantenimiento1_OnBotonEditarClick);
        this.BotonesEdicionMantenimiento1.OnBotonGrabarClick += new EventHandler(BotonEdicionMantenimiento1_OnBotonGrabarClick);
        this.BotonesEdicionMantenimiento1.OnBotonCancelarClick += new EventHandler(BotonEdicionMantenimiento1_OnBotonCancelarClick);
        this.BotonesEdicionMantenimiento1.OnBotonRegresarClick += new EventHandler(BotonEdicionMantenimiento1_OnBotonRegresarClick);

    }
    void BotonEdicionMantenimiento1_OnBotonNuevoClick(object sender, EventArgs e)
    {
        Session["Ejemplares"] = null;
        Session[HelpMaestros.CodigoTabla(HelpMaestros.TablasMaestras.AutoresDeItems)] = null;
        Session[HelpMaestros.CodigoTabla(HelpMaestros.TablasMaestras.ActoresDeObras)] = null;
        Session[HelpMaestros.CodigoTabla(HelpMaestros.TablasMaestras.TiposDeTemas)] = null;
        Session[HelpMaestros.CodigoTabla(HelpMaestros.TablasMaestras.AutoresDeItemsInstitucionales)] = null;
       
        string cadeParametros = hfParameters.Value.Substring(hfParameters.Value.ToString().IndexOf("&xTA"), hfParameters.Value.Trim().Length - hfParameters.Value.ToString().IndexOf("xTA") + 1);
        Response.Redirect("MantArticulo.aspx?pm=" + HelpEncrypt.Encriptar(cadeParametros), false);
       

    }

    void BotonEdicionMantenimiento1_OnBotonEditarClick(object sender, EventArgs e)
    {
        BotonesEdicionMantenimiento1.EstadoBoton(Controles_BotonEdicionMantenimiento.Evento.Editar);
        hfEvento.Value = HelpEvento.Editar.ToString();
        EstadoDatosActivo(true);
        Session["Ejemplares"] = null;
        Session[HelpMaestros.CodigoTabla(HelpMaestros.TablasMaestras.AutoresDeItems)] = null;
        Session[HelpMaestros.CodigoTabla(HelpMaestros.TablasMaestras.ActoresDeObras)] = null;
        Session[HelpMaestros.CodigoTabla(HelpMaestros.TablasMaestras.TiposDeTemas)] = null;
        Session[HelpMaestros.CodigoTabla(HelpMaestros.TablasMaestras.AutoresDeItemsInstitucionales)] = null;
        hfCodItem.Value = txtCodItem.Text;
        CargarConfiguraciones();
        PintarDatosItem(txtCodItem.Text);
        
    }

    void BotonEdicionMantenimiento1_OnBotonGrabarClick(object sender, EventArgs e)
    {
        string mensaje = Validar();
        if (mensaje == "")
        {
            if (string.IsNullOrEmpty(txtPrecioUnitario.Text) == false)
            {
                if (HelpNumbers.EsValido_Numero2Decimales(txtPrecioUnitario.Text) == false)
                {
                    MessageBox1.ShowInfo("El formato ingresado del precio unitario es incorrecto,solo se permite 2 decimales.");
                    return;
                }
            }
            
            try
            {
                ReturnValor oReturnValor = new ReturnValor();
                ItemLogic oItemLogic = new ItemLogic();
                Item oItem = new Item();
                oItem = GetItem();
                if (hfEvento.Value == HelpEvento.Registrar.ToString()) // Registro Item
                {
                    if (GenerarFotografiaEnServidor(oItem.sCodItem))
                    {
                        oReturnValor = oItemLogic.Registrar(oItem);
                        if (oReturnValor.Exitosa)
                        {
                            //hfCodItem.Value = txtCodItem.Text.Trim();
                            BotonesEdicionMantenimiento1.EstadoBoton(Controles_BotonEdicionMantenimiento.Evento.GuardarNuevo);
                            MostrarFotografia(oItem.sFotografia);
                            MessageBox1.ShowSuccess(oReturnValor.Message);
                            EstadoDatosActivo(false);
                        }
                        else
                        {
                            MessageBox1.ShowWarning(oReturnValor.Message);
                        }
                    }


                }
                else if (hfEvento.Value == HelpEvento.Editar.ToString()) // Actualizacion Item
                {
                    if (fuFotografia.HasFile)
                    {
                        if (GenerarFotografiaEnServidor(oItem.sCodItem))
                        {
                            oReturnValor = oItemLogic.Actualizar(oItem);
                            if (oReturnValor.Exitosa)
                            {
                                BotonesEdicionMantenimiento1.EstadoBoton(Controles_BotonEdicionMantenimiento.Evento.GuardarNuevo);
                                MostrarFotografia(oItem.sFotografia);

                                MessageBox1.ShowSuccess(oReturnValor.Message);
                                EstadoDatosActivo(false);
                            }
                            else
                            {
                                MessageBox1.ShowWarning(oReturnValor.Message);

                            }
                        }
                    }
                    else
                    {
                        oReturnValor = oItemLogic.Actualizar(oItem);
                        if (oReturnValor.Exitosa)
                        {
                            BotonesEdicionMantenimiento1.EstadoBoton(Controles_BotonEdicionMantenimiento.Evento.GuardarNuevo);
                            MostrarFotografia(oItem.sFotografia);

                            MessageBox1.ShowSuccess(oReturnValor.Message);
                            EstadoDatosActivo(false);
                        }
                        else
                        {
                            MessageBox1.ShowWarning(oReturnValor.Message);

                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox1.ShowError(ex.Message);
            }

        }
        else
        {
            MessageBox1.ShowInfo(mensaje);
        }
    }

    void BotonEdicionMantenimiento1_OnBotonCancelarClick(object sender, EventArgs e)
    {
        //BotonesEdicionMantenimiento1.EstadoBoton(Controles_BotonEdicionMantenimiento.Evento.GuardarNuevo);

    }

    void BotonEdicionMantenimiento1_OnBotonRegresarClick(object sender, EventArgs e)
    {

        //BotonesEdicionMantenimiento1.EstadoBoton(Controles_BotonEdicionMantenimiento.Evento.GuardarNuevo);

        Response.Redirect("ListaArticulo.aspx?pm=" + HelpEncrypt.Encriptar(hfParameters.Value), false);

        //string script = String.Format("RegresarMe();", "");
        //if (!this.Page.ClientScript.IsStartupScriptRegistered("RegresarPageScript"))
        //{

        //    ScriptManager.RegisterStartupScript(this, this.GetType(), "RegresarPageScript", script, true);
        //}

    }
    #endregion
    protected void gvEjemplares_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            String querystringENCRYP_ED = string.Empty;
            String querystringENCRYP_VER = string.Empty;
            if (string.IsNullOrEmpty(gvEjemplares.DataKeys[e.Row.RowIndex][0].ToString()) == false) // Viene de BD
            {
                string CodItem = gvEjemplares.DataKeys[e.Row.RowIndex][0].ToString();
                string CodEjemplar = e.Row.Cells[1].Text;
                ImageButton btnEditar = (ImageButton)e.Row.Cells[7].FindControl("btnEditar");
                ImageButton btnVer = (ImageButton)e.Row.Cells[6].FindControl("btnVer");
                querystringENCRYP_ED = HelpEncrypt.Encriptar("&aId=" + CodEjemplar + "&oIdItem=" + hfCodItem.Value);
                btnEditar.Attributes.Add("onclick", "OpenPopup('PopupAgregarEjemplar.aspx?pm=" + querystringENCRYP_ED + "',740,390)");
                querystringENCRYP_VER = HelpEncrypt.Encriptar("&aId=" + CodEjemplar + "&oIdItem=" + hfCodItem.Value + "&EV=" + HelpEvento.Ver.ToString());
                btnVer.Attributes.Add("onclick", "OpenPopup('PopupAgregarEjemplar.aspx?pm=" + querystringENCRYP_VER + "',740,390)");
            }
            else
            {
                string IndexRow = e.Row.RowIndex.ToString();
                ImageButton btnEditar = (ImageButton)e.Row.Cells[7].FindControl("btnEditar");
                ImageButton btnVer = (ImageButton)e.Row.Cells[6].FindControl("btnVer");
                querystringENCRYP_ED = HelpEncrypt.Encriptar("&aIndex=" + IndexRow);
                btnEditar.Attributes.Add("onclick", "OpenPopup('PopupAgregarEjemplar.aspx?pm=" + querystringENCRYP_ED + "',740,390)");
                querystringENCRYP_VER = HelpEncrypt.Encriptar("&aIndex=" + IndexRow + "&EV=" + HelpEvento.Ver.ToString());
                btnVer.Attributes.Add("onclick", "OpenPopup('PopupAgregarEjemplar.aspx?pm=" + querystringENCRYP_VER + "',740,390)");
            }
        }
    }
    protected void gvEjemplares_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Eliminar")
        {
            GridViewRow row = ((GridViewRow)((Control)e.CommandSource).NamingContainer);
            string Parametros = e.CommandArgument.ToString();
            string[] pValor = Parametros.Split(new char[] {'-'});
            string index = row.RowIndex.ToString();
            // string Codigo = row.Cells[0].Text;
            EliminarEjemplar(pValor[1].ToString(), pValor[0].ToString(), index);
        }
    }
    protected void ddlTipoItem_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlTipoItem.SelectedValue == hfCodArguAudioVisual.Value)
        {
            HabilitarCamposAudioVisual(true);            
        }
        //else if (ddlTipoItem.SelectedValue == hfCodArguLibro.Value)
        else if (ddlTipoItem.SelectedValue == hfCodArguLibroReader.Value ||
            ddlTipoItem.SelectedValue == hfCodArguLibroGrammar.Value ||
            ddlTipoItem.SelectedValue == hfCodArguLibroPaper.Value)//ELVP:19-09-2011
        {
            HabilitarCamposLibros(true);
        }
        else if (ddlTipoItem.SelectedValue == hfCodArguRevista.Value)
        {
            HabilitarCamposRevista(true);
        }
        else if (ddlTipoItem.SelectedValue == hfCodArguRecursoElectronico.Value)
        {
            HabilitarCamposRecursoElectronico(true);
        }        
        
    }
    //protected void UpdatePanelJavaScriptExtender1_Update(object Sender, EventArgs E, string parameter)
    //{
    //    //String querystringENCRYP_ED = string.Empty;
    //    //querystringENCRYP_ED = HelpEncrypt.Encriptar("&oCodItem=" + hfCodItem.Value);
    //    //this.ibtnAgregarEjemplar.Attributes.Add("OnClick", "OpenPopup('PopupAgregarEjemplar.aspx?pm=" + querystringENCRYP_ED + "',740,390)");
    //}
    protected void ibtnAgregarEjemplar_Click(object sender, ImageClickEventArgs e)
    {
        if (Session["Ejemplares"] != null)
        {
            if (hfEvento.Value == HelpEvento.Registrar.ToString())
                gvEjemplares.DataSource = (List<ItemEjemplar>)Session["Ejemplares"];
            else
                gvEjemplares.DataSource = EjemplaresDelSAC();

            //this.gvEjemplares.DataSource = (List<ItemEjemplar>)Session["Ejemplares"];
            this.gvEjemplares.DataBind();
        }


    }
    protected void btnEditar_Click(object sender, ImageClickEventArgs e)
    {
        if (Session["Ejemplares"] != null)
        {
            if (hfEvento.Value == HelpEvento.Registrar.ToString())
                gvEjemplares.DataSource = (List<ItemEjemplar>)Session["Ejemplares"];
            else
                gvEjemplares.DataSource = EjemplaresDelSAC();

            //this.gvEjemplares.DataSource = (List<ItemEjemplar>)Session["Ejemplares"];
            this.gvEjemplares.DataBind();
        }
    }
    protected void btnAgregarAutores_Click(object sender, ImageClickEventArgs e)
    {
        if (Session[HelpMaestros.CodigoTabla(HelpMaestros.TablasMaestras.AutoresDeItems)] != null)
        {
            List<TDetalle> Lista = (List<TDetalle>)Session[HelpMaestros.CodigoTabla(HelpMaestros.TablasMaestras.AutoresDeItems)];
            List<TDetalle> ListaOrder = Lista.OrderBy(x => x.Nombre).ToList<TDetalle>();
            ltbAutores.DataSource = ListaOrder;
            ltbAutores.DataTextField = "Nombre";
            ltbAutores.DataValueField = "CodArgu";
            ltbAutores.DataBind();
            Session[HelpMaestros.CodigoTabla(HelpMaestros.TablasMaestras.AutoresDeItems)] = ListaOrder;
        }
    }
    protected void btnAgregarTemas_Click(object sender, ImageClickEventArgs e)
    {
        if (Session[HelpMaestros.CodigoTabla(HelpMaestros.TablasMaestras.TiposDeTemas)] != null)
        {
            List<TDetalle> Lista = (List<TDetalle>)Session[HelpMaestros.CodigoTabla(HelpMaestros.TablasMaestras.TiposDeTemas)];
            List<TDetalle> ListaOrder = Lista.OrderBy(x => x.Nombre).ToList<TDetalle>();
            ltbTemas.DataSource = ListaOrder;
            ltbTemas.DataTextField = "Nombre";
            ltbTemas.DataValueField = "CodArgu";
            ltbTemas.DataBind();
            Session[HelpMaestros.CodigoTabla(HelpMaestros.TablasMaestras.TiposDeTemas)] = ListaOrder;
        }
    }
    protected void btnAgregarAutoresInstitucionales_Click(object sender, ImageClickEventArgs e)
    {
        if (Session[HelpMaestros.CodigoTabla(HelpMaestros.TablasMaestras.AutoresDeItemsInstitucionales)] != null)
        {
            List<TDetalle> Lista = (List<TDetalle>)Session[HelpMaestros.CodigoTabla(HelpMaestros.TablasMaestras.AutoresDeItemsInstitucionales)];
            List<TDetalle> ListaOrder = Lista.OrderBy(x => x.Nombre).ToList<TDetalle>();
            ltbAutoresInstitucionales.DataSource = ListaOrder;
            ltbAutoresInstitucionales.DataTextField = "Nombre";
            ltbAutoresInstitucionales.DataValueField = "CodArgu";
            ltbAutoresInstitucionales.DataBind();
            Session[HelpMaestros.CodigoTabla(HelpMaestros.TablasMaestras.AutoresDeItemsInstitucionales)] = ListaOrder;
        }

    }
    protected void btnAgregarActores_Click(object sender, ImageClickEventArgs e)
    {
        if (Session[HelpMaestros.CodigoTabla(HelpMaestros.TablasMaestras.ActoresDeObras)] != null)
        {
            List<TDetalle> Lista = (List<TDetalle>)Session[HelpMaestros.CodigoTabla(HelpMaestros.TablasMaestras.ActoresDeObras)];
            List<TDetalle> ListaOrder = Lista.OrderBy(x => x.Nombre).ToList<TDetalle>();
            ltbActores.DataSource = ListaOrder;
            ltbActores.DataTextField = "Nombre";
            ltbActores.DataValueField = "CodArgu";
            ltbActores.DataBind();
            Session[HelpMaestros.CodigoTabla(HelpMaestros.TablasMaestras.ActoresDeObras)] = ListaOrder;
        }

    }
    protected void gvEjemplares_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvEjemplares.PageIndex = e.NewPageIndex;
        if (hfEvento.Value == HelpEvento.Registrar.ToString())
            gvEjemplares.DataSource = (List<ItemEjemplar>)Session["Ejemplares"];
        else
            gvEjemplares.DataSource = EjemplaresDelSAC();
        gvEjemplares.DataBind();
    }

    private List<ItemEjemplar> EjemplaresDelSAC()
    {
        List<ItemEjemplar> LISTA = new List<ItemEjemplar>();
        List<ItemEjemplar> NewLista = new List<ItemEjemplar>();
        LISTA = (List<ItemEjemplar>)Session["Ejemplares"];
        if (hfCodSAC.Value.Trim() != string.Empty)
        {
            var lista = from item in LISTA
                        where item.sCodSac == hfCodSAC.Value
                        select item;
            NewLista = lista.ToList<ItemEjemplar>();
        }
        else
        {
            NewLista = LISTA;
        }

        return NewLista;
    }

    #endregion






}
