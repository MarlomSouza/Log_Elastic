using log_elastic.Aplication;
using Microsoft.AspNetCore.Mvc;

namespace log_elastic.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private readonly Service _service;

        public TodosController(Service service)
        {
            _service = service;
        }

        [HttpPost]
        public void Post(){
            
        }
    }
}