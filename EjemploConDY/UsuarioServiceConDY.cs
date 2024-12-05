namespace InyeccionDependencias.EjemploConDY
{
    public class UsuarioServiceConDY
    {
        private IEmailServiceConDY _emailServiceConDY;

        public UsuarioServiceConDY(IEmailServiceConDY emailServiceConDY)
        {
            _emailServiceConDY = emailServiceConDY;
        }


        public bool EnviarNotificacionUsuarioConDY(string email)
        {
            _emailServiceConDY.Enviar(email, "notificacion");
            return true;

        }



    }
}
