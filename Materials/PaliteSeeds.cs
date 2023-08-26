using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using static Terraria.ID.ContentSamples.CreativeHelper;
using TJTTMN.Content.Tiles;

namespace TJTTMN.Content.Items.Materials
{
    public class PaliteSeeds : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 50;
        }
        public override void SetDefaults()
        {
            Item.width = 12;
            Item.height = 12;
            Item.rare = ItemRarityID.Orange;
            Item.maxStack = 9999;
            Item.value = Item.buyPrice(silver: 1, copper: 4);
            Item.createTile = ModContent.TileType<PaliteTile>();
        }
    }
}
