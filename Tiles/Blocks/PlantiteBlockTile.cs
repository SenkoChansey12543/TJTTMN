using Terraria.Localization;
using TJTTMN.Content.Items.Placeables;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TJTTMN.Content.Tiles.Blocks
{
    public class PlantiteBlockTile : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSpelunker[Type] = false;
            Main.tileMergeDirt[Type] = true;
            Main.tileSolid[Type] = true;
            Main.tileBlockLight[Type] = true;
            LocalizedText name = CreateMapEntryName();
            AddMapEntry(new Color(10, 225, 0), name);
            DustType = 2;
            HitSound = SoundID.Dig;
            MineResist = 1f;
            MinPick = 1;
        }
    }
}
