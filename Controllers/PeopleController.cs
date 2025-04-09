using BackendHectorDeLeon.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackendHectorDeLeon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private IPeopleService _peopleService;

        public PeopleController([FromKeyedServices("people2Service")]IPeopleService peopleService) 
        {
            _peopleService = peopleService;
        }

        [HttpGet("All")]
        public List<People> GetPeople() => Repository.People;

        [HttpGet("{id}")]
        public ActionResult<People> Get(int id)
        {
         var people = Repository.People.FirstOrDefault(p => p.Id == id);

            if (people == null)
            {
                return NotFound();
            }

            return Ok(people);

        }

        [HttpGet("search/{search}")]
        public List<People> Get(string search) =>
            Repository.People.Where(p => p.Name.Contains(search)).ToList();

        [HttpPost]
        public IActionResult Add(People people) 
        {
           // if (string.IsNullOrEmpty(people.Name))
            if (!_peopleService.Validate(people))
            {
                return BadRequest();
            }
            Repository.People.Add(people);

            return NoContent();
        }
        
    }

    public class Repository
    {
        public static List<People> People = new List<People>
        {
            new People ()
            {
                Id = 1,
                Name = "Foo",
                Birthdate = new DateTime(1990,12,3),
            },
            new People ()
            {
                Id = 2,
                Name = "Foo2",
                Birthdate = new DateTime(1992,1,3),
            },
                new People ()
            {
                Id = 3,
                Name = "Foo3",
                Birthdate = new DateTime(1992,1,3),
            },
            new People ()
            {
                Id = 4,
                Name = "Foo4",
                Birthdate = new DateTime(1992,1,3),
            },

        }; 
    }

    public class People 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
    }


}
