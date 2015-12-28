
/// <summary>
/// Summary description for IBlogData
/// </summary>
public interface IBlogData
{
    void InsertPost(BlogPost newPost);
    BlogPost GetPostById(string postID);
    void DeletePostByID(string postID);
    void OverWritePost(BlogPost editedPost);
    System.Collections.Generic.List<BlogPost> GetPostsForPage(int pageNumber);
    System.Collections.Generic.List<BlogPost> GetPostsForDay(System.DateTime requestedDate);
    System.Collections.Generic.List<string> GetAllDaysWithPosts();
}
