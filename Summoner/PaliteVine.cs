using System;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria;
using TJTTMN.Content.Buffs.WhipBuffs;
using TJTTMN.Content.Projectiles.Whips;
using TJTTMN.Content.Items.Materials;
using TJTTMN.Content.Tiles;

namespace TJTTMN.Content.Items.Weapons.Summoner
{
    public class PaliteVine : ModItem
    {
        public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(PaliteVineBuff.TagDamage);

        public override void SetDefaults()
        {
            Item.DefaultToWhip(ModContent.ProjectileType<PaliteVineProjectile>(), 22, 2, 4, 30);
            Item.rare = ItemRarityID.Orange;
        }

        public override bool MeleePrefix()
        {
            return true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<PaliteFlower>(16)
                .AddIngredient<MysticalGel>(5)
                .AddIngredient(ItemID.HellstoneBar, 6)
                .AddTile<MysticalAnvilTile>()
                .Register();
        }
    }
}
