using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace EssaiZelda
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Map MaMap = new Map();
        Player Hero = new Player();

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = MaMap.MAP_WIDTH;  // Largeur de l'Ecran
            graphics.PreferredBackBufferHeight = MaMap.MAP_HEIGHT;   // Hauteur de l'Ecran
            IsMouseVisible = true; // Affiche la Souris
            graphics.ApplyChanges();
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            System.Diagnostics.Debug.WriteLine("Début de chargement des textures...");
            MaMap.tileset = Content.Load<Texture2D>("images/tilesheet_Zelda");
            MaMap.Load();
            System.Diagnostics.Debug.WriteLine("Début de chargement des textures terminées...");
            System.Diagnostics.Debug.WriteLine("Début de chargement du Hero...");
            for (var i = 1; i <= 6; i++)
            {
                Hero.PlayerUp[i-1] = Content.Load<Texture2D>("images/player/up/Up"+i);
                Hero.PlayerDown[i-1] = Content.Load<Texture2D>("images/player/down/Down"+i);
                Hero.PlayerLeft[i-1] = Content.Load<Texture2D>("images/player/left/Left"+i);
                Hero.PlayerRight[i-1] = Content.Load<Texture2D>("images/player/right/Right"+i);
            }

            Hero.Load();
            System.Diagnostics.Debug.WriteLine("Début de chargement du Hero terminés...");
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            Window.Title = "ID : " + MaMap.Information();
            Hero.Update(MaMap,gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            MaMap.Draw(gameTime, spriteBatch); // On Appel la fonction Draw de la Class Map
            Hero.Draw(MaMap,gameTime,spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
