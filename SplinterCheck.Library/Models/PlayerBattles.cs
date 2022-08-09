using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace SplinterCheck.Library.Models
{
    public class PlayerBattles
    {
        public string Player { get; set; } = String.Empty;
        public List<Battle> Battles { get; set; } = new List<Battle>();
    }
}
