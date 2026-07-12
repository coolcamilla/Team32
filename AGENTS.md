# AGENTS.md

Instructions for coding agents (e.g. Claude, Copilot, other LLM-based tools) working in this repository. This file follows the [agents.md](https://agents.md/) convention. Human contributors should read [`CONTRIBUTING.md`](CONTRIBUTING.md) instead - this file is agent-facing operating guidance, not project onboarding.

## Setup

- This is a **Unity project** pinned to **Unity Editor 6000.4.10f1** (see `ProjectSettings/ProjectVersion.txt`). Agents without a Unity Editor available cannot build or run the project directly, but can still read, edit, and reason about C# source under `Assets/Scripts/`.
- No environment variables, API keys, or secrets are needed for local setup - this project has no backend and no runtime network dependency.

## Build, Test, and Verification Commands

- **Unity Test Runner** (EditMode/PlayMode tests): run via the Unity Editor GUI, or headlessly via `Unity -batchmode -runTests -testPlatform <editmode|playmode> ...` (see the CI workflow files under `.github/workflows/` for exact invocation).
- **Static analysis**: `dotnet build static-analysis/StaticAnalysis.csproj --no-restore` - this is an isolated .NET project that compiles and analyzes only the pure C# logic classes (files matching `*Logic.cs`) against `UnityStubs.cs`, using Roslyn `NetAnalyzers`.
  - **Known failure mode agents should watch for:** `static-analysis/StaticAnalysis.csproj` uses an explicit `<Compile Include>` list, not a glob. If you rename, move, or delete a `*Logic.cs` file, you must update this list manually, or the build will fail with `CS2001: Source file ... could not be found`. This has caused real CI failures before.
  - Do **not** add `using NUnit.Framework;` or any test-framework reference to a production logic class - `StaticAnalysis.csproj` has no NUnit reference, and this specific mistake has broken CI in this repository before.

## Repository Workflow and Review Expectations

- Branch names: `<issue-number>-short-description`. Link work to a GitHub issue where one exists.
- All merges into `main` use a **merge commit** - never squash or rebase.
- Every PR needs approval from a team member other than the author before merging; an agent should not merge its own PR without human review, even if all CI checks pass.
- Keep the branch up to date with `main` before merging - a PR passing CI on an outdated branch does not guarantee `main` stays green afterward.
- If a change is user-visible, add an entry to `CHANGELOG.md` under `[Unreleased]`.

## Sensitive-Data, Credential, and Safety Cautions

- This project has **no runtime secrets or credentials** to handle - there is no backend, so there is nothing to accidentally leak via configuration files.
- Do not commit large binaries, build output (`Library/`, `Temp/`, `Build/`), or IDE-specific files - see `.gitignore` for the current exclusion list.
- Do not fabricate test data, coverage numbers, or claims about what a file contains - if you cannot verify something (e.g. a class's real implementation) by reading the actual source, say so rather than guessing. This repository's documentation has previously contained inaccuracies from assumptions that weren't checked against real source - treat this as a standing caution, not a hypothetical.

## Where to Go Next

- [`docs/development-process.md`](docs/development-process.md) - full git workflow, CI pipeline, configuration management
- [`docs/architecture/README.md`](docs/architecture/README.md) - codebase structure and the ADRs explaining key decisions
- [`docs/testing.md`](docs/testing.md) - current test suite, coverage, and known gaps
- [`docs/definition-of-done.md`](docs/definition-of-done.md) - completion criteria for any PBI
