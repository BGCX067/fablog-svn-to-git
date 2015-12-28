using System;
/// <summary>
/// Summary description for XMLIOHandler
/// </summary>
public class XMLIOHandler
{
    string dataPath = string.Empty;
	public XMLIOHandler()
	{
        try
        {
            System.Configuration.AppSettingsReader reader = new System.Configuration.AppSettingsReader();
            //dataPath = (string)reader.GetValue("dataPath", dataPath.GetType());
            dataPath = System.Web.HttpContext.Current.Server.MapPath("~/App_Data");
            //System.Web.HttpContext.Current.Server.MapPath(dataPath);
        }
        catch
        {
            dataPath = "~/App_Data";
        }
	}

    //Gets the xml string from passed XML file
    public string GetXMLString(string xmlFileName)
    {
        string ret;
        try
        {            
            System.IO.StreamReader reader = new System.IO.StreamReader(dataPath + "\\" + xmlFileName);
            ret = reader.ReadToEnd();
            reader.Close();
            return ret;
        }
        catch (System.Exception ex)
        {
        }
        return System.String.Empty;
    }

    public void WriteXML(string objectXML, string xmlFileName)
    {        
        objectXML = objectXML.Replace("&lt;![CDATA", "<![CDATA");
        objectXML = objectXML.Replace("]]&gt;", "]]>");
        System.IO.StreamWriter writer = System.IO.File.CreateText(dataPath + "\\" + xmlFileName);
        writer.Write(objectXML);
        writer.Close();
    }

    //Delete the passed XML file
    public void RmDataFile(string xmlFileName)
    {                
        foreach (System.String currentFileName in System.IO.Directory.GetFiles(dataPath))
        {
            if (currentFileName == dataPath + "\\" + xmlFileName)
            {
                System.IO.File.Delete(currentFileName);
            }
        }
    }
}
