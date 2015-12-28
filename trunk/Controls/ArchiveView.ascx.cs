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

public partial class Controls_ArchiveView : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        URLPathUtility upu = new URLPathUtility();
        System.Text.StringBuilder builder = new System.Text.StringBuilder();
        PostBroker pb = new PostBroker();        
        builder.Append("<p>");
        foreach (string dt in pb.GetAllDaysWithPosts())
        {
            builder.Append("<a href=\"" + upu.GetNavigableAppPath() + "Default.aspx?RequestedDate=");
            builder.Append(dt);
            builder.Append("\">");
            builder.Append(DateTime.Parse(dt).ToLongDateString());
            builder.Append("</a>");
            builder.Append("<br />");
        }
        builder.Append("</p>");
        Literal1.Text = builder.ToString();
    }
}
