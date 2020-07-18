using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using STI.Course;
using STI.Course.DTO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace STI.Test
{
    public class DemoTest
    {

        private readonly ITestOutputHelper _outputHelper;
        private readonly WebApplicationFactory<Startup> _factory;

        public DemoTest(ITestOutputHelper outputhelper)
        {
            _factory = new WebApplicationFactory<Startup>();
            _outputHelper = outputhelper;
        }

        //[Fact (Skip = "Doesnt Work")] //Theory, Fact,
        [Fact]

        public async Task GetWarehouse()
        {
            //Arrange 
            //Acomodar datos, servicios, objetos, 
            var client = _factory.CreateDefaultClient();

            //Act
            //Llamar lo que quieres probar
            var response = await client.GetAsync("api/Test/HolaMundo");

            //Assert
            //Verificar que el resultado es el esperado
            Assert.NotNull(response);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            _outputHelper.WriteLine("Todo bien con la prueba");

        }


        [Theory]
        [InlineData(1, "Almacen1", 1)]
        [InlineData(2, "Almacen2", 2)]
        [InlineData(3, "Almacen3", 3)]
        [InlineData(4, "Almacen4", 4)]
        public void CreateWarehouse(int Id, string name, int region)
        {
            //ARRANGE
            var client = _factory.CreateDefaultClient();
            var warehouse = new WarehouseDto()
            {
                Id = Id,
                Name = name,
                Region = region,
            };
            var json = JsonConvert.SerializeObject(warehouse);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

            //ACT
            var response = client.PostAsync("api/Test/CreateWarehouse", content).Result;

            //ASSERT
            Assert.NotNull(response);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var responseContent = response.Content.ReadAsStringAsync().Result;
            _outputHelper.WriteLine(responseContent.AsJson());


        }




    }
}
