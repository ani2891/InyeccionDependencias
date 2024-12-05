using InyeccionDependencias.Model;
using InyeccionDependencias.Resources;

namespace InyeccionDependencias.Repository
{
    public interface INorthwindRepository
    {
        Task<List<Employees>> ObtenerTodosLosEmpleados();
        Task<int> ObtenerCantidadEmpleados();
        Task<Employees> ObtenerEmpleadoPorID(int id);
        Task<Employees> ObtenerEmpleadosPorNombre(string nombreEmpleado);
        Task<Employees?> ObtenerIDempleadosPorTitulo(string tituloEmpleado);
        Task<Employees> ObtenerEmpleadoPorPais(string country);
        Task<List<Employees>> ObtenerTodosLosEmpleadosPorPais(string country);
        Task<Employees> ObtenerElEmpleadoMasGrande();
        Task<List<EmployeesTitle>> ObtenerCantidadEmpleadosPorTitulo();

        Task<List<EmployeesTitle>> ObtenerCantEmpleadosPorTitulo2(); //otra forma

        Task<List<ProductCategory>> ObtenerTodosLosProductosConCategoria();

        Task<List<Products>> ObtenerProductosQueContienenChef();

        Task<bool> EliminarOrdenPorID(int orderID);
       
        Task<bool> InsertarEmpleado();

        Task<bool> ModificarNombreEmpleado(int idEmpleado, string nombre);
    }

}