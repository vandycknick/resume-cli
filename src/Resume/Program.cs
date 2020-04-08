using System.CommandLine;
using System.CommandLine.Builder;
using System.CommandLine.Help;
using System.CommandLine.Invocation;
using System.CommandLine.Parsing;
using System.IO;
using System.Threading.Tasks;

namespace Resume
{
    public partial class Program
    {
        public static Task<int> Main(string[] args)
        {
            var command = new RootCommand("Todo add description.")
            {
                new Option(
                    "--cwd",
                    "The current working directory"
                )
                {
                    Argument = new Argument<string>(() => Directory.GetCurrentDirectory())
                    {
                        Name = "path",
                        Arity = ArgumentArity.ZeroOrOne,
                    },
                    Required = false,
                }
            };

            command.Name = "resume";
            command.AddCommand(CreateBuildCommand());
            command.AddCommand(CreateValidateCommand());

            command.Handler = CommandHandler.Create<IHelpBuilder>(help =>
            {
                help.Write(command);
                return 1;
            });

            var builder = new CommandLineBuilder(command);
            builder.UseHelp();
            builder.UseVersionOption();
            builder.UseDebugDirective();
            builder.UseParseErrorReporting();
            // builder.ParseResponseFileAs(ResponseFileHandling.ParseArgsAsSpaceSeparated);

            builder.CancelOnProcessTermination();
            // builder.UseExceptionHandler(HandleException);

            var parser = builder.Build();
            return parser.InvokeAsync(args);
        }
    }
}
