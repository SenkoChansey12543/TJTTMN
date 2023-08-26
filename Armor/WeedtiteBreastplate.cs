using TJTTMN.Content.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using TJTTMN.Content.Tiles;

namespace TJTTMN.Content.Items.Armor
{
    [AutoloadEquip(EquipType.Body)]
    public class WeedtiteBreastplate : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.defense = 5;
            Item.value = Item.buyPrice(silver: 46);
            Item.rare = ItemRarityID.Blue;
        }
        public override void UpdateEquip(Player player)
        {
            player.GetCritChance(damageClass: DamageClass.Ranged) += 3;
            player.GetDamage(damageClass: DamageClass.Ranged) += 0.05f;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.GrassSeeds, 30)
                .AddIngredient<Weedtite>(12)
                .AddIngredient<VineGel>(16)
                .AddTile<HerbalAnvilTile>()
                .Register();
        }
    }
}
