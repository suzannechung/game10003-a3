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
        Window.ClearBackground(Color.OffWhite);
        Graphics.Draw(texture, 100, 100);
    }
}