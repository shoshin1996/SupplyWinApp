# Inventory Management System

🗃️ Hardware-Integrated, Offline-First Desktop Inventory Management

---

## 📌 Problem (Core Idea)

Managing inventory with specialized cabinet hardware in environments with unreliable internet is painful:

- Transactions can't be recorded when the connection drops
- Stock counts get out of sync between devices and the server
- Staff are blocked from working while waiting for connectivity
- Manual workarounds lead to lost or inaccurate records
- Cabinet access needs to be tightly controlled and tied to specific transactions

➡️ **This system provides a reliable, offline-first inventory solution built around custom hardware cabinet access — syncing automatically when connectivity is restored, so work never stops.**

---

## 🧑‍💻 Users

| Persona | Needs |
| --- | --- |
| Standard User | Log in and perform Take or Return transactions via the cabinet hardware |
| Admin | Full transaction access, inventory control, hardware oversight, and manual sync |

---

## ✨ Core Features

### A) Transactions

The following transaction types are supported:

- **Take** — Remove a product from the cabinet
- **Return** — Return a product back into the cabinet
- **Load** — Bring products into a location *(Admin only, requires internet)*
- **Unload** — Remove products out of a location *(Admin only, requires internet)*
- **Inventory** — Manually adjust a product's count *(Admin only)*

### B) Hardware Integration

The application communicates directly with **custom cabinet hardware** via a serial connection and the hardware's SDK. Physical access to inventory items is controlled through this integration:

- The app sends commands to the hardware to open the appropriate cabinet slot during a transaction
- Hardware responses are received and processed in real time
- All hardware communication happens locally on the device, making it fully functional offline
- If the hardware is unreachable or unresponsive, the transaction is blocked until the connection is restored

### C) Offline Support

All transactions are saved locally first. The app works fully offline for Take, Return, and Change Inventory Count. Load and Unload require an active internet connection and are disabled when offline.

### D) Data Sync

Transactions are synced to the server automatically or on demand:

- **Automatic** — Background sync runs at a configured interval
- **Manual** — Triggered anytime via a menu option

Unsynced transactions are tagged as **unsent** until successfully delivered to the server.

### E) Authentication

- Username + Password login
- Role assigned at login (Admin or User)

### F) Multi-Tenant Support

The application is scoped per tenant, ensuring data isolation across different organizations or branches.

### G) Load & Unload Workflow

When performing a Load or Unload:

1. A list of available **locations** is displayed
2. Admin selects a location
3. The screen updates to show **products** available for that location
4. Admin selects a product and completes the transaction

> ⚠️ Both require an active internet connection

---

## 🗄️ Data Model (Rough Draft)

> This schema is a starting point and **will evolve**

```
Tenant
  - id
  - name

User
  - id
  - tenantId
  - username
  - password
  - role (admin | user)
  - createdAt

Product
  - id
  - tenantId
  - name
  - quantity
  - cabinetSlot
  - updatedAt

Location
  - id
  - tenantId
  - name

Transaction
  - id
  - tenantId
  - userId
  - type (take | return | load | unload | adjust)
  - productId
  - locationId (nullable)
  - quantity
  - status (0 = unsent | 1 = sent)
  - createdAt
  - syncedAt (nullable)
```

---

## 🧱 Tech Stack

| Category | Choice |
| --- | --- |
| Platform | Desktop Application |
| Framework | .NET 8 |
| Language | C# |
| Local Database | SQLite |
| Remote Sync | REST API |
| Hardware Communication | Serial Connection + Hardware SDK |
| Target Hardware | Low-spec devices |

---

## 🎨 UI / UX

- Clean, minimal interface optimized for low-spec hardware
- Lightweight UI with fast navigation
- Clear visual indicator for online / offline status
- Clear visual indicator for hardware connection status
- Load and Unload options hidden or disabled when offline

### Layout

- **Login screen** — tenant-scoped authentication
- **Dashboard** — quick access to all available transactions
- **Transaction screens** — guided step-by-step flow with hardware feedback
- **Menu** — sync controls and app settings

### Responsive

- Designed for desktop use
- Optimized for smaller or lower-resolution displays common on low-spec devices

---

## Architecture

This is a WPF desktop application (.NET 8) following Clean Architecture with four layers:

- **Domain** (`SupplyWinApp.Domain`) — Entities and repository interfaces. No dependencies on other projects.
- **Application** (`SupplyWinApp.Application`) — DTOs, service interfaces, and service implementations. Depends on Domain.
- **Infrastructure** (`SupplyWinApp.Infrastructure`) — Repository implementations (JSON file-based) and the DI registration extension method (`AddInfrastructure`). Depends on Application.
- **Presentation** (`SupplyWinApp.Presentation`) — WPF UI layer. Depends on Infrastructure and Application.

Dependency direction: Presentation -> Infrastructure -> Application -> Domain.

## 🔐 Auth Flow

```
User → Login Screen → Credential Check → Role Assigned (Admin / User) → Dashboard
```

---

## 🔧 Hardware Interaction Flow

```
User Logs In
        │
  Check Hardware Connection (Serial / SDK)
        │
   Connected? ──No──► Show Hardware Error, Block Transaction
        │
       Yes
        │
  Send Cabinet Open Command via SDK
        │
  Hardware Opens Cabinet Slot
        │
  User Takes / Returns Item
        │
  Hardware Confirms Action
        │
  Transaction Saved Locally ──► Sync if Online
```

---

## 🧠 Load & Unload Flow

```
Admin Initiates Load/Unload
        │
  Check Internet
        │
   Connected? ──No──► Show Offline Warning, Block Transaction
        │
       Yes
        │
  Fetch Locations from Server
        │
  Admin Selects Location
        │
  Fetch Products from Server
        │
  Admin Selects Product
        │
  Send Cabinet Command via Hardware SDK
        │
  Complete Transaction ──► Save Locally ──► Sync to Server
```

---

## 🗂️ Development Notes

- Designed to run reliably on aging or low-spec hardware
- Local storage handles all persistence; no dependency on the network for core operations
- Hardware communication runs via serial connection using the hardware's SDK — must be treated as a required dependency for all physical transactions
- Server sync is append-based — only unsent transactions are included in each sync payload
- Tenant context is enforced across all local data and server communications

---

## 🧭 Roadmap

### **MVP**
- User login with role assignment
- Take and Return transactions with hardware cabinet integration
- Local storage
- Offline sync queue with unsent tagging
- Interval-based and manual sync

### **Admin Phase**
- Load and Unload transactions (with location/product selection flow)
- Change Inventory Count
- Forced sync via menu

### **Future Enhancements**
- Sync conflict resolution
- Transaction history and audit log
- Reporting and export
- Multi-device support per tenant
- Web-based admin dashboard

---

## 📌 Status

- In planning
- Architecture and data model defined, ready for development setup

---

🏗️ **Access It. Store It. Sync It. Never Stop Working.**
