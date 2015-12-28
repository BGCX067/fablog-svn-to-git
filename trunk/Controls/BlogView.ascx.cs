using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

public partial class Controls_BlogView : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        URLPathUtility upu = new URLPathUtility();
        System.Text.StringBuilder builder = new System.Text.StringBuilder();
        PostBroker pb = new PostBroker();
        System.Collections.Generic.List<BlogPost> bpCol = new System.Collections.Generic.List<BlogPost>();        

        if (!string.IsNullOrEmpty(Request.QueryString["RequestedDate"]))
        {
            bpCol = pb.GetPostsForDay(DateTime.Parse(Request.QueryString["RequestedDate"]));
        }
        else
        {
            bpCol = pb.GetMainPagePosts();
        }

        foreach (BlogPost post in bpCol)
        {
            builder.Append("<h1>").Append(post.Title).Append("</h1>");
            builder.Append("<p>");
            builder.Append(Server.HtmlDecode(post.Text));
            builder.Append("</p>");
            builder.Append("<p>Posted by ");
            builder.Append(post.CreatedBy.ToString());
            builder.Append(" on ");
            builder.Append(DateTime.Parse(post.Created).ToString());
            builder.Append("</p>");

            if (!String.IsNullOrEmpty(Page.User.Identity.Name) && post.CreatedBy == Page.User.Identity.Name)
            {
                builder.Append("<p><a href=\"");
                builder.Append(upu.GetNavigableAppPath());
                builder.Append("protected/CreatePost.aspx?postID=");
                builder.Append(post.ID.Replace(".xml", String.Empty));
                builder.Append("\"><img src=\"images/edit.gif\"/> Edit</a>");
                builder.Append("&nbsp&nbsp");
                builder.Append("<a href=\"");
                builder.Append(upu.GetNavigableAppPath());
                builder.Append("protected/DeletePost.aspx?postID=");
                builder.Append(post.ID.Replace(".xml", String.Empty));
                builder.Append("\"><img src=\"images/trash.gif\"/> Delete</a></p>");
            }
            Literal1.Text = builder.ToString();
        }
    }
}
