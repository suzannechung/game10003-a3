using System;
using System.Drawing;
using System.Numerics;

namespace MohawkGame2D
{
    public class Coin
    {
        public Vector2 position;
        public Vector2 velocity;
        public Vector2 size;
        public float radius = 25;
        public float speed = 1f;
        public bool isVisible;

        Texture2D texture = Graphics.LoadTexture("../../../../assets/Coin50.png");

        public void coin()
        {
            if (isVisible == true)
            {
                Draw.LineSize = 0;
                Draw.FillColor = Color.Clear;
                Draw.Rectangle(position, size);
                Graphics.Draw(texture, position);
            }
        }


        public void coindrop()
        {
            // Accelerate velocity over time
            velocity.Y += Time.DeltaTime * speed;

            // Update position based on velocity
            position += velocity;

        }

        public bool respawncoin()
        {
            bool respawn = position.Y > Window.Height;
            if (respawn)
            {
                position.X = Random.Float(0, Window.Width - size.X);
                position.Y = Random.Float(-100, -size.Y);

                velocity = Vector2.Zero;
                isVisible = true;
            }
            return respawn;
        }


    }
}