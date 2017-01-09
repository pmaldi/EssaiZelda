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

            graphics.PreferredBackBufferWidth = MaMap.MAP_WIDTH;  // set this value to the desired width of your window
            graphics.PreferredBackBufferHeight = MaMap.MAP_HEIGHT;   // set this value to the desired height of your window
            graphics.ApplyChanges();
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            System.Diagnostics.Debug.WriteLine("Début de chargement des textures...");
            MaMap.grassCenter = Content.Load<Texture2D>("images/grassCenter");
            MaMap.liquidLava = Content.Load<Texture2D>("images/liquidLava");
            MaMap.liquidWater = Content.Load<Texture2D>("images/liquidWater");
            MaMap.snowCenter = Content.Load<Texture2D>("images/snowCenter");
            MaMap.stoneCenter = Content.Load<Texture2D>("images/stoneCenter");
            System.Diagnostics.Debug.WriteLine("Début de chargement des textures terminées...");
            MaMap.Load();
            // TODO: use this.Content to load your game content here
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
            MaMap.Draw(gameTime,spriteBatch); // On Appel la fonction Draw de la Class Map

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
