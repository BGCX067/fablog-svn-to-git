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
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

public partial class CreatePost : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!String.IsNullOrEmpty(Request.QueryString["postID"]))
            {
                PostBroker broker = new PostBroker();
                BlogPost post = new BlogPost();
                post = broker.GetPostByID(Request.QueryString["postID"]);
                TextBox1.Text = Server.HtmlDecode(post.Title);
                FreeTextBox1.Text = Server.HtmlDecode(post.Text);
            }
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
                BlogPost bPost = new BlogPost();
        bPost.Title = TextBox1.Text;
        System.Text.StringBuilder builder = new StringBuilder();
        builder.Append("<![CDATA[");
        builder.Append(FreeTextBox1.Text);
        builder.Append("]]>");
        bPost.Text = builder.ToString();
        bPost.Created = DateTime.Now.ToString();
        if (!String.IsNullOrEmpty(Request.QueryString["postID"]))
        {
            bPost.ID = (string)Request.QueryString["postID"];
        }
        if ((!String.IsNullOrEmpty(Page.User.Identity.Name)))
        {
            bPost.CreatedBy = (string)Page.User.Identity.Name;
        }
		else
		{
		    bPost.CreatedBy = "Unknown";
		}
        PostBroker broker = new PostBroker();
        broker.InsertPost(bPost);
        URLPathUtility upu = new URLPathUtility();
        Response.Redirect(upu.GetNavigableAppPath() + "Default.aspx");
    }
}
