# DMBPageBuilder Project Map

## Project-specific section

When copying this file to another PageBuilder ecosystem project, update this section first.

- Project name: `DMBPageBuilder`
- Project root folder: `DMBPageBuilder`
- Main role: foundational page rendering package.
- Important folders: `New_PageInformation/`, `Components/`, `HtmlHelpers/`, `Controllers/`, `Registers/`, `WebAssets/`, `Facades/`, `Models/`, `Tools/`, `Resources/`, and `wwwroot/`.
- Documentation target: `labs_idemobi_com`

## Folder responsibilities

- `Components/`
  - Fluent HTML component builders and shared rendering infrastructure.
  - `Bases/`: abstract builder foundations such as `HtmlBuilderBase<TBuilder>`, `HtmlTagBuilder<TBuilder>`, constrained builders, and void-tag builders.
  - `HtmlTagBuilder/`: builders for standard non-void HTML elements such as anchors, sections, forms, scripts, media, and text elements.
  - `HtmlVoidTagBuilder/`: builders for HTML void elements such as `meta`, `link`, `img`, `input`, `br`, and `hr`.
  - `HtmlConstrainedTagBuilder/`: builders whose valid rendering context is constrained, such as table, list, select, option, and fieldset-related elements.
  - `Comment/`: HTML comment builder support.
  - Custom class composition helpers used by builders that expose class customization.

- `Configuration/`
  - PageBuilder configuration and static-file post-configuration for embedded package assets.

- `Controllers/`
  - MVC base controller support for preparing `PageInformation` before a request renders.

- `Facades/`
  - Public contracts used by PageBuilder components, action items, style/class composition, and rendering integrations.

- `HtmlHelpers/`
  - Razor extension methods that expose PageBuilder components and utility output to `.cshtml` files.

- `Models/`
  - Shared enums and value objects used by rendering, icons, HTML versions, variants, JavaScript tags, link tags, and render context tracking.

- `New_PageInformation/`
  - Page model and page rendering pipeline.
  - Includes `PageInformation`, `PageBuilder`, metadata definitions, script/style definitions, favicon definitions, body rendering contracts, alert helpers, schema.org integration, and page-level Razor helpers.

- `Registers/`
  - Request-scoped registration and lookup for `PageInformation`.

- `Resources/`
  - Internal and data-annotation localization `.resx` assets for `DMBPageBuilder`.

- `Tools/`
  - Utility helpers for HTML identifiers, rendering context, and region-related behavior.

- `WebAssets/`
  - Global web asset registry for scripts and stylesheets shared across rendered pages.

- `wwwroot/`
  - Embedded static assets (`css`, `js`) served through package static-file configuration.

- `.ai/` and `.aiassistant/`
  - Local AI-assistant support metadata when present. Do not treat generated assistant state as project source.

- `bin/` and `obj/`
  - Build outputs and intermediate files. Do not use these folders as documentation or source-of-truth inputs.

## Documentation-related files

- `README.md`: package overview and usage context.
- `AGENTS.md`: local AI rules and scope for this package.
- `AI_CONTEXT.md`: additional context for AI-assisted maintenance.
- `DOCUMENTATION_RULES.md`: strict documentation policy.
- `DRAWIO_DIAGRAM_RULES.md`: rules for editable Draw.io diagrams used by documentation, concept, instruction, example, and tutorial pages.
- `EXAMPLES_AND_TUTORIALS_RULES.md`: rules for example pages and tutorials only.
- `DELIVERY_CHECKLIST.md`: final quality gate before handoff.
- `ARCHITECTURE_DECISIONS.md`: local architecture decisions and constraints.
- `GLOSSARY.md`: shared vocabulary for this package.
- `LOCAL_DEVELOPMENT_RUNBOOK.md`: local workflow notes and handoff checks.
- `LOCALIZATION_NOMENCLATURE.md`: localization key naming rules for this package.
- `TROUBLESHOOTING.md`: known issues and recovery notes.
