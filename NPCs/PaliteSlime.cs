using Terraria;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;
using TJTTMN.Content.Items.Materials;

namespace TJTTMN.Content.NPCs
{
    public class PaliteSlime : ModNPC
    {
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[Type] = Main.npcFrameCount[NPCID.BlueSlime];
            NPCID.Sets.NPCBestiaryDrawModifiers value = new NPCID.Sets.NPCBestiaryDrawModifiers(0)
            {
                Velocity = 1f
            };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, value);
        }
        public override void SetDefaults()
        {
            NPC.height = 26;
            NPC.width = 32;
            NPC.damage = 20;
            NPC.defense = 12;
            NPC.lifeMax = 60;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.value = 2507f;
            NPC.knockBackResist = 0.4f;
            NPC.aiStyle = 1;
            AIType = NPCID.UmbrellaSlime;
            AnimationType = NPCID.LavaSlime;
            NPC.lavaImmune = true;
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (NPC.downedBoss3 == true)
            { 
                return SpawnCondition.Underworld.Chance * 0.75f;
            }
            else
            {
                return 0f;
            }
            
            
        }

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<MysticalGel>(), 1, 2, 4));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<PaliteSeeds>(), 4, 2, 5));
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheUnderworld,
                new FlavorTextBestiaryInfoElement("This curious slime ended in the underworld after exploring very deep in this terraria world. It somehow survived, and consumed some Palite seeds, gaining magical properties."),
                });
        }
    }
}
