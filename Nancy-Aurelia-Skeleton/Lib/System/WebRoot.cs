using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NancyAureliaSkeleton.Lib.System {
    public class WebRoot : OwinMiddleware {

        public WebRoot(OwinMiddleware next) : base(next) { }

        public override async Task Invoke(IOwinContext context) {

            if(context.Request.Path.Value.Length > 1) {
                context.Request.Path = new PathString("/" + SystemConstants.WWW_ROOT + context.Request.Path.Value);
            }

            await Next.Invoke(context);
        }
    }
}
