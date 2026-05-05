# Changelog

All notable changes to **Cirreum.Connections.Client** will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.1.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [Unreleased]

### Added

- `IRealtimeClient` — client-side abstraction for a long-lived connection to a Cirreum server
- `IRealtimeClient.On<T>(string method, Func<T, Task> handler)` — method-keyed typed receive handler registration
- `RealtimeClientBase` — base class with connection lifecycle, reconnect, and state management
- `RealtimeClientState` — connection state enum (Disconnected, Connecting, Connected, Reconnecting)
