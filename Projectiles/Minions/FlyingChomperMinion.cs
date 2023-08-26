using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using TJTTMN.Content.Buffs;
using Terraria.Audio;

namespace TJTTMN.Content.Projectiles.Minions
{
    public class FlyingChomperMinion : ModProjectile
    {
        //Este minion busca ser un subdito bastante poderoso para el pre-hardmode
        //Sin embargo, tiene la limitación de que solo se puede invocar 1 a la vez, ya que la única forma de conseguirlo es con un bonus de armadura

        public override void SetStaticDefaults()
        {
            Main.projFrames[Projectile.type] = 2;
            ProjectileID.Sets.MinionTargettingFeature[Projectile.type] = true;
            Main.projPet[Projectile.type] = true;
            ProjectileID.Sets.CultistIsResistantTo[Projectile.type] = true;
        }
        public sealed override void SetDefaults()
        {
            Projectile.width = 56;
            Projectile.height = 48; //24 de alto cada frame (48 con el 2x2 de pixeles necesarios)
            Projectile.scale = 0.9f;
            Projectile.tileCollide = false;
            Projectile.usesLocalNPCImmunity = true; //Esta linea establece que el minion tiene su propio temporizador de inmunidad para los enemigos
            Projectile.localNPCHitCooldown = 15; //Cada 15 frames el minion podrá hacer daño fisico nuevamente a su objetivo, esto es para evitar daño extra no deseado

            // These below are needed for a minion weapon
            Projectile.friendly = true; // Only controls if it deals damage to enemies on contact (more on that later)
            Projectile.minion = true; // Declares this as a minion (has many effects)
            Projectile.DamageType = DamageClass.Summon; // Declares the damage type (needed for it to deal damage)
            Projectile.minionSlots = 0f; // Amount of slots this minion occupies from the total minion slots available to the player (more on that later)
            Projectile.penetrate = -1; // Needed so the minion doesn't despawn on collision with enemies or tiles
        }
        public override bool? CanCutTiles()
        {
            return false;
        }

        public override bool MinionContactDamage()
        {
            return true;
        }

        public override void AI()
        {
            Player owner = Main.player[Projectile.owner];

            if (!CheckActive(owner))
            {
                return;
            }

            GeneralBehavior(owner, out Vector2 vectorToIdlePosition, out float distanceToIdlePosition, out Vector2 idlePosition);
            SearchTargets(owner, out bool foundTarget, out float distanceFromTarget, out Vector2 targetCenter);
            Movement(foundTarget, distanceFromTarget, targetCenter, distanceToIdlePosition, vectorToIdlePosition);
            Visual(targetCenter, idlePosition, foundTarget);
        }

        private bool CheckActive(Player owner)
        {
            if (owner.dead || !owner.active)
            {
                owner.ClearBuff(ModContent.BuffType<FlyingChomperBuff>());
                return false;
            }

            if (owner.HasBuff(ModContent.BuffType<FlyingChomperBuff>()))
            {
                Projectile.timeLeft = 2;
            }

            return true;
        }

        private void GeneralBehavior(Player owner, out Vector2 vectorToIdlePosition, out float distanceToIdlePosition, out Vector2 idlePosition)
        {
            //Establece la posicion inactiva del minion en 3 tiles arriba del jugador
            idlePosition = owner.Center;
            idlePosition.Y -= 80f;

            //Teletransporta al minion a la posicion del jugador si está a mucha distancia
            vectorToIdlePosition = idlePosition - Projectile.Center;
            distanceToIdlePosition = vectorToIdlePosition.Length();

            if (Main.myPlayer == owner.whoAmI && distanceToIdlePosition > 1500f)
            {
                // Whenever you deal with non-regular events that change the behavior or position drastically, make sure to only run the code on the owner of the projectile,
                // and then set netUpdate to true
                Projectile.position = idlePosition;
                Projectile.velocity *= 0.1f;
                Projectile.netUpdate = true;
            }
        }

