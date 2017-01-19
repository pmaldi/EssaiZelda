using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssaiZelda
{
    class Player
    {
        public Texture2D[] PlayerUp = new Texture2D[6]; // Ensemble d'images
        public Texture2D[] PlayerDown = new Texture2D[6]; // Ensemble d'images
        public Texture2D[] PlayerRight = new Texture2D[6]; // Ensemble d'images
        public Texture2D[] PlayerLeft = new Texture2D[6]; // Ensemble d'images
        Texture2D ImageAffiche; // Me permet de recupéré la Texture2D quand on press une touche directionnel et surtout permet de l'afficher dans le SpriteBatch
        double imageCurrent; // Curseur de position de l'image
        int PlayerLine; // La ligne sur laquelle ce trouve le Player
        int PlayerColumn; // La colonne cette fois
        bool KeyPressed = false; // Boolean qui bloque la répétition de touche

        public void Load()
        {
            ImageAffiche = PlayerDown[1]; // Image Down1 au lancement du jeu
            imageCurrent = 1; // Initialisation du curseur
            PlayerLine = 9; // Ligne de départ du Player (Attention, ajoute +1 car -1 dans les calculs)
            PlayerColumn = 3; // Colonne de départ du Player (Attention, ajoute +1 car -1 dans les calculs)
        }

        public void Update(Map pMap, GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Up) || (Keyboard.GetState().IsKeyDown(Keys.Right) || (Keyboard.GetState().IsKeyDown(Keys.Down) || (Keyboard.GetState().IsKeyDown(Keys.Left))))){
                
                if(KeyPressed == false){
                    int oldPlayerColumn = PlayerColumn; // On stock la valeur précedente de la colonne
                    int oldPlayerLine = PlayerLine; // et de la ligne en cas de tile interdit

                    if (Keyboard.GetState().IsKeyDown(Keys.Up) && PlayerLine > 1)
                    {
                        PlayerLine = PlayerLine - 1;
                        ImageAffiche = Animation(gameTime, PlayerUp); // Fonction qui permet de récupéré la texture a affiché
                    }
                    if (Keyboard.GetState().IsKeyDown(Keys.Right) && PlayerColumn < (pMap.MAP_WIDTH/pMap.tileWidth))
                    {
                        PlayerColumn = PlayerColumn + 1;
                        ImageAffiche = Animation(gameTime, PlayerRight); // Fonction qui permet de récupéré la texture a affiché
                    }
                    if (Keyboard.GetState().IsKeyDown(Keys.Down) && PlayerLine < (pMap.MAP_HEIGHT/pMap.tileHeight))
                    {
                        PlayerLine = PlayerLine + 1;
                        ImageAffiche = Animation(gameTime, PlayerDown); // Fonction qui permet de récupéré la texture a affiché
                    }
                    if (Keyboard.GetState().IsKeyDown(Keys.Left) && PlayerColumn > 1)
                    {
                        PlayerColumn = PlayerColumn - 1;
                        ImageAffiche = Animation(gameTime, PlayerLeft); // Fonction qui permet de récupéré la texture a affiché
                    }

                    string SolDuPlayer = pMap.TilesTypes[pMap.Tiles[PlayerColumn-1, PlayerLine-1]]; // On regarde sous nos pied le type de Tile
                    if (pMap.isSolid(SolDuPlayer)) // Si la tile est Interdite on revient a la position précédente
                    {
                        System.Diagnostics.Debug.WriteLine(SolDuPlayer); // "Interdit / "Walk"
                        System.Diagnostics.Debug.WriteLine("Impossible... isSolid");
                        PlayerColumn = oldPlayerColumn; 
                        PlayerLine = oldPlayerLine;
                    }
                    KeyPressed = true;
                }
            }else{
                KeyPressed = false;
            }
        }

        public void Draw(Map pMap, GameTime gameTime, SpriteBatch spriteBatch)
        {
            int x = (PlayerColumn - 1) * pMap.tileWidth;
            int y = (PlayerLine - 1) * pMap.tileHeight;
            spriteBatch.Draw(ImageAffiche, new Rectangle((int)x, (int)y, 32, 32), Color.White); // On dessine notre Joueur
        }

        public Texture2D Animation(GameTime gameTime, Texture2D[] Images)
        {
            // var dt = (float)gameTime.ElapsedGameTime.TotalSeconds; // Permet d'ajuster la vitesse de l'animation, pas utile depuis la fonction Animation();
            imageCurrent = imageCurrent + 1;
            if (imageCurrent >= Images.Count<Texture2D>())
            {
                imageCurrent = 1;
                return Images[1];
            }
            return Images[(int)imageCurrent]; // Renvoi la Texture2D dans la bonne orientation
        }
    }
}
