using Kreata.Backend.Controllers.Base;
using Kreata.Backend.Repos;
using Kreta.Shared.Assemblers;
using Kreta.Shared.Dtos;
using Kreta.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace Kreata.Backend.Controllers
{
    public class StudentController : BaseController<Student, StudentDto>
    {
        private IStudentRepo _studentRepo;
        public StudentController(StudentAssembler? assambler, IStudentRepo? repo) : base(assambler, repo)
        {
            _studentRepo = repo ?? throw new ArgumentNullException(nameof(repo));
        }

        [HttpGet("getstudentbyfullname")]
        public async Task<IActionResult> GetStudentByFullName([FromQuery] FullNameQueryDto fullNameDto)
        {
            return Ok(await _studentRepo.GetByNameAsync(fullNameDto.FirstName, fullNameDto.LastName));
        }

        // A paraméterben kapott évszám évben született diákok száma
        [HttpGet("NumberOfStudentByYear/{year}")]
        public async Task<IActionResult> GetNumberOfStudentByYear(int year)
        {
            return Ok(await _studentRepo.GetNumberOfStudentByYear(year));
        }

        // A paraméterben kapott évszám évben és hónapban született diákok száma
        //[HttpGet("NumberOfStudentByYear/{year}/{month}")]
        
        [HttpGet("NumberOfStudentByYearAndMonthQuery")]
        public async Task<IActionResult> GetNumberOfStudentByYearQueryAsync([FromQuery] int year, [FromQuery] int month)
        {
            return Ok(await _studentRepo.GetNumberOfStudentByYearAndMonthQuery(year, month));
        }

        //Szűrjük a diákokat névrészlet, születési éb vagy hónap vagy nem szerint
    }
}
