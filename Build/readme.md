# SPT-NoTDifficult-Props

> SPT Mod add random props

**Author:** NoTDifficult
**Version:** 1.0.0
**SPT Version:** 4.0.13
**License:** MIT

---

## What This Mod Does

Describe what your mod does here. Be specific about game systems it modifies.

---

## Requirements

- [SPT](https://www.sp-tarkov.com/) **4.0.13** or compatible
- .NET 9 SDK (for building from source)

---

## Building

```sh
git clone https://github.com/notdifficult/SPT-NoTDifficult-Props
cd SPT-NoTDifficult-Props
dotnet build -c Release
```

The build target automatically packages the mod into a distributable `SPT-NoTDifficult-Props.zip`.

---

## Installation

1. Build the project (see above) **or** download the latest release zip.
2. Extract the zip so that `SPT-NoTDifficult-Props.dll` ends up in:
   
   ```
   <SPT root>/user/mods/SPT-NoTDifficult-Props/
   ```
4. Launch SPT server as usual.

---

## Configuration

No configuration file is required by default. Extend `plugin.cs` to add your own settings.

---

## Project Structure

```
SPT-NoTDifficult-Props/
├── SPT-NoTDifficult-Props.csproj   ← project file + packaging target
├── plugin.cs                       ← entry point (IOnLoad)
├── metadata.cs                     ← entry point (ModMetadata)
├── README.md
└── .gitignore
```

---

## Learning Resources

| Resource | URL |
|---|---|
| SPT Server (C#) — Overview | https://deepwiki.com/sp-tarkov/server-csharp/1-overview |
| Server Mod Examples | https://github.com/sp-tarkov/server-mod-examples |
| SPT Wiki Modding Resources | https://wiki.sp-tarkov.com/modding/Modding_Resources |
| SPT Client Mod Examples | https://github.com/Jehree/SPTClientModExamples |

---
