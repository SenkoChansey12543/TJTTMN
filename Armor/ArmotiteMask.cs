using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using TJTTMN.Content.Items.Materials;

namespace TJTTMN.Content.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class ArmotiteMask : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.defense = 9;
            Item.value = Item.buyPrice(silver: 97);
            Item.rare = ItemRarityID.Green;
        }
        public override void UpdateEquip(Player player)
        {
            player.endurance += 0.3f;
        }
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<ArmotiteBreastplate>() && legs.type == ModContent.ItemType<ArmotiteArmoredPants>();
        }
        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "2 defense and +3% damage reduction";
            player.statDefense += 2;
            player.endurance += 0.03f;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<ArmotiteBar>(8)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}
