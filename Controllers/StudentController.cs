using CRUD_Using_One_To_Many_Relationship.Models;
using CRUD_Using_One_To_Many_Relationship.Services;
using CRUD_Using_One_To_Many_Relationship.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_Using_One_To_Many_Relationship.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private IStudent studentservice;

        public StudentController(IStudent studentservice)
        {
            this.studentservice = studentservice;
        }

        [HttpPost]
        [Route("Save")]
        public async Task<IActionResult> Save(StudentVM studentVM)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    Student newstudent = new Student();
                    newstudent.Sname = studentVM.StudentName;
                    newstudent.Fee = studentVM.Fee;
                    newstudent.Department = new Department();
                    newstudent.Department.DeptName = studentVM.DeptName;
                    Student savedstudent = await studentservice.Save(newstudent);
                    return Ok(savedstudent);
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex) 
            {
                Console.WriteLine("Error Occured"+ex.Message);
                return StatusCode(StatusCodes.Status404NotFound);
            }
        }

        [HttpGet]
        [Route("Get/{id}")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            try
            {
                if(id!=null)
                {
                    Student student = await studentservice.GetStudent(id);
                    return Ok(student);
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error Occured" + ex.Message);
                return StatusCode(StatusCodes.Status404NotFound);
            }
        }

        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                if(id!=null)
                {
                    List<Student> stuedents = await studentservice.GetStudentsList();
                    return Ok(stuedents);
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch(Exception ex)
            {

                Console.WriteLine("Error Occured" + ex.Message);
                return StatusCode(StatusCodes.Status404NotFound);
            }
        }

        [HttpPut]
        [Route("Update")]

        public async Task<IActionResult> Update(StudentVM updatedstudent, int id)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    Student student= await studentservice.GetStudent(id);
                    student.Sname = updatedstudent.StudentName;
                    student.Fee= updatedstudent.Fee;
                    student.Department.DeptName = updatedstudent.DeptName;
                    Student student1=await studentservice.Update(student);
                    return Ok(student1);
                }
                
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch(Exception ex) 
            {

                Console.WriteLine("Error Occured" + ex.Message);
                return StatusCode(StatusCodes.Status404NotFound);
            }
        }

        [HttpDelete]
        [Route("Delete")]

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    Student DeletedStudent= await studentservice.Delete(id);
                    return Ok(DeletedStudent);
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error message occured"+ex.Message);
                return StatusCode(StatusCodes.Status404NotFound);
            }
        }
    }
}
