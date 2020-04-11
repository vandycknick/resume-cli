using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RazorLight;
using Resume.Schema;
using Resume.TemplateProvider;

namespace Resume
{
    public class TemplatingEngine
    {
        private readonly IReadOnlyList<ITemplate> _templates;
        private readonly IRazorLightEngine _engine;
        public TemplatingEngine(IReadOnlyList<ITemplate> templates, IRazorLightEngine engine)
        {
            _templates = templates;
            _engine = engine;
        }

        public Task<string> RenderAsync(string view, JsonResumeV1 resume)
        {
            if (string.IsNullOrEmpty(view)) throw new ArgumentNullException(nameof(view));

            var template = _templates.FirstOrDefault(t => t.Name == view);

            if (template == null) throw new Exception("template not found");

            var model = template.OnBeforeRender(resume);
            return _engine.CompileRenderAsync($"{template.Namespace}.{template.Name}", model);
        }
    }
}
