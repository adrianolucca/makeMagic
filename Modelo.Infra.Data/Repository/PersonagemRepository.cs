using AutoMapper;
using Modelo.Domain.Entities;
using Modelo.Domain.Interfaces.Repositories;
using Modelo.Infra.Cross.DTO;
using Modelo.Infra.Data.Context;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Infra.Data.Repository
{
    public class PersonagemRepository : BaseRepository<Personagem, PersonagemDTO>, IPersonagemRepository
    {
        public PersonagemRepository(context context) : base(context)
        {
        }      

      public async Task<List<HouseDTO>> GetHouseById(string house)
        {

            try
            {
                BaseDTO baseUrls = new BaseDTO();
                HttpClient client = new HttpClient();
                string url = string.Format("{0}{1}?key={2}",baseUrls.ApiURL,house,baseUrls.key);
                var response = await client.GetStringAsync(url);
                var houseret = JsonConvert.DeserializeObject<List<HouseDTO>>(response);
                return houseret;
            }
            catch
            {
                return new List<HouseDTO>();
            }
        }
    }
}
