using Terraria;
using Terraria.ModLoader;

namespace TJTTMN.Content.Buffs
{
    public class ManaForce : ModBuff
    {
        public override void Update(Player player, ref int buffIndex)
        {
            player.statManaMax2 += 50;
            player.manaRegen += 1;
        }
    }
}
