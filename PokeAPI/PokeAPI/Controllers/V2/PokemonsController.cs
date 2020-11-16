using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PokeAPI.Helpers;
using PokeAPI.Models;
using PokeAPI.Services;

namespace PokeAPI.Controllers.V2
{
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Produces("application/json", "application/xml")]
    [ApiController]
    public class PokemonsController : ControllerBase
    {
        // GET: api/Pokemons
        [ResponseCache(VaryByQueryKeys = new string[] { "*" }, Duration = 30)]
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

        // GET: api/Pokemons/5
        [HttpGet("{id}")]
        public IActionResult GetPokemon([FromRoute] string id)
        {
            var pokemon = PokemonsMockDatabase.GetPokemons()
                                              .ToList()
                                              .FirstOrDefault(p => p.Code == id);

            if (pokemon == null)
            {
                return NotFound();
            }

            return Ok(pokemon);
        }

        // POST: api/Pokemons
        [HttpPost]
        public IActionResult PostPokemon([FromBody] Pokemon pokemon)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            PokemonsMockDatabase.CreatePokemon(pokemon);

            return CreatedAtAction("GetPokemon", new { id = pokemon.Code }, pokemon);
        }

        // PUT: api/Pokemons/5
        [HttpPut("{id}")]
        public IActionResult PutPokemon([FromRoute] string id, [FromBody] Pokemon pokemon)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pokemon.Code)
            {
                return BadRequest();
            }

            if (!PokemonsMockDatabase.PokemonExists(pokemon.Code))
            {
                return NotFound();
            }

            PokemonsMockDatabase.UpdatePokemon(pokemon);

            return NoContent();
        }

        // DELETE: api/Pokemons/5
        [HttpDelete("{id}")]
        public IActionResult DeletePokemon([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!PokemonsMockDatabase.PokemonExists(id))
            {
                return NotFound();
            }

            var pokemon = PokemonsMockDatabase.GetPokemons()
                                              .ToList()
                                              .FirstOrDefault(p => p.Code == id);


            PokemonsMockDatabase.Remove(pokemon);

            return Ok(pokemon);
        }
    }


}