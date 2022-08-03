using System;
using System.Collections.Generic;

namespace SplinterCheck.Library.Models

{

    //public class SplinterlandsSettings
    //{
    //    public SplinterlandsSetting[] seting { get; set; }
    //}

    public class SplinterlandsSetting
    {
        public string asset_url { get; set; }
        public float gold_percent { get; set; }
        public int starter_pack_price { get; set; }
        public int booster_pack_price { get; set; }
        public int market_fee { get; set; }
        public int num_editions { get; set; }
        public int modern_num_editions { get; set; }
        public int[] core_editions { get; set; }
        public int[] starter_editions { get; set; }
        public int[] soulbound_editions { get; set; }
        public string[] event_creation_whitelist { get; set; }
        public Bat_Event_List[] bat_event_list { get; set; }
        public int event_entry_fee_required { get; set; }
        public int max_event_entrants { get; set; }
        public int tournaments_creation_fee_dec { get; set; }
        public string account { get; set; }
        public bool stats { get; set; }
        public float[] rarity_pcts { get; set; }
        public int[][] xp_levels { get; set; }
        public int[] alpha_xp { get; set; }
        public int[] gold_xp { get; set; }
        public int[] beta_xp { get; set; }
        public int[] beta_gold_xp { get; set; }
        public int[][] combine_rates { get; set; }
        public int[][] combine_rates_gold { get; set; }
        public Battles battles { get; set; }
        public int multi_lb_start_season { get; set; }
        public Leaderboard_Prizes leaderboard_prizes { get; set; }
        public Leagues leagues { get; set; }
        public Dec dec { get; set; }
        public Guilds guilds { get; set; }
        public Barracks_Perks[][] barracks_perks { get; set; }
        public Fray[][] frays { get; set; }
        public Supported_Currencies[] supported_currencies { get; set; }
        public int transfer_cooldown_blocks { get; set; }
        public DateTime untamed_edition_date { get; set; }
        public string[] active_auth_ops { get; set; }
        public string version { get; set; }
        public int config_version { get; set; }
        public Land_Sale land_sale { get; set; }
        public Chaos_Legion chaos_legion { get; set; }
        public Potion[] potions { get; set; }
        public string[] promotions { get; set; }
        public Sps sps { get; set; }
        public int battles_disabled { get; set; }
        public Loot_Chests loot_chests { get; set; }
        public Daily_Quests[] daily_quests { get; set; }
        public string[] rpc_nodes { get; set; }
        public float dec_price { get; set; }
        public float sps_price { get; set; }
        public bool maintenance_mode { get; set; }
        public Season1 season { get; set; }
        public Brawl_Cycle brawl_cycle { get; set; }
        public Guild_Store_Items[] guild_store_items { get; set; }
        public int last_block { get; set; }
        public long timestamp { get; set; }
        public Chain_Props chain_props { get; set; }
        public int circle_payments_enabled { get; set; }
        public int transak_payments_enabled { get; set; }
        public int zendesk_enabled { get; set; }
        public int dec_max_buy_amount { get; set; }
        public int sps_max_buy_amount { get; set; }
        public bool show_special_store { get; set; }
        public string paypal_acct { get; set; }
        public string paypal_merchant_id { get; set; }
        public string paypal_client_id { get; set; }
        public bool paypal_sandbox { get; set; }
        public Ssc ssc { get; set; }
        public Card_Holding_Accounts[] card_holding_accounts { get; set; }
        public Bridge bridge { get; set; }
        public Ethereum1 ethereum { get; set; }
        public Wax wax { get; set; }
        public Sps_Airdrop sps_airdrop { get; set; }
        public string[] api_ops { get; set; }
    }

    public class Battles
    {
        public string asset_url { get; set; }
        public int default_expiration_seconds { get; set; }
        public int reveal_blocks { get; set; }
        public int win_streak_wins { get; set; }
        public Ruleset[] rulesets { get; set; }
        public Modern modern { get; set; }
    }

    public class Modern
    {
        public int[] editions { get; set; }
        public int[] tiers { get; set; }
    }

    public class Ruleset
    {
        public bool active { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string type { get; set; }
        public string[] invalid { get; set; }
        public int weight { get; set; }
    }

    public class Leaderboard_Prizes
    {
        public Wild wild { get; set; }
        public Modern1 modern { get; set; }
    }

