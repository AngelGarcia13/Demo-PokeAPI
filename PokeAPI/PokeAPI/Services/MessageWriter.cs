using System;
using PokeAPI.Interfaces;

namespace PokeAPI.Services
{
    public class MessageWriter: IMessageWriter
    {
        public void WriteMessage() {
            Console.WriteLine("Hello world!");
            //This goes to a Prod Database
        }
    }
}
