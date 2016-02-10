using Nancy;

namespace NancyAureliaSkeleton.Modules {
    public class IndexModule : NancyModule {
        public IndexModule() {
            Get["/"] = parameters => {
                return View["Views/index.html"];
            };
        }
    }
}