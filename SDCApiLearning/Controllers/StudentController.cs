using Microsoft.AspNetCore.Mvc;
using SDCApiLearning.Repo;

namespace SDCApiLearning.Controllers
{
    [Route("student")]
    public class StudentController : ControllerBase 
    {
        [Route("GetAllStudent")]
        public IActionResult GetStudentList(int id=0)
        {
            StudentContext con=new StudentContext();
            //var data=con.GetStudentList();
            var data = con.GetStudentDatasFromDB(id);

            return Ok(data);
        }
    }
}
