﻿using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Audio;
using Microsoft.Xna.Framework;
using TJTTMN.Content.Buffs;

namespace TJTTMN.Content.Projectiles
{
    public class ViciousMushroomProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("ViciousMushroomProjectile");
        }
        public override void SetDefaults()
        {
            Projectile.width = 10;
            Projectile.height = 10;
            Projectile.aiStyle = 1;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.penetrate = 1;
            Projectile.timeLeft = 600;
            Projectile.light = 0f;
            Projectile.ignoreWater = false;
            Projectile.tileCollide = true;
            AIType = ProjectileID.WoodenArrowFriendly;
        }
        public override void Kill(int timeLeft)
        {
            Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
            SoundEngine.PlaySound(SoundID.Dig, Projectile.position);
        }
        public override void AI()
        {
            int dust = Dust.NewDust(Projectile.Center, 1, 1, 15, 0f, 0f, 0, Color.Red, 1f);
            Main.dust[dust].noGravity = false;
            Projectile.rotation = Projectile.velocity.ToRotation();
            if (Projectile.spriteDirection == 1)
            {
                Projectile.rotation += MathHelper.Pi;
            }
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(BuffID.Ichor, 240);
        }
    }
}

