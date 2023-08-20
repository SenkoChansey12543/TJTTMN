using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using TJTTMN.Content.Buffs;

namespace TJTTMN.Common.Systems.GlobalNPCs
{
    internal class ArmotiteCutGlobalNPC : GlobalNPC
    {
        public override bool InstancePerEntity => true;
        public bool armotiteCut;

        public override void ResetEffects(NPC npc)
        {
            armotiteCut = false;
        }

        public override void ModifyIncomingHit(NPC npc, ref NPC.HitModifiers modifiers)
        {
            if (armotiteCut)
            {
                // For best results, defense debuffs should be multiplicative
                modifiers.Defense *= ArmotiteCut.DefenseMultiplier;
            }
        }
    }
}
