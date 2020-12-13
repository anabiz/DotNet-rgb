using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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

        private readonly IMapper _mapper;

        public CharacterService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetCharacter>>> AddCharacter(AddCharacter newcharacter)
        {
            ServiceResponse<List<GetCharacter>> serviceResponse = new ServiceResponse<List<GetCharacter>>();
            
            Character character = _mapper.Map<Character>(newcharacter);

            character.Id = characters.Max(c => c.Id) + 1;

            characters.Add(character); 

            serviceResponse.Data = (characters.Select(c => _mapper.Map<GetCharacter>(c))).ToList();

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacter>>> GetAllCharacters()
        {
            ServiceResponse<List<GetCharacter>> serviceResponse = new ServiceResponse<List<GetCharacter>>();

            serviceResponse.Data = (characters.Select(c => _mapper.Map<GetCharacter>(c))).ToList();

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacter>> GetCharacterById(int id)
        {
            ServiceResponse<GetCharacter> serviceResponse = new ServiceResponse<GetCharacter>();

            serviceResponse.Data = _mapper.Map<GetCharacter>(characters.FirstOrDefault(c => c.Id == id));

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacter>> UpdateCharacter(UpdateCharacter updateCharacter)
        {
            ServiceResponse<GetCharacter> serviceResponse = new ServiceResponse<GetCharacter>();

            Character character = characters.FirstOrDefault(c => c.Id == updateCharacter.Id);

            character.Name = updateCharacter.Name;
            character.Strength = updateCharacter.Strength;
            character.Class = updateCharacter.Class;
            character.Defence = updateCharacter.Defence;
            character.HitPoints = updateCharacter.HitPoints;
            character.Intelligence = updateCharacter.Intelligence;

            serviceResponse.Data = _mapper.Map<GetCharacter>(character);

            return serviceResponse;

        }
    }
}