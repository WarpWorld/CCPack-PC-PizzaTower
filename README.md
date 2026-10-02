# Pizza Tower

## Pack metadata

- **Game:** PizzaTower
- **Crowd Control game ID:** `PizzaTower`
- **Connector:** `PCConnector`

This folder contains the C# Crowd Control pack definition and patch artifacts for **Pizza Tower**.

## Connector and setup

`PizzaTower.cs` is an `InjectEffectPack` with a `PizzaTower` process profile. Start the matching executable before testing. The included `data.win` and delta files are assets; no installation procedure is documented.

## Layout

- `PizzaTower.cs` — injected pack definition and memory effects.
- `data.win` and `pizzaTower.xdelta.*` — game data and patch artifacts.

## Development

Recheck memory signatures and offsets after game-data changes; use the existing version profile when testing.
