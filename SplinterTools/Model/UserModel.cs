using System;

namespace SplinterTools.Helpers

{
    public class UserModel
    {
        public string Name { get; set; }
        public int Rating { get; set; }
        public int CollectionPower { get; set; }
        public string Completed_items { get; set; }
        public int Reward_qty { get; set; }
        public string Warning { get; set; }
        public string Player { get; set; }
        public DateTime Created_date { get; set; }
        public int Created_block { get; set; }
        public int Total_items { get; set; }
        public object Claim_trx_id { get; set; }
        public object Claim_date { get; set; }
        public string Refresh_trx_id { get; set; }
        public object Rewards { get; set; }
        public string League { get; set; }
        public int RentCancel { get; set; }
        public int Test { get; set; }

    }

}
