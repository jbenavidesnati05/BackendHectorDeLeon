using BackendHectorDeLeon.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendHectorDeLeon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RamdomController : ControllerBase
    {
        private IRamdomService _ramdomServiceSingleton;
        private IRamdomService _ramdomServiceScoped;
        private IRamdomService _ramdomServiceTransient;

        private IRamdomService _ramdomService2Singleton;
        private IRamdomService _ramdomService2Scoped;
        private IRamdomService _ramdomService2Transient;

        public RamdomController
            (
            [FromKeyedServices("ramdomSingleton")] IRamdomService ramdomServiceSingleton,
            [FromKeyedServices("ramdomScoped")] IRamdomService ramdomServiceScoped,
            [FromKeyedServices("ramdomTransient")] IRamdomService ramdomServiceTransient,
            [FromKeyedServices("ramdomSingleton")] IRamdomService ramdomService2Singleton,
            [FromKeyedServices("ramdomScoped")] IRamdomService ramdomService2Scoped,
            [FromKeyedServices("ramdomTransient")] IRamdomService ramdomService2Transient
            )
        {
            _ramdomServiceSingleton = ramdomServiceSingleton;
            _ramdomServiceScoped = ramdomServiceScoped;
            _ramdomServiceTransient = ramdomServiceTransient;
            _ramdomService2Singleton = ramdomService2Singleton;
            _ramdomService2Scoped = ramdomService2Scoped;
            _ramdomService2Transient = ramdomService2Transient;
        }

        [HttpGet]
        public ActionResult<Dictionary<string, int>> Get()
        {
            var result = new Dictionary<string, int>();

            result.Add("Singleton 1", _ramdomServiceSingleton.Value);
            result.Add("Scoped 1", _ramdomServiceScoped.Value);
            result.Add("Transient 1", _ramdomServiceTransient.Value); 
            
            result.Add("Singleton 2", _ramdomService2Singleton.Value);
            result.Add("Scoped 2", _ramdomService2Scoped.Value);
            result.Add("Transient 2", _ramdomService2Transient.Value);

            return result;
        }
    }
}