using System;
using System.Collections.Generic;
using System.Data;
using cse210_finalProject.Game.Casting;
using cse210_finalProject.Game.Services;

namespace cse210_finalProject.Game.Scripting
{
    public class HandleCollisionsAction : Action
    {
        private bool isGameOver = false;

        /// <summary>
        /// Constructs a new instance of HandleCollisionsAction.
        /// </summary>
        public HandleCollisionsAction()
        {
        }

        /// <inheritdoc/>
        public override void Execute(Cast cast, Script script)
        {
            if (isGameOver == false)
            {
                HandlePlatformCollisions(cast);
                HandleCoinCollisions(cast);
                HandleSpikeCollisions(cast);
                HandleGameOver(cast);
            }
        }

        /// <summary>
        /// Causes the player to stop falling when standing on a platform.
        /// </summary>
        /// <param name="cast">The cast of actors.</param>
        private void HandlePlatformCollisions(Cast cast)
        {
            Player player = (Player)cast.GetFirstActor("player");
            Platform platform = (Platform)cast.GetFirstActor("platform");
            List<Actor> platforms = platform.GetSegments();

            bool isPlayerFalling = true;
            foreach (Actor segment in platforms)
            {
                if (Math.Abs(segment.GetPosition().GetX() - player.GetPosition().GetX()) <= (Constants.CELL_SIZE / 2) && Math.Abs(segment.GetPosition().GetY() - player.GetPosition().GetY()) <= player.GetVelocity().GetY())
                {
                    Point velocity = new Point(player.GetVelocity().GetX(), 0);
                    Point position = new Point(segment.GetPosition().GetX(), segment.GetPosition().GetY());
                    player.SetVelocity(velocity);
                    player.SetPosition(position);
                    isPlayerFalling = false;
                }
            }
            player.isFalling = isPlayerFalling;
        }

        /// <summary>
        /// Adds one to the score if the player collects a coin.
        /// </summary>
        /// <param name="cast">The cast of actors.</param>
        private void HandleCoinCollisions(Cast cast)
        {
            Player player = (Player)cast.GetFirstActor("player");
            Coin coin = (Coin)cast.GetFirstActor("coin");
            Score score = (Score)cast.GetFirstActor("score");

            if (Math.Abs(coin.GetPosition().GetX() - player.GetPosition().GetX()) <= (Constants.CELL_SIZE) && Math.Abs((coin.GetPosition().GetY() - player.GetPosition().GetY())) <= Constants.CELL_SIZE)
            {
                coin.SetText("");
                score.AddPoints(1);
                coin.GenerateCoin(cast);
            }
        }

        /// <summary>
        /// Sets the game over flag if the player collides with a spike.
        /// </summary>
        /// <param name="cast">The cast of actors.</param>
        private void HandleSpikeCollisions(Cast cast)
        {
            Player player = (Player)cast.GetFirstActor("player");
            Spike spike = (Spike)cast.GetFirstActor("spike");
            List<Actor> spikes = spike.GetSegments();

            foreach (Actor segment in spikes)
            {
                if (Math.Abs(segment.GetPosition().GetX() - player.GetPosition().GetX()) <= (Constants.CELL_SIZE / 2) && (segment.GetPosition().GetY() == player.GetPosition().GetY()))
                {
                    Point velocity = new Point(0, 0);
                    player.SetVelocity(velocity);
                    isGameOver = true;
                }
            }
        }

        private void HandleGameOver(Cast cast)
        {
            if (isGameOver == true)
            {
                Player player = (Player)cast.GetFirstActor("player");
                Platform platform = (Platform)cast.GetFirstActor("platform");
                List<Actor> platforms = platform.GetSegments();
                Spike spike = (Spike)cast.GetFirstActor("spike");
                List<Actor> spikes = spike.GetSegments();

                // create a "game over" message
                int x = Constants.MAX_X / 2;
                int y = Constants.MAX_Y / 2;
                Point position = new Point(x, y);

                Actor message = new Actor();
                message.SetText("Game Over!");
                message.SetPosition(position);
                cast.AddActor("messages", message);

                // make everything white
                player.SetColor(Constants.WHITE);
                foreach (Actor segment in platforms)
                {
                    segment.SetColor(Constants.WHITE);
                }
                foreach (Actor segment in spikes)
                {
                    segment.SetColor(Constants.WHITE);
                }
            }
        }
    }
}
