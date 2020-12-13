using System.Collections.Generic;
using System.Threading.Tasks;
using Notnet_rgp.Dtos.Character;
using Notnet_rgp.Model;

namespace Notnet_rgp.Services.CharacterService
{
    public interface ICharacterService
    {
        Task<ServiceResponse<List<GetCharacter>>> GetAllCharacters();

        Task<ServiceResponse<GetCharacter>> GetCharacterById(int id);

        Task<ServiceResponse<List<GetCharacter>>> AddCharacter(AddCharacter newCharacter);
    }
}