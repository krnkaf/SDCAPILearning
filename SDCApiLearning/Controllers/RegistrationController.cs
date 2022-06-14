using Microsoft.AspNetCore.Mvc;
using SDCApiLearning.Data;
using SDCApiLearning.Repo;
using Registration;

namespace SDCApiLearning.Controllers
{
    [Route("student")]
    public class RegistrationController : ControllerBase
    {
        IService service;
        IRepo repo;
        public RegistrationController(IService service1, IRepo repo1)
        {
            service=service1;
            repo = repo1;
        }

        [HttpGet]
        [Route("GetSomething")]
        public IActionResult GetSomething()
        {
            var res=service.Insert();

            return Ok(res);
        }

    }
}
