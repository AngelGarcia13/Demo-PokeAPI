1 - Add the Nuget Package Microsoft.AspNetCore.Mvc.Versioning to the API project.

2 - Modify in the Startup Class the following method:

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApiVersioning(config =>
                {
                    config.AssumeDefaultVersionWhenUnspecified = true;
                    config.DefaultApiVersion = new ApiVersion(1, 0);
                });
             
            services.AddControllers();
        }

3 - Create the version folders structure under Controllers folder as V1 > PokemonsController and V2 > PokemonsController.


4 - Add the [ApiVersion("MayorVersionNumberHere.MinorVersionNumberHere")].

5 - Test the Query Strings Versioning https://localhost:5001/api/pokemons?api-version=2.0 and https://localhost:5001/api/pokemons?api-version=1.0

6 - To configure the URL Versioning you need to add the parameter v{version:apiVersion} in route attribute like Route(“api/v{version:apiVersion}/[controller]”) so that API version becomes part of URL:

    namespace PokeAPI.Controllers.V1
    {
        [ApiVersion("1.0")]
        [Route("api/v{version:apiVersion}/[controller]")]
        [ApiController]
        public class PokemonsController : ControllerBase
        {
        }
    }


    namespace PokeAPI.Controllers.V2
    {
        [ApiVersion("2.0")]
        [Route("api/v{version:apiVersion}/[controller]")]
        [ApiController]
        public class PokemonsController : ControllerBase
        {
        }
    }

7 - Test the URL Versioning https://localhost:5001/api/v1/pokemons and https://localhost:5001/api/v2/pokemons


8 - Let's add searching to the Get Pokemons method in the V2 controller.
