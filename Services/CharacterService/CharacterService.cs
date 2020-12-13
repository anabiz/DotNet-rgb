using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Notnet_rgp.Dtos.Character;
using Notnet_rgp.Model;

namespace Notnet_rgp.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
        private static List<Character> characters = new List<Character>{
            new Character(),
            new Character { Id = 1, Name = "Sam" }
        };

        public async Task<ServiceResponse<List<GetCharacter>>> AddCharacter(AddCharacter newcharacter)
        {
            ServiceResponse<List<GetCharacter>> serviceResponse = new ServiceResponse<List<GetCharacter>>();
            
            characters.Add(newcharacter);

            serviceResponse.Data = characters;

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacter>>> GetAllCharacters()
        {
            ServiceResponse<List<GetCharacter>> serviceResponse = new ServiceResponse<List<GetCharacter>>();

            serviceResponse.Data = characters;

            return serviceResponse;
        }

        public async Task<ServiceResponse<Character>> GetCharacterById(int id)
        {
            ServiceResponse<GetCharacter> serviceResponse = new ServiceResponse<GetCharacter>();

            serviceResponse.Data = characters.FirstOrDefault(c => c.Id == id);

            return serviceResponse;
        }
    }
}