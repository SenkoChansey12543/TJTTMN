using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using TJTTMN.Content.Projectiles;

namespace TJTTMN.Content.Items.Weapons.Magic
{
    public class AcornWand : ModItem
    {
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("It's better than nothing");
            // DisplayName.SetDefault("Acorn wand");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {
            Item.damage = 9;
            Item.mana = 3;
            Item.DamageType = DamageClass.Magic;
            Item.knockBack = 2;
            Item.shootSpeed = 9;
            Item.noMelee = true;
            Item.shoot = ModContent.ProjectileType<AcornShoot>();
            Item.rare = ItemRarityID.White;
            Item.useTime = 50;
            Item.useAnimation = 50;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.width = 25;
            Item.height = 25;
            Item.autoReuse = false;
            Item.value = 1000;
            Item.UseSound = SoundID.Item8;
        }
        public override void AddRecipes()
        {
            Recipe VaritaDeBellotas = CreateRecipe();
            VaritaDeBellotas.AddIngredient(ItemID.Wood, 15);
            VaritaDeBellotas.AddIngredient(ItemID.Acorn, 10);
            VaritaDeBellotas.AddTile(TileID.WorkBenches);
            VaritaDeBellotas.Register();










        }
    }
}
