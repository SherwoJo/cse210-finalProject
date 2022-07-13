using System;
using System.Collections.Generic;

namespace cse210_finalProject.Game.Casting
{
    public class Player : Actor
    {
        public bool isFalling { get; set; } = false;

        public Player(Cast cast)
        { 
            Platform platform = (Platform)cast.GetFirstActor("platform");
            List<Actor> platforms = platform.GetSegments();

            Random random = new Random();
            int segment = random.Next(platforms.Count);
            Point platformPosition = platforms[segment].GetPosition();
            int x = platformPosition.GetX();
            int y = platformPosition.GetY();

            Point position = new Point(x, y);
            Point velocity = new Point(0, 0);
            string text = "#";
            Color color = Constants.BLUE;
            SetPosition(position);
            SetVelocity(velocity);
            SetText(text);
            SetColor(color);
        }
        public override void MoveNext()
        {
            int x = (GetPosition().GetX() + GetVelocity().GetX() + Constants.MAX_X) % Constants.MAX_X;
            int y = (GetPosition().GetY() + GetVelocity().GetY());


            SetPosition(new Point(x, y));
        }
    }
}
