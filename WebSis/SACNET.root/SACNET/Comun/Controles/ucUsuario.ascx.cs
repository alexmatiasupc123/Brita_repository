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
using System.Collections.Generic;

using Britanico.SacNet.BusinessEntities;
using Britanico.SacNet.BusinessLogic;
using Oxinet.Tools;
using System.Drawing;

public partial class Comun_Controles_ucUsuario : System.Web.UI.UserControl
{
    public string prm_CodUsuarioSAC;
    public DateTime prm_FechaFinalClases;
    public string prm_Sabado;

    public void CargarDatosDeUsuarioSAC()
    {
        if (prm_CodUsuarioSAC != null)
        {
            if (prm_CodUsuarioSAC.Length > 0)
            {
                HF_CodUsuarioSAC.Value = prm_CodUsuarioSAC;
                vwUsuariosSAC itemvwUsuariosSAC = new vwUsuariosSAC();
                vwDatosVistaLogic ovwDatosVistaLogic = new vwDatosVistaLogic();
                itemvwUsuariosSAC = ovwDatosVistaLogic.Buscarvw_UsuariosSAC(HF_CodUsuarioSAC.Value);
                if (itemvwUsuariosSAC.CodUsuarioSAC != null)
                {
                    TextBoxNombresApellidos.Text = itemvwUsuariosSAC.ApellidosNombres;
                    TextBoxCodSAC.Text = itemvwUsuariosSAC.CodLocalSAC;
                    TextBoxNomSAC.Text = itemvwUsuariosSAC.CodLocalSACNombre;
                    //ELVP:11-10-2011******************
                    if (itemvwUsuariosSAC.EsAlumno == "A")
                        labelTipoPersona.Text = "Alumno";
                    else if (itemvwUsuariosSAC.EsAlumno == "P")
                        labelTipoPersona.Text = "Profesor";
                    else
                        labelTipoPersona.Text = "Empleado";
                    //if (itemvwUsuariosSAC.EsAlumno)
                    //    labelTipoPersona.Text = "Alumno";
                    //else
                    //    labelTipoPersona.Text = "Profesor";
                    //*********************************

                    BuscarCursosAlumno();
                    BuscarMovimientos();
                    MostrarFotografia(HF_CodUsuarioSAC.Value);
                }
                else
                {
                    TextBoxNombresApellidos.Text = string.Empty;
                    TextBoxCodSAC.Text = string.Empty;
                    TextBoxNomSAC.Text = string.Empty;
                    gvvwCursosUsuarioSAC.DataSource = null;
                    gvvwCursosUsuarioSAC.DataBind();
                    gvMovimientos.DataSource = null;
                    gvMovimientos.DataBind();
                    MostrarFotografia(HelpConfiguration.AppSettings(HelpConfiguration.AppSett.Default_NameImagenUsuario));
                }
            }
        }
        else
        {
            TextBoxNombresApellidos.Text = string.Empty;
            TextBoxCodSAC.Text = string.Empty;
            TextBoxNomSAC.Text = string.Empty;
            gvvwCursosUsuarioSAC.DataSource = null;
            gvvwCursosUsuarioSAC.DataBind();
            gvMovimientos.DataSource = null;
            gvMovimientos.DataBind();
            MostrarFotografia(HelpConfiguration.AppSettings(HelpConfiguration.AppSett.Default_NameImagenUsuario));
        }
    }

    private void BuscarCursosAlumno()
    {
        vwDatosVistaLogic ovwDatosVistaLogic = new vwDatosVistaLogic();
        List<vwCursosUsuarioSAC> listavwCursosUsuarioSAC = new List<vwCursosUsuarioSAC>();
        listavwCursosUsuarioSAC = ovwDatosVistaLogic.ListarvwCursosUsuarioSAC(HF_CodUsuarioSAC.Value);
        if (listavwCursosUsuarioSAC.Count > 0)
        {
            DateTime FechaBucle = Convert.ToDateTime(listavwCursosUsuarioSAC[0].FechaFinalCiclo);

            foreach (vwCursosUsuarioSAC xCurso in listavwCursosUsuarioSAC)
            {
                string fechaDato = HelpDates.EsFechaValida(xCurso.FechaFinalCiclo);
                if (fechaDato.Length == 0)
                {
                    if (Convert.ToDateTime(xCurso.FechaFinalCiclo) > FechaBucle)
                        FechaBucle = Convert.ToDateTime(xCurso.FechaFinalCiclo);
                }
            }
            prm_FechaFinalClases = FechaBucle;
            prm_Sabado = listavwCursosUsuarioSAC[0].Sabado;
        }

        gvvwCursosUsuarioSAC.DataSource = HelpConvert<vwCursosUsuarioSAC>.ConvertList(listavwCursosUsuarioSAC);
        gvvwCursosUsuarioSAC.DataBind();
        HelpGridView.Caption(ref gvvwCursosUsuarioSAC, "Lista de cursos", listavwCursosUsuarioSAC.Count.ToString());

    }

