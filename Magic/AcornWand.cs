using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using TJTTMN.Content.Projectiles;
using Microsoft.Xna.Framework;

namespace TJTTMN.Content.Items.Weapons.Magic
{
    public class AcornWand : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {
            Item.damage = 15;
            Item.mana = 4;
            Item.DamageType = DamageClass.Magic;
            Item.knockBack = 2;
            Item.shootSpeed = 9;
            Item.noMelee = true;
            Item.shoot = ModContent.ProjectileType<AcornShoot>();
            Item.rare = ItemRarityID.White;
            Item.useTime = 35;
            Item.useAnimation = 35;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.width = 25;
            Item.height = 25;
            Item.autoReuse = true;
            Item.value = Item.buyPrice(silver: 11);
            Item.UseSound = SoundID.Item8;
        }

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            Vector2 muzzleOffset = Vector2.Normalize(velocity) * 30f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }
        }
    }
}
