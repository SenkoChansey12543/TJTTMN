using Terraria.Localization;
using TJTTMN.Content.Items.Placeables;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TJTTMN.Content.Tiles.Blocks
{
    public class ArmotiteBlockTile : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSpelunker[Type] = false;
            Main.tileMergeDirt[Type] = true;
            Main.tileSolid[Type] = true;
            Main.tileBlockLight[Type] = true;
            LocalizedText name = CreateMapEntryName();
            // name.SetDefault("Armotite block");
            AddMapEntry(new Color(133, 138, 132), name);
            DustType = DustID.Stone;
            HitSound = SoundID.Tink;
            MineResist = 1f;
            MinPick = 1;
        }
    }
}
