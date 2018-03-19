using RealtAutomationProject.Shared;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RealtAutomationProject.API
{
  public class CustomRestRequest
  {
    protected static Logger Log => new Logger(MethodBase.GetCurrentMethod().DeclaringType);
    private RestRequest request;
    private StringBuilder requestInformation;

    public CustomRestRequest()
    {
      request = new RestRequest();
      requestInformation = new StringBuilder();
      Log.Info("Created CuctomRestRequest");
    }

    public CustomRestRequest AddParameter(string name, object value)
    {
      this.request.AddParameter(name, value);
      this.requestInformation.AppendLine($"Parameter: {name} with value {value}");
      return this;
    }

    public CustomRestRequest AddParameter(string name, object value, ParameterType type)
    {
      this.request.AddParameter(name, value, type);
      this.requestInformation.AppendLine($"Parameter: {name} with value {value} with type {type}");
      return this;
    }

    public CustomRestRequest SetResource(string resource)
    {
      this.request.Resource = resource;
      this.requestInformation.AppendLine($"Resource: {resource}");
      return this;
    }

    public CustomRestRequest SetMethod(Method method)
    {
      this.request.Method = method;
      this.requestInformation.AppendLine($"Method: {method.ToString()}");
      return this;
    }

    public RestRequest Build()
    {
      Log.Info($"Build custom request {this.ToString()}");
      return this.request;      
    }

    public override string ToString()
    {
      return $"Detailed information:\r\n{requestInformation}";
    }
  }
}
