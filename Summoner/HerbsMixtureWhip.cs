using System;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria;
using Terraria.GameContent.Creative;
using TJTTMN.Content.Buffs.WhipBuffs;
using TJTTMN.Content.Projectiles.Whips;
using TJTTMN.Content.Items.Materials;
using TJTTMN.Content.Tiles;


namespace TJTTMN.Content.Items.Weapons.Summoner
{
    public class HerbsMixtureWhip : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(HerbsMixtureWhipBuff.TagDamage);

        public override void SetDefaults()
        {
            Item.DefaultToWhip(ModContent.ProjectileType<HerbsMixtureWhipProjectile>(), 11, 2, 4, 45);
            Item.rare = ItemRarityID.White;
            Item.value = Item.buyPrice(silver: 16, copper: 43);
        }

        public override bool MeleePrefix()
        {
            return true;
        }
    }
}
