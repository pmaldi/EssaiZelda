using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssaiZelda
{
    class Map
    {
        public int MAP_HEIGHT = 700;
        public int MAP_WIDTH = 700;
        public int TILE_HEIGHT = 70;
        public int TILE_WIDTH = 70;

        public Texture2D grassCenter;
        public Texture2D liquidLava;
        public Texture2D liquidWater;
        public Texture2D snowCenter;
        public Texture2D stoneCenter;


        int[,] Carte = {
            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            { 1, 1, 1, 2, 1, 1, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            { 1, 1, 1, 2, 1, 1, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 1, 1, 3, 1, 1, 1 },
            { 1, 1, 1, 2, 1, 1, 1, 1, 1, 1 },
            { 1, 5, 1, 1, 1, 1, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 1, 1, 4, 1, 1, 1 },
            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
        };

        public Texture2D[] TileTextures = new Texture2D[6]; // On défini un Tableau de Texture2D de taille 6 élements [0-5]
        
        public void Load()
        {
            System.Diagnostics.Debug.WriteLine("Début d'affectation des Tiles...");
            TileTextures[0] = null;
            TileTextures[1] = grassCenter;
            TileTextures[2] = liquidLava;
            TileTextures[3] = liquidWater;
            TileTextures[4] = snowCenter;
            TileTextures[5] = stoneCenter;
            System.Diagnostics.Debug.WriteLine("Début d'affectation des Tiles terminées...");

        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            int c, l, id;
            for (l=0; l< 10; l++) // Notre carte possede 10 Lignes
            {
                for (c = 0; c < 10; c++) // Et également 10 Colonnes
                {
                    id = Carte[l,c]; //recupere le numéro de la tile
                    spriteBatch.Begin();
                    int x = c * TILE_WIDTH; //Position X de la tile
                    int y = l * TILE_HEIGHT; //Position Y de la tile
                    spriteBatch.Draw(TileTextures[id], new Rectangle(x, y, TILE_HEIGHT, TILE_WIDTH), Color.White); // On déssine la tile a X et Y d'une longeur TILE_HEIGHT & TILE_WIDTH
                    spriteBatch.End();
                }
            }
        }
    }
}
