using System;
using Microsoft.Extensions.DependencyInjection;

namespace cmkService
{
    
    public static class ServiceCollectionExtensions
    {
        public static  IServiceCollection AddCustomizedMvc(this IServiceCollection services)
        {
            services.AddMvc(o => o.Conventions.Add(new FeatureConvention()))
                    .AddRazorOptions(options => {
                        // {0} - Action name
                        // {1} - Controller name
                        // {2} - Area name
                        // {3} - Feature Name
                        options.ViewLocationFormats.Clear();
                        options.ViewLocationFormats.Add("/Features/{3}/{1}/{0}");
                        options.ViewLocationFormats.Add("/Features/{3}/{0}.cshtml");
                        options.ViewLocationFormats.Add("/Features/Shared/{0}.cshtml");
                        options.ViewLocationExpanders.Add(new FeatureViewLocationExpander());
                    });
            return services;
        }
    }
}