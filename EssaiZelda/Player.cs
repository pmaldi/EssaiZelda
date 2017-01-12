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
        public Texture2D[] HeroImages = new Texture2D[5];
        public Texture2D Player_1;
        public Texture2D Player_2;
        public Texture2D Player_3;
        public Texture2D Player_4;
        double imageCurrent;
        int PlayerLine;
        int PlayerColumn;
        bool KeyPressed = false;

        public void Load()
        {
            HeroImages[1] = Player_1;
            HeroImages[2] = Player_2;
            HeroImages[3] = Player_3;
            HeroImages[4] = Player_4;
            imageCurrent = 1;
            PlayerLine = 1;
            PlayerColumn = 1;
        }

        public void Update(Map pMap, GameTime gameTime)
        {
            var dt = (float)gameTime.ElapsedGameTime.TotalSeconds;
            imageCurrent = imageCurrent + (5*dt);
            if (imageCurrent >= HeroImages.Count<Texture2D>())
            {
                imageCurrent = 1;
            }


            if (Keyboard.GetState().IsKeyDown(Keys.Up) || (Keyboard.GetState().IsKeyDown(Keys.Right) || (Keyboard.GetState().IsKeyDown(Keys.Down) || (Keyboard.GetState().IsKeyDown(Keys.Left))))){
                
                if(KeyPressed == false){

                    if (Keyboard.GetState().IsKeyDown(Keys.Up) && PlayerLine > 1)
                    {
                        PlayerLine = PlayerLine - 1;
                    }
                    if (Keyboard.GetState().IsKeyDown(Keys.Right) && PlayerColumn < (pMap.MAP_WIDTH/pMap.tileWidth))
                    {
                        PlayerColumn = PlayerColumn + 1;
                    }
                    if (Keyboard.GetState().IsKeyDown(Keys.Down) && PlayerLine < (pMap.MAP_HEIGHT/pMap.tileHeight))
                    {
                        PlayerLine = PlayerLine + 1;
                    }
                    if (Keyboard.GetState().IsKeyDown(Keys.Left) && PlayerColumn > 1)
                    {
                        PlayerColumn = PlayerColumn - 1;
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
            spriteBatch.Draw(HeroImages[(int)imageCurrent], new Rectangle((int)x, (int)y, 32, 32), Color.White); // On dessine notre Joueur
        }
    }
}