    public class Wild
    {
        public object[] Novice { get; set; }
        public int[] Bronze { get; set; }
        public int[] Silver { get; set; }
        public int[] Gold { get; set; }
        public int[] Diamond { get; set; }
        public int[] Champion { get; set; }
    }

    public class Modern1
    {
        public object[] Novice { get; set; }
        public int[] Bronze { get; set; }
        public int[] Silver { get; set; }
        public int[] Gold { get; set; }
        public int[] Diamond { get; set; }
        public int[] Champion { get; set; }
    }

    public class Leagues
    {
        public Wild1[] wild { get; set; }
        public Modern2[] modern { get; set; }
    }

    public class Wild1
    {
        public string name { get; set; }
        public string group { get; set; }
        public int league_limit { get; set; }
        public int level { get; set; }
        public int min_rating { get; set; }
        public int min_power { get; set; }
        public int season_rating_reset { get; set; }
    }

    public class Modern2
    {
        public string name { get; set; }
        public string group { get; set; }
        public int league_limit { get; set; }
        public int level { get; set; }
        public int min_rating { get; set; }
        public int min_power { get; set; }
        public int season_rating_reset { get; set; }
    }

    public class Dec
    {
        public float streak_bonus { get; set; }
        public float streak_bonus_max { get; set; }
        public int eth_withdrawal_fee { get; set; }
        public int mystery_potion_blocks { get; set; }
        public int dice_cost { get; set; }
        public int dice_available { get; set; }
        public int orb_cost { get; set; }
        public int orbs_available { get; set; }
        public float max_burn_bonus { get; set; }
        public int gold_burn_bonus { get; set; }
        public float beta_bonus { get; set; }
        public int[] burn_rate { get; set; }
        public int gold_burn_bonus_2 { get; set; }
        public int[] untamed_burn_rate { get; set; }
        public int start_block { get; set; }
        public int reduction_blocks { get; set; }
        public int reduction_pct { get; set; }
        public int alpha_burn_bonus { get; set; }
        public int pool_size_blocks { get; set; }
        public float ecr_regen_rate { get; set; }

   //     public float ecr_reduction_rate { get; set; }
        public int promo_burn_bonus { get; set; }
        public float alpha_bonus { get; set; }
        public string prize_pool_account { get; set; }
        public int curve_reduction { get; set; }
        public int pool_cut_pct { get; set; }
        public float gold_bonus { get; set; }
        public int tokens_per_block { get; set; }
        public int curve_constant { get; set; }
    }

    public class Guilds
    {
        public Guild_Hall guild_hall { get; set; }
        public int creation_fee { get; set; }
        public int[] dec_bonus_pct { get; set; }
        public int[] shop_discount_pct { get; set; }
        public string[] rank_names { get; set; }
        public Quest_Lodge quest_lodge { get; set; }
        public Guild_Shop guild_shop { get; set; }
        public float[] merit_multiplier { get; set; }
        public int merit_constant { get; set; }
        public int max_brawl_size { get; set; }
        public Barracks barracks { get; set; }
        public int brawl_prep_duration { get; set; }
        public Arena arena { get; set; }
        public int brawl_combat_duration { get; set; }
        public int brawl_results_duration { get; set; }
        public int brawl_cycle_end_offset { get; set; }
        public int brawl_staggered_start_interval { get; set; }
        public float[] crown_split_pct { get; set; }
        public float[] crown_multiplier { get; set; }
        public int current_fray_edition { get; set; }
    }

    public class Guild_Hall
    {
        public string symbol { get; set; }
        public int[] levels { get; set; }
        public int[] member_limit { get; set; }
    }

    public class Quest_Lodge
    {
        public string symbol { get; set; }
        public int[] levels { get; set; }
    }

    public class Guild_Shop
    {
        public Cost[] cost { get; set; }
    }

    public class Cost
    {
        public string symbol { get; set; }
        public int[] levels { get; set; }
    }

    public class Barracks
    {
        public Cost1[] cost { get; set; }
    }

    public class Cost1
    {
        public string symbol { get; set; }
        public int[] levels { get; set; }
    }

    public class Arena
    {
        public Cost2[] cost { get; set; }
    }

    public class Cost2
    {
        public string symbol { get; set; }
        public int[] levels { get; set; }
    }

    public class Land_Sale
    {
        public int plot_price { get; set; }
        public int tract_price { get; set; }
        public int region_price { get; set; }
        public int plots_available { get; set; }
        public int plot_plots { get; set; }
        public int tract_plots { get; set; }
        public int region_plots { get; set; }
        public DateTime start_date { get; set; }
    }

