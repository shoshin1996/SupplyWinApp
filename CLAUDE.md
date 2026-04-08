# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Build and Run

```bash
dotnet build SupplyWinApp.sln
dotnet run --project src/SupplyWinApp.Presentation
```

No test projects exist yet. No linter or formatter is configured.

## Architecture

This is a WPF desktop application (.NET 8) following Clean Architecture with four layers:

- **Domain** (`SupplyWinApp.Domain`) — Entities and repository interfaces. No dependencies on other projects.
- **Application** (`SupplyWinApp.Application`) — DTOs, service interfaces, and service implementations. Depends on Domain.
- **Infrastructure** (`SupplyWinApp.Infrastructure`) — Repository implementations (JSON file-based) and the DI registration extension method (`AddInfrastructure`). Depends on Application.
- **Presentation** (`SupplyWinApp.Presentation`) — WPF UI layer. Depends on Infrastructure and Application.

Dependency direction: Presentation -> Infrastructure -> Application -> Domain.

## Key Patterns

- **DI composition root** is in `App.xaml.cs`. Infrastructure services are registered via `services.AddInfrastructure(usersJsonPath)`. ViewModels are registered manually.
- **MVVM** with a hand-rolled implementation: `ViewModelBase` (INotifyPropertyChanged), `RelayCommand`, and `ShellViewModel` for navigation via `CurrentViewModel` property and `DataTemplate` switching.
- **Navigation**: `ShellViewModel.NavigateTo()` swaps the active ViewModel. `MainWindow.xaml` uses DataTemplates to map ViewModels to Views.
- **Data storage**: User credentials are stored in `Infrastructure/Data/users.json`, copied to output directory at build time.
