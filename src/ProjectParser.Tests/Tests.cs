using System;
using Xunit;

namespace ProjectParser.Tests {
    public class Tests {
        [Fact]
        public void ShouldReadProjectFile() {
            var project = "../../../../../src/ProjectParser/ProjectParser.csproj";
            var rs = Parser.Parse(project);
            Assert.Equal("ProjectParser", rs.PackageId);
        }
    }
}