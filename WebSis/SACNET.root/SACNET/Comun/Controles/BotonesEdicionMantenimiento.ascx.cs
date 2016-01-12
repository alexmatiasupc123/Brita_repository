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

public partial class Controles_BotonEdicionMantenimiento : System.Web.UI.UserControl
{
    public event EventHandler OnBotonNuevoClick;
    public event EventHandler OnBotonEditarClick;
    public event EventHandler OnBotonGrabarClick;
    public event EventHandler OnBotonCancelarClick;
    public event EventHandler OnBotonRegresarClick;

    public bool BotonNuevo = true;
    public bool BotonEditar = true;
    public bool BotonGrabar = true;
    public bool BotonCancelar = false;
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
    public bool BotonEditarEnabled
    {
        set
        {
            if (value)
            {
                btnEditar.ImageUrl = "~/Comun/Imagenes/Botones/Modificar_A.jpg";
                btnEditar.CssClass = "cursorHabilitado";
            }
            else
            {
                btnEditar.ImageUrl = "~/Comun/Imagenes/Botones/Modificar_I.jpg";
                btnEditar.CssClass = "cursoDeshabilitado";
            }
            btnEditar.Enabled = value;
        }
    }
    public bool BotonGrabarEnabled
    {
        set
        {
            if (value)
            {
                btnGrabar.ImageUrl = "~/Comun/Imagenes/Botones/Grabar_A.jpg";
                btnGrabar.CssClass = "cursorHabilitado";
            }
            else
            {
                btnGrabar.ImageUrl = "~/Comun/Imagenes/Botones/Grabar_I.jpg";
                btnGrabar.CssClass = "cursoDeshabilitado";
            }
            btnGrabar.Enabled = value;
        }
    }
    public bool BotonCancelarEnabled
    {
        set
        {
            if (value)
            {
                btnCancelar.ImageUrl = "~/Comun/Imagenes/Botones/Cancelar_A.jpg";
                btnCancelar.CssClass = "cursorHabilitado";
            }
            else
            {
                btnCancelar.ImageUrl = "~/Comun/Imagenes/Botones/Cancelar_I.jpg";
                btnCancelar.CssClass = "cursoDeshabilitado";
            }
            btnCancelar.Enabled = value;
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
    
    public enum Evento
    {
        GuardarEditar,
        GuardarNuevo,
        Nuevo,
        Editar,
        Ver
       
    }

    public void EstadoBoton(Evento pEvento)
    {
        switch (pEvento)
        {
            case Evento.GuardarEditar:
                BotonNuevoEnabled = true;
                BotonEditarEnabled = true;
                BotonGrabarEnabled = false;
                BotonCancelarEnabled = false;
                BotonRegresarEnabled = true;
                break;
            case Evento.GuardarNuevo:
                BotonNuevoEnabled = true;
                BotonEditarEnabled = true;
                BotonGrabarEnabled = false;
                BotonCancelarEnabled = false;
                BotonRegresarEnabled = true;
                break;
            case Evento.Nuevo:
                BotonNuevoEnabled = false;
                BotonEditarEnabled = false;
                BotonGrabarEnabled = true;
                BotonCancelarEnabled = true;
                BotonRegresarEnabled = true; //false
                break;
            case Evento.Editar:
                BotonNuevoEnabled = true;
                BotonEditarEnabled = false;
                BotonGrabarEnabled = true;
                BotonCancelarEnabled = true;
                BotonRegresarEnabled = true; //false
                break;
            case Evento.Ver:
                BotonNuevoEnabled = false;
                BotonEditarEnabled = false;
                BotonGrabarEnabled = false;
                BotonCancelarEnabled = false;
                BotonRegresarEnabled = true;
                break;
        }
    }

    public void LoadComplete()
    {
        btnAgregar.Visible = BotonNuevo;
        btnEditar.Visible = BotonEditar;
        btnGrabar.Visible = BotonGrabar;
        btnCancelar.Visible = BotonCancelar;
        btnRegresar.Visible = BotonRegresar;
      
    }
    
    protected void Page_Load(object sender, EventArgs e)
    {
            btnAgregar.Visible =  BotonNuevo;
            btnEditar.Visible = BotonEditar;
            btnGrabar.Visible = BotonGrabar;
            btnCancelar.Visible = BotonCancelar;
            btnRegresar.Visible = BotonRegresar;
    }
    
    protected void btnAgregar_Click(object sender, ImageClickEventArgs e)
    {
        if (e != null)
        {
            OnBotonNuevoClick(sender, e);
            EstadoBoton(Evento.Nuevo);

        }
    }
    protected void btnEditar_Click(object sender, ImageClickEventArgs e)
    {
        if (e != null)
        {
            OnBotonEditarClick(sender, e);
            //EstadoBoton(Evento.Editar);
        }
    }
    protected void btnGrabar_Click(object sender, ImageClickEventArgs e)
    {
        if (e != null)
        {
            OnBotonGrabarClick(sender, e);

        }
    }
    protected void btnCancelar_Click(object sender, ImageClickEventArgs e)
    {
        if (e != null)
        {
            OnBotonCancelarClick(sender, e);


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
