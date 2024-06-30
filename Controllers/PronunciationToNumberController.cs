using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PronunciationOfTheNumber.Models;
using PronunciationOfTheNumber.Services;


namespace PronunciationOfTheNumber.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class PronunciationToNumberController : ControllerBase
    {
        private readonly NumberPronunciationService _pronunciationService;

        public PronunciationToNumberController(NumberPronunciationService pronunciationService)
        {
            _pronunciationService = pronunciationService;
        }

        [HttpPost]
        [Authorize]
        public IActionResult Transform([FromBody] RequestNumber request)
        {
            try
            {
                var result = _pronunciationService.Transform(request.number);
                return Ok(new ResponseNumber { pronunciation = result });
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }

        }
    }

}
