using TJTTMN.Content.Tiles;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.IO;
using Terraria.ModLoader;
using Terraria.WorldBuilding;
using Terraria.GameContent.Generation;

namespace TJTTMN.Common.Systems.GenPasses
{
    internal class PaliteGenPass : GenPass
    {
        public PaliteGenPass(string name, float loadWeight) : base(name, loadWeight)
        {
        }

        public class PaliteSystem : ModSystem
        {
            public override void ModifyWorldGenTasks(List<GenPass> tasks, ref double totalWeight)
            {
                int UnderworldIndex = tasks.FindIndex(GenPass => GenPass.Name.Equals("Underworld"));
                //Se implementa este genpass luego de que se genere el inframundo, o sea luego de que se implemente el genpass "Underworld"
                //Antes lo usaba despues de el genpass de "shinies" que era cuando se generaban los ores
                //Esto traia problema y no generaba este ore en el inframundo ya que el genpass "Underworld" se aplica despues del de "shinies", y no habia ningun bloque para generar ores antes del de Underworld
                //Es importante fijarse el orden de los genpass del terraria vanilla para evitar esto
                if (UnderworldIndex != -1)
                {
                    tasks.Insert(UnderworldIndex + 1, new PaliteGenPass("Palite", 237.4298f));
                }
            }
        }

        protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
        {
            progress.Message = "Generating palite";

            for(int k = 0; k < (int)(Main.maxTilesX * Main.maxTilesY * 6E-05); k++)
            {
                int x = WorldGen.genRand.Next(0, Main.maxTilesX);
                int y = WorldGen.genRand.Next((int)Main.maxTilesY - 100, Main.maxTilesY);
                Tile tile = Framing.GetTileSafely(x, y);
                if (tile.TileType == TileID.Ash || tile.TileType == TileID.AshGrass)
                {
                    WorldGen.TileRunner(x, y, WorldGen.genRand.Next(3, 15), WorldGen.genRand.Next(12, 20), ModContent.TileType<PaliteTile>());
                }
            }
        }
    }
}
