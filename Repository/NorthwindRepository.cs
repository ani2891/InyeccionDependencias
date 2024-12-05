using InyeccionDependencias.Model;
using InyeccionDependencias.Resources;
using InyeccionDependencias.DataContext;
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;
namespace InyeccionDependencias.Repository

{
    public class NorthwindRepository : INorthwindRepository 
    {

        private readonly DataContextNorthwind _dataContext;

        public NorthwindRepository(DataContextNorthwind dataContext)
        {
            _dataContext = dataContext;

        }

    public async Task<List<Employees>> ObtenerTodosLosEmpleados()
        {

            var result = await _dataContext.Employees.ToListAsync();
            return result;

        }

    public async Task<int> ObtenerCantidadEmpleados()
        {

            var result = await _dataContext.Employees.CountAsync();
            return result;

        }

    public async Task<Employees> ObtenerEmpleadoPorID(int id)
        {

            var result = await _dataContext.Employees.Where(e => e.EmployeeID == id).FirstOrDefaultAsync();
            return result;

        }

    public async Task<Employees> ObtenerEmpleadosPorNombre(string nombreEmpleado)
        {

            var result = await _dataContext.Employees.FirstOrDefaultAsync(e => e.FirstName == nombreEmpleado);
            return result;
        }

    public async Task<Employees?> ObtenerIDempleadosPorTitulo(string tituloEmpleado)
        {

            var result = from emp in _dataContext.Employees where emp.Title == tituloEmpleado select emp;
            return await result.FirstOrDefaultAsync();

        }

    public async Task<Employees> ObtenerEmpleadoPorPais(string country)
        {

            var result = from emp in _dataContext.Employees
                         where emp.Country == country
                         select new Employees
                         {
                      
                             FirstName = emp.FirstName,
                             LastName = emp.LastName,
                             Country = emp.Country,

                         };
            return await result.FirstOrDefaultAsync();

        }



    public async Task<List<Employees>> ObtenerTodosLosEmpleadosPorPais(string country)
        {

            var result = from emp in _dataContext.Employees
                         where emp.Country == country
                         orderby emp.LastName
                         select new Employees
                         {

                             FirstName = emp.FirstName,
                             LastName = emp.LastName,
                             Country = emp.Country,

                         };
            return await result.ToListAsync();

        }



    public async Task<Employees> ObtenerElEmpleadoMasGrande()
        {

            var result = from emp in _dataContext.Employees
                         orderby emp.BirthDate
                         select new Employees
                         {

                             FirstName = emp.FirstName,
                             LastName = emp.LastName,
                             

                         };
            return await result.FirstOrDefaultAsync();

        }



    public async Task<List<EmployeesTitle>> ObtenerCantidadEmpleadosPorTitulo()
        {
            var result = await _dataContext.Employees
                                           .GroupBy(empleados => empleados.Title)
                                           .Select(g => new EmployeesTitle
                                           {
                                               Titulo = g.Key,
                                               cantidadEmpleados = g.Count()
                                           })
                                           .ToListAsync();

            return result;
        }

    public async Task<List<EmployeesTitle>> ObtenerCantEmpleadosPorTitulo2() //otra forma de hacerlo
        {

            var result = await(from emp in _dataContext.Employees
                                group emp by emp.Title into g
                                select new EmployeesTitle
                                {
                                    Titulo = g.Key,
                                    cantidadEmpleados = g.Count(),
                                }).ToListAsync();


            return result;


        }



    public async Task<List<ProductCategory>> ObtenerTodosLosProductosConCategoria()
        {
            var result = from prod in _dataContext.Products
                         join cat in _dataContext.Categories on prod.CategoryID equals cat.CategoryID

                         select new ProductCategory
                         {
                             ProductName = prod.ProductName,
                             CategoryName = cat.CategoryName,

                         };

        return await result.ToListAsync();
                         
            }



    public async Task<List<Products>> ObtenerProductosQueContienenChef()
        {
            var result = await _dataContext.Products
                                           .Where(p => EF.Functions.Like(p.ProductName, "%chef%"))
                                           .ToListAsync();

            return result;
        }

        public async Task<bool> EliminarOrdenPorID(int orderID)
        {
            Orders? orden = await _dataContext.Orders.Where(r => r.OrderID == orderID).FirstOrDefaultAsync();
            OrderDetails? ordenDetail = await _dataContext.OrderDetails.Where(r => r.OrderID == orden.OrderID).FirstOrDefaultAsync();

            _dataContext.OrderDetails.Remove(ordenDetail);
            _dataContext.Orders.Remove(orden);

            var resulta = _dataContext.SaveChanges();
            return true;
        }


        public async Task<bool> InsertarEmpleado()
        {
            Employees employee = new Employees();
            employee.Title = "Sales Manager";
            employee.City = "Rosario";
            employee.FirstName = "Ana";
            employee.LastName = "Parmigiani";
            employee.BirthDate = new DateTime(1991, 9, 28);
            var newEmployee = await _dataContext.AddAsync(employee);
            var result = _dataContext.SaveChanges();

            return (result > 0);
        }



        public async Task<bool> ModificarNombreEmpleado(int idEmpleado, string nombre)
        {
            bool actualizado = false;
            Employees result = await _dataContext.Employees.Where(r => r.EmployeeID == idEmpleado).FirstOrDefaultAsync();

            if (result != null)
            {
                result.FirstName = nombre;
                var resulta = _dataContext.SaveChanges();
                actualizado = true;
            }

            return actualizado;
        }




    }

}