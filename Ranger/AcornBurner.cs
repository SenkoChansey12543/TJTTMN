using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using TJTTMN.Content.Items.Ammo;
using TJTTMN.Content.Items.Materials;

namespace TJTTMN.Content.Items.Weapons.Ranger
{
    public class AcornBurner : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.damage = 14;
            Item.width = 16;
            Item.height = 16;
            Item.value = Item.buyPrice(silver: 14, copper: 65);
            Item.useTime = 40;
            Item.useAnimation = 40;
            Item.knockBack = 2f;
            Item.autoReuse = true;
            Item.DamageType = DamageClass.Ranged;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.shoot = ProjectileID.BallofFire;
            Item.useAmmo = ModContent.ItemType<GelAcorn>();
            Item.noMelee = true;
            Item.rare = ItemRarityID.White;
            Item.shootSpeed = 6.5f;
        }

        public override bool CanConsumeAmmo(Item ammo, Player player)
        {
            return Main.rand.NextFloat() >= .30f;
        }

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            Vector2 muzzleOffset = Vector2.Normalize(velocity) * 40f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(5f, 0f);
        }
    }
}
