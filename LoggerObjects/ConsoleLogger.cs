﻿using System.Runtime.CompilerServices;
using SharpLogger.LoggerSupport;

namespace SharpLogger.LoggerObjects
{
    /// <summary>
    /// Builds a console logging object to show output with.
    /// </summary>
    public class ConsoleLogger : BaseLogger 
    {
        /// <summary>
        /// Builds a new falcon file logging object.
        /// </summary>
        /// <param name="LoggerName"></param>
        /// <param name="MinLevel"></param>
        /// <param name="MaxLevel"></param>
        public ConsoleLogger([CallerMemberName] string LoggerName = "", int MinLevel = 0, int MaxLevel = 5) : base(LoggerActions.ConsoleLogger, LoggerName, MinLevel, MaxLevel)
        {
            // Add the logging rule here.
            this.LoggingConfig = LogManager.Configuration;
            this.LoggingConfig.AddRule(
                LogLevel.FromOrdinal(MinLevel),
                LogLevel.FromOrdinal(MaxLevel), 
                WatchdogLoggerConfiguration.GenerateConsoleLogger(LoggerName));

            // Store configuration
            LogManager.Configuration = this.LoggingConfig;
            this.NLogger = LogManager.GetCurrentClassLogger();
            this.PrintLoggerInfos();
        }

        // ----------------------------------------------------------------------------------------------------------------
    }
}
