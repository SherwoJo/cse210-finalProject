using System;
using cse210_finalProject;
using cse210_finalProject.Game.Casting;
using cse210_finalProject.Game.Services;

namespace cse210_finalProject.Game.Scripting
{
    public class ControlActorsAction : Action
    {
        private KeyboardService keyboardService;
        private Point velocity = new Point(0, 0);

        /// <summary>
        /// Constructs a new instance of ControlActorsAction using the given KeyboardService.
        /// </summary>
        public ControlActorsAction(KeyboardService keyboardService)
        {
            this.keyboardService = keyboardService;
        }

        /// <inheritdoc/>
        public override void Execute(Cast cast, Script script)
        {
            Player player = (Player)cast.GetFirstActor("player");
            int x = player.GetVelocity().GetX();
            int y = player.GetVelocity().GetY();
            // left
            if (keyboardService.IsKeyDown("a"))
            {
                velocity = new Point(-Constants.CELL_SIZE, y);
            }
            // Right
            if (keyboardService.IsKeyDown("d"))
            {
                velocity = new Point(Constants.CELL_SIZE, y);
            }
            // Neither left or right
            if (keyboardService.IsKeyUp("a") && keyboardService.IsKeyUp("d"))
            {
                velocity = new Point(0, y);
            }

            // Jump
            if (keyboardService.IsKeyDown("w") && !player.isFalling)
            {
                velocity = new Point(x, -(Constants.JUMP_HEIGHT));
            }

            if (player.isFalling)
            {
                velocity = new Point(x, (player.GetVelocity().GetY() + Constants.GRAVITY));
            }

            player.SetVelocity(velocity);
        }
    }
}
