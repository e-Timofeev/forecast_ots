# Forecast OTS

Historical desktop application for forecasting the OTS audience metric using ETS.

## Status

**Historical / no longer actively maintained.**

- Original development: **2020**
- Repository cleanup: **2026-10-06**
- The codebase is preserved as a record of the original implementation and technology stack.
- There is no current production deployment or supported runtime environment.

## What the application did

The WinForms application combined several operations:

- loading OTS data from Excel;
- storing and reading observations in SQL Server Compact;
- receiving OTS data from an external analytics API;
- forecasting time series with Excel `FORECAST.ETS`;
- displaying actual and forecast values in charts.

## Original technology stack

- C# / Windows Forms
- .NET Framework 4.5
- SQL Server Compact 4.0
- Microsoft Office / Excel Interop
- Newtonsoft.Json
- Visual Studio 2017-era project format

The project intentionally retains its original legacy stack. It is not being migrated to modern .NET.

## Legacy API credentials

The original configuration contained a temporary research access token used during the project period.

That token **expired / was revoked in 2020**, is no longer valid, and is not used by any current system. The live value has been removed from the current branch and replaced with an explicit placeholder. Historical commits are retained as part of the project history.

The external API endpoints are also legacy project dependencies and are not guaranteed to exist today.

## Dependency note

On **2026-10-06**, Newtonsoft.Json was updated from `12.0.3` to `13.0.2` to resolve the historical Dependabot security alert. The project file reference was synchronized with the NuGet package version.

## Build note

A clean cloud build is **not guaranteed**. The original application depended on Windows-specific and locally installed components, including Excel Interop, SQL Server Compact, signing material and other legacy references.

This repository is therefore intended primarily as a historical source-code artifact, not as a currently supported build.

## Legacy runtime note

For the original environment, SQL Server Compact runtime installation may be required. See `Forecast/Readme.txt`.
