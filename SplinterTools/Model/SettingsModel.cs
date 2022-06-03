using System;

namespace SplinterTools
{

    [Serializable]



    public class leagues
    {
        public string name { get; set; }
        public string group { get; set; }
        public int league_limit { get; set; }
        public int level { get; set; }
        public int min_rating { get; set; }
        public int min_power { get; set; }
        public int season_rating_reset { get; set; }
    }

}