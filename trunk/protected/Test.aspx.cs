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

public partial class Test : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        URLPathUtility upu = new URLPathUtility();
        System.Text.StringBuilder builder = new System.Text.StringBuilder();
        foreach (string s in System.Web.HttpContext.Current.Request.ServerVariables.AllKeys)
        {
            builder.Append(s);
            builder.Append(" = ");
            builder.Append(System.Web.HttpContext.Current.Request.ServerVariables[s]);
            builder.Append("<br />");
        }
        builder.Append(System.Web.HttpContext.Current.Request.Path);
        builder.Append("<br />");
        builder.Append(System.Web.HttpContext.Current.Request.ApplicationPath);
        builder.Append("<br />");
        builder.Append(System.Web.HttpContext.Current.Server);
        builder.Append("<br />");
        builder.Append(System.Web.HttpContext.Current.Request.UserHostName);
        builder.Append("<br /><br /><br />");
        builder.Append(VirtualPathUtility.ToAbsolute(Request.ApplicationPath));
        builder.Append("<br />");
        builder.Append(VirtualPathUtility.ToAppRelative(Request.ApplicationPath));
        builder.Append("<br /><br /><br />");
        builder.Append(upu.GetNavigableAppPath());
        Literal1.Text = builder.ToString();
        
    }
}
