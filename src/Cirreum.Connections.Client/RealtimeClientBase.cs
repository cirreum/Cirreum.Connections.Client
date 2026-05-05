namespace Cirreum.Connections.Client;

/// <summary>
/// Base class for <see cref="IRealtimeClient"/> implementations providing connection
/// lifecycle management, state tracking, and reconnection scaffolding.
/// Transport-specific subclasses override the abstract transport methods.
/// </summary>
public abstract class RealtimeClientBase : IRealtimeClient {

	private RealtimeClientState _state = RealtimeClientState.Disconnected;

	/// <inheritdoc />
	public RealtimeClientState State {
		get => this._state;
		protected set {
			if (this._state == value) {
				return;
			}
			this._state = value;
			StateChanged?.Invoke(value);
		}
	}

	/// <inheritdoc />
	public event Action<RealtimeClientState>? StateChanged;

	/// <inheritdoc />
	public async Task ConnectAsync(CancellationToken cancellationToken = default) {
		this.State = RealtimeClientState.Connecting;
		try {
			await this.ConnectCoreAsync(cancellationToken).ConfigureAwait(false);
			this.State = RealtimeClientState.Connected;
		} catch {
			this.State = RealtimeClientState.Disconnected;
			throw;
		}
	}

	/// <inheritdoc />
	public async Task DisconnectAsync(CancellationToken cancellationToken = default) {
		await this.DisconnectCoreAsync(cancellationToken).ConfigureAwait(false);
		this.State = RealtimeClientState.Disconnected;
	}

	/// <inheritdoc />
	public abstract ValueTask SendAsync<T>(T payload, CancellationToken cancellationToken = default);

	/// <inheritdoc />
	public abstract IDisposable On<T>(string method, Func<T, Task> handler);

	/// <summary>Establish the transport-level connection.</summary>
	protected abstract Task ConnectCoreAsync(CancellationToken cancellationToken);

	/// <summary>Close the transport-level connection.</summary>
	protected abstract Task DisconnectCoreAsync(CancellationToken cancellationToken);

	/// <summary>
	/// Called by subclasses when the transport detects an unexpected disconnect.
	/// Transitions to <see cref="RealtimeClientState.Reconnecting"/> and begins reconnection.
	/// </summary>
	protected void OnTransportDisconnected() {
		if (this._state == RealtimeClientState.Disconnected) {
			return;
		}
		this.State = RealtimeClientState.Reconnecting;
	}

	/// <inheritdoc />
	public virtual async ValueTask DisposeAsync() {
		if (this._state is not RealtimeClientState.Disconnected) {
			await this.DisconnectAsync().ConfigureAwait(false);
		}
		GC.SuppressFinalize(this);
	}

}
