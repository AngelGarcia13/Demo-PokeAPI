1 - Create API project.

2 - Add Models folder.

3 - Create Pokemon Entity (Plain Object with no annotations) in the Models folder.


    public class Pokemon
    {
        public string Code { get; set; }
        public string ImageUrl { get; set; }
        public string Name { get; set; }
        public string Type1 { get; set; }
        public string Type2 { get; set; }
    }

4 -  Add a Services folder.

5 - Create a Class (under Services folder) named PokemonsMockDatabase wich will simulate our Pokemons Database.

    public static class PokemonsMockDatabase
    {
        public static IEnumerable<Pokemon> GetPokemons()
        {
            return pokemonsDB;
        }

        private static List<Pokemon> pokemonsDB = new List<Pokemon> {
                new Pokemon { Code = "001", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/001.png", Name = "Bulbasaur", Type1 = "Grass", Type2 = "Poison"},
                new Pokemon { Code = "002", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/002.png", Name = "Ivysaur", Type1 = "Grass", Type2 = "Poison"},
                new Pokemon { Code = "003", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/003.png", Name = "Venusaur", Type1 = "Grass", Type2 = "Poison"},
                new Pokemon { Code = "004", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/004.png", Name = "Charmander", Type1 = "Fire", Type2 = ""},
                new Pokemon { Code = "005", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/005.png", Name = "Charmeleon", Type1 = "Fire", Type2 = ""},
                new Pokemon { Code = "006", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/006.png", Name = "Charizard", Type1 = "Fire", Type2 = "Flying"},
                new Pokemon { Code = "007", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/007.png", Name = "Squirtle", Type1 = "Water", Type2 = ""},
                new Pokemon { Code = "008", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/008.png", Name = "Wartortle", Type1 = "Water", Type2 = ""},
                new Pokemon { Code = "009", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/009.png", Name = "Blastoise", Type1 = "Water", Type2 = ""},
                new Pokemon { Code = "010", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/010.png", Name = "Caterpie", Type1 = "Bug", Type2 = ""},
                new Pokemon { Code = "011", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/011.png", Name = "Metapod", Type1 = "Bug", Type2 = ""},
                new Pokemon { Code = "012", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/012.png", Name = "Butterfree", Type1 = "Bug", Type2 = "Flying"},
                new Pokemon { Code = "013", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/013.png", Name = "Weedle", Type1 = "Bug", Type2 = "Poison"},
                new Pokemon { Code = "014", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/014.png", Name = "Kakuna", Type1 = "Bug", Type2 = "Poison"},
                new Pokemon { Code = "015", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/015.png", Name = "Beedrill", Type1 = "Bug", Type2 = "Poison"},
                new Pokemon { Code = "016", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/016.png", Name = "Pidgey", Type1 = "Normal", Type2 = "Flying"},
                new Pokemon { Code = "017", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/017.png", Name = "Pidgeotto", Type1 = "Normal", Type2 = "Flying"},
                new Pokemon { Code = "018", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/018.png", Name = "Pidgeot", Type1 = "Normal", Type2 = "Flying"},
                new Pokemon { Code = "019", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/019.png", Name = "Rattata", Type1 = "Normal", Type2 = ""},
                new Pokemon { Code = "020", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/020.png", Name = "Raticate", Type1 = "Normal", Type2 = ""},
                new Pokemon { Code = "021", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/021.png", Name = "Spearow", Type1 = "Normal", Type2 = "Flying"},
                new Pokemon { Code = "022", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/022.png", Name = "Fearow", Type1 = "Normal", Type2 = "Flying"},
                new Pokemon { Code = "023", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/023.png", Name = "Ekans", Type1 = "Poison", Type2 = ""},
                new Pokemon { Code = "024", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/024.png", Name = "Arbok", Type1 = "Poison", Type2 = ""},
                new Pokemon { Code = "025", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/025.png", Name = "Pikachu", Type1 = "Electric", Type2 = ""},
                new Pokemon { Code = "026", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/026.png", Name = "Raichu", Type1 = "Electric", Type2 = ""},
                new Pokemon { Code = "027", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/027.png", Name = "Sandshrew", Type1 = "Ground", Type2 = ""},
                new Pokemon { Code = "028", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/028.png", Name = "Sandslash", Type1 = "Ground", Type2 = ""},
                new Pokemon { Code = "029", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/029.png", Name = "Nidoran♀", Type1 = "Poison", Type2 = ""},
                new Pokemon { Code = "030", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/030.png", Name = "Nidorina", Type1 = "Poison", Type2 = ""},
                new Pokemon { Code = "031", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/031.png", Name = "Nidoqueen", Type1 = "Poison", Type2 = "Ground"},
                new Pokemon { Code = "032", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/032.png", Name = "Nidoran♂", Type1 = "Poison", Type2 = ""},
                new Pokemon { Code = "033", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/033.png", Name = "Nidorino", Type1 = "Poison", Type2 = ""},
                new Pokemon { Code = "034", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/034.png", Name = "Nidoking", Type1 = "Poison", Type2 = "Ground"},
                new Pokemon { Code = "035", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/035.png", Name = "Clefairy", Type1 = "Fairy", Type2 = ""},
                new Pokemon { Code = "036", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/036.png", Name = "Clefable", Type1 = "Fairy", Type2 = ""},
                new Pokemon { Code = "037", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/037.png", Name = "Vulpix", Type1 = "Fire", Type2 = ""},
                new Pokemon { Code = "038", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/038.png", Name = "Ninetales", Type1 = "Fire", Type2 = ""},
                new Pokemon { Code = "039", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/039.png", Name = "Jigglypuff", Type1 = "Normal", Type2 = "Fairy"},
                new Pokemon { Code = "040", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/040.png", Name = "Wigglytuff", Type1 = "Normal", Type2 = "Fairy"},
                new Pokemon { Code = "041", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/041.png", Name = "Zubat", Type1 = "Poison", Type2 = "Flying"},
                new Pokemon { Code = "042", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/042.png", Name = "Golbat", Type1 = "Poison", Type2 = "Flying"},
                new Pokemon { Code = "043", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/043.png", Name = "Oddish", Type1 = "Grass", Type2 = "Poison"},
                new Pokemon { Code = "044", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/044.png", Name = "Gloom", Type1 = "Grass", Type2 = "Poison"},
                new Pokemon { Code = "045", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/045.png", Name = "Vileplume", Type1 = "Grass", Type2 = "Poison"},
                new Pokemon { Code = "046", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/046.png", Name = "Paras", Type1 = "Bug", Type2 = "Grass"},
                new Pokemon { Code = "047", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/047.png", Name = "Parasect", Type1 = "Bug", Type2 = "Grass"},
                new Pokemon { Code = "048", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/048.png", Name = "Venonat", Type1 = "Bug", Type2 = "Poison"},
                new Pokemon { Code = "049", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/049.png", Name = "Venomoth", Type1 = "Bug", Type2 = "Poison"},
                new Pokemon { Code = "050", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/050.png", Name = "Diglett", Type1 = "Ground", Type2 = ""},
                new Pokemon { Code = "051", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/051.png", Name = "Dugtrio", Type1 = "Ground", Type2 = ""},
                new Pokemon { Code = "052", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/052.png", Name = "Meowth", Type1 = "Normal", Type2 = ""},
                new Pokemon { Code = "053", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/053.png", Name = "Persian", Type1 = "Normal", Type2 = ""},
                new Pokemon { Code = "054", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/054.png", Name = "Psyduck", Type1 = "Water", Type2 = ""},
                new Pokemon { Code = "055", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/055.png", Name = "Golduck", Type1 = "Water", Type2 = ""},
                new Pokemon { Code = "056", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/056.png", Name = "Mankey", Type1 = "Fighting", Type2 = ""},
                new Pokemon { Code = "057", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/057.png", Name = "Primeape", Type1 = "Fighting", Type2 = ""},
                new Pokemon { Code = "058", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/058.png", Name = "Growlithe", Type1 = "Fire", Type2 = ""},
                new Pokemon { Code = "059", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/059.png", Name = "Arcanine", Type1 = "Fire", Type2 = ""},
                new Pokemon { Code = "060", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/060.png", Name = "Poliwag", Type1 = "Water", Type2 = ""},
                new Pokemon { Code = "061", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/061.png", Name = "Poliwhirl", Type1 = "Water", Type2 = ""},
                new Pokemon { Code = "062", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/062.png", Name = "Poliwrath", Type1 = "Water", Type2 = "Fighting"},
                new Pokemon { Code = "063", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/063.png", Name = "Abra", Type1 = "Psychic", Type2 = ""},
                new Pokemon { Code = "064", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/064.png", Name = "Kadabra", Type1 = "Psychic", Type2 = ""},
                new Pokemon { Code = "065", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/065.png", Name = "Alakazam", Type1 = "Psychic", Type2 = ""},
                new Pokemon { Code = "066", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/066.png", Name = "Machop", Type1 = "Fighting", Type2 = ""},
                new Pokemon { Code = "067", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/067.png", Name = "Machoke", Type1 = "Fighting", Type2 = ""},
                new Pokemon { Code = "068", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/068.png", Name = "Machamp", Type1 = "Fighting", Type2 = ""},
                new Pokemon { Code = "069", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/069.png", Name = "Bellsprout", Type1 = "Grass", Type2 = "Poison"},
                new Pokemon { Code = "070", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/070.png", Name = "Weepinbell", Type1 = "Grass", Type2 = "Poison"},
                new Pokemon { Code = "071", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/071.png", Name = "Victreebel", Type1 = "Grass", Type2 = "Poison"},
                new Pokemon { Code = "072", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/072.png", Name = "Tentacool", Type1 = "Water", Type2 = "Poison"},
                new Pokemon { Code = "073", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/073.png", Name = "Tentacruel", Type1 = "Water", Type2 = "Poison"},
                new Pokemon { Code = "074", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/074.png", Name = "Geodude", Type1 = "Rock", Type2 = "Ground"},
                new Pokemon { Code = "075", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/075.png", Name = "Graveler", Type1 = "Rock", Type2 = "Ground"},
                new Pokemon { Code = "076", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/076.png", Name = "Golem", Type1 = "Rock", Type2 = "Ground"},
                new Pokemon { Code = "077", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/077.png", Name = "Ponyta", Type1 = "Fire", Type2 = ""},
                new Pokemon { Code = "078", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/078.png", Name = "Rapidash", Type1 = "Fire", Type2 = ""},
                new Pokemon { Code = "079", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/079.png", Name = "Slowpoke", Type1 = "Water", Type2 = "Psychic"},
                new Pokemon { Code = "080", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/080.png", Name = "Slowbro", Type1 = "Water", Type2 = "Psychic"},
                new Pokemon { Code = "081", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/081.png", Name = "Magnemite", Type1 = "Electric", Type2 = "Steel"},
                new Pokemon { Code = "082", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/082.png", Name = "Magneton", Type1 = "Electric", Type2 = "Steel"},
                new Pokemon { Code = "083", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/083.png", Name = "Farfetchd", Type1 = "Normal", Type2 = "Flying"},
                new Pokemon { Code = "084", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/084.png", Name = "Doduo", Type1 = "Normal", Type2 = "Flying"},
                new Pokemon { Code = "085", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/085.png", Name = "Dodrio", Type1 = "Normal", Type2 = "Flying"},
                new Pokemon { Code = "086", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/086.png", Name = "Seel", Type1 = "Water", Type2 = ""},
                new Pokemon { Code = "087", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/087.png", Name = "Dewgong", Type1 = "Water", Type2 = "Ice"},
                new Pokemon { Code = "088", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/088.png", Name = "Grimer", Type1 = "Poison", Type2 = ""},
                new Pokemon { Code = "089", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/089.png", Name = "Muk", Type1 = "Poison", Type2 = ""},
                new Pokemon { Code = "090", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/090.png", Name = "Shellder", Type1 = "Water", Type2 = ""},
                new Pokemon { Code = "091", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/091.png", Name = "Cloyster", Type1 = "Water", Type2 = "Ice"},
                new Pokemon { Code = "092", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/092.png", Name = "Gastly", Type1 = "Ghost", Type2 = "Poison"},
                new Pokemon { Code = "093", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/093.png", Name = "Haunter", Type1 = "Ghost", Type2 = "Poison"},
                new Pokemon { Code = "094", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/094.png", Name = "Gengar", Type1 = "Ghost", Type2 = "Poison"},
                new Pokemon { Code = "095", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/095.png", Name = "Onix", Type1 = "Rock", Type2 = "Ground"},
                new Pokemon { Code = "096", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/096.png", Name = "Drowzee", Type1 = "Psychic", Type2 = ""},
                new Pokemon { Code = "097", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/097.png", Name = "Hypno", Type1 = "Psychic", Type2 = ""},
                new Pokemon { Code = "098", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/098.png", Name = "Krabby", Type1 = "Water", Type2 = ""},
                new Pokemon { Code = "099", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/099.png", Name = "Kingler", Type1 = "Water", Type2 = ""},
                new Pokemon { Code = "100", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/100.png", Name = "Voltorb", Type1 = "Electric", Type2 = ""},
                new Pokemon { Code = "101", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/101.png", Name = "Electrode", Type1 = "Electric", Type2 = ""},
                new Pokemon { Code = "102", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/102.png", Name = "Exeggcute", Type1 = "Grass", Type2 = "Psychic"},
                new Pokemon { Code = "103", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/103.png", Name = "Exeggutor", Type1 = "Grass", Type2 = "Psychic"},
                new Pokemon { Code = "104", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/104.png", Name = "Cubone", Type1 = "Ground", Type2 = ""},
                new Pokemon { Code = "105", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/105.png", Name = "Marowak", Type1 = "Ground", Type2 = ""},
                new Pokemon { Code = "106", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/106.png", Name = "Hitmonlee", Type1 = "Fighting", Type2 = ""},
                new Pokemon { Code = "107", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/107.png", Name = "Hitmonchan", Type1 = "Fighting", Type2 = ""},
                new Pokemon { Code = "108", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/108.png", Name = "Lickitung", Type1 = "Normal", Type2 = ""},
                new Pokemon { Code = "109", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/109.png", Name = "Koffing", Type1 = "Poison", Type2 = ""},
                new Pokemon { Code = "110", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/110.png", Name = "Weezing", Type1 = "Poison", Type2 = ""},
                new Pokemon { Code = "111", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/111.png", Name = "Rhyhorn", Type1 = "Ground", Type2 = "Rock"},
                new Pokemon { Code = "112", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/112.png", Name = "Rhydon", Type1 = "Ground", Type2 = "Rock"},
                new Pokemon { Code = "113", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/113.png", Name = "Chansey", Type1 = "Normal", Type2 = ""},
                new Pokemon { Code = "114", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/114.png", Name = "Tangela", Type1 = "Grass", Type2 = ""},
                new Pokemon { Code = "115", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/115.png", Name = "Kangaskhan", Type1 = "Normal", Type2 = ""},
                new Pokemon { Code = "116", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/116.png", Name = "Horsea", Type1 = "Water", Type2 = ""},
                new Pokemon { Code = "117", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/117.png", Name = "Seadra", Type1 = "Water", Type2 = ""},
                new Pokemon { Code = "118", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/118.png", Name = "Goldeen", Type1 = "Water", Type2 = ""},
                new Pokemon { Code = "119", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/119.png", Name = "Seaking", Type1 = "Water", Type2 = ""},
                new Pokemon { Code = "120", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/120.png", Name = "Staryu", Type1 = "Water", Type2 = ""},
                new Pokemon { Code = "121", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/121.png", Name = "Starmie", Type1 = "Water", Type2 = "Psychic"},
                new Pokemon { Code = "122", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/122.png", Name = "Mr. Mime", Type1 = "Psychic", Type2 = "Fairy"},
                new Pokemon { Code = "123", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/123.png", Name = "Scyther", Type1 = "Bug", Type2 = "Flying"},
                new Pokemon { Code = "124", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/124.png", Name = "Jynx", Type1 = "Ice", Type2 = "Psychic"},
                new Pokemon { Code = "125", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/125.png", Name = "Electabuzz", Type1 = "Electric", Type2 = ""},
                new Pokemon { Code = "126", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/126.png", Name = "Magmar", Type1 = "Fire", Type2 = ""},
                new Pokemon { Code = "127", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/127.png", Name = "Pinsir", Type1 = "Bug", Type2 = ""},
                new Pokemon { Code = "128", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/128.png", Name = "Tauros", Type1 = "Normal", Type2 = ""},
                new Pokemon { Code = "129", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/129.png", Name = "Magikarp", Type1 = "Water", Type2 = ""},
                new Pokemon { Code = "130", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/130.png", Name = "Gyarados", Type1 = "Water", Type2 = "Flying"},
                new Pokemon { Code = "131", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/131.png", Name = "Lapras", Type1 = "Water", Type2 = "Ice"},
                new Pokemon { Code = "132", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/132.png", Name = "Ditto", Type1 = "Normal", Type2 = ""},
                new Pokemon { Code = "133", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/133.png", Name = "Eevee", Type1 = "Normal", Type2 = ""},
                new Pokemon { Code = "134", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/134.png", Name = "Vaporeon", Type1 = "Water", Type2 = ""},
                new Pokemon { Code = "135", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/135.png", Name = "Jolteon", Type1 = "Electric", Type2 = ""},
                new Pokemon { Code = "136", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/136.png", Name = "Flareon", Type1 = "Fire", Type2 = ""},
                new Pokemon { Code = "137", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/137.png", Name = "Porygon", Type1 = "Normal", Type2 = ""},
                new Pokemon { Code = "138", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/138.png", Name = "Omanyte", Type1 = "Rock", Type2 = "Water"},
                new Pokemon { Code = "139", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/139.png", Name = "Omastar", Type1 = "Rock", Type2 = "Water"},
                new Pokemon { Code = "140", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/140.png", Name = "Kabuto", Type1 = "Rock", Type2 = "Water"},
                new Pokemon { Code = "141", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/141.png", Name = "Kabutops", Type1 = "Rock", Type2 = "Water"},
                new Pokemon { Code = "142", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/142.png", Name = "Aerodactyl", Type1 = "Rock", Type2 = "Flying"},
                new Pokemon { Code = "143", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/143.png", Name = "Snorlax", Type1 = "Normal", Type2 = ""},
                new Pokemon { Code = "144", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/144.png", Name = "Articuno", Type1 = "Ice", Type2 = "Flying"},
                new Pokemon { Code = "145", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/145.png", Name = "Zapdos", Type1 = "Electric", Type2 = "Flying"},
                new Pokemon { Code = "146", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/146.png", Name = "Moltres", Type1 = "Fire", Type2 = "Flying"},
                new Pokemon { Code = "147", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/147.png", Name = "Dratini", Type1 = "Dragon", Type2 = ""},
                new Pokemon { Code = "148", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/148.png", Name = "Dragonair", Type1 = "Dragon", Type2 = ""},
                new Pokemon { Code = "149", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/149.png", Name = "Dragonite", Type1 = "Dragon", Type2 = "Flying"},
                new Pokemon { Code = "150", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/150.png", Name = "Mewtwo", Type1 = "Psychic", Type2 = ""},
                new Pokemon { Code = "151", ImageUrl = "https://www.serebii.net/pokemongo/pokemon/151.png", Name = "Mew", Type1 = "Psychic", Type2 = ""}
        };

    }

6 - Create the PokemonsController as Empty API controller.

    [ApiController]
    [Route("api/[controller]")]
    public class PokemonsController: ControllerBase
    {
        public PokemonsController(){}

    }


7 - Implementing GET (Read) all the pokemons.


        // GET: api/Pokemons
        [HttpGet]
        public IEnumerable<Pokemon> GetPokemons()
        {
            return PokemonsMockDatabase.GetPokemons();
        } 

8 - Change the launchUrl in the Properties/launchSettings.json to api/pokemons.

9 - Implementing GET (Read) a pokemon by it's code using Query Strings.

        // GET: api/Pokemons/5
        [HttpGet("{id}")]
        public IActionResult GetPokemon([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var pokemon = PokemonsMockDatabase.GetPokemons()
                                              .ToList()
                                              .FirstOrDefault(p => p.Code == id);

            if (pokemon == null)
            {
                return NotFound();
            }

            return Ok(pokemon);
        }

10 - Adding Annotations for validation rules to the Pokemon Entity [Required].

11 - Implementing POST (Create) a Pokemon using Model Binding Validation.

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

12 - Add the missing method to the PokemonsMockDatabase.

        public static Pokemon CreatePokemon(Pokemon pokemon) {
            pokemonsDB.Add(pokemon);
            return pokemon;
        }

        public static void UpdatePokemon(Pokemon pokemon)
        {
            pokemonsDB[pokemonsDB.FindIndex(p => p.Code == pokemon.Code)] = pokemon;
        }

        public static void Remove(Pokemon pokemon)
        {
            pokemonsDB.Remove(pokemon);
        }

        public static bool PokemonExists(string code)
        {
            return pokemonsDB.Any(p => p.Code == code);
        }

13 - Implementing PUT (Modify) a Pokemon.

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

14 - Implementing DELETE a Pokemon.


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