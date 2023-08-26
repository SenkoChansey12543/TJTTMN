using System;
using System.Diagnostics.Metrics;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using TJTTMN.Content.Buffs;

namespace TJTTMN.Content.Projectiles.Minions
{
    public class PlantiteSpiritMinion : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            Main.projFrames[Projectile.type] = 2;
            ProjectileID.Sets.MinionTargettingFeature[Projectile.type] = true;
            Main.projPet[Projectile.type] = true;
            ProjectileID.Sets.MinionSacrificable[Projectile.type] = true;
            ProjectileID.Sets.CultistIsResistantTo[Projectile.type] = true;
        }

        public sealed override void SetDefaults()
        {
            Projectile.width = 16;
            Projectile.height = 36;
            Projectile.tileCollide = false;
            Projectile.scale = 1.3f;

            // These below are needed for a minion weapon
            Projectile.friendly = true; // Only controls if it deals damage to enemies on contact (more on that later)
            Projectile.minion = true; // Declares this as a minion (has many effects)
            Projectile.DamageType = DamageClass.Summon; // Declares the damage type (needed for it to deal damage)
            Projectile.minionSlots = 1f; // Amount of slots this minion occupies from the total minion slots available to the player (more on that later)
            Projectile.penetrate = -1; // Needed so the minion doesn't despawn on collision with enemies or tiles
        }

        // Here you can decide if your minion breaks things like grass or pots
        public override bool? CanCutTiles()
        {
            return false;
        }

        public override void AI()
        {
            Player owner = Main.player[Projectile.owner];

            if (!CheckActive(owner))
            {
                return;
            }
            GeneralBehavior(owner, out Vector2 vectorToIdlePosition, out float distanceToIdlePosition);
            SearchTargets(owner, out bool foundTarget, out float distanceFromTarget, out Vector2 targetCenter);
            Movement(foundTarget, distanceFromTarget, targetCenter, distanceToIdlePosition, vectorToIdlePosition);
            Visual(owner, targetCenter, foundTarget);
        }

        private bool CheckActive(Player owner)
        {
            if (owner.dead || !owner.active)
            {
                owner.ClearBuff(ModContent.BuffType<PlantiteSpiritBuff>());
                return false;
            }

            if (owner.HasBuff(ModContent.BuffType<PlantiteSpiritBuff>()))
            {
                Projectile.timeLeft = 2;
            }

            return true;
        }

        private void GeneralBehavior(Player owner, out Vector2 vectorToIdlePosition, out float distanceToIdlePosition)
        {
            //Establece la posicion inactiva del minion en 3 tiles arriba del jugador
            Vector2 idlePosition = owner.Center;
            idlePosition.Y -= 48f;

            //Para poner al minion en linea con los otros minion cuando estan inactivos
            float minionPositionOffsetX = (10 + Projectile.minionPos * 40) * -owner.direction;
            idlePosition.X += minionPositionOffsetX;

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

            //Para evitar superposicion con los otros minions
            float overlapVelocity = 0.04f;
            for (int i = 0; i < Main.maxProjectiles; i++)
            {
                Projectile other = Main.projectile[i];

                if (i != Projectile.whoAmI && other.active && other.owner == Projectile.owner && Math.Abs(Projectile.position.X - other.position.X) + Math.Abs(Projectile.position.Y - other.position.Y) < Projectile.width)
                {
                    if (Projectile.position.X < other.position.X)
                    {
                        Projectile.velocity.X -= overlapVelocity;
                    }
                    else
                    {
                        Projectile.velocity.X += overlapVelocity;
                    }

                    if (Projectile.position.Y < other.position.Y)
                    {
                        Projectile.velocity.Y -= overlapVelocity;
                    }
                    else
                    {
                        Projectile.velocity.Y += overlapVelocity;
                    }
                }

            }
        }

        private void SearchTargets(Player owner, out bool foundTarget, out float distanceFromTarget, out Vector2 targetCenter)
        {
            distanceFromTarget = 500f; //La distancia maxima a la que detectara enemigos el minion
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
                        bool lineOfSight = Collision.CanHitLine(Projectile.position, Projectile.width, Projectile.height, npc.position, npc.width, npc.height);
                        // Additional check for this specific minion behavior, otherwise it will stop attacking once it dashed through an enemy while flying though tiles afterwards
                        // The number depends on various parameters seen in the movement code below. Test different ones out until it works alright
                        bool closeThroughWall = between < 100f;

                        if ((closest && inRange || !foundTarget) && (lineOfSight || closeThroughWall) && npc.whoAmI != NPCID.TargetDummy)
                        {
                            distanceFromTarget = between;
                            targetCenter = npc.Center;
                            foundTarget = true;
                        }
                    }
                }
            }

            //Esta linea solo es necesaria si el minion hace daño fisico
            //Projectile.friendly = foundTarget;
        }

        int CounterShoot = 0, CounterNoMovement = 0;
        private void Movement(bool foundTarget, float distanceFromTarget, Vector2 targetCenter, float distanceToIdlePosition, Vector2 vectorToIdlePosition)
        {

            //Parametros de movimiento por defecto
            float speed = 4f;
            float inertia = 10f;
            if (foundTarget) //Si el minion encontro un objetivo...
            {
                Vector2 direction = targetCenter - Projectile.Center; //La distancia entre el objetivo y el minion
                direction.Normalize();
                direction *= speed;
                if (distanceFromTarget > 110f)
                {
                    //Es necesario que el codigo se ejecute solo cuando el minion está un poco alejado del objetivo y no cuando está pegado a el
                    //Si se ejecutara siempre, el minion se quedaría pegado al objetivo todo el tiempo
                    Projectile.velocity = (Projectile.velocity * (inertia - 1) + direction) / inertia;
                }
                else if (distanceFromTarget > 50f)
                {
                    CounterNoMovement++;

                    if (CounterNoMovement <= 120)
                    {
                        Projectile.velocity.X = 0.2f;
                        Projectile.velocity.Y = 0.3f;
                        Projectile.rotation = 0.03f;
                    }
                    else if (CounterNoMovement <= 240)
                    {
                        Projectile.velocity.X = -0.2f;
                        Projectile.velocity.Y = -0.3f;
                        Projectile.rotation = -0.03f;
                    }
                    else
                    {
                        CounterNoMovement = 0;
                    }
                }
                else
                {

                    if (targetCenter.X > Projectile.Center.X) //Si el objetivo está a la derecha...
                    {
                        Projectile.rotation = 0.05f;
                        Projectile.velocity.X = -2f; //Mover a la izquierda
                    }
                    else //Si el objetivo está a la izquierda...
                    {
                        Projectile.rotation = -0.05f;
                        Projectile.velocity.X = 2f; //Mover a la derecha
                    }

                }
                //Para disparar un proyectil cada vez que el contador llegue a 60
                CounterShoot++;
                if (CounterShoot == 60)
                {
                    if (Main.myPlayer == Projectile.owner)
                    {
                        direction *= 2.5f;
                        Projectile.NewProjectile(Projectile.GetSource_FromAI(), Projectile.Center, direction, ModContent.ProjectileType<PlantiteSpiritShoot>(), 25, 3f, Main.myPlayer);
                        SoundEngine.PlaySound(SoundID.Item8);
                        CounterShoot = 0;
                    }
                }

            }
            else //Si el minion no tiene objetivo...
            {
                //Hay que hacer que vaya a la posición inactiva, cerca del jugador
                if (distanceToIdlePosition > 500f) //Si esta muy lejos del jugador, debe acelerar
                {
                    speed = 12f;
                    inertia = 30f;
                }
                else //Si está cerca del jugador, bajará su velocidad
                {
                    speed = 3f;
                    inertia = 6f;
                }

                if (distanceToIdlePosition > 20f)
                {
                    //Esto se ejecuta solo cuando el minion está un poco alejado del jugador 

                    vectorToIdlePosition.Normalize();
                    vectorToIdlePosition *= speed;
                    Projectile.velocity = (Projectile.velocity * (inertia - 1) + vectorToIdlePosition) / inertia;
                }
                else if (Projectile.velocity == Vector2.Zero)
                {
                    //Si por alguna razón el minion no se mueve en absoluto, esta instrucción le dará un empujón

                    Projectile.velocity.X = -0.15f;
                    Projectile.velocity.Y = -0.05f;
                }
            }
        }

        private void Visual(Player owner, Vector2 targetCenter, bool foundTarget)
        {
            //Necesarios para calcular la direccion a la que mirara el minion
            if (foundTarget) //Si el minion encontró objetivo...
            {
                if (targetCenter.X > Projectile.Center.X) //Y el objetivo está a la derecha...
                {
                    Projectile.spriteDirection = 1; //Mirar a la derecha
                }
                else
                {
                    Projectile.spriteDirection = -1; //Mirar a la izquierda
                }
            }
            else //Si el minion no encontró objetivo...
            {
                if (owner.Center.X > Projectile.Center.X)
                {
                    Projectile.spriteDirection = 1;
                }
                else
                {
                    Projectile.spriteDirection = -1;
                }
            }

            //Cuando el minion esté completamente quieto, se inclinará un poco hacia la dirección a la que mira
            if (Projectile.velocity.X == 0)
            {
                if (targetCenter.X > Projectile.Center.X)
                {
                    Projectile.rotation = 0.15f; //A la derecha
                }
                else
                {
                    Projectile.rotation = -0.15f; //A la izquierda
                }
            }
            else
            {
                //Esto hará que el minion rote ligeramente hacia la posición que está yendo
                Projectile.rotation = Projectile.velocity.X * 0.04f;
            }

            //El codigo de abajo permite hacer un bucle entre los distintos frames del minion para hacer la animacion
            //Solo hay que modificar la variable "frameSpeed" para poner la velocidad a la que queremos que pasen los frames
            //Luego el codigo se encarga de detectar los frames del minion que establecimos en setstaticdefaults, y cambia segun la velocidad que pusimos
            int frameSpeed = 20;
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


            //Para que emita luz el minion
            Lighting.AddLight(Projectile.Center, Color.LightBlue.ToVector3() * 0.78f);
        }
    }
}
