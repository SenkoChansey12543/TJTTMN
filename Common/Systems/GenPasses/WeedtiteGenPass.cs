﻿using TJTTMN.Content.Tiles;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.IO;
using Terraria.ModLoader;
using Terraria.WorldBuilding;

namespace TJTTMN.Common.Systems.GenPasses
{
    internal class WeedtiteGenPass : GenPass
    {
        public WeedtiteGenPass(string name, float loadWeight) : base(name, loadWeight)
        {
        }
        public class WeedtiteSystem : ModSystem
        {
            public override void ModifyWorldGenTasks(List<GenPass> tasks, ref double totalWeight)
            {
                int ShiniesIndex = tasks.FindIndex(GenPass => GenPass.Name.Equals("Armoplantite"));
                if (ShiniesIndex != -1)
                {
                    tasks.Insert(ShiniesIndex + 1, new WeedtiteGenPass("Weedtite", 237.4298f));
                }

            }
        }
        protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
        {
            progress.Message = "Generating weedtite";

            for (int k = 0; k < (int)(Main.maxTilesX * Main.maxTilesY * 6E-05); k++)
            {
                int x = WorldGen.genRand.Next(0, Main.maxTilesX);
                int y = WorldGen.genRand.Next((int)GenVars.worldSurfaceLow, Main.maxTilesY);
                Tile tile = Framing.GetTileSafely(x, y);
                if (tile.TileType == TileID.Dirt)
                {
                    WorldGen.TileRunner(x, y, WorldGen.genRand.Next(5, 18), WorldGen.genRand.Next(25, 35), ModContent.TileType<WeedtiteTile>());
                }
            }
        }
    }
}
