using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplinterTools.Helpers

{
    public class User
    {
        public string Name { get; set; }

        public int Rating { get; set; }

        public int CollectionPower { get; set; }

        public string completed_items { get; set; }

        public int reward_qty { get; set; }

        public string warning { get; set; }
        public string player { get; set; }
        public DateTime created_date { get; set; }
        public int created_block { get; set; }
        public string name { get; set; }
        public int total_items { get; set; }

        public object claim_trx_id { get; set; }
        public object claim_date { get; set; }

        public string refresh_trx_id { get; set; }
        public object rewards { get; set; }
        public string league { get; set; }

        public int RentCancel { get; set; }

    }

}
