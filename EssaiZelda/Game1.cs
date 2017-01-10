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
            MaMap.tileset = Content.Load<Texture2D>("images/tilesheet");
            MaMap.Load();
            System.Diagnostics.Debug.WriteLine("Début de chargement des textures terminées...");

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

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            MaMap.Draw(gameTime, spriteBatch); // On Appel la fonction Draw de la Class Map
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
