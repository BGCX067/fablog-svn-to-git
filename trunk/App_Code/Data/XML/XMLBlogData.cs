using System;

/// <summary>
/// Summary description for XMLBlogData
/// </summary>
public class XMLBlogData : IBlogData
{
    string dataPath = string.Empty;
	public XMLBlogData()
	{                
        try
        {
            System.Configuration.AppSettingsReader reader = new System.Configuration.AppSettingsReader();
            //dataPath = (string)reader.GetValue("dataPath", dataPath.GetType());
            dataPath = System.Web.HttpContext.Current.Server.MapPath("~/App_Data");
            
        }
        catch
        {
            dataPath = "~/App_Data";
        }
	}

    //Insert post into today's XML file
    public void InsertPost(BlogPost newPost)
    {
        TypeSerialization ts = new TypeSerialization();
        XMLIOHandler xio = new XMLIOHandler();        
        if (String.IsNullOrEmpty(newPost.ID))
        {
            newPost.ID = GeneratePostID();
        }
        System.Collections.Generic.List<BlogPost> newPostCol = new System.Collections.Generic.List<BlogPost>();
        newPostCol.Add(newPost);
        if (System.IO.File.Exists(dataPath + "\\" + GetOwningXMLFileName(newPost.ID)))
        {
            foreach (BlogPost oldPost in ts.DeSerializePosts(xio.GetXMLString(GetOwningXMLFileName(newPost.ID))))
            {
                newPostCol.Add(oldPost);
            }
        }
        if (System.IO.File.Exists(dataPath + GetOwningXMLFileName(newPost.ID)))
        {
            xio.RmDataFile(GetOwningXMLFileName(newPost.ID));
        }
        if (newPostCol.Count > 0)
        {
            xio.WriteXML(ts.SerializeGenericObject(newPostCol), GetOwningXMLFileName(newPost.ID));
        }
    }

    //Gets post from passed ID
    public BlogPost GetPostById(string postID)
    {
        XMLIOHandler xio = new XMLIOHandler();
        TypeSerialization ts = new TypeSerialization();
        BlogPost sorryPost = new BlogPost();
        foreach (BlogPost tempPost in ts.DeSerializePosts(xio.GetXMLString(GetOwningXMLFileName(postID))))
        {
            if (tempPost.ID == postID)
            {
                return tempPost;
            }
            else
            {
                sorryPost.Title = "Post Not Found";
                sorryPost.Text = "The post you requested was not found";
            }
        }
        return sorryPost;
    }

    //Deletes post with the ID passed.  This function reads in existing XML from owning XML file,
    //rebuilds the collection without the deleted post, deletes the owning XML file, and rewrites
    //the owning XML file with the same name.
    public void DeletePostByID(string postID)
    {
        XMLIOHandler xio = new XMLIOHandler();
        TypeSerialization ts = new TypeSerialization();
        System.Collections.Generic.List<BlogPost> newPostCol = new System.Collections.Generic.List<BlogPost>();
        foreach (BlogPost tempPost in ts.DeSerializePosts(xio.GetXMLString(GetOwningXMLFileName(postID))))
        {
            if (tempPost.ID != postID)
            {
                newPostCol.Add(tempPost);
            }
        }
        xio.RmDataFile(GetOwningXMLFileName(postID));
        if (newPostCol.Count > 0)
        {
            xio.WriteXML(ts.SerializeGenericObject(newPostCol), GetOwningXMLFileName(postID));
        }
    }

    //Handles the editing of existing posts.
    public void OverWritePost(BlogPost editedPost)
    {
        this.DeletePostByID(editedPost.ID);
        this.InsertPost(editedPost);        
    }

    public System.Collections.Generic.List<BlogPost> GetPostsForPage(int pageNumber)
    {
        XMLIOHandler xio = new XMLIOHandler();
        TypeSerialization ts = new TypeSerialization();
        System.Collections.Generic.List<BlogPost> postCol = new System.Collections.Generic.List<BlogPost>();
        foreach (string fileName in GetAllBlogFiles())
        {
            foreach (BlogPost tempPost in ts.DeSerializePosts(xio.GetXMLString(fileName)))
            {
                if (postCol.Count <= 10)
                {
                    postCol.Add(tempPost);
                }
                else
                {
                    break;
                }
            }
            if (postCol.Count >= 10)
            {
                break;
            }
        }
        return postCol;
    }

    public System.Collections.Generic.List<BlogPost> GetPostsForDay(System.DateTime requestedDate)
    {
        XMLIOHandler xio = new XMLIOHandler();
        TypeSerialization ts = new TypeSerialization();        
        System.Collections.Generic.List<BlogPost> retPosts = new System.Collections.Generic.List<BlogPost>();
        if (System.IO.File.Exists(dataPath + "\\" + GetXMLFileForDay(requestedDate)))
        {
            retPosts = ts.DeSerializePosts(xio.GetXMLString(GetXMLFileForDay(requestedDate)));
        }
        if (retPosts.Count > 0)
        {
            return retPosts;
        }
        else
        {
            return ts.DeSerializePosts(xio.GetXMLString("20070101.xml"));
        }
    }

    //Gets a collection of DateTime for the archive view
    public System.Collections.Generic.List<string> GetAllDaysWithPosts()
    {
        System.Collections.Generic.List<string> retVals = new System.Collections.Generic.List<string>();
        foreach (string s in GetAllBlogFiles())
        {
            System.Text.StringBuilder builder = new System.Text.StringBuilder();
            builder.Append(s.Substring(4, 2));
            builder.Append("/");
            builder.Append(s.Substring(6, 2));
            builder.Append("/");
            builder.Append(s.Substring(0,4));                        
            retVals.Add(builder.ToString());
        }
        return retVals;
    }

    /********************----END PUBLIC METHODS----**********************/

    //Parses the ID to get the XML file name that contains the postID
    private string GetOwningXMLFileName(string postID)
    {
        System.Text.StringBuilder builder = new System.Text.StringBuilder();
        builder.Append(postID.Substring(0, 4));
        builder.Append(postID.Substring(4, 2));
        builder.Append(postID.Substring(6, 2));
        builder.Append(".xml");
        return builder.ToString();
    }

    //This gets the name of today's XML file
    private string GetTodayXMLFile()
    {       
        System.Text.StringBuilder builder = new System.Text.StringBuilder();
        builder.Append(System.DateTime.Now.ToString("yyyyMMdd")).Append(".xml");
        return builder.ToString();
    }

    private string GetXMLFileForDay(System.DateTime dateRequested)
    {
        System.Text.StringBuilder builder = new System.Text.StringBuilder();        
        builder.Append(dateRequested.ToString("yyyyMMdd")).Append(".xml");        
        return builder.ToString();
    }

    private string GeneratePostID()
    {        
        return System.DateTime.Now.ToString("yyyyMMddHHmmssfff");
    }

    //Gets the filenames of all the files in the blogdata directory
    //Because of the stupid "20*.xml" lazy man's search pattern, this program will only function correctly 
    //until 2099.
    private System.Collections.Generic.List<string> GetAllBlogFiles()
    {                    
        System.Collections.Generic.List<string> fileNameCol = new System.Collections.Generic.List<string>();
        
        foreach (string currentFileName in System.IO.Directory.GetFileSystemEntries(dataPath, "20*.xml"))
        {          
            fileNameCol.Add(System.IO.Path.GetFileName(currentFileName));
        }
        fileNameCol.Reverse();
        return fileNameCol;
    }
}
