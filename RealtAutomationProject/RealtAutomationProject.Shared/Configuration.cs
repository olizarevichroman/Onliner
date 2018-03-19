using System.Configuration;

namespace RealtAutomationProject.Shared
{
  public class Configuration
  {
    public static string GetConfigurationVariable(string variable)
    {
        string result = ConfigurationManager.AppSettings.Get(variable);
        return result;
    }
  }
}