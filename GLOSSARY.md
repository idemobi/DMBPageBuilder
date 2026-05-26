# DMBPageBuilder Glossary

## Project-specific section

When copying this file to another PageBuilder ecosystem project, update this section first.

- Project name: `DMBPageBuilder`
- Project role: foundational page rendering package for the PageBuilder ecosystem.
- Publication host: `labs_idemobi_com`

## DMBPageBuilder

Foundational package providing page metadata, HTML builder, Razor helper, asset registration, and rendering lifecycle primitives for PageBuilder ecosystem modules.

## XML HeaderDoc

C# XML documentation comments attached to public API elements, used for API understanding and extraction.

## DocumentationBuilder-first

Authoring approach where documentation is structured to be programmatically extracted and rendered.

## PageInformation

Page-level model used to collect metadata, body information, scripts, stylesheets, icons, schema.org data, and rendering information before the final layout renders.

## PageBuilder

Rendering coordinator that turns collected page information and Razor content into the final page output.

## HTML Builder

Fluent object used to configure and render HTML tags or page artifacts in a consistent, strongly typed way.

## Razor Helper

Extension method exposed to `.cshtml` files so views can create PageBuilder components and rendering artifacts without manual tag construction.

## Publication Host

Target web project where extracted documentation is rendered (`labs_idemobi_com`).
