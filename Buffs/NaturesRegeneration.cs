using Terraria;
using Terraria.ModLoader;

namespace TJTTMN.Content.Buffs
{
    public class NaturesRegeneration : ModBuff
    {
        public override void Update(Player player, ref int buffIndex)
        {
            player.lifeRegen += 5;
        }
    }
}
