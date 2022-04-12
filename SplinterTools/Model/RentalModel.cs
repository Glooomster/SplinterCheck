using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplinterTools
{
    

    //public class RentalModel
    //{
    //    public RentalListModel[] Property1 { get; set; }
    //}

    public class RentalModel
    {
        public int id { get; set; }
        public string sell_trx_id { get; set; }
        public string seller { get; set; }
        public int num_cards { get; set; }
        public string buy_price { get; set; }
        public int fee_percent { get; set; }
        public int market_item_id { get; set; }
        public string rental_tx { get; set; }
        public DateTime rental_date { get; set; }
        public string renter { get; set; }
        public int status { get; set; }
        public string market_account { get; set; }
        public int rental_days { get; set; }
        public DateTime next_rental_payment { get; set; }
        public string payment_currency { get; set; }
        public string payment_amount { get; set; }
        public string escrow_currency { get; set; }
        public string escrow_amount { get; set; }
        public string paid_amount { get; set; }
        public string cancel_tx { get; set; }
        public string cancel_player { get; set; }
        public DateTime? cancel_date { get; set; }
        public string card_id { get; set; }
        public int card_detail_id { get; set; }
        public bool gold { get; set; }
        public int xp { get; set; }
        public int edition { get; set; }
    }


}
