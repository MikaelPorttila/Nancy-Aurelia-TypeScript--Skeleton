using Nancy;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NancyAureliaSkeleton.Lib.System {
    /// <summary>
    /// Modify Nancy default web root.
    /// </summary>
    public class StaticRootProvider : IRootPathProvider {

        private static string _rootPath;

        static StaticRootProvider() {
            _rootPath = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                SystemConstants.WWW_ROOT);
        }

        public string GetRootPath() {
            return _rootPath;
        }
    }
}
