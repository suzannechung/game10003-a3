using System;
using System.Numerics;

namespace MohawkGame2D
{
    public class Asteroids
    {
        Vector2 position;
        Vector2 direction;
        float speed = 200;
        float radius;
        Color color;
        bool hasHitScreenEdge;


        public Asteroids(Vector2 pos)
        {
            position = pos;

            // Give bullet a random direction and fixed speed
            direction = Random.Direction();
        }

        public void Render()
        {
            const string assetFolder = "../../../../assets/";
            Texture2D texture = Graphics.LoadTexture(assetFolder + "mediAsteroids.png");
            Graphics.Draw(texture, position);
        }

        public void Update()
        {
            // add to speed
            speed += Time.DeltaTime * 5;

            // Add velocity to position, scaled by time
            position += direction * speed * Time.DeltaTime;

        }

        public bool HasHitScreenEdge()
        {
            bool hitScreenEdge = hasHitScreenEdge;
            hasHitScreenEdge = false;
            return hitScreenEdge;
        }

        public Asteroids CreateClone()
        {
            Asteroids clone = new Asteroids(position);

            // Add random deviation
            Vector2 deviation1 = Random.Direction() / 3;
            Vector2 deviation2 = Random.Direction() / 3;
            // Reconstruct direction and reapply speed
            this.direction = Vector2.Normalize(direction + deviation1);
            clone.direction = Vector2.Normalize(direction + deviation2);

            return clone;
        }

        public Vector2 GetPosition()
        {
            return position;
        }
    }
}