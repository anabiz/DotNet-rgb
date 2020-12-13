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
            
            characters.Add(_mapper.Map<Character>(newcharacter));

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
    }
}