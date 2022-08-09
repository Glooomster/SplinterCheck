using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplinterCheck.Library.Models
{



    public class BattlesModel
    {
        //public string player { get; set; }
        //public Battle[] battles { get; set; }
    }

    //public class Battle
    //{
    //    public string battle_queue_id_1 { get; set; }
    //    public string battle_queue_id_2 { get; set; }
    //    public int player_1_rating_initial { get; set; }
    //    public int player_2_rating_initial { get; set; }
    //    public string winner { get; set; }
    //    public int player_1_rating_final { get; set; }
    //    public int player_2_rating_final { get; set; }
    //    //public Details details { get; set; }
    //    public string player_1 { get; set; }
    //    public string player_2 { get; set; }
    //    public DateTime created_date { get; set; }
    //    public string match_type { get; set; }
    //    public int mana_cap { get; set; }
    //    public int current_streak { get; set; }
    //    public string ruleset { get; set; }
    //    public string inactive { get; set; }
    //    public string settings { get; set; }
    //    public int block_num { get; set; }
    //    public int rshares { get; set; }
    //    public string dec_info { get; set; }
    //    public int leaderboard { get; set; }
    //    public string reward_dec { get; set; }
    //    public object reward_sps { get; set; }
    //    public bool is_surrender { get; set; }
    //    public string format { get; set; }
    //    //public Player_1_Data player_1_data { get; set; }
    //    //public Player_2_Data player_2_data { get; set; }
    //}

    //public class Details
    //{
    //    public string seed { get; set; }
    //    //public Team1 team1 { get; set; }
    //    //public Team2 team2 { get; set; }
    //    public string winner { get; set; }
    //    public string loser { get; set; }
    //    public string type { get; set; }
    //}

    //public class Team1
    //{
    //    public string player { get; set; }
    //    public int rating { get; set; }
    //    public string color { get; set; }
    //    public Summoner summoner { get; set; }
    //    public Monster[] monsters { get; set; }
    //}

    //public class Summoner
    //{
    //    public string uid { get; set; }
    //    public int xp { get; set; }
    //    public bool gold { get; set; }
    //    public int card_detail_id { get; set; }
    //    public int level { get; set; }
    //    public int edition { get; set; }
    //    public object skin { get; set; }
        //public State state { get; set; }
    //}

    //public class State
    //{
    //    public int[] stats { get; set; }
    //    public string[] abilities { get; set; }
    //}

    //public class Monster
    //{
    //    public string uid { get; set; }
    //    public int xp { get; set; }
    //    public bool gold { get; set; }
    //    public int card_detail_id { get; set; }
    //    public int level { get; set; }
    //    public int edition { get; set; }
    //    public object skin { get; set; }
    //    //public State1 state { get; set; }
    //    public string[] abilities { get; set; }
    //}

    //public class State1
    //{
    //    public bool alive { get; set; }
    //    public int[] stats { get; set; }
    //    public int base_health { get; set; }
    //    public object[][] other { get; set; }
    //}

    //public class Team2
    //{
    //    public string player { get; set; }
    //    public int rating { get; set; }
    //    public string color { get; set; }
    //    public Summoner1 summoner { get; set; }
    //    public Monster1[] monsters { get; set; }
    //}

    //public class Summoner1
    //{
    //    public string uid { get; set; }
    //    public int xp { get; set; }
    //    public bool gold { get; set; }
    //    public int card_detail_id { get; set; }
    //    public int level { get; set; }
    //    public int edition { get; set; }
    //    public object skin { get; set; }
    //    //public State2 state { get; set; }
    //    public string player { get; set; }
    //    public object market_id { get; set; }
    //    public object buy_price { get; set; }
    //    public object market_listing_type { get; set; }
    //    public object market_listing_status { get; set; }
    //    public object market_created_date { get; set; }
    //    public int last_used_block { get; set; }
    //    public string last_used_player { get; set; }
    //    public DateTime last_used_date { get; set; }
    //    public object last_transferred_block { get; set; }
    //    public object last_transferred_date { get; set; }
    //    public int alpha_xp { get; set; }
    //    public object delegated_to { get; set; }
    //    public string delegation_tx { get; set; }
    //    public object delegated_to_display_name { get; set; }
    //    public object display_name { get; set; }
    //    public int lock_days { get; set; }
    //    public object unlock_date { get; set; }
    //}

    //public class State2
    //{
    //    public int[] stats { get; set; }
    //    public string[] abilities { get; set; }
    //}

    //public class Monster1
    //{
    //    public string uid { get; set; }
    //    public int xp { get; set; }
    //    public bool gold { get; set; }
    //    public int card_detail_id { get; set; }
    //    public int level { get; set; }
    //    public int edition { get; set; }
    //    public object skin { get; set; }
    //    //public State3 state { get; set; }
    //    public string[] abilities { get; set; }
    //    public string player { get; set; }
    //    public object market_id { get; set; }
    //    public object buy_price { get; set; }
    //    public object market_listing_type { get; set; }
    //    public object market_listing_status { get; set; }
    //    public object market_created_date { get; set; }
    //    public int last_used_block { get; set; }
    //    public string last_used_player { get; set; }
    //    public DateTime last_used_date { get; set; }
    //    public int? last_transferred_block { get; set; }
    //    public DateTime? last_transferred_date { get; set; }
    //    public int? alpha_xp { get; set; }
    //    public object delegated_to { get; set; }
    //    public string delegation_tx { get; set; }
    //    public object delegated_to_display_name { get; set; }
    //    public object display_name { get; set; }
    //    public int? lock_days { get; set; }
    //    public object unlock_date { get; set; }
    //}

    //public class State3
    //{
    //    public bool alive { get; set; }
    //    public int[] stats { get; set; }
    //    public int base_health { get; set; }
    //    public object[][] other { get; set; }
    //}

    //public class Player_1_Data
    //{
    //    public string name { get; set; }
    //    public DateTime join_date { get; set; }
    //    public int rating { get; set; }
    //    public int battles { get; set; }
    //    public int wins { get; set; }
    //    public int current_streak { get; set; }
    //    public int longest_streak { get; set; }
    //    public int max_rating { get; set; }
    //    public int max_rank { get; set; }
    //    public int modern_rating { get; set; }
    //    public int modern_battles { get; set; }
    //    public int modern_wins { get; set; }
    //    public int modern_current_streak { get; set; }
    //    public int modern_longest_streak { get; set; }
    //    public int modern_max_rating { get; set; }
    //    public int modern_max_rank { get; set; }
    //    public int champion_points { get; set; }
    //    public int capture_rate { get; set; }
    //    public int last_reward_block { get; set; }
    //    public DateTime last_reward_time { get; set; }
    //    public string guild { get; set; }
    //    public string guild_name { get; set; }
    //    public string guild_motto { get; set; }
    //    public string guild_data { get; set; }
    //    public int? guild_level { get; set; }
    //    public int? guild_quest_lodge_level { get; set; }
    //    public bool starter_pack_purchase { get; set; }
    //    public int avatar_id { get; set; }
    //    public object display_name { get; set; }
    //    public object title_pre { get; set; }
    //    public object title_post { get; set; }
    //    public int collection_power { get; set; }
    //    public int league { get; set; }
    //    public int modern_league { get; set; }
    //    public bool adv_msg_sent { get; set; }
    //    public bool modern_adv_msg_sent { get; set; }
    //    public string alt_name { get; set; }
    //    public bool is_banned { get; set; }
    //    public string player_uuid { get; set; }
    //    public object paypal_ban { get; set; }
    //}

    //public class Player_2_Data
    //{
    //    public string name { get; set; }
    //    public DateTime join_date { get; set; }
    //    public int rating { get; set; }
    //    public int battles { get; set; }
    //    public int wins { get; set; }
    //    public int current_streak { get; set; }
    //    public int longest_streak { get; set; }
    //    public int max_rating { get; set; }
    //    public int max_rank { get; set; }
    //    public int modern_rating { get; set; }
    //    public int modern_battles { get; set; }
    //    public int modern_wins { get; set; }
    //    public int modern_current_streak { get; set; }
    //    public int modern_longest_streak { get; set; }
    //    public int modern_max_rating { get; set; }
    //    public int modern_max_rank { get; set; }
    //    public int champion_points { get; set; }
    //    public int capture_rate { get; set; }
    //    public int last_reward_block { get; set; }
    //    public DateTime last_reward_time { get; set; }
    //    public string guild { get; set; }
    //    public string guild_name { get; set; }
    //    public string guild_motto { get; set; }
    //    public string guild_data { get; set; }
    //    public int? guild_level { get; set; }
    //    public int? guild_quest_lodge_level { get; set; }
    //    public bool starter_pack_purchase { get; set; }
    //    public int avatar_id { get; set; }
    //    public object display_name { get; set; }
    //    public object title_pre { get; set; }
    //    public object title_post { get; set; }
    //    public int collection_power { get; set; }
    //    public int league { get; set; }
    //    public int modern_league { get; set; }
    //    public bool adv_msg_sent { get; set; }
    //    public bool modern_adv_msg_sent { get; set; }
    //    public string alt_name { get; set; }
    //    public bool is_banned { get; set; }
    //    public string player_uuid { get; set; }
    //    public object paypal_ban { get; set; }
    //}



}
