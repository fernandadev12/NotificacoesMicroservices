using Microsoft.AspNetCore.Mvc;
using Notificacoes.Domain.Entity;

namespace Notificacoes.API.Controllers
{
    public class NotificacoesController 
    {
        [ApiController]
        [Route("api/[controller]")]
        public class NotificationsController : ControllerBase
        {
            private readonly NotificationService _service;

            public NotificationsController(NotificationService service)
            {
                _service = service;
            }

            [HttpPost]
            public async Task<IActionResult> SendNotification([FromBody] Notification notification)
            {
                await _service.SendAsync(notification);
                return Ok("Notificação enviada com sucesso!");
            }
        }
    }
}
