using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using TJTTMN.Content.Buffs;
using TJTTMN.Content.Items.Materials;
using TJTTMN.Content.Projectiles.Minions;
using TJTTMN.Content.Tiles;

namespace TJTTMN.Content.Items.Weapons.Summoner
{
    public class PlantiteSpiritRod : ModItem
    {
        public override void SetStaticDefaults()
        {
            ItemID.Sets.GamepadWholeScreenUseRange[Item.type] = true;
            ItemID.Sets.LockOnIgnoresCollision[Item.type] = true;
            ItemID.Sets.StaffMinionSlotsRequired[Item.type] = 1f;
        }

        public override void SetDefaults()
        {
            //For generic weapons
            Item.damage = 9;
            Item.knockBack = 3f;
            Item.mana = 11;
            Item.width = 44;
            Item.height = 44;
            Item.useTime = 50;
            Item.useAnimation = 50;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.value = Item.sellPrice(silver: 50);
            Item.rare = ItemRarityID.Blue;
            Item.UseSound = SoundID.Item77;

            //For minion weapons
            Item.noMelee = true;
            Item.DamageType = DamageClass.Summon;
            Item.buffType = ModContent.BuffType<PlantiteSpiritBuff>();
            Item.shoot = ModContent.ProjectileType<PlantiteSpiritMinion>();

        }

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            //This function makes the minion spawning at the position of the cursor
            position = Main.MouseWorld;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            player.AddBuff(Item.buffType, 2);

            var projectile = Projectile.NewProjectileDirect(source, position, velocity, type, damage, knockback, Main.myPlayer);
            projectile.originalDamage = Item.damage;

            return false;
        }

        public override void AddRecipes()
        {
            //Recipe for gold bars
            CreateRecipe()
                .AddIngredient<Plantite>(12)
                .AddIngredient(ItemID.GoldBar, 8)
                .AddIngredient<VineGel>(4)
                .AddTile<HerbalAnvilTile>()
                .Register();

            //Recipe for platinum bars
            CreateRecipe()
                .AddIngredient<Plantite>(12)
                .AddIngredient(ItemID.PlatinumBar, 8)
                .AddIngredient<VineGel>(4)
                .AddTile<HerbalAnvilTile>()
                .Register();
        }
    }
}
