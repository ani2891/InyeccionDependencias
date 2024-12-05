using InyeccionDependencias.EjemploSinDY;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InyeccionDependencias.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EjemploSinDYController : ControllerBase
    {
        [HttpGet]

        public bool EnviarMail([FromQuery]string mail) 
        { 
            UsuarioServiceSinDY usuarioServiceSinDY = new UsuarioServiceSinDY();
            return usuarioServiceSinDY.EnviarNotificacionUsuario(mail);
       
        }
    }
}
