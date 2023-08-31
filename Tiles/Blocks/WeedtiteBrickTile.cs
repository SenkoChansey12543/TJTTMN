using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using TJTTMN.Content.Items.Placeables;

namespace TJTTMN.Content.Tiles.Blocks
{
    public class WeedtiteBrickTile : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSpelunker[Type] = false;
            Main.tileMergeDirt[Type] = true;
            Main.tileShine2[Type] = false;
            Main.tileShine[Type] = 975;
            Main.tileSolid[Type] = true;
            Main.tileBlockLight[Type] = true;
            LocalizedText name = CreateMapEntryName();
            AddMapEntry(new Color(32, 214, 60));
            DustType = DustID.Grass;
            HitSound = SoundID.Tink;
            MineResist = 1f;
            MinPick = 1;
        }
    }
}
