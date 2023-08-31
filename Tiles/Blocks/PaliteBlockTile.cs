using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace TJTTMN.Content.Tiles.Blocks
{
    public class PaliteBlockTile : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSpelunker[Type] = false;
            Main.tileMergeDirt[Type] = true;
            Main.tileShine[Type] = 975;
            Main.tileSolid[Type] = true;
            Main.tileBlockLight[Type] = true;
            LocalizedText name = CreateMapEntryName();
            AddMapEntry(new Color(194, 54, 245), name);
            DustType = DustID.Ice_Purple;
            HitSound = SoundID.Dig;
            MineResist = 1f;
            MinPick = 1;
        }
    }
}
