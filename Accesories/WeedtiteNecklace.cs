using Terraria;
using Terraria.Audio;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using TJTTMN.Content.Items.Materials;
using TJTTMN.Content.Items.Placeables;
using TJTTMN.Content.Tiles;
using TJTTMN.Content.Buffs;

namespace TJTTMN.Content.Items.Accesories
{
    [AutoloadEquip(EquipType.Neck)]

    public class WeedtiteNecklace : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 24;
            Item.value = Item.buyPrice(silver: 23);
            Item.rare = ItemRarityID.White;
            Item.accessory = true;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetAttackSpeed(DamageClass.Generic) += 0.05f;
            player.GetCritChance(DamageClass.Generic) += 1;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<Weedtite>(6)
                .AddIngredient<VineGel>(2)
                .AddTile<HerbalAnvilTile>()
                .Register();              
        }
    }

}
