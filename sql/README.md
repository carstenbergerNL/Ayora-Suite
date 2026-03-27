# SQL Server Schema

## Files

- `main.sql`: **Full current schema** (idempotent; always reflects the latest state)
- `alter/`: incremental migration scripts (append-only)

## Rules

- Any schema change must be reflected in **`main.sql`**.
- For incremental history, add a corresponding script under `alter/` (named with a sortable prefix, e.g. `2026-03-27_add_table_x.sql`).
- Keep seed data (e.g. default roles) idempotent.

