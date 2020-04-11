using System.Threading.Tasks;
using Resume.Schema;
using Resume.TemplateProvider;

namespace Resume.Templates
{
    public class DefaultTemplate : ITemplate
    {
        public string Name => "Default";

        public string Description => "Default template";

        public string Namespace => GetType().Namespace;

        public object OnBeforeRender(JsonResumeV1 resume) => new DefaultModel(resume);
    }
}
