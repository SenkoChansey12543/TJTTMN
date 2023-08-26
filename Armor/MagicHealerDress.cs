﻿using TJTTMN.Content.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using TJTTMN.Content.Tiles;

namespace TJTTMN.Content.Items.Armor
{
    [AutoloadEquip(EquipType.Body)]
    public class MagicHealerDress : ModItem
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
            Item.value = Item.buyPrice(gold: 1, silver: 5);
            Item.rare = ItemRarityID.Green;
        }
        public override void UpdateEquip(Player player)
        {
            player.GetAttackSpeed(DamageClass.Magic) += 0.05f;
            player.GetDamage(DamageClass.Magic) += 0.04f;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<Plantite>(16)
                .AddIngredient<VineGel>(3)
                .AddIngredient(ItemID.Mushroom, 3)
                .AddTile<HerbalAnvilTile>()
                .Register();
        }
    }
}
