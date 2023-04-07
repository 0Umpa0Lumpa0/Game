using System;
using System.Collections.Generic;
using System.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace game
{
    class Items
    {
        public static int Width, Height;
        public static Random rnd = new Random();
        static public SpriteBatch SpriteBatch { get; set; }
        static Star[] stars;

        static public int GetIntRnd(int min, int max)
        {
            return rnd.Next(min, max);
        }
        
        static public void Init(SpriteBatch SpriteBatch, int Width, int Height)
        {
            Items.Width = Width;
            Items.Height = Height;  
            Items.SpriteBatch = SpriteBatch;
            var stars = new Star[75];
            for (int count = 0; count < stars.Length; count++)
                stars[count] = new Star(new Vector2(-rnd.Next(1, 10), 0));
        }
        
        static public void Draw()
        {
            foreach (Star star in stars)
                star.Draw();
        }
         static public void Update()
        {
            foreach (Star star in stars)
                star.Update();
        }
    }

    class Star
    {
        Vector2 Position;
        Vector2 Direction;
        Color color;

        public static Texture2D Texture2D { get; set; }
        public Star (Vector2 Position, Vector2 Direction)
        {
            this.Position = Position;
            this.Direction = Direction;
        }

        public Star(Vector2 Direction)
        {
            this.Direction = Direction;
            RandomSet();
        }
        
        public void Update()
        {
            Position += Direction;
            if (Position.X <0)
            {
                RandomSet();
            }
        }

        public void RandomSet()
        {
            Position = new Vector2(Items.GetIntRnd(Items.Width, Items.Width + 300), Items.GetIntRnd(0, Items.Height));
            color = Color.FromNonPremultiplied(Items.GetIntRnd(0, 256), Items.GetIntRnd(0, 256), Items.GetIntRnd(0, 256), 255);
        }

        public void Draw()
        {
            Items.SpriteBatch.Draw(Texture2D, Position, color);
        }


    }
}
