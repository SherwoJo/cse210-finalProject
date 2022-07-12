using System;
using System.Collections.Generic;

namespace cse210_finalProject.Game.Casting
{
    public class Coin : Actor
    {
        public Coin(Cast cast)
        {
            GenerateCoin(cast);
        }

        // Places a coin above a random Platform segment.
        public void GenerateCoin(Cast cast)
        {
            Platform platform = (Platform)cast.GetFirstActor("platform");
            List<Actor> platforms = platform.GetSegments();

            Random random = new Random();
            int segment = random.Next(platforms.Count + 1);
            Point platformPosition = platforms[segment].GetPosition();
            int x = platformPosition.GetX();
            int y = platformPosition.GetY();

            Point coinPosition = new Point(x, y + 2);
            Point velocity = new Point(0, 0);
            string text = "*";
            Color color = Constants.YELLOW;
            Actor coin = new Actor();
            coin.SetPosition(coinPosition);
            coin.SetVelocity(velocity);
            coin.SetText(text);
            coin.SetColor(color);

            cast.AddActor("coin", coin);
        }
    }
}
