using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using TJTTMN.Content.Items.Materials;
using TJTTMN.Content.Tiles;

namespace TJTTMN.Content.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class MagicHealerHeaddress : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            ArmorIDs.Head.Sets.DrawHatHair[Item.headSlot] = true;
        }
        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.defense = 3;
            Item.rare = ItemRarityID.Green;
            Item.value = Item.buyPrice(silver: 91);
        }
        public override void UpdateEquip(Player player)
        {
            player.GetCritChance(damageClass: DamageClass.Magic) += 3;
            player.manaCost -= 0.04f;
            player.lifeRegen += 1; 
        }
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<MagicHealerDress>() && legs.type == ModContent.ItemType<MagicHealerPants>();
        }
        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Increased max life by 50";
            player.statLifeMax2 += 50;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<Plantite>(8)
                .AddIngredient(ItemID.Mushroom, 1)
                .AddTile<HerbalAnvilTile>()
                .Register();
        }
    }
}
