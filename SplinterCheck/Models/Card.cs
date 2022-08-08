using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplinterCheck.Models
{


    //public class Rootobject
    //{
    //    public Class1[] Property1 { get; set; }
    //}

    public class Card
    {
        public int id { get; set; }
        public string name { get; set; }
        public string color { get; set; }
        public string type { get; set; }
        public object sub_type { get; set; }
        public int rarity { get; set; }
        public int drop_rate { get; set; }
        //public Stats stats { get; set; }
        public bool is_starter { get; set; }
        public string editions { get; set; }
        public int? created_block_num { get; set; }
        public string last_update_tx { get; set; }
        public int total_printed { get; set; }
        public bool is_promo { get; set; }
        public int? tier { get; set; }
        //public Distribution[] distribution { get; set; }
    }

    //public class Stats
    //{
    //    public object mana { get; set; }
    //    public object attack { get; set; }
    //    public object ranged { get; set; }
    //    public object magic { get; set; }
    //    public object armor { get; set; }
    //    public object health { get; set; }
    //    public object speed { get; set; }
    //    public object[] abilities { get; set; }
    //}

    //public class Distribution
    //{
    //    public int card_detail_id { get; set; }
    //    public bool gold { get; set; }
    //    public int edition { get; set; }
    //    public string num_cards { get; set; }
    //    public string total_xp { get; set; }
    //    public object num_burned { get; set; }
    //    public object total_burned_xp { get; set; }
    //}


}
