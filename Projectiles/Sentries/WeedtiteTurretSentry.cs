using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.Audio;
using TJTTMN.Content.Projectiles.Minions;


namespace TJTTMN.Content.Projectiles.Sentries
{
    public class WeedtiteTurretSentry : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.MinionTargettingFeature[Projectile.type] = true;
            Main.projFrames[Projectile.type] = 5;
        }

        public sealed override void SetDefaults()
        {
            Projectile.width = 28;
            Projectile.height = 36;
            Projectile.tileCollide = true;
            Projectile.scale = 1f;
     
            Projectile.sentry = true; // Declares this as a sentry (has many effects)
            Projectile.timeLeft = Projectile.SentryLifeTime; //Para que dure el tiempo que vive una torreta estándar
            Projectile.DamageType = DamageClass.Summon; //Declares the damage type (needed for it to deal damage)
            Projectile.penetrate = -1; //Needed so the sentry doesn't despawn on collision with enemies or tiles
        }

        bool tileCollideChecker = false;
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Player owner = Main.player[Projectile.owner];

            if (!tileCollideChecker)
            {
                if (Main.MouseWorld.X > owner.Center.X) //Si el mouse está a la derecha del jugador...
                {
                    Projectile.spriteDirection = 1; //La torreta aparecerá mirando a la derecha
                }
                else //Si el mouse está a la izquierda del jugador...
                {
                    Projectile.spriteDirection = -1; //La torreta aparecerá mirando a la izquierda
                }
            }
            tileCollideChecker = true;
            return false;
        }

        public override bool? CanCutTiles()
        {
            return false;
        }

        public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough, ref Vector2 hitboxCenterFrac)
        {
            fallThrough = false;
            return true;
        }


        public override void AI()
        {
            Player owner = Main.player[Projectile.owner];
            if (!tileCollideChecker)
            {
                Projectile.velocity.Y = 4000f;
            }
            else
            {
                Projectile.velocity.Y = 5f;  //La torreta caera
            }
            
       

            SearchTargets(owner, out bool foundTarget, out float distanceFromTarget, out Vector2 targetCenter);
            Attack(foundTarget, targetCenter);
            FrameLoop(foundTarget);
        }

        private void SearchTargets (Player owner, out bool foundTarget, out float distanceFromTarget, out Vector2 targetCenter)
        {
            distanceFromTarget = 600f;
            targetCenter = Projectile.position;
            foundTarget = false;

            if (owner.HasMinionAttackTargetNPC)
            {
                NPC npc = Main.npc[owner.MinionAttackTargetNPC];
                float between = Vector2.Distance(npc.Center, Projectile.Center);
                if (between < 700f && npc.whoAmI != NPCID.TargetDummy)
                {
                    distanceFromTarget = between;
                    targetCenter = npc.Center;
                    foundTarget = true;
                }
            }

            if (!foundTarget)
            {
                // This code is required either way, used for finding a target
                for (int i = 0; i < Main.maxNPCs; i++)
                {
                    NPC npc = Main.npc[i];

                    if (npc.CanBeChasedBy())
                    {
                        float between = Vector2.Distance(npc.Center, Projectile.Center);
                        bool closest = Vector2.Distance(Projectile.Center, targetCenter) > between;
                        bool inRange = between < distanceFromTarget;
                        bool lineOfSight = Collision.CanHitLine(Projectile.position, Projectile.width, Projectile.height, npc.position, npc.width, npc.height);

                        if ((closest && inRange || !foundTarget) && (between < 600f) && (lineOfSight))
                        {
                            distanceFromTarget = between;
                            targetCenter = npc.Center;
                            foundTarget = true;
                        }
                    }
                }
            }
        }

        int CounterShoot = 0;
        private void Attack(bool foundTarget, Vector2 targetCenter)
        {
            float speed = 8f;
            if (foundTarget)
            {
                Vector2 shootSpawn;
                shootSpawn.Y = Projectile.Center.Y - 8f; //El proyectil a disparar por la torreta se generara un poco mas arriba

                if (targetCenter.X > Projectile.position.X) //Si el objetivo está a la derecha...
                {
                    shootSpawn.X = Projectile.Center.X + 14f;
                    Projectile.spriteDirection = 1;
                    //Generar el disparo un poco mas a la derecha y mirar en esa direccion
                }
                else //Si el objetivo está a la izquierda...
                { 
                    shootSpawn.X = Projectile.Center.X - 14f;
                    Projectile.spriteDirection = -1;
                    //Generar el disparo un poco mas a la izquierda y mirar en esa direccion
                }

                Vector2 direction = targetCenter - shootSpawn;
                direction.Normalize();
                direction *= speed;

                CounterShoot++;
                if (CounterShoot == 8) //Dispara una vez cada 8 frames
                {
                    if (Main.myPlayer == Projectile.owner)
                    {

                        Projectile.NewProjectile(Projectile.GetSource_FromAI(), shootSpawn, direction, ProjectileID.Bullet, 1, 0.01f, Main.myPlayer);
                        CounterShoot = 0;
                        SoundEngine.PlaySound(new SoundStyle($"{nameof(TJTTMN)}/Content/Sounds/GrassRock")
                        {
                            Volume = 0.6f,
                        });
                    }
                }
            }
        }

        private void FrameLoop (bool foundTarget)
        {
            int frameSpeed = 2;
            Projectile.frameCounter++;
            if (foundTarget)
            {
                if (Projectile.frameCounter >= frameSpeed)
                {
                    Projectile.frameCounter = 0;
                    Projectile.frame++;

                    if (Projectile.frame >= Main.projFrames[Projectile.type])
                    {
                        Projectile.frame = 0;
                    }
                }
            }
            else
            {
                Projectile.frame = 0;
            }
        }
    }
}
