using Modelo.Domain.Entities;
using Modelo.Infra.Cross.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Domain.Interfaces.Repositories
{
    public interface IPersonagemRepository : IBaseRepository<Personagem, PersonagemDTO>
    {
        Task<List<HouseDTO>> GetHouseById(string house);
    }
}
