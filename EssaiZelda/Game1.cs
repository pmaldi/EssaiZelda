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
        Boutique MaBoutique = new Boutique();
        Player Hero = new Player();

        public enum GameState { MapPrincipal, MapBoutique}
        public GameState currentState = GameState.MapPrincipal;

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
            MaBoutique.tileset = Content.Load<Texture2D>("images/shop");
            MaBoutique.Load();
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
            Hero.currentState = currentState;
            switch (currentState)
            {
                case GameState.MapPrincipal:
                    {
                        Window.Title = "ID : " + MaMap.Information(currentState);
                        if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                        {
                            currentState = GameState.MapBoutique;
                            Hero.currentState = GameState.MapBoutique;
                            MaMap.currentState = GameState.MapBoutique;
                        }
                    }
                break;
                case GameState.MapBoutique:
                    {
                        Window.Title = "ID : " + MaBoutique.Information(currentState);
                        if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                        {
                            currentState = GameState.MapPrincipal;
                            Hero.currentState = GameState.MapPrincipal;
                            MaMap.currentState = GameState.MapPrincipal;
                        }
                    }
                    break;
            }
            // TODO: Add your update logic here
            Hero.Update(MaMap, MaBoutique, gameTime, spriteBatch);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {

            if(currentState == GameState.MapPrincipal)
            {
                GraphicsDevice.Clear(Color.Black);
                spriteBatch.Begin();
                MaMap.Draw(gameTime, spriteBatch); // On Appel la fonction Draw de la Class Map
                Hero.Draw(MaMap, gameTime,Hero.PlayerColumn,Hero.PlayerLine, spriteBatch);
                spriteBatch.End();
            }
            if(currentState == GameState.MapBoutique)
            {
                GraphicsDevice.Clear(Color.Black);
                spriteBatch.Begin();
                MaBoutique.Draw(gameTime, spriteBatch); // On Appel la fonction Draw de la Class Map
                Hero.Draw(MaBoutique, gameTime, Hero.PlayerColumn, Hero.PlayerLine, spriteBatch);
                spriteBatch.End();
            }
            base.Draw(gameTime);
        }
    }
}
