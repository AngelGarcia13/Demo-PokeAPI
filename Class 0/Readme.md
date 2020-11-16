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


8 - Let's add searching, sorting and pagination to the Get Pokemons method in the V2 controller.

        // GET: api/Pokemons
        [HttpGet]
        public IEnumerable<Pokemon> GetPokemons(string searchString, string sortBy, int? pageIndex)
        {
            //If we were pointing to a DB using EF this should be an IQueryable
            var pokemonsQueryResult = PokemonsMockDatabase.GetPokemons().AsQueryable(); 
            //Searching (non case-sensitive)
            if (!String.IsNullOrEmpty(searchString))
            {
                pokemonsQueryResult = pokemonsQueryResult.Where(s => s.Name.ToUpper().Contains(searchString.ToUpper())
                                       || s.Code.ToUpper().Contains(searchString.ToUpper()));
            }

            //Sorting
            pokemonsQueryResult = sortBy switch
            {
                "name" => pokemonsQueryResult.OrderBy(s => s.Name),
                "name_desc" => pokemonsQueryResult.OrderByDescending(s => s.Name),
                "code" => pokemonsQueryResult.OrderBy(s => s.Code),
                "code_desc" => pokemonsQueryResult.OrderByDescending(s => s.Code),
                _ => pokemonsQueryResult.OrderBy(s => s.Code),
            };

            //Paging
            int pageSize = 10;
            var paginatedResult = PaginatedList<Pokemon>.Create(
                pokemonsQueryResult, pageIndex ?? 1, pageSize);
            return paginatedResult;
        }


    namespace PokeAPI.Helpers
    {
        public class PaginatedList<T> : List<T>
        {
            public int PageIndex { get; private set; }
            public int TotalPages { get; private set; }
    
            public PaginatedList(List<T> items, int count, int pageIndex, int pageSize)
            {
                PageIndex = pageIndex;
                TotalPages = (int)Math.Ceiling(count / (double)pageSize);
                this.AddRange(items);
            }
    
            public bool HasPreviousPage
            {
                get { return (PageIndex > 1); }
            }
    
            public bool HasNextPage
            {
                get { return (PageIndex < TotalPages); }
            }
    
            public static PaginatedList<T> Create(
                IQueryable<T> source, int pageIndex, int pageSize)
            {
                var count = source.Count();//With EF .CountAsync()
                var items = source.Skip((pageIndex - 1) * pageSize)
                    .Take(pageSize).ToList();//With EF .ToListAsync()
                return new PaginatedList<T>(items, count, pageIndex, pageSize);
            }
        }
    }