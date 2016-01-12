using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class Controles_BotonesEdicionLista : System.Web.UI.UserControl
{
    public event EventHandler OnBotonNuevoClick;
    public event EventHandler OnBotonImprimirClick;
    public event EventHandler OnBotonExportarClick;
    public event EventHandler OnBotonBuscarClick;
    public event EventHandler OnBotonRegresarClick;

    public bool BotonNuevo = true;
    public bool BotonImprimir = false;
    public bool BotonExportar = false;
    public bool BotonBuscar = true;
    public bool BotonRegresar = true;

    public bool BotonNuevoEnabled
    {
        set
        {
            if (value)
            {
                btnAgregar.ImageUrl = "~/Comun/Imagenes/Botones/Nuevo_A.jpg";
                btnAgregar.CssClass = "cursorHabilitado";
            }
            else
            {
                btnAgregar.ImageUrl = "~/Comun/Imagenes/Botones/Nuevo_I.jpg";
                btnAgregar.CssClass = "cursoDeshabilitado";
            }
            btnAgregar.Enabled = value;
        }
    }
    public bool BotonImprimirEnabled
    {
        set
        {
            if (value)
            {
                btnImprimir.ImageUrl = "~/Comun/Imagenes/Botones/Imprimir_A.jpg";
                btnImprimir.CssClass = "cursorHabilitado";
            }
            else
            {
                btnImprimir.ImageUrl = "~/Comun/Imagenes/Botones/Imprimir_I.jpg";
                btnImprimir.CssClass = "cursoDeshabilitado";
            }
            btnImprimir.Enabled = value;
        }
    }
    public bool BotonExportarEnabled
    {
        set
        {
            if (value)
            {
                btnExportar.ImageUrl = "~/Comun/Imagenes/Botones/Exportar_A.jpg";
                btnExportar.CssClass = "cursorHabilitado";
            }
            else
            {
                btnExportar.ImageUrl = "~/Comun/Imagenes/Botones/Exportar_I.jpg";
                btnExportar.CssClass = "cursoDeshabilitado";
            }
            btnExportar.Enabled = value;
        }
    }
    public bool BotonBuscarEnabled
    {
        set
        {
            if (value)
            {
                btnBuscar.ImageUrl = "~/Comun/Imagenes/Botones/Buscar_A.jpg";
                btnBuscar.CssClass = "cursorHabilitado";
            }
            else
            {
                btnBuscar.ImageUrl = "~/Comun/Imagenes/Botones/Buscar_I.jpg";
                btnBuscar.CssClass = "cursoDeshabilitado";
            }
            btnBuscar.Enabled = value;
        }
    }
    public bool BotonRegresarEnabled
    {
        set
        {
            if (value)
            {
                btnRegresar.ImageUrl = "~/Comun/Imagenes/Botones/Regresar_A.jpg";
                btnRegresar.CssClass = "cursorHabilitado";
            }
            else
            {
                btnRegresar.ImageUrl = "~/Comun/Imagenes/Botones/Regresar_I.jpg";
                btnRegresar.CssClass = "cursoDeshabilitado";
            }
            btnRegresar.Enabled = value;
        }
    }
    public void LoadComplete()
    {
        btnAgregar.Visible = BotonNuevo;
        btnImprimir.Visible = BotonImprimir;
        btnExportar.Visible = BotonExportar;
        btnBuscar.Visible = BotonBuscar;
        btnRegresar.Visible = BotonRegresar;

    }
    protected void Page_Load(object sender, EventArgs e)
    {
        btnAgregar.Visible = BotonNuevo;
        btnImprimir.Visible = BotonImprimir; 
        btnExportar.Visible = BotonExportar;
        btnBuscar.Visible = BotonBuscar;
        btnRegresar.Visible = BotonRegresar;
        btnBuscar.Focus();
      
    }
    protected void btnAgregar_Click(object sender, ImageClickEventArgs e)
    {
        if (e != null)
        {
            OnBotonNuevoClick(sender, e);
        }
    }
    protected void btnImprimir_Click(object sender, ImageClickEventArgs e)
    {
        if (e != null)
        {
            OnBotonImprimirClick(sender, e);
        }
    }
    protected void btnExportar_Click(object sender, ImageClickEventArgs e)
    {
        if (e != null)
        {
            OnBotonExportarClick(sender, e);
        }
    }
    protected void btnBuscar_Click(object sender, ImageClickEventArgs e)
    {
        if (e != null)
        {
            OnBotonBuscarClick(sender, e);
        }
    }
    protected void btnRegresar_Click(object sender, ImageClickEventArgs e)
    {
        if (e != null)
        {
            OnBotonRegresarClick(sender, e);
        }
    }
}
