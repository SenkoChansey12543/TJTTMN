using System;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria;
using TJTTMN.Content.Buffs.WhipBuffs;
using TJTTMN.Content.Projectiles.Whips;
using TJTTMN.Content.Items.Materials;

namespace TJTTMN.Content.Items.Weapons.Summoner
{
    public class ArmotiteChain : ModItem
    {
        public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(ArmotiteChainBuff.TagDamage);

        public override void SetDefaults()
        {
            Item.DefaultToWhip(ModContent.ProjectileType<ArmotiteChainProjectile>(), 32, 8, 4, 70);
            Item.rare = ItemRarityID.Green;
        }

        public override bool MeleePrefix()
        {
            return true;
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
