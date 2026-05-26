# DMBPageBuilder Troubleshooting

## Project-specific section

When copying this file to another PageBuilder ecosystem project, update this section first.

- Project name: `DMBPageBuilder`
- Main troubleshooting areas: page metadata, rendering lifecycle, fluent HTML builders, Razor helpers, localization resources, and web asset registration.
- Resource folder: `Resources/`
- Documentation target: `labs_idemobi_com`

## Localization key fallback text appears

### Symptoms

- UI displays token-like fallback text instead of translated labels.

### Checks

1. Confirm key exists in `Resources/*.resx`.
2. Confirm key naming follows `LOCALIZATION_NOMENCLATURE.md`.
3. Confirm the expected localizer context is used.

## Page metadata does not appear in the rendered output

### Checks

1. Confirm the expected `PageInformation` instance is registered for the request.
2. Confirm the controller initializes page information before the layout renders.
3. Confirm metadata keys are not overwritten later in the request.

## Fluent builder output is missing expected attributes or classes

### Checks

1. Confirm the fluent method sets, replaces, or removes the value as expected.
2. Confirm conditional builder calls are executed before rendering.
3. Confirm custom class composition does not override the expected class.

## Script or stylesheet is missing or duplicated

### Checks

1. Verify the web asset registration key.
2. Verify asset ordering and location rules.
3. Verify the layout renders the corresponding asset region.

## Documentation output quality is weak

### Checks

1. Confirm docs follow `DOCUMENTATION_RULES.md` structure.
2. Confirm examples are self-contained and realistic.
3. Confirm headings are deterministic for extraction.
4. Confirm audience needs (developers + AI) are addressed.
