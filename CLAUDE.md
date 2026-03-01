# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Repository Overview

Personal .NET Core learning projects. The main (and only) project is **climate/** — a full-stack app combining weather data (OpenWeatherMap) and news headlines (NewsAPI) with search history persistence.

## Build & Run Commands

### Backend (.NET 6.0)

```sh
cd climate
dotnet build
dotnet run              # serves both API and React SPA on port 5000
dotnet publish          # builds SPA via yarn and publishes self-contained
```

### Frontend (React 17 + TypeScript, in climate/ClientApp/)

```sh
cd climate/ClientApp
yarn install
yarn start              # dev server (CRA)
yarn build              # production build
yarn test               # jest via react-scripts
yarn types              # TypeScript type-check (tsc --noEmit)
```

### Docker Compose (recommended for full stack)

```sh
cd climate
docker-compose up       # web on :3000 → :5000, SQL Server on :1433
```

## Required Environment Variables

- `SQLSERVER` — SQL Server connection string
- `APP_RUN_DELAY` — (optional) startup delay in ms, used to wait for DB readiness in Docker

## Architecture

### Backend (climate/)

ASP.NET Core 6.0 Web API + SPA host. Top-level `Program.cs` (minimal hosting).

**Controllers** (under `Controllers/`):
- `ExternalController` — serves weather + news from seed data in the database (no external API calls)
- `HistoryController` — CRUD for search history (GET all, POST new)
- `TestController` — health check

**Data layer** (under `Models/`):
- `AppDbContext` — EF Core DbContext with auto-migration on startup
- `History` → `Location` (one-to-many) — tracks searches and associated locations
- SQL Server with EF Core lazy-loading proxies
- Circular references handled via Newtonsoft.Json `ReferenceLoopHandling.Ignore`

**DI setup**: `CustomExtension.cs` registers DbContext with connection string from `SQLSERVER` env var.

Swagger UI available in Development mode at `/swagger`.

### Frontend (climate/ClientApp/)

Create React App with TypeScript, Material-UI v5, Axios, SCSS.

- `src/Session/` — React Context providing API state (prepare/fetchLocation actions)
- `src/App/` — main dashboard displaying weather + news
- `src/App/Bar/` — top nav with search input and history drawer
- `src/api/` — Axios-based API client with TypeScript types
- Uses custom packages `mp48-react` (state management) and `mp48-cra` (CRA tooling)

### Integration

The .NET backend serves the built React SPA from `ClientApp/build/` via `UseSpa()`. API routes follow the `{controller}/{action}/{id?}` convention.
