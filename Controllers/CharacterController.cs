using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Notnet_rgp.Dtos.Character;
using Notnet_rgp.Model;
using Notnet_rgp.Services.CharacterService;

namespace Notnet_rgp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService _characterService;

        public CharacterController(ICharacterService characterService)
        {
            _characterService = characterService;
        }



        //[Route("GetAll")]
        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _characterService.GetAllCharacters());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            return Ok(await _characterService.GetCharacterById(id));
        }

        [HttpPost("")]
        public async Task<IActionResult> AddCharacter(AddCharacter newcharacter)
        {

            return Ok(await _characterService.AddCharacter(newcharacter));
        }

        [HttpPost("")]
        public async Task<IActionResult> UpdateCharacter(UpdateCharacter updatedcharacter)
        {

            return Ok(await _characterService.UpdateCharacter(updatedcharacter));
        }
    }
}