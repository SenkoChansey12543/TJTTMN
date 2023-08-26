using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace TJTTMN.Content.Items.Materials
{
    public class ArmotiteChunk : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 50;
        }
        public override void SetDefaults()
        {
            Item.width = 11;
            Item.height = 11;
            Item.rare = ItemRarityID.Green;
            Item.maxStack = 9999;
            Item.value = 755;
        }
    }
}
