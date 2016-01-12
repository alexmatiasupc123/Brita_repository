using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for redes_sociales
/// </summary>
public static class redes_sociales
{
    public static string facebook_centro_cultural {
        get {
            return ConfigurationManager.AppSettings["facebook_centro_cultural"].ToString();
        }
    }
    public static string facebook_teatro {
        get {
            return ConfigurationManager.AppSettings["facebook_teatro"].ToString();
        }
    }

    public static string btn_recomendar {
        get {
            string btn = "<iframe src='http://www.facebook.com/plugins/like.php?locale=es_PE&href=" + HttpContext.Current.Request.Url.AbsoluteUri + "&amp;layout=button_count&amp;show_faces=false&amp;width=130&amp;action=recommend&amp;font&amp;colorscheme=light&amp;height=21' scrolling='no' frameborder='0' style='border:none; overflow:hidden; width:130px; height:21px;' allowTransparency='true'></iframe>";
            return btn.Replace("'",Convert.ToChar(34).ToString());
        }
    }
    public static string btn_recomendar_id(string id)
    {
            string url = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Path);
            string btn = "<iframe src='http://www.facebook.com/plugins/like.php?locale=es_PE&href=" + url + "?id=" + id + "&amp;layout=button_count&amp;show_faces=false&amp;width=130&amp;action=recommend&amp;font&amp;colorscheme=light&amp;height=21' scrolling='no' frameborder='0' style='border:none; overflow:hidden; width:130px; height:21px;' allowTransparency='true'></iframe>";
            return btn.Replace("'", Convert.ToChar(34).ToString());
        
    }
    public static string btn_megusta
    {
        get
        {
            string btn = "<iframe src='http://www.facebook.com/plugins/like.php?href=" + HttpContext.Current.Request.Url.AbsoluteUri + "&amp;layout=button_count&amp;show_faces=false&amp;width=112&amp;action=like&amp;font&amp;colorscheme=light&amp;height=21;locale=es_PE' scrolling='no' frameborder='0' style='border:none; overflow:hidden; width:112px; height:21px;' allowTransparency='true'></iframe>";
            return btn.Replace("'", Convert.ToChar(34).ToString());
        }
    }
    public static string btn_megusta_id(string id)
    {
        string url = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Path);
        string btn = "<iframe src='http://www.facebook.com/plugins/like.php?href=" + url + "?id=" + id + "&amp;layout=button_count&amp;show_faces=false&amp;width=112&amp;action=like&amp;font&amp;colorscheme=light&amp;height=21;locale=es_PE' scrolling='no' frameborder='0' style='border:none; overflow:hidden; width:112px; height:21px;' allowTransparency='true'></iframe>";
        return btn.Replace("'", Convert.ToChar(34).ToString());
        
    }
    public static string btn_publicar(string url,string title)
    {
            string script = "<script>function fbs_click() {u='"+url+"';t='"+title+"';window.open('http://www.facebook.com/sharer.php?u='+encodeURIComponent(u)+'&t='+encodeURIComponent(t),'sharer','toolbar=0,status=0,width=626,height=436');return false;}</script>";
            string btn = "<a rel='nofollow' href='http://www.facebook.com/share.php?u=<;url>' onclick='return fbs_click()' target='_blank' class='facebook_button'>Publicar</a>";
            return script + btn.Replace("'", Convert.ToChar(34).ToString());
    }
    public static string btn_compartir
    {
        get
        {
            string btn = "<div class='addthis_toolbox addthis_default_style' style='z-index:5000;'><a href='http://www.addthis.com/bookmark.php?v=250&amp;pubid=ra-4d7791d1335fee2b' class='compartir_button addthis_button'>Compartir</a></div>";
            string script = "<script type='text/javascript'>var addthis_config = {'data_track_clickback':true};</script><script type='text/javascript' src='http://s7.addthis.com/js/250/addthis_widget.js#pubid=ra-4d7791d1335fee2b'></script>";
            return btn.Replace("'", Convert.ToChar(34).ToString()) + script.Replace("'", Convert.ToChar(34).ToString());
        }
    }

    public static string btn_teatro_britanico {
        get {
            string btn = "<div style='font-family:Tahoma;color:#bcbabb;'><span style='font-size:10px;display:block;float:left;'>Síguenos: &nbsp;</span><a href='"+ redes_sociales.facebook_teatro +"' target='_blank' style='background:url(App_themes/Imagenes/facebook_share_icon.png) no-repeat center left; display:block;float:left;width:150px;height:15px;text-indent:23px;font-family: Tahoma;font-size:11px;color:#bcbabb; text-decoration:none;'><b>TEATRO BRITANICO</b></a></div>";
            return btn.Replace("'", Convert.ToChar(34).ToString());
        }
    }
}
