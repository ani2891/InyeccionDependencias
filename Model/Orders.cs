using System.ComponentModel.DataAnnotations;

namespace InyeccionDependencias.Model
{
    public class Orders
    {
        [Key]
        public int OrderID { get; set; }
    }
}
