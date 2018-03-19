using System;
using System.Linq;
using NLog;

namespace RealtAutomationProject.Shared
{
  public class Logger
  {
    private readonly ILogger logger;

    public Logger(Type type)
    {
      logger = LogManager.GetLogger(type.Name);
    }

    public void Trace(string message, params object[] parameters)
    {
      logger.Trace(GetFormattedMessage(message, parameters));
    }

    public void Debug(string message, params object[] parameters)
    {
      logger.Debug(GetFormattedMessage(message, parameters));
    }

    public void Info(string message, params object[] parameters)
    {
      logger.Info(GetFormattedMessage(message, parameters));
    }

    public void Warn(string message, params object[] parameters)
    {
      logger.Warn(GetFormattedMessage(message, parameters));
    }

    public void Error(string message, params object[] parameters)
    {
      logger.Error(GetFormattedMessage(message, parameters));
    }

    public void Fatal(string message, params object[] parameters)
    {
      logger.Fatal(GetFormattedMessage(message, parameters));
    }

    private static string GetFormattedMessage(string message, params object[] parameters)
    {
      if (parameters != null && parameters.Any())
      {
        message = string.Format(message, parameters);
      }
      return message;
    }
  }
}