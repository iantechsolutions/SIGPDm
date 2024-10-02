using BlazorApp1.Shared.Models;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

public class NotificacionesHub : Hub
{
    public async Task EnviarNotificacion(string usuario, string mensaje)
    {
        await Clients.User(usuario).SendAsync("RecibirNotificacion", mensaje);
    }
}