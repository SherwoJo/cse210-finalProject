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
            // left
            if (keyboardService.IsKeyDown("a"))
            {
                velocity = new Point(-Constants.CELL_SIZE, 0);
            }

            // Right
            if (keyboardService.IsKeyDown("d"))
            {
                velocity = new Point(Constants.CELL_SIZE, 0);
            }

            // Jump
            if (keyboardService.IsKeyDown("w"))
            {
                velocity = new Point(0, -(Constants.JUMP_HEIGHT * Constants.CELL_SIZE));
            }

            Player player = (Player)cast.GetFirstActor("player");
            player.SetVelocity(velocity);
        }
    }
}
