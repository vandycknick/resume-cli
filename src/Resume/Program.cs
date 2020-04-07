using System.IO;
using System.Reflection;
using McMaster.Extensions.CommandLineUtils;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using RazorLight;
using Resume.Commands;
using Resume.Services;

namespace Resume
{
    [Command("resume")]
    [VersionOptionFromMember("--version", MemberName = nameof(GetVersion))]
    [Subcommand(typeof(BuildCommand))]
    [Subcommand(typeof(ValidateCommand))]
    class Program
    {
        [LegalFilePath]
        [Option(Description = "Root directory", ShortName = "r", Inherited=true)]
        public string Root { get; set; } = Directory.GetCurrentDirectory();

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IFileProvider>(_ => new PhysicalFileProvider(Root));

            services.AddSingleton<IResumeClient, ResumeFileClient>();
            services.AddHttpClient<IResumeValidator, ResumeValidator>();

            var engine = new RazorLightEngineBuilder()
                .UseEmbeddedResourcesProject(typeof(Templates.DefaultModel))
                .UseMemoryCachingProvider()
                .Build();

            services.AddSingleton<IRazorLightEngine>(engine);
        }

        public int OnExecute(CommandLineApplication app)
        {
            app.ShowHelp();
            return 1;
        }

        public static int Main(string[] args) => ConsoleApplicationHost.Run<Program>(args);

        private static string GetVersion()
            => typeof(Program).Assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion;
    }
}
