using System;

namespace cse210_finalProject.Game.Casting
{
    public class Player : Actor
    {
        public bool isFalling { get; set; } = false;

        public Player()
        { 
            string text = "#";
            Color color = Constants.BLUE;
            Point position = new Point(Constants.CELL_SIZE, 3 * (Constants.MAX_Y / 2));
            Point velocity = new Point(0, 0);

            SetText(text);
            SetColor(color);
            SetPosition(position);
            SetVelocity(velocity);
        }
    }
}
