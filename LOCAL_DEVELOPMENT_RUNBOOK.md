# DMBPageBuilder Local Development Runbook

## Purpose

Guide local development for `DMBPageBuilder` changes.

## Project-specific section

When copying this file to another PageBuilder ecosystem project, update this section first.

- Project name: `DMBPageBuilder`
- Main code areas: `New_PageInformation/`, `Components/`, `HtmlHelpers/`, `Controllers/`, `Registers/`, `WebAssets/`, `Facades/`, `Models/`, and `Tools/`.
- Main risk areas: rendered HTML output, metadata ordering, asset registration, Razor helper contracts, and fluent builder behavior.
- Documentation target: `labs_idemobi_com`

## Typical workflow

1. Update rendering, builder, helper, page model, or related resource code.
2. Update XML HeaderDoc for changed public API surface.
3. Update local markdown docs (`README`, rules, checklists) if behavior changed.
4. Validate downstream usage in nearest consumers.
5. Hand off for developer-run DocumentationBuilder generation.

## Common checks

- Resource key consistency in `Resources/*.resx`.
- Namespace and public contract consistency.
- Null/argument validation behavior.
- Rendered HTML, metadata, and asset ordering expectations.
- Razor helper discoverability and usage consistency.

## Documentation handoff checks

- Documentation structure is extraction-ready.
- Examples are self-contained.
- Audience (developers + AI) is respected.
