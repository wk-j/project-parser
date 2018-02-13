using System;
using System.IO;
using System.Xml.Linq;
using System.Linq;

namespace ProjectParser {

    public class ProjectInfo {
        public string Version { set; get; } = "";
        public string PackageId { set; get; } = "";
        public string Title { set; get; } = "";
    }

    public static class Parser {
        public static ProjectInfo Parse(string projectFile) {
            var xml = File.ReadAllText(projectFile);
            var properties = XDocument.Parse(xml)
                                .Root.Elements("PropertyGroup")
                                .SelectMany(x => x.Elements());
            var info = new ProjectInfo();

            foreach (var el in properties) {
                var name = el.Name.LocalName;
                var value = el.Value;

                switch (name) {
                    case "Title": {
                            info.Title = value;
                            break;
                        }
                    case "Version": {
                            info.Version = value;
                            break;
                        }
                    case "PackageId": {
                            info.Version = value;
                            break;
                        }
                    default: {
                            break;
                        }
                }
            }
            return info;
        }
    }
}
