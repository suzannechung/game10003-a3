using System;
using System.Drawing;
using System.Numerics;

namespace MohawkGame2D
{
    public class Bomb
    {
        public Vector2 position;
        public Vector2 velocity;
        public Vector2 size;
        public float speed = 2f;
        public bool isVisible;

        Texture2D texture = Graphics.LoadTexture("../../../../assets/bomb40.png");

        public void bomb()
        {
            if (isVisible == true)
            {
                Draw.LineSize = 0;
                Draw.FillColor = Color.Clear;
                Draw.Rectangle(position, size);
                Graphics.Draw(texture, position);
            }
        }


        public void bombdrop()
        {
            // Accelerate velocity over time
            velocity.Y += Time.DeltaTime * speed/2;

            // Update position based on velocity
            position += velocity;

        }

        //have the bomb respawn back at the top of the window
        public bool respawnbomb()
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