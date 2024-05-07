using Microsoft.AspNetCore.Mvc;
using System.Net.WebSockets;
using System.Text;

namespace Traceability_System.API.Controllers
{
    [Route("api/[controller]")]
    public class WebSocketController : Controller
    {
    
            [HttpGet("connect")]
            public async Task<IActionResult> ConnectWebSocket()
            {
                if (HttpContext.WebSockets.IsWebSocketRequest)
                {
                    WebSocket webSocket = await HttpContext.WebSockets.AcceptWebSocketAsync();
                    await HandleWebSocket(webSocket);
                    return new EmptyResult();
                }
                else
                {
                    return BadRequest("WebSocket connection is required.");
                }
            }

            private async Task HandleWebSocket(WebSocket webSocket)
            {
                var buffer = new byte[1024 * 4];
                WebSocketReceiveResult result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);

                while (!result.CloseStatus.HasValue)
                {
                    // 处理接收到的消息
                    string message = Encoding.UTF8.GetString(buffer, 0, result.Count);
                    Console.WriteLine($"Received message: {message}");

                    // 回复消息
                    string response = $"Server received: {message}";
                    byte[] responseBytes = Encoding.UTF8.GetBytes(response);
                    await webSocket.SendAsync(new ArraySegment<byte>(responseBytes), result.MessageType, result.EndOfMessage, CancellationToken.None);

                    result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
                }

                await webSocket.CloseAsync(result.CloseStatus.Value, result.CloseStatusDescription, CancellationToken.None);
            }
        }
    
}
