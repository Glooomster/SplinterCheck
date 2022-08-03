
using System;

namespace SplinterCheck.Library.Models
{




    public class SplinterModel
    {
        public string name { get; set; }
        public DateTime join_date { get; set; }
        public int rating { get; set; }
        public int battles { get; set; }
        public int wins { get; set; }
        public int current_streak { get; set; }
        public int longest_streak { get; set; }
        public int max_rating { get; set; }
        public int max_rank { get; set; }
        public int champion_points { get; set; }
        public int capture_rate { get; set; }
        public int last_reward_block { get; set; }
        public Guild guild { get; set; }
        public bool starter_pack_purchase { get; set; }
        public int avatar_id { get; set; }
        public object display_name { get; set; }
        public object title_pre { get; set; }
        public object title_post { get; set; }
        public int collection_power { get; set; }
        public int league { get; set; }
        public bool adv_msg_sent { get; set; }
        public bool is_banned { get; set; }
        public int modern_rating { get; set; }
        public int modern_battles { get; set; }
        public int modern_wins { get; set; }
        public int modern_current_streak { get; set; }
        public int modern_longest_streak { get; set; }
        public int modern_max_rating { get; set; }
        public int modern_max_rank { get; set; }
        public int modern_league { get; set; }
        public bool modern_adv_msg_sent { get; set; }
        public object paypal_ban { get; set; }
        public string player_uuid { get; set; }

    }

    public class Guild
    {
        public string id { get; set; }
        public string name { get; set; }
        public string owner { get; set; }
        public DateTime created_date { get; set; }
        public string membership_type { get; set; }
        public string language { get; set; }
        public string motto { get; set; }
        public string description { get; set; }
        public Data data { get; set; }
        public int level { get; set; }
        public Buildings buildings { get; set; }
        public int quest_lodge_level { get; set; }
        public int brawl_status { get; set; }
        public int crowns { get; set; }
        public int brawl_level { get; set; }
        public string tournament_id { get; set; }
        public int spy_uses { get; set; }
        public bool spy_active { get; set; }
        public int tournament_status { get; set; }
        public Tournament_Data tournament_data { get; set; }
    }


    public class Crest
    {
        public string banner { get; set; }
        public string decal { get; set; }
    }

    public class Buildings
    {
        public Guild_Hall guild_hall { get; set; }
        public Quest_Lodge quest_lodge { get; set; }
        public Arena arena { get; set; }
        public Barracks barracks { get; set; }
        public Guild_Shop guild_shop { get; set; }
    }




    public class Tournament_Data
    {
        public int duration_blocks { get; set; }
        public bool multiple_rounds { get; set; }
        public int cp_min { get; set; }
        public int spsp_min { get; set; }
        public int group_size { get; set; }
        public int create_team_seconds { get; set; }
        public int challenge_level { get; set; }
        public string[] guilds { get; set; }
        public int crown_pot { get; set; }
    }

}
