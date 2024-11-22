using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentProject.Interface;
using StudentProject.Model;

namespace StudentProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PateintsController : ControllerBase
    {
        private readonly IPateints service;

        public PateintsController(IPateints _service)
        {
            service = _service;
        }

        [HttpPost("/AddPateint")]
        public IActionResult Addpateint(PateintsModel model)
        {
            if (ModelState.IsValid)
            {
                service.AddPateint(model);
                return Created();
            }
            return BadRequest();
        }
        [HttpGet("/ListPateint")]
        public IActionResult PateintList()
        {
            return Ok(service.GetPateintsList());
        }

        [HttpGet("/UpdatePateintGetById")]
        public IActionResult UpdatePateintGetById(int id)
        {
            service.Getpateint(id);
            return Ok();
        }

        [HttpPost("/Updatepateint")]
        public IActionResult Updatepateint(PateintsModel model)
        {
            if (!ModelState.IsValid)
            {
                return NoContent();
            }
            service.UpdatePateint(model);
            return Ok();
        }

        [HttpPost("/Deletepateint")]
        public IActionResult RemovePateint(int id)
        {
            if (ModelState.IsValid)
            {
                service.DeletePateint(id);
                return Ok();
            }
            return BadRequest();
        }
    }

}
