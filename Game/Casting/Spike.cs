using System;
using System.Collections.Generic;
using System.Linq;

namespace cse210_finalProject.Game.Casting
{
    public class Spike : Actor
    {
        private List<Actor> segments = new List<Actor>();

        /// <summary>
        /// Constructs a new instance of the Spikes.
        /// </summary>
        public Spike(Cast cast)
        {
            PrepareSpikes(cast);
        }
        
        /// <summary>
        /// Gets the spike segments
        /// </summary>
        /// <returns>A list of spike segments as instances of Actors.</returns>
        public List<Actor> GetSegments()
        {
            return segments;
        }

        /// <summary>
        /// Prepares the Spikes.
        /// </summary>
        private void PrepareSpikes(Cast cast)
        {
            // Bottom Spikes
            int x = 0;
            int y = Constants.MAX_Y - Constants.CELL_SIZE;

            for (int i = 0; i < Constants.COLUMNS; i++)
            {
                Point position = new Point(x + i * Constants.CELL_SIZE, y);
                Point velocity = new Point(0, 0);
                string text = "W";
                Color color = Constants.RED;
                Actor segment = new Actor();
                segment.SetPosition(position);
                segment.SetVelocity(velocity);
                segment.SetText(text);
                segment.SetColor(color);
                segments.Add(segment);
            }

            // Random Spikes
            Player player = (Player)cast.GetFirstActor("player");
            Platform platform = (Platform)cast.GetFirstActor("platform");
            List<Actor> platforms = platform.GetSegments();
            Random random = new Random();
            for (int i = 0; i < Constants.NUMBER_OF_SPIKES; i++)
            {
                int randomPlatform = random.Next(platforms.Count);
                Point platformPosition = platforms[randomPlatform].GetPosition();
                x = platformPosition.GetX();
                y = platformPosition.GetY();

                Point position = new Point(x, y);
                // Ensure that a spike doesn't spawn on top of the player
                if (position == player.GetPosition())
                {
                    i = i - 1;
                    continue;
                }
                Point velocity = new Point(0, 0);
                string text = "W";
                Color color = Constants.RED;
                Actor segment = new Actor();
                segment.SetPosition(position);
                segment.SetVelocity(velocity);
                segment.SetText(text);
                segment.SetColor(color);
                segments.Add(segment);
            }
        }
    }
}
