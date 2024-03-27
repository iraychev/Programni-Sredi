﻿using Microsoft.Extensions.Logging;
using WelcomeExtended.Loggers;

namespace WelcomeExtended.Helpers
{
    internal static class LoggerHelper
    {
        public static ILogger GetLogger(string categoryName)
        {
            var loggerFactory = new LoggerFactory();
            loggerFactory.AddProvider(new LoggerProvider());

            return loggerFactory.CreateLogger(categoryName);
        }

    }
}
