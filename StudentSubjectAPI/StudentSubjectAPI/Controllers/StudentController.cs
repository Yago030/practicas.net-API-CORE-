using Microsoft.AspNetCore.Mvc;
using StudentSubjectAPI.Repositories;
using System.Collections.Generic;

[ApiController]
[Route("api/students")]
public class StudentController : ControllerBase
{
    private readonly IStudentRepository _studentRepository;

    public StudentController(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

    [HttpGet] // Responde a "GET api/students"
    public IActionResult GetStudents()
    {
        var students = _studentRepository.GetAllStudents();
        return Ok(students);
    }
}
