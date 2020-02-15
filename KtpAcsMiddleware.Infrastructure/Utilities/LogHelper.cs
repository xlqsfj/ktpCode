using System;
using System.Diagnostics;
using System.IO;
using NLog;
using NLog.Config;
using NLog.Targets;

namespace KtpAcsMiddleware.Infrastructure.Utilities
{
    public class LogHelper
    {
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();

        static LogHelper()
        {
            var configFileName = AppDomain.CurrentDomain.BaseDirectory + "NLog.config";
            if (!File.Exists(configFileName))
            {
                configFileName = configFileName.Replace("\\bin", "");
                configFileName = configFileName.Replace("\\Debug", "");
                configFileName = configFileName.Replace("\\Release", "");
            }
            if (File.Exists(configFileName))
            {
                LogManager.Configuration = new XmlLoggingConfiguration(configFileName, true);
            }
            else
            {
                //Create configuration object
                var config = new LoggingConfiguration();
                //Create targets and add them to the configuration
                var fileTarget = new FileTarget();
                config.AddTarget("file", fileTarget);
                //Set target properties
                fileTarget.FileName = "${basedir}/logs/${shortdate}.log";
                fileTarget.Layout = "${longdate} ${uppercase:${level}} ${message}";
                //Define rules
                config.LoggingRules.Add(new LoggingRule("*", LogLevel.Debug, fileTarget));
                //Activate the configuration
                LogManager.Configuration = config;
            }
        }

        public static void Info(string msg)
        {
            Log.Info(msg);
        }

        public static void ExceptionLog(string msg, string methodName = null)
        {
            try
            {
                if (methodName == null)
                {
                    var stackFrame = new StackFrame(1);
                    methodName = stackFrame.GetMethod().Name;
                }
                Log.Error($"{methodName} exception,{msg}");
            }
            catch
            {
                Log.Error(msg);
            }
        }

        public static void ExceptionLog(Exception ex, string methodName = null)
        {
            try
            {
                if (methodName == null)
                {
                    var stackFrame = new StackFrame(1);
                    methodName = stackFrame.GetMethod().Name;
                }
                if (string.IsNullOrEmpty(ex.StackTrace))
                {
                    Log.Error($"{methodName} exception,Message={ex.Message}");
                    return;
                }
                Log.Error($"{methodName} exception,Message={ex.Message},StackTrace={ex.StackTrace}");
            }
            catch
            {
                Log.Error(ex);
            }
        }

        public static void ErrorLog(string erro, string methodName = null)
        {
            try
            {
                string stackTrace;
                if (methodName == null)
                {
                    var stackFrame = new StackFrame(1);
                    methodName = stackFrame.GetMethod().Name;
                    var fileName = stackFrame.GetFileName();
                    var lineNumber = stackFrame.GetFileLineNumber();
                    stackTrace = $"{methodName} ({fileName} line {lineNumber})";
                }
                else
                {
                    stackTrace = methodName;
                }
                Log.Error($"{methodName} erro,Message={erro},StackTrace={stackTrace}");
            }
            catch
            {
                Log.Error($"has erro,Message={erro}");
            }
        }

        public static void EntryLog(string userId, string viewUrl)
        {
            Info($"{userId} entry {viewUrl}");
        }
    }
}