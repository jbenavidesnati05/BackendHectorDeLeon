using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net.WebSockets;

namespace BackendHectorDeLeon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SomeController : ControllerBase
    {
        [HttpGet("Sync")]
        public IActionResult GetSync() 
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            stopwatch.Start();
            stopwatch.Stop();

            Thread.Sleep(1000);
            Console.WriteLine("Conexion a base de datos terminada");
            
            
            Thread.Sleep(1000);
            Console.WriteLine("Envio de mail de terminado");

            Console.WriteLine("Todo ha terminado");

            return Ok(stopwatch.Elapsed);
        }

        [HttpGet("async")]

        public async Task<IActionResult> GetAsync()
        {
            var task1 = new Task<int>(() =>

            {
                Thread.Sleep(1000);
                Console.WriteLine("1. Conexion a base de datos terminada");
                return 8;

            });

            task1.Start();
            Console.WriteLine("2. Hago otra cosa");

            var result1 = await task1;
            Console.WriteLine("3. Todo ha terminado");

            
            return Ok(result1);
        }
      
    }
}
