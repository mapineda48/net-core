# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Repository Overview

Personal .NET Core learning projects. The main (and only) project is the **climate** app — a full-stack app combining weather data (OpenWeatherMap) and news headlines (NewsAPI) with search history persistence.

## Build & Run Commands

### Backend (.NET 10)

```sh
dotnet build
dotnet run              # API only on port 5000 (no SPA in dev mode)
dotnet publish          # builds SPA via pnpm and publishes self-contained
```

### Frontend (React 19 + TypeScript + Vite, in ClientApp/)

```sh
cd ClientApp
pnpm install
pnpm dev                # Vite dev server on port 3000 (proxies /api → :5000)
pnpm build              # production build → ClientApp/build/
pnpm types              # TypeScript type-check (tsc --noEmit)
```

### Development workflow (two terminals)

```sh
# Terminal 1 — backend API
dotnet run

# Terminal 2 — frontend dev server
cd ClientApp && pnpm dev
```

Access the app at **http://localhost:3000**. The Vite dev server proxies `/api` requests to the .NET backend on `:5000`.

### Docker Compose (full stack)

```sh
docker-compose up       # web on :3000 → :5000, SQL Server on :1433
```

### Devcontainer (recommended for development)

Open in VS Code with the Dev Containers extension. The devcontainer runs the full stack with SQL Server included.

## Required Environment Variables

- `SQLSERVER` — SQL Server connection string
- `APP_RUN_DELAY` — (optional) startup delay in ms, used to wait for DB readiness in Docker

## Architecture

### Backend (root)

ASP.NET Core 10 Web API. Top-level `Program.cs` (minimal hosting).

**Controllers** (under `Controllers/`):
- `ExternalController` — serves weather + news from seed data in the database (no external API calls)
- `HistoryController` — CRUD for search history (GET all, POST new)
- `TestController` — health check

**Data layer** (under `Models/`):
- `AppDbContext` — EF Core DbContext with auto-migration and seed data on startup
- `History` → `Location` (one-to-many) — tracks searches and associated locations
- SQL Server with EF Core lazy-loading proxies
- Circular references handled via `System.Text.Json` `ReferenceHandler.IgnoreCycles`

**DI setup**: `CustomExtension.cs` registers DbContext with connection string from `SQLSERVER` env var.

Swagger UI available in Development mode at `/swagger`.

### Frontend (ClientApp/)

Vite + React 19 + TypeScript, Material-UI v6, Axios, SCSS.

- `src/Session/` — React Context providing API state (prepare/fetchLocation actions)
- `src/App/` — main dashboard displaying weather + news
- `src/App/Bar/` — top nav with search input and history drawer
- `src/api/` — Axios-based API client with TypeScript types
- Uses custom package `mp48-react` for state management

### Integration

In **development**: Vite dev server on `:3000` proxies `/api` to .NET on `:5000`. The backend does not serve the SPA in dev mode.

In **production** (`dotnet publish`): Vite builds to `ClientApp/build/`, which is copied to `wwwroot/` and served by .NET via `MapStaticAssets()` and `MapFallbackToFile("index.html")`.

API routes follow the `{controller}/{action}/{id?}` convention.
