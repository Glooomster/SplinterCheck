﻿using Newtonsoft.Json.Linq;

namespace SplinterCheck.Library.Models
{ 

    public class BattleDetails
    {
        public string Seed { get; set; } = string.Empty;

       


        public Team Team1 { get; set; } = new Team();
        public Team Team2 { get; set; } = new Team();


        public string Winner { get; set; } = string.Empty;
        public string Loser { get; set; } = string.Empty;

        public override string ToString()
        {
            return $"{{ seed: { Seed }}}";
        }
    }
}
