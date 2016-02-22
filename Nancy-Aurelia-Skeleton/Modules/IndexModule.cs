using Nancy;

namespace NancyAureliaSkeleton.Modules {
    public class IndexModule : NancyModule {
        public IndexModule() {
            Get["/"] = _ => View["index.html"];
            Get["/api/test"] = _ => "Hello World";
        }
    }
}