    private void BuscarMovimientos()
    {
        List<Prestamo> listaPrestamo = new List<Prestamo>();
        PrestamoLogic oPrestamoLogic = new PrestamoLogic();
        listaPrestamo = oPrestamoLogic.Listar(string.Empty, DateTime.Now.AddDays(Convert.ToDouble(HelpConfiguration.AppSettings(HelpConfiguration.AppSett.Default_DIAS_ANTES)) * -4 + (-3)), DateTime.Now, HF_CodUsuarioSAC.Value, string.Empty, string.Empty, string.Empty, null, string.Empty, null, PrestamoLogic.TipoDeOperacion.OperTodos);
        List<Prestamo> listaOrdenada;
        listaOrdenada = listaPrestamo.OrderByDescending(x => x.dFechaPrestamo).ToList();
        gvMovimientos.DataSource = HelpConvert<Prestamo>.ConvertList(listaOrdenada);
        gvMovimientos.DataBind();
        HelpGridView.Caption(ref gvMovimientos,"Últimos movimientos", listaOrdenada.Count.ToString());
    }

    public void MostrarFotografia(string CodigoUsuarioSAC)
    {
        Random Num = new Random();
        Int32 NumI;

        NumI = Convert.ToInt32(Num.Next(100));

        string DirImagen = HelpConfiguration.AppSettings(HelpConfiguration.AppSett.DirImagenUsuarioSAC);
        f_ImageUsuarioSAC.Visible = true;
        if (CodigoUsuarioSAC == HelpConfiguration.AppSettings(HelpConfiguration.AppSett.Default_NameImagenUsuario))
            f_ImageUsuarioSAC.ImageUrl = DirImagen + CodigoUsuarioSAC;
        else
        {
            string NombreArchivoGen = CodigoUsuarioSAC + ".jpg?id=" + NumI;
            f_ImageUsuarioSAC.ImageUrl = DirImagen + NombreArchivoGen;
        }
    }

    public void OcultaFotografia()
    {
        f_ImageUsuarioSAC.Visible = false;
    }

    protected void gvMovimientos_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //Label TieneConCarne = ((Label)e.Row.Cells[4].FindControl("LabelCarne"));

            DataRowView IOK = (DataRowView)e.Row.DataItem;

            //if (TieneConCarne.Text == "True")
            //{
            //    TieneConCarne.Text = "Si";
            //}
            //else
            //{
            //    TieneConCarne.Text = "No";
            //}
            e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#99CCFF';");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");

            string FechaEntR = IOK.Row[11].ToString();
            string FechaEntE = IOK.Row[10].ToString();
            Nullable<DateTime> FechaEntRe = null;
            Nullable<DateTime> FechaEntEs = null;

            if (FechaEntR != string.Empty && FechaEntE != string.Empty)
            {
                FechaEntRe = Convert.ToDateTime(Convert.ToDateTime(FechaEntR).ToShortDateString());
                FechaEntEs = Convert.ToDateTime(Convert.ToDateTime(FechaEntE).ToShortDateString());
                if (FechaEntRe > FechaEntEs)
                    e.Row.ForeColor = Color.Red;
            }
            else
            {
                if (FechaEntE != string.Empty)
                {
                    FechaEntEs = Convert.ToDateTime(Convert.ToDateTime(FechaEntE).ToShortDateString());
                    if (DateTime.Today > FechaEntEs)
                        e.Row.ForeColor = Color.Coral;
                }
            }

            //ELVP:29-09-2011
            bool bRenovacion = Convert.ToBoolean(IOK.Row["bRenovacion"].ToString());
            if (bRenovacion)
                e.Row.Cells[9].Text = "R";
        }
    }

    protected void gvMovimientos_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvMovimientos.PageIndex = e.NewPageIndex;
        BuscarMovimientos();
    }
  
    protected void gvvwCursosUsuarioSAC_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvvwCursosUsuarioSAC.PageIndex = e.NewPageIndex;
        BuscarCursosAlumno();
    }
}
