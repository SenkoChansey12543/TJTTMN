using System;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace TJTTMN.Content.Buffs.WhipBuffs
{
    public class ArmotiteChainBuff : ModBuff
    {
        public static readonly int TagDamage = 5;
        public override void SetStaticDefaults()
        {
            BuffID.Sets.IsAnNPCWhipDebuff[Type] = true;
        }
    }

    public class ArmotiteChainBuffNPC : GlobalNPC
    {
        public override void ModifyHitByProjectile(NPC npc, Projectile projectile, ref NPC.HitModifiers modifiers)
        {
            if (projectile.npcProj || projectile.trap || !projectile.IsMinionOrSentryRelated)
                return;

            var projTagMultiplier = ProjectileID.Sets.SummonTagDamageMultiplier[projectile.type];
            if (npc.HasBuff<ArmotiteChainBuff>())
            {
                modifiers.FlatBonusDamage += ArmotiteChainBuff.TagDamage * projTagMultiplier;
            }
        }
    }
}
