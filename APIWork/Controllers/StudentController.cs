using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Net;

namespace APIWork.Controllers
{
    [ApiController]
    [Route("api/Student")]
    public class StudentController : ControllerBase
    {
        static List<StudentModel> students = new List<StudentModel>();
        [HttpGet]
        public ActionResult<IEnumerable<StudentModel>> GetAllStudents()
        {
            return Ok(students);
        }



        [HttpGet("{id:int}",Name = "GetStudent")]        
        public ActionResult<StudentModel> GetStudent(int id)
        {
            return Ok(students.Find(s => s.Id == id));
        }



        
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public ActionResult<StudentModel> CreateNewStudent([FromBody] StudentModel newStudent)
        {
            var ifStudent = students.Find(s => s.Id == newStudent.Id);
            if(ifStudent != null)
            {
                return BadRequest("Student with this ID already exists, Try with different ID");
            }
            students.Add(newStudent);
            //return Ok(newStudent);
            return CreatedAtRoute("GetStudent", new { id = newStudent.Id}, newStudent);
        }



        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut]
        public ActionResult<StudentModel> UpdateStudent([FromBody] StudentModel oldStudent)
        {
            var ifStudent = students.Find(s => s.Id == oldStudent.Id);
            if(ifStudent == null)
            {
                return BadRequest("Student with this ID doesnot exist, Try again with different ID");
            }
            int index = students.IndexOf(ifStudent);
            students[index] = oldStudent;
            return CreatedAtRoute("GetStudent", new { id = oldStudent.Id }, oldStudent);

        }



        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id:int}")]
        public IActionResult DeleteStudent(int id)
        {
            var ifStudent = students.Find(s => s.Id == id);
            if (ifStudent == null)
            {
                return BadRequest("Student with this ID doesnot exist");
            }
            students.Remove(ifStudent);
            return NoContent();
        }
    }
}
