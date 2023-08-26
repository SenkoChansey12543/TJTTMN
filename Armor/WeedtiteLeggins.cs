using TJTTMN.Content.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using TJTTMN.Content.Tiles;

namespace TJTTMN.Content.Items.Armor

{
    [AutoloadEquip(EquipType.Legs)]
    public class WeedtiteLeggins : ModItem
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
            Item.rare = ItemRarityID.Blue;
            Item.value = Item.buyPrice(silver: 39);
        }
        public override void UpdateEquip(Player player)
        {
            player.GetCritChance(damageClass: DamageClass.Ranged) += 3;
            player.moveSpeed += 0.07f;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.GrassSeeds, 25)
                .AddIngredient<Weedtite>(10)
                .AddIngredient<VineGel>(12)
                .AddTile<HerbalAnvilTile>()
                .Register();
        }
    }
}
