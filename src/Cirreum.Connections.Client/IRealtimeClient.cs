namespace Cirreum.Connections.Client;

/// <summary>
/// Client-side abstraction for a long-lived bidirectional connection to a Cirreum server.
/// Transport-specific implementations (SignalR <c>HubConnection</c>, raw <c>ClientWebSocket</c>)
/// are provided by L5 runtime extension packages.
/// </summary>
public interface IRealtimeClient : IAsyncDisposable {

	/// <summary>Current connection state.</summary>
	RealtimeClientState State { get; }

	/// <summary>Raised when <see cref="State"/> changes.</summary>
	event Action<RealtimeClientState>? StateChanged;

	/// <summary>
	/// Establish the connection. Throws if the connection cannot be established.
	/// </summary>
	Task ConnectAsync(CancellationToken cancellationToken = default);

	/// <summary>
	/// Gracefully close the connection.
	/// </summary>
	Task DisconnectAsync(CancellationToken cancellationToken = default);

	/// <summary>
	/// Send a payload to the server. Fire-and-forget; no expected response.
	/// </summary>
	ValueTask SendAsync<T>(T payload, CancellationToken cancellationToken = default);

	/// <summary>
	/// Register a typed handler for a named server method. Dispose the returned
	/// handle to unregister. Maps to SignalR's <c>HubConnection.On&lt;T&gt;</c>;
	/// raw WebSocket adapters route by a message-type discriminator field.
	/// </summary>
	IDisposable On<T>(string method, Func<T, Task> handler);

}
