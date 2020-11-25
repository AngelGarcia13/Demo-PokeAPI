using System;
using System.Linq;
using PokeAPI.Models;

namespace PokeAPI.Interfaces
{
    public interface IPokemonsRepository
    {
        IQueryable<Pokemon> GetAllPokemons();
    }
}
