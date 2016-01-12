using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;

/// <summary>
/// Summary description for funciones
/// </summary>
public static class functions
{
    
    public static bool IsInteger(string theValue)
    {
            try
            {
                Convert.ToInt32(theValue);
                return true;
            }
            catch
            {
                return false;
            }
    } //IsInteger
    public static string RemoveHTML(string source){
        source = Regex.Replace(source, "<BR>", " ");
        source = Regex.Replace(source, "<BR/>", " ");
        source = Regex.Replace(source, "<BR />", " ");
        source = Regex.Replace(source, "<br>", " ");
        source = Regex.Replace(source, "<br/>", " ");
        source = Regex.Replace(source, "<br />", " ");
        return Regex.Replace(source, "<.*?>", string.Empty);
    }
}
