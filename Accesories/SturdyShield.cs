﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace TJTTMN.Content.Items.Accesories
{
    [AutoloadEquip(EquipType.Shield)]
    public class SturdyShield : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 26;
            Item.defense = 2;
            Item.value = Item.buyPrice(gold: 1, silver: 41);
            Item.rare = ItemRarityID.Green;
            Item.accessory = true;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.endurance += 0.07f;
            player.GetAttackSpeed(DamageClass.Generic) -= 0.03f;
            player.noKnockback = true;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.CobaltShield)
                .AddIngredient<SturdyMedallion>(1)
                .AddTile(TileID.TinkerersWorkbench)
                .Register();
        }
    }
}
