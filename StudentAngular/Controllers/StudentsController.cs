using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using StudentAngular.Models;
using StudentAngular.Repository;
using StudentAngular.ViewModel;
using System.Threading.Tasks;

namespace StudentAngular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private IStudentRepository _studentRepository;
        public StudentsController(IStudentRepository studentRepo)
        {
            _studentRepository = studentRepo;
        }

        [Route("[action]")]
        public IActionResult GetAllStudent()
        {
            return Ok(_studentRepository.GetAllStudent());
        }

        [HttpPut]
        [Route("[action]/{id:int}")]

        public  async Task<IActionResult> UpdateStudent([FromRoute] int id, [FromBody] UpdateStudentViewModel studentView) {

           if (await _studentRepository.Exists(id))
            {
                var updateStudent = await _studentRepository.UpdateStudent(id, studentView);
                if (updateStudent != null)
                {
                    return Ok(updateStudent);
                }
            }
            return NotFound();
        }


        [HttpPost]
        [Route("[action]/")]

        public async Task<IActionResult> addStudent([FromBody] UpdateStudentViewModel studentView)
        {
                var student = await _studentRepository.AddStudent(studentView);
                 return Ok(student);
        }

        [HttpDelete]
        [Route("[action]/{Id:int}")]

        public async Task<IActionResult> DeleteStudent([FromRoute] int Id) { 

            if (await _studentRepository?.Exists(Id))
            {
                var student = await _studentRepository.DeleteStudentAsync(Id);
                return Ok(student);
            }
            return NotFound();
        }
    }
}
