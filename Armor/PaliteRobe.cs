using System;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using TJTTMN.Content.Items.Materials;
using TJTTMN.Content.Tiles;

namespace TJTTMN.Content.Items.Armor
{
    [AutoloadEquip(EquipType.Body)]
    public class PaliteRobe : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            ArmorIDs.Body.Sets.HidesHands[Item.bodySlot] = true;
        }
        public override void Load()
        {
            if (Main.netMode == NetmodeID.Server)
            {
                return;
            }
            EquipLoader.AddEquipTexture(Mod, $"{Texture}_{EquipType.Legs}", EquipType.Legs, this);
        }

        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.defense = 6;
            Item.value = Item.buyPrice(gold: 1, silver: 38);
            Item.rare = ItemRarityID.Orange;
        }
        public override void UpdateEquip(Player player)
        {
            player.whipRangeMultiplier += 0.20f; //1f = +100% de alcance de latigo
            player.GetDamage(damageClass: DamageClass.Summon) += 0.05f;
            player.maxTurrets += 1;
        }
        public override void SetMatch(bool male, ref int equipSlot, ref bool robes)
        {
            robes = true;
            equipSlot = EquipLoader.GetEquipSlot(Mod, Name, EquipType.Legs);
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<PaliteFlower>(20)
                .AddIngredient<MysticalGel>(5)
                .AddIngredient(ItemID.HellstoneBar, 8)
                .AddTile<MysticalAnvilTile>()
                .Register();
        }
    }
}
