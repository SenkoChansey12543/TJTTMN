using System;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace TJTTMN.Content.Buffs.WhipBuffs
{
    public class PaliteVineBuff : ModBuff
    {
        public static readonly int TagDamage = 9;
        public override void SetStaticDefaults()
        {
            BuffID.Sets.IsAnNPCWhipDebuff[Type] = true;
        }
    }

    public class PaliteVineBuffNPC : GlobalNPC
    {
        public override void ModifyHitByProjectile(NPC npc, Projectile projectile, ref NPC.HitModifiers modifiers)
        {
            if (projectile.npcProj || projectile.trap || !projectile.IsMinionOrSentryRelated)
                return;

            var projTagMultiplier = ProjectileID.Sets.SummonTagDamageMultiplier[projectile.type];
            if (npc.HasBuff<PaliteVineBuff>())
            {
                modifiers.FlatBonusDamage += PaliteVineBuff.TagDamage * projTagMultiplier;
            }
        }
    }
}