        private void SearchTargets(Player owner, out bool foundTarget, out float distanceFromTarget, out Vector2 targetCenter)
        {
            distanceFromTarget = 400; //La distancia maxima a la que detectara enemigos el minion
            targetCenter = Projectile.position;
            foundTarget = false; //Siempre tiene que devolver false por defecto, devolvera true si encuentra un enemigo cerca para ejecutar su ataque


            //Para minions que necesiten encontrar objetivos
            if (owner.HasMinionAttackTargetNPC)
            {
                NPC npc = Main.npc[owner.MinionAttackTargetNPC];
                float between = Vector2.Distance(npc.Center, Projectile.Center);

                if (between < 2000f)
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

                        if ((closest && inRange || between < 400) && npc.whoAmI != NPCID.TargetDummy)
                        {
                            distanceFromTarget = between;
                            targetCenter = npc.Center;
                            foundTarget = true;
                        }
                    }
                }
            }
            //Esta linea solo es necesaria si el minion hace daño fisico
            Projectile.friendly = foundTarget;
        }

        bool changeRotationAttack = false, changeRotationIdle = false;
        private void Movement(bool foundTarget, float distanceFromTarget, Vector2 targetCenter, float distanceToIdlePosition, Vector2 vectorToIdlePosition)
        {

            //Parametros de movimiento por defecto
            float speed = 8f;

            if (foundTarget) //Si el minion encontro un objetivo...
            {
                Vector2 direction = targetCenter - Projectile.Center; //La distancia entre el objetivo y el minion
                direction.Normalize();
                direction *= speed;
                if (distanceFromTarget > 90f) //Si el objetivo está a más de 90 pixeles...
                {
                    Projectile.velocity = direction;
                    changeRotationAttack = true;
                }
                else
                {
                    int genDust = Main.rand.Next(3);
                    if (genDust == 0)
                    {
                        int dust = Dust.NewDust(Projectile.Center, 3, 3, DustID.Ice_Purple);
                        Main.dust[dust].noGravity = true;
                        Main.dust[dust].scale = 0.9f;
                    }
                    changeRotationAttack = false;
                }
            }
            else //Si el minion no tiene objetivo...
            {
                //Hay que hacer que vaya a la posición inactiva, cerca del jugador
                if (distanceToIdlePosition > 160f) //Si esta muy lejos del jugador, debe acelerar
                {
                    speed = 7f;
                }
                else if (distanceToIdlePosition > 100f)
                {
                    speed = 4f;
                }
                else //Si está cerca del jugador, bajará su velocidad
                {
                    speed = 1.5f;
                }

                if (distanceToIdlePosition > 50f)
                {
                    //Esto se ejecuta solo cuando el minion está un poco alejado del jugador 

                    vectorToIdlePosition.Normalize();
                    vectorToIdlePosition *= speed;
                    Projectile.velocity = vectorToIdlePosition;
                    changeRotationIdle = true;
                }
                else
                {
                    changeRotationIdle = false;
                }

                if (Projectile.velocity == Vector2.Zero)
                {
                    //Si por alguna razón el minion no se mueve en absoluto, esta instrucción le dará un empujón

                    Projectile.velocity.X = -0.15f;
                    Projectile.velocity.Y = -0.05f;
                }
            }
        }
        private void Visual (Vector2 targetCenter, Vector2 idlePosition, bool foundTarget)
        {
            //Rotación del sprite dependiendo de a donde mira
            if (foundTarget)
            {
                if (changeRotationAttack)
                {
                    double x = Projectile.Center.X - targetCenter.X;
                    double y = Projectile.Center.Y - targetCenter.Y;
                    Projectile.rotation = (float)Math.Atan2(y, x); //Calcula el angulo al que debe rotar el sprite para mirar a la posicion en la que está el enemigo
                    SoundEngine.PlaySound(new SoundStyle($"{nameof(TJTTMN)}/Content/Sounds/WallOfFleshSoundEffect")
                    {
                        Volume = 0.5f,
                        Pitch =  0.3f,
                    });
                }
            }
            else
            {
                if (changeRotationIdle)
                {
                    double xv = Projectile.Center.X - idlePosition.X;
                    double yv = Projectile.Center.Y - idlePosition.Y;
                    Projectile.rotation = (float)Math.Atan2(yv, xv); //Calcula el angulo al que debe rotar el sprite para mirar a la posicion en la que está el idleposition
                }
            }

            //Intercalador de frames
            int frameSpeed = 12;
            Projectile.frameCounter++;
            if (Projectile.frameCounter >= frameSpeed)
            {
                Projectile.frameCounter = 0;
                Projectile.frame++;

                if (Projectile.frame >= Main.projFrames[Projectile.type])
                {
                    Projectile.frame = 0;
                }
            }

            //Añadir luz al minion
            Lighting.AddLight(Projectile.Center, Color.Purple.ToVector3() * 0.78f);
        }
    }
}
