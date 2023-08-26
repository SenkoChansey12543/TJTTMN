using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using TJTTMN.Content.Buffs;
using TJTTMN.Content.Projectiles.Minions;
using TJTTMN.Content.Projectiles.Sentries;
using Terraria.DataStructures;
using TJTTMN.Content.Items.Materials;
using TJTTMN.Content.Tiles;

namespace TJTTMN.Content.Items.Weapons.Summoner
{
    public class WeedtiteTurretSetter : ModItem
    {
        public override void SetStaticDefaults()
        {
            ItemID.Sets.GamepadWholeScreenUseRange[Item.type] = true;
            ItemID.Sets.LockOnIgnoresCollision[Item.type] = true;
        }

        public override void SetDefaults()
        {

            //For generic weapons
            Item.damage = 1;
            Item.knockBack = 1f;
            Item.mana = 12;
            Item.width = 44;
            Item.height = 44;
            Item.useTime = 50;
            Item.useAnimation = 50;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.value = Item.buyPrice(silver: 26, copper: 61);
            Item.rare = ItemRarityID.Blue;
            Item.UseSound = SoundID.DD2_DefenseTowerSpawn;

            //For sentries
            Item.noMelee = true;
            Item.DamageType = DamageClass.Summon;
            Item.shoot = ModContent.ProjectileType<WeedtiteTurretSentry>();

        }
        public override bool CanUseItem(Player player)
        {
            player.FindSentryRestingSpot(Item.shoot, out int worldX, out int worldY, out _);
            worldX /= 16;
            worldY /= 16;
            worldY -= 3;
            return !WorldGen.SolidTile(worldX, worldY);
        }


        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            player.FindSentryRestingSpot(type, out int worldX, out int worldY, out int pushYUp);
            worldY -= 16;
            Vector2 spawnPos;
            spawnPos.X = worldX;
            spawnPos.Y = worldY;
            spawnPos.Y -= pushYUp;
            Projectile.NewProjectile(source, spawnPos, velocity, ModContent.ProjectileType<WeedtiteTurretSentry>(), 1, 0.01f, Main.myPlayer);
            player.UpdateMaxTurrets(); //Actualiza la cantidad de torretas del jugador
            int dust = Dust.NewDust(position, 44, 44, DustID.Grass);
            Main.dust[dust].noGravity = true;
            return false;
        }

        public override void AddRecipes()
        {
            //Iron recipe
            CreateRecipe()
                .AddIngredient<Weedtite>(16)
                .AddIngredient<VineGel>(6)
                .AddIngredient(ItemID.IronBar, 8)
                .AddTile<HerbalAnvilTile>()
                .Register();

            //Lead recipe
            CreateRecipe()
                .AddIngredient<Weedtite>(16)
                .AddIngredient<VineGel>(6)
                .AddIngredient(ItemID.LeadBar, 8)
                .AddTile<HerbalAnvilTile>()
                .Register();
        }
    }
}
