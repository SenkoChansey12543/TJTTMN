using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ID;
using TJTTMN.Content.Items.Ores;
using Microsoft.Xna.Framework;
using TJTTMN.Content.Items.Materials;

namespace TJTTMN.Content.Tiles.Blocks
{
    public class WeedtiteTile : ModTile
    {
        public override void SetStaticDefaults()
        {
            TileID.Sets.Ore[Type] = true;
            Main.tileSpelunker[Type] = true;
            Main.tileOreFinderPriority[Type] = 10;
            Main.tileMergeDirt[Type] = true;
            Main.tileSolid[Type] = true;
            Main.tileBlockLight[Type] = true;
            LocalizedText name = CreateMapEntryName();
            AddMapEntry(new Color(57, 201, 0), name);
            DustType = DustID.Grass;
            HitSound = SoundID.Dig;
            MineResist = 1f;
            MinPick = 1;
        }
    }
}
