# Feature Spec: Login & Main Menu — UI Design & Navigation

## Overview

This spec covers the UI design implementation and navigation flow for the **Login Screen**. Design references are sourced from the `context/screenshots/` folder and visual assets from the `context/assets/` folder.

---

## Scope

| In Scope | Out of Scope |
|---|---|
| Login screen UI | Authentication logic / backend integration |
| Navigation between login → main menu | User session management |
| Asset and image integration | Push notifications, deep links |

---

## Screens

### 1. Login Screen

**Purpose:** Entry point of the app. Allows users to initiate access.

**Reference:** 
- `context/screenshots/login-ui.png` (or equivalent file in `screenshots/`) for the layout 
- `context/assets/logo_red.png` for the logo
- `context/assets/swa_login_bg.png` for the background

#### Layout & Components

copy the layout in the screenshot


#### States

- **Default** — empty fields, login button enabled
- **Loading** — button shows loading indicator (placeholder for future integration)
- **Error** — inline error message below fields (UI placeholder only)

---


## Navigation Flow

```
[App Launch]
     |
     v
[Login Screen]
     |
  (Login Button tapped)
     |
     v
[Main Menu Screen]
     |
  (Menu Item tapped)
     |
     v
[Placeholder / Destination Screen]
     |
  (Back)
     |
     v
[Main Menu Screen]
```

---

## Assets Reference

| Asset Type | Folder Path | Usage |
|---|---|---|
| Logo | `assets/logo_red.png*` | Login screen branding |
| Background images | `assets/swa_login_bg/` | Login & main menu backgrounds |


> All assets should be used as-is. No asset modifications in this phase.

---

## Design Guidelines

- **Follow screenshots exactly** for layout, spacing, typography, and color.
- **Do not deviate** from the visual design shown in `screenshots/` unless a component is missing from the reference, in which case use best judgment consistent with the overall style.
- Ensure all assets are properly linked and display correctly on target screen sizes.
- UI should be **pixel-faithful** to the design references.

---

## Acceptance Criteria

- [ ] Login screen renders correctly matching `screenshots/login-ui.*`
- [ ] All assets and images load without errors
- [ ] Tapping Login navigates to Main Menu
- [ ] Tapping each menu item navigates to its destination (placeholder screen is acceptable)
- [ ] Back navigation from destination returns to Main Menu
- [ ] No crashes or broken layouts on target device/screen sizes

---

## Notes & Assumptions

- This phase is **UI and navigation only** — no business logic, authentication, or API calls.
- Placeholder screens for menu destinations are acceptable.
- Actual menu item labels and icons will be confirmed against the `screenshots/` reference.
- Any ambiguity in the design should be flagged and resolved against the screenshot references before implementation begins.

---

*Spec version: 1.0 | Phase: UI & Navigation*
