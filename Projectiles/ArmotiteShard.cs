﻿using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using TJTTMN.Content.Buffs;

namespace TJTTMN.Content.Projectiles
{
    public class ArmotiteShard : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Armotite shard");
        }
        public override void SetDefaults()
        {
            Projectile.DamageType = DamageClass.Melee;
            Projectile.width = 6;
            Projectile.height = 6;
            Projectile.aiStyle = 0;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.penetrate = 1;
            Projectile.timeLeft = 600;
            Projectile.light = 0;
            Projectile.ignoreWater = false;
            Projectile.tileCollide = true;
        }
        public override void Kill(int timeLeft)
        {
            Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
            SoundEngine.PlaySound(SoundID.Dig, Projectile.position);
        }
        public override void AI()
        {

            if (Main.rand.NextBool(3))
            {
                int dust = Dust.NewDust(Projectile.Center, 1, 1, DustID.Titanium, 0f, 0f, 120);
                Main.dust[dust].noGravity = true;
            }
            Projectile.rotation = Projectile.velocity.ToRotation();
            if (Projectile.spriteDirection == 1)
            {
                Projectile.rotation += MathHelper.Pi;
            }
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(ModContent.BuffType<ArmotiteCut>(), 300);
        }
    }
}