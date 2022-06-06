using Microsoft.AspNetCore.Mvc;
using SDCApiLearning.Repo;

namespace SDCApiLearning.Controllers
{
    [Route("student")]
    public class StudentController : ControllerBase 
    {
        [Route("GetAllStudent")]
        public IActionResult GetStudentList()
        {
            StudentContext con=new StudentContext();
            var data=con.GetStudentList();

            return Ok(data);
        }
    }
}
