# Material Catalog Phase 1 Backend Summary

## Scope

This phase prepares backend/domain infrastructure for the target flow:

`MaterialFamily -> MaterialForm -> MaterialStandard -> Material -> StockCard -> StockPrice`

Controller, Razor view, Ajax endpoints, and EF migration files are intentionally left for the next phase.

## Added entities

- `MaterialCatalog.MaterialFamily`
- `MaterialCatalog.MaterialStandard`
- `MaterialCatalog.MaterialMechanicalProperty`

## Updated existing entities

- `Material` now has optional catalog relationships and grade fields while keeping legacy `Name` and `Forms` intact.
- `MaterialForm` keeps its legacy detail-role fields and receives optional catalog master fields (`Name`, `Code`, `Description`, `IsActive`) to avoid data loss during transition.
- `StockCard` now supports optional material linkage and long stock codes through `MaterialId`, `StockCode`, `Unit`, and `IsActive`.
- `StockCardPrice` now supports `PriceDate`, nullable supplier metadata, and existing price history fields.

## Migration risks / follow-up decisions

- Existing `MaterialForm` is currently used as a material-specific detail table, not a pure master table. A future migration must decide whether to split it into a clean master `MaterialForm` table or keep the transition fields.
- Existing `StockCard` has product-code required fields (`SProductGroupId`, `SProductId`, `StockSequenceId`, `StockCode8`). Material stock cards can use the added optional fields, but a migration must decide whether these legacy required fields should be nullable for pure material stock cards.
- No migration file was generated in this phase because the current environment does not have the `dotnet` CLI installed.
- StockCard/StockPrice seed data was not added yet because existing `StockCard` seeds require the stock-code product hierarchy to be present.

## Before UI phase

Confirm these decisions before creating Admin CRUD screens:

1. Should `MaterialForm` be split into a pure master table and a separate material-form-availability/detail table?
2. Should material stock cards reuse existing `StockCard` with nullable product fields, or should a separate `MaterialStockCode` be created?
3. Should active price overlap be enforced with service validation only, or also with database constraints/triggers?
