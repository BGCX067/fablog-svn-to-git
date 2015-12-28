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

public partial class DeletePost : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!String.IsNullOrEmpty(Request.QueryString["postID"]))
        {
            string postID = Request.QueryString["postId"].Replace(".xml", String.Empty);
            PostBroker broker = new PostBroker();
            broker.DeletePostByID(postID);
            Response.Redirect("Default.aspx");
        }
    }
}
