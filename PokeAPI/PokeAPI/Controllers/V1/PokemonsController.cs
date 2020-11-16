using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PokeAPI.Models;
using PokeAPI.Services;

namespace PokeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonsController : ControllerBase
    {
        // GET: api/Pokemons
        [HttpGet]
        public IEnumerable<Pokemon> GetPokemons()
        {
            return PokemonsMockDatabase.GetPokemons();
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