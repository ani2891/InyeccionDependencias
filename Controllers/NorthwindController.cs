using InyeccionDependencias.EjemploConDY;
using InyeccionDependencias.Model;
using InyeccionDependencias.Repository;
using InyeccionDependencias.Resources;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace InyeccionDependencias.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NorthwindController : ControllerBase
    {
        private readonly INorthwindRepository _repository;

        public NorthwindController(INorthwindRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("api/TodosLosEmpleados")]
        public async Task<List<Employees>> ObtenerTodosLosEmpleados()
        {
           
           return await _repository.ObtenerTodosLosEmpleados();

        }

        [HttpGet]
        [Route("api/CantidadEmpleados")]
        public async Task<int> ObtenerCantidadEmpleados()
        {

            return await _repository.ObtenerCantidadEmpleados();
        }

        [HttpGet]
        [Route("api/EmpleadoPorID")]
        public async Task<Employees> ObtenerEmpleadoPorID([FromQuery] int empleadoID)
        {

            return await _repository.ObtenerEmpleadoPorID(empleadoID);
        }


        [HttpGet]
        [Route("api/EmpleadosPorNombre")]
        public async Task<Employees> ObtenerEmpleadosPorNombre([FromQuery] string nombreEmpleado)
        {

            return await _repository.ObtenerEmpleadosPorNombre(nombreEmpleado);
        }


        [HttpGet]
        [Route("api/IDempleadosPorTitulo")]
        public async Task<Employees?> ObtenerIDempleadosPorTitulo([FromQuery] string tituloEmpleado)
        {

            return await _repository.ObtenerIDempleadosPorTitulo(tituloEmpleado);
        }


        [HttpGet]
        [Route("api/EmpleadoPorPais")]
        public async Task<Employees> ObtenerEmpleadoPorPais([FromQuery] string country)
        {

            return await _repository.ObtenerEmpleadoPorPais(country);
        }

        [HttpGet]
        [Route("api/TodosLosEmpleadosPorPais")]
        public async Task<List<Employees>> ObtenerTodosLosEmpleadosPorPais([FromQuery] string country)
        {

            return await _repository.ObtenerTodosLosEmpleadosPorPais(country);
        }

        [HttpGet]
        [Route("api/ElEmpleadoMasGrande")]
        public async Task<Employees> ObtenerElEmpleadoMasGrande()
        {

            return await _repository.ObtenerElEmpleadoMasGrande();
        }



        [HttpGet]
        [Route("api/CantidadEmpleadosPorTitulo")]
        public async Task<List<EmployeesTitle>> ObtenerCantidadEmpleadosPorTitulo()
        {

            return await _repository.ObtenerCantidadEmpleadosPorTitulo();
        }


        [HttpGet]
        [Route("api/CantEmpleadosPorTitulo2")]
        public async Task<List<EmployeesTitle>> ObtenerCantEmpleadosPorTitulo2()
        {

            return await _repository.ObtenerCantEmpleadosPorTitulo2();
        }


        [HttpGet]
        [Route("api/TodosLosProductosConCategoria")]
        public async Task<List<ProductCategory>> ObtenerTodosLosProductosConCategoria()
        {
            return await _repository.ObtenerTodosLosProductosConCategoria();
        }



        [HttpGet]
        [Route("api/ProductosQueContienenChef")]
        public async Task<List<Products>> ObtenerProductosQueContienenChef()
        {
            return await _repository.ObtenerProductosQueContienenChef();
        }


        [HttpDelete]
        [Route("api/EliminarOrdenPorID")]
        public async Task<bool> EliminarOrdenPorID([Required, FromQuery] int id)
        {
            return await _repository.EliminarOrdenPorID(id);
        }


        [HttpPost]
        [Route("api/InsertarEmpleado")]

        public async Task<bool> InsertarEmpleado()
        {
            return await _repository.InsertarEmpleado();
        }




   
        [HttpPut]
        [Route("api/ModificarNombreEmpleado")]
        public async Task<bool> ModificarNombreEmpleado([Required, FromQuery] int id,
                                                [Required, FromQuery] string nombre)
                                               
        {
            return await _repository.ModificarNombreEmpleado(id, nombre);
        }


    }
}
