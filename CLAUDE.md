# CLAUDE.md

MovieApi-Refactor är en **inlärningsövning**: ett fungerande ASP.NET Core Web API
som byggs upp genom 13 medvetna refaktoreringsfaser (se `README.md`). Poängen är
att känna smärtan som motiverar varje lager *innan* det införs. Tidig kod är
medvetet naiv — förbättra den inte i förväg, före sin fas.

## Gyllene regler

- **Du skriver ingen kod och kör inga terminalkommandon.** Jag (användaren) kodar
  och kör allt själv i terminalen. Din roll: förklara, föreslå, rita flöden,
  granska — som en handledare.
- **Ett steg åt gången.** Gör bara det aktuella steget. Nästa steg först när jag
  säger "nästa" eller "kör".
- **Fråga innan du går utanför steget.** Föreslå gärna, men implementera inte
  otillfrågat.
- **Verifiera efter varje steg** med `dotnet build` (eller ett Kulala-anrop mot
  `.http` när det är relevant).
- **Föreslå ett commit-meddelande efter varje steg** enligt mönstret nedan — jag
  commit:ar själv.
- **Efter varje refaktorering:** ge en kort flödesbeskrivning — var är vi, var
  kommer datan ifrån, vart skickas den.

## Bygg & verifiera

- Bygg: `dotnet build`
- Kör: `dotnet run` (eller `dotnet watch` under utveckling)
- Migrations: `dotnet ef migrations add <Namn>` + `dotnet ef database update`
  - `dotnet ef` är ett **globalt** verktyg (inget lokalt manifest i repot ännu —
    ev. vid Fas 13)
  - `Microsoft.EntityFrameworkCore.Design` i `.csproj` krävs för att migrations
    ska fungera
- Manuell test: anropen i `MovieApi-Refactor.http` via Kulala.nvim
- Databas: SQLite, code-first; `.db`-filen skapas lokalt och ligger inte i git

## Commit-konventioner

Mönster: `Fas <N> Steg <X>: <beskrivning>. Closes #<issue>`

- Svenska, imperativ verbform: *Skapa, Implementera, Registrera, Refaktorera,
  Flytta, Ta bort, Byt namn*
- Versal begynnelsebokstav efter kolon, punkt före `Closes`
- En rad, ingen brödtext (om inte steget verkligen kräver förklaring)
- Flera issues: `Closes #41, closes #42`
- Undernummer (`Steg 2.2`) när ett steg delas upp
- En commit per steg
- Rena meddelanden — ingen `Co-Authored-By`-trailer

Exempel:

```
Fas 5 Steg 4: Registrera IServiceManager i DI. Closes #44
Fas 6 Steg 1: Skapa Actor-entity. Closes #45
```

## Kodkonventioner

C# / .NET 10, `Nullable` och `ImplicitUsings` på.

- **File-scoped namespaces** (`namespace MovieApi_Refactor.Data;`)
- **Primära konstruktorer** för DI
  (`public class MovieService(IUnitOfWork unitOfWork)`)
- **Expression-bodied members** för enradare
- **`Async`-suffix** på alla asynkrona metoder
- "Hittades inte" → returnera `null` (`Task<Movie?>`), inte exceptions
  (exceptions kommer Fas 10)
- Rot-namespace: `MovieApi_Refactor` (understreck — bindestreck är ogiltigt i
  namespace)
- **Mappnamn = namespace-segment:** `Entities/`, `Data/`, `Repositories/`,
  `Services/`, `Controllers/`
- En publik typ per fil, filnamn = typnamn. Interface prefixas `I`, ligger
  bredvid sin implementation

### Lageransvar

- **Controller** — HTTP in/ut, ingen affärslogik
- **Service** — affärslogik, orkestrerar repositories via UnitOfWork
- **Repository** — dataåtkomst, anropar **aldrig `SaveChanges`**
  (UnitOfWork:s ansvar)
- **UnitOfWork** — äger `SaveChangesAsync` via `CompleteAsync()`
- Entities skickas just nu direkt via API:et — **DTOs införs Fas 8**,
  AutoMapper Fas 9

## Fasdisciplin

- **Följ faserna i ordning.** Inför inte ett lager eller en teknik före sin fas —
  även om det "vore bättre".
- **Föreslå inte förbättringar som hör till en senare fas.** Om du ser något som
  löses senare: nämn kort vilken fas, gå inte vidare.
- **Naiv kod är avsiktlig** tills den fas som fixar den. Ingen
  drive-by-refaktorering.
- Om ett steg känns fel eller ur ordning — säg till, gör det inte ändå.
- Fasplanen och "vad du lär dig"-tabellen finns i `README.md`.

## Var ligger jag

- **GitHub Project:** MovieApi-Refactor, Project #9
  (https://github.com/users/xavidiaz/projects/9) — källan till vilket steg som
  är på tur
- **Issues:** ett issue per steg, mönster `Fas N Steg X: <vad>`. Aktuellt steg =
  lägsta öppna issue-numret i nuvarande fas
- **Fasplan & lärandemål:** `README.md`
- **Historik:** `git log --oneline` visar avklarade steg (commit stänger sitt
  issue via `Closes #<nr>`)

Vid sessionsstart: kolla senaste commit + öppna issues för att avgöra var vi är.
Fråga om det är oklart.
