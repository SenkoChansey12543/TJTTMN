using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using TJTTMN.Content.Projectiles;
using TJTTMN.Content.Items.Weapons.Ranger;

namespace TJTTMN.Common.Systems.GlobalItems
{
    public class GlobalAmmoMushroomMod : GlobalItem
    {
        public override void SetDefaults(Item item)
        {
            if (item.type == ItemID.Mushroom)
            {
                item.ammo = ItemID.Mushroom;
                item.shoot = ModContent.ProjectileType<MushroomProjectile>();
            }
            if (item.type == ItemID.VileMushroom)
            {
                item.ammo = ItemID.Mushroom;
                item.shoot = ModContent.ProjectileType<VileMushroomProjectile>();
                item.consumable = true;
            }
            if (item.type == ItemID.ViciousMushroom)
            {
                item.ammo = ItemID.Mushroom;
                item.shoot = ModContent.ProjectileType<ViciousMushroomProjectile>();
                item.consumable = true;
            }
            if (item.type == ItemID.GlowingMushroom)
            {
                item.ammo = ItemID.Mushroom;
                if (item.type == ModContent.ItemType<MushroomCannon>())
                {
                    item.shoot = ModContent.ProjectileType<GlowingMushroomProjectile>();
                }
            }

        }
    }
}
