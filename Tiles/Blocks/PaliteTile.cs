using Terraria.Localization;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TJTTMN.Content.Tiles.Blocks
{
    public class PaliteTile : ModTile
    {
        public override void SetStaticDefaults()
        {
            TileID.Sets.Ore[Type] = true;
            Main.tileSpelunker[Type] = true;
            Main.tileOreFinderPriority[Type] = 420;
            Main.tileShine2[Type] = true;
            Main.tileShine[Type] = 975;
            Main.tileSolid[Type] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileMerge[Type][TileID.Ash] = true;
            Main.tileMerge[TileID.Ash][Type] = true;
            LocalizedText name = CreateMapEntryName();
            AddMapEntry(new Color(168, 12, 240), name);
            DustType = DustID.Ice_Purple;
            HitSound = SoundID.Dig;
            MineResist = 1f;
            MinPick = 100;
        }
    }
}
