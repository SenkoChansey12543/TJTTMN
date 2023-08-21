using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using TJTTMN.Content.Buffs;
using TJTTMN.Content.Projectiles;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TJTTMN.Content.Items.Materials;

namespace TJTTMN.Content.Items.Weapons.Other
{
    public class HeavyWarriorShield : ModItem
    {
        public override void SetStaticDefaults()
        {

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {
            //Hitbox
            Item.width = 10;
            Item.height = 10;

            //Value and stack
            Item.maxStack = 1;
            Item.value = Item.sellPrice(gold: 1, silver: 78);
            Item.rare = ItemRarityID.Green;

            //Use
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.useTime = 1;
            Item.useAnimation = 1;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.noMelee = false;

            //Other
            Item.damage = 0;
            Item.DamageType = DamageClass.Melee;
            Item.buffType = ModContent.BuffType<HeavyWarriorDefense>();
            Item.buffTime = 2;
        }
        public override void AddRecipes()
        {
            //Recipe
            CreateRecipe()
                .AddIngredient<ArmotiteBar>(12)
                .AddRecipeGroup(RecipeGroupID.IronBar, 3)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}
