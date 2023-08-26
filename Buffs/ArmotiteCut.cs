using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using TJTTMN.Common.Systems.GlobalNPCs;

namespace TJTTMN.Content.Buffs
{
    public class ArmotiteCut : ModBuff
    {
        public const int DefenseReductionPercent = 6;
        public static float DefenseMultiplier = 1 - DefenseReductionPercent / 100f;

        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GetGlobalNPC<ArmotiteCutGlobalNPC>().armotiteCut = true;
        }
    }
}
