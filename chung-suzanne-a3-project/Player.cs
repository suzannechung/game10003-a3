using System;
using System.Drawing;
using System.Numerics;

namespace MohawkGame2D
{
    public class Player
    {
        public Vector2 position;
        public Vector2 size;
        public float speed = 5f;
        public int coinscollected;

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
            Graphics.Draw(moneybag, position);
        }

        public void Update()
        {
            Move();

        }


        //player movement is left or right
        public void Move()
        {
            // Left and right movement of money bag only
            if (Input.IsKeyboardKeyDown(KeyboardInput.A) || Input.IsKeyboardKeyDown(KeyboardInput.Left)) 
                position.X -= speed;
            if (Input.IsKeyboardKeyDown(KeyboardInput.D) || Input.IsKeyboardKeyDown(KeyboardInput.Right)) 
                position.X += speed;

            if (position.X < 0) 
                position.X = 0;
            if (position.X + size.X > Window.Width)
                position.X = Window.Width - size.X;

        }

        //Coin collision check!
        public bool isMoneyCollected(Coin coin)
        {
            if (coin.isVisible == false)
                return false;

            float playerLeft = position.X;
            float playerRight = position.X + size.X;
            float playerTop = position.Y;
            float playerBottom = position.Y + size.Y;

            float coinLeft = coin.position.X;
            float coinRight = coin.position.X + coin.size.X;
            float coinTop = coin.position.Y;
            float coinBottom = coin.position.Y + coin.size.Y;

            bool CheckLeftHit = playerRight > coinLeft;
            bool CheckRightHit = playerLeft < coinRight;
            bool CheckTopHit = playerBottom > coinTop;
            bool CheckBottomHit = playerTop < coinBottom;
            bool isCollected = CheckLeftHit && CheckRightHit && CheckTopHit && CheckBottomHit;

            return isCollected;
        }

        //Bomb collision check!
        public bool didyouhitbomb(Bomb bomb)
        {
            if (bomb.isVisible == false)
                return false;

            float playerLeft = position.X;
            float playerRight = position.X + size.X;
            float playerTop = position.Y;
            float playerBottom = position.Y + size.Y;

            float bombLeft = bomb.position.X;
            float bombRight = bomb.position.X + bomb.size.X;
            float bombTop = bomb.position.Y;
            float bombBottom = bomb.position.Y + bomb.size.Y;

            bool CheckLeftHit = playerRight > bombLeft;
            bool CheckRightHit = playerLeft < bombRight;
            bool CheckTopHit = playerBottom > bombTop;
            bool CheckBottomHit = playerTop < bombBottom;
            bool didyouhit = CheckLeftHit && CheckRightHit && CheckTopHit && CheckBottomHit;

            return didyouhit;
        }
    }
}