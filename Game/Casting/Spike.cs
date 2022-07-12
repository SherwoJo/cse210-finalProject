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
        public Spike()
        {
            PrepareSpikes();
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
        private void PrepareSpikes()
        {
            // Bottom Spikes
            int x = 0;
            int y = Constants.MAX_Y;

            for (int i = 0; i < Constants.COLUMNS; i++)
            {
                Point position = new Point(x + i * Constants.CELL_SIZE, y);
                Point velocity = new Point(0, 0);
                string text = "A";
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
