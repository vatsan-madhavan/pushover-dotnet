using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nlog_Target;
using NLog;
using NLog.Config;

namespace nlog_pushover_tests
{
    [TestClass]
    public class NlogPushoverTests
    {
        private readonly Logger logger;
        /// <summary>
        /// Configure PushoverTarget using Nlog API
        /// </summary>
        public NlogPushoverTests()
        {
            var logConfig = new LoggingConfiguration();
            var target = new PushoverTarget()
            {
                AppToken = "YOUR PUSHOVER APP TOKEN. ref: https://pushover.net ",
                UserOrGroupKey = "YOUR PUSHOVER USER KEY. ref: https://pushover.net "
            };

            logConfig.AddTarget(target);
            logConfig.LoggingRules.Add(new LoggingRule("*",LogLevel.Trace, target));
            LogManager.Configuration = logConfig;
            LogManager.ReconfigExistingLoggers();
            logger = LogManager.GetCurrentClassLogger();
        }

        /// <summary>
        /// Pump out a test message for every log level
        /// </summary>
        [TestMethod]
        public void DebugTest()
        {
            logger.Debug("Debug test");
            logger.Trace("Trace test");
            logger.Info("Info test");
            logger.Warn("Warn test");
            logger.Error("Error test");
            logger.Fatal("Fatal test");
        }
    }
}
