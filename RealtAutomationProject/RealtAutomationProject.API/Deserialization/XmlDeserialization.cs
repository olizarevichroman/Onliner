using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RealtAutomationProject.API.Deserialization
{
  public class XmlDeserialization
  {
    private static XmlDeserialization xmlDeserialization;

    private XmlDeserialization()
    {
    }

    public static XmlDeserialization Instance => xmlDeserialization ?? (xmlDeserialization = new XmlDeserialization());


    public string RootElement { get; private set; }

    public T Deserialize<T>(IRestResponse response)
    {
      if (response == null)
      {
        throw new ArgumentNullException(nameof(response));
      }

      var serializer = new XmlSerializer(typeof(T));

      using ( MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(response.Content))){
        object result = serializer.Deserialize(ms);
        return (T)result;
      }
    }
  }
}
