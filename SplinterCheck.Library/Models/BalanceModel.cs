

namespace SplinterCheck.Library.Models
{


    public class BalanceModel
    {
        public string player { get; set; }
        public string token { get; set; }
        public float balance { get; set; }
        public int last_reward_block { get; set; }
        public DateTime last_reward_time { get; set; }
    }


}
