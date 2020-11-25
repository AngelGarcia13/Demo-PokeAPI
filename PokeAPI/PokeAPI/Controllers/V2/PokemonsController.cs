using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PokeAPI.Data;
using PokeAPI.Helpers;
using PokeAPI.Interfaces;
using PokeAPI.Models;
using PokeAPI.Services;

namespace PokeAPI.Controllers.V2
{
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Produces("application/json", "application/xml")]
    [ApiExplorerSettings(GroupName = "v2")]
    [ApiController]
    public class PokemonsController : ControllerBase
    {
        int pageSize = 10;

        private IMessageWriter _messageWritter;
        private IPokemonsRepository _pokemonsRepository;

        public PokemonsController(IMessageWriter messageWritter, IPokemonsRepository pokemonsRepository) {
            _messageWritter = messageWritter;
            _pokemonsRepository = pokemonsRepository;
        }

        // GET: api/Pokemons
        [ResponseCache(VaryByQueryKeys = new string[] { "*" }, Duration = 30)]
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Pokemon>))]
        public IEnumerable<Pokemon> GetPokemons(string searchString, string sortBy, int? pageIndex)
        {
            _messageWritter.WriteMessage();
            //If we were pointing to a DB using EF this should be an IQueryable
            var pokemonsQueryResult = _pokemonsRepository.GetAllPokemons();
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
            var paginatedResult = PaginatedList<Pokemon>.Create(
                pokemonsQueryResult, pageIndex ?? 1, pageSize);
            return paginatedResult;
        }

        // GET: api/Pokemons/5
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Pokemon))]
        [ProducesResponseType(404)]
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
        [ProducesResponseType(201, Type = typeof(Pokemon))]
        [ProducesResponseType(400)]
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
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
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
        [ProducesResponseType(200, Type = typeof(Pokemon))]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
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