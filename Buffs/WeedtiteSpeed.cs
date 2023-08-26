using Terraria;
using Terraria.ModLoader;

namespace TJTTMN.Content.Buffs
{
    public class WeedtiteSpeed : ModBuff
    {
        public override void Update(Player player, ref int buffIndex)
        {
            player.GetAttackSpeed(DamageClass.Generic) += 0.05f;
        }
    }
}
