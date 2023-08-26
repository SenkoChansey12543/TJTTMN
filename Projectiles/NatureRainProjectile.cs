﻿using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace TJTTMN.Content.Projectiles
{
    public class NatureRainProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("NatureRainProjectile");
            Main.projFrames[Projectile.type] = 2;
        }
        public override void SetDefaults()
        {
            Projectile.DamageType = DamageClass.Magic;
            Projectile.width = 5;
            Projectile.height = 5;
            Projectile.aiStyle = 0;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.penetrate = 1;
            Projectile.timeLeft = 600;
            Projectile.light = 0.15f;
            Projectile.ignoreWater = false;
            Projectile.tileCollide = true;
        }
        public override void Kill(int timeLeft)
        {
            Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
        }
        public override void AI()
        {
            int dust = Dust.NewDust(Projectile.Center, 1, 1, 15, 0f, 0f, 0, Color.LightBlue, 1f);
            Main.dust[dust].noGravity = false;
            Projectile.rotation = Projectile.velocity.ToRotation(); 
            if (Projectile.spriteDirection == 1)
            {
                Projectile.rotation += MathHelper.Pi;
            }
        }
    }
}
