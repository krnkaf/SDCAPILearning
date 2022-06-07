using Microsoft.AspNetCore.Mvc;
using SDCApiLearning.Data;
using SDCApiLearning.Repo;

namespace SDCApiLearning.Controllers
{
    [Route("student")]
    public class StudentController : ControllerBase 
    {
        [HttpGet]
        [Route("GetAllStudent")]
        public IActionResult GetStudentList(int id=0)
        {
            StudentContext con=new StudentContext();
            //var data=con.GetStudentList();
            var data = con.GetStudentDatasFromDB(id);

            return Ok(data);
        }

        [HttpGet]
        [Route("Create")]
        public IActionResult Create()
        {
            var data = new StudentData {
                id=5,
                name="hari"
            };
            StudentContext s = new StudentContext();
            s.InsertIntoStudent(data);
            return Ok(data);
        }

        [HttpGet]
        [Route("Update")]
        public IActionResult Update()
        {
            var data = new StudentData
            {
                id = 1,
                name = "hari ram"
            };
            StudentContext s = new StudentContext();
            s.UpdateStudent(data);
            return Ok(data);
        }


    }
}
