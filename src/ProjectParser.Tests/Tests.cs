using System;
using Xunit;

namespace ProjectParser.Tests {
    public class Tests {
        [Fact]
        public void ShouldReadProjectFile() {
            var project = "/Users/wk/Source/ProjectParser/src/ProjectParser/ProjectParser.csproj";
            var rs = Parser.Parse(project);
            Assert.Equal("0.1.0", rs.Version);
        }
    }
}