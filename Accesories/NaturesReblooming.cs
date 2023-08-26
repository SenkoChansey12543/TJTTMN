using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using TJTTMN.Content.Items.Materials;

namespace TJTTMN.Content.Items.Accesories
{
    [AutoloadEquip(EquipType.Face)]
    public class NaturesReblooming : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 24;
            Item.value = Item.buyPrice(silver: 67);
            Item.rare = ItemRarityID.Green;
            Item.accessory = true;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetDamage(DamageClass.Magic) += 0.08f;
            player.manaCost -= 0.06f;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.NaturesGift)
                .AddIngredient<Plantite>(6)
                .AddTile(TileID.TinkerersWorkbench)
                .Register();
        }
    }  
}
