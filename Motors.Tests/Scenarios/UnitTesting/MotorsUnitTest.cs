using Microsoft.AspNetCore.Http;
using Motors.Domain.Entidades;
using Motors.Tests.Fixtures;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Motors.Tests.Scenarios.UnitTesting
{
    public class MotorsUnitTest
    {
        private readonly TestContext _testContext;

        public MotorsUnitTest()
        {
            _testContext = new TestContext();
        }

   
        [Fact]
        public async Task CadastrarAnuncio_semMarca()
        {
            var response = await _testContext.Http.PostAsync("/api/Anuncio/CadastrarAnuncio",
              new StringContent(JsonConvert.SerializeObject(new TbAnuncioWebmotors()
              {
                  Marca = ""
              }), Encoding.UTF8, "application/json"));

            if ((int)response.StatusCode == StatusCodes.Status400BadRequest)
            {
                Assert.Equal((int)HttpStatusCode.BadRequest, (int)response.StatusCode);
            }
        }

        [Fact]
        public async Task CadastrarAnuncio_semModel()
        {
            var response = await _testContext.Http.PostAsync("/api/Anuncio/CadastrarAnuncio",
              new StringContent(JsonConvert.SerializeObject(new TbAnuncioWebmotors()
              {
                  Marca = "asdaf",
                  Modelo = "",
              }), Encoding.UTF8, "application/json"));

            if ((int)response.StatusCode == StatusCodes.Status400BadRequest)
            {
                Assert.Equal((int)HttpStatusCode.BadRequest, (int)response.StatusCode);
            }
        }

        [Fact]
        public async Task CadastrarAnuncio_semVersao()
        {
            var response = await _testContext.Http.PostAsync("/api/Anuncio/CadastrarAnuncio",
              new StringContent(JsonConvert.SerializeObject(new TbAnuncioWebmotors()
              {
                  Marca = "asdaf",
                  Modelo = "bdfgd",
                  Versao = null
              }), Encoding.UTF8, "application/json"));

            if ((int)response.StatusCode == StatusCodes.Status400BadRequest)
            {
                Assert.Equal((int)HttpStatusCode.BadRequest, (int)response.StatusCode);
            }
        }

        [Fact]
        public async Task CadastrarAnuncio_semObservacao()
        {
            var response = await _testContext.Http.PostAsync("/api/Anuncio/CadastrarAnuncio",
              new StringContent(JsonConvert.SerializeObject(new TbAnuncioWebmotors()
              {
                  Marca = "asdaf",
                  Modelo = "bdfgd",
                  Versao = "vaasasgd",
                  Observacao = ""
              }), Encoding.UTF8, "application/json"));

            if ((int)response.StatusCode == StatusCodes.Status400BadRequest)
            {
                Assert.Equal((int)HttpStatusCode.BadRequest, (int)response.StatusCode);
            }
        }



    }
}
