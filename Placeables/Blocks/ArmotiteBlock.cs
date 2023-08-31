﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using TJTTMN.Content.Items.Materials;
using TJTTMN.Content.Tiles.Blocks;

namespace TJTTMN.Content.Items.Placeables.Blocks
{
    public class ArmotiteBlock : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;
        }
        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTurn = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.autoReuse = true;
            Item.maxStack = 9999;
            Item.consumable = true;
            Item.createTile = ModContent.TileType<ArmotiteBlockTile>();
            Item.width = 12;
            Item.height = 12;
            Item.value = 0;
            Item.rare = ItemRarityID.White;
        }
        public override void AddRecipes()
        {
            CreateRecipe(5)
                .AddIngredient<ArmotiteChunk>(3)
                .AddTile(TileID.HeavyWorkBench)
                .Register();
        }
    }
}
