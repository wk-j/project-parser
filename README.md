## Project Parser [![Build Status](https://travis-ci.org/wk-j/project-parser.svg?branch=master)](https://travis-ci.org/wk-j/project-parser) [![Join the chat at https://gitter.im/project-parser/Lobby](https://badges.gitter.im/project-parser/Lobby.svg)](https://gitter.im/project-parser/Lobby?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)

```bash
dotnet add package wk.ProjectParser
```

## Usage

```csharp
var project = "src/ProjectParser/ProjectParser.csproj";
var info = Parser.Parse(project);
Assert.Equal("wk.ProjectParser", info.PackageId);
Assert.Equal("0.4.0", info.Version);
```