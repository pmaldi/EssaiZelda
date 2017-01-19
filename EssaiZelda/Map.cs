using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiledSharp;
using Microsoft.Xna.Framework.Input;

namespace EssaiZelda
{
    class Map
    {
        Player Hero = new Player();
        public int MAP_HEIGHT = 23 * 32; // Nombre de Tiles * Taille des Tiles.
        public int MAP_WIDTH = 32 * 32; // Nombre de Tiles * Taille des Tiles.

        TmxMap map = new TmxMap("Map/ZeldaTest.tmx");
        public Texture2D tileset;

        public int tileWidth; // Valeur Récupéré grace a TMXMAP
        public int tileHeight; // Valeur Récupéré grace a TMXMAP
        public int tilesetTilesWide;
        public int tilesetTilesHigh;

        public int[,] Tiles;
        public string[] TilesTypes = new string[1180];

        public void Load()
        {
            System.Diagnostics.Debug.WriteLine("Début d'affectation des Tiles...");
            var version = map.Version;
            var myTileset = map.Tilesets["Zelda"];
            var myLayer = map.Layers[0];
            System.Diagnostics.Debug.WriteLine("Récupérations des tailles des Tile...");
            tileWidth = map.Tilesets[0].TileWidth;
            tileHeight = map.Tilesets[0].TileHeight;
            System.Diagnostics.Debug.WriteLine("Récupérations des tailles HD des Tile...");
            tilesetTilesWide = tileset.Width / tileWidth;
            tilesetTilesHigh = tileset.Height / tileHeight;
            System.Diagnostics.Debug.WriteLine("Début d'affectation des Tiles terminées...");
            setTileCoord();
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            for (var i = 0; i < map.Layers[0].Tiles.Count; i++) //on compte le nombre de Tiles est nécessaire pour faire la map.
            {
                int gid = map.Layers[0].Tiles[i].Gid; // On récupere l'id de la Tile.
                if (gid == 0)
                {
                    //Si l'id de la tile est 0 alors on affiche un "trou"
                }
                else
                {
                    int tileFrame = gid - 1;
                    int column = tileFrame % tilesetTilesWide;
                    int row = (int)Math.Floor((double)tileFrame / (double)tilesetTilesWide);

                    float x = (i % map.Width) * map.TileWidth; // On calcule les coordonnées de positionnement de la tile
                    float y = (float)Math.Floor(i / (double)map.Width) * map.TileHeight; // On calcule les coordonnées de positionnement de la tile

                    Rectangle tilesetRec = new Rectangle(tileWidth * column, tileHeight * row, tileWidth, tileHeight); // On récupere la Tile d'origine

                    spriteBatch.Draw(tileset, new Rectangle((int)x, (int)y, tileWidth, tileHeight), tilesetRec, Color.White); // On dessine la Tile
                }
            }
        }

        public void setTileCoord()
        {
            Tiles = new int[32, 23]; //on crée un tableau correspondant au nombre de Tiles
            for (var i = 0; i < map.Layers[1].Tiles.Count; i++) //on compte le nombre de Tiles
            {
                Tiles[map.Layers[1].Tiles[i].X, map.Layers[1].Tiles[i].Y] = map.Layers[1].Tiles[i].Gid; // on attribue au coordonnée X/Y l'id de la tile
            }
            TilesTypes[0] = "Walk";
            TilesTypes[1179] = "Interdit";

            System.Diagnostics.Debug.WriteLine("Alimentation du Tableau Tiles.. Function setTileCoord..");

        }

        public string Information() // Fonction d'aide pour avoir des infos (ID, X,Y)
        {
            int X = Mouse.GetState().X;
            int Y = Mouse.GetState().Y;
            int col = (Convert.ToInt32(X) / tileWidth);
            int lig = (Convert.ToInt32(Y) / tileHeight);
            if (col >= 0 && col < (MAP_WIDTH / tileWidth) && lig >= 0 && lig < (MAP_HEIGHT / tileHeight))
            {
                //return TilesTypes[Tiles[col, lig]] +" ||| X : "+col+" ||| Y : "+lig;
                return Tiles[col, lig] +" ||| X : "+col+" ||| Y : "+lig;
            }
            else
            {
                return "KO";
            }
        }

        public bool isSolid(string LaTile) // Fonction qui permet de définir et verifier les Tiles Solides.
        {
            if (LaTile == "Walk")
            {
                return false;
            }
            return true;
        }
    }
}