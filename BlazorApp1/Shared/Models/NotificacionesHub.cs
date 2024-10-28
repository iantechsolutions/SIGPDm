using Microsoft.AspNetCore.SignalR;
using System.Security.Claims;

public class NotificacionesHub : Hub
{
    public async Task EnviarNotificacion(string mensaje)
    {
        var usuarioId = Context.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        await Clients.All.SendAsync("RecibirNotificacion", mensaje);
    }
}
