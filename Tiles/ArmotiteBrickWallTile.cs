using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TJTTMN.Content.Tiles
{
    public class ArmotiteBrickWallTile : ModWall
    {
        public override void SetStaticDefaults()
        {
            Main.wallHouse[Type] = true;
            Main.tileShine2[Type] = true;
            Main.tileShine[Type] = 975;
            DustType = DustID.Stone;
            AddMapEntry(new Color(65, 74, 70));
        }

        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }
    }
}