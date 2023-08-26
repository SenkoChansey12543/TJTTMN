using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using TJTTMN.Content.Items.Materials;
using TJTTMN.Content.Tiles;

namespace TJTTMN.Content.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class WeedtiteArcherHood : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.defense = 4;
            Item.value = Item.buyPrice(silver: 33);
            Item.rare = ItemRarityID.Blue;
        }
        public override void UpdateEquip(Player player)
        {
            player.GetCritChance(damageClass: DamageClass.Ranged) += 4;
            player.GetDamage(damageClass: DamageClass.Ranged) += 0.03f;
          
        }
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<WeedtiteBreastplate>() && legs.type == ModContent.ItemType<WeedtiteLeggins>();
        }
        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Increased ranged attack speed by 10%";                       
            player.GetAttackSpeed(DamageClass.Ranged) += 0.10f;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.GrassSeeds, 20)
                .AddIngredient<Weedtite>(8)
                .AddIngredient<VineGel>(8)
                .AddTile<HerbalAnvilTile>()
                .Register();
        }
    }
}
