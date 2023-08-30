using System;
using System.Collections.Generic;
using Terraria.ID;
using Terraria.IO;
using Terraria.ModLoader;
using Terraria.WorldBuilding;
using Terraria;
using TJTTMN.Content.Items.Materials;
using TJTTMN.Content.Items.Weapons.Ranger;
using TJTTMN.Content.Items.Weapons.Melee;
using TJTTMN.Content.Items.Accesories;
using TJTTMN.Content.Items.Weapons.Summoner;
using TJTTMN.Content.Items.Consumables;
using TJTTMN.Content.Tiles.Blocks;
using TJTTMN.Content.Tiles.Walls;
using TJTTMN.Content.Items.Weapons.Magic;

namespace TJTTMN.Common.Systems.GenPasses
{
    internal class WeedtiteShrineGenPass : GenPass
    {
        public WeedtiteShrineGenPass(string name, float loadWeight) : base(name, loadWeight)
        {
        }

        public class WeedtiteShrineSystem : ModSystem
        {
            public override void ModifyWorldGenTasks(List<GenPass> tasks, ref double totalWeight)
            {
                int finalIndex = tasks.FindIndex(GenPass => GenPass.Name.Equals("Final Cleanup"));
                //Se implementa este genpass luego de que se genere todo el mundo
                if (finalIndex != -1)
                {
                    tasks.Insert(finalIndex + 1, new WeedtiteShrineGenPass("WeedtiteShrineGenPassMod", 237.4298f));
                }
            }
        }

        protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
        {
            progress.Message = "Generating weedtite shrines";

            int structuresToGen = (int)(Main.maxTilesX * Main.maxTilesY * 0.0000017);
            int structuresGenerated = 0;
            int attemps = 0;

            while (structuresGenerated < structuresToGen) //Este bucle busca crear este tipo de estructura constantemente hasta que se genere el numero deseado
            {
                attemps++;
                if (attemps > 15000) //En caso de superarse los 15000 intentos para crear las estructuras, se rompe el bucle para evitar que el codigo se ejecute infinitamente
                {
                    break;
                }
                int x = WorldGen.genRand.Next(120, Main.maxTilesX - 120); //La posicion de la x debe ser un poco alejada del limite del mundo, si se eligiera un punto pegado al limite este genpass tiraria error ya que intentaria generar bloques fuera del limite
                int y = WorldGen.genRand.Next(Main.maxTilesY - Main.maxTilesY + 250, (int)Main.worldSurface);
                int validTileCounter = 0;
                int validTileCounterWeedtite = 0;

                //Este doble for escanea un area de 12x12 para detectar si todas las tiles de ese area son bloques de tierra/piedra/arcilla
                //Por cada bloque de tierra/piedra/arcilla en el area suma 1 al contador, y si el contador llega a 144 (12x12) significa que toda el area está hecha de bloques de tierra/piedra/arcilla
                for (int j = 0; j < 12; j++)
                    {
                        for (int i = 0; i < 12; i++)
                        {
                            Tile tile = Main.tile[x + j, y - i];
                            if ((tile.TileType == TileID.Dirt || tile.TileType == TileID.Stone || tile.TileType == TileID.ClayBlock || tile.TileType == ModContent.TileType<WeedtiteTile>()) && tile.HasTile)
                            {
                                validTileCounter++;
                            }
                        }
                    }

                //Este doble for escanea un area de 200x200 para detectar que ninguna de las tiles de ese area sean ladrillos weedtite
                //Por cada bloque que no sea ladrillo weedtite en el area, suma 1 al contador, y si el contador llega a 40000 (200x200) significa que en toda el area no hay ladrillos weedtite
                for (int j = 0; j < 200; j++)
                {
                    for (int i = 0; i < 200; i++)
                    {
                        Tile tile1 = Main.tile[x + j - 99, y - i + 99]; //-99 bloques a la izquierda y 99 bloques abajo, se hace esto para que escanee en un radio alrededor de la zona elegida, y no que simplemente escanee 200 bloques para una sola direccion
                        if (tile1.TileType != ModContent.TileType<WeedtiteBrickTile>())
                        {
                            validTileCounterWeedtite++;
                        }
                    }
                }

                //Se usan los valores acumulados de los contadores para decidir si la estructura debe generarse o no
                //Se escanea el area en busca de bloques de tierra/piedra/arcilla con el fin de que toda la estructura se genere cubierta por bloques, y no que esté descubierta en la superficie
                //Se escanea el area en busca de ladrillos weedtite para detectar si esta estructura ya se generó anteriormente cerca del area elegida, para evitar que se generen 2 estructuras del mismo tipo muy cerca
                if (validTileCounter >= 144 && validTileCounterWeedtite >= 40000)
                {
                    structuresGenerated++;

                    //Este enjambre de placetile y killtile coloca y destruye bloques en posiciones especificas para construir la estructura de la forma deseada
                    //No es nada del otro mundo, simplemente es logica de calcular las coordenadas para colocar cada bloque en la posicion correcta

                    for (int j = 3; j < 9; j++)
                    {
                        for (int i = 3; i < 8; i++)
                        {
                            WorldGen.KillTile(x + j, y - i);
                        }
                    }

                    for (int i = 3; i < 6; i++)
                    {
                        WorldGen.KillTile(x + 2, y - i);
                        WorldGen.KillTile(x + 9, y - i);
                        WorldGen.PlaceTile(x + 2, y - i, TileID.WoodenBeam);
                        WorldGen.PlaceTile(x + 9, y - i, TileID.WoodenBeam);
                    }

                    for (int i = 4; i < 8; i++)
                    {
                        WorldGen.KillTile(x + i, y - 8);
                    }

                    for (int j = 0; j < 12; j++)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            WorldGen.KillTile(x + j, y - i);
                            WorldGen.PlaceTile(x + j, y - i, ModContent.TileType<WeedtiteBrickTile>());
                        }
                    }

                    WorldGen.KillTile(x, y - 1);
                    WorldGen.KillTile(x, y - 2);
                    WorldGen.KillTile(x + 1, y - 2);
                    WorldGen.KillTile(x + 11, y - 1);
                    WorldGen.KillTile(x + 11, y - 2);
                    WorldGen.KillTile(x + 10, y - 2);
                    WorldGen.PlaceTile(x, y - 1, TileID.Dirt);
                    WorldGen.PlaceTile(x, y - 2, TileID.Dirt);
                    WorldGen.PlaceTile(x + 1, y - 2, TileID.Dirt);
                    WorldGen.PlaceTile(x + 11, y - 1, TileID.Dirt);
                    WorldGen.PlaceTile(x + 11, y - 2, TileID.Dirt);
                    WorldGen.PlaceTile(x + 10, y - 2, TileID.Dirt);

                    for (int i = 6; i < 9; i++)
                    {
                        WorldGen.KillTile(x + 2, y - i);
                        WorldGen.KillTile(x + 9, y - i);
                        WorldGen.PlaceTile(x + 2, y - i, ModContent.TileType<WeedtiteBrickTile>());
                        WorldGen.PlaceTile(x + 9, y - i, ModContent.TileType<WeedtiteBrickTile>());
                    }

                    WorldGen.KillTile(x + 3, y - 8);
                    WorldGen.KillTile(x + 3, y - 9);
                    WorldGen.KillTile(x + 4, y - 9);
                    WorldGen.KillTile(x + 4, y - 10);
                    WorldGen.KillTile(x + 7, y - 10);
                    WorldGen.KillTile(x + 7, y - 9);
                    WorldGen.KillTile(x + 8, y - 9);
                    WorldGen.KillTile(x + 8, y - 8);
                    WorldGen.PlaceTile(x + 3, y - 8, ModContent.TileType<WeedtiteBrickTile>());
                    WorldGen.PlaceTile(x + 3, y - 9, ModContent.TileType<WeedtiteBrickTile>());
                    WorldGen.PlaceTile(x + 4, y - 9, ModContent.TileType<WeedtiteBrickTile>());
                    WorldGen.PlaceTile(x + 4, y - 10, ModContent.TileType<WeedtiteBrickTile>());
                    WorldGen.PlaceTile(x + 7, y - 10, ModContent.TileType<WeedtiteBrickTile>());
                    WorldGen.PlaceTile(x + 7, y - 9, ModContent.TileType<WeedtiteBrickTile>());
                    WorldGen.PlaceTile(x + 8, y - 9, ModContent.TileType<WeedtiteBrickTile>());
                    WorldGen.PlaceTile(x + 8, y - 8, ModContent.TileType<WeedtiteBrickTile>());

                    for (int i = 9; i < 12; i++)
                    {
                        WorldGen.KillTile(x + 5, y - i);
                        WorldGen.KillTile(x + 6, y - i);
                        WorldGen.PlaceTile(x + 5, y - i, ModContent.TileType<WeedtiteBrickTile>());
                        WorldGen.PlaceTile(x + 6, y - i, ModContent.TileType<WeedtiteBrickTile>());
                    }

                    for (int i = 3; i < 9; i++)
                    {
                        for (int j = 3; j < 8; j++)
                        {
                            WorldGen.KillWall(x + i, y - j);
                            WorldGen.PlaceWall(x + i, y - j, ModContent.WallType<WeedtiteBrickWallTile>());
                        }
                    }

                    for (int i = 4; i < 8; i++)
                    {
                        WorldGen.KillWall(x + i, y - 8);
                        WorldGen.PlaceWall(x + i, y - 8, ModContent.WallType<WeedtiteBrickWallTile>());
                    }

                    //Con style se puede elegir el tipo de antorcha, en este caso style 3 es la antorcha verde
                    WorldGen.PlaceTile(x + 4, y - 6, TileID.Torches, style: 3);
                    WorldGen.PlaceTile(x + 7, y - 6, TileID.Torches, style: 3);


                    // Todo el codigo de abajo es para generar un cofre en la estructura y añadirle items
                    int chestIndex = WorldGen.PlaceChest(x + 5, y - 3, style: 0);

                    if (chestIndex != -1)
                    {
                        Chest chest = Main.chest[chestIndex];
                        var itemsToAdd = new List<(int type, int stack)>(); //La lista de items a añadir al cofre. Debemos acceder a esto cada vez que se agregue un item al cofre

                        //Usamos un switch para elegir uno de 4 casos. Cada caso agrega un arma distinta al cofre en el primer slot
                        //Esto se hace para que elegir al azar 1 de 4 armas que queramos que aparezcan en el cofre
                        switch (Main.rand.Next(4))
                        {
                            case 0:
                                    itemsToAdd.Add((ModContent.ItemType<CaptivatingFlower>(), 1)); //El 1 significa la cantidad de items que se colocan en el stack
                                break;
                            case 1:
                                    itemsToAdd.Add((ModContent.ItemType<AcornBurner>(), 1)); 
                                break;
                            case 2:
                                    itemsToAdd.Add((ModContent.ItemType<AcornWand>(), 1));
                                break;
                            case 3:
                                    itemsToAdd.Add((ModContent.ItemType<HerbsMixtureWhip>(), 1));
                                break;
                        }

                        //Agregar pociones al cofre, una de entre las 8 opciones
                        switch (Main.rand.Next(8))
                        {
                            case 0:
                                itemsToAdd.Add((ModContent.ItemType<NatureBrew>(), Main.rand.Next(1, 5)));
                                break;
                            case 1:
                                itemsToAdd.Add((ModContent.ItemType<WeedtiteSpeedPotion>(), Main.rand.Next(1, 5)));
                                break;
                            case 2:
                                itemsToAdd.Add((ItemID.IronskinPotion, Main.rand.Next(1, 5)));
                                break;
                            case 3:
                                itemsToAdd.Add((ItemID.RegenerationPotion, Main.rand.Next(1, 4)));
                                break;
                            case 4:
                                itemsToAdd.Add((ItemID.SwiftnessPotion, Main.rand.Next(1, 4)));
                                break;
                            case 5:
                                itemsToAdd.Add((ItemID.MiningPotion, Main.rand.Next(1, 3)));
                                break;
                            case 6:
                                itemsToAdd.Add((ItemID.ArcheryPotion, Main.rand.Next(1, 4)));
                                break;
                            case 7:
                                itemsToAdd.Add((ItemID.GillsPotion, Main.rand.Next(1, 5)));
                                break;
                        }

                        //Agregar (algunas veces) lingotes de hierro al cofre
                        switch (Main.rand.Next(6))
                        {
                            case 0:
                                itemsToAdd.Add((ItemID.IronBar, Main.rand.Next(3, 15)));
                                break;
                            case 1:
                                itemsToAdd.Add((ItemID.LeadBar, Main.rand.Next(3, 15)));
                                break;
                        }

                        //Agregar pociones de vida y mana al cofre, quiero que puedan aparecer los dos tipos en un mismo cofre por lo que no hace falta incluir switch
                        itemsToAdd.Add((ItemID.LesserHealingPotion, Main.rand.Next(3, 12)));
                        if (Main.rand.NextBool()) //A veces quiero que no aparezcan las pociones de mana, por lo que uso un if con un rand bool
                        {
                            itemsToAdd.Add((ItemID.LesserManaPotion, Main.rand.Next(3, 15)));
                        }

                        //Agregar (algunas veces) o bolsas de hierba, o latas de gusanos al cofre
                        switch (Main.rand.Next(8))
                        {
                            case 0:
                                itemsToAdd.Add((ItemID.HerbBag, Main.rand.Next(1, 3)));
                                break;
                            case 1:
                                itemsToAdd.Add((ItemID.CanOfWorms, Main.rand.Next(1, 3)));
                                break;
                        }

                        //Agregar shurikens y cuchillos arrojadizos al cofre, misma situacion que la anterior
                        itemsToAdd.Add((ItemID.Shuriken, Main.rand.Next(13, 45)));
                        if (Main.rand.NextBool()) 
                        {
                            itemsToAdd.Add((ItemID.ThrowingKnife, Main.rand.Next(9, 40)));
                        }

                        //Agregar (rara vez) una estatua de angel al cofre
                        if (Main.rand.NextBool(20))
                        {
                            itemsToAdd.Add((ItemID.AngelStatue, 1));
                        }

                        //Agregar (a veces) vine gel al cofre
                        if (Main.rand.NextBool(3))
                        {
                            itemsToAdd.Add((ModContent.ItemType<VineGel>(), Main.rand.Next(3, 12)));
                        }

                        //Agregar cuerdas al cofre
                        itemsToAdd.Add((ItemID.Rope, Main.rand.Next(12, 50)));

                        //Agregar (a veces) botellas al cofre
                        if (Main.rand.NextBool())
                        {
                            itemsToAdd.Add((ItemID.Bottle, Main.rand.Next(4, 19)));
                        }

                        //Agregar weedtite o brotes de weedtite al cofre
                        if (Main.rand.NextBool())
                        {
                            itemsToAdd.Add((ModContent.ItemType<Weedtite>(), Main.rand.Next(1, 12)));
                        }
                        else
                        {
                            itemsToAdd.Add((ModContent.ItemType<WeedtiteSprout>(), Main.rand.Next(5, 26)));
                        }

                        //Agregar (2 veces de cada 3) pociones de recuperacion al cofre
                        if (!Main.rand.NextBool(3))
                        {
                            itemsToAdd.Add((ItemID.RecallPotion, Main.rand.Next(2, 5)));
                        }

                        //Agregar (a veces) monedas al cofre
                        if (Main.rand.NextBool())
                        {
                            itemsToAdd.Add((ItemID.SilverCoin, Main.rand.Next(3, 55)));
                        }
                        if (Main.rand.NextBool())
                        {
                            itemsToAdd.Add((ItemID.CopperCoin, Main.rand.Next(40, 85)));
                        }

                        int chestItemIndex = 0;
                        foreach (var itemToAdd in itemsToAdd) // Por cada item a añadir de la lista, se ejecuta este codigo
                        {
                            Item item = new Item();
                            item.SetDefaults(itemToAdd.type);
                            item.stack = itemToAdd.stack;
                            chest.item[chestItemIndex] = item;
                            chestItemIndex++;
                            if (chestItemIndex >= 40) // Si la cantidad de stacks excede 40, deja de agregar items al cofre, ya que esa es la capacidad maxima
                                break;
                        }
                    }
                }

            }
        }
    }
}
