namespace InyeccionDependencias.EjemploSinDY
{
    public class UsuarioServiceSinDY //la clase principal
    {
        public EmailServiceSinDY emailServiceSinDY { get; set; }  // creamos una PROPIEDAD sobre la otra clase. emailServiceSinDY es la variable a la que se le asignan las propiedades

        public UsuarioServiceSinDY() //constructor
        {
            emailServiceSinDY = new EmailServiceSinDY();  //instanciamos la clase y esa propiedad se convierte en un objeto, cuando lo inicializamos

        }

        public bool EnviarNotificacionUsuario(string email) //al tener ya como objeto la clase, podemos acceder al metodo "enviar"
        {
            emailServiceSinDY.Enviar(email, "notificacion");

            return true;

        }

    }
}
