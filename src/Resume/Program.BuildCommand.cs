using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using PuppeteerSharp;
using PuppeteerSharp.Media;
using RazorLight;
using Resume.Models;

namespace Resume
{
    public partial class Program
    {
        public static Command CreateBuildCommand()
        {
            var command = new Command("build", "Build resume")
            {
                new Option(
                    new string[] { "-l", "--location" },
                    "Path to a resume.json file"
                )
                {
                    Argument = new Argument<FileInfo>
                    {
                        Name = "filepath",
                        Arity = ArgumentArity.ExactlyOne,
                    },
                    Required = true,
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
                }
            };

            command.Handler = CommandHandler.Create<FileInfo, string, string>(async (location, output, cwd) =>
            {
                using var stream = location.OpenRead();
                using var reader = new StreamReader(stream);
                using var jsonReader = new JsonTextReader(reader);

                var resume = new JsonSerializer().Deserialize<JsonResume>(jsonReader);

                var engine = new RazorLightEngineBuilder()
                    .UseEmbeddedResourcesProject(typeof(Templates.DefaultModel))
                    .UseMemoryCachingProvider()
                    .Build();

                var model = new Templates.DefaultModel();
                model.OnRender(resume);

                var result = await engine.CompileRenderAsync("Default", model);

                Directory.CreateDirectory(output);

                var resumeHtmlPath = Path.Join(output, "resume.html");
                var resumePdfPath = Path.Join(output, "resume.pdf");

                using var htmlStream = new FileStream(resumeHtmlPath, FileMode.Create);
                var bytes = Encoding.UTF8.GetBytes(result);
                await htmlStream.WriteAsync(bytes);


                var fetcher = new BrowserFetcher(new BrowserFetcherOptions
                {
                    Path = Path.GetDirectoryName(typeof(Program).Assembly.Location),
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

                Console.WriteLine("Done...");
            });

            return command;
        }
    }
}