    public class Chaos_Legion
    {
        public DateTime pre_sale_start { get; set; }
        public int pack_price { get; set; }
        public Airdrop[] airdrops { get; set; }
        public DateTime pre_sale_end { get; set; }
        public int voucher_drop_duration { get; set; }
        public DateTime voucher_drop_start { get; set; }
        public DateTime sale2_end { get; set; }
        public int voucher_drop_rate { get; set; }
        public DateTime sale3_start { get; set; }
        public DateTime main_sale_start { get; set; }
    }

    public class Airdrop
    {
        public string name { get; set; }
        public int id { get; set; }
        public float chance { get; set; }
        public int gold_guarantee { get; set; }
        public DateTime claim_date { get; set; }
        public float gold_chance { get; set; }
    }

    public class Sps
    {
        public Staking_Rewards staking_rewards { get; set; }
        public int unstaking_periods { get; set; }
        public int unstaking_interval_seconds { get; set; }
        public float staking_rewards_acc_tokens_per_share { get; set; }
        public Staking_Rewards_Voucher staking_rewards_voucher { get; set; }
        public int staking_rewards_voucher_last_reward_block { get; set; }
        public float staking_rewards_voucher_acc_tokens_per_share { get; set; }
        public int staking_rewards_last_reward_block { get; set; }
    }

    public class Staking_Rewards
    {
        public float tokens_per_block { get; set; }
        public int reduction_blocks { get; set; }
        public int reduction_pct { get; set; }
        public int start_block { get; set; }
    }

    public class Staking_Rewards_Voucher
    {
        public float tokens_per_block { get; set; }
        public int start_block { get; set; }
    }

    public class Loot_Chests
    {
        public Quest[] quest { get; set; }
        public Season[] season { get; set; }
        public Boosts boosts { get; set; }
    }

    public class Boosts
    {
        public Bronze bronze { get; set; }
        public Silver silver { get; set; }
        public Gold gold { get; set; }
        public Diamond diamond { get; set; }
        public Champion champion { get; set; }
    }

    public class Bronze
    {
        public float rarity_boost { get; set; }
        public int token_multiplier { get; set; }
    }

    public class Silver
    {
        public int rarity_boost { get; set; }
        public int token_multiplier { get; set; }
    }

    public class Gold
    {
        public float rarity_boost { get; set; }
        public int token_multiplier { get; set; }
    }

    public class Diamond
    {
        public int rarity_boost { get; set; }
        public int token_multiplier { get; set; }
    }

    public class Champion
    {
        public int rarity_boost { get; set; }
        public int token_multiplier { get; set; }
    }

    public class Quest
    {
        public int @base { get; set; }
        public float step_multiplier { get; set; }
        public int max { get; set; }
    }

    public class Season
    {
        public int @base { get; set; }
        public float step_multiplier { get; set; }
        public int max { get; set; }
    }

    public class Season1
    {
        public int id { get; set; }
        public string name { get; set; }
        public DateTime ends { get; set; }
        public string[] reward_packs { get; set; }
        public object reset_block_num { get; set; }
    }

    public class Brawl_Cycle
    {
        public int id { get; set; }
        public string name { get; set; }
        public DateTime start { get; set; }
        public int status { get; set; }
        public object reset_block_num { get; set; }
        public DateTime end { get; set; }
    }

    public class Chain_Props
    {
        public DateTime time { get; set; }
        public int ref_block_num { get; set; }
        public string ref_block_id { get; set; }
        public long ref_block_prefix { get; set; }
    }

    public class Ssc
    {
        public string rpc_url { get; set; }
        public string chain_id { get; set; }
        public string hive_rpc_url { get; set; }
        public string hive_chain_id { get; set; }
        public string alpha_token { get; set; }
        public string beta_token { get; set; }
        public string pack_holding_account { get; set; }
    }

    public class Bridge
    {
        public Ethereum ethereum { get; set; }
        public Bsc bsc { get; set; }
    }

    public class Ethereum
    {
        public DEC1 DEC { get; set; }
        public SPS1 SPS { get; set; }
    }

    public class DEC1
    {
        public bool enabled { get; set; }
        public string game_wallet { get; set; }
        public int min_amount { get; set; }
        public float fee_pct { get; set; }
    }

    public class SPS1
    {
        public bool enabled { get; set; }
        public string game_wallet { get; set; }
        public int min_amount { get; set; }
        public float fee_pct { get; set; }
    }

