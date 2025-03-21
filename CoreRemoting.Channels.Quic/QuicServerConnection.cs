﻿using System;
using System.IO;
using System.Net.Quic;
using System.Text;
using System.Threading.Tasks;
using CoreRemoting.Threading;
using CoreRemoting.Toolbox;

namespace CoreRemoting.Channels.Quic;

/// <summary>
/// Quic server-side connection.
/// </summary>
public class QuicServerConnection : IRawMessageTransport
{
    private const int MaxMessageSize = QuicClientChannel.MaxMessageSize;

    /// <summary>
    /// Initializes a new instance of the <see cref="QuicServerConnection"/> class.
    /// </summary>
    public QuicServerConnection(QuicConnection connection, QuicStream stream, IRemotingServer remotingServer)
    {
        Connection = connection ?? throw new ArgumentNullException(nameof(connection));
        ClientStream = stream ?? throw new ArgumentNullException(nameof(stream));
        RemotingServer = remotingServer ?? throw new ArgumentNullException(nameof(remotingServer));
        ClientReader = new BinaryReader(stream, Encoding.UTF8, true);
        ClientWriter = new BinaryWriter(stream, Encoding.UTF8, true);
    }

    private QuicConnection Connection { get; set; }

    private QuicStream ClientStream { get; set; }

    private BinaryReader ClientReader { get; set; }

    private BinaryWriter ClientWriter { get; set; }

    private IRemotingServer RemotingServer { get; set; }

    private RemotingSession Session { get; set; }

    /// <inheritdoc/>
    public NetworkException LastException { get; set; }

    /// <inheritdoc/>
    public event Action<byte[]> ReceiveMessage;

    /// <inheritdoc/>
    public event Action<string, Exception> ErrorOccured;

    /// <summary>
    /// Event: fires when a web socket is disconnected.
    /// </summary>
    public event Action Disconnected;

    private AsyncLock ReceiveLock { get; } = new();

    private AsyncLock SendLock { get; } = new();

    /// <inheritdoc/>
    public async Task<bool> SendMessageAsync(byte[] rawMessage)
    {
        try
        {
            if (rawMessage.Length > MaxMessageSize)
                throw new InvalidOperationException("Message is too large. Max size: " +
                    MaxMessageSize + ", actual size: " + rawMessage.Length);

            using var sendLock = await SendLock;

            // message length + message body
            ClientWriter.Write7BitEncodedInt(rawMessage.Length);
            await ClientStream.WriteAsync(rawMessage, 0, rawMessage.Length);
            return true;
        }
        catch (Exception ex)
        {
            LastException = ex as NetworkException ??
                new NetworkException(ex.Message, ex);

            ErrorOccured?.Invoke(ex.Message, ex);
            return false;
        }
    }

    /// <summary>
    /// Starts listening to the incoming messages.
    /// </summary>
    public async Task<Guid> StartListening()
    {
        var sessionId = await CreateRemotingSession();
        _ = Task.Run(ReadIncomingMessages);
        return sessionId;
    }

    /// <summary>
    /// Creates <see cref="RemotingSession"/> for the incoming QUIC connection.
    /// </summary>
    private async Task<Guid> CreateRemotingSession()
    {
        // read handshake message
        var clientPublicKey = await ReadIncomingMessage()
            .ConfigureAwait(false);

        // disable message encryption if handshake is empty
        if (clientPublicKey != null && clientPublicKey.Length == 0)
            clientPublicKey = null;

        Session = RemotingServer.SessionRepository.CreateSession(
            clientPublicKey, Connection.RemoteEndPoint.ToString(),
                RemotingServer, this);

        return Session.SessionId;
    }

    private async Task<byte[]> ReadIncomingMessage()
    {
    	using var receiveLock = await ReceiveLock;
        var messageSize = ClientReader.Read7BitEncodedInt();
        return ClientReader.ReadBytes(Math.Min(messageSize, MaxMessageSize));
    }

    private async Task ReadIncomingMessages()
    {
        try
        {
            while (true)
            {
                var message = await ReadIncomingMessage()
                    .ConfigureAwait(false);
                ReceiveMessage(message ?? []);
            }
        }
        catch (Exception ex)
        {
            LastException = ex as NetworkException ??
                new NetworkException(ex.Message, ex);

            ErrorOccured?.Invoke(ex.Message, LastException);
            Disconnected?.Invoke();
        }
        finally
        {
            await (Connection?.DisposeAsync() ?? default);
            Connection = null;
        }
    }
}
