# Plan: Redesign MainMenuView to Match Screenshot

## Context
The current MainMenuView uses a navy-blue card style with emoji icons and a simple header. The screenshot (`context/screenshots/main-menu-ui.png`) shows a dark background with red square buttons, a branded header, machine info sub-header, and bottom action buttons. This plan redesigns the UI to match.

## Files to Modify (in order)

### 1. `src/SupplyWinApp.Presentation/App.xaml`
- Add dark background colors: `#111111` (header), `#1A1A2E` (sub-header), `#0D0D1A` (main bg)
- Update `MenuItemButtonStyle` to use red background (`AccentRedBrush`) instead of navy
- Add `MenuActionButtonStyle` for bottom buttons (SELECT MACHINE, LOGOUT)

### 2. Copy icon assets into project
- Copy all 6 PNGs from `context/assets/icons/` to `src/SupplyWinApp.Presentation/Assets/Icons/`
- Add them as `Resource` in `.csproj`

### 3. `src/SupplyWinApp.Presentation/ViewModels/MainMenuViewModel.cs`
- Add `MachineName` property (string)
- Add `SelectMachineCommand` + `SelectMachineRequested` event
- Change `MenuItemViewModel.Icon` from emoji string to image path string (e.g. `/Assets/Icons/mdi_take.png`)
- Replace menu items with 6 fixed items:
  - TAKE (`mdi_take.png`), RECLAIM (`mdi_reclaim.png`), RETURN (`mdi_return.png`)
  - INVENTORY CHECK (`mdi_inventory_check.png`), STOCK (`mdi_stock.png`), ADHOC ORDER (`mdi_adhoc_order.png`)
- Remove role-based conditional logic (screenshot shows fixed 3x2 grid)
- Update constructor: `(string displayName, string role, string machineName)`

### 4. `src/SupplyWinApp.Presentation/App.xaml.cs`
- Update `NavigateToMainMenu` to pass machine name to constructor
- Wire `SelectMachineRequested` event (no-op for now)

### 5. `src/SupplyWinApp.Presentation/Views/MainMenuView.xaml`
Complete rewrite with 5-row Grid layout:
- **Background**: `swa_login_bg.jpg` with dark semi-transparent overlay (same approach as LoginView)
- **Row 0** (Header): Dark bar with logo + "SUPPLYSYSTEM INTELLIGENT SOFTWARE" left, user icon + "CUSTOMIZE" right
- **Row 1** (Sub-header): "VIRTUAL MACHINE" label + machine name
- **Row 2** (Menu): UniformGrid 3×2 of red square buttons with Segoe MDL2 icons
- **Row 3** (Bottom): "SELECT MACHINE ▼" and "LOGOUT" buttons (left-aligned, stacked vertically)
- **Row 4** (Footer): Thin red accent bar

## Key Design Decisions
- `Icon` property changes from emoji to image path string; XAML DataTemplate uses `<Image Source="{Binding Icon}"/>` 
- UniformGrid for consistent button sizing in the 3×2 grid
- Background uses `swa_login_bg.jpg` with dark overlay (same approach as LoginView)

## Verification
```bash
dotnet build SupplyWinApp.sln
dotnet run --project src/SupplyWinApp.Presentation
```
- Login → verify MainMenu renders with red buttons, dark background, branded header
- Verify all 6 menu items display with icons
- Click menu items → placeholder view works
- Click LOGOUT → returns to login
- Compare visually against `context/screenshots/main-menu-ui.png`
