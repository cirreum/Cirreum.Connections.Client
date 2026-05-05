namespace Cirreum.Connections.Client;

/// <summary>
/// Connection state of a realtime client.
/// </summary>
public enum RealtimeClientState {

	/// <summary>Not connected. Initial state and terminal state after explicit disconnect.</summary>
	Disconnected,

	/// <summary>Connection attempt in progress (first connect).</summary>
	Connecting,

	/// <summary>Connection established and active.</summary>
	Connected,

	/// <summary>Connection lost; automatic reconnection in progress.</summary>
	Reconnecting

}
