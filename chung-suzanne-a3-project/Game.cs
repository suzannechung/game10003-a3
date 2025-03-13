// Include the namespaces (code libraries) you need below.
using System;
using System.IO;
using System.Numerics;

// The namespace your code is in.
namespace MohawkGame2D;

/// <summary>
///     Your game code goes inside this class!
/// </summary>
public class Game
{
    // Place your variables here:
    const string assetFolder = "../../../../assets/";
    // Load graphic
    Texture2D texture = Graphics.LoadTexture(assetFolder + "mediAsteroids.png");

    Asteroids[] asteros = [new Asteroids(new Vector2(300, 200)), new Asteroids(new Vector2(100, 200)), new Asteroids(new Vector2(200, 200))];
    int activeasteros = 0;
    int countBulletHitEdges;
    bool isGameOver;
    int maxBulletCount = 1000;
    int hitsRequired;

    /// <summary>
    ///     Setup runs once before the game loop begins.
    /// </summary>
    public void Setup()
    {
        Window.SetTitle("Get the Asteroids!");
        Window.SetSize(500, 500);

    }

    /// <summary>
    ///     Update runs every frame.
    /// </summary>
    public void Update()
    {
        // Prepare for drawing
        //Window.ClearBackground(Color.OffWhite);
        //Graphics.Draw(texture, 100, 100);
        for (int i = 0; i < asteros.Length; i++)
        {
            asteros[i].Render();
   
        }

    }

    public void PlayGame()
    {
        Window.ClearBackground(Color.OffWhite);

        //player.Update();

        for (int i = 0; i < activeasteros; i++)
        {
            Asteroids bullet = asteros[i];
            bullet.Update();
            bullet.Render();
            activeasteros++;

            // does bullet hit player
            //float distance = Vector2.Distance(player.position, bullet.GetPosition());
            //if (distance < player.drawSize)
            //{
            //isGameOver = true;
            //}
        }

        //player.Render();
    }
}