using TJTTMN.Content.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace TJTTMN.Content.Items.Armor

{
    [AutoloadEquip(EquipType.Legs)]
    public class ArmotiteArmoredPants : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {
            Item.defense = 10;
            Item.width = 18;
            Item.height = 18;
            Item.rare = ItemRarityID.Green;
            Item.value = Item.buyPrice(gold : 1, silver: 1);
        }
        public override void UpdateEquip(Player player)
        {
            player.endurance += 0.03f;
            player.moveSpeed -= 0.12f;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<ArmotiteBar>(12)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}
