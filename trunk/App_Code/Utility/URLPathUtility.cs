/// <summary>
/// Summary description for URLPathUtility
/// </summary>
public class URLPathUtility
{
	public URLPathUtility()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public string GetNavigableAppPath()
    {
        return System.Web.HttpContext.Current.Request.ApplicationPath == "/" ?
            System.Web.HttpContext.Current.Request.ApplicationPath : 
            System.Web.HttpContext.Current.Request.ApplicationPath + "/";
    }
}
