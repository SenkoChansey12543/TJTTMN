﻿using Terraria;
using Terraria.ModLoader;


namespace TJTTMN.Content.Buffs
{
    public class HeavyWarriorDefense : ModBuff
    {
        public override void SetStaticDefaults()
        {
        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.endurance += 0.45f;
            player.moveSpeed -= 0.8f;
            player.runAcceleration -= 0.07f;
        }
    }
}
