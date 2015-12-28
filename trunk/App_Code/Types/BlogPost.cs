
/// <summary>
/// Summary description for BlogPost
/// </summary>
/// 
[System.Xml.Serialization.XmlRoot("post", IsNullable=false)]
public class BlogPost
{
    private string _ID;
    private string _Title;
    private string _Created;
    private string _CreatedBy;
    private string _Text;

	public BlogPost()
	{
		//
		// TODO: Add constructor logic here
		//       
	}
    [System.Xml.Serialization.XmlElement("id", DataType="string")]
    public string ID
    {
        get { return _ID; }
        set { _ID = value; }
    }
    [System.Xml.Serialization.XmlElement("title", DataType = "string")]
    public string Title
    {
        get { return _Title; }
        set { _Title = value; }
    }
    [System.Xml.Serialization.XmlElement("date", DataType = "string")]
    public string Created
    {
        get { return _Created; }
        set { _Created = value; }
    }
    [System.Xml.Serialization.XmlElement("userid", DataType = "string")]
    public string CreatedBy
    {
        get { return _CreatedBy; }
        set { _CreatedBy = value; }
    }
    [System.Xml.Serialization.XmlElement("text", DataType = "string")]
    public string Text
    {
        get { return _Text; }
        set { _Text = value; }
    }
}
