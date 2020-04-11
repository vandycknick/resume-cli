using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using RazorLight;
using Resume.TemplateProvider;
using Resume.Templates;

namespace Resume
{
    public class TemplatingEngineBuilder
    {
        private readonly RazorLightEngineBuilder _engineBuilder;

        private readonly List<ITemplate> _templates;

        public TemplatingEngineBuilder()
        {
            _engineBuilder = new RazorLightEngineBuilder()
                .EnableEncoding()
                .UseMemoryCachingProvider();

            _templates = new List<ITemplate>();
        }

        public TemplatingEngineBuilder AddDefaultTemplates()
        {
            var assembly = typeof(DefaultTemplateProvider).Assembly;
            return AddFromAssembly(assembly);
        }

        public TemplatingEngineBuilder AddFromAssembly(Assembly assembly)
        {
            var templates = assembly.GetTypes()
                    .Where(type => typeof(ITemplate).IsAssignableFrom(type) && !type.IsInterface)
                    .Select(type => (ITemplate)Activator.CreateInstance(type));

            _templates.AddRange(templates);

            _engineBuilder.UseEmbeddedResourcesProject(assembly);
            return this;
        }

        public TemplatingEngineBuilder AddPlugins()
        {
            // TODO: implement loading of custom themes!
            return this;
        }

        public TemplatingEngine Build()
        {
            var razorEngine = _engineBuilder.Build();
            return new TemplatingEngine(_templates, razorEngine);
        }
    }
}
