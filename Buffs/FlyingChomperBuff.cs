using System;
using Terraria;
using Terraria.ModLoader;

namespace TJTTMN.Content.Buffs
{
    public class FlyingChomperBuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.buffNoSave[Type] = true; //Won't save the buff after exiting world
            Main.buffNoTimeDisplay[Type] = true; //Won't display the buff time remaining
        }
        public override void Update(Player player, ref int buffIndex)
        {
        }
    }
}
