using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using TiledSharp;

namespace EssaiZelda
{
    class Boutique : Map
    {
        public TmxMap shop = new TmxMap("Map/Shop.tmx");

        public void Load()
        {
            System.Diagnostics.Debug.WriteLine("Début d'affectation des Tiles...");
            var version = shop.Version;
            var myTileset = shop.Tilesets["shop"];
            var myLayer = shop.Layers[0];
            System.Diagnostics.Debug.WriteLine("Récupérations des tailles des Tile...");
            tileWidth = shop.Tilesets[0].TileWidth;
            tileHeight = shop.Tilesets[0].TileHeight;
            System.Diagnostics.Debug.WriteLine("Récupérations des tailles HD des Tile...");
            tilesetTilesWide = tileset.Width / tileWidth;
            tilesetTilesHigh = tileset.Height / tileHeight;
            System.Diagnostics.Debug.WriteLine("Début d'affectation des Tiles terminées...");
            setTileCoord(shop);
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            for (var i = 0; i < shop.Layers[0].Tiles.Count; i++) //on compte le nombre de Tiles est nécessaire pour faire la map.
            {
                int gid = shop.Layers[0].Tiles[i].Gid; // On récupere l'id de la Tile.
                if (gid == 0)
                {
                    //Si l'id de la tile est 0 alors on affiche un "trou"
                }
                else
                {
                    int tileFrame = gid - 1;
                    int column = tileFrame % tilesetTilesWide;
                    int row = (int)Math.Floor((double)tileFrame / (double)tilesetTilesWide);

                    float x = (i % shop.Width) * shop.TileWidth; // On calcule les coordonnées de positionnement de la tile
                    float y = (float)Math.Floor(i / (double)shop.Width) * shop.TileHeight; // On calcule les coordonnées de positionnement de la tile

                    Rectangle tilesetRec = new Rectangle(tileWidth * column, tileHeight * row, tileWidth, tileHeight); // On récupere la Tile d'origine

                    spriteBatch.Draw(tileset, new Rectangle((int)x, (int)y, tileWidth, tileHeight), tilesetRec, Color.White); // On dessine la Tile
                }
            }
        }
    }
}