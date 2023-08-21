using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using TJTTMN.Content.Projectiles;
using TJTTMN.Content.Items.Materials;
using Terraria.DataStructures;

namespace TJTTMN.Content.Items.Weapons.Melee
{
    public class ArmotiteHeavyBlade : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {
            //Hitbox
            Item.width = 70;
            Item.height = 70;

            //Value and stack
            Item.maxStack = 1;
            Item.value = Item.sellPrice(gold: 1, silver: 62);
            Item.rare = ItemRarityID.Green;

            //Use
            Item.useTime = 45;
            Item.useAnimation = 45;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.noMelee = false;
            Item.UseSound = SoundID.Item1;

            //Other
            Item.damage = 41;
            Item.DamageType = DamageClass.Melee;
            Item.shoot = ModContent.ProjectileType<ArmotiteShard>();
            Item.shootSpeed = 9;
            Item.knockBack = 6f;
            Item.crit = 6;
        }
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            //Dust
            if (Main.rand.NextBool(4))
            {
                int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.Titanium);
                Main.dust[dust].noGravity = true;
            }
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            //Shoot
            Vector2 newVelocity = velocity.RotatedBy(MathHelper.ToRadians(-2));
            Projectile.NewProjectileDirect(source, position, newVelocity, type, damage, knockback, player.whoAmI);
            Vector2 new1Velocity = velocity.RotatedBy(MathHelper.ToRadians(2));
            Projectile.NewProjectileDirect(source, position, new1Velocity, type, damage, knockback, player.whoAmI);
            return false;
        }
        public override void AddRecipes()
        {
            //Recipe
            CreateRecipe()
                .AddIngredient<ArmotiteBar>(12)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}
