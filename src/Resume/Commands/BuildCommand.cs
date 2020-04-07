using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using McMaster.Extensions.CommandLineUtils;
using PuppeteerSharp;
using PuppeteerSharp.Media;
using RazorLight;
using Resume.Services;

namespace Resume.Commands
{
    [Command(Description = "Build resume")]
    public class BuildCommand
    {
        [LegalFilePath]
        [Option(Description = "Path to resume.json file", ShortName = "l")]
        public string Location { get; set; } = "resume.json";

        [LegalFilePath]
        [Option(Description = "Path to resume.json file", ShortName = "o")]
        public string Output { get; set; } = "artifacts";

        private readonly IRazorLightEngine _razorViewRenderer;
        private readonly IResumeClient _resumeClient;

        public BuildCommand(IRazorLightEngine razorViewRenderer, IResumeClient resumeClient)
        {
            _razorViewRenderer = razorViewRenderer;
            _resumeClient = resumeClient;
        }

        public async Task OnExecuteAsync()
        {
            Console.WriteLine("Starting ...");
            var model = new Resume.Templates.DefaultModel();
            model.OnRender(_resumeClient.GetResume(Location));

            var result = await _razorViewRenderer.CompileRenderAsync("Default", model);

            Directory.CreateDirectory(Output);

            var resumeHtmlPath = $"{Output}/resume.html";
            var resumePdfPath = $"{Output}/resume.pdf";

            using (var stream = new FileStream(resumeHtmlPath, FileMode.Create))
            {
                var bytes = Encoding.UTF8.GetBytes(result);
                await stream.WriteAsync(bytes);
            }

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

            // await page.emulateMedia(themePkg.pdfRenderOptions && themePkg.pdfRenderOptions.mediaType || 'screen');
            // await page.goto(`data: text / html; base64,${ btoa(unescape(encodeURIComponent(html)))}`, { waitUntil: 'networkidle0' });

            await page.PdfAsync(resumePdfPath, new PdfOptions
            {
                Format = PaperFormat.Letter,
                PrintBackground = true,
            });

    //     path: fileName + format,
    //   format: 'Letter',
    //   printBackground: true,
    //   ...themePkg.pdfRenderOptions

            Console.WriteLine("Done...");
        }
    }
}
