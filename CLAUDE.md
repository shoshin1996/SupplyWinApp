# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Build & Run

```bash
dotnet build                                          # build entire solution
dotnet run --project src/SupplyWinApp.Presentation        # run the WPF app
```

## Architecture

Clean Architecture with four projects under `src/`:

- **SupplyWinApp.Domain** — Entities and repository interfaces. No dependencies.
- **SupplyWinApp.Application** — DTOs, service interfaces, and service implementations. Depends on Domain.
- **SupplyWinApp.Infrastructure** — Data access (JSON file repositories) and DI registration (`DependencyInjection.AddInfrastructure`). Depends on Application.
- **SupplyWinApp.Presentation** — WPF app (MVVM). Depends on Application and Infrastructure. Startup wires DI in `App.xaml.cs`.

Dependency flow: **Presentation → Infrastructure → Application → Domain**

## Key Conventions

- .NET 8, C# with nullable enabled, file-scoped namespaces
- MVVM pattern: ViewModels in `Presentation/ViewModels/`, Views in `Presentation/Views/`
- `ViewModelBase` provides `INotifyPropertyChanged`; `RelayCommand` wraps async commands
- Mock data lives in `Infrastructure/Data/users.json` (copied to output on build)
- DI is configured via `IServiceCollection` extension method in `Infrastructure/DependencyInjection.cs`
- `SupplyWinApp.Application` namespace conflicts with `System.Windows.Application` — use fully qualified `System.Windows.Application` in Presentation code-behind files
