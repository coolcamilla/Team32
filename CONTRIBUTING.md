# Contributing to Operation: EarthCore

This guide covers how to set up, verify, and submit changes to this repository. For the project overview and how to run the game, see [`README.md`](README.md). For deeper technical detail, see the links at the bottom of each section below.

## Setup

1. Install **Unity Hub** and **Unity Editor 6000.4.10f1** (the exact pinned version - see `ProjectSettings/ProjectVersion.txt`).
2. Clone the repository and open the project from its root in Unity.
3. No environment variables, API keys, or secrets are required to build or run this project locally - it has no backend or runtime network dependency.

See [`docs/development-process.md`](docs/development-process.md#reproducible-development-environment) for the full reproducible-environment notes.

## Verifying a Change Before Submitting

Run these before opening a pull request:

- **Unity Editor Play Mode** - manually verify your change behaves as expected in the actual scene.
- **Unity Test Runner** - run EditMode and PlayMode tests locally (`Window -> General -> Test Runner`) for any area your change touches.
- **Static analysis** - if you added or modified a plain C# logic class (anything under a `*Logic.cs` naming pattern), confirm it's included in `static-analysis/StaticAnalysis.csproj`'s `<Compile Include>` list, and run `dotnet build static-analysis/StaticAnalysis.csproj` locally. **This step is easy to forget** - a stale reference to a deleted logic file has broken CI before (see `docs/development-process.md`'s Configuration Management section for the real incident).
- **Coverage** - if your change touches `InventoryManager`, `CraftManager`, or `GridGenerator` (the current critical modules), make sure the change doesn't drop coverage below the required 30% threshold.

All of the above also run automatically in CI on your PR - see [`docs/testing.md`](docs/testing.md) and [`docs/development-process.md`](docs/development-process.md#ci-process) for the full pipeline.

## Branch and PR Workflow

- Branch names follow **`<issue-number>-short-description`** (e.g. `192-update-tests-week-5`).
- Every change should be linked to a GitHub issue. Work generally isn't started without one.
- Open a PR against `main` when your change is ready for review. Fill in the PR template, including what was implemented and how it was tested.
- **Keep your branch up to date with `main` before merging** - a PR passing its own CI does not guarantee `main` stays green after merging if the branch has drifted (this has happened before in this repo; see the PR #198/#210 note in `docs/development-process.md`).
- All PRs are merged into `main` using a **merge commit** - no squash or rebase merges.

## Review Expectations

- Every PR requires approval from **at least one team member other than the author** before merging.
- All CI checks (linting/static analysis, EditMode/PlayMode tests, QRTs, Lychee link checking) must pass before a PR is mergeable - this is enforced by branch protection on `main`.
- If your change is user-visible, add an entry to `CHANGELOG.md` under `[Unreleased]`.
- See [`docs/definition-of-done.md`](docs/definition-of-done.md) for the full completion checklist every PBI must satisfy.

## Where to Go Next

- [`docs/development-process.md`](docs/development-process.md) - full git workflow, CI pipeline, and configuration management
- [`docs/architecture/README.md`](docs/architecture/README.md) - how the codebase is structured, and why
- [`docs/testing.md`](docs/testing.md) - current test suite and coverage status
- [`docs/definition-of-done.md`](docs/definition-of-done.md) - what "done" means for a PBI
