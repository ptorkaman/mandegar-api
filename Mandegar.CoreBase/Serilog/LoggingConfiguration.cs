using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using Serilog.Exceptions;
using Serilog.Sinks.Elasticsearch;
using System;
using System.Reflection;

namespace Mandegar.CoreBase.Serilog
{
    public static class LoggingConfiguration
    {
        public static Action<HostBuilderContext, LoggerConfiguration> ConfigureLogger =>
        (context, configuration) =>
        {
            #region Enriching Logger Context
            var env = context.HostingEnvironment;
            configuration.Enrich.FromLogContext()
            .Enrich.WithProperty("ApplicationName", env.ApplicationName)
            .Enrich.WithProperty("Environment", env.EnvironmentName)
            .Enrich.WithExceptionDetails();
            #endregion

            #region ElasticSearch Configuration.
            var elasticUrl = context.Configuration.GetValue<string>("Logging:Elastic:Url");
            if (!string.IsNullOrEmpty(elasticUrl))
            {
                configuration.WriteTo.Elasticsearch(
                  new ElasticsearchSinkOptions(new Uri(elasticUrl))
                  {
                      AutoRegisterTemplate = true,
                      AutoRegisterTemplateVersion = AutoRegisterTemplateVersion.ESv7,
                      IndexFormat = context.Configuration.GetValue<string>($"Logging:Elastic:IndexFormat:{Assembly.GetEntryAssembly().GetName().Name}"),
                      MinimumLogEventLevel = LogEventLevel.Error,
                  });
            }
            #endregion
        };
    }
}
