using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using System.Reflection;
using RealtAutomationProject.Shared;

namespace RealtAutomationProject.API
{
    public class FrameworkClient
    {

    private RestClient client;
    protected static Logger Log => new Logger(MethodBase.GetCurrentMethod().DeclaringType);

    public FrameworkClient()
    {
      client = new RestClient();
      client.BaseUrl = new Uri(Configuration.GetConfigurationVariable("BaseUrl"));
      Log.Info("FrameworkClient created");
    }

    public IRestResponse<T> Execute<T>(CustomRestRequest request) where T : new()
    {
      Log.Info("Trying to get responce");
      var response = client.Execute<T>(request.Build());    

      if (response.ErrorException != null)
      {
        const string message = "Error retrieving response.  Check inner details for more info.";
        var twilioException = new ApplicationException(message, response.ErrorException);
        Log.Error(message);
        throw twilioException;
      }
      return response;
    }
  }
}
