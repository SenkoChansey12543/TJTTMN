using Terraria;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Terraria.ID;
using TJTTMN.Content.Tiles;

namespace TJTTMN.Content.Items.Materials
{
    public class WeedtiteSprout : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 50;
        }
        public override void SetDefaults()
        {
            Item.width = 10;
            Item.height = 10;
            Item.rare = ItemRarityID.White;
            Item.value = Item.sellPrice(copper : 70);
            Item.maxStack = 9999;
            Item.createTile = ModContent.TileType<WeedtiteTile>();
        }
    }
}
