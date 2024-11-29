using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Rumors.Desktop.Common;
using Rumors.Desktop.Common.Messages.MessageHub;
using Rumors.Desktop.Common.Messages.Serialization;
using Rumors.Desktop.Common.Pipes;
using Rumors.Desktop.Logging;
using Rumors.Desktop.MessageHandlers;
using Serilog;
using System.IO;

namespace Rumors.Desktop
{
    public class ApplicationEntryPoint
    {
        public static IServiceProvider ServiceProvider { get; private set; } = null!;
        public static IConfiguration Configuration { get; private set; } = null!;


        public static void RegisterServices()
        {
            var services = new ServiceCollection();
            services.AddLogging(builder =>
            {
                builder.AddSerilog(dispose: true);
            });

            Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false).Build();
            services.AddSingleton<IConfiguration>(Configuration);

            services.AddTransient<IMessageSerializer, MessageSerializer>();
            services.AddSingleton<IPageNavigator, PageNavigator>();
            services.AddSingleton<IMessageHub, MessageHub>();
            services.AddSingleton<IMessageHandlersList, MessageHandlersList>();
            services.AddSingleton<IChatNotifier, LogNotifier>();
            services.AddSingleton<PipeClient>(c => new PipeClient(PipeConsts.ReversedPipeName, ex => { }));


            ServiceProvider = services.BuildServiceProvider();

        }


    }
}
