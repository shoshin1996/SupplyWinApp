# Coding Standards (WPF - .NET 8)

This document defines the coding standards for our **WPF (.NET 8) application** designed for:

- Low-spec devices
- Inventory system
- Kiosk mode (always running, stable, responsive)

---

# Goals

- Performance (low CPU & memory usage)
- Stability (long-running app, no memory leaks)
- Simplicity (easy to maintain and debug)
- Predictability (AI + human consistency)
- Avoid over-engineering

---

# C#

## General Principles
- Prefer simple, readable code over clever abstractions
- Avoid unnecessary allocations
- Avoid reflection and dynamic features
- Keep methods short and focused (< 30 lines)
- Make sure the app has no memory leak

---

## Naming Conventions
- Classes: `PascalCase` → `InventoryService`
- Methods: `PascalCase` → `CalculateTotal()`
- Variables: `camelCase` → `totalPrice`
- Private fields: `_camelCase`
- Interfaces: `I` prefix → `IInventoryRepository`

---

## Async/Await
- Use only for:
  - I/O operations (database, file)
- Avoid for:
  - UI-only logic
  - CPU-bound work

---

## Memory & Performance
- Make sure the app has no memory leak
- Avoid LINQ in hot paths
- Avoid unnecessary `.ToList()`
- Reuse objects when possible
- Minimize allocations inside loops

---

## Exception Handling
- Use exceptions only for unexpected errors
- Never use exceptions for control flow

---

## Dependency Injection
- Use constructor injection
- Avoid too many dependencies (>5 = smell)

---

## Logging
- Log only:
  - Errors
  - Critical actions
- Avoid verbose logging (affects performance)

---

# WPF-Specific Guidelines

## UI Performance (CRITICAL ⚠️)

- Avoid complex visual trees
- Avoid deeply nested controls
- Prefer simple layouts (Grid over StackPanel when possible)
- Limit use of:
  - `ItemsControl` with large datasets
  - Heavy templates
- For UI Designs, make it responsive to small screens and low-spec devices. Avoid complex animations and effects.
---

## Data Binding

- Prefer **OneWay binding** unless TwoWay is required
- Avoid excessive bindings in a single view
- Avoid binding to deeply nested properties

```xml
<!-- GOOD -->
<TextBlock Text="{Binding Name}" />

<!-- AVOID -->
<TextBlock Text="{Binding User.Profile.Address.Street}" />