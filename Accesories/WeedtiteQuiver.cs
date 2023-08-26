using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using TJTTMN.Content.Items.Materials;
using TJTTMN.Content.Tiles;

namespace TJTTMN.Content.Items.Accesories
{
    [AutoloadEquip(EquipType.Back)]
    public class WeedtiteQuiver : ModItem        
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 28;
            Item.value = Item.buyPrice(silver: 34);
            Item.rare = ItemRarityID.Blue;
            Item.accessory = true;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetDamage(DamageClass.Ranged) += 0.05f;
            player.GetAttackSpeed(DamageClass.Ranged) += 0.05f;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.GrassSeeds, 20)
                .AddIngredient(ItemID.Silk, 5)
                .AddIngredient<VineGel>(8)
                .AddIngredient<Weedtite>(8)
                .AddTile<HerbalAnvilTile>()
                .Register();
        }
    }
}
