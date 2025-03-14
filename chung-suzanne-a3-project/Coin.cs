using System;
using System.Drawing;
using System.Numerics;

namespace MohawkGame2D
{
    public class Coin
    {
        Vector2 position;
        Vector2 velocity;
        Vector2 size;
        float radius = 25;
        float speed = 5; // units of speed per second

        const string assetFolder = "../../../../assets/";
        Texture2D texture = Graphics.LoadTexture(assetFolder + "Coin100.png");

        public void coin()
        {
            Draw.LineSize = 0;
            Draw.FillColor = Color.Clear;
            Draw.Rectangle(position, size);
            Graphics.Draw(texture, position);
 
        }

        public void Render()
        {


        }

        public void Update()
        {
            // Accelerate velocity over time
            velocity.Y += Time.DeltaTime * speed;

            // Update position based on velocity
            position += velocity;

            // Constrain to left and right sides of the window
            bool isCollideLeft = position.X <= 0;
            bool isCollideRight = position.X >= Window.Width;
            bool isCollideTop = position.Y <= 0;
            bool isCollideBottom = position.Y >= Window.Height;

        }


        public Vector2 GetPosition()
        {
            return position;
        }
    }
}