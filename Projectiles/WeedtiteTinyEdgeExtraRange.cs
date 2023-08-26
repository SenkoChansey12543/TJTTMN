using System;
using Terraria;
using Terraria.ModLoader;

namespace TJTTMN.Content.Projectiles
{
    public class WeedtiteTinyEdgeExtraRange : ModProjectile
    {
        //Este proyectil fue creado para que spawnee alrededor del jugador al usar la espada corta de weedtite
        //Su proposito es el de extender el rango de ataque de la espada
        //Si no spawneara este proyectil, la espada no podria golpear enemigos muy pequeños o destruir hierba del suelo

        public override void SetDefaults()
        {
            //Hitbox
            Projectile.width = 30;
            Projectile.height = 30;

            //Proyectil invisible
            Projectile.alpha = 255;

            //El proyectil debe ser capaz de atravesar muchos enemigos para simular el comportamiento de la espada al golpear
            //Queremos que el proyectil dure muy poco ya que la espada solo hará daño cada vez que la usemos
            Projectile.penetrate = 100;
            Projectile.timeLeft = 5;

            //Otros
            Projectile.DamageType = DamageClass.Melee;
            Projectile.aiStyle = 1;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.light = 0;
            Projectile.ignoreWater = false;
            Projectile.tileCollide = true;
        }
    }
}
