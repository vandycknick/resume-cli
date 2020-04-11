using Resume.Schema;

namespace Resume.TemplateProvider
{
    public interface ITemplate
    {
        string Name { get; }
        string Description { get; }
        string Namespace { get; }
        object OnBeforeRender(JsonResumeV1 resume) => resume;
    }
}
