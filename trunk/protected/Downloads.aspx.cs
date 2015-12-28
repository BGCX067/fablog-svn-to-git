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
using System.IO;
using System.Text;

public partial class Downloads : System.Web.UI.Page
{
    string downloadDir = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        System.Configuration.AppSettingsReader reader = new AppSettingsReader();
        downloadDir = (string)reader.GetValue("downloadPath", downloadDir.GetType());
        string downloadPath = Server.MapPath(downloadDir);
        StringBuilder litBuilder = new StringBuilder();
        DirectoryInfo dir = new DirectoryInfo(downloadPath);
        FileInfo[] filesInDir = dir.GetFiles("*.*");
        URLPathUtility upu = new URLPathUtility();
        litBuilder.Append("<table width=\"99%\" border=\"0\" cellpadding=\"2\">");
        int itemCount = 0;
        int totFiles = GetFileNames(downloadPath).Count;
        foreach (FileInfo f in filesInDir)
        {
            if (itemCount == 0)
            {
                litBuilder.Append("<tr>");
            }
            litBuilder.Append("<td width=\"20%\" align=\"center\" valign=\"top\">");
            litBuilder.Append("<br />");
            litBuilder.Append("<a href=\"");
            litBuilder.Append(upu.GetNavigableAppPath() + "protected/" + downloadDir + "/");
            litBuilder.Append(f.Name);
            litBuilder.Append("\">");
            litBuilder.Append("<img src=\"");
            litBuilder.Append(upu.GetNavigableAppPath() + GetImageForExtension(f.Extension));
            litBuilder.Append("\"/>");
            litBuilder.Append("<br />");
            litBuilder.Append(f.Name);
            litBuilder.Append("</a>");
            litBuilder.Append("<br />");
            litBuilder.Append("</td>");
            itemCount++;
            if (itemCount >= 4)
            {
                litBuilder.Append("</tr>");
                itemCount = 0;
            }
        }
        if (itemCount > 0)
        {
            litBuilder.Append("</tr>");
        }
        litBuilder.Append("</table>");
        Literal1.Text = litBuilder.ToString();
    }

    private ArrayList GetFileNames(string currentDir)
    {
        ArrayList fileList = new ArrayList();
        DirectoryInfo di = new DirectoryInfo(currentDir);
        di.Refresh();
        foreach (string fileName in Directory.GetFiles(currentDir))
        {
            fileList.Add(Path.GetFileName(fileName));
        }
        return fileList;
    }

    private string GetFileExtension(string currentFile)
    {
        return "nada";
    }

    private string GetImageForExtension(string fileExtension)
    {
        AppSettingsReader reader = new AppSettingsReader();
        string value = string.Empty;
        try
        {
            return (String)reader.GetValue(fileExtension, value.GetType());
        }
        catch
        {
            return "images/unknown.jpg";
        }
    }
}
    
