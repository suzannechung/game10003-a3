using System;
using System.Drawing;
using System.Numerics;

namespace MohawkGame2D
{
    public class Player
    {
        public Vector2 position;
        public Vector2 size;
        public float colliderSize = 0;
        public float speed = 5f;

        public Player()
        {

        }

        public void Render()
        {
            Draw.LineSize = 0;
            Draw.FillColor = Color.Clear;
            Draw.Rectangle(position, size);

            //Player Texture
            Texture2D moneybag = Graphics.LoadTexture("../../../../assets/moneybag150.png");
            Graphics.Draw(moneybag, position - (Vector2.One * 10));
        }

        public void Update()
        {
            Move();
            ConstrainToWindow();
        }

        private void ConstrainToWindow()
        {
            bool isTouchingTop = position.Y - colliderSize <= 0;
            bool isTouchingBottom = position.Y + colliderSize >= Window.Height;
            bool isTouchingLeft = position.X - colliderSize <= 0;
            bool isTouchingRight = position.X + colliderSize >= Window.Width;

            if (isTouchingLeft)
                position.X = 0 + colliderSize;

            if (isTouchingRight)
                position.X = Window.Width - colliderSize;

            if (isTouchingTop)
                position.Y = 0 + colliderSize;

            if (isTouchingBottom)
                position.Y = Window.Height - colliderSize;
        }

        public void Move()
        {
            // Left and right movement of money bag only
            if (Input.IsKeyboardKeyDown(KeyboardInput.A) || Input.IsKeyboardKeyDown(KeyboardInput.Left)) 
                position.X -= speed;
            if (Input.IsKeyboardKeyDown(KeyboardInput.D) || Input.IsKeyboardKeyDown(KeyboardInput.Right)) 
                position.X += speed;

        }
    }
}