# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Build and Run

```bash
dotnet build SupplyWinApp.sln
dotnet run --project src/SupplyWinApp.Presentation
```

No test projects exist yet. No linter or formatter is configured.

## Context Files

Read the following files for the full context of the application

- `project-overview.md` - Full project spec including features, data models, tech stack and UI/UX
- `coding-standards.md` - Code conventions, patterns and rules for the AI to follow
- `ai-interaction.md` - Workflow and communication guidelines for working with the AI
- `current-feature.md` - Living document tracking the feature currently being worked on
- `features/` - Feature spec files used with the `/feature` command
- `fixes/` - Fix spec files for bugs and issues
- `research/` - Research files used with the `/research` command to generate documentation
- `screenshots/` - UI screenshots used as visual references for the AI
