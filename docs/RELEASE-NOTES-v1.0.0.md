# Release Notes — Cirreum.Connections.Client v1.0.0

Initial release of the client-side abstractions for long-lived Cirreum connections.

## What's in this release

- **`IRealtimeClient`** — client-side interface for a long-lived bidirectional connection (connect, disconnect, send, state tracking). Implements `IAsyncDisposable`.
- **`RealtimeClientBase`** — abstract base class with connection lifecycle management, state transitions, and reconnection scaffolding. Transport-specific subclasses override `ConnectCoreAsync`, `DisconnectCoreAsync`, and `SendAsync<T>`.
- **`RealtimeClientState`** — connection state enum: `Disconnected`, `Connecting`, `Connected`, `Reconnecting`.

## Design references

- [ADR-0001 — Cirreum.Connections](https://github.com/cirreum/DevOps/blob/main/docs/adr/0001-realtime-connections.md)
- [Implementation Specification](https://github.com/cirreum/DevOps/blob/main/docs/Connections/01-DESIGN.md)
