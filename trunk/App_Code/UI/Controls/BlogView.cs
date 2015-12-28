/// <summary>
/// Summary description for BlogView
/// </summary>
namespace FABlog.Controls
{
    public class BlogView : System.Web.UI.Control
    {
        public BlogView()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        protected override void Render(System.Web.UI.HtmlTextWriter writer)
        {
            System.Text.StringBuilder builder = new System.Text.StringBuilder();

            if (!System.String.IsNullOrEmpty((string)System.Web.HttpContext.Current.Session["LoggedOnUser"]))
            {
                builder.Append("<p>Welcome ");
                builder.Append((string)System.Web.HttpContext.Current.Session["LoggedOnUser"]);
                builder.Append("</p>");
                builder.Append("<p><a href=\"Logout.aspx\">Logout</a></p>");
             }
            else
            {                
                builder.Append("<p>Welcome Guest</p>");
                builder.Append("<p><a href=\"Login.aspx\">Login</a></p>");                
            }
            PostBroker postRetrieval = new PostBroker();            
            foreach (BlogPost post in postRetrieval.GetMainPagePosts())
            {
                builder.Append("<h1>").Append(post.Title).Append("</h1>");
                builder.Append("<p>");
                builder.Append(System.Web.HttpContext.Current.Server.HtmlDecode(post.Text));
                builder.Append("</p>");
                builder.Append("<br />");
                if (!System.String.IsNullOrEmpty((string)System.Web.HttpContext.Current.Session["LoggedOnUser"]) && post.CreatedBy == (string)System.Web.HttpContext.Current.Session["LoggedOnUser"])
                {
                    builder.Append("<p><a href=\"CreatePost.aspx?postID=");
                    builder.Append(post.ID.Replace(".xml", System.String.Empty));
                    builder.Append("\">Edit</a>");
                    builder.Append("&nbsp&nbsp");
                    builder.Append("<a href=\"");
                    builder.Append(System.Web.HttpContext.Current.Request.ApplicationPath.ToString());
                    builder.Append("/DeletePost.aspx?postID=");
                    builder.Append(post.ID.Replace(".xml", System.String.Empty));
                    builder.Append("\">Delete</a></p>");
                }
            }
            writer.Write(builder.ToString());
            base.Render(writer);
        }
    }
}