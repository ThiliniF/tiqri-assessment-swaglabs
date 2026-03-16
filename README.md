# Swag Labs E2E Test Automation

End-to-end test suite for [Swag Labs](https://www.saucedemo.com) built with Reqnroll (BDD), Selenium WebDriver, and NUnit.

## Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- Google Chrome (latest)
- Visual Studio 2022 or above

## Setup

### 1. Clone the repository

```bash
git clone git@github.com:ThiliniF/tiqri-assessment-swaglabs.git
cd SwagLabsAssessment
```

### 2. Configure credentials

Create a .env file in the project root and add the following:

```
Username=standard_user
Password=secret_sauce
```

▎ The .env file is gitignored and must be created manually. Tests will fail to start without it.

### 3. Restore dependencies

```
dotnet restore src/SwagLabs.slnx
```

#### Run all E2E tests:

```
dotnet test src/SwagLabs.Definitions/SwagLabs.Definitions.csproj --filter "Category=e2e"
```

#### Run only happy path tests:

```
dotnet test src/SwagLabs.Definitions/SwagLabs.Definitions.csproj --filter "Category=happy-path"
```

#### Run only negative tests:

```
dotnet test src/SwagLabs.Definitions/SwagLabs.Definitions.csproj --filter "Category=negative"
```

### Project Structure

```
src/
├── SwagLabs.Core/ # Driver factory, configuration, wait helpers
├── SwagLabs.PageObjects/ # Page Object Model (pages + components)
└── SwagLabs.Definitions/ # Reqnroll feature files, step definitions, hooks
├── Features/
│ ├── Login/
│ └── Checkout/
├── Steps/
└── Hooks/
```

### CI/CD

Tests run automatically on push and pull requests to main via GitHub Actions.
Test results are published to the Github actions.

Secrets required in GitHub:

```
- SWAG_LABS_PASSWORD — stored as a secret
- SWAG_LABS_USERNAME — stored as a variable (vars)
```

### Assumptions & Considerations

- Tests run against the public demo site at https://www.saucedemo.com using the standard_user account.
- Each scenario starts a new browser instance and resets application state via the sidebar menu after completion.
- Tests run headless in CI and headed locally. This is detected automatically via the CI environment variable.
- The default browser is Chrome. This can be changed in src/SwagLabs.Core/appsettings.json by setting "Browser" to "Firefox" or "Edge"
- Test scenarios cover expected
  behaviour for the `standard_user` account only
- There are some bugs in the system and have not considered them when implementing test scenarios as this is a demo website
