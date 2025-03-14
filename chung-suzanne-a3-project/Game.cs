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
    Coin[] coindropper = new Coin[50];
    Vector2 position;
    Vector2 velocity;
    int activeasteros = 0;
    int countBulletHitEdges;
    bool isGameOver;
    int maxBulletCount = 1000;
    int hitsRequired;

    public Player player = new Player();

    /// <summary>
    ///     Setup runs once before the game loop begins.
    /// </summary>
    public void Setup()
    {
        Window.SetTitle("Get Richer or Die Trying!");
        Window.SetSize(500, 500);

        player.position.X = Window.Width / 2;
        player.position.Y = Window.Height - 100;
;


    }

    /// <summary>
    ///     Update runs every frame.
    /// </summary>
    public void Update()
    {
        // Prepare for drawing
        Window.ClearBackground(Color.OffWhite);
        //Graphics.Draw(texture, 100, 100);
        player.Move();
        player.Render();
    }

    public void PlayGame()
    {
        Window.ClearBackground(Color.OffWhite);
        
        for (int i = 0; i < coindropper.Length; i++)
        {
            coindropper[i].coin();
        }

    }
}