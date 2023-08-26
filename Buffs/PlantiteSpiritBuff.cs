using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TJTTMN.Content.Projectiles.Minions;

namespace TJTTMN.Content.Buffs
{
    public class PlantiteSpiritBuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.buffNoSave[Type] = true; //Won't save the buff after exiting world
            Main.buffNoTimeDisplay[Type] = true; //Won't display the buff time remaining
        }

        public override void Update(Player player, ref int buffIndex)
        {
            if (player.ownedProjectileCounts[ModContent.ProjectileType<PlantiteSpiritMinion>()] > 0) //If the number of minions summoned is more than zero...
            {
                player.buffTime[buffIndex] = 10000; //Then reset the buff time of the minions
            }
            //The upper code is for avoiding that the buff finish. It will last forever until death or quiting the world
            else //Otherwise...
            {
                player.DelBuff(buffIndex);
                buffIndex--;
                //Delete the buff
            }
        }
    }
}
