using Nancy;
using Nancy.Bootstrapper;
using Nancy.TinyIoc;
using Owin;
namespace NancyAureliaSkeleton {

    public class Startup {
        public void Configuration(IAppBuilder builder) {

            // Tell owin to delegate requests 
            // to nancys handler
            builder.UseNancy();
        }
    }

    public class ApplicationBootstrap : DefaultNancyBootstrapper {
        protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines) {

            // add some security.
            Nancy.Security.Csrf.Enable(pipelines);
            
            // Set ContentType after request been handled.  
            pipelines.AfterRequest += ctx => {
                ctx.Response.ContentType += "; charset=utf-8";
            };
        }
        
    }
}
