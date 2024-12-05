using System.ComponentModel.DataAnnotations;

namespace InyeccionDependencias.Model
{
    public class Products
    {
        [Key]
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int CategoryID { get; set; }


    }
}
