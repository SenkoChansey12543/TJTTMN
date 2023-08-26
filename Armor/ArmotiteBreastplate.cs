using TJTTMN.Content.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace TJTTMN.Content.Items.Armor
{
    [AutoloadEquip(EquipType.Body)]
    public class ArmotiteBreastplate : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.defense = 11;
            Item.value = Item.buyPrice(gold: 1, silver: 19);
            Item.rare = ItemRarityID.Green;
        }
        public override void UpdateEquip(Player player)
        {
            player.endurance += 0.04f;
            player.GetAttackSpeed(DamageClass.Generic) -= 0.08f;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<ArmotiteBar>(16)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}
