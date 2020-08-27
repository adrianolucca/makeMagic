using Modelo.Domain.Entities;
using Modelo.Domain.Interfaces.Repositories;
using Modelo.Domain.Interfaces.Services;
using Modelo.Infra.Cross.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Service
{
    public class PersonagemService: BaseService<Personagem, PersonagemDTO>, IPersonagemService
    {
        private readonly IPersonagemRepository _personagemRepository;

        public PersonagemService(IPersonagemRepository personagemRepository) :base(personagemRepository)
        {
            _personagemRepository = personagemRepository;
        }

       public async Task<List<HouseDTO>> GetHouseById(string house)
        {
           return  await _personagemRepository.GetHouseById(house);
        }

    }
}
