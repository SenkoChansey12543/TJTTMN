using Terraria.Localization;
using TJTTMN.Content.Items.Ores;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TJTTMN.Content.Tiles
{
    public class ArmoplantiteTile : ModTile
    {
        public override void SetStaticDefaults()
        {
            TileID.Sets.Ore[Type] = true;
            Main.tileSpelunker[Type] = true;
            Main.tileOreFinderPriority[Type] = 410; 
            Main.tileShine2[Type] = true;
            Main.tileShine[Type] = 975; 
            Main.tileMergeDirt[Type] = true;
            Main.tileSolid[Type] = true;
            Main.tileBlockLight[Type] = true;
            LocalizedText name = CreateMapEntryName();
            AddMapEntry(new Color(184, 202, 175), name);
            DustType = 188;
            HitSound = SoundID.Tink;
            MineResist = 7f;
            MinPick = 64;
        }        
    }
}
