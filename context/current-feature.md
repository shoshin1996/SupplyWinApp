# Current Feature: Redesign MainMenuView to Match Screenshot

## Status

In Progress

## Goals

- Redesign MainMenuView to match the screenshot (`context/screenshots/main-menu-ui.png`)
- Dark background with red square buttons in a 3x2 grid layout
- Branded header with logo + "SUPPLYSYSTEM INTELLIGENT SOFTWARE" and user icon + "CUSTOMIZE"
- Sub-header showing "VIRTUAL MACHINE" label + machine name
- 6 menu items: TAKE, RECLAIM, RETURN, INVENTORY CHECK, STOCK, ADHOC ORDER with icon images
- Bottom action buttons: SELECT MACHINE and LOGOUT
- Footer with thin red accent bar
- Background uses `swa_login_bg.jpg` with dark overlay (same as LoginView)

## Notes

- Icon property changes from emoji to image path string; XAML uses `<Image Source="{Binding Icon}"/>`
- UniformGrid for consistent button sizing in 3x2 grid
- Files to modify: App.xaml, .csproj (icon assets), MainMenuViewModel.cs, App.xaml.cs, MainMenuView.xaml
- Copy icon PNGs from `context/assets/icons/` to `src/SupplyWinApp.Presentation/Assets/Icons/`
- Full plan details in `context/features/implement-main-menu-ui.md`

## History

<!-- Keep this updated. Earliest to latest -->

- **Login & Main Menu — UI Design & Navigation** (completed 2026-04-08): Implemented LoginView with branded background/logo, MainMenuView with grid navigation, PlaceholderView for destinations, and DataTemplate-based navigation. Added project assets, CLAUDE.md, feature specs, and skill definitions.
