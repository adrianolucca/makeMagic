using Microsoft.VisualStudio.TestTools.UnitTesting;
using Modelo.Domain.Entities;
using Modelo.Domain.Interfaces.Services;
using Modelo.Infra.Cross.DTO;
using Modelo.Service;
using Moq;
using NSubstitute;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UnitTest
{
    [TestClass]
    public  class UnitTest
    {
        private IPersonagemService mock;

        [TestMethod]
        public void TesteHouseValida()
        {
            mock = Substitute.For<IPersonagemService>();
            Personagem personagem = new Personagem
            {
                Name = "Harry Potter",
                Role = "student",
                School = "Hogwarts School of Witchcraft and Wizardry",
                House = "5a05e2b252f721a3cf2ea33f",
                Patronus = "stag"
            };

            //house invalida
            mock.GetHouseById("4455335")
               .Returns((List<HouseDTO>)null);

            //house valida
            mock.GetHouseById(personagem.House)
              .Returns(new List<HouseDTO>());         

          
        }

        [TestMethod]
        public  void TestInsert()
        {

            mock = Substitute.For<IPersonagemService>();
            PersonagemDTO personagem = new PersonagemDTO
            {
                Name = "Harry Potter",
                Role = "student",
                School = "Hogwarts School of Witchcraft and Wizardry",
                House = "5a05e2b252f721a3cf2ea33f",
                Patronus = "stag"
            };

            mock.Add(personagem);
           
        }
    }
}
