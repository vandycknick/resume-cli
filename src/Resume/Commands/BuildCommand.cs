using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using McMaster.Extensions.CommandLineUtils;
using Resume.Services;
using SelectPdf;

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

        private readonly RazorViewRenderer _razorViewRenderer;
        private readonly IResumeClient _resumeClient;

        public BuildCommand(RazorViewRenderer razorViewRenderer, IResumeClient resumeClient)
        {
            _razorViewRenderer = razorViewRenderer;
            _resumeClient = resumeClient;
        }

        public async Task OnExecuteAsync()
        {
            Console.WriteLine("Starting ...");
            var model = new Resume.Views.DefaultModel();
            model.OnRender(_resumeClient.GetResume(Location));


            var page = await _razorViewRenderer.RenderViewToStringAsync("Default.cshtml", model);

            Directory.CreateDirectory(Output);

            var resumeHtmlPath = $"{Output}/resume.html";
            var resumePdfPath = $"{Output}/resume.pdf";

            using (var stream = new FileStream(resumeHtmlPath, FileMode.Create))
            {
                var bytes = Encoding.UTF8.GetBytes(page);
                await stream.WriteAsync(bytes);
            }

            var converter = new HtmlToPdf();

            converter.Options.PdfPageSize = PdfPageSize.A4;
            converter.Options.MarginTop = 72;
            converter.Options.MarginBottom = 72;
            converter.Options.MarginLeft = 72;
            converter.Options.MarginRight =72;

            converter.Options.CssMediaType = HtmlToPdfCssMediaType.Print;

            var document = converter.ConvertHtmlString(page);

            using (var stream = new FileStream(resumePdfPath, FileMode.Create))
            {
                document.Save(stream);
                document.Close();
            }

            Console.WriteLine("Done...");
        }
    }
}
