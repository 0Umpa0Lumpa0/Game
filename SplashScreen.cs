using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace game
{
    static class SplashScreen
    {
        public static Texture2D Background { get; set }
        static int TimeCounter = 0;
        static Color color;

        stutic public void Draw (SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(Background, Vector2.Zero, color);
        }

        stutic public  void Update()
        {
            color = Color.FromNonPremultipiled(255, 255, 255, TimeCounter % 256);
            TimeCounter++;
        }
    }
}
