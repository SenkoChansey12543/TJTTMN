using Terraria.Localization;
using TJTTMN.Content.Items.Ores;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.ItemDropRules;
using static Terraria.ID.ContentSamples.CreativeHelper;
using TJTTMN.Content.Items.Materials;
using System;
using Terraria.GameContent;
using System.Runtime.CompilerServices;

namespace TJTTMN.Content.Tiles
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
            LocalizedText name = CreateMapEntryName();
            AddMapEntry(new Color(168, 12, 240), name);
            DustType = DustID.Ice_Purple;
            HitSound = SoundID.Dig;
            MineResist = 1f;
            MinPick = 100;
        }
    }
}
