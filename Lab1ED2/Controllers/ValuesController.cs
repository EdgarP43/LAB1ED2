using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Lab1ED2.Arbol;
using Lab1ED2.SodaViewModel;

namespace Lab1ED2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public static ArbolB Arbol = new ArbolB();
        // Mostrar todas las peliculas
        [HttpGet]
        public string Get()
        {
            var contenido = "Para buscar elementos ingrese la extension /BusquedaBebidas e ingresar el valor buscado en Postman \n" + Arbol.InOrden();
            return contenido;
        }

        // GET api/values/5
        [Route("BusquedaBebidas")]
        [HttpGet]
        public string Get([FromBody] string nuevo)
        {
            var valorBuscado = Arbol.buscar(nuevo);
            string encontrado;
            if (valorBuscado != null)
            {
                encontrado = "-------------\n" + "Nombre: " + valorBuscado.nombre + "\n" + "Sabor: " + valorBuscado.sabor + "\n" + "Volumen: " + valorBuscado.volumen + "\n" + "Precio: " + valorBuscado.precio + "Casa productora: " + valorBuscado.productora + "\n" + "-----------------\n";

            }
            else
            {
                encontrado = "Valor no encontrado";
            }
            return encontrado;
        }


        // POST api/values
        [HttpPost]
        public void Post([FromBody] SodaClass value)
        {
            Arbol.inserta(value);
        }
    }
}
