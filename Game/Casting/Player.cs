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
        public override void MoveNext()
        {
            int x = ((GetPosition().GetX() + GetVelocity().GetX()) + Constants.MAX_X) % Constants.MAX_X;
            int y = ((GetPosition().GetY() + GetVelocity().GetY()) + Constants.MAX_Y) % Constants.MAX_Y;
            SetPosition(new Point(x, y));

            // Update the player's velocity due to friction and gravity.
            if (isFalling)
            {
                int x1 = 0;
                int y1 = GetVelocity().GetY() + Constants.GRAVITY;
                Point newVelocity = new Point(x1, y1);
                SetVelocity(newVelocity);
            }
        }
    }
}
