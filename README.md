> [!WARNING]
> **This package is deprecated and this repository is archived.**
>
> The runtime extension packages named below — `Cirreum.Runtime.Connections.SignalR.Wasm`, `Cirreum.Runtime.Connections.WebSockets.Wasm`, and `Cirreum.Runtime.Connections.Wasm` — **were never published and do not exist.**
>
> The caller side of a long-lived Cirreum connection ships today as `Cirreum.RemoteConnections.SignalR`
> and `Cirreum.RemoteConnections.WebSockets`, registered through
> `Cirreum.Runtime.RemoteConnections.SignalR` / `Cirreum.Runtime.RemoteConnections.WebSockets`. The
> server side ships in `Cirreum.Services.Server`.
>
> Everything below this line is retained as a historical record and does not describe a supported
> package.

---

# Cirreum.Connections.Client

[![NuGet Version](https://img.shields.io/nuget/v/Cirreum.Connections.Client.svg?style=flat-square&labelColor=1F1F1F&color=003D8F)](https://www.nuget.org/packages/Cirreum.Connections.Client/)
[![NuGet Downloads](https://img.shields.io/nuget/dt/Cirreum.Connections.Client.svg?style=flat-square&labelColor=1F1F1F&color=003D8F)](https://www.nuget.org/packages/Cirreum.Connections.Client/)
[![GitHub Release](https://img.shields.io/github/v/release/cirreum/Cirreum.Connections.Client?style=flat-square&labelColor=1F1F1F&color=FF3B2E)](https://github.com/cirreum/Cirreum.Connections.Client/releases)
[![License](https://img.shields.io/github/license/cirreum/Cirreum.Connections.Client?style=flat-square&labelColor=1F1F1F&color=F2F2F2)](https://github.com/cirreum/Cirreum.Connections.Client/blob/main/LICENSE)
[![.NET](https://img.shields.io/badge/.NET-10.0-003D8F?style=flat-square&labelColor=1F1F1F)](https://dotnet.microsoft.com/)

**Client-side abstractions for long-lived Cirreum connections**

## Overview

**Cirreum.Connections.Client** defines the client-side abstractions for maintaining long-lived bidirectional connections to a Cirreum server. It provides the `IRealtimeClient` interface and `RealtimeClientBase` with connection lifecycle management, automatic reconnection, and state tracking.

This package is transport-agnostic and host-neutral. For concrete transport implementations, install a runtime extension:

- `Cirreum.Runtime.Connections.SignalR.Wasm` — SignalR client for Blazor WASM
- `Cirreum.Runtime.Connections.WebSockets.Wasm` — raw WebSocket client for Blazor WASM
- `Cirreum.Runtime.Connections.Wasm` — both client transports

## Key Abstractions

| Type | Purpose |
|---|---|
| `IRealtimeClient` | Client-side interface for a long-lived connection (connect, disconnect, send, state) |
| `RealtimeClientBase` | Base class with lifecycle management, reconnect logic, and state tracking |
| `RealtimeClientState` | Connection state: `Disconnected`, `Connecting`, `Connected`, `Reconnecting` |

## Contribution Guidelines

1. **Be conservative with new abstractions**  
   The API surface must remain stable and meaningful.

2. **Limit dependency expansion**  
   Only add foundational, version-stable dependencies.

3. **Favor additive, non-breaking changes**  
   Breaking changes ripple through the entire ecosystem.

4. **Include thorough unit tests**  
   All primitives and patterns should be independently testable.

5. **Document architectural decisions**  
   Context and reasoning should be clear for future maintainers.

6. **Follow .NET conventions**  
   Use established patterns from Microsoft.Extensions.* libraries.

## Versioning

Cirreum.Connections.Client follows [Semantic Versioning](https://semver.org/):

- **Major** - Breaking API changes
- **Minor** - New features, backward compatible
- **Patch** - Bug fixes, backward compatible

Given its foundational role, major version bumps are rare and carefully considered.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

---

**Cirreum Foundation Framework**  
*Layered simplicity for modern .NET*
