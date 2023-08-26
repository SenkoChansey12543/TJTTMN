using TJTTMN.Content.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using TJTTMN.Content.Tiles;

namespace TJTTMN.Content.Items.Armor

{
    [AutoloadEquip(EquipType.Legs)]
    public class MagicHealerPants : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {
            Item.defense = 4;
            Item.width = 18;
            Item.height = 18;
            Item.rare = ItemRarityID.Green;
            Item.value = Item.buyPrice(silver: 99);
        }
        public override void UpdateEquip(Player player)
        {
            player.lifeRegen += 2;
            player.GetAttackSpeed(DamageClass.Magic) += 0.03f;
            player.moveSpeed += 0.04f;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<Plantite>(12)
                .AddIngredient<VineGel>(1)
                .AddIngredient(ItemID.Mushroom, 2)
                .AddTile<HerbalAnvilTile>()
                .Register();
        }
    }
}
