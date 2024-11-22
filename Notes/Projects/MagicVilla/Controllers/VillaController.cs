using MagicVilla.Data;
using MagicVilla.Model;
using MagicVilla.Model.Dto;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;

namespace MagicVilla.Controllers
{
    [Route("api/Villa")]
    [ApiController]

    public class VillaController : ControllerBase
    {
        [HttpGet]
        // It has return the collection 

        public IActionResult GetVillas()
        {

            return StatusCode(StatusCodes.Status200OK, VillaStore.villalist);
        }

        [HttpGet("id")]
        // It has return single id  or single record 
        public IActionResult GetVilla(int id)
        {
            if (id == 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            var data = VillaStore.villalist.FirstOrDefault(x => x.Id == id);
            if (data == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);

            }
            return StatusCode(StatusCodes.Status200OK, data);
        }
        [HttpPost]
        public IActionResult CreateVillas([FromBody] Villadto villadto)
        {
            //if (ModelState.IsValid)
            //{
            //    return StatusCode(StatusCodes.Status400BadRequest);
            //}
            if (VillaStore.villalist.FirstOrDefault(u => u.Names == villadto.Names) != null)
            {
                ModelState.AddModelError("", "Villa name is required ");
                return StatusCode(StatusCodes.Status400BadRequest, ModelState);
            }

            if (villadto == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
            if (villadto.Id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            // why we use this : - if we enter the id 0 from front end side then it count by descending and increment the id by 1
            // if we have use the orderby ascending then it will repeat the id 
            // this is store the value temporary 
            villadto.Id = VillaStore.villalist.OrderByDescending(u => u.Id).FirstOrDefault().Id + 1;

            return StatusCode(StatusCodes.Status200OK, villadto);
        }

        [HttpDelete("id")]

        public IActionResult DeleteVilla(int id)
        {

            if (id == 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            var villa = VillaStore.villalist.FirstOrDefault(u => u.Id == id);
            if (villa is null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
            VillaStore.villalist.Remove(villa);
            ModelState.AddModelError("", "id deleted Succefully");
            return StatusCode(StatusCodes.Status204NoContent, villa);
        }

        [HttpPut(Name = "Update")]

        public IActionResult Update(int id, [FromBody] Villadto villadto)
        {
            if (villadto is null || id != villadto.Id)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            var villa = VillaStore.villalist.FirstOrDefault(u => u.Id == id);
            villa.Names = villadto.Names;
            villa.sqft = villadto.sqft;
            villa.Occupancy = villadto.Occupancy;

            return StatusCode(StatusCodes.Status200OK, new
            {
                Message = "Villa Update Succefully"
            });
        }


        [HttpPatch("Name = Upate Extisting data ")]

        public IActionResult UpdateExitingdata(int id, [FromBody] JsonPatchDocument<Villadto> patchdto)
        {
            if (patchdto is null || id ==0)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            var villa = VillaStore.villalist.FirstOrDefault(u=>u.Id== id);
            if(villa is null)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            patchdto.ApplyTo(villa,ModelState);
            if(!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status502BadGateway);
            }
            //return StatusCode(StatusCodes.Status200OK, villa);
            return new ObjectResult(villa);



        }
   
    }
}
