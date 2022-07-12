using System;
using System.Collections.Generic;
using System.Linq;

namespace cse210_finalProject.Game.Casting
{
    public class Platform : Actor
    {
        private List<Actor> segments = new List<Actor>();

        /// <summary>
        /// Constructs a new instance of the Platforms.
        /// </summary>
        public Platform()
        {
            PreparePlatforms();
        }
        
        /// <summary>
        /// Gets the platform segments
        /// </summary>
        /// <returns>A list of platform segments as instances of Actors.</returns>
        public List<Actor> GetSegments()
        {
            return segments;
        }

        /// <summary>
        /// Prepares the Platforms.
        /// </summary>
        private void PreparePlatforms()
        {
            // Platform 1
            int x = 0;
            int y = 3 * (Constants.MAX_Y / 2);

            for (int i = 0; i < Constants.BOTTOM_PLATFORM_LENGTH; i++)
            {
                Point position = new Point(x + i * Constants.CELL_SIZE, y);
                Point velocity = new Point(0, 0);
                string text = "_";
                Color color = Constants.GREEN;
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
