

using System;

namespace SplinterTools
{
    public class QuestModel
    {

        public string id { get; set; }
        public string player { get; set; }
        public DateTime created_date { get; set; }
        public int created_block { get; set; }
        public string name { get; set; }
        public int total_items { get; set; }
        public int completed_items { get; set; }
        public object claim_trx_id { get; set; }
        public object claim_date { get; set; }
        public int reward_qty { get; set; }
        public object refresh_trx_id { get; set; }
        public object rewards { get; set; }
        public int chest_tier { get; set; }
        public int rshares { get; set; }
        public int league { get; set; }

    }


    public class DailyLootModel
    {
        public int Base { get; set; }
        public double Step { get; set; }
        public int Level { get; set; }



    }

}




