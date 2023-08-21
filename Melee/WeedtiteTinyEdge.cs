using System;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using TJTTMN.Content.Items.Materials;
using TJTTMN.Content.Tiles;
using TJTTMN.Content.Projectiles;

namespace TJTTMN.Content.Items.Weapons.Melee
{
    public class WeedtiteTinyEdge : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            //Hitbox
            Item.width = 30;
            Item.height = 30;

            //Value and stack
            Item.maxStack = 1;
            Item.value = Item.sellPrice(silver: 35);
            Item.rare = ItemRarityID.Blue;

            //Use
            Item.useTime = 5;
            Item.useAnimation = 5;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTurn = false;
            Item.autoReuse = true;
            Item.noMelee = false;
            Item.UseSound = SoundID.Item1;

            //Other
            Item.damage = 2;
            Item.DamageType = DamageClass.Melee;
            Item.knockBack = 1f;
            Item.crit = 4;

            //Dispara un proyectil invisible en la posicion del jugador para simular mayor rango de la espada. Ver "WeedtiteTinyEdgeExtraRange" para mas
            Item.shoot = ModContent.ProjectileType<WeedtiteTinyEdgeExtraRange>();
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

        public override void AddRecipes()
        {
            //Iron recipe
            CreateRecipe()
                .AddIngredient<Weedtite>(16)
                .AddIngredient(ItemID.IronBar, 4)
                .AddIngredient(ItemID.Wood, 12)
                .AddTile<HerbalAnvilTile>()
                .Register();

            //Lead recipe
            CreateRecipe()
                .AddIngredient<Weedtite>(16)
                .AddIngredient(ItemID.LeadBar, 4)
                .AddIngredient(ItemID.Wood, 12)
                .AddTile<HerbalAnvilTile>()
                .Register();
        }
    }
}
