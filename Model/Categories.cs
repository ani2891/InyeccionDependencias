using System.ComponentModel.DataAnnotations;

namespace InyeccionDependencias.Model
{
    public class Categories
    {
        [Key]
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }



    }
}
