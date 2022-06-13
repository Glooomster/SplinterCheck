using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplinterTools.Helpers;

namespace SplinterTools.Processors
{

    public class Quests
    {
        public string GetQuestProgress(int totalEarnedChests, int chest_tier, double rshares)
        {


            int baseRshares = SplinterlandsData.splinterlandsSettings.loot_chests.quest[chest_tier].@base;
            int maxChests = SplinterlandsData.splinterlandsSettings.loot_chests.quest[chest_tier].max;
            double multiplier = SplinterlandsData.splinterlandsSettings.loot_chests.quest[chest_tier].step_multiplier;

            int neededRshares = GetFocusPointsNeeded(baseRshares, multiplier, rshares);

            string response = $"{totalEarnedChests}/{maxChests}|{rshares}/{neededRshares}";
            return response;
        }

        public int CalculateEarnedChests(int chest_tier, double rshares)
        {
            int baseRshares = SplinterlandsData.splinterlandsSettings.loot_chests.quest[chest_tier].@base;
            double multiplier = SplinterlandsData.splinterlandsSettings.loot_chests.quest[chest_tier].step_multiplier;
            int chests = 0;
            int fp_limit = baseRshares;

            while (rshares > fp_limit)
            {
                chests++;
                fp_limit = Convert.ToInt32(baseRshares + fp_limit * multiplier);
            }

            return chests;
        }

        internal int GetFocusPointsNeeded(int baseRshares, double multiplier, double rshares)
        {
            int fp_limit = baseRshares;
            while (rshares > fp_limit)
            {
                fp_limit = Convert.ToInt32(baseRshares + fp_limit * multiplier);
            }
            return fp_limit;
        }


        public string GetCardsColorByQuestType(string questTitle)
        {
            string questType = questTitle.Split(' ').GetValue(0).ToString();

            string response = questType.ToUpper() switch
            {
                "FIRE" => "Red",
                "WATER" => "Blue",
                "LIFE" => "White",
                "DEATH" => "Black",
                "EARTH" => "Green",
                "DRAGON" => "Gold",
                _ => "XXX",
            };
            return response;
        }

    }
}
