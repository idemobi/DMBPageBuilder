# DMBPageBuilder AI Context

## What this module is

`DMBPageBuilder` is the foundational page rendering package used by PageBuilder ecosystem packages and web modules.

It should be treated as infrastructure-level rendering code with cross-module impact.

## Project-specific section

When copying this file to another PageBuilder ecosystem project, update this section first.

- Project name: `DMBPageBuilder`
- Project role: page metadata, rendering lifecycle, Razor helper, HTML builder, and web asset foundation.
- Primary consumers: `labs_idemobi_com` and ecosystem packages such as `DMBBootstrapBuilder`, `DMBComponentBuilder`, and `DMBFormBuilder`.
- Main documentation target: DocumentationBuilder output rendered in `labs_idemobi_com`.

## What this module is not

- Not a product-specific feature package.
- Not a Bootstrap-specific visual component package.
- Not a place for business-flow logic.
- Not a replacement for specialized component packages such as BootstrapBuilder, ComponentBuilder, or FormBuilder.

## Main responsibilities

- Page information and metadata modeling.
- HTML document and body rendering lifecycle support.
- Fluent HTML tag builders and constrained HTML builders.
- Razor helper extensions for PageBuilder components and utility output.
- Script, stylesheet, icon, metadata, and schema.org registration.
- Request-scoped page information registration.
- Embedded package static assets.

## Change strategy for AI

1. Identify whether change affects public rendering contracts, Razor helpers, fluent builders, or page metadata behavior.
2. Evaluate downstream impact before changing signatures, rendered HTML, ordering, or default behavior.
3. Prefer extension points over behavior replacement.
4. Update documentation in the same change set.

## Documentation strategy for AI

- Produce extraction-ready docs for DocumentationBuilder.
- Keep sectioning explicit and deterministic.
- Prefer examples that are realistic and directly mappable to package capabilities.
