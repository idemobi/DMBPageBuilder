# DMBPageBuilder

## Purpose

`DMBPageBuilder` is the foundational page rendering package for the PageBuilder ecosystem.

It centralizes reusable primitives for:

- describing page-level metadata through `PageInformation`,
- composing HTML documents from Razor views,
- rendering strongly typed HTML tag builders,
- registering scripts, stylesheets, metadata, icons, and schema.org data,
- coordinating body, header, main, and footer rendering,
- exposing reusable Razor helpers for page and element composition.

## Project-specific section

When copying this file to another PageBuilder ecosystem project, update this section first.

- Project name: `DMBPageBuilder`
- Project folder: `DMBPageBuilder`
- Project role: foundational page rendering package.
- Main consumers: `labs_idemobi_com` and PageBuilder ecosystem packages.
- Documentation target: DocumentationBuilder output rendered in `labs_idemobi_com`.

## Audience

- Primary audience: developers integrating or maintaining the package.
- Secondary audience: AI assistants (Codex, Claude, Junie, and similar tools) that produce technical documentation and code updates.

## Scope

- `Components/`: fluent HTML builders for standard HTML tags, constrained tag contexts, comments, custom classes, and shared builder behavior.
- `HtmlHelpers/`: Razor helper extensions that expose PageBuilder components and utility output.
- `Controllers/`: base controller support for initializing and publishing page information during MVC requests.
- `Registers/`: request-scoped page information storage and retrieval.
- `WebAssets/`: global web asset registry for links, scripts, and stylesheets shared across rendered pages.
- `Facades/`: public contracts used by builders, action items, style composers, and page-level integrations.
- `Models/`: page model, metadata definitions, script/style definitions, body rendering contracts, page rendering entry points, shared enums, and value objects used by rendering, icon, style, and action APIs.
- `Tools/`: utility helpers for identifiers, render context tracking, and region behavior.
- `Resources/`: package localization resources.
- `wwwroot/`: embedded static package assets.

## Technical baseline

- SDK: `Microsoft.NET.Sdk.Razor`
- Target framework: `net10.0`
- Nullable: enabled
- XML documentation output: enabled in `Debug`, `Release`, and `NuGet` configurations

## Global web assets

`IWebAssetRegistry` can register application-level assets that every `RawPageController` page imports before rendering.
Use `RegisterGlobalLinkAsset` for shared `PageLinkDefinition` entries such as manifests, icons, preloads, prefetches, or canonical links.
Use `RegisterGlobalScriptAsset` and `RegisterGlobalStylesheetAsset` for shared JavaScript and CSS files.

## Documentation strategy

This module follows a **DocumentationBuilder-first** strategy:

- Documentation must be authored for extraction/rendering by DocumentationBuilder.
- Publication target is `labs_idemobi_com`.
- AI prepares content and structure; the developer executes DocumentationBuilder.
- XML documentation must describe the public rendering contract, not only restate member names.
- Examples should use realistic Razor and page composition scenarios when behavior is user-facing.

## Related orientation files

- [AGENTS.md](AGENTS.md)
- [AI_CONTEXT.md](AI_CONTEXT.md)
- [PROJECT_MAP.md](PROJECT_MAP.md)
- [LOCALIZATION_NOMENCLATURE.md](LOCALIZATION_NOMENCLATURE.md)
- [DOCUMENTATION_RULES.md](DOCUMENTATION_RULES.md)
- [DRAWIO_DIAGRAM_RULES.md](DRAWIO_DIAGRAM_RULES.md)
- [EXAMPLES_AND_TUTORIALS_RULES.md](EXAMPLES_AND_TUTORIALS_RULES.md)
- [LOCAL_DEVELOPMENT_RUNBOOK.md](LOCAL_DEVELOPMENT_RUNBOOK.md)
- [DELIVERY_CHECKLIST.md](DELIVERY_CHECKLIST.md)
- [TROUBLESHOOTING.md](TROUBLESHOOTING.md)
- [GLOSSARY.md](GLOSSARY.md)
- [ARCHITECTURE_DECISIONS.md](ARCHITECTURE_DECISIONS.md)
