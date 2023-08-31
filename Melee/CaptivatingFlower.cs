using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using TJTTMN.Content.Buffs;
using TJTTMN.Content.Projectiles;

namespace TJTTMN.Content.Items.Weapons.Melee
{
    public class CaptivatingFlower : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            //Hitbox
            Item.width = 44;
            Item.height = 44;

            //Value and stack
            Item.maxStack = 1;
            Item.value = Item.sellPrice(silver: 13, copper: 14);
            Item.rare = ItemRarityID.White;

            //Use
            Item.useTime = 60;
            Item.useAnimation = 60;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTurn = false;
            Item.autoReuse = false;
            Item.noMelee = false;
            Item.UseSound = SoundID.Item1;

            //Other
            Item.damage = 12;
            Item.DamageType = DamageClass.Melee;
            Item.knockBack = 4f;
            Item.crit = 4;
        }

        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(ModContent.BuffType<FloralCaptivation>(), 360);
        }

        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            //Dust
            if (Main.rand.NextBool(10))
            {
                int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.Grass);
                Main.dust[dust].noGravity = true;
            }
        }
    }
}
