using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.CommandLine.IO;
using System.IO;
using System.Text;
using PuppeteerSharp;
using PuppeteerSharp.Media;
using Resume.Schema;

namespace Resume
{
    public partial class Program
    {
        private const string RESUME_FILENAME = "resume.json";

        public static Command CreateBuildCommand()
        {
            var command = new Command("build", "Build resume")
            {
                new Option(
                    new string[] { "-f", "--file" },
                    "Path to a resume.json file"
                )
                {
                    Argument = new Argument<FileInfo>(() => new FileInfo(RESUME_FILENAME))
                    {
                        Name = "filepath",
                        Arity = ArgumentArity.ZeroOrOne,
                    },
                    Required = false,
                },
                new Option(
                    new string[] { "-o", "--output" },
                    "Path to a folder to store the output"
                )
                {
                    Argument = new Argument<string>(() => "artifacts")
                    {
                        Name = "directory",
                        Arity = ArgumentArity.ZeroOrOne,
                    },
                    Required = false
                },
                new Option(
                    new string[] { "-t", "--theme" },
                    "A theme for your resume"
                )
                {
                    Argument = new Argument<string>(() => "Default")
                    {
                        Name = "theme",
                        Arity = ArgumentArity.ZeroOrOne
                    },
                    Required = false,
                }
            };

            command.Handler = CommandHandler.Create<FileInfo, string, string, string, IConsole>(async (file, output, cwd, theme, console) =>
            {
                if (!file.Exists) throw new FileNotFoundException("Resume not found", file.FullName);

                console.Out.WriteLine("Starting ...");

                using var stream = file.OpenRead();
                using var reader = new StreamReader(stream);

                var resume = JsonResumeV1.FromJson(reader);
                var engine = new TemplatingEngineBuilder()
                    .AddDefaultTemplates()
                    .AddPlugins()
                    .Build();

                var result = await engine.RenderAsync(theme, resume);

                Directory.CreateDirectory(output);

                var resumeHtmlPath = Path.Join(output, "resume.html");
                var resumePdfPath = Path.Join(output, "resume.pdf");

                using var htmlStream = new FileStream(resumeHtmlPath, FileMode.Create);
                var bytes = Encoding.UTF8.GetBytes(result);
                await htmlStream.WriteAsync(bytes);


                var fetcher = new BrowserFetcher(new BrowserFetcherOptions
                {
                    Path = AppContext.BaseDirectory,
                });

                await fetcher.DownloadAsync(BrowserFetcher.DefaultRevision);
                var browser = await Puppeteer.LaunchAsync(new LaunchOptions
                {
                    ExecutablePath = fetcher.GetExecutablePath(BrowserFetcher.DefaultRevision),
                    Headless = true
                });

                var page = await browser.NewPageAsync();

                await page.EmulateMediaTypeAsync(MediaType.Print);

                var encoded = System.Convert.ToBase64String(Encoding.UTF8.GetBytes(result));
                await page.GoToAsync($"data:text/html;base64,{encoded}", WaitUntilNavigation.Networkidle0);

                await page.PdfAsync(resumePdfPath, new PdfOptions
                {
                    Format = PaperFormat.Letter,
                    PrintBackground = true,
                });

                console.Out.WriteLine("Done...");
            });

            return command;
        }
    }
}
