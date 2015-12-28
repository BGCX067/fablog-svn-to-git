
/// <summary>
/// Summary description for PostBroker
/// </summary>
public class PostBroker
{
    IBlogData bData = (IBlogData)System.Activator.CreateInstance(System.Type.GetType("XMLBlogData"));

	public PostBroker()
	{
        
	}

    public void InsertPost(BlogPost newPost)
    {
        if (!string.IsNullOrEmpty(newPost.ID))
        {
            bData.OverWritePost(newPost);
        }
        else
        {
        bData.InsertPost(newPost);
        }
    }

    public BlogPost GetPostByID(string postID)
    {
        return bData.GetPostById(postID);
    }

    public void DeletePostByID(string postID)
    {
        bData.DeletePostByID(postID);
    }

    public System.Collections.Generic.List<BlogPost> GetMainPagePosts()
    {
        //return bData.GetPostsForDay(System.DateTime.Now);
        return bData.GetPostsForPage(0);
    }

    public System.Collections.Generic.List<BlogPost> GetPostsForDay(System.DateTime requestedDate)
    {
        return bData.GetPostsForDay(requestedDate);
    }

    public System.Collections.Generic.List<string> GetAllDaysWithPosts()
    {
        return bData.GetAllDaysWithPosts();
    }
    
    //Generates an ID built off of the date and time down to the millisecond.
    //private string GeneratePostID()
    //{
    //    System.Text.StringBuilder builder = new System.Text.StringBuilder();
    //    builder.Append(System.DateTime.Now.Year.ToString());
    //    builder.Append(System.DateTime.Now.Month.ToString());
    //    builder.Append(System.DateTime.Now.Day.ToString());
    //    builder.Append(System.DateTime.Now.Hour.ToString());
    //    builder.Append(System.DateTime.Now.Minute.ToString());
    //    builder.Append(System.DateTime.Now.Second.ToString());
    //    builder.Append(System.DateTime.Now.Millisecond.ToString());
    //    //builder.Append(".xml");
    //    return builder.ToString();
    //}  //
}
