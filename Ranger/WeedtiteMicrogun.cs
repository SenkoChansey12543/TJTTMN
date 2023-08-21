using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.Audio;
using TJTTMN.Content.Items.Materials;
using TJTTMN.Content.Tiles;

namespace TJTTMN.Content.Items.Weapons.Ranger
{
    public class WeedtiteMicrogun : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 24;
            Item.damage = 4;
            Item.useTime = 14;
            Item.useAnimation = 14;
            Item.knockBack = 0.5f;
            Item.autoReuse = false;
            Item.DamageType = DamageClass.Ranged;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noMelee = true;
            Item.rare = ItemRarityID.White;
            Item.useAmmo = AmmoID.Bullet;
            Item.shoot = ProjectileID.Bullet;
            Item.shootSpeed = 6f;
            Item.value = Item.sellPrice(silver: 11);
            Item.UseSound = new SoundStyle($"{nameof(TJTTMN)}/Content/Sounds/GrassRock")
            {
                Volume = 1f,
            };
        }
        public override bool CanConsumeAmmo(Item ammo, Player player)
        {
            return Main.rand.NextFloat() >= .20f;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<Weedtite>(12)
                .AddIngredient<VineGel>(5)
                .AddRecipeGroup(RecipeGroupID.IronBar, 3)
                .AddTile<HerbalAnvilTile>()
                .Register();
        }
    }
}
