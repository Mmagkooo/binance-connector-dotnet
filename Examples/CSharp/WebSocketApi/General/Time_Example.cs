namespace Binance.Spot.WebSocketApiExamples
{
    using System.Threading;
    using System.Threading.Tasks;
    using Binance.Spot;
    using Microsoft.Extensions.Logging;

    public class Time_Example
    {
        public static async Task Main(string[] args)
        {
            // Create logger
            using var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
            });
            ILogger logger = loggerFactory.CreateLogger<Time_Example>();

            // Create WebSocket API
            var websocket = new WebSocketApi();

            // Receive WebSocket API Response
            websocket.OnMessageReceived(
                async (data) =>
            {
                logger.LogInformation(data);
                await Task.CompletedTask;
            });

            await websocket.ConnectAsync();

            await websocket.General.TimeAsync();
            await websocket.General.TimeAsync(requestId: 123, CancellationToken.None);
            await websocket.General.TimeAsync(requestId: "requestId123", CancellationToken.None);

            // wait for 5s before disconnected
            await Task.Delay(5000);
            logger.LogInformation("Disconnect with WebSocket Server");
            await websocket.DisconnectAsync();
        }
    }
}