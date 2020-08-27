using Modelo.Infra.Cross.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Domain.Interfaces.Services
{
    public interface IPersonagemService : IBaseService<PersonagemDTO>
    {
        Task<List<HouseDTO>> GetHouseById(string house);
    }
}
