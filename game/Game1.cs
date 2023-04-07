using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace game
{
    enum Stat
    {
        SplashScreen,
        Game,
        Final,
        Pause
    }
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Stat Stat = Stat.SplashScreen;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            
        }

        protected override void Initialize()
        {
            _graphics.PreferredBackBufferWidth = 1000;
            _graphics.PreferredBackBufferHeight = 700;
            _graphics.IsFullScreen = false;
            _graphics.ApplyChanges();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            SplashScreen.Background = Content.Load<Texture2D>("beautifulPicture");
            SplashScreen.Font = Content.Load<SpriteFont>("SplashFont");
            Items.Init(_spriteBatch, _graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);
            Star.Texture2D = Content.Load<Texture2D>("star"); 
        }

        protected override void Update(GameTime gameTime)
        {
            switch (Stat)
            {
                case Stat.SplashScreen:
                    SplashScreen.Update();
                    if (Keyboard.GetState().IsKeyDown(Keys.Space)) Stat = Stat.Game;
                    break;  
                case Stat.Game:
                    Items.Update();
                    if (Keyboard.GetState().IsKeyDown(Keys.Escape)) Stat = Stat.SplashScreen;
                    break; 
            }

            //if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape)) Exit();
            SplashScreen.Update();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            _spriteBatch.Begin();
            switch(Stat)
            {
                case Stat.SplashScreen:
                    SplashScreen.Draw(_spriteBatch);
                    break;
                case Stat.Game:
                    Items.Draw();
                    break;
            }
            SplashScreen.Draw(_spriteBatch);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}