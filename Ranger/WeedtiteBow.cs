using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using TJTTMN.Content.Items.Materials;
using TJTTMN.Content.Tiles;

namespace TJTTMN.Content.Items.Weapons.Ranger
{
    public class WeedtiteBow : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 36;
            Item.damage = 16;
            Item.DamageType = DamageClass.Ranged;
            Item.knockBack = 1.5f;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.autoReuse = true;
            Item.noMelee = true;
            Item.rare = ItemRarityID.Blue;
            Item.shoot = 1;
            Item.shootSpeed = 60f;
            Item.useAmmo = AmmoID.Arrow;
            Item.UseSound = SoundID.Item5;
            Item.value = Item.sellPrice(silver: 15);
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.GrassSeeds, 25)
                .AddIngredient<Weedtite>(8)
                .AddIngredient<VineGel>(12)
                .AddTile<HerbalAnvilTile>()
                .Register();
        }
    }
}
