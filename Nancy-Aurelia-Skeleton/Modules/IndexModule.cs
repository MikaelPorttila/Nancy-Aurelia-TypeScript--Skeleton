using Nancy;
using System.Threading.Tasks;

namespace NancyAureliaSkeleton.Modules {
    public class IndexModule : NancyModule {
        public IndexModule() {
            Get["/"] = (request, ctx) =>  Task.FromResult<dynamic>(View["index.html"]);
            Get["/api/test"] = (request, ctx) => Task.FromResult<dynamic>("Hello World");
        }
    }
}