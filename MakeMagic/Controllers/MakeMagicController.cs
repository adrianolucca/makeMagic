using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Modelo.Domain.Entities;
using Modelo.Domain.Interfaces.Services;
using Modelo.Infra.Cross.DTO;


namespace MakeMagic.Controllers
{
    [ApiController]
    [Route("MakeMagic/")]
    public class MakeMagicController : ControllerBase
    {
        private readonly IPersonagemService _personagemService;

        /// <summary>
        /// ok
        /// </summary>
        /// <param name="personagemService"></param>
        public MakeMagicController(IPersonagemService personagemService)
        {
            _personagemService = personagemService;
        }


        [HttpGet]
        [Route("api/GetPersonagens")]
        public IActionResult GetPersonagens()
        {
            try
            {
                var personagens = _personagemService.GetAll();
                return Ok(personagens);
            }
            catch 
            {
                Result result = new Result { Status = "NOK", Mensagem = "Ocorreu um erro na chamada " };
                return BadRequest(result);
            }
        }
        // GET api/<controller>/5
        [HttpGet]
        [Route("api/GetIdPersonagem")]
        public IActionResult GetByIdPersonagem(int id)
        {
            try
            {
                var personagem = _personagemService.GetById(id);
                return Ok(personagem);
            }

            catch
            {
                Result result = new Result { Status = "NOK", Mensagem = "Ocorreu um erro na chamada " };
                return BadRequest(result);
            }
        }

        // POST api/<controller>

        [HttpPost]
        [Route("api/Insert")]
        public async Task<IActionResult> Insert(Personagem personagem)
        {

            try
            {
                List<HouseDTO> house = await _personagemService.GetHouseById(personagem.House);
                Result result = new Result();
                if (house.Count > 0)
                {
                    _personagemService.Add(Mapper.Map<PersonagemDTO>(personagem));
                    result.Status = "OK";
                    result.Mensagem = "Personagem inserido com sucesso.";

                    return Ok(result);
                }
                else
                {
                    result.Status = "NOK";
                    result.Mensagem = "Casa do personagem não encontrada.";
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                Result result = new Result { Status = "NOK", Mensagem = "Ocorreu um erro na chamada " };
                return BadRequest(result);
            }
        }


        [HttpPut]
        [Route("api/Update")]
        public IActionResult Update(Personagem personagem)
        {

            try
            {
                Result result = new Result();
                _personagemService.Update(Mapper.Map<PersonagemDTO>(personagem));
                result.Status = "OK";
                result.Mensagem = "Personagem atualizado com sucesso.";
                return Ok(result);
            }
            catch
            {
                Result result = new Result { Status = "NOK", Mensagem = "Ocorreu um erro na chamada " };
                return BadRequest(result);

            }
        }


        [HttpDelete]
        [Route("api/Delete")]
        public IActionResult Delete(int id)
        {
            try
            {
                Result result = new Result();
                _personagemService.Remove(id);
                result.Status = "OK";
                result.Mensagem = "Personagem atualizado com sucesso.";
                return Ok(result);
            }
            catch
            {
                Result result = new Result { Status = "NOK", Mensagem = "Ocorreu um erro na chamada " };
                return BadRequest(result);

            }
        }

        [HttpGet]
        [Route("api/GetPersonagensByHouse")]
        public async Task<IActionResult> GetPersonagensByHouse(string houseId)
        {

            try
            {
                List<HouseDTO> house = await _personagemService.GetHouseById(houseId);

                return Ok(house);
            }
            catch (Exception ex)
            {
                Result result = new Result { Status = "NOK", Mensagem = "Ocorreu um erro na chamada " };
                return BadRequest(result);
            }
        }
    }
}
