(GPT-5 mini)
--------
Can GitHub support workflow with testing and deploing .NET web application?
--------
Yes — GitHub Actions can run CI/CD for .NET web apps (including Blazor). It can restore, build, test, publish, and deploy to targets like Azure App Service, Azure Static Web Apps, Docker registries, or GitHub Pages.
Quick overview
•	Use actions/checkout and actions/setup-dotnet to run .NET commands.
•	Run dotnet restore, dotnet build, dotnet test, and dotnet publish.
•	Cache NuGet packages with actions/cache to speed builds.
•	Deploy with official actions: azure/webapps-deploy, azure/static-web-apps-deploy, or Docker actions / peaceiris/actions-gh-pages for static Blazor WASM.
•	Store credentials (publish profiles, service principals, Docker creds) in repository Secrets.
Minimal example workflow (.github/workflows/ci-cd.yml)
```
name: CI/CD

on: [push, pull_request]

jobs:
  build:
    runs-on: ubuntu-latest
    steps:
      - uses: actions/checkout@v4
      - uses: actions/setup-dotnet@v4
        with:
          dotnet-version: '10.x'
      - run: dotnet restore
      - run: dotnet build --no-restore -c Release
      - run: dotnet test --no-build -c Release
      - run: dotnet publish -c Release -o ./publish
      - name: Deploy to Azure Web App
        uses: azure/webapps-deploy@v2
        with:
          app-name: your-app-name
          publish-profile: ${{ secrets.AZURE_WEBAPP_PUBLISH_PROFILE }}
          package: ./publish
```
If you want, I can add a ready-to-use workflow for this Blazor project (specify Blazor Server vs Blazor WASM and your deployment target).
--------
Is GitHub Pages service free?
--------
Yes. GitHub Pages is free for hosting static sites from public repositories (personal, org, or project sites). You get free HTTPS and custom domain support.
Notes:
•	Pages from private repositories depend on your GitHub plan (some paid plans include it).
•	If you build your site with GitHub Actions, the build uses Actions minutes which are subject to your plan’s quotas.
•	GitHub Pages only hosts static sites — Blazor WebAssembly works fine, but Blazor Server (server-side) needs a different host (Azure, etc.).
--------
