# MovieApi-Refactor — Learning by Refactoring

En mini-övning för att bygga djup intuition kring lagerarkitektur i ASP.NET Core Web API — genom **kontinuerlig refaktorering**.

## Pedagogisk idé

Vi börjar med det **enklaste som funkar** — en fungerande endpoint på så få rader som möjligt. Sen refaktorerar vi, men bara när vi känner smärtan av att inte ha refaktorerat.

Varje refaktorering föregås av:

1. **Vad är problemet?** — vi ser vad som är jobbigt just nu
2. **Vilket lager löser det?** — vi introducerar ETT lager i taget
3. **Var kommer datan ifrån, vart skickas den?** — vi ritar flödet efter varje refaktorering

**Två refaktoreringspass:**
- **Fas 2–12:** Refaktorering till **mappar** — låg friktion, snabb progression
- **Fas 13:** Refaktorering till **projekt** — kompilatorn tvingar arkitekturen

Samma refaktorering görs två gånger — först lätt, sen på riktigt. Repetition = internalisering.

## Miljö

- .NET 10, ASP.NET Core Web API (controller-based)
- EF Core + SQLite (code-first)
- `dotnet` CLI, `gh` CLI, `git`
- Kulala.nvim för `.http`-tester
- LazyVim/Neovim

## Sessionsregler

- **Ett steg åt gången.** Nästa när jag säger "nästa" eller "kör".
- **Verifiering efter varje steg.** `dotnet build` eller Kulala-anrop.
- **Commit efter varje steg.** Mönster: `Fas N Steg X: <vad>. Closes #<issue>`
- **Efter varje refaktorering:** flödesbeskrivning ("var är vi, var kommer datan ifrån, vart går den").

## Faser

### FAS 1 — Enklaste möjliga endpoint 🎯

Ett projekt. Allt i rotmappen. Ingen ceremoni. Mål: `GET /movies` returnerar data.

**Efter fas 1:**
```
HTTP → MoviesController → MovieContext → SQLite
```

### FAS 2 — Refaktorering: Mappar

**Problem:** Alla filer i rotmappen. Ohanterbart snart.
**Lösning:** Organisera i `Entities/`, `Data/`, `Controllers/`.

### FAS 3 — Refaktorering: Repository-mönstret

**Problem:** Controllern innehåller EF Core-kod. Byta databas eller testa utan riktig databas är omöjligt.
**Lösning:** `IMovieRepository` som fasad över DbContext.

### FAS 4 — Refaktorering: UnitOfWork

**Problem:** Med flera repositories kommande — vem ansvarar för transaktion och `SaveChanges`?
**Lösning:** `IUnitOfWork` samlar repositories + `CompleteAsync()`.

### FAS 5 — Refaktorering: Service-lager

**Problem:** Var placeras affärslogik? Inte i controller (HTTP), inte i repository (data).
**Lösning:** Service-lager mellan controller och UnitOfWork.

### FAS 6 — Fler entities

Lägg till Actor och Review. Repetera mönstret. Bevisa att arkitekturen skalar.

### FAS 7 — Refaktorering: ServiceManager

**Problem:** Controllers behöver ofta flera services — konstruktorn växer.
**Lösning:** `IServiceManager` som fasad över alla services.

### FAS 8 — Refaktorering: DTOs

**Problem:** Vi skickar entities direkt via API — läckage av interna fält, tight coupling mellan databas och klienter.
**Lösning:** Data Transfer Objects — separata typer för API-lagret.

### FAS 9 — Refaktorering: AutoMapper

**Problem:** Manuell mappning entity ↔ DTO är repetitiv och felkänslig.
**Lösning:** AutoMapper med profiles.

### FAS 10 — Refaktorering: Validering + felhantering

**Problem:** Ogiltiga inputs sparas, saknade resurser kraschar eller tystas.
**Lösning:** Data annotations på DTOs + custom exceptions + global exception handler.

### FAS 11 — Refaktorering: JWT Auth

**Problem:** Alla kan skriva till API:et.
**Lösning:** JWT Bearer + `dotnet user-jwts` + `[Authorize]` + policies.

### FAS 12 — Refaktorering: Tester

**Problem:** Manuell Kulala-verifiering efter varje refaktorering är opålitligt.
**Lösning:** xUnit unit tests med Moq + integration tests med `WebApplicationFactory`.

### FAS 13 — 💥 Splitta i 4 projekt

**Nu — och först nu — förstår du varför man vill ha projekt-per-lager.**

Slutstruktur:
```
Movie.Domain/          ← Entities + repo-interfaces + custom exceptions
Movie.Application/     ← Service-interfaces + services + DTOs + mapping
Movie.Infrastructure/  ← DbContext + repositories + UnitOfWork
Movie.Api/             ← Controllers + Program.cs + auth-config
Movie.Api.Tests/       ← xUnit tests
```

Beroendepilar:
```
Api → Application → Domain
Api → Infrastructure → Domain
Application och Infrastructure känner INTE varandra
```

När `Movie.Domain` inte har någon EF Core-referens och ändå fungerar — då förstår du hela grejen.

## Vad du lär dig efter varje fas

| Efter fas | Du förstår |
|---|---|
| 1  | Web API + EF Core, minsta möjliga |
| 2  | Mappar organiserar men tvingar inget |
| 3  | Repository döljer datalager |
| 4  | UnitOfWork = transaktioner |
| 5  | Service = affärslogik separerad |
| 6  | Mönstret skalar — nya entities är billiga |
| 7  | ServiceManager = injektion skalar |
| 8  | DTOs = API-modell vs domän-modell |
| 9  | AutoMapper = mindre boilerplate |
| 10 | Validering + felhantering centralt |
| 11 | Auth = middleware, JWT-tokens via `dotnet user-jwts` |
| 12 | Interfaces = mockbara → Clean Architecture klickar |
| 13 | Projekt = kompilator-tvingad arkitektur |

## Vad detta INTE innehåller (medvetet)

- ❌ Minimal APIs — separat övning (`MovieApi-Minimal`)
- ❌ MongoDB — separat övning (`MovieApi-Mongo`)
- ❌ Azure deploy — separat övning (`MovieApi-Azure`)
- ❌ Logging/monitoring, API-versionering

Fokus här: **arkitektur och flow, från noll till Clean Architecture**.

## Referenser

Denna slutstruktur matchar:
- Jason Taylor's Clean Architecture template (GitHub, 17k+ stars)
- Microsoft's eShopOnWeb
- 90% av moderna .NET-produktionsprojekt
