using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using TJTTMN.Content.Items.Materials;

namespace TJTTMN.Content.Items.Accesories
{
    [AutoloadEquip(EquipType.Neck)]
    public class SturdyMedallion : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 26;
            Item.value = Item.sellPrice(silver: 74);
            Item.rare = ItemRarityID.Green;
            Item.accessory = true;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.endurance += 0.07f;
            player.GetAttackSpeed(DamageClass.Generic) -= 0.03f;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.Chain, 2)
                .AddIngredient<ArmotiteBar>(8)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}
