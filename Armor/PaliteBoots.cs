using System;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using TJTTMN.Content.Items.Materials;
using TJTTMN.Content.Tiles;

namespace TJTTMN.Content.Items.Armor
{
    [AutoloadEquip(EquipType.Legs)]
    public class PaliteBoots : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.defense = 4;
            Item.value = Item.buyPrice(gold: 1, silver: 25);
            Item.rare = ItemRarityID.Orange;
        }
        public override void UpdateEquip(Player player)
        {
            player.maxMinions += 1;
            player.GetDamage(damageClass: DamageClass.Summon) += 0.08f;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<PaliteFlower>(16)
                .AddIngredient<MysticalGel>(4)
                .AddIngredient(ItemID.HellstoneBar, 6)
                .AddTile<MysticalAnvilTile>()
                .Register();
        }
    }
}
