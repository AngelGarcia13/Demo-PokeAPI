using System;
using System.Linq;
using PokeAPI.Interfaces;
using PokeAPI.Models;

namespace PokeAPI.Data
{
    public class PokemonsRepository: IPokemonsRepository
    {
        private AppDatabaseContext _appDatabaseContext;

        public PokemonsRepository(AppDatabaseContext appDatabaseContext) {
            _appDatabaseContext = appDatabaseContext;
        }
        public IQueryable<Pokemon> GetAllPokemons()
        {
            return _appDatabaseContext.Pokemons.AsQueryable();
        }
    }
}
