using Microsoft.AspNetCore.Identity.UI.Services;
using System.Threading.Tasks;

public class EmailSender : IEmailSender
{
    // Esta clase se deja vacía o con un comportamiento por defecto que no envía correos.

    public Task SendEmailAsync(string email, string subject, string message)
    {
        // Aquí simplemente devolvemos una tarea completada sin realizar ninguna acción.
        return Task.CompletedTask;
    }
}