    public class Bsc
    {
        public DEC2 DEC { get; set; }
        public SPS2 SPS { get; set; }
    }

    public class DEC2
    {
        public bool enabled { get; set; }
        public string game_wallet { get; set; }
        public int min_amount { get; set; }
        public float fee_pct { get; set; }
    }

    public class SPS2
    {
        public bool enabled { get; set; }
        public string game_wallet { get; set; }
        public int min_amount { get; set; }
        public float fee_pct { get; set; }
    }

    public class Ethereum1
    {
        public int withdrawal_fee { get; set; }
        public int sps_withdrawal_fee { get; set; }
        public Contracts contracts { get; set; }
    }

    public class Contracts
    {
        public Cards cards { get; set; }
        public Crystals crystals { get; set; }
        public Payments payments { get; set; }
    }

    public class Cards
    {
        public Abi abi { get; set; }
        public string address { get; set; }
    }

    public class Abi
    {
        public string status { get; set; }
        public string message { get; set; }
        public string result { get; set; }
    }

    public class Crystals
    {
        public Abi1 abi { get; set; }
        public string address { get; set; }
    }

    public class Abi1
    {
        public string status { get; set; }
        public string message { get; set; }
        public string result { get; set; }
    }

    public class Payments
    {
        public Abi2 abi { get; set; }
        public string address { get; set; }
    }

    public class Abi2
    {
        public string status { get; set; }
        public string message { get; set; }
        public string result { get; set; }
    }

    public class Wax
    {
        public bool login_enabled { get; set; }
        public string client_id { get; set; }
        public string auth_url { get; set; }
        public External external { get; set; }
    }

    public class External
    {
        public Token token { get; set; }
        public Atomicassets atomicassets { get; set; }
    }

    public class Token
    {
        public string account { get; set; }
    }

    public class Atomicassets
    {
        public string account { get; set; }
    }

    public class Sps_Airdrop
    {
        public DateTime start_date { get; set; }
        public int current_airdrop_day { get; set; }
        public float sps_per_day { get; set; }
    }

    public class Bat_Event_List
    {
        public string id { get; set; }
        public int bat { get; set; }
    }

    public class Barracks_Perks
    {
        public string bonus { get; set; }
        public int delta { get; set; }
        public string stat { get; set; }
        public string target { get; set; }
    }

    public class Fray
    {
        public object[] editions { get; set; }
        public string foil { get; set; }
        public int rating_level { get; set; }
    }

    public class Supported_Currencies
    {
        public string name { get; set; }
        public string currency { get; set; }
        public string type { get; set; }
        public bool tournament_enabled { get; set; }
        public bool payment_enabled { get; set; }
        public float usd_value { get; set; }
        public int precision { get; set; }
        public string contract_address { get; set; }
        public string payment_address { get; set; }
        public Networks networks { get; set; }
        public string token_id { get; set; }
        public string asset_name { get; set; }
        public string symbol { get; set; }
    }

    public class Networks
    {
        public string eth { get; set; }
        public string bsc { get; set; }
    }

    public class Potion
    {
        public string id { get; set; }
        public string name { get; set; }
        public int item_id { get; set; }
        public int price_per_charge { get; set; }
        public int value { get; set; }
        public Bonus[] bonuses { get; set; }
    }

    public class Bonus
    {
        public int min { get; set; }
        public int bonus_pct { get; set; }
    }

    public class Daily_Quests
    {
        public string name { get; set; }
        public bool active { get; set; }
        public string objective_type { get; set; }
        public int min_rating { get; set; }
        public Data data { get; set; }
    }

    public class Data
    {
        public string color { get; set; }
        public string action { get; set; }
        public string splinter { get; set; }
        public string value { get; set; }
        public string description { get; set; }
    }

    public class Guild_Store_Items
    {
        public string name { get; set; }
        public string short_desc { get; set; }
        public int unlock_level { get; set; }
        public Cost3 cost { get; set; }
        public string icon { get; set; }
        public string icon_sm { get; set; }
        public string color { get; set; }
        public string unit_of_purchase { get; set; }
        public string symbol { get; set; }
        public string plural { get; set; }
    }

    public class Cost3
    {
        public string symbol { get; set; }
        public int amount { get; set; }
    }

    public class Card_Holding_Accounts
    {
        public string blockchainName { get; set; }
        public string accountName { get; set; }
    }


}
