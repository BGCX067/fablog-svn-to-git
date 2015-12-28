/// <summary>
/// Summary description for TypeSerialization
/// </summary>
public class TypeSerialization
{
	public TypeSerialization()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    //Take generic collection of BlogPost objects and serialize them
    public string SerializeGenericObject(object serializableObject)
    {
        try
        {
            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(serializableObject.GetType());
            System.IO.MemoryStream buffer = new System.IO.MemoryStream();
            serializer.Serialize((System.IO.Stream)buffer, System.Runtime.CompilerServices.RuntimeHelpers.GetObjectValue(serializableObject));
            buffer.Seek(0, System.IO.SeekOrigin.Begin);
            System.IO.TextReader reader = new System.IO.StreamReader(buffer);
            System.Text.StringBuilder builder = new System.Text.StringBuilder((int)buffer.Length);
            builder.Append(reader.ReadToEnd());
            return builder.ToString();
        }
        catch
        {

        }
        return System.String.Empty;
    }

    //Converts the XML string into a generic collection of BlogPost objects
    public System.Collections.Generic.List<BlogPost> DeSerializePosts(string objectSerialized)
    {
        System.Collections.Generic.List<BlogPost> deSerializedPosts;
        try
        {
            byte[] b = System.Text.Encoding.Default.GetBytes(objectSerialized);
            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(System.Collections.Generic.List<BlogPost>));
            System.IO.MemoryStream ms = new System.IO.MemoryStream(b);
            deSerializedPosts = (System.Collections.Generic.List<BlogPost>)serializer.Deserialize(ms);
        }
        catch (System.Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex.Message);
            System.Diagnostics.Debug.WriteLine(ex.StackTrace);
            throw;
        }
        return deSerializedPosts;
    }
}
