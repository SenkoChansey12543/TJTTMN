using System;
using Terraria.ModLoader;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using TJTTMN.Content.Buffs;
using TJTTMN.Content.Projectiles.Minions;
using Microsoft.Xna.Framework;
using TJTTMN.Content.Items.Materials;
using TJTTMN.Content.Tiles;

namespace TJTTMN.Content.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class PaliteHood : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            ArmorIDs.Head.Sets.DrawHead[Item.headSlot] = false;
        }
        int paliteArmorSet = 0;
        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.defense = 4;
            Item.value = Item.buyPrice(gold: 1, silver: 12);
            Item.rare = ItemRarityID.Orange;
        }
        public override void UpdateEquip(Player player)
        {
            player.maxMinions += 1;
            player.GetDamage(damageClass: DamageClass.Summon) += 0.07f;
        }
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<PaliteRobe>() && legs.type == ModContent.ItemType<PaliteBoots>();
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Increases summon damage by 5%" +
                "\nSummons a flying chomper minion to protect you" +
                "\nThe flying chomper minion doesn't use minion slots!";
            player.GetDamage(damageClass: DamageClass.Summon) += 0.05f;
            player.AddBuff(ModContent.BuffType<FlyingChomperBuff>(), 1);

            Vector2 spawnPos;
            spawnPos.X = player.Center.X;
            spawnPos.Y = player.Center.Y;

            if(player.ownedProjectileCounts[ModContent.ProjectileType<FlyingChomperMinion>()] == 0)
            {
                if (Main.myPlayer == player.whoAmI)
                {
                    Projectile.NewProjectile(player.GetSource_FromThis("SetBonus_PaliteSet"), spawnPos, Vector2.Zero, ModContent.ProjectileType<FlyingChomperMinion>(), 10, 0.1f, Main.myPlayer);

                }
            }
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<PaliteFlower>(12)
                .AddIngredient<MysticalGel>(3)
                .AddIngredient(ItemID.HellstoneBar, 4)
                .AddTile<MysticalAnvilTile>()
                .Register();
        }
    }
}
