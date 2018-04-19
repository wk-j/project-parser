using System;
using Xunit;

namespace ProjectParser.Tests {
    public class Tests {
        [Fact]
        public void ShouldReadProjectFile() {
            var project = "../../../../../src/ProjectParser/ProjectParser.csproj";
            var info = Parser.Parse(project);
            Assert.Equal("wk.ProjectParser", info.PackageId);
            Assert.Equal("0.4.0", info.Version);
        }
    }
}