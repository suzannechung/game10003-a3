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
    Coin[] coins = new Coin[10];
    public Player player = new Player();
    int coincounter = 1;

    /// <summary>
    ///     Setup runs once before the game loop begins.
    /// </summary>
    public void Setup()
    {
        Window.SetTitle("Get Richer or Die Trying!");
        Window.SetSize(500, 500);

        player.position.X = Window.Width / 2;
        player.position.Y = Window.Height - 140;
        player.size.X = 100;
        player.size.Y = 100;
        player.coinscollected = 0;
        
        //randomly assign coins at the top
        for (int i = 0; i < coins.Length; i++)
        {
            Coin coin_im = new Coin();
            coin_im.size = new Vector2(50, 50);
            coin_im.isVisible = true;
            coin_im.position.X = Random.Float(50, Window.Width - coin_im.size.X);
            coin_im.position.Y = -coin_im.size.Y;

            coins[i] = coin_im;
        }

    }

    /// <summary>
    ///     Update runs every frame.
    /// </summary>
    public void Update()
    {
        if (player.coinscollected < 20)
            PlayGame();

        if (player.coinscollected == 20)
            GameOverWinner();
    }
    public void PlayGame()
    {
        // Prepare for drawing
        Window.ClearBackground(Color.LightGray);

        player.Move();
        player.Render();

        for (int i = 0; i < coins.Length; i++)
        {
            coins[i].coin();
        }

        for (int i = 0; i < coincounter; i++)
        {
            coins[i].coindrop();

            bool didyoucollect = player.isMoneyCollected(coins[i]);
            if (didyoucollect == true)
            {
                coins[i].isVisible = false;
                player.coinscollected += 1;
            }

            bool didcoinpass = coins[i].respawncoin();
            if (didcoinpass && coincounter < coins.Length)
            {
                coincounter++;
            }
        }

        //Players can track how many coins they've collected so far
        Text.Size = 25;
        Text.Draw($"Coins Collected: {player.coinscollected}", new Vector2(10, 10));


    }

    public void GameOverWinner()
    {
        Window.ClearBackground(Color.LightGray);
        Text.Size = 20;
        Text.Draw("WINNER! GAME OVER!", new Vector2(150, 200));
        Text.Draw("Press Space to Play Again!", new Vector2(150, 250));
    }

    public void GameOverLoser()
    {
        Window.ClearBackground(Color.LightGray);
        Text.Size = 20;
        Text.Draw("YOU LOST! GAME OVER!", new Vector2(150, 200));
        Text.Draw("Press Space to Play Again!", new Vector2(150, 250));
    }
}