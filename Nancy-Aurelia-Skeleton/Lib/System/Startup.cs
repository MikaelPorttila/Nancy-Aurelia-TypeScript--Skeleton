using Nancy;
using Owin;
using NancyAureliaSkeleton.Lib.System;
using Microsoft.Owin.Extensions;

namespace NancyAureliaSkeleton {
    public class Startup {
        public void Configuration(IAppBuilder builder) {

            builder
                .UseNancy(options =>
                    options.PerformPassThrough = context =>
                        context.Response.StatusCode == HttpStatusCode.NotFound)
                .Use<WebRoot>()
                .UseStaticFiles()
                .UseStageMarker(PipelineStage.MapHandler);
        }
    }
}
